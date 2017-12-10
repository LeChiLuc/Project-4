using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;

namespace TeduShop.Web.Controllers
{
    public class test
    {
        public test(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int id { get; set; }
        public string name { get; set; }
    }


    [RoutePrefix("api/test")]
    public class testController : ApiControllerBase
    {

        public testController(IErrorService errorService) : base(errorService)
        {

        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage getAll(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;
            Func<HttpResponseMessage> func = () =>
            {
                var lst = new List<test>() {
                    new test(1,"abc"),
                    new test(2,"abc"),
                    new test(3,"abc"),
                    new test(4,"abc"),
                    new test(5,"abc")
                };
                response = request.CreateResponse(HttpStatusCode.OK, lst);
                return response;
            };
            return CreateHttpResponse(request, func);
        }
    }
}