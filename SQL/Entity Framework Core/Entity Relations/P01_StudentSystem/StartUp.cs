using P01_StudentSystem.Data;
using P01_StudentSystem.Data.Models;
using System;

namespace Code_First
{
    public class P01_StudentSystem
    {
        public static void Main(string[] args)
        {
            var db = new StudentSystemContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
                       

            db.SaveChanges();
        }
    }
}
