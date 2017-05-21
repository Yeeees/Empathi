using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MpathY.Models
{
    //Database set for code-first database.
    public class MyDbContext : DbContext
    {
        public DbSet<Classification> Classifications { set; get; }
    }
   
}