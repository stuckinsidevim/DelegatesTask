
namespace DelegatesTask
{
    public class UserChangedEventArgs : EventArgs
    {
        public User User { get; }
        public string Operation { get; }

        public UserChangedEventArgs(User user, string operation)
        {
            User = user;
            Operation = operation;
        }
    }
    public class UserRepository
    {
        private readonly List<User> _users = new();
        public event EventHandler<UserChangedEventArgs> OnUserChanged;

        public User GetUserById(int id)
        {
            return _users.Find(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            _users.Add(user);
            OnUserChanged?.Invoke(this, new UserChangedEventArgs(user, "Added"));
        }

        public void UpdateUser(User updatedUser)
        {
            var user = _users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (user != null)
            {
                user.Name = !string.IsNullOrEmpty(updatedUser.Name) ? updatedUser.Name : user.Name;
                user.Email = !string.IsNullOrEmpty(updatedUser.Email) ? updatedUser.Email : user.Email;
                user.Contact = !string.IsNullOrEmpty(updatedUser.Contact) ? updatedUser.Contact : user.Contact;

                OnUserChanged?.Invoke(this, new UserChangedEventArgs(user, "Updated"));
            }
        }

        public void RemoveUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
                OnUserChanged?.Invoke(this, new UserChangedEventArgs(user, "Removed"));
            }
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _users.AsReadOnly();
        }

    }
}
