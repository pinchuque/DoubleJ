using System.Collections.Generic;
using DoubleJ.Oms.Model.Definitions;

namespace DoubleJ.Oms.Model.Entities
{
    public class CurrentLocationType : IEntity
    {
        public CurrentLocationType()
        {
            Label = new List<Label>();
        }

        public OmsCurrentLocation Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Label> Label { get; set; }

        public int GetId()
        {
            return (int) Id;
        }
    }
}