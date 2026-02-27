using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Intrinsics.X86;
using System.Threading.Channels;
using System.Xml.Linq;

record Product(int Id, string Name, decimal Price, string Category);

record Employee(string Name, string Department, decimal Salary);

namespace LINQ_Task
{

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1
            ////return all even numbers greater than 10, ordered descending
            //List<int> numbers = [3, 18, 7, 42, 10, 5, 29, 14, 6, 100];

            ////fluent
            //var nums = numbers.Where(n => n%2 == 0 && n > 10)
            //                  .OrderByDescending(n => n);
            //Console.WriteLine(string.Join(", ", nums));

            ////query
            //var nums2 = from n in numbers
            //            where n%2==0 && n>10
            //            orderby n descending
            //            select n;
            //Console.WriteLine(string.Join(", ", nums2)); 
            #endregion


            #region Q2
            //First, Last, Single, and ElementAt throw exceptions if no element matches(or more than one in the case of Single), while their OrDefault counterparts return null safely without throwing.
            //Using?.and ?? allows you to access properties or provide a default message safely when the result is null.


            List<Product> products =
            [
              new(1,"Laptop", 1200m,"Electronics"),
              new(2,"Phone", 800m,"Electronics"),
              new(3,"Desk", 350m,"Furniture"),
              new(4,"Chair", 150m,"Furniture"),
              new(5,"Headphones", 200m,"Electronics"),
            ];

            //// 1. Get the first Electronics product
            //var firstElectronics = products.FirstOrDefault(p => p.Category == "Electronics");
            //Console.WriteLine(firstElectronics?.Name ?? "Not Found");

            //// 2. Get the last product with Price > 1000 (use OrDefault — handle null)
            //var lastProduct = products.LastOrDefault(p => p.Price > 1000);
            //Console.WriteLine(lastProduct?.Price.ToString() ?? "No product with Price > 1000");

            //// 3. Get the single Furniture item with Price > 300 (what if >1 match?)
            //var furnitureMatches = products.Where(p => p.Category == "Furniture" && p.Price > 300);

            //if (furnitureMatches.Count() == 1)
            //{
            //    var singleFurniture = furnitureMatches.Single();
            //    Console.WriteLine(singleFurniture.Name);
            //}
            //else
            //{
            //    Console.WriteLine("Not one matching Furniture item");
            //}

            //// 4. Get the element at index 3 
            //var element = products.ElementAtOrDefault(3);

            //Console.WriteLine(element != null? $"Element at index 3: {element.Name}": "index out of range");

            #endregion


            #region Q3
            ////1.Are ALL products priced above 100 ? → bool
            //bool allAbove = products.All(p => p.Price > 100);
            //Console.WriteLine($"All products above 100? {allAbove}");

            ////2.Is THERE ANY product in the "Gaming" category ? → bool
            //bool anyGaming = products.Any(p => p.Category == "Gaming");
            //Console.WriteLine($"Any Gaming product? {anyGaming}");

            ////3.Does the collection CONTAIN a product named "Chair" ?(use the default comparer on the record)
            //bool containsChair = products.Contains(new Product(4, "Chair", 150m, "Furniture"));
            //Console.WriteLine($"Contains Chair? {containsChair}");

            ////4.Are ALL Electronics products priced above 500 ? → bool
            //bool allElectronicsAbove500 = products.Where(p => p.Category == "Electronics")
            //                                      .All(p => p.Price > 500);
            //Console.WriteLine($"All Electronics above 500? {allElectronicsAbove500}");

            ////5.Is there ANY product cheaper than 200 ? → bool
            //bool anyCheaperThan200 = products.Any(p => p.Price < 200);
            //Console.WriteLine($"Any product cheaper than 200? {anyCheaperThan200}");

            #endregion


            #region Q4

            // ToDictionary vs ToLookup:
            // - ToDictionary: Each key must be unique. If there are duplicate keys, it throws an ArgumentException.
            // - ToLookup: Allows multiple values per key. Duplicate keys are fine, and each key maps to a collection of values.


            //1.Convert to Array
            //Product[] prodArray = products.ToArray();
            //Console.WriteLine($"Array length: {prodArray.Length}");

            ////2.Convert to Dictionary keyed by Id
            //Dictionary<int, Product> prodDict = products.ToDictionary(p => p.Id);
            //Console.WriteLine($"Dictionary count: {prodDict.Count}");

            ////3.Convert to HashSet of product Names
            //HashSet<string> prodSet = products.Select(p => p.Name).ToHashSet();
            //Console.WriteLine($"HashSet contains {prodSet.Count} product names");

            ////4.Convert to Lookup keyed by Category → lookup["Electronics"] should return all electronics products
            //ILookup<string, Product> prodLookup = products.ToLookup(p => p.Category);

            //Console.WriteLine("Electronics products from Lookup:");
            //foreach (var p in prodLookup["Electronics"])
            //{
            //    Console.WriteLine($" {p.Name}");
            //}

            //What exception does ToDictionary throw if keys are duplicated?
            //ToDictionary throws an ArgumentException 
            //How does ToLookup handle duplicate keys differently ?
            //ToLookup allows duplicate keys; Keeps all items for the same key as a collection(no exception occurs)

            #endregion


            #region Q5
            List<string> orders =
               [
                 "ORD-001",
              "ORD-002",
              "ORD-003",
              "ORD-004",
              "ORD-005",
              "ORD-006",
              "ORD-007"
               ];

            //// 1. Get Page 1 (items 1–3)
            //var page1 = orders.Take(3);
            //Console.WriteLine("Page 1: " + string.Join(", ", page1));

            //// 2. Get Page 2 (items 4–6) ← use Skip + Take
            //var page2 = orders.Skip(3).Take(3);
            //Console.WriteLine("Page 2: " + string.Join(", ", page2));

            //// 3. Get the last 2 orders using TakeLast
            //var last2 = orders.TakeLast(2);
            //Console.WriteLine("Last 2: " + string.Join(", ", last2));

            //// 4. Drop the first and last order using Skip + SkipLast
            //var middle = orders.Skip(1).SkipLast(1);
            //Console.WriteLine("Without first & last: " + string.Join(", ", middle));

            #endregion


            #region Q6
            List<Employee> employees =
               [
                 new("Ali","Engineering", 9000m),new("Sara","Engineering", 8500m),
              new("Omar","HR", 6000m),
              new("Mona","HR", 6200m),
              new("Yara","Marketing", 7000m),
              new("Karim","Marketing", 7500m),
              new("Nada", "Engineering", 9500m),

            ];

            //// 1. Project to anonymous type: { FullName = Name.ToUpper(), Salary }
            //var anony = employees.Select(e => new
            //{
            //    FullName = e.Name.ToUpper(),
            //    e.Salary
            //});

            //// 2. Project to a formatted string: "Ali works in Engineering — EGP 9,000"
            //var format = employees.Select(e => $"{e.Name} works in {e.Department} - EGP {e.Salary}");

            //// 3. Sort by Salary descending, then use indexed Select to add Rank:
            ////{ Rank = index + 1, Name, Salary }
            ////Expected: { Rank=1, Name="Nada", Salary = 9500 },....
            //var rankedEmp = employees.OrderByDescending(e => e.Salary)
            //                         .Select((e, index) => new
            //                         {
            //                             Rank = index + 1,
            //                             e.Name,
            //                             e.Salary
            //                         });
            //Console.WriteLine("Ranking:");
            //foreach (var e in rankedEmp)
            //    Console.WriteLine($"Rank={e.Rank} ,Name={e.Name} - Salary={e.Salary}");

            ////BONUS: Project each employee to include a "SeniorityLevel" property:
            //var empLevel = employees.Select(e => new
            //{
            //    e.Name,
            //    e.Department,
            //    e.Salary,
            //    SeniorityLevel =
            //       e.Salary >= 9000 ? "Senior" :
            //       e.Salary >= 7000 ? "Mid" : "Junior"
            //}); 
            #endregion


            #region Q7
            //List<int> scores = [88, 92, 75, 60, 55, 80, 91, 45];

            //// 1. TakeWhile score >= 70 → expected: [88, 92, 75]
            //var scoreTake = scores.TakeWhile(s => s >= 70);
            //Console.WriteLine(string.Join(", ", scoreTake));

            //// 2. SkipWhile score >= 70 → expected: [60, 55, 80, 91, 45]
            //var scoreSkip = scores.SkipWhile(s => s >= 70);
            //Console.WriteLine(string.Join(", ", scoreSkip));

            //// 3. What is the difference between this and using Where? 
            //  // Where checks all elements and returns those matching the condition anywhere in the list. 
            #endregion


            #region Q8
            //// 1. Group by Department, print: "Engineering → Count: 3, Avg: 9000"
            //var groupedEmp = employees.GroupBy(d => d.Department);
            //Console.WriteLine("Grouped employees by department");
            //foreach (var group in groupedEmp)
            //{
            //    Console.WriteLine($"{group.Key} >> Count: {group.Count()}, Avg: {group.Average(e => e.Salary):N0}");
            //}

            //// 2. Find the department with the highest total salary budget
            //var highSalEmp = groupedEmp.OrderByDescending(e => e.Sum(emp => emp.Salary))
            //                           .First();

            //Console.WriteLine();
            //// 3. List employees in each group ordered by Salary descending
            //Console.WriteLine("Employees in each department (by Salary descending):");
            //foreach (var group in groupedEmp)
            //{
            //    Console.WriteLine($"{group.Key}:");
            //    foreach (var emp in group.OrderByDescending(e => e.Salary))
            //    {
            //        Console.WriteLine($" {emp.Name} ({emp.Salary:N0})");
            //    }
            //}

            #endregion


            #region Q9
            // Q: What is printed? Why?
            //The Where query uses deferred execution, meaning it does not run when defined.
            //The query only executes when you iterate over it(foreach).
            //After defining the query, we add 10 to nums, so the query now sees[1, 2, 3, 4, 5, 10].
            //Applying the condition n > 2 on this list returns 3, 4, 5, 10.

            // Q: How would using .ToList() right after .Where(...) change the result?
            //ToList() immediate execution, so the query runs at that moment.
            //The results are copied into a new list, so later changes to nums(like adding 20) do not affect the query.

            // Q: Name 3 LINQ operators that trigger immediate execution.
            //any aggregation operator(sum,max) - ToLost()  - ToArray() 
            #endregion


             #region Q10
            //List<string> words = ["apple", "fig", "banana", "kiwi", "grape", "mango", "pear", "plum"];

            //// 1. Filter words longer than 4 characters
            //var wordLong = words.Where(w => w.Length > 4);
            //Console.WriteLine("Words longer than 4 chars: " + string.Join(", ", wordLong));

           //// 2. Filter words at even indexes (0, 2, 4, 6...) using (item, index) overload
           //var evenIndexWord = words.Where ((w, index) => index % 2 == 0);
           //Console.WriteLine("Words at even indexes: " + string.Join(", ", evenIndexWord));

           //// 3. Filter words that are BOTH longer than 4 chars AND at an even index
           //var word = words.Where((w, index) => w.Length > 4 && index % 2 == 0);
           //Console.WriteLine("Words longer than 4 chars AND at even index: " + string.Join(", ", word));

           //// 4. What is the index of "mango" in the filtered result from step 1?
           //var listLongerThan4 = wordLong.ToList();
           //int mangoIndex = listLongerThan4.IndexOf("mango");
           //Console.WriteLine("Index of 'mango' in step 1 result: " + mangoIndex);

           #endregion


           #region Q11
           List<Course> courses = new List<Course>
           {
           new("C# Basics", new List<string> { "Ali", "Sara", "Omar" }),
           new("LINQ Mastery", new List<string> { "Sara", "Mona", "Ali" }),
           new("ASP.NET Core", new List<string> { "Yara", "Omar", "Karim" }),
           };

           //// 1. Flatten to a single list of ALL student names (with duplicates)
           //var allStudents = courses.SelectMany(c => c.Students);
           //Console.WriteLine("\nAll student names (with duplicates): " + string.Join(", ", allStudents));

           //// 2. Get a distinct list of all student names
           //var distinctStudents = allStudents.Distinct();
           //Console.WriteLine("\nDistinct student names: " + string.Join(", ", distinctStudents));

          //// 3. Find students who appear in MORE THAN ONE course
          //var duplicates = allStudents.GroupBy(s => s)
          //                            .Where(g => g.Count() > 1)
          //                            .Select(g => g.Key);
          //Console.WriteLine("\nStudents in more than one course: " + string.Join(", ", duplicates));

         //// 4. Use SelectMany with result selector to get (CourseName, StudentName) pairs
         //var courseStudentPairs = courses.SelectMany(c => c.Students,(course, student) => new 
         //                       { 
         //                          CourseName = course.Title, StudentName = student 
         //                       });

         //Console.WriteLine("\nCourseName - StudentName pairs:");
         //foreach (var pair in courseStudentPairs)
        //{
        //    Console.WriteLine($"{pair.CourseName} - {pair.StudentName}");
        //} 
        #endregion


#region Q12
 ////1.From employees: get the TOP 2 highest - paid employees per department.
 //var top2PerDept = employees.GroupBy(e => e.Department)                                   // Deferred
 //                           .SelectMany(g => g.OrderByDescending(e => e.Salary).Take(2)); // Deferred until iterated

 //Console.WriteLine("Top 2 highest-paid employees per department:");
 //foreach (var emp in top2PerDept)
 //{
 //    Console.WriteLine($"{emp.Name} ({emp.Department}) - {emp.Salary}");
 //}


 ////2.From courses: build a Dictionary<string, int> of{ CourseName → StudentCount }, but only for courses with > 2 students.
 //var courseDict = courses.Where(c => c.Students.Count > 2)                      // Deferred
 //                        .ToDictionary(c => c.Title, c => c.Students.Count);    // Immediate execution

 //Console.WriteLine("\nCourse dictionary (more than 2 students):");
 //foreach (var kv in courseDict)
 //{
 //    Console.WriteLine($"{kv.Key} >> {kv.Value} students");
 //}


 ////3.Check:
 ////        Does ANY employee in Engineering earn less than 8000 ?
 //bool anyEngineeringBelow8k = employees.Where(e => e.Department == "Engineering")
 //                                      .Any(e => e.Salary < 8000);                 // Immediate execution

 ////        Do ALL HR employees earn more than 5500 ?
 //bool allHREmployeesAbove5_5k = employees.Where(e => e.Department == "HR")
 //                                        .All(e => e.Salary > 5500);                // Immediate execution

 //Console.WriteLine($"\nAny Engineering employee < 8000? {anyEngineeringBelow8k}");
 //Console.WriteLine($"All HR employees > 5500? {allHREmployeesAbove5_5k}");

 ////4.Project the top - 2 - per - dept result into:
 ////  { Rank, Name, Department, Salary, SeniorityLevel }
 ////  where Rank resets per department(use indexed Select per group).
 //var top2WithRank = employees.GroupBy(e => e.Department)          //Deferred execution until iterated
 //                            .SelectMany(g => g
 //                            .OrderByDescending(e => e.Salary)
 //                            .Select((emp, index) => new
 //                            {
 //                              Rank = index + 1,
 //                              emp.Name,
 //                              emp.Department,
 //                              emp.Salary,
 //                              SeniorityLevel = emp.Salary >= 9000 ? "Senior" :
 //                              emp.Salary >= 7000 ? "Mid" : "Junior"
 //                            }).Take(2));                           // Deferred until iteration

 //Console.WriteLine("\nTop 2 per department with rank and seniority:");
 //foreach (var emp in top2WithRank)
 //{
 //    Console.WriteLine($"{emp.Rank}. {emp.Name} ({emp.Department}) - {emp.Salary} - {emp.SeniorityLevel}");
 //}

 #endregion






        }
    }
}

