using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Requests.Create
{
    public class CreateBrand : IRequest
    {
        public string BrandName { get; set; }

    }
}
