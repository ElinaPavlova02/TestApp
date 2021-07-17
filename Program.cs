using System;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        /// <summary>
        /// Функция для битового реверса массива байтов
        /// </summary>
        /// <param name="array"></param>
        public static void Reverse(byte[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int tmp = array[i];

                tmp = ((tmp & 0x55) << 1) | ((tmp >> 1) & 0x55); // Поменять местами соседние биты
                tmp = ((tmp & 0x33) << 2) | ((tmp >> 2) & 0x33); // Поменять местами соседние пары бит
                tmp = ((tmp & 0x0F) << 4) | ((tmp >> 4) & 0x0F); // Поменять местами первые и последние 4 бита

                Console.WriteLine(tmp);
                
                array[i] = (byte)tmp;
            }
        }

        static async Task Main(string[] args)
        {
            // Проверка работы класса UserRepository

            UserRepository repository = new UserRepository();

            var u = await repository.GetUserAsync(1);

            Console.WriteLine(u);

            User user = new User { Id = 10, Name = "Michael"};

            repository.AddUserAsync(user);

            Console.WriteLine();

            await repository.GetOrderedUsersAsync();

            Console.WriteLine();

            // Проверка работы функции Reverse

            byte[] array = { 0, 10, 50, 100, 255 };

            Reverse(array);
        }
    }
}
