﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class OperationClaim:Entity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserOperationClaim> UserOperationClaims { get;}
    }
}
