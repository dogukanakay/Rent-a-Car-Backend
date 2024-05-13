using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Responses.GetById
{
    public class GetByIdBrandReponse  : IResponse
    {
        public int Id { get; set; }
        public int BrandName { get; set; }
    }
}
