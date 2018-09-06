using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class LogicWrapper
    {
        public DataSet GetAllEmployeeData(string startDate, string endDate, string filterName, string filterTime)
        {
            var dbObj = DBWrapper.GetInstance();
            DataSet ds = new DataSet();
            ds = dbObj.GetAllEmployeeData(startDate, endDate, filterName, filterTime);
            return ds;
        }

        public async Task<DataSet> GetAllEmployeeDataAsync(string startDate, string endDate)
        {
            var dbObj = DBWrapper.GetInstance();
            DataSet ds = new DataSet();
            ds = await dbObj.GetAllEmployeeDataAsync(startDate, endDate);
            return ds;
        }
    }
}
