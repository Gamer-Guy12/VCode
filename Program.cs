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

                write = File.ReadAllLines("@" + '"' + arg + '"');

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
                Start(null);

            }
            else if (split[0] == "read")
            {

                Console.ReadLine();
                Start(null);

            }
            else
            {

                Console.WriteLine("No known code");
                Start(null);

            }

            if (repeat)
            {

                string write = Console.ReadLine();
                Code(write, true);

            }

        }

    }
}
