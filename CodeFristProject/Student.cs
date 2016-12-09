﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFristProject
{
    public class Student
    {
        public Student()
        {
            
        }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        //public int StandardId { get; set; }
        public Teacher Teacher { get; set; }
        public Standard Standard { get; set; }
      

    }
    public class Teacher
    {
        public Teacher()
        {

        }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
    }

}
