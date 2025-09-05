using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PostalService.DTO;
using PostalService.Model;
using PostalService.Services;

namespace PostalService.Controllers
{
    public class LocationController : ControllerBase
    {
        private IMapper _mapper;
        private ILocationService _locationService;
        private IParcelService _parcelService;

        public LocationController(IMapper mapper, ILocationService locationService, IParcelService parcelService)
        {
            _mapper = mapper;
            _locationService = locationService;
            _parcelService = parcelService;
        }

        [Route("/locations")]
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(List<LocationResponseDto>))]
        public async Task<IActionResult> GetLocations([FromQuery] LocationType locationType)
        {
            var locations = await _locationService.GetLocations(locationType);
            var locationsResponse = locations.Select(l => _mapper.Map<LocationResponseDto>(l)).ToList();

            return Ok(locationsResponse);
        }


        // TODO auth only user who was creator of package/admin
        [Route("/locations/{locationId}/post/{parcelId}")]
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PostParcel([FromRoute] int locationId, [FromRoute] int parcelId)
        {
            await _locationService.PostParcelAsync(locationId, parcelId);
            return NoContent();
        }
    }
}
