namespace LibreriaLogicaNegocio.ApplicationInterfaces
{
    public interface ICuGetByHigherAmount<T>
    {
        IEnumerable<T> Execute(double amount);
    }
}
