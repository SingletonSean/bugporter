using Bugporter.Client.Features.SignIn;
using Bugporter.Client.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugporter.Client.Pages.SignIn
{
    public class SignInViewModel : ViewModelBase
    {
        public SignInFormViewModel SignInFormViewModel { get; }

        public SignInViewModel(SignInFormViewModel signInFormViewModel)
        {
            SignInFormViewModel = signInFormViewModel;
        }
    }
}
