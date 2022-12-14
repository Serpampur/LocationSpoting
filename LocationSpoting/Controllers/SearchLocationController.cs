using LocationSpoting.Models;
using LocationSpoting.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocationSpoting.Controllers
{
    [Route("api/[controller]")]
    public class SearchLocationController : Controller
    {
        private readonly ISearchLocationService _searchLocationService;
        public SearchLocationController(ISearchLocationService searchLocationService)
        {
            _searchLocationService = searchLocationService;
        }

        [HttpGet]
        [Route("search")]
        public IActionResult Search([FromBody] SearchRequest request)
        {
            if (request == null)
            {
                return BadRequest("The search data is not provided.");
            }

            if (request.ServiceName == null) 
            {
                return BadRequest("The service name is not provided.");
            }

            if (request.GeoLocation?.Latitude == null || request.GeoLocation?.Longtitude == null)
            {
                return BadRequest("GeoLocation is not provided.");
            }

            var searchLocationRequest = new SearchLocationRequest()
            {
                Name = request.ServiceName,
                Position = new Position
                {
                    Latitude = request.GeoLocation.Latitude,
                    Longitude = request.GeoLocation.Longtitude
                }
            };

            var res = _searchLocationService.Search(searchLocationRequest);
            return Ok(res);
        }
    }
}
