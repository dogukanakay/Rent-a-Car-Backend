using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Responses.Create
{
    public class CreateBrandResponse : IResponse
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
    }
}
