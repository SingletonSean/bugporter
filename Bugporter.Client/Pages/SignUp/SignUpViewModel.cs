using Bugporter.Client.Features.SignUp;
using Bugporter.Client.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugporter.Client.Pages.SignUp
{
    public class SignUpViewModel : ViewModelBase
    {
        public SignUpFormViewModel SignUpFormViewModel { get; }

        public SignUpViewModel(SignUpFormViewModel signUpFormViewModel)
        {
            SignUpFormViewModel = signUpFormViewModel;
        }
    }
}
