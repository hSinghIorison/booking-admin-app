using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookingAdminUi.Models
{
    public class SmbRepository
    {
        private readonly SmbDbContext _db;

        public SmbRepository(SmbDbContext db)
        {
            _db = db;
        }

        public IEnumerable<AppointmentBookingIncentiveCampaign> GetAllCampaigns()
        {
            try
            {
                return _db.AppointmentBookingIncentiveCampaign.ToList();
            }
            catch
            {
                throw;
            }
        }

        public int AddCampaign(AppointmentBookingIncentiveCampaign campaign)
        {
            try
            {
                _db.AppointmentBookingIncentiveCampaign.Add(campaign);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public int UpdateCampaign(AppointmentBookingIncentiveCampaign campaign)
        {
            try
            {
                _db.Entry(campaign).State = EntityState.Modified;
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public AppointmentBookingIncentiveCampaign GetCampaignData(int id)
        {
            try
            {
                AppointmentBookingIncentiveCampaign campaign = _db.AppointmentBookingIncentiveCampaign.Find(id);
                return campaign;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular employee    
        public int DeleteCampaign(int id)
        {
            try
            {
                AppointmentBookingIncentiveCampaign campaign = _db.AppointmentBookingIncentiveCampaign.Find(id);
                _db.AppointmentBookingIncentiveCampaign.Remove(campaign);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        // //To Get the list of Cities    
        // public List<TblCities> GetCities()
        // {
        //     List<TblCities> lstCity = new List<TblCities>();
        //     lstCity = (from CityList in db.TblCities select CityList).ToList();
        //
        //     return lstCity;
        // }

    }
}