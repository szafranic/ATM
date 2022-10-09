using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ATM
{
	internal class ATM
	{
		public List<User> Users { get; set; }
		public User CurrentUser { get; set; }
		
		public ATM(List<User> users)
		{
			this.Users = users;
		}

		private User getCurrentUser(string Name)
		{
			return Users.Where(user => user.Name == Name).First();
		}

		public User Register(string Name, string Password)
		{
			Users.Add(new User(Name, Password, 0));
			CurrentUser = getCurrentUser(Name);
			return getCurrentUser(Name);
		}

		public User Login(string Name, string Password)
		{
			if (true)
			{
				try
				{
					Users.Where(user => user.Name == Name && user.password == Password);
					CurrentUser = getCurrentUser(Name);
				}
				catch (InvalidOperationException)
				{
					Console.WriteLine("thats a bad combo");
					return null;
				}
				return CurrentUser;
			}
			return null;
		}
		public void Logout()
		{
			CurrentUser = null;
		}


		

		public void CheckBalance(List<User> users, string Name)
		{
			Console.WriteLine("Your current balance is: $" + getCurrentUser(Name).Balance);
		}

		public void Deposit(int transfer, string Name)
		{
			Console.WriteLine("You balance was: $" + getCurrentUser(Name).Balance);
			getCurrentUser(Name).Balance += transfer;
			Console.WriteLine("You balance now is: $"+ getCurrentUser(Name).Balance);
		}

		public void Withdraw(int transfer, string Name)
		{
			
			if (getCurrentUser(Name).Balance - transfer >= 0)
			{
				Console.WriteLine("You balance was: $" + getCurrentUser(Name).Balance);
				getCurrentUser(Name).Balance -= transfer;
				Console.WriteLine("You balance now is: $" + getCurrentUser(Name).Balance);

			}
			else
			{
				Console.WriteLine("you cant withdraw more than $"+ getCurrentUser(Name).Balance);
			}
		}


	}
}
