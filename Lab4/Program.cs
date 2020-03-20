using System;
using System.Collections;

namespace EFConsole6
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                var stud = new Student() {StudentName = "Popescu"};
                ctx.Students.Add(stud);
                ctx.SaveChanges();
            }
        }
    }
}
