using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PostalService.DTO;
using PostalService.Model;
using PostalService.Services;

namespace PostalService.Controllers
{
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Route("/users")]
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created, type: typeof(UserResponseDto))]
        public async Task<IActionResult> CreateUser([FromBody] UserRequestDto userRequestDto)
        {
            var user = _mapper.Map<User>(userRequestDto);
            await _userService.AddUserAsync(user, userRequestDto.Password);

            var result = _mapper.Map<User>(user);

            return CreatedAtAction(nameof(CreateUser), result);
        }
    }
}
