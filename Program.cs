using System.Linq;
namespace LINQDemo
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Fees { get; set; }
        public int Age { get; set; }
        public double Score { get; set; }

        public void PrintRecord()
        {
            Console.WriteLine("Id: "+this.Id+" Name: "+this.Name+" Fees: "+this.Fees+" Age: "+this.Age+" Score: "+this.Score);
        }
    }

    internal class Program
    {

        public static void MainTest4()
        {
            List<Student> students = new List<Student>();       //here students is object of List class

            students.Add(new Student { Id = 101, Name = "Malkeet", Age = 35, Fees = 345.78, Score = 67 });
            students.Add(new Student { Id = 105, Name = "Soham", Age = 25, Fees = 11345.78, Score = 98 });
            students.Add(new Student { Id = 104, Name = "Zeenat", Age = 21, Fees = 456745, Score = 81 });
            students.Add(new Student { Id = 102, Name = "Parimal", Age = 20, Fees = 78945.78, Score = 60 });
            students.Add(new Student { Id = 103, Name = "Mohini", Age = 22, Fees = 674523, Score = 89 });

            

           // var stus = students.ToList().Where(s => s.Score > 90);      //Immediate execution

            var stus = from s in students where s.Score>90 select s;
            int num = students.Count();

            students.Add(new Student { Id = 106, Name = "Vaishnavi", Age = 23, Fees = 12345, Score = 96 });

           Console.WriteLine("The Number of Students are: "+num);

            foreach (Student student in stus)       //Deffered Execution
            {
                student.PrintRecord();
            }



        }

        public static void MainTest3()
        {
            List<Student> students = new List<Student>();       //here students is object of List class

            students.Add(new Student { Id = 101, Name = "Malkeet", Age = 35, Fees = 345.78, Score = 67 });
            students.Add(new Student { Id = 105, Name = "Soham", Age = 25, Fees = 11345.78, Score = 98 });
            students.Add(new Student { Id = 104, Name = "Zeenat", Age = 21, Fees = 456745, Score = 81 });
            students.Add(new Student { Id = 102, Name = "Parimal", Age = 20, Fees = 78945.78, Score = 60 });
            students.Add(new Student { Id = 103, Name = "Mohini", Age = 22, Fees = 674523, Score = 89 });

            var stus = students.ToList().Where(s=>s.Age>24).OrderBy(s=>s.Age);

            foreach(Student student in stus)
            {
                student.PrintRecord();
            }




        }

        public static void MainTest2()
        {
            List<Student> students = new List<Student>();       //here students is object of List class

            students.Add(new Student { Id = 101, Name = "Malkeet", Age = 35, Fees = 345.78, Score = 67 });
            students.Add(new Student { Id = 105, Name = "Soham", Age = 25, Fees = 11345.78, Score = 98 });
            students.Add(new Student { Id = 104, Name = "Zeenat", Age = 21, Fees = 456745, Score = 81 });
            students.Add(new Student { Id = 102, Name = "Parimal", Age = 20, Fees = 78945.78, Score = 60 });
            students.Add(new Student { Id = 103, Name = "Mohini", Age = 22, Fees = 674523, Score = 89 });
            
            var stus = from s in students where s.Name.StartsWith("M") select s;

            foreach( Student s in stus)
            {
                s.PrintRecord();
            }
            Console.WriteLine("Age Filter");
            var stusAge = from s in students where s.Age > 30 && s.Age <40 select s;

            foreach (Student s in stusAge)
            {
                s.PrintRecord();
            }
        }

        static void MainTest1(string[] args)
        {
            List<Student> students = new List<Student>();       //here students is object of List class

            students.Add(new Student { Id = 101, Name = "Malkeet", Age = 35, Fees = 345.78, Score = 67 });
            students.Add(new Student { Id = 105, Name = "Soham", Age = 25, Fees = 11345.78, Score = 98  });
            students.Add(new Student { Id = 104, Name = "Zeenat", Age = 21, Fees = 456745, Score = 81 });
            students.Add(new Student { Id = 102, Name = "Parimal", Age = 20, Fees = 78945.78, Score = 60 });
            students.Add(new Student { Id = 103, Name = "Mohini", Age = 22, Fees = 674523, Score = 89 });

            //select s.name from students (SQL)
            //from s in students select s.name (LINQ)

            var names = from s in students where s.Fees > 70000 select s.Name;

            //Select s.name from students where s.Fees > 70000; (SQL)

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            var person = from s in students select new { s.Name, s.Age };

            foreach (object o in person)
            {
                Console.WriteLine(o.ToString());
            }
        }
    }
}
