using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class AuthenticationResult : JWTTokenModel
    {
        public bool Success { get; set; }
        //public string Error { get; set; }
        public IEnumerable<string> Errors { get; set; }

    }
    public class JWTTokenModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }

}
