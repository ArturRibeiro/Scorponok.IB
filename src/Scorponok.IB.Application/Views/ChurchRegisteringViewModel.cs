using System.ComponentModel;

namespace Scorponok.IB.Application.Views
{
    public class ChurchRegisteringViewModel
    {
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Photo")]
        public string Photo { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("MobileTelephone")]
        public string MobileTelephone { get; set; }

        [DisplayName("TelephoneFixed")]
        public string TelephoneFixed { get; set; }
    }
}