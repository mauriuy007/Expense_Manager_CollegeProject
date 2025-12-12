namespace LibreriaLogicaNegocio.Vo
{
    public record DateTill
    {
        public DateTime Value { get; set; }

        public DateTill(DateTime value)
        {
            Value = value;
        }
    }
}
