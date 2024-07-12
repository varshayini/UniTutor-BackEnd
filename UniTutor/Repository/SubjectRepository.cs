using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniTutor.DataBase;
using UniTutor.DTO;
using UniTutor.Interface;
using UniTutor.Model;

namespace UniTutor.Repository
{
    public class SubjectRepository : ISubject
    {
        private ApplicationDBContext _DBcontext;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public SubjectRepository(ApplicationDBContext DBcontext, IConfiguration config, IMapper mapper)
        {
            _DBcontext = DBcontext;
            _config = config;
            _mapper = mapper;

        }

        public async Task<bool> CreateSubject(int tutorId, SubjectRequestDto request)
        {
            var tutor = await _DBcontext.Tutors.FindAsync(tutorId);
            if (tutor == null)
            {
                return false; // Tutor not found
            }

            var subject = new Subject
            {
                title = request.title,
                description = request.description,
                coverImage = request.coverImage,
                medium = request.medium,
                mode = request.mode,
                availability = request.availability,
                tutorId = tutorId,

            };

            _DBcontext.Subjects.Add(subject);
            await _DBcontext.SaveChangesAsync();
            return true;
        }
        public async Task<Subject> GetSubjectById(int id)
        {
            return await _DBcontext.Subjects.FindAsync(id);
        }
        public async Task<Subject> GetSubject(int tutorId, int id)
        {
            var subject = await GetSubjectById(id);
            if (subject == null || subject.tutorId != tutorId)
            {
                return null; // Subject not found or doesn't belong to the tutor
            }
            return subject;
        }

        public async Task<List<Subject>> GetSubjectsByTutorId(int tutorId)
        {
            return await _DBcontext.Subjects.Where(s => s.tutorId == tutorId).ToListAsync();
        }
        //methode for deteting a subject
        public async Task<Subject> DeleteSubject(int id)
        {
            var subject = await _DBcontext.Subjects.FindAsync(id);
            if (subject == null)
            {
                return null;
            }

            _DBcontext.Subjects.Remove(subject);
            await _DBcontext.SaveChangesAsync();
            return subject;
        }
        //update method for updating a subject withautomapper
        public async Task<Subject> UpdateSubject(int id, SubjectRequestDto request)
        {
            var subject = await _DBcontext.Subjects.FindAsync(id);
            if (subject == null)
            {
                return null;
            }

            _mapper.Map(request, subject);
            await _DBcontext.SaveChangesAsync();

            return subject;
        }
        //get all the subject
        public async Task<List<Subject>> GetAllSubjects()
        {
            return await _DBcontext.Subjects.ToListAsync();
        }

        //public async Task<List<Subject>> GetAllSubjects()
        //{
        //    var subjectsWithRatings = await _DBcontext.Subjects
        //        .Include(s => s.Tutor)
        //        .Select(s => new Subject
        //        {
        //            title = s.title,
        //            description = s.description,
        //            coverImage = s.coverImage,
        //            medium = s.medium,
        //            mode = s.mode,
        //            availability = s.availability,
        //            tutorName = s.Tutor.firstName, // Map Tutor's firstName to tutorName
        //            tutorId = s.Tutor._id,
        //            AverageRating = _DBcontext.Reviews
        //                .Where(r => r.subjectId == s._id)
        //                .Select(r => r.rating)
        //                .DefaultIfEmpty(0)
        //                .Average()
        //        })
        //        .ToListAsync();

        //    return subjectsWithRatings;
        //}


    }
}