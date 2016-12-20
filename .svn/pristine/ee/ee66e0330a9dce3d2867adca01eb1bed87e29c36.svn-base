using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class AnimalOrderDetailRepository : GenericRepository<AnimalOrderDetail>, IAnimalOrderDetailRepository
    {
        public AnimalOrderDetailRepository(IOmsContext context) : base(context)
        {
        }

        public List<AnimalOrderDetail> GetByColdWeghtDetailId(int coldWeightDetailId)
        {
            return Context.AnimalOrderDetail.Where(x => x.ColdWeightDetailId == coldWeightDetailId).ToList();
        }

        public AnimalOrderDetail GetByOrderDetailId(int ordDetailId)
        {
            return Context.AnimalOrderDetail.First(x => x.OrderDetailId == ordDetailId);
        }
    }
}