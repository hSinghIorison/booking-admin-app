using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingAdminUi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingAdminUi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly SmbRepository _smbRepository;

        public CampaignController(SmbDbContext dbContext)
        {
          _smbRepository = new SmbRepository(dbContext);

        }

        [HttpGet]
        [Route("api/Index")]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<AppointmentBookingIncentiveCampaign> campaigns = await Task.Run(() => _smbRepository.GetAllCampaigns());
                return Ok(campaigns);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("api/Create")]
        public async Task<IActionResult> Create(AppointmentBookingIncentiveCampaign campaign)
        {
            try
            {
                await Task.Run(() => _smbRepository.AddCampaign(campaign));
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("api/Campaign/Details/{id}")]
        public AppointmentBookingIncentiveCampaign Details(int id)
        {
            return _smbRepository.GetCampaignData(id);
        }

        [HttpPut]
        [Route("api/Edit")]
        public async Task<IActionResult> Edit(AppointmentBookingIncentiveCampaign campaign)
        {
            try
            {
                await Task.Run(()=> _smbRepository.UpdateCampaign(campaign));
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("api/Campaign/Delete/{id}")]
        public int Delete(int id)
        {
            return _smbRepository.DeleteCampaign(id);
        }

        // [HttpGet]
        // [Route("api/Campaign/GetCityList")]
        // public IEnumerable<TblCities> Details()
        // {
        //     return smbRepository.GetCities();
        // }
    }
}