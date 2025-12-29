namespace LibreriaLogicaNegocio.ApplicationInterfaces
{
    public interface ICULogin<T>
    {
        (bool, string) Execute(T dto);
    }
}
