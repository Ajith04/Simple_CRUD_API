using DotNetCRUD.DTO.RequestDTO;
using DotNetCRUD.DTO.ResponseDTO;
using DotNetCRUD.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost("Add-Subject")]
        public async Task<ActionResult<SubjectResponseDTO>> AddSubjectAsync(SubjectRequestDTO subjectRequestDTO)
        {
            var createdSubject = await _subjectService.AddSubjectAsync(subjectRequestDTO);
            return Ok(createdSubject);
        }

        [HttpGet("Get-All-Subject")]
        public async Task<ActionResult<IEnumerable<SubjectResponseDTO>>> GetAllSubjectsAsync()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            return Ok(subjects);
        }

        [HttpGet("Get-Subject-By-Id")]
        public async Task<ActionResult<SubjectResponseDTO>> GetSubjectByIdAsync(int id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);
            if (subject == null) 
            { 
                return NotFound();
            }
            return Ok(subject);
        }

        [HttpPut("Update-Subject-By-Id")]
        public async Task<ActionResult> UpdateSubjectByIdAsync(int id, SubjectRequestDTO subjectRequestDTO)
        {
            var updatedSubject = await _subjectService.UpdateSubjectByIdAsync(id, subjectRequestDTO);
            if (updatedSubject == null)
            {
                return NotFound();
            }
            return Ok(updatedSubject);

        }

        [HttpDelete("Delete-Subject-By-Id")]
        public async Task<IActionResult> DeleteSubjectAsync(int id)
        {
            await _subjectService.DeleteSubjectAsync(id);
            return Ok();
        }

    }
}
