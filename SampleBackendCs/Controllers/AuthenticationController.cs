using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleBackendCs.Models;
using SampleBackendCs.Services;
using Virgil.SDK.Web.Authorization;

namespace SampleBackendCs.Controllers
{
    [Route("auth/")]
    public class AuthenticationController : Controller
    {
        [HttpGet]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AuthResponse> Login([FromBody]AuthRequest authRequest)
        {
            string authToken = AuthenticationService.Login(authRequest.Identity);
            if (authToken == null) return NotFound();
            return new ActionResult<AuthResponse>(new AuthResponse(authToken));
        }

        [HttpGet]
        [Route("GetVirgilToken")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<VirgilTokenResponse> GetVirgilToken([FromHeader(Name = "Authorization-Token")]string authToken)
        {
            string identity = AuthenticationService.GetIdentity(authToken);
            if (identity == null) return Unauthorized();
            Jwt token = AuthenticationService.GenerateVirgilToken(identity);
            return new ActionResult<VirgilTokenResponse>(new VirgilTokenResponse(token.ToString()));
        }
    }
}
