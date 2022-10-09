using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
	internal class User
	{
		public string Name { get; set; }
		private string Password { get; set; }
		public int Balance { get; set; }

		public string password
		{

			get
			{
				return Password;
			}
		}

		public User(string Name, String Password, int Balance)
		{
			this.Name = Name;
			this.Password = Password;
			this.Balance = Balance;	

		}

	}
}
