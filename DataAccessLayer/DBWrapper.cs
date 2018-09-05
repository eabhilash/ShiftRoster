using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web;

namespace DataAccessLayer
{
    public class DBWrapper
    {
        private readonly static DBWrapper _instance = new DBWrapper();

        private DBWrapper()
        { }

        public static DBWrapper GetInstance()
        {
            return _instance;
        }

        public DataSet GetAllEmployeeData(string startDate, string endDate)
        {
            string connectionString = Properties.Settings.Default.ShiftRosterDB;
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("exec [ShiftRoster].dbo.[uspGetEmployeeShift] '"+ startDate + "','"+ endDate + "'", con);
                //cmd.Parameters.AddWithValue("@startDate", startDate);
                //cmd.Parameters.AddWithValue("@endDate", endDate);
                DataSet ds = ExecuteDataSet(cmd);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public async Task<DataSet> GetAllEmployeeDataAsync(string startDate, string endDate)
        {
            string connectionString = Properties.Settings.Default.ShiftRosterDB;
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("exec [ShiftRoster].dbo.[uspGetEmployeeShift] '" + startDate + "','" + endDate + "'", con);
                //cmd.Parameters.AddWithValue("@startDate", startDate);
                //cmd.Parameters.AddWithValue("@endDate", endDate);
                DataSet ds = ExecuteDataSet(cmd);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }

        private static DataSet ExecuteDataSet(SqlCommand cmd)
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
