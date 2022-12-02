using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TicketingWebAPI.Models;

namespace TicketingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketingController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TicketingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                                select * from ticketphase1
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TicketAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(TicketPhase1 ticket)
        {
            string query = @"
                                insert into ticketphase1 (Summary,Description,Status,CreatedDate) values (@Summary,@Description,@Status,@CreatedDate)
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TicketAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Summary", ticket.Summary);
                    myCommand.Parameters.AddWithValue("@Description", ticket.Description);
                    myCommand.Parameters.AddWithValue("@Status", 1);
                    myCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    myReader = myCommand.ExecuteReader();
                   
                    table.Load(myReader);
                    myCon.Close();
                }
            }
            return new JsonResult("Data Added");
        }
    }
}
