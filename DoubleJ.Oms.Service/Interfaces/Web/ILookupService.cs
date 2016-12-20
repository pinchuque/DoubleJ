﻿using System.Collections.Generic;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Service.Interfaces.Web
{
    public interface ILookupService
    {
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Customer> GetCustomers(string name);
        IEnumerable<LogoType> GetLogoTypes();
        IEnumerable<Status> GetStatuses();
        IEnumerable<PrimalCut> GetPrimalCuts();
        IEnumerable<QualityGrade> GetQualityGrades();
        IEnumerable<Region> GetRegions();
        IEnumerable<Species> GetSpecies();
        //IEnumerable<SubPrimalCut> GetSubPrimalCuts();
        IEnumerable<TrimCut> GetTrimCuts();
        IEnumerable<Refrigeration> GetRefrigerations();
    }
}