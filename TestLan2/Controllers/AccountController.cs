using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestLan2.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage ValidLogin(string userName, string userPassword)
        {
            if (userName == "tri" && userPassword == "tri")
            {
                return Request.CreateResponse(HttpStatusCode.OK, TokenManager.GenerateToken(userName));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadGateway, "User name and password invalid");
            }
        }
        [HttpGet]
        [CustomAuthenticationFilter]
        public IHttpActionResult ValidateToken()
        {
            string ret = "Ok";
            return Ok(ret);
        }
    }
}
