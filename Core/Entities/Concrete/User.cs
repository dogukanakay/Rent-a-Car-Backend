using Core.Entities.Abstract;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class User : Entity<int>
    {
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool status { get; set; }

        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
