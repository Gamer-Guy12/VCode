using System;
using System.IO;

namespace Language
{
    class Program
    {
        static void Main(string[] args)
        {

            Program program = new Program();
            if (args.Length != 0) program.Start(args[0]);
            else program.Start(null);

        }

        void Start(string arg)
        {
            string[] write = null;
            if (arg != null)
            {

                write = File.ReadAllLines(arg);

                foreach (string code in write)
                {

                    Code(code, false);

                }

            }
            else
            {

                string code = Console.ReadLine();
                Code(code, true);

            }   

        }

        void Code(string code, bool repeat)
        {

            string[] split = code.Split(' ');
            if (split[0] == "print")
            {

                string writable = null;

                for (int i = 1; i < split.Length; i++)
                {

                    if (split[i] != null)
                    {

                        if (writable != null)
                            writable = writable + " " + split[i];
                        else
                            writable = split[i];

                    }

                }
                Console.WriteLine(writable);
                if (repeat)
                {

                    string write = Console.ReadLine();
                    Code(write, true);

                }

            }
            else if (split[0] == "read")
            {

                Console.ReadLine();
                if (repeat)
                {

                    string write = Console.ReadLine();
                    Code(write, true);

                }

            }
            else if (repeat && split[0] == "exit")
            {

                Exit();

            }
            else if (split [0] == "look")
            {

                string drive = split[1];
                string path = @"C:\";
                path = path.Replace("C", drive);
                for (int i = 2; i < split.Length; i++)
                {

                    if (path == null) path = split[i] + " ";
                    else path = path + split[i] + " ";

                }


                string[] look = null;

                look = File.ReadAllLines(path);

                foreach (string text in look)
                {

                    Console.WriteLine(text);

                }
                string write = Console.ReadLine();
                Code(write, true);

            }
            else
            {

                Console.WriteLine("No known code");
                if (repeat)
                {

                    string write = Console.ReadLine();
                    Code(write, true);

                }

            }

            

        }

        void Exit()
        {

            Console.ReadKey();

        }

    }
}
