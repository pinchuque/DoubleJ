using System.Linq;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class CaseSizeRepository : GenericRepository<CaseSize>, ICaseSizeRepository
    {
        public CaseSizeRepository(IOmsContext context) : base(context)
        {
        }

        public new CaseSize Add(CaseSize entity)
        {
            var savedEntity = Context.Set<CaseSize>().Add(entity);
            Save();
            return savedEntity;
        }

        public void Remove(int id)
        {
            var itemToRemove = Context.CaseSize.FirstOrDefault(x => x.Id == id);
            if (itemToRemove != null)
            {
                this.Remove(itemToRemove);
            }
            Save();
        }
    }
}