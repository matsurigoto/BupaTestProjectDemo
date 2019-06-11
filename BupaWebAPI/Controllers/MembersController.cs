using System.Threading.Tasks;
using BupaWebAPI.Clients;
using BupaWebAPI.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BupaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {

        protected readonly ILogger Logger;
        protected readonly IMemberApiClient _membetApiClient;
        public MembersController(ILogger<MembersController> logger, IMemberApiClient memberApiClient)
        {
            Logger = logger;
            _membetApiClient = memberApiClient;
        }

        // POST api/members
        [HttpPost]
        public async Task<CreateMemberResponse> CreateMember([FromBody]CreateMemberRequest request)
        {
            return await _membetApiClient.CreateMemberAsync(request);
        }
    }
}