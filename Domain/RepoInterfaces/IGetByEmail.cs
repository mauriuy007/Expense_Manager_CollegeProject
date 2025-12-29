namespace LibreriaLogicaNegocio.RepoInterfaces
{
    public interface IGetByEmail<T>
    {
        T GetByEmail(string email);
    }   
}
