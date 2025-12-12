using LibreriaLogicaNegocio.Exceptions;

namespace LibreriaLogicaNegocio.Vo
{
    public record Email
    {
        public string Value { get; set; }

        public Email(string value)
        {
            Value = value;

            if (string.IsNullOrWhiteSpace(Value))
            {
                throw new NullEmailException();
            }
        }   
    }
}
