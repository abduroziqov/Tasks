using Main.Objects;
using Main.Actions;

namespace Main
{
    public class Program
    {
        static void Main()
        {
            IUserMethods userMethods = new UserMethods();

            List<User> users = new()
            {
                new User()
                {
                    FirstName = "quvonchbek",
                    LastName = "abduroziqov"
                },
                new User()
                {
                    FirstName = "ali",
                    LastName = "vali"
                }
            };

            while (true)
            {
                Console.Clear();
                
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.FirstName}-{user.LastName}");
                    Console.WriteLine("==============================");
                }

                users.Add(userMethods.GetUser(ref users));
            }
        }
    }
}