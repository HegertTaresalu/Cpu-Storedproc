using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StoredProc.Data;
using StoredProc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoredProc.Controllers
{
    public class CpuController : Controller
    {

        public StoredProcDbContext _context;
        public IConfiguration _config { get; }

        public CpuController
            (
            StoredProcDbContext context,
            IConfiguration config
            )
        {
            _context = context;
            _config = config;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CpuSearch()
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchCpu";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Cpu> model = new List<Cpu>();
                while (sdr.Read())
                {
                    var details = new Cpu();
                    details.Name = sdr["Name"].ToString();
                    details.Company = sdr["Company"].ToString();
                    details.BaseClock = (double?)Convert.ToDecimal(sdr["BaseClock"]);
                    details.MaxClockSpeed = (double?)Convert.ToDecimal(sdr["MaxClockSpeed"]);
                    details.CoreCount = Convert.ToInt32(sdr["CoreCount"]);
                    details.ThreadCount = Convert.ToInt32(sdr["ThreadCount"]);
                    model.Add(details);
                }
                return View(model);
            }
        }


        [HttpPost]
        public IActionResult CpuSearch(string Name, string Company, int BaseClock, decimal? MaxClockSpeed, int? CoreCount, int? ThreadCount)
        {
            string connectionStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchCpu";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (Name != null)
                {
                    SqlParameter param_fn = new SqlParameter("@Name", Name);
                    cmd.Parameters.Add(param_fn);
                }
                if (Company != null)
                {
                    SqlParameter param_ln = new SqlParameter("@Company", Company);
                    cmd.Parameters.Add(param_ln);
                }
                if (BaseClock != 0)
                {
                    SqlParameter param_g = new SqlParameter("@BaseClock", BaseClock);
                    cmd.Parameters.Add(param_g);
                }
                if (MaxClockSpeed != null)
                {
                    SqlParameter param_s = new SqlParameter("@MaxClockSpeed", MaxClockSpeed);
                    cmd.Parameters.Add(param_s);
                }
                if (CoreCount != null)
                {
                    SqlParameter param_s = new SqlParameter("@CoreCount", CoreCount);
                    cmd.Parameters.Add(param_s);
                         
                }
                if(ThreadCount != null)
                {
                    SqlParameter param_s = new SqlParameter("@ThreadCount", ThreadCount);
                    cmd.Parameters.Add(param_s);
                }

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Cpu> model = new List<Cpu>();
                while (sdr.Read())
                {
                    var details = new Cpu();
                    details.Name = sdr["Name"].ToString();
                    details.Company = sdr["Company"].ToString();
                    details.BaseClock = (double?)Convert.ToDecimal(sdr["BaseClock"]);
                    details.MaxClockSpeed = (double?)Convert.ToDecimal(sdr["MaxClockSpeed"]);
                    details.CoreCount = Convert.ToInt32(sdr["CoreCount"]);
                    details.ThreadCount = Convert.ToInt32(sdr["ThreadCount"]);
                    model.Add(details);
                }
                return View(model);
            }
        }

    }
}
