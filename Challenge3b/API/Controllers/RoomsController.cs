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
    public class RoomsController : ControllerBase
    {
        // GET: api/Rooms
        [HttpGet]
        public IEnumerable<Room> Get()
        {
            SqlConnection connection = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");

            string query = "SELECT * FROM Room;";

            SqlCommand select = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader result = select.ExecuteReader();

            List<Room> rooms = new List<Room>();

            while (result.Read()) {
                rooms.Add(new Room(result[0].ToString(), int.Parse(result[1].ToString()), int.Parse(result[2].ToString())));
            }

            connection.Close();

            return rooms;
        }

        // GET: api/Rooms/Used
        [HttpGet("Used")]
        public List<RoomClass> GetUsed()
        {
            SqlConnection connection = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");

            string query = "SELECT DISTINCT R.Building, R.RoomNo, C.ClassCode, C.Name " +
                            "FROM Room R " +
                            "INNER JOIN Class C " +
                            "ON R.RoomNo = C.RoomNo; ";

            SqlCommand select = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader result = select.ExecuteReader();

            List<RoomClass> usedrooms = new List<RoomClass>();

            while (result.Read()) {
                usedrooms.Add(new RoomClass(result[0].ToString(), int.Parse(result[1].ToString()), new ClassinRoom(result[2].ToString(), result[3].ToString())));
            }

            connection.Close();

            return usedrooms;
        }

        // GET: api/Rooms/Unused
        [HttpGet("Unused")]
        public List<Room> GetUnused() {
            SqlConnection connection = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");

            string query = "SELECT * FROM ROOM " +
                            "WHERE CONCAT(BUILDING, ROOMNO) NOT IN(SELECT DISTINCT(CONCAT(BUILDING, ROOMNO)) FROM CLASS)";

            SqlCommand select = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader result = select.ExecuteReader();

            List<Room> unusedrooms = new List<Room>();

            while (result.Read()) {
                unusedrooms.Add(new Room(result[0].ToString(), int.Parse(result[1].ToString()), int.Parse(result[2].ToString())));
            }

            connection.Close();

            return unusedrooms;
        }

        [HttpGet("Computers")]
        public List<Room> WithComputers() {
            SqlConnection connection = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");

            string query =  "SELECT DISTINCT R.Building, R.RoomNo, R.Capacity " +
                            "FROM Room R " +
                            "INNER JOIN Computer C " +
                            "ON R.RoomNo = C.RoomNo;";

            SqlCommand select = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader result = select.ExecuteReader();

            List<Room> computerrooms = new List<Room>();

            while (result.Read()) {
                computerrooms.Add(new Room(result[0].ToString(), int.Parse(result[1].ToString()), int.Parse(result[2].ToString())));
            }

            return computerrooms;
        }

        // POST: api/Rooms
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Rooms/5
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
