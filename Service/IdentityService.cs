using DAL;
using DAL.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using System.Security.Cryptography;

namespace Service
{
    public class IdentityService : IIdentityService
    {
        private readonly ProjectContext _projectContext;
        private readonly JWTServiceConfig _appSettings; //Osäker på om vi ens ska använda vår appsettings.json?

        private readonly TokenValidationParameters _tokenValidationParameters;

        public IdentityService(ProjectContext projectContext, IOptions<JWTServiceConfig> settings, TokenValidationParameters tokenValidationParameters)
        {
            _projectContext = projectContext;
            _appSettings = settings.Value;
            _tokenValidationParameters = tokenValidationParameters;
        }

        //public async Task<ResponseModel<JWTTokenModel>> LoginAsync(LoginModel login)
        //{
        //    ResponseModel<JWTTokenModel> responseModel = new ResponseModel<JWTTokenModel>();
        //    try
        //    {
             

        //            //GenerateMd5Hash(login.Password);
        //    }
        //}
    }
}
