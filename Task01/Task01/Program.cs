using System.Runtime.InteropServices;

namespace Task01
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            #region Problem 
            //// 1
            //string ver = Environment.Version.ToString();
            ////   string os = Environment.OSVersion.ToString();
            //string os = RuntimeInformation.OSDescription;
            //string cpu = RuntimeInformation.ProcessArchitecture.ToString();


            //Display("Runtime Environment Analyzer:");
            //Display($"Runtime version =>  {ver}");
            //Display($"Operating System =>  {os}");
            //Display($"CPU Architecture =>  {cpu}");


            //// 2
            ////requirment(switch expression)
            //string result = ver switch
            //{
            //    string r when r.Contains("5") || r.Contains("6") || r.Contains("7") || r.Contains("8") || r.Contains("9")
            //        => "Modern .NET Runtime",
            //    _ => "Legacy Runtime"
            //};

            //Display($"Result =>  {result}");


            ////traditional way
            ////string result;

            ////if (ver.Contains("5") || ver.Contains("6") || ver.Contains("7") || ver.Contains("8") || ver.Contains("9"))                
            ////    result = "Modern .NET Runtime";

            ////else           
            ////    result = "Legacy Runtime";

            ////Display($"Result =>  {result}"); 
            #endregion


            #region Problem 
            //if (LoginEnabled && AppVersion >= LoginMinVersion)
            //    Console.WriteLine("Login feature is AVAILABLE");
            //else
            //    Console.WriteLine("Login feature is NOT available");


            //string exportStatus = (ExportEnabled && AppVersion >= ExportMinVersion) ? "Export feature is AVAILABLE" : "Export feature is NOT available";
            //Console.WriteLine(exportStatus);


            //string adminStatus = (AdminEnabled && AppVersion >= AdminMinVersion) ? "AdminPanel feature is AVAILABLE" : "AdminPanel feature is NOT available";
            //Console.WriteLine(adminStatus); 
            #endregion


            #region Problem 
            //List<int> numbers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9,10 };
            //Numbers(numbers);

            #endregion


            #region Problem 
            //User user = new User { Name = "Ahmed" };

            //UserSnapshot snapshot = new UserSnapshot { Name = "Ahmed" };

            //Console.WriteLine("Normal Call >>>");
            //Modify(user, snapshot);
            //Console.WriteLine($"User: {user.Name}");
            //Console.WriteLine($"Snapshot: {snapshot.Name}");

            //Console.WriteLine("\nRef Call >>>");
            //ModifyRef(ref user, ref snapshot);
            //Console.WriteLine($"User: {user.Name}");
            //Console.WriteLine($"Snapshot: {snapshot.Name}");

            //static void Modify(User u, UserSnapshot s)
            //{
            //    u.Name = "Mohamed";
            //    s.Name = "Mohamed";
            //}


            //static void ModifyRef(ref User u, ref UserSnapshot s)
            //{
            //    u.Name = "Menna";
            //    s.Name = "Menna";
            //}

            #endregion


            #region Problem
            //string[] strs1 = { "flower", "flow", "flight" };
            //Console.WriteLine(LongestPrefix(strs1)); 

            //string[] strs2 = { "dog", "racecar", "car" };
            //Console.WriteLine(LongestPrefix(strs2));   
            #endregion


            #region Problem
            //int[] nums1 = { 1, 2, 3, 1 };
            //Console.WriteLine(ContainsDuplicate(nums1));

            //int[] nums2 = { 1, 2, 3, 4 };
            //Console.WriteLine(ContainsDuplicate(nums2));

            //int[] nums3 = { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };
            //Console.WriteLine(ContainsDuplicate(nums3)); 
            #endregion


            #region Problem
            //string s1 = "anagram";
            //string t1 = "nagaram";
            //Console.WriteLine(IsAnagram(s1, t1));

            //string s2 = "rat";
            //string t2 = "car";
            //Console.WriteLine(IsAnagram(s2, t2));

            #endregion


        }

        //related by problem 1
        //static void Display(string msg)
        //{
        //    Console.WriteLine(msg);
        //}


        //related by problem 2

        //const double AppVersion = 2;

        //static readonly bool LoginEnabled = true;
        //static readonly bool ExportEnabled = false;
        //static readonly bool AdminEnabled = true;

        //const double LoginMinVersion = 1.0;
        //const double ExportMinVersion = 1.5;
        //const double AdminMinVersion = 2.3;




        //related Problem 3

        //static void Numbers(List<int> numbers)
        //{
        //    List<int> evens = new List<int>();
        //    List<int> odds = new List<int>();
        //    List<int> primes = new List<int>();

        //    foreach (var n in numbers)
        //    {
        //        if (IsEven(n))
        //            evens.Add(n);
        //        else
        //            odds.Add(n);

        //        if (IsPrime(n)) primes.Add(n);
        //    }

        //    Console.WriteLine("Even Numbers: " + string.Join(", ", evens));
        //    Console.WriteLine("Odd Numbers: " + string.Join(", ", odds));
        //    Console.WriteLine("Prime Numbers: " + string.Join(", ", primes));
        //}

        //static bool IsEven(int n) => n % 2 == 0;

        //static bool IsOdd(int n) => n % 2 != 0;

        //static bool IsPrime(int n)
        //{
        //    if (n < 2) return false;
        //    for (int i = 2; i * i <= n; i++)
        //        if (n % i == 0) return false;
        //    return true;
        //} 




        //related problem 4

        //class User
        //{
        //    public string Name;
        //}


        //struct UserSnapshot
        //{
        //    public string Name;
        //}

        //Class = Reference Type - يخزن في heap → التغيير يحصل على النسخة الأصلية

        //Struct = Value Type → التغيير ميحصلش إلا لو استخدمنا ref - يخزن في stack




        //related by problem 6

        //static string LongestPrefix(string[] strs)
        //{
        //    if (strs == null || strs.Length == 0) return "";

        //    string first = strs[0];
        //    int prefixLength = first.Length;

        //    for (int i = 1; i < strs.Length; i++)
        //    {
        //        int j = 0;
        //        while (j < prefixLength && j < strs[i].Length && first[j] == strs[i][j])
        //        {
        //            j++;
        //        }

        //        prefixLength = j;

        //        if (prefixLength == 0) return "";
        //    }

        //    return first.Substring(0, prefixLength);
        //}



        //related by problem 7
        //static bool ContainsDuplicate(int[] nums)
        //{
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        for (int j = i + 1; j < nums.Length; j++)
        //        {
        //            if (nums[i] == nums[j])
        //                return true; 
        //        }
        //    }
        //    return false; 
        //}


        //related by problem 8
        //static bool IsAnagram(string s, string t)
        //{
        //    if (s.Length != t.Length) return false; 

        //    char[] arrS = s.ToCharArray();
        //    char[] arrT = t.ToCharArray();

        //    Array.Sort(arrS);
        //    Array.Sort(arrT);

        //    for (int i = 0; i < arrS.Length; i++)
        //    {
        //        if (arrS[i] != arrT[i])
        //            return false; 
        //    }

        //    return true; 
        //}


    }
}



