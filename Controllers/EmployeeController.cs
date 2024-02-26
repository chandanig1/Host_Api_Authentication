using Hostapiauthentication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hostapiauthentication.Controllers
{
    public class EmployeeController : ApiController
    {
        ApplicationDbContext dbcontext= new ApplicationDbContext();
        [Authorize(Roles =("User"))]
        public HttpResponseMessage GetEmployeeById(int id)
        {
            var user = dbcontext.Employees.FirstOrDefault(e => e.Id == id);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
        [Authorize(Roles = ("Admin, SuperAdmin"))]
        [Route("api/Employee/GetSomeEmployee")]
        public HttpResponseMessage GetSomeEmployee()
        {
            var user = dbcontext.Employees.Where(e => e.Id <= 2);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
        [Authorize(Roles = ("SuperAdmin"))]
        [Route("api/Employee/GetEmployee")]
        public HttpResponseMessage GetEmployee()
        {
            var user = dbcontext.Employees.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
    }
}
