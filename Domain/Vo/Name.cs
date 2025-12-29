using LibreriaLogicaNegocio.Exceptions;

namespace LibreriaLogicaNegocio.Vo
{
    public record Name
    {
        public string Value { get; set; }

        public Name(string value)
        {
            Value = value;
            if (string.IsNullOrWhiteSpace(Value))
            {
                throw new NullNameException();
            }
        }

        
    }
}
