using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Responses.GetList
{
    public class GetListBrandResponse : IResponse
    {
        public int Id { get; set; }
        public string BrandName { get; set; }

    }
}
