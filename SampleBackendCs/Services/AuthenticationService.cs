using System;
using System.Collections.Generic;
using System.IO;
using Virgil.Crypto;
using Virgil.SDK.Common;
using Virgil.SDK.Web.Authorization;

namespace SampleBackendCs.Services
{
    public static class AuthenticationService
    {
        private static Dictionary<string, string> _authTokens;
        private static JwtGenerator _jwtGenerator;

        static AuthenticationService()
        {
            NewtonsoftJsonSerializer njs = new NewtonsoftJsonSerializer();
            var config = njs.Deserialize<Config>(File.ReadAllText(@"appsettings.json"));

            var apiKeyBase64 = config.API_KEY;
            var privateKeyData = Bytes.FromString(apiKeyBase64, StringEncoding.BASE64);

            var crypto = new VirgilCrypto();
            var apiKey = crypto.ImportPrivateKey(privateKeyData);

            var accessTokenSigner = new VirgilAccessTokenSigner();

            var appId = config.APP_ID;
            var apiKeyId = config.API_KEY_ID;
            var ttl = TimeSpan.FromHours(1); // 1 hour (JWT's lifetime)
            
            _jwtGenerator = new JwtGenerator(appId, apiKey, apiKeyId, ttl, accessTokenSigner);
            _authTokens = new Dictionary<string, string>();
        }

        public static string Login(string identity)
        {
            //String authToken = String.Format("{0} {1}", identity, Guid.NewGuid().ToString());
            string authToken = Guid.NewGuid().ToString();
            if (!_authTokens.TryAdd(authToken, identity)) return null; //TODO: add error message 
            return authToken;
        }

        public static string GetIdentity(string authToken)
        {
            if (string.IsNullOrWhiteSpace(authToken)) return null;
            //String token = authToken.Split(" ")[1];
            string token = authToken.Split(" ")[0];
            if (!_authTokens.TryGetValue(token, out string identity)) return null; //TODO: add error message 
            return identity;
        }

        public static Jwt GenerateVirgilToken(string identity)
        {
            return _jwtGenerator.GenerateToken(identity);
        }
    }
}
