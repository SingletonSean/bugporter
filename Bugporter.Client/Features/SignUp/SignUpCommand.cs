using Bugporter.Client.Shared.Commands;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugporter.Client.Features.SignUp
{
    public class SignUpCommand : AsyncCommandBase
    {
        private readonly SignUpFormViewModel _viewModel;
        private readonly FirebaseAuthClient _authClient;

        public SignUpCommand(SignUpFormViewModel viewModel, FirebaseAuthClient authClient)
        {
            _viewModel = viewModel;
            _authClient = authClient;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            if (_viewModel.Password != _viewModel.ConfirmPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Password and confirm password values do not match.", "Ok");
                return;
            }

            try
            {
                await _authClient.CreateUserWithEmailAndPasswordAsync(_viewModel.Email, _viewModel.Password);

                await Application.Current.MainPage.DisplayAlert("Success", "Successfully signed up!", "Ok");

                await Shell.Current.GoToAsync("//SignIn");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to sign up. Please try again later.", "Ok");
            }
        }
    }
}
