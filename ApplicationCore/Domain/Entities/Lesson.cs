﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Entities
{
    public class Lesson : BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public string Time { get; set; }
        public float Grade { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
