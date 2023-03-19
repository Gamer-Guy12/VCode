using System;
using System.IO;
using System.Collections.Generic;

namespace Language
{
    class Program
    {

        public Dictionary<string, string[]> funcs = new Dictionary<string, string[]>();
        public Dictionary<string, string> strings = new Dictionary<string, string>();
        public Dictionary<string, float> floats = new Dictionary<string, float>();
        public Dictionary<string, Keyword> keywords = new Dictionary<string, Keyword>();

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

            string[] split = new string[1212345];

            if (code == null) return;

            split = code.Split(' ');
            if (split[0] == "print")
            {

                string writable = null;

                if (split[1] == "$")
                {

                    Console.WriteLine(strings[split[2]]);

                }
                else if (split[1] == "#")
                {

                    Console.WriteLine(floats[split[2]].ToString());

                }
                else
                {

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

                }

                if (repeat)
                {

                    string write = Console.ReadLine();
                    Code(write, true);

                }

            }
            else if (split[0] == "read")
            {

                if (split[1] == "$")
                {

                    strings[split[2]] = Console.ReadLine();

                }
                else if (split[1] == "#")
                {

                    string num = Console.ReadLine();
                    floats[split[2]] = float.Parse(num);

                }
                else
                {

                    Console.ReadLine();

                }
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
            else if (split[0] == "look")
            {

                string drive = split[1];
                string path = @"C:\";
                path = path.Replace("C", drive);
                if (split[2] == "$") path = path + strings[split[3]] + " ";
                else
                {
                    for (int i = 2; i < split.Length; i++)
                    {

                        if (path == null) path = split[i] + " ";
                        else path = path + split[i] + " ";

                    }
                }

                string[] look = null;

                look = File.ReadAllLines(path);

                foreach (string text in look)
                {

                    Console.WriteLine(text);

                }

                if (repeat)
                {

                    string write = Console.ReadLine();
                    Code(write, true);

                }

            }
            else if (split[0] == "write")
            {

                string drive = split[1];
                string path = @"C:\";
                path = path.Replace("C", drive);
                if (split[2] == "$") path = path + strings[split[3]] + " ";
                else
                {
                    for (int i = 2; i < split.Length; i++)
                    {

                        if (path == null) path = split[i] + " ";
                        else path = path + split[i] + " ";

                    }
                }

                while (true)
                {

                    string write = Console.ReadLine();
                    if (write != null && write != "`")
                    {

                        File.AppendAllText(path, "\n" + write);

                    }


                    if (write == "`") break;

                }

                if (repeat)
                {

                    string write = Console.ReadLine();
                    Code(write, true);

                }

            }
            else if (split[0] == "func")
            {

                string[] toWrite = new string[1000];
                int id = 0;
                while (true)
                {

                    string writeable = Console.ReadLine();
                    if (writeable == "`") break;
                    else
                    {

                        toWrite[id] = writeable;
                        id = id + 1;

                    }

                }

                funcs.Add(split[1], toWrite);

                if (repeat)
                {

                    string write = Console.ReadLine();
                    Code(write, true);

                }

            }
            else if (split[0] == "run")
            {

                if (!funcs.ContainsKey(split[1]))
                {

                    Console.WriteLine("No known function");
                    if (repeat)
                    {

                        string write = Console.ReadLine();
                        Code(write, true);

                    }

                }

                string[] toWrite = funcs[split[1]];

                foreach (string writable in toWrite)
                {

                    if (writable == "`") break;
                    Code(writable, false);

                }

                if (repeat)
                {

                    string write = Console.ReadLine();
                    Code(write, true);

                }

            }
            else if (split[0] == "$")
            {

                string toWrite = null;

                if (strings.ContainsKey(split[1]))
                {

                    for (int i = 2; i < split.Length; i++)
                    {

                        if (split[i] != null)
                        {

                            if (toWrite != null)
                                toWrite = toWrite + " " + split[i];
                            else
                                toWrite = split[i];

                        }

                    }

                    strings[split[1]] = toWrite;
                    if (repeat)
                    {

                        string write = Console.ReadLine();
                        Code(write, true);

                    }
                    return;

                }

                for (int i = 2; i < split.Length; i++)
                {

                    if (split[i] != null)
                    {

                        if (toWrite != null)
                            toWrite = toWrite + " " + split[i];
                        else
                            toWrite = split[i];

                    }

                }

                strings.Add(split[1], toWrite);

                if (repeat)
                {

                    string write = Console.ReadLine();
                    Code(write, true);

                }

            }
            else if (split[0] == "#")
            {

                string num = split[2];
                float index = float.Parse(num);

                if (floats.ContainsKey(split[1]))
                {

                    floats[split[1]] = index;
                    if (repeat)
                    {

                        string write = Console.ReadLine();
                        Code(write, true);

                    }
                    return;

                }

                floats.Add(split[1], index);

                if (repeat)
                {

                    string write = Console.ReadLine();
                    Code(write, true);

                }

            }
            else if (split[0] == "")
            {

                if (repeat)
                {

                    string write = Console.ReadLine();
                    Code(write, true);

                }

            }
            else if (split[0] == "import")
            {

                string drive = split[2];
                string path = @"C:\";
                path = path.Replace("C", drive);
                if (split[3] == "$") path = path + strings[split[4]] + " ";
                else if (split[3] == "*")
                {

                    path = null;
                    for (int i = 3; i < split.Length; i++)
                    {

                        if (path == null) path = split[i] + " ";
                        else path = path + split[i] + " ";

                    }

                }
                else
                {
                    for (int i = 3; i < split.Length; i++)
                    {

                        if (path == null) path = split[i] + " ";
                        else path = path + split[i] + " ";

                    }
                }

                string[] import = File.ReadAllLines(path);

                bool inFunc = false;
                string[] func = new string[100];
                string[] defFunc = new string[200];
                int defId = 0;
                string funcName = "";
                int id = 0;

                foreach (string funcText in import)
                {

                    string[] text = funcText.Split(" ");
                    if (text[0] == "func")
                    {

                        inFunc = true;
                        funcName = text[1];
                        id = 0;

                    }
                    else if (text[0] == "`")
                    {

                        inFunc = false;
                        funcs.Add(funcName, func);
                        func = new string[100];
                        id = 0;

                    }
                    else if (text[0] == "import")
                    {

                        Code(funcText, false);

                    }
                    else if (inFunc)
                    {

                        func[id] = funcText;
                        id = id + 1;

                    }
                    else
                    {

                        defFunc[defId] = funcText;
                        defId++;

                    }

                }

                if (defFunc[0] != "")
                {

                    funcs.Add(split[1], defFunc);

                }

                if (repeat)
                {

                    string write = Console.ReadLine();
                    Code(write, true);

                }

            }
            else if (split[0] == "funcs")
            {

                List<string> func = new List<string>(funcs.Keys);
                foreach (string key in func)
                {

                    Console.WriteLine(key);

                }

                if (repeat)
                {

                    string write = Console.ReadLine();
                    Code(write, true);

                }

            }
            else if (split[0] == "null")
            {

                if (repeat)
                {

                    string write = Console.ReadLine();
                    Code(write, true);

                }

            }
            else if (split[0] == "add$")
            {

                string add = "";

                for (int i = 2; i < split.Length; i++)
                {

                    if (split[i] != null)
                    {

                        if (add != null)
                            add = add + " " + split[i];
                        else
                            add = split[i];

                    }

                }

                string output = strings[split[1]] + add;

                strings[split[1]] = output;

            }
            else if (split[0] == "push$")
            {

                strings[split[1]] = strings[split[3]];

            }
            else if (split[0] == "add#")
            {

                float add = floats[split[2]];

                float output = floats[split[1]] + add;

                floats[split[1]] = output;

            }
            else if (split[0] == "push#")
            {

                floats[split[1]] = floats[split[3]];

            }
            else if (split[0] == "mult")
            {

                floats[split[1]] *= floats[split[2]];

            }
            else if (split[0] == "key")
            {

                string drive = split[2];
                string path = @"C:\";
                path = path.Replace("C", drive);
                if (split[3] == "$") path = path + strings[split[4]] + " ";
                else if (split[3] == "*")
                {

                    path = null;
                    for (int i = 3; i < split.Length; i++)
                    {

                        if (path == null) path = split[i] + " ";
                        else path = path + split[i] + " ";

                    }

                }
                else
                {
                    for (int i = 3; i < split.Length; i++)
                    {

                        if (path == null) path = split[i] + " ";
                        else path = path + split[i] + " ";

                    }
                }

                string[] lines = File.ReadAllLines(path);
                Keyword key = new Keyword();

                bool inFunc = false;
                string funcName = "";
                string[] funcText = new string[100];
                int id = 0;

                foreach (string line in lines)
                {

                    string[] text = line.Split(" ");
                    
                    if (text[0] == "func")
                    {

                        inFunc = true;
                        funcName = text[1];
                        id = 0;

                    }
                    else if (inFunc && text[0] == "`")
                    {

                        inFunc = false;
                        key.funcs.Add(funcName, funcText);
                        funcName = "";
                        id = 0;

                    }
                    else if (inFunc)
                    {

                        funcText[id] = line;
                        id++;

                    }
                    else if (text[0] == "$")
                    {

                        string toWrite = null;

                        if (key.strings.ContainsKey(split[1]))
                        {

                            for (int i = 2; i < split.Length; i++)
                            {

                                if (split[i] != null)
                                {

                                    if (toWrite != null)
                                        toWrite = toWrite + " " + split[i];
                                    else
                                        toWrite = split[i];

                                }

                            }

                            key.strings[split[1]] = toWrite;

                        }
                        else
                        {

                            for (int i = 2; i < split.Length; i++)
                            {

                                if (split[i] != null)
                                {

                                    if (toWrite != null)
                                        toWrite = toWrite + " " + split[i];
                                    else
                                        toWrite = split[i];

                                }

                            }

                            key.strings.Add(split[1], toWrite);

                        }

                    }
                    else if (text[0] == "#")
                    {

                        string num = split[2];
                        float index = float.Parse(num);

                        if (key.floats.ContainsKey(split[1]))
                        {

                            key.floats[split[1]] = index;

                        }
                        else
                        {

                            key.floats.Add(split[1], index);

                        }

                    }
                    else if (text[0] == "key")
                    {

                        string newdrive = split[2];
                        string newpath = @"C:\";
                        newpath = newpath.Replace("C", newdrive);
                        if (split[3] == "$") newpath = newpath + strings[split[4]] + " ";
                        else if (split[3] == "*")
                        {

                            newpath = null;
                            for (int i = 3; i < split.Length; i++)
                            {

                                if (newpath == null) newpath = split[i] + " ";
                                else newpath = newpath + split[i] + " ";

                            }

                        }
                        else
                        {
                            for (int i = 3; i < split.Length; i++)
                            {

                                if (newpath == null) newpath = split[i] + " ";
                                else newpath = newpath + split[i] + " ";

                            }
                        }

                        string[] newlines = File.ReadAllLines(newpath);
                        Keyword newkey = new Keyword();

                        bool newinFunc = false;
                        string newfuncName = "";
                        string[] newfuncText = new string[100];
                        int newid = 0;

                        foreach (string newline in newlines)
                        {

                            string[] newtext = newline.Split(" ");

                            if (newtext[0] == "func")
                            {

                                newinFunc = true;
                                newfuncName = newtext[1];
                                newid = 0;

                            }
                            else if (newinFunc && newtext[0] == "`")
                            {

                                newinFunc = false;
                                newkey.funcs.Add(newfuncName, newfuncText);
                                newfuncName = "";
                                newid = 0;

                            }
                            else if (newinFunc)
                            {

                                newfuncText[newid] = newline;
                                newid++;

                            }
                            else if (newtext[0] == "$")
                            {

                                string toWrite = null;

                                if (newkey.strings.ContainsKey(split[1]))
                                {

                                    for (int i = 2; i < split.Length; i++)
                                    {

                                        if (split[i] != null)
                                        {

                                            if (toWrite != null)
                                                toWrite = toWrite + " " + split[i];
                                            else
                                                toWrite = split[i];

                                        }

                                    }

                                    newkey.strings[split[1]] = toWrite;

                                }
                                else
                                {

                                    for (int i = 2; i < split.Length; i++)
                                    {

                                        if (split[i] != null)
                                        {

                                            if (toWrite != null)
                                                toWrite = toWrite + " " + split[i];
                                            else
                                                toWrite = split[i];

                                        }

                                    }

                                    newkey.strings.Add(split[1], toWrite);

                                }

                            }
                            else if (newtext[0] == "#")
                            {

                                string num = split[2];
                                float index = float.Parse(num);

                                if (newkey.floats.ContainsKey(split[1]))
                                {

                                    newkey.floats[split[1]] = index;

                                }
                                else
                                {

                                    newkey.floats.Add(split[1], index);

                                }

                            }
                            else if (newtext[0] == "key")
                            {



                            }

                        }

                    }
                    else if (text[0] == "import")
                    {



                    }

                }

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

            ConsoleKeyInfo state = Console.ReadKey();
            char finalState = state.KeyChar;

            if (finalState != 'n')
            {

                return;

            }
            else
            {

                string write = Console.ReadLine();
                Code(write, true);

            }

        }

    }
}
