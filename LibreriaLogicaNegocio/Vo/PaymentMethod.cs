using LibreriaLogicaNegocio.Exceptions;

namespace LibreriaLogicaNegocio.Vo
{
    public record PaymentMethod
    {
        public string Value { get; set; }
        public PaymentMethod(string value)
        {
            Value = value;
           
        }
    }
}
