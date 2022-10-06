﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace Fallprojekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GravatarController : ControllerBase
    {
        [HttpGet("GetGravatarProfile")]
        public async Task<string> GetGravatarProfile(string hash)
        {
            string profileurl = $"https://www.gravatar.com/{hash}.json";

            HttpClient httpclient = new HttpClient();
            httpclient.DefaultRequestHeaders.Add("User-Agent", "MyWebAPI");

            try
            {
                var httpResponseMessege = await httpclient.GetAsync(profileurl);

                string JSONResponse = await httpResponseMessege.Content.ReadAsStringAsync();

                return (JSONResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ("");
            }
            finally
            {
                httpclient.Dispose();
            }
        }
    }
}
