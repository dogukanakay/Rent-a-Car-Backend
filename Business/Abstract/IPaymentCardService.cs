using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPaymentCardService
    {
        IResult Add(PaymentCard paymentCard);
        IResult Delete(PaymentCard paymentCard);
        IResult Update(PaymentCard paymentCard);

        IDataResult<List<PaymentCard>> GetAll();
        IDataResult<PaymentCard> GetById(int paymentCardId);
    }

}
