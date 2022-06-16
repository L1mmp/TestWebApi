using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;
using TestWebApi.Repositories;

namespace TestWebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : Controller
	{
		private readonly IUserRepository _userRepository;

		public UserController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		/// <summary>
		/// Получает пользователя по Id.
		/// </summary>
		/// <param name="id"> Id. </param>
		/// <returns> Пользователя. </returns>
		[Route("Get/{id:Guid}"), HttpGet]
		public ActionResult<User> GetUserById(Guid id)
		{
			var _user = _userRepository.GetUserById(id);
			if (_user == default(User))
			{
				return NotFound("user not found!");
			}
			return Ok(_user);
		}

		/// <summary>
		/// Получает всех пользователей.
		/// </summary>
		/// <returns> Пользователи. </returns>
		[Route("GetAllUsers"), HttpGet]
		public ActionResult<IEnumerable<User>> GetAllUsers()
		{
			if (_userRepository.GetAllUsers().Count() == 0)
			{
				return BadRequest("Users aren`t exist");
			}
			return Ok(_userRepository.GetAllUsers());
		}

		/// <summary>
		/// Добавляет пользователя.
		/// </summary>
		/// <param name="user"> Пользователь. </param>
		/// <returns> true, при успешнном добавлении пользователя. </returns>
		[Route("Add"), HttpPost]
		public ActionResult<bool> AddUser([FromBody] User user)
		{
			var _user = _userRepository.AddUser(user);
			if (_user)
			{
				return Ok(_user);
			}
			return BadRequest("Can`t add user");
		}

		/// <summary>
		/// Удаляет пользователя по Id.
		/// </summary>
		/// <param name="id"> Id пользователя. </param>
		/// <returns> true, при успешнном удалении пользователя. </returns>
		[Route("Delete/{id:Guid}"), HttpDelete]
		public ActionResult<bool> RemoveUserById(Guid id)
		{
			if (_userRepository.RemoveUserById(id))
			{
				return Ok("User sucessfully removed!");
			}
			return BadRequest("User can`t be removed!");
		}

		/// <summary>
		/// Обновляет пользователя.
		/// </summary>
		/// <param name="user"> Пользователь. </param>
		/// <returns> true, при успешнном изменении пользователя. </returns>
		[Route("Update"), HttpPut]
		public ActionResult<bool> UpdateUser([FromBody] User user)
		{
			if (_userRepository.UpdateUser(user))
			{
				return Ok("User sucessfully updated!");
			}
			return BadRequest("User update failed!");

		}
	}
}
