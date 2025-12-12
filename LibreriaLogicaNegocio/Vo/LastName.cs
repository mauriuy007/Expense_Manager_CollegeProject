using LibreriaLogicaNegocio.Exceptions;

namespace LibreriaLogicaNegocio.Vo
{
    public record LastName
    {
        public string Value { get; set; }
        public LastName(string value)
        {
            Value = value;
            if (string.IsNullOrWhiteSpace(Value))
            {
                throw new NullNameException();
            }
        }
    }
}
