using Main.Objects;
using System.Text.RegularExpressions;

namespace Main.Actions
{
    public class UserMethods : IUserMethods
    {
        //public static User CreateAndValidate(ref List<User> generatedUser)
        //{
        //    User tempUser = new User();
        //    while(true)
        //    {
        //        tempUser.FirstName = Console.ReadLine().Trim().ToLower();
        //        tempUser.LastName = Console.ReadLine().Trim().ToLower();

        //        for (int i = 0; i < tempUser.FirstName.Length; i++)
        //        {
        //            if (char.IsNumber(tempUser.FirstName, i))
        //            {
        //                Console.WriteLine("First Name is not valid!");
        //                break;
        //            }
        //        }

        //        for (int i = 0; i < tempUser.LastName.Length; i++)
        //        {
        //            if (char.IsNumber(tempUser.LastName, i))
        //            {
        //                Console.WriteLine("Last Name is not valid!");
        //                break;
        //            }
        //        }

        //        foreach (var item in generatedUser)
        //        {
        //            if (item.FirstName == tempUser.FirstName && item.LastName == tempUser.LastName)
        //            {
        //                Console.WriteLine("This user is already available!");
        //                break;
        //            }
        //        }
        //    }
            
        //    return tempUser;
        //}

        public virtual User GetUser(ref List<User> users)
        {
            User user = new User();
            Random random = new Random();
            
            while (true)
            {
                //information receive
                Console.Write("First Name => ");
                string firstName = Console.ReadLine().ToLower().Trim();
                Console.Write("Last Name => ");
                string lastName = Console.ReadLine().ToLower().Trim();

                Regex regex = new Regex("^[a-zA-Z]+$", RegexOptions.IgnoreCase);

                //spell check
                if (regex.IsMatch(firstName) && regex.IsMatch(lastName))
                {
                    user = new() { FirstName = firstName, LastName = lastName };
                    break;
                }
                else
                {
                    Console.WriteLine("Entered information is not valid!");
                }
            }

            //check list
            foreach (var item in users)
            {
                if (item.FirstName == user.FirstName)
                {
                    user.FirstName += random.Next(100);
                }
                else if (item.LastName == user.LastName)
                {
                    user.LastName += random.Next(100);
                }
            }

            return user;
        }
    }
}
