namespace LibreriaLogicaNegocio.Vo
{
    public record Password
    {
        public string Value { get; set; }
        public Password(string value)
        {
            Value = value;
        }
    }
}
