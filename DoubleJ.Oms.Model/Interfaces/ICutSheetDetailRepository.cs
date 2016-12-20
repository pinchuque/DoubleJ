using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Model.Interfaces
{
    public interface ICutSheetDetailRepository : IGenericRepository<CutSheetDetail>
    {
        CutSheetDetail GetCutSheetDetail(int coldWeightDetailId, int customerLocationId);
    }
}
