using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.ViewModels.Internal;
using Microsoft.Ajax.Utilities;

namespace DoubleJ.Oms.Web.Extensions
{
    public static class CaseSizeExtensions
    {
        public static CaseSize ToCaseSize(this TareWeightViewModel tareWeightViewModel)
        {
            var caseSize = new CaseSize()
            {
                Name = tareWeightViewModel.Name,
                Id = tareWeightViewModel.Id,
                CustomerTypeId = (tareWeightViewModel.CustomerType.Id == 0)? (OmsCustomerType?) null: tareWeightViewModel.CustomerType.Id,
                CaseTypeId = tareWeightViewModel.CaseType.Id,
                CreateDateTime = DateTime.Today,
                IsActive = true,
                TareWeight = tareWeightViewModel.TareWeight_
            };
            return caseSize;
        }

        public static AnimalLabel ToAnimalLabel(this AnimalLabelsViewModel animalLabelViewModel)
        {
            var animalLabel = new AnimalLabel()
            {
                Name = animalLabelViewModel.Name,
                Id = animalLabelViewModel.Id,
                IsOrganic = animalLabelViewModel.IsOrganic,
                SpeciesId = animalLabelViewModel.Species.Id
            };
            return animalLabel;
        }
    }
}