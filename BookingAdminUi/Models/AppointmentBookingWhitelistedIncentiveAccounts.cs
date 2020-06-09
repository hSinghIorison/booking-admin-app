using System;
using System.Collections.Generic;

namespace BookingAdminUi.Models
{
    public partial class AppointmentBookingWhitelistedIncentiveAccounts
    {
        public int Id { get; set; }
        public int BillingAccountId { get; set; }
        public string JobType { get; set; }
        public string CampaignCode { get; set; }
        public string NonMonetaryCampaignCode { get; set; }
        public string BillingSystem { get; set; }

        public virtual AppointmentBookingIncentiveCampaign CampaignCodeNavigation { get; set; }
        public virtual AppointmentBookingNonMonetaryIncentiveCampaign NonMonetaryCampaignCodeNavigation { get; set; }
    }
}
