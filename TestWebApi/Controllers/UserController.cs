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
		public ActionResult<User> GetUserById(Guid id) => Ok(_userRepository.GetUserById(id));

		/// <summary>
		/// Получает всех пользователей.
		/// </summary>
		/// <returns> Пользователи. </returns>
		[Route("GetAllUsers"), HttpGet]
		public ActionResult<IEnumerable<User>> GetAllUsers() => Ok(_userRepository.GetAllUsers());

		/// <summary>
		/// Добавляет пользователя.
		/// </summary>
		/// <param name="user"> Пользователь. </param>
		/// <returns> true, при успешнном добавлении пользователя. </returns>
		[Route("Add"), HttpPost]
		public ActionResult<bool> AddUser([FromBody] User user) => Ok(_userRepository.AddUser(user));

		/// <summary>
		/// Удаляет пользователя по Id.
		/// </summary>
		/// <param name="id"> Id пользователя. </param>
		/// <returns> true, при успешнном удалении пользователя. </returns>
		[Route("Delete/{id:Guid}"), HttpDelete]
		public ActionResult<bool> RemoveUserById(Guid id) => Ok(_userRepository.RemoveUserById(id));

		/// <summary>
		/// Обновляет пользователя.
		/// </summary>
		/// <param name="user"> Пользователь. </param>
		/// <returns> true, при успешнном изменении пользователя. </returns>
		[Route("Update"), HttpPost]
		public ActionResult<bool> UpdateUser([FromBody] User user) => Ok(_userRepository.UpdateUser(user));

	}
}
