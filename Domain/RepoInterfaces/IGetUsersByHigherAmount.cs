namespace LibreriaLogicaNegocio.RepoInterfaces
{
    public interface IGetUsersByHigherAmount<T>
    {
        IEnumerable<T> GetUsersByHigherAmount(double amount);    
    }
}
