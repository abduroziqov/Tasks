using Main.Objects;

namespace Main.Actions
{
    public interface IUserMethods
    {
        public abstract User GetUser(ref List<User> users);
    }
}
