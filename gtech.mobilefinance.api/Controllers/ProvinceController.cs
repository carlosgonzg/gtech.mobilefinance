using gtech.mobilefinance.dal;
using gtech.mobilefinance.bll;
using System.Web.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using gtech.mobilefinance.bll.Util;

namespace gtech.mobilefinance.api.Controllers
{
    [RoutePrefix("api/Province")]
    public class ProvinceController : BaseController<BaseHandler<Province>, Province>
    {
        [Authorize]
        [HttpGet]
        [Route("ByCountry")]
        public async Task<IHttpActionResult> ByCountry(int id)
        {
            var provinces = await (from bs in _handler._set
                                   where bs.CountryId == id
                                   select bs).ToListAsync();
            // var user = HttpContext.Current.GetOwinContext().Get<ApplicationUse>().
            var retData = new ReturnData(CodeStatus.Ok, "");
            retData.Data = provinces;
            return Ok(retData);
        }
    }
}
