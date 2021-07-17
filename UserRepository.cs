using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class UserRepository
    {
        /// <summary>
        /// Хранилище данных
        /// </summary>
        List<User> users = new List<User>
        {
            new User { Name = "Alex", Id = 0 },
            new User { Name = "Ann", Id = 2 },
            new User { Name = "Kate", Id = 1 },
        };

        /// <summary>
        /// Добавление пользователя в хранилище
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(User user)
        {
            users.Add(new User { Id = user.Id, Name = user.Name});
        }

        /// <summary>
        /// Получение пользователя по UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetUser(int userId)
        {
            foreach (User u in users)
            {
                if (u.Id == userId) return u.Name; 
            }
            return null;
        }

        /// <summary>
        /// Получение отсортированного по UserId списка пользователей
        /// </summary>
        /// <returns></returns>
        public void GetOrderedUsers()
        {
            var sortedUsers = users.OrderBy(u => u.Id);

            foreach (User u in sortedUsers)
            {
                Console.WriteLine($"{u.Id, 2} - {u.Name}");
            }
        }

        /// <summary>
        /// Асинхронная версия метода AddUser()
        /// </summary>
        /// <param name="user"></param>
        public async void AddUserAsync(User user)
        {
            await Task.Run(() => AddUser(user));
        }

        /// <summary>
        /// Асинхронная версия метода GetUser()
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<string> GetUserAsync(int userId)
        {
            return await Task.Run(() => GetUser(userId));
        }
        
        /// <summary>
        /// Асинхронная версия метода GetOrderedUsers()
        /// </summary>
        /// <returns></returns>
        public async Task GetOrderedUsersAsync()
        {
            await Task.Run(() => GetOrderedUsers());
        }
    }
}
