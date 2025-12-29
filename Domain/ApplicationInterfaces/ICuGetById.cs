namespace LibreriaLogicaNegocio.ApplicationInterfaces
{
    public interface ICuGetById<T>
    {
        T Execute(int id);
    }
}
