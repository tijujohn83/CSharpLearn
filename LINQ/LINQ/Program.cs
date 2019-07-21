using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            #region LINQ Basic
            //List<int> numbers = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //IEnumerable<int> filterquery =
            //    from num in numbers
            //    where num > 3 && num < 7
            //    select num;

            //foreach (var item in filterquery)
            //{
            //    Console.WriteLine(item);
            //}

            //IEnumerable<int> orderingQuery =
            //    from num in numbers
            //    where num > 3 && num < 7
            //    orderby num ascending
            //    select num;

            //Console.WriteLine("Ordered query");
            //foreach (var item in orderingQuery)
            //{
            //    Console.WriteLine(item);
            //}

            //int nu = numbers.Where(n => n > 3 && n < 7).FirstOrDefault();

            //Console.WriteLine("Lambda");
            //Console.WriteLine(nu);

            
            string[] groupingQuery = { "carrots", "cabbage", "broccoli", "beans", "barley" };
            IEnumerable<IGrouping<char, string>> queryFoodGroups =
                from item in groupingQuery
                group item by item[0];


            // Having clause
            /*
            var query1 =
                from e in repository.GetAll()
                group e by e.DeptID
                    into eGroup
                    orderby eGroup.Key descending
                    where eGroup.Key < 3
                    select eGroup;
            */

            // Gouping by Composite Key
            /*
            var query2 =
                from e in repository.GetAll()
                group e by new
                {
                    e.DeptID,
                    FirstName = e.Name[0]
                };
            
            */

            // Projection
            /*
            var query3 =
                from e in repository.GetAll()
                group e by e.DeptID
                    into eGroup
                    orderby eGroup.Key descending
                    where eGroup.Key < 3
                    select new
                    {
                        DeptId = eGroup.Key,
                        Count = eGroup.Count(),
                        Employees = eGroup
                    };

            */

            // Lambda
            /*
            var query4 = repository.GetAll()
                .GroupBy(e => e.DeptId)
                .OrderByDescending(g => g.Key)
                .Where(g => g.Key < 3)
                .Select(g =>
                    new
                    {
                        DeptId = g.Key,
                        Count = g.Count(),
                        Employees = g
                    });

            */

            // Joins

            /*

            var joinQuery =
                from employee in employeeRepository.GetAll()
                join dept in departmentRepository.GetAll()
                    on employee.DeptId equals dept.DeptId
                select new { employee.Name, Department = dept.Name };


            */


            // Left Outer Join
            /*
            var leftOuterJoin =
                from d in departmentRepository.GetAll()
                join e in employeeRepository.GetAll()
                    on d.DeptId equals e.DeptId
                    into ed
                select new
                {
                    Department = d.Name,
                    Employees = e
                };

            */














            Console.WriteLine("Grouped query");
            foreach (var itemGroup in queryFoodGroups)
            {
                Console.WriteLine(itemGroup.Key);
                foreach (var item in itemGroup)
                {
                    Console.WriteLine(item);
                }
                
            }

            #endregion

            List<Student> students = new List<Student>
{
   new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
   new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
   new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
   new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
   new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
   new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
   new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
   new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
   new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
   new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
   new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
   new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91} }
};

            IEnumerable<Student> queryStudent =
                from student in students
                where student.Scores[0] > 90
                select student;
            foreach (var student in queryStudent)
            {
                //Console.WriteLine("{0}, {1}", student.First, student.Last);
            }

            // studentQuery2 is an IEnumerable<IGrouping<char, Student>> 
            var studentQuery2 =
                from student in students
                group student by student.Last[0];

            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("{0}, {1}", student.Last, student.First);
                }
            }
        }
    }

}
