namespace DelegatesTask
{
    public class Program
    {
        private static readonly UserService userService = new();


        private static readonly List<Student> students = new()
        {
        new Student { Id = 100, Name = "Ram", Age = 15, Score = 99 },
        new Student { Id = 121, Name = "Arjun", Age = 19, Score = 89.8 },
        new Student { Id = 101, Name = "Rahul", Age = 15, Score = 99.9 },
        new Student { Id = 102, Name = "Riya", Age = 16, Score = 78.5 }
    };

        public static void Main()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Update User");
                Console.WriteLine("3. Remove User");
                Console.WriteLine("4. List Users");
                Console.WriteLine("5. Sort and Display Students");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice (1-6): ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddUser();
                        break;
                    case "2":
                        UpdateUser();
                        break;
                    case "3":
                        RemoveUser();
                        break;
                    case "4":
                        ListUsers();
                        break;
                    case "5":
                        SortAndDisplayStudents();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        public static void AddUser()
        {
            var user = new User();
            Console.Write("Enter user Name: ");
            user.Name = Console.ReadLine() ?? "";
            Console.Write("Enter user Email: ");
            user.Email = Console.ReadLine() ?? "";
            Console.Write("Enter user Contact: ");
            user.Contact = Console.ReadLine() ?? "";

            userService.AddUser(user);
            Console.WriteLine("User added successfully.");
        }

        public static void UpdateUser()
        {
            Console.Write("Enter user ID to update: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var userToUpdate = userService.GetUserById(id);
            if (userToUpdate == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            var updatedUser = new User() { Id = id };

            Console.WriteLine("Select property to update:");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Email");
            Console.WriteLine("3. Contact");
            Console.WriteLine("4. Done");

            bool updating = true;
            while (updating)
            {
                Console.Write("Enter your choice (1-4): ");
                string choice = Console.ReadLine() ?? "";
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter new Name: ");
                        updatedUser.Name = Console.ReadLine() ?? "";
                        break;
                    case "2":
                        Console.Write("Enter new Email: ");
                        updatedUser.Email = Console.ReadLine() ?? "";
                        break;
                    case "3":
                        Console.Write("Enter new Contact: ");
                        updatedUser.Contact = Console.ReadLine() ?? "";
                        break;
                    case "4":
                        updating = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }

            Console.WriteLine($"ID: {updatedUser.Id} , Name: {updatedUser.Name}, Email: {updatedUser.Email}, Contact: {updatedUser.Contact}");

            userService.UpdateUser(updatedUser);
            Console.WriteLine("User updated successfully.");
        }

        public static void RemoveUser()
        {
            Console.Write("Enter user ID to remove: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            userService.RemoveUser(id);
            Console.WriteLine("User removed successfully.");
        }

        public static void ListUsers()
        {
            Console.WriteLine("Listing Users added...");
            if (!userService.GetAllUsers().Any())
            {
                Console.WriteLine("Users list empty.");
                return;
            }
            foreach (var user in userService.GetAllUsers())
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}, Contact: {user.Contact}");
            }
        }

        public static void SortAndDisplayStudents()
        {
            Console.WriteLine("Sorting students by Score in descending order...");
            var studentArray = students.ToArray();
            Sorter.BubbleSort(studentArray, (x, y) => y.Score.CompareTo(x.Score));

            Console.WriteLine("Sorted Students:");
            foreach (var student in studentArray)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Score: {student.Score}");
            }
        }
    }
}
