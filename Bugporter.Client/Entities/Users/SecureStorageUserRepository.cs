using Firebase.Auth;
using Firebase.Auth.Repository;
using System.Text.Json;

namespace Bugporter.Client.Entities.Users
{
    public class SecureStorageUserRepository : IUserRepository
    {
        private const string CURRENT_USER_INFO_KEY = "user_info";
        private const string CURRENT_FIREBASE_CREDENTIAL_KEY = "firebase_credential";

        private readonly ISecureStorage _secureStorage;

        public SecureStorageUserRepository(ISecureStorage secureStorage)
        {
            _secureStorage = secureStorage;
        }

        public (UserInfo userInfo, FirebaseCredential credential) ReadUser()
        {
            try
            {
                string userInfoJson = Task.Run(() => _secureStorage.GetAsync(CURRENT_USER_INFO_KEY)).Result;
                string credentialJson = Task.Run(() => _secureStorage.GetAsync(CURRENT_FIREBASE_CREDENTIAL_KEY)).Result;

                UserInfo userInfo = JsonSerializer.Deserialize<UserInfo>(userInfoJson);
                FirebaseCredential credential = JsonSerializer.Deserialize<FirebaseCredential>(credentialJson);

                return (userInfo, credential);
            }
            catch (Exception)
            {
                return (null, null);
            }
        }

        public void SaveUser(User user)
        {
            try
            {
                string userInfoJson = JsonSerializer.Serialize(user.Info);
                string credentialJson = JsonSerializer.Serialize(user.Credential);

                _secureStorage.SetAsync(CURRENT_USER_INFO_KEY, userInfoJson).GetAwaiter().GetResult();
                _secureStorage.SetAsync(CURRENT_FIREBASE_CREDENTIAL_KEY, credentialJson).GetAwaiter().GetResult();
            }
            catch (Exception)
            {
                
            }
        }

        public void DeleteUser()
        {
            _secureStorage.Remove(CURRENT_USER_INFO_KEY);
            _secureStorage.Remove(CURRENT_FIREBASE_CREDENTIAL_KEY);
        }

        public bool UserExists()
        {
            (UserInfo userInfo, FirebaseCredential credential) = ReadUser();

            return userInfo != null && credential != null;
        }
    }
}