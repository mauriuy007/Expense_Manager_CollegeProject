using LibreriaLogicaNegocio.Entities;

namespace LibreriaLogicaNegocio.RepoInterfaces
{
    public interface IPaymentRepo : 
        IAddRepo<Payment>, 
        IGetAllRepo<Payment>, 
        IGetByYearMonth<Payment>,
        IGetById<Payment>,
        IGetPaymentsByUserId<Payment>,
        IAddPaymentRepo<Payment>;



}
