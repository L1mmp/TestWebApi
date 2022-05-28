using TestWebApi.Models;

namespace TestWebApi.Repositories
{
	public class UserRepository : IUserRepository
	{
		/// <summary>
		/// Добавляет пользователя.
		/// </summary>
		/// <param name="user"> Пользователь. </param>
		/// <returns> true, при успешнном добавлении пользователя. </returns>
		public bool AddUser(User user)
		{
			users.Add(user);
			return true;
		}

		/// <summary>
		/// Удаляет пользователя по Id.
		/// </summary>
		/// <param name="id"> Id пользователя. </param>
		/// <returns> true, при успешнном удалении пользователя. </returns>
		public bool RemoveUserById(Guid id)
		{
			var user = users.FirstOrDefault(x => x.Id == id);

			if (user == null)
			{
				return false;
			}

			users.Remove(user);
			return true;
		}

		/// <summary>
		/// Получает всех пользователей.
		/// </summary>
		/// <returns> Пользователи. </returns>
		public IEnumerable<User> GetAllUsers()
		{
			return users;
		}

		/// <summary>
		/// Получает пользователя по Id.
		/// </summary>
		/// <param name="id"> Id. </param>
		/// <returns> Пользователя. </returns>
		public User GetUserById(Guid id)
		{
			return users.FirstOrDefault(x => x.Id == id);
		}

		/// <summary>
		/// Обновляет пользователя.
		/// </summary>
		/// <param name="user"> Пользователь. </param>
		/// <returns> true, при успешнном изменении пользователя. </returns>
		public bool UpdateUser(User user)
		{
			var userToUpdate = users.FirstOrDefault(x => x.Id == user.Id);

			if (userToUpdate == null)
			{
				return false;
			}

			userToUpdate.Name = user.Name;
			userToUpdate.Age = user.Age;

			return true;
		}


		public static List<User> users = new List<User>();
	}
}
