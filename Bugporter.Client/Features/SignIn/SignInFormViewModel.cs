using Bugporter.Client.Entities.Users;
using Bugporter.Client.Shared.ViewModels;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bugporter.Client.Features.SignIn
{
    public class SignInFormViewModel : ViewModelBase
    {
		private string _email;
		public string Email
		{
			get
			{
				return _email;
			}
			set
			{
				_email = value;
				OnPropertyChanged(nameof(Email));
			}
		}

		private string _password;
		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
				OnPropertyChanged(nameof(Password));
			}
		}

		public ICommand SignInCommand { get; }

		public SignInFormViewModel(FirebaseAuthClient authClient, CurrentUserStore currentUserStore)
		{
            SignInCommand = new SignInCommand(this, authClient, currentUserStore);
        }
	}
}
