using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Model.Interfaces
{
    public interface ILabelRepository : IGenericRepository<Label>
    {
        Label GetLabelByOrderDetailId(int ordDetailId);
    }
}