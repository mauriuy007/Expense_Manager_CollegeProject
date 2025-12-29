namespace LibreriaLogicaNegocio.RepoInterfaces
{
    public interface IGetByYearMonth<T>
    {
        IEnumerable<T> GetPaymentByYearMonth(int year, int month);
    }
}
