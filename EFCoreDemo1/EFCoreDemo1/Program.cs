using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace EFCoreDemo1
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                //creates db if not exists 
                context.Database.EnsureCreated();

                //create entity objects
                var grd1 = new Grade() { GradeName = "1st Grade" };
                var std1 = new Student() { FirstName = "Akash", LastName = "Gupta", Grade = grd1 };

                //add entitiy to the context
                context.Students.Add(std1);

                //save data to the database tables
                context.SaveChanges();

                //retrieve all the students from the database
                foreach (var s in context.Students)
                {
                    Console.WriteLine($"First Name: {s.FirstName}, Last Name: {s.LastName}");
                }

                //retrieve entity
                var student = context.Students.FirstOrDefault();
                DisplayStates(context.ChangeTracker.Entries());
                context.Students.Add(new Student() { FirstName = "John", LastName = "Moore", Grade = grd1 });
                DisplayStates(context.ChangeTracker.Entries());
            }
        }
        static void DisplayStates(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State.ToString()}");
            }
        }
    }
}
