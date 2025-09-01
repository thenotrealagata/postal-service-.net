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

        [Route("/parcels")]
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(List<ParcelResponseDto>))]
        public async Task<IActionResult> GetParcels()
        {
            var parcels = await _parcelService.GetParcelsAsync();
            var parcelsResponse = parcels.Select(p => _mapper.Map<ParcelResponseDto>(p)).ToList();

            return Ok(parcelsResponse);
        }


        [Route("/parcels/{id}")]
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ParcelResponseDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
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
