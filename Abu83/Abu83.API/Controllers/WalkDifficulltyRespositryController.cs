using Abu83.API.Data;
using Abu83.API.Models.Domain;
using Abu83.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Abu83.API.Controllers
{
    [ApiController]
    [Route("WalkDifficullty")]

    public class WalkDifficulltyRespositryController : Controller
    {
        private readonly IWalkDifficulltyRespositry walkDifficulltyRespositry;
        private readonly IMapper mapper;

        public WalkDifficulltyRespositryController(IWalkDifficulltyRespositry walkDifficulltyRespositry, IMapper mapper)
        {
            this.walkDifficulltyRespositry = walkDifficulltyRespositry;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWalkDifficullty()
        {
            var walkDifficulltyDomain = await walkDifficulltyRespositry.GetAllAsync();
            var walkDifficulltyDTO= mapper.Map<List<Models.DTO.WalkDifficulty>>(walkDifficulltyDomain);
            return Ok(walkDifficulltyDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetWalkDifficulty")]
        public async Task<IActionResult> GetWalkDifficulty (Guid id)
        {
            var WalkDifficultydomain = await walkDifficulltyRespositry.GetSingleWalkDiffAsync(id);
            if (WalkDifficultydomain == null)
            {
                return null;
            }
            var WalkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(WalkDifficultydomain);
            return Ok(WalkDifficultyDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkDifficaulty (Models.DTO.WalkDifficullityRequest walkDifficullityRequest)
        {

            // Convert DTO to Domian 
            var walkDifficulityDomain = new Models.Domain.WalkDifficulty
            {
                Code = walkDifficullityRequest.Code
            };
            // Pass detials to Repositry
            walkDifficulityDomain = await walkDifficulltyRespositry.AddWalkDiffAsync(walkDifficulityDomain);
            // check null or not 
            
            // Domain TO DTO
            var WalkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty> (walkDifficulityDomain);
            // return 

            return CreatedAtAction(nameof(GetWalkDifficulty), new { id = WalkDifficultyDTO.Id }, WalkDifficultyDTO);


        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateWalkDifficultyAsync(Guid id , Models.DTO.UpDateWalkDifficultyRequst upDateWalkDifficultyRequst )
        {
            //  DTO To Domain  
            var walkDifficulty = new Models.Domain.WalkDifficulty
            {
                Code = upDateWalkDifficultyRequst.Code
            };

            // Respon
            walkDifficulty = await walkDifficulltyRespositry.UpdateWalkDiffAsync(id, walkDifficulty);
            // Cheak Null or Not 
            if (walkDifficulty == null)
            {
                return NotFound();
            }
            // Domain To DTO 
            var WalkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);

            // Return 
            return Ok   (WalkDifficultyDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkDifficullty(Guid id)
        {
            var deletewalkDomain = await walkDifficulltyRespositry.DeleteWalkDiffAsync(id);
            if (deletewalkDomain == null)
            {
                return NotFound();
            }
            var waltDTO = mapper.Map<Models.DTO.WalkDifficulty>(deletewalkDomain);
            return Ok(waltDTO);
        }
    }
}
