using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Services.Interfaces;

namespace UniClub.Services
{
    public class FirebaseUploadService : IUploadService
    {
        private static string API_KEY = "";
        private static string BUCKET = "";
        private static string AUTH_EMAIL = "";
        private static string AUTH_PASSWORD = "";
        public async Task<string> Upload(IFormFile file, string folder = "files")
        {
            string link = string.Empty;
            try
            {
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);

                    var auth = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));
                    var signIn = await auth.SignInWithEmailAndPasswordAsync(AUTH_EMAIL, AUTH_PASSWORD);

                    var cancellation = new CancellationTokenSource();

                    var task = new FirebaseStorage(
                        BUCKET,
                        new FirebaseStorageOptions
                        {

                            AuthTokenAsyncFactory = () => Task.FromResult(signIn.FirebaseToken),
                            ThrowOnCancel = true
                        })
                        .Child(folder)
                        .Child(file.FileName)
                        .PutAsync(stream, cancellation.Token);
                    link = await task;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return link;
        }
    }
}
