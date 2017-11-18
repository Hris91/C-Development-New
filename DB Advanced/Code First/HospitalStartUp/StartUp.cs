using System;
using P01_HospitalDatabase.Data;
using P01_HospitalDatabase.Data.Models;
using P01_HospitalDatabase.Initializer;

namespace P01_HospitalDatabase
{
    public class StartUp
    {
        public static void Main()
        {

            DatabaseInitializer.ResetDatabase();
            using (var db = new HospitalContext())
            {
                //db.Database.EnsureCreated();
                DatabaseInitializer.InitialSeed(db);

                
            }
        }
    }
}
