using System;
using System.Collections.Generic;

namespace BookingAdminUi.Models
{
    public partial class AppointmentBookingReportedForIncentive
    {
        public int BillingAccountId { get; set; }
        public DateTime Created { get; set; }
        public string BillingSystem { get; set; }
    }
}
