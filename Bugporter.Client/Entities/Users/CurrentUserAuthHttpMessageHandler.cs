using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bugporter.Client.Entities.Users
{
    public class CurrentUserAuthHttpMessageHandler : DelegatingHandler
    {
        private readonly CurrentUserStore _currentUserStore;

        public CurrentUserAuthHttpMessageHandler(CurrentUserStore currentUserStore)
        {
            _currentUserStore = currentUserStore;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string accessToken = await GetAccessToken();

            if (accessToken != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            return await base.SendAsync(request, cancellationToken);
        }

        private Task<string> GetAccessToken()
        {
            User currentUser = _currentUserStore.CurrentUser;

            if (currentUser == null)
            {
                return null;
            }

            try
            {
                return currentUser.GetIdTokenAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
