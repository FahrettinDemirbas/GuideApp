using System.ComponentModel;

namespace Guide.Service
{
    public class Enums
    {
        public enum ContactTypes
        {
            [Description("Telefon Numarası")]
            TelefonNumarasi,
            [Description("E-Mail")]
            EMail,
            [Description("Adres")]
            Adres,
            [Description("Konum")]
            Konum
        }
    }
}
