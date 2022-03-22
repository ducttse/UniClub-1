using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UniClub.Application.Interfaces;
using UniClub.Application.Models;
using UniClub.HttpApi.Utils;

namespace UniClub.HttpApi.Services
{
    public class FireBaseRegisterService : IFireBaseRegisterService
    {
        private readonly string FIREBASE_REGISTER_URL;
        private readonly IOptions<AppSettings> _appSettings;

        public FireBaseRegisterService(IOptions<AppSettings> appSettings)
        {
            FIREBASE_REGISTER_URL = $"https://identitytoolkit.googleapis.com";
            _appSettings = appSettings;
        }
        public async Task RegisterToFireBase(string email, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(FIREBASE_REGISTER_URL);
                FirebaseSignUp registerForm = new FirebaseSignUp { Email = email, Password = password };
                // List all Names.
                HttpResponseMessage response = await client.PostAsJsonAsync($"/v1/accounts:signUp?key={_appSettings.Value.AuthKey}", registerForm);
                return;
            }
        }
    }
}
