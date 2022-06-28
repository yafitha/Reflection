using PrimeProject.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PrimeProject.Controllers
{
    public class PrimeNumberController : ApiController
    {
        [System.Web.Http.HttpPost]
        [Route("api/PrimeNumber/IsPrime")]
        public HttpResponseMessage GetIsPrimeAsync(long number)
        {
            try
            {
                return Request.CreateResponse<bool>(HttpStatusCode.OK, NumberManipulationBL.IsPrime(number));
            }
            catch (ArgumentException e)
            {
                List<string> s = new List<string>();
                var x = 0 - 1;
                ModelState.AddModelError(nameof(number), e.Message);
                return Request.CreateResponse<bool>(HttpStatusCode.BadRequest, false);
            }
        }
    }
}
