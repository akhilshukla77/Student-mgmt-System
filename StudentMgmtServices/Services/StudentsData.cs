using StudentMgmtServices.DAL;
using StudentMgmtServices.Interfaces;
using StudentMgmtServices.Models;
using StudentMgmtServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMgmtServices.Services
{
    public class StudentsData : IStudents
    {
        private readonly AppDBContext _appdbContext;
        public StudentsData(AppDBContext appdbcontext)
        {
            _appdbContext = appdbcontext;
        }
        
        public List<Student> GetAllStudents()
        {
            return _appdbContext.StudentsList.ToList(); ;
        }
        public List<StudentEnrolledList> GetAllStudentEnrolledList()
        {
            List<StudentEnrolledList> enrolledList = new List<StudentEnrolledList>();
            var studentEnrolledList = (from s in _appdbContext.StudentsList
                                       join r in _appdbContext.StudentEnrollments on s.Ssn equals r.StudentId

                                       select new
                                       {
                                           studentId = s.Ssn,
                                           s.FirstName,
                                           s.LastName,                                                
                                           r.SchoolYear,
                                           r.StartDate,
                                           r.EndDate
                                       }).ToList();
            foreach (var item in studentEnrolledList)
            {
                enrolledList.Add(new StudentEnrolledList
                {
                    StudentId = item.studentId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    SchoolYear = item.SchoolYear,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate

                });
            }

            return enrolledList;
        }


        public List<StudentServicesInfo> GetAllStudentServices()
        {
            List<StudentServicesInfo> servicesInfo = new List<StudentServicesInfo>();
            var StudentServicesList = (from s in _appdbContext.StudentsList
                                       join r in _appdbContext.StudentServices on s.Ssn equals r.StudentId

                                       select new
                                       {
                                           studentId = s.Ssn,
                                           s.FirstName,
                                           s.LastName,                                                
                                           r.SchoolYear,
                                           r.StartDate,
                                           r.EndDate,
                                           r.ServiceName
                                       }).ToList();

            foreach (var item in StudentServicesList)
            {
                servicesInfo.Add(new StudentServicesInfo
                {
                    StudentId = item.studentId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    SchoolYear = item.SchoolYear,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    ServiceName = item.ServiceName

                });
            }

            return servicesInfo;
        }
    }
}
