using DotNetCRUD.DTO.RequestDTO;
using DotNetCRUD.DTO.ResponseDTO;
using DotNetCRUD.IRepositories;
using DotNetCRUD.IServices;
using DotNetCRUD.Models;

namespace DotNetCRUD.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<SubjectResponseDTO> AddSubjectAsync(SubjectRequestDTO subjectRequestDTO)
        {
            var subject = new Subject
            {
                Name = subjectRequestDTO.Name,
                Description = subjectRequestDTO.Description,
                SubType = subjectRequestDTO.SubType
            };
            await _subjectRepository.AddSubjectAsync(subject);
            return new SubjectResponseDTO
            {
                Name = subject.Name,
                Description = subject.Description,
                SubType = subject.SubType
            };
        }

       public async Task<IEnumerable<SubjectResponseDTO>> GetAllSubjectsAsync()
        {
            var subjects = await _subjectRepository.GetAllSubjectsAsync();
            return subjects.Select(s => new SubjectResponseDTO
            {
                Name = s.Name,
                Description = s.Description,
                SubType = s.SubType
            }).ToList();
        }

        public async Task<SubjectResponseDTO> GetSubjectByIdAsync(int id)
        {
            var subject = await _subjectRepository.GetSubjectByIdAsync(id);
            if (subject == null)
            {
                return null;
            }
            return new SubjectResponseDTO
            {
                Name = subject.Name,
                Description = subject.Description,
                SubType = subject.SubType
            };
        }

        public async Task<SubjectResponseDTO> UpdateSubjectByIdAsync(int id, SubjectRequestDTO subjectRequestDTO)
        {
            var subject = await _subjectRepository.GetSubjectByIdAsync(id);
            if (subject == null)
            {
                return null;
            }
            subject.Name = subjectRequestDTO.Name;
            subject.Description = subjectRequestDTO.Description;
            subject.SubType = subjectRequestDTO.SubType;

            var updatedSubject = await _subjectRepository.UpdateSubjectByIdAsync(subject);

            return new SubjectResponseDTO
            {
                Name = updatedSubject.Name,
                Description = updatedSubject.Description,
                SubType = updatedSubject.SubType
            };
        }

        public async Task DeleteSubjectAsync(int id)
       {
            await _subjectRepository.DeleteSubjectAsync(id);
       }
    }
}
