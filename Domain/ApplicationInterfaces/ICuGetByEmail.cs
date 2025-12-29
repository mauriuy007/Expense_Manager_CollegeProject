namespace LibreriaLogicaNegocio.ApplicationInterfaces
{
    public interface ICuGetByEmail<T, K>
    {
        T Execute(K key);
    }
}
