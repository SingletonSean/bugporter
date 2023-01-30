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
        private readonly FirebaseAuthClient _authClient;

        public SignUpCommand(FirebaseAuthClient authClient)
        {
            _authClient = authClient;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var result = await _authClient.CreateUserWithEmailAndPasswordAsync("test@gmail.com", "test123");

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
