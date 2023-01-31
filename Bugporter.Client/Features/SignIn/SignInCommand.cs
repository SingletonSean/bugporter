using Bugporter.Client.Shared.Commands;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugporter.Client.Features.SignIn
{
    public class SignInCommand : AsyncCommandBase
    {
        private readonly SignInFormViewModel _viewModel;
        private readonly FirebaseAuthClient _authClient;

        public SignInCommand(SignInFormViewModel viewModel, FirebaseAuthClient authClient)
        {
            _viewModel = viewModel;
            _authClient = authClient;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _authClient.SignInWithEmailAndPasswordAsync(_viewModel.Email, _viewModel.Password);

                await Application.Current.MainPage.DisplayAlert("Success", "Successfully signed in!", "Ok");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to sign in. Please try again later.", "Ok");
            }
        }
    }
}
