using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseResultManagementWebApp.Gateway;
using UniversityCourseResultManagementWebApp.Models;
using UniversityCourseResultManagementWebApp.Models.ViewModels;

namespace UniversityCourseResultManagementWebApp.Manager
{
    public class StudentManager
    {
        StudentGateway aStudentGateway = new StudentGateway();

        public string SaveStudent(Student student)
        {
            if (aStudentGateway.IsUniqeEmail(student.Email) != null)
            {
                return "Email Not Unique";
            }

            int rowAffected = aStudentGateway.SaveStudent(student);
            if (rowAffected > 0)
            {

                return "yes";
            }
            else
            {
                return "no";
            }
        }

        public List<SelectListItem> GetAllStudentsSelectListItem()
        {
            return aStudentGateway.GetAllStudentsSelectListItem();
        }

        public List<Student> GetStudentById(int studentId)
        {
            return aStudentGateway.GetStudentById(studentId);
        }

        public ResultSheet GenerateResultForStudentId(int studentId)
        {
            return aStudentGateway.GenerateResultForStudentId(studentId);
        }
    }
}