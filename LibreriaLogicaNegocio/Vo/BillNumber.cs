namespace LibreriaLogicaNegocio.Vo
{
    public record BillNumber
    {
        public string Value { get; set; }

        public BillNumber(string value)
        {
            Value = value;
        }
    }
}
