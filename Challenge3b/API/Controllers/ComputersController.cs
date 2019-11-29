using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using System.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputersController : ControllerBase
    {
        // GET: api/Computers
        [HttpGet]
        public IEnumerable<Computer> Get()
        {
            SqlConnection connection = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");

            string query = "SELECT * FROM Computer;";

            SqlCommand select = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader result = select.ExecuteReader();

            List<Computer> computers = new List<Computer>();

            while (result.Read()) {
                computers.Add(new Computer(int.Parse(result[0].ToString()), int.Parse(result[1].ToString()), result[2].ToString(), int.Parse(result[3].ToString())));
            }

            connection.Close();

            return computers;
        }

        // GET: api/Computers/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Computers
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Computers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
