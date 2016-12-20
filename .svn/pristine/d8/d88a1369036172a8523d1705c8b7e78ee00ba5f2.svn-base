using System.Linq;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class LabelRepository : GenericRepository<Label>, ILabelRepository
    {
        public LabelRepository(IOmsContext context) : base(context)
        {
        }

        public Label GetLabelByOrderDetailId(int ordDetailId)
        {
            return Context.Label.First(x => x.OrderDetailId == ordDetailId);
        }
        
    }
}
