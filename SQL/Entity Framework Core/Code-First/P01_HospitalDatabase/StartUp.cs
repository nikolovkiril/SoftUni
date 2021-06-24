﻿using P01_HospitalDatabase.Data;
using System;

namespace P01_HospitalDatabase
{
    public class P01_HospitalDatabase
    {
        public static void Main(string[] args)
        {
            var db = new HospitalContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
                       

            db.SaveChanges();
        }
    }
}
