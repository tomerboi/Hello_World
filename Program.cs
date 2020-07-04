using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace HelloWorld
{
    static class Program
    {
        public static string imgPath = "C:\\Tomer PC\\photos";
        public static string imgNewPath = "C:\\Tomer PC\\photos\\newphotos";
        public static string imgNewPathForThread = "C:\\Tomer PC\\photos\\newphotosthread";
        public static Dictionary<int, int> levels = new Dictionary<int, int>();
        static void Main(string[] args)
        {
            Name ssa = new Name("Tomer", "Boiman");
            var trs = ssa.GetFullName();
            var ds = Simplified("4/6");
            var ad = IsPalindronOrDescendent(97358817);
            string k = ReverseAndNot(123);
            Call cv = new Call();
            myDel m = new myDel((int a) => { return a + 100; });
            cv.AddNum(m, 5);
            int a;
            SomeFunc(out a);
            var ee = IsPalindrom(10901);
            var hh = 98697697 % 10;
            var kl = 98697697 / 10;
            CallCenter v = new CallCenter();
            var b = new Call();

            int fr = b.AddNum(m, 1);
            Bfunc(b);
            // int a = 10;
            Afunc(ref a);
            List<int> myList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (var item in func(2, 10))
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public static string Simplified(string s){
            int dividor = GetDividor(s);
            int a = int.Parse(s.Substring(0, s.IndexOf('/')));
            int b = int.Parse(s.Substring(s.IndexOf('/') + 1));

            if(dividor == 1)
                return s;
            else{
                while((a % dividor) == 0 && (b % dividor) == 0){
                    a /= dividor;
                    b /= dividor;
                }

                if(a % b == 0){
                    return (a/b).ToString();
                }
            }

            return a.ToString() + '/' + b.ToString();
        }

        private static int GetDividor(string s)
        {
            int a = int.Parse(s.Substring(0, s.IndexOf('/')));
            int b = int.Parse(s.Substring(s.IndexOf('/') + 1));

            int c = a < b ? a : b;
            while(c != 1){
                if(a % c == 0 && b % c == 0){
                    return c;
                }
                c--;
            }
            if((a % 2) == 0 && (b % 2) == 0){
                return 2;
            }

            return 1;
        }

        public static bool IsPalindronOrDescendent(int a)
        {
            if (IsPalindrom(a))
                return true;
            if(a < 100)
                return false;
            
            return IsPalindronOrDescendent(GetDecendent(a, "", 0));
        }

        public static int GetDecendent(int a, string h, int numOfZeros){
            if(a < 10){
                if(a == 0)
                    return Int32.Parse(h);
                return Int32.Parse(h + a.ToString());
            }
            string d = a.ToString();
            while(numOfZeros > 0){
                d = '0' + d;
                numOfZeros--;
            }
            int largest = Int32.Parse(d[0].ToString());
            int second = Int32.Parse(d[1].ToString());
            int tot = largest + second;
            h += tot.ToString();
            int i = 2;
            int j = 0;
            while(i < d.Length && d[i] == '0'){
                i++;
                j++;
            }

            return GetDecendent(Int32.TryParse(d.Substring(2), out int val) ? val : 0, h, j);
        }

        public static string ReverseAndNot(int i)
        {
            return new string(i.ToString().ToCharArray().Reverse().Concat(i.ToString().ToCharArray()).ToArray());
        }
        public static void SomeFunc(out int a)
        {
            a = 2;
        }
        public static bool IsPalindrom(int num)
        {
            int r, nu = 0, dem;
            dem = num;
            while (num > 0)
            {
                r = num % 10;
                nu = (nu * 10) + r;
                num = num / 10;
            }
            if (dem == nu)
                return true;
            else
                return false;
        }
        public static void Bfunc(Call a)
        {
            a.Tier = Tier.Tier3;
        }
        public static void Afunc(ref int a)
        {
            a++;
        }

        public static IEnumerable func(int a, int b)
        {
            for (int i = 0; i < b; i++)
            {
                yield return a + 2 * i;
            }
        }
        public static void ParallelForeach<T>(IEnumerable<T> list, Func<T, bool> func)
        {
            foreach (var item in list)
            {
                ThreadPool.QueueUserWorkItem((object o) => func(item));
            }
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> list, Func<T, bool> func)
        {
            foreach (var item in list)
            {
                if (func(item))
                    yield return item;
            }
        }

        /*   public static int solution(int[] A)
           {
               // write your code in C# 6.0 with .NET 4.5 (Mono)
               HashSet<int> myHash = new HashSet<int>();
               for(int i = 0; i < A.Length; i++){
                   if(myHash.Contains(A[i]))
                   {
                       myHash.Remove(A[i]);
                   }
                   else{
                       myHash.Add(A[i]);
                   }
               }

               return myHash.First();
           }*/
        public static int FindLongestSubstringWithoutDup(string a)
        {
            Dictionary<char, int> charIndex = new Dictionary<char, int>();
            int maxCounter = 0;
            int tmpCounter = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (!charIndex.ContainsKey(a[i]))
                {
                    charIndex.Add(a[i], i);
                    tmpCounter++;
                    if (tmpCounter > maxCounter)
                    {
                        maxCounter = tmpCounter;
                    }
                }
                else
                {
                    int location = charIndex[a[i]];
                    tmpCounter = i - location + 1;
                    charIndex[a[i]] = i;
                }
            }

            return maxCounter;
        }
        public static void FindAllInLevel(int level, Node n)
        {
            if (levels.ContainsKey(level))
            {
                levels[level]++;
            }
            else
            {
                levels.Add(level, 1);
            }

            foreach (Node node in n.Neighbours)
            {
                FindAllInLevel(level + 1, node);
            }
        }
        public static void DoWorkThread(object item, string a, int b)
        {
            string path = item as string;
            var byteArr = ConvertFileToByteArray(path);
            WriteImage(byteArr, imgNewPathForThread + path.Substring(path.LastIndexOf('\\')));
        }

        public static void DoWork(object item, string a, int b)
        {
            string path = item as string;
            var byteArr = ConvertFileToByteArray(path);
            WriteImage(byteArr, imgNewPath + path.Substring(path.LastIndexOf('\\')));
        }
        public static List<string> GetAllImagesFromPath(string path)
        {
            return Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly)
                .ToList();
        }

        public static byte[] ConvertFileToByteArray(string fileName)
        {
            return File.ReadAllBytes(fileName);
        }

        public static void WriteImage(byte[] image, string path)
        {
            MemoryStream ms = new MemoryStream(image);
            Image im = Image.FromStream(ms);
            im.Save(path);
        }
    }
}
