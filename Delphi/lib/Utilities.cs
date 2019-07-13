using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Datastructure;

namespace Utility
{
    
    public class Utilities
    {
        private static Stopwatch stopWatch = null;

        public static void startTimer()
        {
            stopWatch = Stopwatch.StartNew();
        }

        public static long  endTimer()
        {
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }
    }

    //Delphi Shell
    public class DShell
    {

        // _D for descriptions
        static private string READ_D = "reads from file, without params it reads to the default file in config.txt, USAGE: read FILENAME; read";
        static private string SAVE_D = "saves into a file, without params it saves to the default file in config.txt, USAGE: save FILENAME; save";
        static private string ADD_D = "add a word(-w)/definition(-d)/novel(-n)/expression(-e), not fully implemented, USAGE add -w WORD TYPE; add -w;\n   \tadd -d WORD DEFINITION";
        static private string CLEAR_D = "clear the screen";
        static private string EXIT_D = "exit from shell";
        static private string HELP_D = "show the commands and thier descriptions";
        static private string LIST_D = "list the words/expressions/novels; usage: list; list -w; list -e ; list -n, finish the typing with CTRL-E ";
        static private string REMOVE_D = "delete a word, an expression or a novel; usage: remove TITLE";
        static private string FIND_D = "finds a word, an expression or a novel; usage: find -w/-e/-n TITLE";
        static private string REMIND_D = "show the last seen words";
        static private string SHOW_D = "show the details of a word(-w)/ expression(-e)/novel(-n.)  USAGE: show -d WORD";
        static private string CHANGE_D = "change the current dictionary USAGE: change INDEX";
       

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
        static private string SHOW = "show";
        static private string CHANGE = "change";

        //flag for dict is -dtc

        // heading
        static private string HEAD = "Delphi [Versione 1.0.0]";


        private DictManger dictManger = null;
        WordBuilder wrdBuilder = null;
        static private Dictionary<string, string> cmds;

        public DShell()
        {
            init();
            dictManger = DictManger.Manager();
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
            cmds[SHOW] = SHOW_D;
            cmds[CHANGE] = CHANGE_D;

            // set the max input chars
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
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
                if(flags.Count == 0 )
                {
                    Console.WriteLine("error: choose -w / -d / -n / -e");
                    return 0;
                }

                if(flags[0] == "-dct")
                {
                    if(paramss == null || paramss.Count != 2)
                    {
                        Console.WriteLine("ERROR USAGE: add -dct DICT_NAME LANG");
                        return -1;
                    }

                    dictManger.addDict(
                        DictBuilder.dictBuilder().
                        setName(paramss[0]).
                        setLanguage(paramss[1]).
                        build()
                    );
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

                    Word wrd = dictManger.CurDict().findWord(paramss[0]);

                    if (wrd == null)
                    {
                        Console.WriteLine("Error: Word not found");
                        return -1;
                    }

                    wrd.addDefinition(new Definition(paramss[1].Replace("\'", "").Replace("\"", "")));
                    return 0;
                }

                /*-----------------------
                  ADD SYNONYM OR CONTRARY
                 ------------------------*/

                if(flags[0] == "-s")
                {
                    if (paramss == null || (paramss.Count != 3  && paramss.Count != 2) )
                    {
                        Console.WriteLine("USAGE: add -s WORD SYNONYM [N.DEFINITION]");
                        return 0;
                    }


                    Word wrd = dictManger.CurDict().findWord(paramss[0]);
                    if (wrd == null)
                    {
                        Console.WriteLine("Error: Word not found");
                        return -1;
                    }

                    Definition def;
                    def = wrd.getDefinition( paramss.Count == 3 ? Int32.Parse(paramss[2]) : 0 );
                    def.addSynonym(dictManger.CurDict().findWord(paramss[1]));
                }

                if(flags[0] == "-c")
                {
                    if (paramss == null || (paramss.Count != 3 && paramss.Count != 2))
                    {
                        Console.WriteLine("USAGE: add -s WORD CONTRARY [N.DEFINITION]");
                        return 0;
                    }


                    Word wrd = dictManger.CurDict().findWord(paramss[0]);
                    if (wrd == null)
                    {
                        Console.WriteLine("Error: Word not found");
                        return -1;
                    }

                    Definition def;
                    def = wrd.getDefinition(paramss.Count == 3 ? Int32.Parse(paramss[2]) : 0);
                    def.addContrary(dictManger.CurDict().findWord(paramss[1]));
                }

                /*-----------------------
                  ADD TRANSLATION  need to be re-thought
                 ------------------------*/
                if (flags[0] == "-wt")
                {
                    if (paramss == null || paramss.Count > 4 || paramss.Count < 2)
                    {
                        Console.WriteLine("USAGE: add -wt WORD TRANSLATED LANG [N.DEFINITION]");
                        return 0;
                    }

                    Word wrd = dictManger.CurDict().findWord(paramss[0]);
                    if (wrd == null)
                    {
                        Console.WriteLine("Error: Word not found");
                        return -1;
                    }
                    
                    // Texts found , List of indexes of dictionaries
                    Tuple<List<Text>, List<int>> tuple = dictManger.find(paramss[1], Dictionary.FLAG_W);
                    int idx = tuple.Item2[0];

                    if (tuple.Item1.Count != 1)
                    {
                        for (int i = 0; i < tuple.Item2.Count; i++)
                            if (dictManger.getDict(tuple.Item2[i]).Language == paramss[2]) { 
                                idx = i;
                                break;
                            }
                    }

                    Word translated = (Word)tuple.Item1[idx];
                    Definition def = wrd.getDefinition(paramss.Count == 4 ? Int32.Parse(paramss[3]) : 0);
                    def.addTranslation(new Translation(paramss[2],translated) );
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
                        title = DShell.input("word:");
                        type = DShell.input("tipo:");
                        origin = DShell.multiline("origin:");
                        note = DShell.multiline("note:");
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
                   
                    
                    
                    title = DShell.input("title:");
                    text = DShell.multiline("text:");
                    
                    txt = new Expression(title, origin, note, text, explanation);
                }

                /* -------------------
                * ADD NOVEL command
                * -------------------*/
                if (flags[0] == "-n")
                {
                    


                    string text = "";
                    string author = "";

                   
                    title = DShell.input("title:");
                    author = DShell.input("author:");
                    text = DShell.multiline("text:");
                    

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

                    Console.WriteLine(dict.list());
                    return 0;
                }

                /* ----------------------------
                   * LIST DICTIONARIES command
                   * --------------------------*/

                if(flags[0] == "-dct")
                {
                    Console.WriteLine(dictManger.listDicts());
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

                Console.WriteLine( dict.list(sFLAG) );
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
                } else if ( (paramss.Count != 2 && paramss.Count != 1 ))
                {
                    Console.WriteLine("USAGE: remove -d WORD N*DEFINITION");
                    return -1;
                }
                

                Text txt = dictManger.CurDict().find(paramss[0]);


                if ( flags.Count != 0 && flags[0] == "-d")
                {
                    if (((Word)txt).removeDefinition(Int32.Parse(paramss[1]) - 1) == null)
                    {
                        Console.WriteLine("ERROR: index of definition out of bound");
                        return -1;
                    }
                    return 0;
                }

                if (flags.Count == 0 && dictManger.CurDict().remove(txt))
                {
                    Console.WriteLine("ERROR: word/expression/novel not found");
                    return -1;
                }

                


                return 0;
            }

            /*----------------------
             * FIND 
             * -------------------*/
            if(command == FIND)
            {

                if(flags.Count == 0)
                {
                    Text txt = dictManger.CurDict().find(paramss[0]);
                    if (txt != null)
                    {
                        Console.WriteLine("found:" + txt.title);
                    }
                    else
                    {
                        Console.WriteLine("not found :" + paramss[0]);
                    }
                    return 0;
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

                if (flags[0] == "-p")
                {
                    if (paramss == null)
                    {
                        Console.WriteLine("ERROR: params missing");
                        return -1;
                    }

                    List<Text> texts = dictManger.CurDict().PBS(paramss[0]);
                    foreach (Text text in texts) { 
                        if (text != null)
                        {
                            Console.WriteLine("found text:" + text.title);
                        }
                        else
                        {
                            Console.WriteLine("not found word:" + paramss[0]);
                        }
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
                Console.WriteLine(list_wrd);
                return 0;
            }

            /*----------------------
            * SHOW
            * -------------------*/
            if(command == SHOW)
            {
                if(paramss == null || paramss.Count != 1)
                {
                    Console.WriteLine("USAGE: show -w WORD");
                    return 0;
                }
                int find_flags = 0;

                if(flags.Count != 0) { 

                    if (flags[0] == "-w")
                        find_flags |= Dictionary.FLAG_W;
                    else if (flags[0] == "-n")
                        find_flags |= Dictionary.FLAG_N;
                    else if (flags[0] == "-e")
                        find_flags |= Dictionary.FLAG_E;

                }

                Text txtFound = dictManger.CurDict().find(paramss[0],find_flags);

                if(txtFound == null)
                {
                    Console.WriteLine("error: word/expression/novel not found");
                    return -1;
                } else Console.WriteLine(txtFound.toString());

                return 0;
            }


            /*----------------------
            * CHANGE
            * -------------------*/
            if (command == CHANGE)
            {
               if(paramss == null || paramss.Count != 1)
                {
                    Console.WriteLine("ERROR, USAGE: change INDEX");
                    return -1;
                }

                dictManger.setCurDict(Int32.Parse( paramss[0]) );
            }


            Console.WriteLine($"{input} not found");
            return 1;
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


                for (int i = 0; i < paramss.Count; i++)
                {
                    paramss[i] = paramss[i].Replace("\"", "");
                    paramss[i] = paramss[i].Replace("'", "");
                }
                ret[2] = paramss;

                return ret;
            }
        }
    }




    //
    // Builders for the data structures
    //
    public abstract class TextBuilder
    {
        static protected TextBuilder txtBuilder = null;
        protected Text txtText = null;


        protected TextBuilder()
        {
            this.newText();
        }

        public TextBuilder setTitle(string title)
        {
            txtText.title = title;
            return this;
        }

        public TextBuilder setOrigin(string origin)
        {
            txtText.origin = origin;
            return this;
        }

        public TextBuilder setNote(string note)
        {
            txtText.note = note;
            return this;
        }

        protected Text getText()
        {
            txtText.updateLastVisit();
            return txtText;
        }

        public Text build()
        {
            Text ret = getText();
            newText();
            return ret;
        }

        protected abstract void newText();
    }

    public class NovelBuilder : TextBuilder
    {
        static new protected TextBuilder txtBuilder = null;

        private NovelBuilder():base(){}

        static public NovelBuilder novelBuilder()
        {
            if (txtBuilder == null)
                txtBuilder = new NovelBuilder();

            return (NovelBuilder)txtBuilder;
        }

        protected override void newText()
        {
            txtText = new Novel();
        }


        public  Novel getText()
        {
            return (Novel)(base.getText());
        }

        public NovelBuilder setAuthor(string author)
        {
            ((Novel)txtText).author = author;
            return (NovelBuilder)txtBuilder;
        }

        public NovelBuilder setText(string text)
        {
            ((Novel)txtText).text = text;
            return (NovelBuilder)txtBuilder;
        }

    }

    public class ExpressionBuilder : TextBuilder
    {

        protected new static TextBuilder txtBuilder = null;

        private ExpressionBuilder() : base(){ }

        static public ExpressionBuilder expressionBuilder()
        {
            if (txtBuilder == null)
                txtBuilder = new ExpressionBuilder();

            return (ExpressionBuilder)txtBuilder;
        }

        protected override void newText()
        {
            txtText = new Expression();
        }

        public Expression getText()
        {
            return (Expression)(base.getText());
        }


        public ExpressionBuilder setExplanation(string explanation)
        {
            ((Expression)txtText).explanation = explanation;
            return(ExpressionBuilder) txtBuilder;
        }

        public ExpressionBuilder setText(string text)
        {
            ((Expression)txtText).text = text;
            return (ExpressionBuilder)txtBuilder;
        }

    }

    public class WordBuilder: TextBuilder {

        static new protected TextBuilder txtBuilder = null;

        static public WordBuilder wordBuilder()
        {
            if (txtBuilder == null)
                txtBuilder = new WordBuilder();

            return (WordBuilder)txtBuilder;
        }

        private WordBuilder():base(){}

        protected override void newText()
        {
            txtText = new Word();
        }

        public WordBuilder addDefinition(Definition def)
        {
            ((Word)txtText) .addDefinition(def);
            return this;
        }

        public WordBuilder setType(string type)
        {
            ((Word)txtText).setType(type);
            return this;
        }

        public WordBuilder addForm(Form form)
        {
            ((Word)txtText).addForm(form);
            return this;
        }
        
        public Word getText()
        {
            return (Word)(base.getText());
        }
    }

    public class DictBuilder
    {
        private static DictBuilder dctBuilder = null;
        private Dictionary dict = null;

        public DictBuilder()
        {
            newDict();
        }

        static public DictBuilder dictBuilder()
        {
            if (dctBuilder == null)
                dctBuilder = new DictBuilder();

            return dctBuilder;
        }

        private  void newDict(){
            dict = new Dictionary();
        }

        public DictBuilder setName(string name)
        {
            if (name != null)
                dict.Name = name;
            else return null;

            return this;
        }

        public DictBuilder setLanguage(string lang)
        {
            if (lang != null)
                dict.Language = lang;
            else return null;

            return this;
        }

        protected Dictionary getDict()
        {
            return dict;
        }

        public Dictionary build()
        {
            Dictionary ret = getDict();
            newDict();
            return ret;
        }

    }
}
