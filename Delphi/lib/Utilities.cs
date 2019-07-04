using System;
using System.Collections.Generic;
using System.Linq;

using Datastructure;

namespace Utility
{
    public class Shell
    {

        // _D for descriptions
        static private string READ_D = "reads from file, without params it reads to the default file in config.txt, USAGE: read FILENAME; read";
        static private string SAVE_D = "saves into a file, without params it saves to the default file in config.txt, USAGE: save FILENAME; save";
        static private string ADD_D = "add a word(-w)/definition(-d)/novel/expression, not fully implemented, USAGE add -w WORD TYPE; add -w;\n   \tadd -d WORD DEFINITION";
        static private string CLEAR_D = "clear the screen";
        static private string EXIT_D = "exit from shell";
        static private string HELP_D = "show the commands and thier descriptions";
        static private string LIST_D = "list the words/expressions/novels; usage: list; list -w; list -e ; list -n, finish the typing with CTRL-E ";
        static private string REMOVE_D = "delete a word, an expression or a novel; usage: remove TITLE";
        static private string FIND_D = "finds a word, an expression or a novel; usage: find -w/-e/-n TITLE";
        static private string REMIND_D = "show the last seen words";

        // commands
        static private string READ = "read";
        static private string SAVE = "save";
        static private string ADD = "add";
        static private string CLEAR = "clear";
        static private string EXIT = "exit";
        static private string HELP = "help";
        static private string LIST = "list";
        static private string REMOVE = "remove";
        static private string FIND = "find";
        static private string REMIND = "remind";

        // heading
        static private string HEAD = "Delphi [Versione 0.0.0]";


        private DictManger dictManger = null;
        WordBuilder wrdBuilder = null;
        static private Dictionary<string, string> cmds;

        public Shell()
        {
            init();
            dictManger = DictManger.Manger();
            wrdBuilder = WordBuilder.wordBuilder();
        }

        // initing the dictionary of commands
        private void init()
        {
            cmds = new Dictionary<string, string>();
            // _D for description
            cmds[READ] = READ_D;
            cmds[SAVE] = SAVE_D;
            cmds[ADD] = ADD_D;
            cmds[CLEAR] = CLEAR_D;
            cmds[EXIT] = EXIT_D;
            cmds[HELP] = HELP_D;
            cmds[LIST] = LIST_D;
            cmds[REMOVE] = REMOVE_D;
            cmds[FIND] = FIND_D;
            cmds[REMIND] = REMIND_D;
        }

        public void Run()
        {
            string input = null;

            Console.WriteLine(HEAD);

            do
            {
                Console.Write(">");
                input = Console.ReadLine();
                Execute(input);
            } while (input != "exit");


        }


        public int Execute(string input)
        {
            
            if (input.All(x => x == ' ') || input == "")
            {
                return 0;
            }

            Object[] fields = CParser.Parse(input);

            string command = (string)fields[0];

            if (!cmds.Keys.Contains(command)) {
                Console.WriteLine("command not found");
                return -1;
            }

            List<string> flags = (List<string>)fields[1];
            List<string> paramss = (List<string>)fields[2];

            /* -------------------
             * READ command
             * -------------------*/
            if (command == READ)
            {
                if(paramss == null) { 
                    dictManger.read("../../input1.txt");
                }else if (paramss.Count == 1)
                    dictManger.read(paramss[0]);
                else
                {
                    Console.WriteLine("error: too many params");
                }

                return 0;
            }
            /* -------------------
             * SAVE command
             * -------------------*/
            if (command == SAVE)
            {
                if (paramss == null)
                {
                    dictManger.save("../../input1.txt");
                }
                else if (paramss.Count == 1)
                    dictManger.save(paramss[0]);
                else
                {
                    Console.WriteLine("error: too many params");
                }
                return 0;
            }

            /* -------------------
             * ADD command
             * -------------------*/
            if (command == ADD)
            {
                if(flags == null)
                {
                    Console.WriteLine("error: choose -w / -d");
                    return 0;
                }

                /* -------------------
                * ADD DEFINITION command
                * -------------------*/
                if (flags[0] == "-d")
                {
                    if (paramss == null || paramss.Count == 1)
                    {
                        Console.WriteLine("USAGE: add -w WORD DEFINITION");
                        return 0;
                    }

                    Word wrd = dictManger.CurDict().
                        findWord(paramss[0]);

                    if (wrd == null)
                    {
                        Console.WriteLine("Error: Word not found");
                        return -1;
                    }

                    wrd.addDefinition(new Definition(paramss[1].Replace("\'", "").Replace("\"", "")));
                    return 0;
                }

                Text txt = null;
                string title = "";
                string origin = "";
                string note = "";

                /* -------------------
                * ADD WORD command
                * -------------------*/
                if (flags[0] == "-w" )
                {
                    
                    string type = "";

                    if(paramss == null)
                    {
                        title = Shell.input("word:");
                        type = Shell.input("tipo:");
                        origin = Shell.multiline("origin:");
                        note = Shell.multiline("note:");
                    }

                    if (paramss != null && paramss.Count == 2)
                    {
                        title = paramss[0];
                        type = paramss[1];
                    }else if (paramss.Count == 1)
                    {
                        title = paramss[0];
                    }
                    else return -1;

                    wrdBuilder.setTitle(title);
                    wrdBuilder.setOrigin(origin);
                    wrdBuilder.setNote(note);
                    wrdBuilder.setType(type);
                    txt = wrdBuilder.build();
                }


                /* -------------------
                * ADD EXPRESSION command
                * -------------------*/
                if (flags[0] == "-e")
                {
                    

                    string text = "";
                    string explanation = "";
                   
                    
                    
                    title = Shell.input("title:");
                    text = Shell.multiline("text:");
                    
                    txt = new Expression(title, origin, note, text, explanation);
                }

                /* -------------------
                * ADD NOVEL command
                * -------------------*/
                if (flags[0] == "-n")
                {
                    


                    string text = "";
                    string author = "";

                   
                    title = Shell.input("title:");
                    author = Shell.input("author:");
                    text = Shell.multiline("text:");
                    

                    txt = new Novel(title, origin, note, text, author);
                }

                if(txt == null)
                {
                    Console.WriteLine("Invalid flag");
                }

                dictManger.CurDict().add(txt);

                return 0;
            }

            /* -------------------
            * CLEAR command
            * -------------------*/
            if (command == CLEAR)
            {
                Console.Clear();
                Console.WriteLine(HEAD);
                return 0;
            }
            /* -------------------
            * EXIT command
            * -------------------*/

            if (command == EXIT)
            {
                return 0;
            }

            /* -------------------
            * HELP command
            * -------------------*/

            if (command == HELP)
            {
                Console.WriteLine("commands:");
                foreach(var var in cmds)
                {
                    Console.WriteLine("   " + var.Key+":"+ "\t" + var.Value);
                }
                return 0;
            }


            /* -------------------
            * LIST command
            * -------------------*/

            if (command == LIST)
            {
                var dict = dictManger.CurDict();

                /* -------------------
                 * LIST all TEXT command
                 * -------------------*/
                if (flags == null)
                {

                    showList(dict.list());
                    return 0;
                }
                /* -------------------
                   * LIST WORDS command
                   * -------------------*/

                //show flag
                int sFLAG = 0;

                if (flags[0] == "-w")
                {
                    sFLAG = sFLAG | Dictionary.FLAG_W;
                }
                /* -------------------
                 * LIST EXPRESSIONS command
                 * -------------------*/
                if (flags[0] == "-e")
                {
                    sFLAG = sFLAG | Dictionary.FLAG_E;
                }

                /* -------------------
                 * LIST NOVELS command
                 * -------------------*/
                if (flags[0] == "-n")
                {
                    sFLAG = sFLAG | Dictionary.FLAG_N;
                }

                showList(dict.list(sFLAG));
                return 0;
            }


            /* -------------------
            * DELETE command
            * -------------------*/
            if (command == REMOVE)
            {

                if(paramss == null)
                {
                    Console.WriteLine("ERROR: params missing");
                    return -1;
                }

                Text wrd = dictManger.CurDict().find(paramss[0]);
                if (dictManger.CurDict().remove(wrd))
                {
                    Console.WriteLine("ERROR: word/expression/novel not found");
                }
                return 0;
            }

            /*----------------------
             * FIND 
             * -------------------*/
            if(command == FIND)
            {
                if(flags == null)
                {
                    Console.WriteLine("ERROR: flags missing");
                    return -1;
                }

                if (flags[0] == "-w")
                {
                    if (paramss == null)
                    {
                        Console.WriteLine("ERROR: params missing");
                        return -1;
                    }

                    Word wrd = dictManger.CurDict().findWord(paramss[0]);
                    if(wrd != null)
                    {
                        Console.WriteLine("found word:"+wrd.title);
                    }
                    else
                    {
                        Console.WriteLine("not found word:" + paramss[0]);
                    }
                    return 0;
                }

                if (flags[0] == "-e")
                {
                    if (paramss == null)
                    {
                        Console.WriteLine("ERROR: params missing");
                        return -1;
                    }

                    Expression exp = dictManger.CurDict().findExp(paramss[0]);
                    if (exp != null)
                    {
                        Console.WriteLine("found word:" + exp.title);
                    }
                    else
                    {
                        Console.WriteLine("not found word:" + paramss[0]);
                    }
                    return 0;
                }

                if (flags[0] == "-n")
                {
                    if (paramss == null)
                    {
                        Console.WriteLine("ERROR: params missing");
                        return -1;
                    }

                    Novel nvl = dictManger.CurDict().findNovel(paramss[0]);
                    if (nvl != null)
                    {
                        Console.WriteLine("found novel:" + nvl.title);
                    }
                    else
                    {
                        Console.WriteLine("not found word:" + paramss[0]);
                    }
                    return 0;
                }
            }

            /*----------------------
             * REMIND 
             * -------------------*/

            if (command == REMIND)
            {
                int n = 5;
                if(paramss != null )
                {
                    n = int.Parse(paramss[0]);
                }

                List<string> list_wrd =new List<string>();

                List<Word> words = dictManger.CurDict().wrdRemind(n);
                foreach(Word w in words)
                {
                    list_wrd.Add(w.title);
                }
                showList(list_wrd);
                return 0;
            }
            Console.WriteLine($"{input} not found");
            return 1;
        }

        private void showList(List<string> inputs)
        {
            int i = 0;
            for (i = 0; i < inputs.Count; i++)
                Console.WriteLine((i + 1) + ") " + inputs[i]);

        }


        static private string input(string text)
        {
            Console.Write(text);
            string ret = Console.ReadLine();
            return ret;
        }

        static private string multiline(string text)
        {
            string ret = "";
            Console.WriteLine(text);
            char ch;
            int x = 0;
            Console.Write("-->");
            while ( (x = Console.Read()) != 5)
            {
                ch = Convert.ToChar(x);
                ret += ch;
                if (ch == 13)
                    Console.Write("-->");
                
            }
            FlushKeyboard();
            return ret;
        }

        private static void FlushKeyboard()
        {
            while (Console.In.Peek() != -1)
                Console.In.Read();
        }

        

        /*
           Command Parser
           format: command flags params
           example: add -d ciao "un modo per salutarsi"
             */
        internal static class CParser
        {
            
            static public Object[] Parse(string input)
            {
                string cmd = null;
                List<string> flags = new List<string>() ;
                List<string> paramss = new List<string>();
                int index;

                Object[] ret = new Object[3];

                index = input.IndexOf(" ");
                if (index == -1) {
                    cmd = input;
                    ret[0] = cmd;
                    return ret;
                }

                //get the command
                cmd = input.Substring(0,index);
                ret[0] = cmd;

                //Console.WriteLine(cmd+"wtf");


                // get the flags
                index = index + 1;
                string next = input.Substring(index,input.Length-index);
                //Console.WriteLine(next + "wtf");
                while (true)
                {
                    index = next.IndexOf("-");
                    //se non trova più flags
                    if (index == -1)
                        break;

                    string flag = next.Substring(index, 2);
                    //Console.WriteLine(flag + "wtf");
                    next = next.Substring(index+2,next.Length-index-2);
                    //Console.WriteLine(next + "wtf");
                    flags.Add(flag);
                }
                ret[1] = flags;

                //get params
                if(next == "")
                {
                    return ret;
                }

                if(flags.Count != 0) next = next.Remove(0, 1);
                //Console.WriteLine("qualcosa:"+next);
                List<string> tmp = new List<string>();
                // for '
                while (true)
                {
                    int index_s = next.IndexOf("'");
                    int count = next.Substring(index_s+1).IndexOf("'");
                    //se non trova più parametri con ''
                    if (index_s == -1 || count == -1)
                        break;

                   // Console.WriteLine("params:" + next.Substring(index_s, count+2));

                    tmp.Add(next.Substring( index_s,count+2) );
                    next = next.Remove(index_s,count+2);
                }

                // for "
                while (true)
                {
                    int index_s = next.IndexOf("\"");
                    int count = next.Substring(index_s + 1).IndexOf("\"");
                    //se non trova più parametri con ''
                    if (index_s == -1 || count == -1)
                        break;

                    // Console.WriteLine("params:" + next.Substring(index_s, count+2));

                    tmp.Add(next.Substring(index_s, count + 2));
                    next = next.Remove(index_s, count + 2);
                }

                string[] fields = next.Split(' ');

                for (int i = 0; i< fields.Length; i++)
                {
                    if (fields[i] == "")
                        continue;
                    paramss.Add(fields[i]);
                    //Console.WriteLine("params:" + fields[i]);
                }
                paramss.AddRange(tmp);

                ret[2] = paramss;
                return ret;
            }
        }
    }




    class WordBuilder {

        static private WordBuilder wrdBuilder = null;
        private Word wrdWord;

        static public WordBuilder wordBuilder()
        {
            if (wrdBuilder == null)
                wrdBuilder = new WordBuilder();

            return wrdBuilder;
        }
       

        private WordBuilder()
        {
            newWord();
        }

        private void newWord()
        {
            wrdWord = new Word();
        }

        public WordBuilder setTitle(string title)
        {
            wrdWord.title = title;
            return this;
        }

        public WordBuilder setOrigin(string origin)
        {
            wrdWord.origin = origin;
            return this;
        }

        public WordBuilder setNote(string note)
        {
            wrdWord.note = note;
            return this;
        }

        public WordBuilder addDefinition(Definition def)
        {
            wrdWord.addDefinition(def);
            return this;
        }

        public WordBuilder setType(string type)
        {
            wrdWord.setType(type);
            return this;
        }

        public WordBuilder addForm(Form form)
        {
            wrdWord.addForm(form);
            return this;
        }

        private Word getWord()
        {
            wrdWord.updateLastVisit();
            return wrdWord;
        }

        public Word build()
        {
            Word ret = getWord();
            newWord();
            return ret;
        }
    }
        
}
