using LibreriaLogicaNegocio.Exceptions;

namespace LibreriaLogicaNegocio.Vo
{
    public record Amount
    {
        public double Value { get; set; }

        public Amount(double value)
        {
            Value = value;


            if (Value < 0)
            {
                throw new NegativeAmountException();
            }
        }
    }
    
}
