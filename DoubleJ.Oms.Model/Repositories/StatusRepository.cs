using System.Collections.Generic;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class StatusRepository : GenericRepository<Status>, IStatusRepository
    {
        public StatusRepository(IOmsContext context) : base(context)
        {
        }

        public override IEnumerable<Status> GetAll()
        {
            return FindAndSort(status => status.SortOrder);
        }
    }
}
