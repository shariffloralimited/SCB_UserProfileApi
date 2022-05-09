using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserProfileApi.Classes;

namespace UserProfileApi.Controllers
{
    [Authorize]
    public class UlaController : ApiController
    {
        [Route("testConnection")]
        [HttpGet]
        public HttpResponseMessage TestConnection()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { IsConnected = true });
        }

        [Route("account")]
        [HttpPost]
        public HttpResponseMessage GetAccounts(string accountID = null, int? currentPage = null, int? pageSize = null)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Data = $"accountID:{accountID}, currentPage:{currentPage}, pageSize:{pageSize}", Message = "Successful" });
        }

        [Route("group")]
        [Route("role")]
        [Route("site")]
        [HttpPost]
        public HttpResponseMessage GetEntitlements(string entitlementOrGroupID = null, int? currentPage = null, int? pageSize = null)
        {
            EntitlementType entitlementType;
            Enum.TryParse(Request.GetRouteData().Route.RouteTemplate, true, out entitlementType);

            switch (entitlementType)
            {
                case EntitlementType.Group:
                    // logic goes here for group entitlement type
                    break;
                case EntitlementType.Role:
                    // logic goes here for role entitlement type
                    break;
                case EntitlementType.Site:
                    // logic goes here for site entitlement type
                    break;
            }

            return Request.CreateResponse(HttpStatusCode.OK, new { Data = $"entitlementType:{entitlementType},entitlementOrGroupID:{entitlementOrGroupID}, currentPage:{currentPage}, pageSize:{pageSize}", Message = "Successful" });
        }
    }
}
