namespace LibreriaLogicaNegocio.Vo
{
    public record DateFrom
    {
        public DateTime Value { get; set; }

        public DateFrom (DateTime value)
        {
            Value = value;

        }
    }
}
