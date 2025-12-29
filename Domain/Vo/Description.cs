using LibreriaLogicaNegocio.Exceptions;

namespace LibreriaLogicaNegocio.Vo
{
    public record Description
    {
        public string Value { get; set; }

        public Description(string value)
        {
            Value = value;

            if (string.IsNullOrWhiteSpace(Value))
            {
                throw new NullDescriptionException();
            }
        }
    }
}
