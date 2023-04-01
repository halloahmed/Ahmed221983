using Abu83.API.Models.Domain;
using Abu83.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Abu83.API.Controllers
{
    [ApiController]
    [Route("Region")]
    public class RegionController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet] 
        public IActionResult GetALlRegin()
        {
            var regions = regionRepository.GetAll();
            /*var regionsDTO = new List<Models.DTO.Region>();
            regions.ToList().ForEach(region =>
            {
                var regionDTO = new Models.DTO.Region()    
                {
                    Id = region.Id,
                    Code = region.Code,
                    Area = region.Area,
                    Lat = region.Lat, 
                    Name = region.Name,
                    Population = region.Population,
                    Long = region.Long,
                };
                regionsDTO.Add(regionDTO);  

            });*/
            return Ok(regionsDTO);
        }
     
    }
}
