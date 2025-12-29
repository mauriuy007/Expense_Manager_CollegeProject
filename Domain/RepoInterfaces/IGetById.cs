namespace LibreriaLogicaNegocio.RepoInterfaces
{
    public interface IGetById<T>
    {
        T GetById(int id);
    }
}
