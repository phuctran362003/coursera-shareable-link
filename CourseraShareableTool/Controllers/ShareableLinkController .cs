using CourseraShareableTool.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ShareableLinkController : ControllerBase
{
    [HttpPost]
    [Route("generate")]
    public IActionResult GenerateLink([FromBody] ShareableLinkRequest request)
    {
        if (string.IsNullOrEmpty(request.OriginalUrl))
            return BadRequest("Invalid URL");

        var shareableLink = $"{request.OriginalUrl}?share=true";
        return Ok(new ShareableLinkResponse { ShareableLink = shareableLink });
    }
}
