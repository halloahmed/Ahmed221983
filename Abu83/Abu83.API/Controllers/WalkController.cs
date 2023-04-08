using Abu83.API.Models.DTO;
using Abu83.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Abu83.API.Controllers
{
    [ApiController]
    [Route("Walk")]
    public class WalkController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalkController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetALlWalkAsync()
        {
            var walk = await walkRepository.GetAllAsync();
            /*var regionsDTO = new List<Models.DTO.Region>(); // as Region 
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
            var walkDTO = mapper.Map<List<Models.DTO.Walk>>(walk);
            return Ok(walkDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkAsync")]
        public async Task<IActionResult> GetSingelWalk(Guid id)
        {
            // Get Walk Domain Objeckt
            var walkDomain = await walkRepository.GetAsync(id);
            // Convert walk To DTO 
            var walkDTO = mapper.Map<Models.DTO.Walk>(walkDomain);
            // Return Responce 
            return Ok(walkDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalk([FromBody] Models.DTO.AddWalkRequst addWalkRequst)
        {
            // Convert DTO to Domain 
            var walkdomain = new Models.Domain.Walk
            {
                Name = addWalkRequst.Name,
                Length = addWalkRequst.Length,
                RegionId = addWalkRequst.RegionId,
                WalkDifficultyId = addWalkRequst.WalkDifficultyId
            };


            // Passt Doomain Object to Responsity to persist this
            walkdomain = await walkRepository.AddAsync(walkdomain);
            // Domain To DTO 
            var walkDTO = new Models.DTO.Walk
            {
                Id = walkdomain.Id,
                Name = walkdomain.Name,
                Length = walkdomain.Length,
                RegionId = walkdomain.RegionId,
                WalkDifficultyId = walkdomain.WalkDifficultyId
            };
            // back to Client 
            return CreatedAtAction(nameof(GetSingelWalk), new { id = walkDTO.Id }, walkDTO);

        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute]Guid id, [FromBody] Models.DTO.UpdateWalkReguest updateWalkReguest)
        {
            // Convert DTO to Domain object 
            var walkDomain = new Models.Domain.Walk
            {
                Name = updateWalkReguest.Name,
                Length = updateWalkReguest.Length,
                RegionId= updateWalkReguest.RegionId,
                WalkDifficultyId= updateWalkReguest.WalkDifficultyId

            };
            // pass detial tp Resposirty -Get Domain object in responce or null
            walkDomain = await walkRepository.UpdateAsync(id, walkDomain);
            // Check Null
            if (walkDomain== null)
            {
                return NotFound();
            }
            
            // convert back domain to DTO 
            var walkDTO = new Models.DTO.Walk 
            {
                Name = walkDomain.Name,
                Length = walkDomain.Length,
                RegionId = walkDomain.RegionId,
                WalkDifficultyId = walkDomain.WalkDifficultyId
            };
            // Return Responce
            return Ok(walkDTO);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalk(Guid id)
        {
            var deletewalkDomain = await walkRepository.DeleteAsync(id);
            if (deletewalkDomain == null)
            {
                return NotFound();
            }
            var waltDTO = mapper.Map<Walk>(deletewalkDomain);
            return Ok(waltDTO);
        }

    }
}
