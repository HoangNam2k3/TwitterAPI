using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using twitter.Models;
using twitter.Services;

namespace twitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IRepoImage _repo;

        public ImageController(IRepoImage repoImage) {
            _repo = repoImage;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            try
            {
                var imgs = await _repo.GetAllAsync();
                return Ok(imgs);
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
                var img = await _repo.GetByIdAsync(id);
                if (img == null) return NotFound();
                return Ok(img);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(ImageMD imageMD)
        {
            try
            {
                var img = await _repo.CreateAsync(imageMD);
                return Ok(img);
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
                var img = await _repo.DeleteAsync(id);
                if (img == false) return NotFound();
                return Ok("Delete Success!");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
