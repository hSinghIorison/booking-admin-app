using System;
using System.Collections.Generic;

namespace BookingAdminUi.Models
{
    public partial class AppointmentBookingIncentiveCampaign
    {
        public AppointmentBookingIncentiveCampaign()
        {
            AppointmentBookingWhitelistedIncentiveAccounts = new HashSet<AppointmentBookingWhitelistedIncentiveAccounts>();
        }

        public string CampaignCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte ElecAmount { get; set; }
        public byte GasAmount { get; set; }
        public bool AllCustomers { get; set; }
        public string BillingSystem { get; set; }

        public virtual ICollection<AppointmentBookingWhitelistedIncentiveAccounts> AppointmentBookingWhitelistedIncentiveAccounts { get; set; }
    }
}
