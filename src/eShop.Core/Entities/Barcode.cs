namespace eShop.Core.Entities
{
    public class Barcode
    {
        private const int DefaultLength = 15;

        public string Value { get; set; }

        private Barcode(string value)
        {
            this.Value = value;
        }

        public static Barcode? Create(string? value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            if (value.Length != DefaultLength)
            {
                return null;
            }
            return new Barcode(value);
        }
    }
}
