namespace ResearchLink.Core.Services.Impl
{
    [Service]
    internal class PaymentService : ServiceBase<Payment>, IPaymentService
    {
        public PaymentService(DatabaseContext context) : base(context)
        {
        }
    }
}
