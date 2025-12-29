namespace LibreriaLogicaNegocio.RepoInterfaces
{
    public interface IGetAllRepo<T>
    {
        IEnumerable<T> GetAll();
    }
}
