using Microsoft.AspNetCore.Mvc;
using _29Jul2026_Ass.Models;

namespace _29Jul2026_Ass.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        // In-memory data store (seeded data, since only GET and PUT are allowed)
        private static List<Vehicle> vehicles = new List<Vehicle>()
        {
            new Vehicle { Id = 1, VehicleNumber = "MH26AB1234", Brand = "Maruti Suzuki", Model = "Swift", Year = 2021, Type = "Car", IsAvailable = true },
            new Vehicle { Id = 2, VehicleNumber = "MH26CD5678", Brand = "Hero", Model = "Splendor", Year = 2022, Type = "Bike", IsAvailable = true },
            new Vehicle { Id = 3, VehicleNumber = "MH26EF9012", Brand = "Tata", Model = "Ace", Year = 2020, Type = "Truck", IsAvailable = false },
            new Vehicle { Id = 4, VehicleNumber = "MH26GH3456", Brand = "Honda", Model = "City", Year = 2023, Type = "Car", IsAvailable = true }
        };

        // GET: api/Vehicle
        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> GetAllVehicles()
        {
            return Ok(vehicles);
        }

        // GET: api/Vehicle/{id}
        [HttpGet("{id}")]
        public ActionResult<Vehicle> GetVehicleById(int id)
        {
            var vehicle = vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicle == null)
            {
                return NotFound(new { message = $"Vehicle with id {id} not found." });
            }
            return Ok(vehicle);
        }

        // PUT: api/Vehicle/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(int id, [FromBody] Vehicle updatedVehicle)
        {
            var vehicle = vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicle == null)
            {
                return NotFound(new { message = $"Vehicle with id {id} not found." });
            }

            vehicle.VehicleNumber = updatedVehicle.VehicleNumber;
            vehicle.Brand = updatedVehicle.Brand;
            vehicle.Model = updatedVehicle.Model;
            vehicle.Year = updatedVehicle.Year;
            vehicle.Type = updatedVehicle.Type;
            vehicle.IsAvailable = updatedVehicle.IsAvailable;

            return Ok(vehicle);
        }
    }
}
