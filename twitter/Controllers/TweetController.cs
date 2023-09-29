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
    public class TweetController : ControllerBase
    {
        private readonly IRepoTweet _repoTweet;

        public TweetController(IRepoTweet repoTweet)
        {
            _repoTweet = repoTweet;
        }
        [EnableCors("MyAllowSpecificOrigins")]
        [HttpGet]
        public  async Task<IActionResult> GetAll()
        {
            try
            {
                var tweets = await _repoTweet.GetAllAsync();
                return Ok(tweets);
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
                var tweet = await _repoTweet.GetByIdAsync(id);
                if (tweet == null) return NotFound();
                return Ok(tweet);
            }
            catch { return BadRequest(); }
        }
        [HttpPost]
        public async Task<IActionResult> Create(TweetMD tweetMD)
        {
            try
            {
                var tweet = await _repoTweet.CreateAsync(tweetMD);
                return Ok(tweet);
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
                var tweet = await _repoTweet.DeleteAsync(id);
                if (tweet == false) return NotFound();
                return Ok(tweet);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
