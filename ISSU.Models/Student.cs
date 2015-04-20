﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISSU.Models
{
    public class Student
    {
        private ICollection<CourseResult> courseResults;

        public Student()
        {
            courseResults = new HashSet<CourseResult>();
        }

        public int ID { get; set; }
        public int Group { get; set; }
        public int Year { get; set; }
        public int FacultyNumber { get; set; }
        public string Programme { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public DateTime? Updated { get; set; } 
        public string LastAuthKey { get; set; }

        public virtual ICollection<CourseResult> CourseResults 
        { 
            get
            {
                return courseResults;
            }
            set
            {
                courseResults = value;
            }
        }
    }
}
