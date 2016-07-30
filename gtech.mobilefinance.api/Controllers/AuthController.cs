using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using gtech.mobilefinance.dal;
using gtech.mobilefinance.bll;
using gtech.mobilefinance.bll.Util;

namespace gtech.mobilefinance.api.Controllers
{
    [RoutePrefix("api/Auth")]
    public class AuthController : BaseController<BaseHandler<User>, User>
    {
        private AuthHandler _authHandler = new AuthHandler();

        [Authorize]
        [HttpGet]
        public override async Task<IHttpActionResult> Get()
        {
            var user = await _authHandler.GetActualUser();
            // var user = HttpContext.Current.GetOwinContext().Get<ApplicationUse>().
            var retData = new ReturnData(CodeStatus.Ok, "User extracted");
            retData.Data = user;
            return Ok(retData);
        }

        [Authorize]
        [HttpPost]
        public override async Task<IHttpActionResult> Post(User user)
        {
            HttpResponseMessage response = null;
            ReturnData retData = new ReturnData(CodeStatus.InvalidData, "Not happening bruh");
            retData.Data = null;
            response = Request.CreateResponse((HttpStatusCode)200, retData);
            return new ResponseMessageResult(response);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(User user)
        {
            HttpResponseMessage response = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Invalid Data");
                }
                User result = await _authHandler.Create(user);
                ReturnData retData = new ReturnData(CodeStatus.Ok, "Usuario creado exitosamente");
                retData.Data = result;
                response = Request.CreateResponse((HttpStatusCode)200, retData);
            }
            catch (Exception e)
            {
                response = Request.CreateResponse((HttpStatusCode)510, new ReturnData(CodeStatus.InvalidData, e.Message));
            }
            return new ResponseMessageResult(response);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _authHandler.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
