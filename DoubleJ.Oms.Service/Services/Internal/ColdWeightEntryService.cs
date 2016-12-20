using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Model.ViewModels.Internal;
using DoubleJ.Oms.Service.Interfaces;
using DoubleJ.Oms.Utils.Extensions;


namespace DoubleJ.Oms.Service.Services.Internal
{
    public class ColdWeightEntryService : IColdWeightEntryService
    {
        private readonly IColdWeightEntryRepository _coldWeightEntryRepository;
        private readonly IAnimalLabelRepository _animalLabelRepository;
        private readonly IQualityGradeRepository _qualityGradeRepository;
        private readonly ISpeciesRepository _speciesRepository;
        private readonly IColdWeightEntryDetailRepository _coldWeightEntryDetailRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailService _orderDetailService;



        public ColdWeightEntryService(IOrderDetailService orderDetailService, IColdWeightEntryDetailRepository coldWeightEntryDetailRepository, 
            IOrderRepository orderRepository, IColdWeightEntryRepository coldWeightEntryRepository,IAnimalLabelRepository animalLabelRepository,
            IQualityGradeRepository qualityGradeRepository,ISpeciesRepository speciesRepository)
        {
            _coldWeightEntryRepository = coldWeightEntryRepository;
            _animalLabelRepository = animalLabelRepository;
            _qualityGradeRepository = qualityGradeRepository;
            _speciesRepository = speciesRepository;
            _coldWeightEntryDetailRepository = coldWeightEntryDetailRepository;
            _orderRepository = orderRepository;
            _orderDetailService = orderDetailService;
        }


        public ColdWeightEntryModel Get(int orderId)
        {
            return new ColdWeightEntryModel
            {
                OrderId = orderId
            };
        }

        public ColdWeightCutSheetViewModel GetCutSheetViewModel(int orderId)
        {
            var order = _orderRepository.Get(orderId);
            var viewModel = new ColdWeightCutSheetViewModel
            {
                OrderId = orderId,
                CustomerId = order.CustomerId,
                CustomerName = order.Customer.Name,
                StatusName = order.Status.Name,
                RequestedProcessDate = order.RequestedProcessDate,
                ExpectedHeadNumber = order.ExpectedHeadNumber
            };

            return viewModel;
        }
        //get base coldweight entry
        public ColdWeightEntryDetailItem GetColdWeightEntryDetail(int orderId)
        {
            var customerId = _orderRepository.Get(orderId).CustomerId;
            var coldWeightEntry = _coldWeightEntryRepository.GetByOrderId(orderId);
            var qualitiesList = new SelectList(_qualityGradeRepository.GetAll().Select(x => new QualityGrade()
            {
                Id = x.Id,
                Name = x.Name
            }), "Id", "Name");
            int speciesId =0;
            if (coldWeightEntry != null && coldWeightEntry.ColdWeightEntryDetails != null)
            {
                var coldWeightEntryDetail = coldWeightEntry.ColdWeightEntryDetails.FirstOrDefault();
                speciesId = coldWeightEntry != null && coldWeightEntry.ColdWeightEntryDetails.Any()
                    ? coldWeightEntryDetail.AnimalLabel.SpeciesId: 0;
            }
            var species =
                new List<SpeciesViewModel>(_speciesRepository.GetAll().Select(x => new SpeciesViewModel()
                {   
                    Id = x.Id,
                    Name = x.Name
                }));
            var speciesViewModel = species.FirstOrDefault(x=> { return speciesId != 0 && x.Id == speciesId; });
                var coldweightDetailItem = new ColdWeightEntryDetailItem
                {
                    AnimalLabelId = speciesViewModel != null ? speciesViewModel.Id: (int?) null,
                    AnimalLabel =  new AnimalLabelsViewModel() { Species = speciesViewModel },
                    TrackAnimalBy = coldWeightEntry != null ? coldWeightEntry.TrackAnimalId : TrackAnimal.Whole,
                    OrderId = orderId,
                    IsExist = coldWeightEntry != null && coldWeightEntry.ColdWeightEntryDetails.Any(),
                    CustomerLocations = new SelectList(_orderDetailService.GetCustomerLocations(customerId), "CustomerLocationId", "CustomerLocationName"),
                    SpeciesList = new SelectList(species, "Id", "Name"),
                    QualityGradeList = qualitiesList
                };
                return coldweightDetailItem;
        }


        public ColdWeightEntryModel GetColdWeightEntryPreferences(int? orderId)
        {
            if (!orderId.HasValue)
            {
                return new ColdWeightEntryModel();
            }

            var order = _orderRepository
                .Query()
                .Where(x => x.Id == orderId.Value)
                .Include(x => x.Customer)
                .Select(x => new
                {
                    x.Id,
                    x.Customer.Name,
                    x.ExpectedHeadNumber,
                    x.ReceivedHeadNumber,
                    x.SlaughteredHeadNumber
                })
                .FirstOrDefault();

            if (order == null)
            {
                return new ColdWeightEntryModel();
            }

            var coldWeightEntry = _coldWeightEntryRepository.GetByOrderId(orderId.Value);

            if (coldWeightEntry == null)
            {
                coldWeightEntry = new ColdWeightEntry
                {
                    OrderId = orderId.Value
                };

                _coldWeightEntryRepository.Add(coldWeightEntry);
                _coldWeightEntryRepository.Save();
            }

            return new ColdWeightEntryModel
            {
                OrderId = order.Id,
                Customer = order.Name,
                HeadExpected = order.ExpectedHeadNumber,
                HeadReceived = order.ReceivedHeadNumber,
                HeadProcessed = order.SlaughteredHeadNumber,
                QualityGradeId = coldWeightEntry.QualityGradeId,
                TotalCount = coldWeightEntry.TotalCount,
                TotalWeight = coldWeightEntry.TotalWeight,
                
            };
        }

        //get coldweight entry detail items
        public IEnumerable<ColdWeightEntryDetailItem> GetItems(int orderId)
        {
            var coldWeightEntry = _coldWeightEntryRepository.GetByOrderId(orderId);

            if (coldWeightEntry == null)
            {
                return Enumerable.Empty<ColdWeightEntryDetailItem>();
            }

            var coldWeightIndex = 0;
            return coldWeightEntry
                .ColdWeightEntryDetails
                .OrderBy(x => x.CreatedDate)
                .Select(x => new ColdWeightEntryDetailItem
                {
                    Id = x.Id,
                    ColdWeightId = x.ColdWeightId,
                    AnimalNumber = x.AnimalNumber,
                    EarTag = x.EarTag,
                    FirstCustomer = CreateCustomerLocationItem(x, x.FirstSideWeight),
                    SecondCustomer =
                        (x.ColdWeightEntry.TrackAnimalId == TrackAnimal.Half ||
                         x.ColdWeightEntry.TrackAnimalId == TrackAnimal.Quarter||
                         coldWeightEntry.TrackAnimalId == TrackAnimal.HalfAndTwoQuaters ||
                         coldWeightEntry.TrackAnimalId == TrackAnimal.ThreeQuatersAndQuater)
                            ? CreateCustomerLocationItem(x, x.SecondSideWeight) : null,
                    ThirdCustomer =
                        (x.ColdWeightEntry.TrackAnimalId == TrackAnimal.Quarter || coldWeightEntry.TrackAnimalId == TrackAnimal.HalfAndTwoQuaters)
                            ? CreateCustomerLocationItem(x, x.ThirdSideWeight) : null,
                    FourthCustomer =
                        (x.ColdWeightEntry.TrackAnimalId == TrackAnimal.Quarter)
                            ? CreateCustomerLocationItem(x, x.FourthSideWeight) : null,
                    IsOrganic = x.IsOrganic,
                    HotWeight = x.HotWeight,
                    ColdWeight = x.ColdWeight,
                    QualityGrade =  new QualityGrade() {Id = x.QualityGrade.Id,
                    Name = x.QualityGrade.Name},
                    TrackAnimalBy = x.TrackAnimalId,
                    TrackAnimalBySelectColumn = x.TrackAnimalId,
                    Rank = (++coldWeightIndex),
                    AnimalLabel = CreateAnimalLabelItem(x.AnimalLabel)
                })
                .OrderByDescending(x => x.Rank)
                .ToArray();
        }

        private static OrderDetailCustomerLocationItem CreateCustomerLocationItem(ColdWeightEntryDetail x, int? locationId)
        {
            return new OrderDetailCustomerLocationItem
            {
                CustomerLocationId = locationId,
                CustomerLocationName = GetCustomerName(x.ColdWeightEntry.Order.Customer.CustomerLocation, locationId)
            };
        }

        private static AnimalLabelsViewModel CreateAnimalLabelItem(AnimalLabel item)
        {
            return new AnimalLabelsViewModel()
            {
                Name = item.Name,
                Id = item.Id,
                Species =  new SpeciesViewModel()
                {
                    Name = item.Species.Name,
                    Id = item.SpeciesId
                }
            };
        }

        private static string GetCustomerName(ICollection<CustomerLocation> locations, int? locationId)
        {
            return locationId.HasValue ? locations.First(c => c.Id == locationId.Value).Name : "";
        }

        public void Update(ColdWeightEntryModel coldWeightEntryItem)
        {
            if (coldWeightEntryItem.OrderId != null)
            {
                var coldWeightEntry = _coldWeightEntryRepository.GetByOrderId(coldWeightEntryItem.OrderId.Value);
                if (coldWeightEntry != null)
                {
                    coldWeightEntry.QualityGradeId = coldWeightEntryItem.QualityGradeId;
                    _coldWeightEntryRepository.Save();
                }
            }
        }



        public void Save(IEnumerable<ColdWeightEntryDetailItem> newarray, int orderId, TrackAnimal trackAnimal)
        {
            var coldWeightEntry = _coldWeightEntryRepository.GetByOrderId(orderId);
            if (coldWeightEntry == null)
            {
                coldWeightEntry = new ColdWeightEntry
                {
                    OrderId = orderId,
                    TrackAnimalId = trackAnimal
                };
                _coldWeightEntryRepository.Add(coldWeightEntry);
            }
            coldWeightEntry.TrackAnimalId = trackAnimal;
                _coldWeightEntryRepository.Save();

            List<ColdWeightEntryDetail> newColdWeightDetails = new List<ColdWeightEntryDetail>();
            foreach (var newItem in newarray)
            {
                newColdWeightDetails.Add(new ColdWeightEntryDetail
                {
                    Id = newItem.Id,
                    ColdWeightId = coldWeightEntry.Id,
                    AnimalNumber = newItem.AnimalNumber,
                    EarTag = newItem.EarTag,
                    FirstSideWeight = newItem.FirstCustomer.CustomerLocationId,
                    SecondSideWeight = (trackAnimal == TrackAnimal.Half || trackAnimal == TrackAnimal.Quarter || 
                        coldWeightEntry.TrackAnimalId == TrackAnimal.HalfAndTwoQuaters || coldWeightEntry.TrackAnimalId == TrackAnimal.ThreeQuatersAndQuater) ? newItem.SecondCustomer.CustomerLocationId : null,
                    ThirdSideWeight = (trackAnimal == TrackAnimal.Quarter || trackAnimal == TrackAnimal.HalfAndTwoQuaters) ? newItem.ThirdCustomer.CustomerLocationId : null,
                    FourthSideWeight = trackAnimal == TrackAnimal.Quarter ? newItem.FourthCustomer.CustomerLocationId : null,
                    IsOrganic = newItem.IsOrganic,
                    TrackAnimalId = newItem.TrackAnimalBySelectColumn,
                    HotWeight = newItem.HotWeight,
                    ColdWeight = newItem.ColdWeight,
                    QualityGradeId = newItem.QualityGrade.Id,
                    AnimalLabelId = newItem.AnimalLabel.Id,
                });
            }

            if (coldWeightEntry.ColdWeightEntryDetails.Any())
            {
                var existingIds = coldWeightEntry.ColdWeightEntryDetails.Select(ord => ord.Id).ToList();
                foreach (var item in newColdWeightDetails)
                {
                    if (existingIds.Contains(item.Id))
                        _coldWeightEntryDetailRepository.Update(newColdWeightDetails.First(x => x.Id == item.Id));
                    else
                        _coldWeightEntryDetailRepository.Add(item);
                }
            }
            else
                _coldWeightEntryDetailRepository.AddRange(newColdWeightDetails);

            _coldWeightEntryDetailRepository.Save();
        }

        public bool CheckIfAnimalNumberAlreadyExists(string valueToCheck)
        {
            return _coldWeightEntryDetailRepository.CheckIfAnimalNumberAlreadyExists(valueToCheck);
        }

        public bool CheckIfEarTagAlreadyExists(string valueToCheck)
        {
            return _coldWeightEntryDetailRepository.CheckIfEarTagAlreadyExists(valueToCheck);
        }

        public IEnumerable<ColdWeightEntryDetailItem> AddDetail(List<ColdWeightEntryDetailItem> array,
            ColdWeightEntryDetailItem item)
        {
            List<ColdWeightEntryDetailItem> coldWeightEntryDetailItems = new List<ColdWeightEntryDetailItem>();

            if (array != null)
            {
                var arrayNewAnimalNumbers = new List<int>();
                if (item.StartNumber >= item.EndNumber || item.EndNumber == null)
                {
                    arrayNewAnimalNumbers.Add(item.StartNumber.Value);
                }
                else
                {
                    for (int i = item.StartNumber.Value; i <= item.EndNumber; i++)
                    {
                        arrayNewAnimalNumbers.Add(i);
                    }
                }

                foreach (var coldWeightEntryDetailItem in array)
                {
                    if (arrayNewAnimalNumbers.Contains(Convert.ToInt32(coldWeightEntryDetailItem.AnimalNumber)))
                    {
                        arrayNewAnimalNumbers.Remove(Convert.ToInt32(coldWeightEntryDetailItem.AnimalNumber));
                    }
                }

                foreach (var arrayNewAnimalNumber in arrayNewAnimalNumbers)
                {
                    coldWeightEntryDetailItems.Add(new ColdWeightEntryDetailItem
                    {
                        AnimalNumber = arrayNewAnimalNumber.ToString(),
                        IsOrganic = item.Organic,
                        FirstCustomer = item.FirstCustomer,
                        SecondCustomer = item.SecondCustomer,
                        ThirdCustomer = item.ThirdCustomer,
                        FourthCustomer = item.FourthCustomer,
                        TrackAnimalBy = item.TrackAnimalBy,
                        AnimalLabel = item.AnimalLabel,
                        QualityGrade = item.QualityGrade,
                        TrackAnimalBySelectColumn = item.TrackAnimalBy
                    });
                }
            }
            else
            {
                if (item.StartNumber >= item.EndNumber)
                {
                    coldWeightEntryDetailItems.Add(new ColdWeightEntryDetailItem
                    {
                        AnimalNumber = item.StartNumber.ToString(),
                        IsOrganic = item.Organic,
                        FirstCustomer = item.FirstCustomer,
                        SecondCustomer = item.SecondCustomer,
                        ThirdCustomer = item.ThirdCustomer,
                        FourthCustomer = item.FourthCustomer,
                        AnimalLabel = item.AnimalLabel,
                        QualityGrade = item.QualityGrade,
                        TrackAnimalBy = item.TrackAnimalBy,
                        TrackAnimalBySelectColumn = item.TrackAnimalBy
                    });
                }
                else
                {
                    for (int i = item.StartNumber.Value; i < item.EndNumber; i++)
                    {
                        coldWeightEntryDetailItems.Add(new ColdWeightEntryDetailItem
                        {
                            AnimalNumber = i.ToString(),
                            IsOrganic = item.Organic,
                            FirstCustomer = item.FirstCustomer,
                            SecondCustomer = item.SecondCustomer,
                            ThirdCustomer = item.ThirdCustomer,
                            FourthCustomer = item.FourthCustomer,
                            AnimalLabel = item.AnimalLabel,
                            QualityGrade = item.QualityGrade,
                            TrackAnimalBy = item.TrackAnimalBy,
                            TrackAnimalBySelectColumn = item.TrackAnimalBy
                        });
                    }
                }
            }

           return coldWeightEntryDetailItems;
        }

        public bool RemoveDetail(ColdWeightEntryDetailItem coldWeightEntryDetailItem)
        {
            if (coldWeightEntryDetailItem.Id == 0)
                return false;

            var coldWeightEntryDetail = _coldWeightEntryDetailRepository.Get(coldWeightEntryDetailItem.Id);
            if (coldWeightEntryDetail == null)
                return false;

            _coldWeightEntryDetailRepository.Remove(coldWeightEntryDetail);
            _coldWeightEntryDetailRepository.Save();
            return true;
        }

        public bool RemoveAllDetails(int coldWeightId)
        {
            return _coldWeightEntryDetailRepository.RemoveAllDetails(coldWeightId);
        }
    }
}