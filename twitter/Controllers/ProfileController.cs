using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using twitter.Data;
using twitter.Models;
using twitter.Services;

namespace twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IRepoProfile _repoProfile;

        public ProfileController(IRepoProfile repoProfile)
        {
            _repoProfile = repoProfile;
        }
        [EnableCors("MyAllowSpecificOrigins")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var prf = await _repoProfile.GetAllAsync();
                return Ok(prf);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var prf = await _repoProfile.GetByIdAsync(id);
                if (prf == null) return NotFound();
                return Ok(prf);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProfileMD profileMD)
        {
            try
            {
                var prf = await _repoProfile.CreateAsync(profileMD);
                return Ok(prf);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var prf = await _repoProfile.DeleteAsync(id);
                if (prf == false) return NotFound();
                return Ok("DeleteSuccess");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
