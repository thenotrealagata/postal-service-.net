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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateUser([FromBody] UserRequestDto userRequestDto)
        {
            var user = _mapper.Map<User>(userRequestDto);
            await _userService.AddUserAsync(user, userRequestDto.Password);

            var result = _mapper.Map<User>(user);

            return CreatedAtAction(nameof(CreateUser), result);
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(UserResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Login([FromBody] UserRequestDto loginRequestDto)
        {
            var (authToken, refreshToken, userId) = await _userService.LoginAsync(loginRequestDto.Email, loginRequestDto.Password);

            var loginResponseDto = new LoginResponseDto
            {
                UserId = userId,
                AuthToken = authToken,
                RefreshToken = refreshToken,
            };

            return Ok(loginResponseDto);
        }

        [HttpPost]
        [Route("refresh")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(UserResponseDto))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> RedeemRefreshToken([FromBody] string refreshToken)
        {
            var (authToken, newRefreshToken, userId) = await _userService.RedeemRefreshTokenAsync(refreshToken);

            var loginResponseDto = new LoginResponseDto
            {
                UserId = userId,
                AuthToken = authToken,
                RefreshToken = newRefreshToken,
            };

            return Ok(loginResponseDto);
        }
    }
}
