using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using twitter.Models;
using twitter.Services;

namespace twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IRepoVideo _repo;

        public VideoController(IRepoVideo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var videos = await _repo.GetAllAsync();
                return Ok(videos);
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
                var video = await _repo.GetByIdAsync(id);
                if (video == null) return NotFound();
                return Ok(video);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(VideoMD videoMD)
        {
            try
            {
                var video = await _repo.CreateAsync(videoMD);
                return Ok(video);
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
                var video = await _repo.DeleteAsync(id);
                if (video == false) return NotFound();
                return Ok(video);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
