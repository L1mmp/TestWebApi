using TestWebApi.Models;

namespace TestWebApi.Repositories
{
	public interface IUserRepository
	{
		/// <summary>
		/// Добавляет пользователя.
		/// </summary>
		/// <param name="user"> Пользователь. </param>
		/// <returns> true, при успешнном добавлении пользователя. </returns>
		public bool AddUser(User user);

		/// <summary>
		/// Получает пользователя по Id.
		/// </summary>
		/// <param name="id"> Id. </param>
		/// <returns> Пользователя. </returns>
		public User GetUserById(Guid id);

		/// <summary>
		/// Получает всех пользователей.
		/// </summary>
		/// <returns> Пользователи. </returns>
		public IEnumerable<User> GetAllUsers();

		/// <summary>
		/// Обновляет пользователя.
		/// </summary>
		/// <param name="user"> Пользователь. </param>
		/// <returns> true, при успешнном изменении пользователя. </returns>
		public bool UpdateUser(User user);

		/// <summary>
		/// Удаляет пользователя по Id.
		/// </summary>
		/// <param name="id"> Id пользователя. </param>
		/// <returns> true, при успешнном удалении пользователя. </returns>
		public bool RemoveUserById(Guid id);

	}
}