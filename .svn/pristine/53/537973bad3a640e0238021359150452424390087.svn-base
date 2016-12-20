using System.Linq;
using System.Runtime.CompilerServices;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class CutSheetDetailRepository : GenericRepository<CutSheetDetail>, ICutSheetDetailRepository
    {
        public CutSheetDetailRepository(IOmsContext context)
            : base(context)
        {

        }

        public CutSheetDetail GetCutSheetDetail(int coldWeightDetailId, int customerLocationId)
        {
            return
                Context.CutSheetDetail.FirstOrDefault(x => x.ColdWeightDeatailId == coldWeightDetailId);
        }
    }
}
