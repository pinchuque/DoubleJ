using System.Linq;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class AnimalLabelRepository : GenericRepository<AnimalLabel>, IAnimalLabelRepository
    {
        public new AnimalLabel Add(AnimalLabel entity)
        {
            var savedEntity = Context.Set<AnimalLabel>().Add(entity);
            Save();
            return savedEntity;
        }

        public void Remove(int id)
        {
            var itemToRemove = Context.AnimalLabel.FirstOrDefault(x => x.Id == id);
            if (itemToRemove != null)
            {
                this.Remove(itemToRemove);
            }
            Save();
        }
        public AnimalLabelRepository(IOmsContext context) : base(context)
        {
        }
    }
}