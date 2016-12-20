using System.Collections.Generic;
using System.Linq;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Model.ViewModels.Internal;

namespace DoubleJ.Oms.Model.Repositories
{
    public class ColdWeightEntryDetailRepository : GenericRepository<ColdWeightEntryDetail>, IColdWeightEntryDetailRepository
    {
        public ColdWeightEntryDetailRepository(IOmsContext context)
            : base(context)
        {
        }
        public bool CheckIfAnimalNumberAlreadyExists(string valueToCheck)
        {
            return Context.ColdWeightEntryDetail.Any(x => x.AnimalNumber == valueToCheck);
        }
        public bool CheckIfEarTagAlreadyExists(string valueToCheck)
        {
            return Context.ColdWeightEntryDetail.Any(x => x.EarTag == valueToCheck);
        }

        public Dictionary<OmsSideType, int?> GetSideWeigths(int coldWeightDetailId)
        {
            var sideWeigths = new Dictionary<OmsSideType, int?>();
            if (!Context.ColdWeightEntryDetail.Any(it => it.Id == coldWeightDetailId))
                return null;

            foreach (var entity in Context.ColdWeightEntryDetail.Where(it => it.Id == coldWeightDetailId))
            {
                sideWeigths.Add(OmsSideType.FirstSide, entity.FirstSideWeight);
                sideWeigths.Add(OmsSideType.SecondSide, entity.SecondSideWeight);
                sideWeigths.Add(OmsSideType.ThirdSide, entity.ThirdSideWeight);
                sideWeigths.Add(OmsSideType.FourthSide, entity.FourthSideWeight);
            }
            
            return sideWeigths;
        }

        public bool RemoveAllDetails(int coldId)
        {
            if (!Context.ColdWeightEntryDetail.Any(it => it.ColdWeightId == coldId))
                return false;

            foreach (var entity in Context.ColdWeightEntryDetail.Where(it => it.ColdWeightId == coldId))
                Context.ColdWeightEntryDetail.Remove(entity);

            Context.SaveChanges();
            return true;
        }

    }
}
