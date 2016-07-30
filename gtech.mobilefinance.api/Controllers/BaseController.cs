using gtech.mobilefinance.bll;
using gtech.mobilefinance.bll.Util;
using gtech.mobilefinance.dal;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace gtech.mobilefinance.api.Controllers
{
    public abstract class BaseController<T, M> : ApiController where T : BaseHandler<M>, new() where M : Model, new()
    {
        protected T _handler = new T();

        //Get List
        [Authorize]
        [HttpGet]
        public virtual async Task<IHttpActionResult> Get()
        {
            
            HttpResponseMessage response = null;
            try
            {
                var list = await _handler.Retrieve();
                ReturnData retData = new ReturnData(CodeStatus.Ok, "Data Successful");
                retData.Data = list;
                response = Request.CreateResponse((HttpStatusCode)200, retData);
            }
            catch (ErrorException e)
            {
                response = Request.CreateResponse((HttpStatusCode)510, new ReturnData((CodeStatus)e.Code, e.Message));
            }
            return new ResponseMessageResult(response);
        }

        [Authorize]
        //Get By Id
        [HttpGet]
        public virtual async Task<IHttpActionResult> Get(int id)
        {
            HttpResponseMessage response = null;
            return new ResponseMessageResult(response);
        }

        [Authorize]
        //Insert
        [HttpPost]
        public virtual async Task<IHttpActionResult> Post(M baseObject)
        {
            HttpResponseMessage response = null;
            try
            {
                var auxObject = await _handler.Create(baseObject);
                ReturnData retData = new ReturnData(CodeStatus.Ok, "Data Created Successfully");
                retData.Data = auxObject;
                response = Request.CreateResponse((HttpStatusCode)200, retData);
            }
            catch (ErrorException e)
            {
                response = Request.CreateResponse((HttpStatusCode)510, new ReturnData((CodeStatus)e.Code, e.Message));
            }
            return new ResponseMessageResult(response);
        }

        [Authorize]
        [HttpPut]
        //Update
        public virtual async Task<IHttpActionResult> Put(int id, M baseObject)
        {
            HttpResponseMessage response = null;
            try
            {
                await _handler.Update(id, baseObject);
                ReturnData retData = new ReturnData(CodeStatus.Ok, "Data Updated Successfully");
                retData.Data = baseObject;
                response = Request.CreateResponse((HttpStatusCode)200, retData);
            }
            catch (ErrorException e)
            {
                response = Request.CreateResponse((HttpStatusCode)510, new ReturnData((CodeStatus)e.Code, e.Message));
            }
            return new ResponseMessageResult(response);
        }

        [Authorize]
        [HttpDelete]
        // Delete
        public virtual async Task<IHttpActionResult> Delete(int id)
        {
            HttpResponseMessage response = null;
            try
            {
                await _handler.Delete(id);
                ReturnData retData = new ReturnData(CodeStatus.Ok, "Data Deleted Successfully");
                retData.Data = id;
                response = Request.CreateResponse((HttpStatusCode)200, retData);
            }
            catch (ErrorException e)
            {
                response = Request.CreateResponse((HttpStatusCode)510, new ReturnData((CodeStatus)e.Code, e.Message));
            }
            return new ResponseMessageResult(response);
        }
    }
}