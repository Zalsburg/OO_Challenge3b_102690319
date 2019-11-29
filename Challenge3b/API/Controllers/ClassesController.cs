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
    public class ClassesController : ControllerBase {
        // GET: api/Classes
        [HttpGet]
        public IEnumerable<Class> Get() {
            SqlConnection connection = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");

            string query = "SELECT * FROM Class;";

            SqlCommand select = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader result = select.ExecuteReader();

            List<Class> classes = new List<Class>();

            while (result.Read()) {
                classes.Add(new Class(result[0].ToString(), result[1].ToString(), result[2].ToString(), int.Parse(result[3].ToString())));
            }

            connection.Close();

            return classes;
        }

        // GET: api/Classes/5
        //[HttpGet("{ClassCode}")]
        [HttpGet("{id}", Name = "ClassCode")]
        //public Class GetClassCode(string id)
        public Class GetClassCode(string id) {
            SqlConnection connection = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");

            string query = "SELECT * " +
                            "FROM Class " +
                            "WHERE ClassCode = '" + id + "'";

            SqlCommand selectclass = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader result = selectclass.ExecuteReader();

            Class classcode = new Class();

            //string output = id;

            while (result.Read()) {
                classcode = new Class(result[0].ToString(), result[1].ToString(), result[2].ToString(), int.Parse(result[3].ToString()));
            }

            //result.Read();
            //Class classcode = new Class(result[0].ToString(), result[1].ToString(), result[2].ToString(), int.Parse(result[3].ToString()));

                
            

            connection.Close();

            return classcode;
            


        }

        // POST: api/Classes
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Classes/5
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
