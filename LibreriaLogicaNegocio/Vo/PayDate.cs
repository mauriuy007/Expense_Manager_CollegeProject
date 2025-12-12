namespace LibreriaLogicaNegocio.Vo
{
    public record PayDate
    {
        public DateTime Value { get; set; }
        public PayDate(DateTime value)
        {
            Value = value;
        }
    }
}
