namespace DelegatesTask
{
    public class UserService
    {
        private readonly UserRepository _userRepository = new();

        public UserService()
        {
            SMSService smsService = new();
            EmailService emailService = new();
            PushNotificationService pushNotificationService = new();

            _userRepository.OnUserChanged += (sender, e) =>
            {
                string message = $"{e.Operation} - {e.User.Id}: {e.User.Name}";
                smsService.Notify(message);
                emailService.Notify(message);
                pushNotificationService.Notify(message);
            };
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }

        public void RemoveUser(int id)
        {
            _userRepository.RemoveUser(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}
