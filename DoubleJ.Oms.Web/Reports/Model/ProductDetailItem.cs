﻿using System;

namespace DoubleJ.Oms.Web.Reports.Model
{
    public class ProductDetailItem
    {
        private decimal _weightKg;
        private decimal _weightLbs;
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public decimal WeightKg
        {
            get { return _weightKg; }
            set { _weightKg = Math.Round(value, 2); }
        }

        public decimal WeightLbs
        {
            get { return _weightLbs; }
            set { _weightLbs = Math.Round(value, 2); ; }
        }

        public string Date { get; set; }
        public string SpeciesName { get; set; }
    }
}