namespace LibreriaLogicaNegocio.ApplicationInterfaces
{
    public interface ICuGetPaymentByYearMonth<T>
    {
        IEnumerable<T> Execute(int? year, int? month);
    }
}
