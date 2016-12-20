using System;
using System.Collections.Generic;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Models;
using DoubleJ.Oms.Model.ViewModels.Internal;

namespace DoubleJ.Oms.Service.Interfaces
{
    public interface ILabelCreateService
    {
        void ProduceLabel(int orderDetailId, ScaleWeight weight, OmsLabelType labelType, DateTime? processDate);
        void ProduceLabel(int orderDetailId, double poundWeight, OmsLabelType labelType, int quantity, DateTime? processDate, QualityGrade qualityGrade, AnimalLabelsViewModel animalLabel, CaseSize customCaseSize = null);
        void ProduceCustomBagLabels(List<OrderDetail> orderDetails, double poundWeight, OmsLabelType labelType, DateTime? processDate, QualityGrade qualityGrade, AnimalLabelsViewModel animalLabel, CaseSize customCaseSize = null);
    }
}