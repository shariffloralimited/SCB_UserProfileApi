using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserProfileApi.Models;

namespace UserProfileApi.Controllers
{
    [Authorize]
    public class UraController : ApiController
    {
        [Route("createAccount")]
        [HttpPost]
        public HttpResponseMessage CreateAccount(AccountInfoCreate accountInfo)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                RequestNumber = accountInfo.RequestNumber,
                Status = "Success",
                StatusMessage = "Business friendly status message which would be recorded in SRM"
            });
        }

        [Route("deleteAccount")]
        [HttpPost]
        public HttpResponseMessage DeleteAccount(string accountID)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                RequestNumber = accountID,
                AccountName = "<Bank Id or unique identifier of the account >",
                Operation = "delete"
            });
        }

        [Route("addEntitlement")]
        [HttpPost]
        public HttpResponseMessage AddEntitlement(EntitlementInfo entitlementInfo)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                AccountOwner = entitlementInfo.AccountOwner,
                AccountName = entitlementInfo.AccountName,
                Status = "Success/Failure/Warning/Retry",
                StatusMessage = "Business friendly status message which would be recorded in SRM"
            });
        }

        [Route("removeEntitlement")]
        [HttpPost]
        public HttpResponseMessage RemoveEntitlement(EntitlementInfo entitlementInfo)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                AccountOwner = entitlementInfo.AccountOwner,
                AccountName = entitlementInfo.AccountName,
                Status = "Success/Failure/Warning/Retry",
                StatusMessage = "Business friendly status message which would be recorded in SRM"
            });
        }

        [Route("updateAccount")]
        [HttpPost]
        public HttpResponseMessage UpdateAccount(AccountInfoUpdate accountInfoUpdate)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                AccountOwner = accountInfoUpdate.AccountOwner,
                AccountName = accountInfoUpdate.AccountName,
                Status = "Success/Failure/Warning/Retry",
                StatusMessage = "Business friendly status message which would be recorded in SRM"
            });
        }

        [Route("enableAccount")]
        [HttpPost]
        public HttpResponseMessage EnableAccount(string accountName)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                AccountOwner = "<11 digits bankID>",
                AccountName = accountName,
                Status = "Success/Failure/Warning/Retry",
                StatusMessage = "Business friendly status message which would be recorded in SRM",
            });
        }

        [Route("disableAccount")]
        [HttpPost]
        public HttpResponseMessage DisableAccount(string accountName)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                AccountOwner = "<11 digits bankID>",
                AccountName = accountName,
                Status = "Success/Failure/Warning/Retry",
                StatusMessage = "Business friendly status message which would be recorded in SRM",
            });
        }
    }
}
