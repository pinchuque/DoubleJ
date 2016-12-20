using System.Collections.Generic;

namespace DoubleJ.Oms.Model.Entities
{
    public class User : EntityBase
    {
        public User()
        {
            IsActive = true;
            Customer = new List<Customer>();
        }

        public int TypeId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public int? CustomerId { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        
        public virtual UserType UserType { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
    }
}