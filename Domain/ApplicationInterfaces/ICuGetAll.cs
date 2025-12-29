namespace LibreriaLogicaNegocio.ApplicationInterfaces
{
    public interface ICuGetAll<T>
    {
        IEnumerable<T> Execute();
    }
}
