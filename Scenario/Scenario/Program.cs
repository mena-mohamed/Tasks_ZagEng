namespace Scenario
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var employees = EmployeeRepository.GetEmployees();
            // (Data Sorting)
            // order by in both query syntax and fluent syntax
            // Then By
            //var orderedEmployees = employees.OrderBy(x => x.FirstName.Length)
            //                                    .ThenBy(x => x.Id)
            //                                .Select(x => new { FullName = x.FirstName + ' ' + x.LastName });

            //var orderedEmployeesQ = from employee in employees  
            //                        orderby employee.FirstName.Length, employee.Id descending  
            //                        select employee.FirstName + ' ' + employee.LastName;  

            //EmployeeRepository.Print("Print Sorted Employees by firdt name length", orderedEmployeesQ);  






            // (Data Partioning)  
            // skip - skip while - skipLast  
            // take - take while - takeLast  
            // chnuc   

            //var partition0 = employees.SkipWhile(emp => emp.Skills.Count < 3);  
            //EmployeeRepository.Print($"Print from employee num #1 to emmployee {employees.Count - 10}", partition0);  

            //var partition1 = employees.TakeLast(10);  
            //EmployeeRepository.Print($"Print lat 10 elemnts", partition1);  


            //var partition2 = employees.Chunk(10).ToList();  
            //for(int i = 0; i < partition2.Count; i++)  
            //{  
            //    EmployeeRepository.Print($"Chunck number {i + 1}", partition2[i]);  
            //    Console.WriteLine("====================================================");  
            //}  


            // pagination logic // page size = 50/5 = 10 seceond page = 6-10  

            //var page2 = employees.Paginate(page: 2, size: 5);  

            //EmployeeRepository.Print("Page 2", page2);  


            // (Quantifiers)  
            // any - all - contain  

            //var isEmployeeExist = Employee.IsExist(employees);  
            //Console.WriteLine(isEmployeeExist);  


            //var groupByDepartment = employees.GroupBy(e => e.Department)  
            //                        .            Select(g => new {   
            //                                         Department = g.Key,  
            //                                         TotalEmployees = g.Count()  
            //                                     });  

            //EmployeeRepository.Print($"Grouped Data", groupByDepartment);  

            //var groupByDepartmentQ = (from employee in employees  
            //                         group employee by employee.Department into deptGroup  
            //                         select new  
            //                         {  
            //                             Department = deptGroup.Key,  
            //                             TotalEmployees = deptGroup.Count()  
            //                         }).Distinct();  

            //EmployeeRepository.Print($"Grouped Data", groupByDepartmentQ);  



            // ================ Quiz Time =================  


            // Get all IT employees who know C# and return only their full name and skills
            var itEmployee = employees.Where(e => e.Department =="IT" && e.Skills.Contains("C#"))
                                      .Select(e => new
                                      {
                                          FullName = e.FirstName + " " + e.LastName,
                                          Skills = e.Skills
                                      });
            Console.WriteLine("IT Employees who knoe C# >> ");
            foreach (var emp in itEmployee)
            {
                Console.WriteLine(emp.FullName);
                Console.WriteLine("Skills: " + string.Join("," , emp.Skills));
                
            }

            Console.WriteLine();
            Console.WriteLine();    


            //List employees grouped by department, showing department name and number of employees in each
            var groupDept = employees.GroupBy(e => e.Department)
                                     .Select(d => new
                                     {
                                         Department = d.Key, 
                                         Count = d.Count()
                                     });
            Console.WriteLine("Employee in Department >>");
            foreach (var dept in groupDept)
            {
                Console.WriteLine($" {dept.Department}: {dept.Count} employees");
            }

            Console.WriteLine();
            Console.WriteLine();


            // Get all unique skills across all employees  
            var uniqSkills = employees.SelectMany(e => e.Skills)
                                      .Distinct()
                                      .OrderBy(s => s);
            Console.WriteLine("Unique Skills >> ");
            foreach(var skill in uniqSkills)
            {
                Console.Write(skill);
                Console.Write("   ,   ");
            }


        }
    }
}
