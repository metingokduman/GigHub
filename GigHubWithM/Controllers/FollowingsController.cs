using GigHubWithM.Dtos;
using GigHubWithM.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHubWithM.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            var exist = _context.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == dto.FolloweeId);

            if (exist)
                return BadRequest("Following already exist.");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            _context.Followings.Add(following);

            _context.SaveChanges();

            return Ok();

        }
    }
}
