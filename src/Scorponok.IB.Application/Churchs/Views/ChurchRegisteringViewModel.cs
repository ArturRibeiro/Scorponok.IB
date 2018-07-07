using System;
using System.ComponentModel;

namespace Scorponok.IB.Application.Churchs.Views
{
    public class RegisterChurchViewModel
    {
        [DisplayName("Id")]
        public Guid? Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Photo")]
        public string Photo { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Region")]
        public byte Region { get; set; }

        [DisplayName("Prefix")]
        public byte Prefix { get; set; }

        [DisplayName("MobileTelephone")]
        public string MobileTelephone { get; set; }

        [DisplayName("TelephoneFixed")]
        public string TelephoneFixed { get; set; }
    }

    public class ChurchUpdatedViewModel
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

    public class ChurchDeletedViewModel
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