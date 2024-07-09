﻿using System.Security.Claims;
using UniTutor.Model;

namespace UniTutor.Interface
{
    public interface IAdmin
    {
        
        
        public ClaimsPrincipal validateToken(string token);

        public bool IsAdmin(Admin admin);

        public Admin GetAdminByEmail(string Email);
        public Admin GetAdminById(int Id);

        public bool Logout();
        bool Login(string email, string password);
        bool CreateAdmin(Admin admin);

        public IEnumerable<Student> GetAllStudent();
        public IEnumerable<Tutor> GetAllTutor();
        Tutor  GetTutorById(int id);
        public  Task AcceptTutor(int id);
        public Task RejectTutor(int id);

        Student GetStudentById(int id);

        




    }
}
