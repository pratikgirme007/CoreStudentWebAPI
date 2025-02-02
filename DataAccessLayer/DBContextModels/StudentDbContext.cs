﻿using CoreStudentWebAPI.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreStudentWebAPI.DataAccessLayer.DBContextModels
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) 
                            : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
