using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class PaymentCardManager : IPaymentCardService
    {
        IPaymentCardDal _paymentCardDal;
        public PaymentCardManager(IPaymentCardDal paymentCardDal)
        {
            _paymentCardDal = paymentCardDal;
        }
        public IResult Add(PaymentCard paymentCard)
        {
            _paymentCardDal.Add(paymentCard);
            return new SuccessResult(Messages.PaymentCardAdded);
        }

        public IResult Delete(PaymentCard paymentCard)
        {
            _paymentCardDal.Delete(paymentCard);
            return new SuccessResult(Messages.PaymentCardDeleted);
        }

        public IDataResult<List<PaymentCard>> GetAll()
        {
            return new SuccessDataResult<List<PaymentCard>>(_paymentCardDal.GetAll(), Messages.PaymentCardListed);
        }

        public IDataResult<List<PaymentCard>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<PaymentCard>>(_paymentCardDal.GetAll(p=>p.CustomerId==customerId), Messages.PaymentCardListed);
        }

        public IDataResult<PaymentCard> GetById(int paymentCardId)
        {
            return new SuccessDataResult<PaymentCard>(_paymentCardDal.Get(p=>p.CardId == paymentCardId), Messages.PaymentCardListed);
        }

        public IResult Update(PaymentCard paymentCard)
        {
            _paymentCardDal.Update(paymentCard);
            return new SuccessResult(Messages.PaymentCardUpdated);
        }
    }
}
