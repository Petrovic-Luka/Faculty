using Faculty.Common.Models.Subject;
using Faculty.Core;
using Faculty.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Faculty.Api.Controllers;

[ApiController]
[Route("api/subjects")]
public class SubjectController : ControllerBase
{
    private readonly ISubjectManager subjectManager;

    public SubjectController(ISubjectManager subjectManager)
    {
        this.subjectManager = subjectManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSubjects()
    {
        try
        {
            return Ok(await subjectManager.GetAllSubjects());
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<IActionResult>CreateSubject(SubjectCreateModel model)
    {
        try
        {
            await subjectManager.Create(model);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
       
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSubject(Guid guid)
    {
        try
        {
            await subjectManager.Delete(guid);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSubject(Subject subject)
    {
        try
        {
            await subjectManager.Update(subject);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}
