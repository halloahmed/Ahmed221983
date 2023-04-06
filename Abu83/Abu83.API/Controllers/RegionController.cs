using Abu83.API.Models.Domain;
using Abu83.API.Models.DTO;
using Abu83.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

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
        public async Task<IActionResult> GetALlReginAsync()
        {
            var regions = await regionRepository.GetAllAsync();
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
            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id )
        {
            var region = await regionRepository.GetAsync(id);
            if (region==null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegion(Models.DTO.AddRegionReguest addRegionReguest)
        {
            // Requst DTO to Domain 
            var region = new Models.Domain.Region()
            {
                Code = addRegionReguest.Code,   
                Name = addRegionReguest.Name,   
                Area= addRegionReguest.Area,
                Long= addRegionReguest.Long,
                Lat = addRegionReguest.Lat,
                Population =addRegionReguest.Population
            };
            // Pass detials to Repositry 
            region  = await regionRepository.AddRegionAsync(region);

            // Convert back to DTO

            var regionDTO = new Models.DTO.Region
            {
                Id         = region.Id,
                Code       = region.Code,
                Name       = region.Name,
                Area       = region.Area,
                Long       = region.Long,
                Lat        = region.Lat,
                Population = region.Population
            };
            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDTO.Id }, regionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            // Get region from Database 
            var region = await regionRepository.deleteAnync(id);
            // if null not found
            if (region== null)
            {
                return NotFound();
            }
            // Convert resopnce back to DTO 
            var regionDTO = new Models.DTO.Region
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                Area = region.Area,
                Long = region.Long,
                Lat = region.Lat,
                Population = region.Population
            };
            // return ok response
            return Ok(regionDTO);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateReguest updateReguest)
        {
            // 1
            var region = new Models.Domain.Region()
            {
                Code       = updateReguest.Code,
                Name       = updateReguest.Name,
                Area       = updateReguest.Area,
                Long       = updateReguest.Long,
                Lat        = updateReguest.Lat,
                Population = updateReguest.Population
            };
            // 2 call UpdateAnynce
            region = await regionRepository.UpdateAsync(id, region);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = new Models.DTO.Region
            {
                Id         = region.Id,
                Code       = region.Code,
                Name       = region.Name,
                Area       = region.Area,
                Long       = region.Long,
                Lat        = region.Lat,
                Population = region.Population
            };
            

            return Ok(regionDTO);   

        }
    }
}
