using System.Net.WebSockets;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PostalService.DTO;
using PostalService.Model;
using PostalService.Services;

namespace PostalService.Controllers
{
    public class ParcelController : ControllerBase
    {
        private IParcelService _parcelService;
        private IMapper _mapper;

        public ParcelController(IParcelService parcelService, IMapper mapper)
        {
            _parcelService = parcelService;
            _mapper = mapper;
        }

        [Route("/parcels/{id}")]
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ParcelResponseDto))]
        public async Task<IActionResult> GetParcelById([FromRoute] int id)
        {
            var parcel = await _parcelService.GetByIdAsync(id);
            var parcelResponse = _mapper.Map<ParcelResponseDto>(parcel);

            return Ok(parcel);
        }

        [Route("/parcels")]
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created, type: typeof(ParcelResponseDto))]
        public async Task<IActionResult> CreateParcel([FromBody] ParcelRequestDto parcelRequestDto)
        {
            var parcel = _mapper.Map<Parcel>(parcelRequestDto);
            await _parcelService.CreateParcel(parcel);

            var parcelResponse = _mapper.Map<ParcelResponseDto>(parcel);

            return CreatedAtAction(nameof(CreateParcel), new { id = parcel.Id }, parcelResponse);
        }
    }
}
