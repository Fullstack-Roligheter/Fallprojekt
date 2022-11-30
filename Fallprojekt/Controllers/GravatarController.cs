using Microsoft.AspNetCore.Mvc;

namespace Fallprojekt.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GravatarController : ControllerBase
{
    [HttpGet("GetGravatarProfile")]
    public async Task<IActionResult> GetGravatarProfile(string hash)
    {
        string profileurl = $"https://www.gravatar.com/{hash}.json";

        HttpClient httpclient = new HttpClient();
        httpclient.DefaultRequestHeaders.Add("User-Agent", "MyWebAPI");

        try
        {
            var httpResponseMessege = await httpclient.GetAsync(profileurl);

            string JSONResponse = await httpResponseMessege.Content.ReadAsStringAsync();

            return Ok(JSONResponse);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500);
        }
        finally
        {
            httpclient.Dispose();
        }
    }
}