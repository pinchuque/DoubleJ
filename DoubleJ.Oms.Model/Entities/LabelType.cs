using System.Collections.Generic;
using DoubleJ.Oms.Model.Definitions;

namespace DoubleJ.Oms.Model.Entities
{
    public class LabelType : IEntity
    {
        public LabelType()
        {
            Label = new List<Label>();
        }

        public OmsLabelType Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Label> Label { get; set; }

        public int GetId()
        {
            return (int) Id;
        }
    }
}