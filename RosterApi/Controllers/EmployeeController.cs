using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer;
using System.Threading.Tasks;

namespace RosterApi.Controllers
{
    public class EmployeeController : ApiController
    {
        public DataSet GetAllEmployeeData(string startDate, string endDate)
        {
            LogicWrapper obj = new LogicWrapper();
            return obj.GetAllEmployeeData(startDate, endDate);
        }

        public async Task<DataSet> GetAllEmployeeDataAsync(string startDate, string endDate)
        {
            LogicWrapper obj = new LogicWrapper();
            return await obj.GetAllEmployeeDataAsync(startDate, endDate);
        }
    }
}
