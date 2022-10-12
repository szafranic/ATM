namespace ATM
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to the ATM at 7-11 on Jefferson Ave");

<<<<<<< HEAD
			Console.WriteLine("changing code lol");
			List<User> users = new List<User>()
=======
            //test code review line change

            List<User> users = new List<User>()
>>>>>>> a9300ad1608295b4110a60ba9e0796b1db337a2c
			{
				new User("Hudson", "1234", 1000),
				new User("Brian", "godfather", 9999999),
				new User("Bob", "sponge", 13),
				new User("nath", "moth", 1717),
				new User("Slime", "mine", 3000),
				new User("Bianca", "Sn1vy", 8888)
			};

			ATM atm = new ATM(users);
			while(true)
			{
				User cur = LoginForm(users);
				WhatToDo(users, cur);
			}
		}
		public static string getString(string msg)
		{
			Console.Write(msg);
			string output = Console.ReadLine();
			while(output == null)
			{
				Console.WriteLine("please enter something.");
				Console.Write(msg);
				output = Console.ReadLine();
			}
			return output;
		}
		public static int getInt(string msg)
		{
			int output = -1;
			Console.Write(msg);
			try
			{
				output = int.Parse(Console.ReadLine());
			}
			catch (FormatException)
			{
				Console.WriteLine("that isnt a number");
				getInt(msg);
			}
			while (output == -1)
			{
				Console.WriteLine("please enter something.");
				Console.Write(msg);
				output = int.Parse(Console.ReadLine());
			}
			return output;
		}
		public static bool AskToContinue()
		{
			Console.WriteLine("would you like to continue? (y/n)");
			string input = Console.ReadLine().ToLower();
			if (input == "y" || input == "yes")
			{
				return true;

			}
			else if (input == "n" || input == "no")
			{
				return false;
			}
			else
			{
				Console.WriteLine("try again (y/n)");
				return AskToContinue();
			}
		}
		public static User LoginForm(List<User> users)
		{
			ATM atm = new ATM(users);
			bool notLoggedIn = true;
			User currentUser = null;
			while (notLoggedIn)
			{
				Console.WriteLine("would you like to login or register?");
				string menu = Console.ReadLine().ToLower();
				if (menu == "login")
				{
					string Name = getString("Your Name: ");
					string Password = getString("Password: ");
					//next line tries to log in and returns 
					currentUser = atm.Login(Name, Password);
					notLoggedIn = (currentUser == null);
				}
				else if (menu == "register")
				{
					string Name = getString("Your Name: ");
					string Password = getString("Password: ");
					currentUser = atm.Register(Name, Password);
					notLoggedIn = (currentUser == null);
				}
				else
				{
					Console.WriteLine("please input *login* or *register*");
				}
			}
			Console.WriteLine("Hello, " + atm.CurrentUser.Name);
			return currentUser;
		}
		public static void WhatToDo(List<User> users, User CurrentUser)
		{
			ATM atm = new ATM(users);
			
/*			bool running = true;
			while (running)
			{*/
				bool LoggedIn = true;
				while (LoggedIn)
				{
					Console.WriteLine("would you like to [1]deposit, [2]withdraw, [3]checkbalance, or [4]logout?");
					string menu = Console.ReadLine().ToLower();
					if (menu == "deposit" || menu == "1")
					{
						int amount = getInt("deposit amount: ");
						atm.Deposit(amount, CurrentUser.Name);
					}
					else if (menu == "withdraw" || menu == "2")
					{
						int amount = getInt("withdrawl amount: ");

						atm.Withdraw(amount, CurrentUser.Name);
					}
					else if (menu == "balance" || menu == "checkbalance" || menu == "3")
					{
						int amount = 0;
						atm.CheckBalance(users, CurrentUser.Name);
					}
					else if (menu == "logout" || menu == "4")
					{
						atm.Logout();
						CurrentUser = null;
						LoggedIn = false;
					}
					else
					{
						Console.WriteLine("please input the *title* or *#* of what you want");
					}
				}
			//}
		}
	}
}