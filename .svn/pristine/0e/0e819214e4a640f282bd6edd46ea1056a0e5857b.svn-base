using System.Collections.Generic;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class QualityGradeRepository : GenericRepository<QualityGrade>, IQualityGradeRepository
    {
        public QualityGradeRepository(IOmsContext context) : base(context)
        {
        }

        public override IEnumerable<QualityGrade> GetAll()
        {
            return FindAndSort(qualityGrade => qualityGrade.SortOrder);
        }
    }
}
