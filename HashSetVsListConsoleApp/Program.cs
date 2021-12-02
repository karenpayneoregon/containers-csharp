using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace HashSetVsListConsoleApp
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Working . . .");
            StringBuilder builder = new();

            int times = 10000000;


            for (int listSize = 1; listSize < 10; listSize++)
            {
                Console.Write($"{listSize,-2}");
                List<string> list = new();
                HashSet<string> hashset = new();

                for (int index = 0; index < listSize; index++)
                {
                    list.Add("string" + index.ToString());
                    hashset.Add("string" + index.ToString());
                }

                Stopwatch timer = new();
                timer.Start();

                for (int index = 0; index < times; index++)
                {
                    list.Remove("string0");
                    list.Add("string0");
                }

                timer.Stop();
                builder.AppendLine($" item LIST strings time: {timer.ElapsedMilliseconds} ms");
                
                timer = new Stopwatch();
                timer.Start();

                for (int index = 0; index < times; index++)
                {
                    hashset.Remove("string0");
                    hashset.Add("string0");
                }

                timer.Stop();
                
                builder.AppendLine($"{listSize} item HASHSET strings time: {timer.ElapsedMilliseconds} ms");
                builder.AppendLine("");

            }

            Console.Write("Working . . .");

            for (int listSize = 1; listSize < 50; listSize += 3)
            {

                Console.Write($"{listSize,-3}");

                List<object> list = new();
                HashSet<object> hashset = new();

                for (int index = 0; index < listSize; index++)
                {
                    list.Add(new object());
                    hashset.Add(new object());
                }

                object objToAddRem = list[0];

                Stopwatch timer = new();
                timer.Start();

                for (int index = 0; index < times; index++)
                {
                    list.Remove(objToAddRem);
                    list.Add(objToAddRem);
                }

                timer.Stop();
                builder.AppendLine($"{listSize} item LIST objects time: {timer.ElapsedMilliseconds} ms");
                
                timer = new Stopwatch();
                timer.Start();

                for (int index = 0; index < times; index++)
                {
                    hashset.Remove(objToAddRem);
                    hashset.Add(objToAddRem);
                }

                timer.Stop();

                builder.AppendLine( $"{listSize} item HASHSET objects time: {timer.ElapsedMilliseconds} ms");
                builder.AppendLine("");
            }

            Debug.WriteLine(builder);

        }
        [ModuleInitializer]
        public static void Init1()
        {
            Console.Title = "List vs HashSet";
        }

    }
}
