using System;
using System.Collections.Generic;

namespace BookingAdminUi.Models
{
    public partial class AppointmentBookingNonMonetaryIncentiveCampaign
    {
        public AppointmentBookingNonMonetaryIncentiveCampaign()
        {
            AppointmentBookingWhitelistedIncentiveAccounts = new HashSet<AppointmentBookingWhitelistedIncentiveAccounts>();
        }

        public string CampaignCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Item { get; set; }
        public string SendAddress { get; set; }
        public bool AllCustomers { get; set; }
        public string BillingSystem { get; set; }

        public virtual ICollection<AppointmentBookingWhitelistedIncentiveAccounts> AppointmentBookingWhitelistedIncentiveAccounts { get; set; }
    }
}
