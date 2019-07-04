using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


namespace Datastructure
{

    /**--------------------------------------------------------------------
     *                                                                    |
     * Dictionary Manager, it reads from file , saves dictionary and      |
     * implement the Singleton Pattern there is only one istance of       |
     * DictManger in all the program                                      |
     *                                                                    |
     * -------------------------------------------------------------------- */

    public class DictManger
    {
        private static DictManger dictManger = null;
        private List<Dictionary> dicts = null;
        private Dictionary curDict = null;

        private static String DEFAULT_PATH;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool setCurDict(string name)
        {
            for(int i = 0; i< dicts.Count; i++)
            {
                if(dicts[i].Name == name)
                {
                    curDict = dicts[i];
                    return true;
                }
            }
            return false;
        }
        public Dictionary CurDict() {
            return curDict;
        }

        private DictManger()
        { load(); }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static DictManger Manger()
        {
            if (dictManger == null)
                dictManger = new DictManger();

            return dictManger;
        }


        /**--------------------------------------------------------
         *                                                        |
         * the method writes on file and create a readable local  |
         * db ,see delphi.txt                                     |
         *                                                        |
         ---------------------------------------------------------*/

        [MethodImpl(MethodImplOptions.Synchronized)]
        public  bool save(string path)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path, false, Encoding.Unicode);
                // number of dictionaries
                sw.WriteLine(dicts.Count);


                // for each dictionary, the method memorize on file the words, expressions and novels.
                for (int cntDic = 0; cntDic < dicts.Count; cntDic++)
                {
                    Dictionary dtnDict = dicts[cntDic];

                    // dictionary name and language
                    sw.WriteLine(dtnDict.Name + ";" + dtnDict.Language);

                    //number of words , expressions and novels
                    string wds_exps_nvscount = String.Format("{0};{1};{2}", dtnDict.getWordsCount(),
                                                                           dtnDict.getExpressionsCount(),
                                                                           dtnDict.getNovelsCount());
                    sw.WriteLine(wds_exps_nvscount);

                    /* -------------
                     * WORDS       |
                     ---------------*/
                    for (int cntWord = 0; cntWord < dtnDict.getWordsCount(); cntWord++)
                    {
                        Word wrdWord = dicts[cntDic].getWord(cntWord);
                        // title, creation date, last vist date, type
                        sw.WriteLine(wrdWord.title + ";" +
                                     wrdWord.getCreationDate() + ";" +
                                     wrdWord.getLastVisitDate() + ";" +
                                     wrdWord.getType());

                        write(sw, wrdWord.origin);
                        write(sw, wrdWord.note);

                        // the forms
                        string typeline = "";

                        List<Form> forms = wrdWord.getForms();
                        for (int cntForm = 0; cntForm < forms.Count; cntForm++)
                            typeline += forms[cntForm].form + ";" + forms[cntForm].type + ";";

                        if (!typeline.Equals(""))
                            typeline = typeline.Remove(typeline.Length - 1);

                        sw.WriteLine(typeline);

                        // definitions
                        sw.WriteLine(wrdWord.getDefinitionCount());
                        List<Definition> defs = wrdWord.GetDefinitions();
                        for (int cntDefinition = 0; cntDefinition < defs.Count; cntDefinition++)
                            write(sw, defs[cntDefinition].definition);

                    }

                    /* -------------------
                     * EXPRESSIONs       |
                     ---------------------*/
                    for (int cntExp = 0; cntExp < dtnDict.getExpressionsCount(); cntExp++)
                    {
                        Expression exp = dtnDict.getExpression(cntExp);
                        sw.WriteLine(exp.title + ";" + exp.getCreationDate() + ";" + exp.getLastVisitDate());
                        write(sw, exp.origin);
                        write(sw, exp.note);
                        write(sw, exp.text);
                        write(sw, exp.explanation);
                    }

                    /**-----------------------------
                      SYNONYMS AND CONTRARIES      |
                    --------------------------------
                     */
                    for (int cntWord = 0; cntWord < dtnDict.getWordsCount(); cntWord++)
                    {
                        Word wrdWord = dtnDict.getWord(cntWord);
                        for (int cntDef = 0; cntDef < wrdWord.getDefinitionCount(); cntDef++)
                        {
                            Definition dfnDef = wrdWord.getDefinition(cntDef);

                            /*if there arent any synms it just doesn't write anything 
                              else then 0 */
                            bool isThereSyns = true;
                            if (dfnDef.getSynonyms().Count == 0)
                                isThereSyns = false;
                            /*if there arent any contraries it just doesn't write anything 
                              else then 0 */
                            bool isThereCons = true;
                            if (dfnDef.getContraries().Count == 0)
                                isThereCons = false;

                            sw.WriteLine(cntWord.ToString() + ";" +
                                         cntDef.ToString() + ";" +
                                         (isThereSyns ? "1" : "0") + ";" +
                                         (isThereCons ? "1" : "0")
                            );


                            if (isThereSyns)
                            {
                                string res = "";
                                // collecting the synonmyms
                                foreach (Text t in dfnDef.getSynonyms())
                                    res += dtnDict.getIdArrayOfText(t) + ";";

                                // write down the synonyms
                                sw.WriteLine(res);
                            }

                            if (isThereCons)
                            {
                                // collecting the contraires
                                string res = "";
                                foreach (Text t in dfnDef.getContraries())
                                    res += dtnDict.getIdArrayOfText(t) + ";";

                                // write down the contraries
                                sw.WriteLine(res);
                            }
                        }
                    }

                    /*---------------
                     NOVELS         |
                     ---------------*/
                    for (int cntNovel = 0; cntNovel < dtnDict.getNovelsCount(); cntNovel++)
                    {
                        Novel nvl = dtnDict.getNovel(cntNovel);
                        sw.WriteLine(nvl.title + ";" + nvl.getCreationDate() + ";" + nvl.getLastVisitDate() + ";" + nvl.author);
                        write(sw, nvl.origin);
                        write(sw, nvl.note);
                        write(sw, nvl.text);
                    }
                }

                /**---------------------
                   TRANSLATIONS INDEX  |
                ------------------------*/
                for (int cntDict = 0; cntDict < dicts.Count; cntDict++)
                {
                    Dictionary dic = dicts[cntDict];

                    for (int cntWord = 0; cntWord < dic.getWordsCount(); cntWord++)
                    {
                        Word wrd = dic.getWord(cntWord);
                        int idx = dic.getIdArrayOfText(wrd);

                        for (int cntDef = 0; cntDef < wrd.getDefinitionCount(); cntDef++)
                        {
                            Definition def = wrd.getDefinition(cntDef);
                            string ret = "";
                            foreach (Translation trans in def.getTranslations())
                            {
                                int dic_idx = trans.getDicID();
                                ret += dic_idx + " - " + dicts[dic_idx].getIdArrayOfText(trans.getTranslated()) + ";";
                            }
                            if (!ret.Equals("")) ret = ";" + ret.Remove(ret.Length - 1);
                            sw.WriteLine(idx + ";" + cntDef + ret);
                        }
                    }
                    for (int cntExp = 0; cntExp < dic.getExpressionsCount(); cntExp++)
                    {
                        Expression expr = dic.getExpression(cntExp);
                        int expr_idx = dic.getIdArrayOfText(expr);
                        string ret = "";
                        foreach (Translation trans in expr.getTranslations())
                        {
                            int dic_idx = trans.getDicID();
                            ret += dic_idx + " - " + dicts[dic_idx].getIdArrayOfText(trans.getTranslated()) + ";";
                        }
                        if (!ret.Equals("")) ret = ret.Remove(ret.Length - 1);
                        sw.WriteLine(expr_idx + ";" + ret);
                    }

                    for (int cntNvl = 0; cntNvl < dic.getNovelsCount(); cntNvl++)
                    {
                        Novel nvl = dic.getNovel(cntNvl);
                        int nvl_idx = dic.getIdArrayOfText(nvl);
                        string ret = "";
                        foreach (Translation trans in nvl.getTranslations())
                        {
                            int dic_idx = trans.getDicID();
                            ret += dic_idx + " - " + dicts[dic_idx].getIdArrayOfText(trans.getTranslated()) + ";";
                        }
                        if (!ret.Equals("")) ret = ret.Remove(ret.Length - 1);
                        sw.WriteLine(nvl_idx + ";" + ret);
                    }
                }

                sw.Close();
                return false;
            }
            catch (Exception e)
            { Console.WriteLine("Exception: " + e.Message); }

            return true;
        }

        //it sets the curDict to the first dictionary
        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool load()
        {
            config();
            if (read(DEFAULT_PATH)) { 
                dicts.Add( new Dictionary() );
                curDict = dicts[0];
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        // imposta solo il DEFAULT PATH
        private void config()
        {
            DEFAULT_PATH = "../../input1.txt";
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private  void addSynonymsOrContrarysFromFile(string line, Dictionary dictionary, List<Text> list)
        {

            string[] records = line.Split(';');
            foreach (string s in records)
            {
                int idx_text = Int32.Parse(s);
                if (idx_text < dictionary.getWordsCount())
                    list.Add(dictionary.getWord(idx_text));
                else
                    list.Add(dictionary.
                        getExpression(idx_text - dictionary.getWordsCount()));

            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private  void write(StreamWriter sw, string text)
        {
            sw.WriteLine("<t>");
            sw.WriteLine(text);
            sw.WriteLine("</t>");
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private  string parse(StreamReader sr)
        {
            string ret = "";
            string line;
            sr.ReadLine();
            while (!(line = sr.ReadLine()).Equals("</t>"))
            { ret += line + "\n"; }
            if (ret.Length > 1) ret = ret.Remove(ret.Length - 1);
            return ret;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        // after reading , it will call init() to inizialize the dicts
        public  bool read(string path)
        {
            dicts = new List<Dictionary>();
            try
            {
                String line;
                string[] fields;
                StreamReader sr = new StreamReader(path);

                /** numbers of dicts */
                line = sr.ReadLine();
                int num_dictio = Int32.Parse(line);
                //Console.WriteLine("num dict:{0}",num_dictio);
                /**---------------------------------------
                    reading the dictionaraies            |
                ------------------------------------------*/

                for (int cntDict = 0; cntDict < num_dictio; cntDict++)
                {
                    Dictionary dict = new Dictionary();
                    dicts.Add(dict);
                    /** setting the name and language of dictionary*/

                    line = sr.ReadLine();
                    string[] dicHeader = line.Split(';');
                    dict.Name = dicHeader[0];
                    dict.Language = dicHeader[1];

                    //Console.WriteLine(" name:{0}, lang:{1} ",dict.Name, dict.Language);
                    /** reading the numer of words, expressions and novels*/
                    line = sr.ReadLine();
                    string[] counters = line.Split(';');
                    int num_words = Int32.Parse(counters[0]);
                    int num_expres = Int32.Parse(counters[1]);
                    int num_novels = Int32.Parse(counters[2]);
                    //Console.WriteLine(" n words:{0}, n expres:{1}, n novels:{2}",num_words,num_expres,num_novels);

                    /**---------------------------- 
                     * reading the words          |
                     ------------------------------*/

                    for (int cntWord = 0; cntWord < num_words; cntWord++)
                    {
                        line = sr.ReadLine();
                        fields = line.Split(';');
                        string orig = parse(sr);
                        string note = parse(sr);

                        Word w = new Word(fields[0], orig, note, DateTime.Parse(fields[1]), DateTime.Parse(fields[2]), fields[3]);

                        /** reading the forms of the word*/
                        line = sr.ReadLine();
                        if (!line.Equals(""))
                        {
                            fields = line.Split(';');
                            for (int i = 0; i < fields.Length; i++)
                                w.addForm(new Form(fields[i], fields[++i]));
                        }

                        /**reading the definitions of the word*/
                        line = sr.ReadLine();
                        int num_def = Int32.Parse(line);
                        string def = "";
                        for (int i = 0; i < num_def; i++)
                        {
                            def = parse(sr);
                            w.addDefinition(new Definition(def));
                        }

                        dict.add(w);
                    }




                    /**---------------------------------------------
                     * reading the expressions                     |
                     -----------------------------------------------*/
                    for (int cntExpres = 0; cntExpres < num_expres; cntExpres++)
                    {

                        line = sr.ReadLine();
                        fields = line.Split(';');
                        string orig = parse(sr);
                        string note = parse(sr);
                        string text = parse(sr);
                        string expla = parse(sr);
                        Expression e = new Expression(fields[0], orig, note, DateTime.Parse(fields[1]), DateTime.Parse(fields[2]), text,expla);

                        dict.add(e);
                    }


                    /**----------------------------------------------------------------- 
                     *| reading synonyms and contraries of definitions                 |
                     *-----------------------------------------------------------------*/

                    /**it's after the reaading of expressions because a definition maybe
                     has as synonym or contrary an expression*/
                    for (int cntDef = 0; cntDef < dict.getDefinitionsOfWordsCount(); cntDef++)
                    {
                        line = sr.ReadLine();
                        fields = line.Split(';');

                        /**getting the definition of the given word*/

                        int idx_word = Int32.Parse(fields[0]);
                        int idx_def = Int32.Parse(fields[1]);

                        Definition def = dict
                                            .getWord(idx_word).getDefinition(idx_def);

                        /**checking if there are synonyms*/
                        if (fields[2].Equals("1"))
                        {
                            line = sr.ReadLine();
                            addSynonymsOrContrarysFromFile(line, dict, def.getSynonyms());
                        }

                        /**checking if there are contraries*/
                        if (fields[3].Equals("1"))
                        {
                            line = sr.ReadLine();
                            addSynonymsOrContrarysFromFile(line, dict, def.getContraries());
                        }
                    }


                    /**-------------------------
                     * reading the novels      |
                     ---------------------------*/
                    for (int cntNov = 0; cntNov < num_novels; cntNov++)
                    {
                        line = sr.ReadLine();
                        fields = line.Split(';');

                        string orig = parse(sr);
                        string note = parse(sr);
                        string text = parse(sr);
                        Novel n = new Novel(fields[0], orig, note, DateTime.Parse(fields[1]), DateTime.Parse(fields[2]), text, fields[3]);

                        dict.add(n);
                    }
                }

                /**-------------------------------
                 * reading the translations      |
                 ---------------------------------*/


                for (int cntDict = 0; cntDict < dicts.Count; cntDict++)
                {
                    string[] records;
                    Dictionary dict = dicts[cntDict];

                    /* translation for words  */
                    for (int cntWord = 0; cntWord < dict.getDefinitionsOfWordsCount(); cntWord++)
                    {
                        line = sr.ReadLine();
                        fields = line.Split(';');

                        int idx_word = Int32.Parse(fields[0]);
                        int idx_def = Int32.Parse(fields[1]);
                        Definition def = dict.getWord(idx_word).getDefinition(idx_def);

                        for (int i = 2; i < fields.Length; i++)
                        {
                            records = fields[i].Split('-');
                            int idx_dict = Int32.Parse(records[0]);
                            int idx_text = Int32.Parse(records[1]);

                            string lang = dicts[idx_dict].Language;

                            Text txtText = dicts[idx_dict].getText(idx_text);
                            Translation trsTrans = new Translation(idx_dict, lang, txtText);
                            def.addTranslation(trsTrans);
                        }

                    }

                    /*translation for expressions, it's the same algorithm of words*/
                    for (int cntExpres = 0; cntExpres < dict.getExpressionsCount(); cntExpres++)
                    {
                        line = sr.ReadLine();
                        fields = line.Split(';');

                        int idx_expres = Int32.Parse(fields[0]);
                        Expression e = dict.getExpression(cntExpres);


                        for (int i = 2; i < fields.Length; i++)
                        {
                            records = fields[i].Split('-');
                            int idx_dict = Int32.Parse(records[0]);
                            int idx_text = Int32.Parse(records[1]);
                            string lang = dicts[idx_dict].Language;

                            Text txtText = dicts[idx_dict].getText(idx_text);
                            Translation trsTrans = new Translation(idx_dict, lang, txtText);
                            e.addTranslation(trsTrans);
                        }
                    }

                    /*translation for novels , it's the same algorithm of words*/
                    for (int cntNovel = 0; cntNovel < dict.getNovelsCount(); cntNovel++)
                    {
                        line = sr.ReadLine();
                        fields = line.Split(';');

                        int idx_expres = Int32.Parse(fields[0]);
                        Novel n = dict.getNovel(cntNovel);


                        for (int i = 2; i < fields.Length; i++)
                        {
                            records = fields[i].Split('-');
                            int idx_dict = Int32.Parse(records[0]);
                            int idx_text = Int32.Parse(records[1]);
                            string lang = dicts[idx_dict].Language;

                            Text txtText = dicts[idx_dict].getText(idx_text);
                            Translation trsTrans = new Translation(idx_dict, lang, txtText);
                            n.addTranslation(trsTrans);
                        }
                    }
                }

                sr.Close();
                curDict = dicts[0];
                init();
                return false;
            }

            catch (Exception e)
            { Console.WriteLine("Exception: " + e.Message); }
            return true;
        }

        private  void init()
        {
            foreach (var dict in dicts)
                dict.init();
        }
    }

    /**--------------------------------------------------------------------
     *                                                                    |
     * Dictionary, it has a 1 to N relationship with the classes Word     |
     * Expression and Novel. It wrapps them and use them.                 |
     *                                                                    |
     * -------------------------------------------------------------------- */

    public class Dictionary
    {

        private string _name;
        private string _language;
        private DateTime dataCreation;

        private List<Word> words;
        private List<Expression> expressions;
        private List<Novel> novels;
        private IndexBook idxBook;

        private List<int> dateIdxArray;
        private int maxIndexedIndex;

        public static int FLAG_W = 0b00000001;
        public static int FLAG_E = 0b00000010;
        public static int FLAG_N = 0b00000100;

       /*--------------
         COSTRUCTORS
         ----------------
             */

        public Dictionary(string name, string lang, DateTime date) 
        {
            words = new List<Word>();
            expressions = new List<Expression>();
            novels = new List<Novel>();
            dateIdxArray = new List<int>();
            idxBook = new IndexBook();
            dataCreation = DateTime.UtcNow;

            _name = name;
            _language = lang;

            if (date != null)
                dataCreation = date;
        }

        public Dictionary(string name, string lang): this(name,lang,DateTime.UtcNow){}

        public Dictionary(): this("Default","ita") {}


        public string Name {
            get => _name;

            set
            {
                _name = value;
            }
        }
        public string Language { get => _language; set => _language = value; }
        public DateTime DataCreation { get => dataCreation; set => dataCreation = value; }

        /**-----------------------
            add methods          |
            ----------------------*/

        public bool add(Text t)
        {
            if (t == null)
                return true;

            Type type = t.GetType();

            idxBook.add(t);

            if (type == typeof(Word)) { 
                words.Add((Word)t);
                updateDateIdx();
            }

            if (type == typeof(Expression))
                expressions.Add((Expression)t);

            if (type == typeof(Novel))
                novels.Add((Novel)t);

            return false;
        }

        public bool add(Word w)
        { return add((Text)w); }

        public bool add(Expression e)
        { return add((Text)e); }

        private bool add(Novel n)
        { return add((Text)n); }

        private bool addDef(string word, Definition def)
        {
            Word wrd = (Word)idxBook.search(word);
            if (wrd == null)
                return true;

            wrd.addDefinition(def);
            return false;
        }

        /*------------------
         * REMOVE METHODS
         * -----------------
         * */

        public bool remove(Text t)
        {
            if (t == null)
                return true;

            Type type = t.GetType();

            idxBook.remove(t.title);

            if (type == typeof(Word))
            {   
                words.Remove((Word)t);
            }

            if (type == typeof(Expression))
                expressions.Remove((Expression)t);

            if (type == typeof(Novel))
                novels.Remove((Novel)t);

            return false;
        }

        private bool remove(Novel nvl)
        {
            return remove((Text)nvl);
        }

        private bool remove(Expression exp)
        {
            return remove((Text)exp);
        }

        private bool remove(Word wrd)
        {
            return remove((Text)wrd);
        }

        /*---------------------
         LIST
         ----------------------
             */


        // FLAG = {w,e,n}
        public List<string> list(int FLAG = 0b0000111)
        {
            List<string> ret = new List<string>();
            if( (FLAG & Dictionary.FLAG_W) == Dictionary.FLAG_W  )
            {
                ret.AddRange(list_w());
            }

            if ((FLAG & Dictionary.FLAG_E) == Dictionary.FLAG_E)
            {
                ret.AddRange(list_e());
            }

            if ((FLAG & Dictionary.FLAG_N) == Dictionary.FLAG_N )
            {
                ret.AddRange(list_n());
            }
            return ret;
        }

        private List<string> list_w()
        {
            List<string> list_w = new List<string>();
            int i = 0; 
            for (i = 0; i < getWordsCount(); i++)
            {
                list_w.Add(getWord(i).title+" (w)");
            }

            return list_w;
        }

        private List<string> list_n()
        {
            List<string> list_n = new List<string>();
            int i = 0;
            for (i = 0; i < getNovelsCount(); i++)
            {
                list_n.Add(getNovel(i).title+ " (n)");
            }

            return list_n;
        }

        private List<string> list_e()
        {
            List<string> list_e = new List<string>();
            int i = 0;
            for (i = 0; i < getExpressionsCount(); i++)
            {
                list_e.Add(getExpression(i).title+" (e)");
            }

            return list_e;
        }

        
        /**-----------------------
            get methods          |
            ----------------------*/

        public Text getText(int idArray)
        {
            int wrdCount = getWordsCount();
            if (idArray < wrdCount)
                return words[idArray];

            int exprCount = getExpressionsCount();
            if (idArray < wrdCount + exprCount)
                return expressions[idArray - wrdCount];
            
            if (idArray < wrdCount + exprCount + getNovelsCount())
                return novels[idArray - wrdCount - exprCount ];

            return null;
        }

        //identificatore unico per ogni text
        // words -> numero della prola nella words
        // expressions -> numero dell'espressione nelle espressioni + num. parole
        // novelle -> numero della novella nelle novelle + num. espres. + num. parole
        public int getIdArrayOfText(Text t)
        {
            Type type = t.GetType();
            if (type == typeof(Word))
                return  words.IndexOf( (Word)t );

            if (type == typeof(Expression))
                return expressions.IndexOf((Expression)t)+words.Count;

            if (type == typeof(Novel))
                return novels.IndexOf((Novel)t)+words.Count+expressions.Count;

            return -1;
        }


        public Word getWord(int idx)
        {
            if (idx < words.Count) return words[idx];
            else return null;
        }

        public Expression getExpression(int idx)
        {
            if (idx < expressions.Count) return expressions[idx];
            else return null;
        }

        public Novel getNovel(int idx)
        {
            if (idx < novels.Count) return novels[idx];
            else return null;
        }

        public int getWordsCount()
        {
            return words.Count;
        }

        public int getExpressionsCount()
        {
            return expressions.Count;
        }

        public int getNovelsCount()
        {
            return novels.Count;
        }

        public int getDefinitionsOfWordsCount()
        {
            int count = 0;
            foreach (Word w in words)
            {
                count += w.getDefinitionCount();
            }
            return count;
        }

        public int getWordsCountWithoutTranslation()
        {
            int ret = 0;
            foreach (Word wrd in words) {
                if (!wrd.hasADefinitionWithTranslation())
                    ret++;
            }
            return ret;
        }
        public int getExpressionsCountWithoutTranslation()
        {

            int ret = 0;
            foreach(Expression expr in expressions)
            {
                if (expr.getTranslationCount() == 0)
                    ret++;
            }
            return ret;
        }
        public int getNovelsCountWithoutTranslation()
        {

            int ret = 0;
            foreach (Novel nvl in novels)
            {
                if (nvl.getTranslationCount() == 0)
                    ret++;
            }
            return ret;
        }

        public int getElemsCount()
        {
            return getWordsCount() + getExpressionsCount() + getNovelsCount();
        }

        public string toString()
        {
            string wds= "";
            foreach (Word w in words)
                wds += w.toString() + "\n  ";

            string exps = "";
            foreach (Expression e in expressions)
                exps += e.toString() + "\n  ";

            string novs = "";
            foreach (Novel n in novels)
                novs += n.toString() + "\n  ";
            
            string ret = "Dictionary{  "+
                         "name:"+_name+"; "
                         +"lang:"+_language+";  "+
                         "dataCreation:"+dataCreation.ToString()+";}\n"+
                         wds+exps+novs;

            return ret;
        }

        private void sortWords()
        { words.Sort(delegate (Word wrd1, Word wrd2) { return wrd1.title.CompareTo(wrd2.title); }   ); }

        /**---------------------
            FIND METHODS
             ------------------*/

        public Text find(string title)
        {
            return idxBook.search(title);
        }
        public Text find(string title, int type)
        {
            if (title == null )
                return null;

            Text ret = idxBook.search(title);
            if (ret == null)
                return null;

            if(type == FLAG_W && ret.GetType() != typeof(Word)  ) 
            {
                ret = null;
            }

            if (type == FLAG_E && ret.GetType() != typeof(Expression))
            {
                ret = null;
            }

            if (type == FLAG_N && ret.GetType() != typeof(Novel))
            {
                ret = null;
            }

            return ret;
        }

        public Word findWord(string word)
        {
            return (Word)find(word, FLAG_W);
        }

        public Expression findExp(string title)
        {
            return (Expression)find(title, FLAG_E);
        }

        public Novel findNovel(string title)
        {
            return (Novel)find(title, FLAG_N);
        }

        public void init()
        {
            sortWords();
            createDateIdx();
        }

        /**------------------------
         DATA INDEDXING METHODS
            ----------------------- */

        // crea un index per le date
        private void createDateIdx()
        {
            dateIdxArray.Add(0);
            
            maxIndexedIndex = 1;

            updateDateIdx();
        }
        
        // aggiorna le date ogni volta che si aggiunge una nuova parola
        private void updateDateIdx()
        {
            int idx = 0;
            for (int cntDate = maxIndexedIndex; cntDate < words.Count; cntDate++)
            {
                idx = getClosestDate(words[cntDate].getLastVisitDate());
                dateIdxArray.Insert(idx, cntDate);
            }
            maxIndexedIndex = words.Count;
        }

        // restituisce la data più recente della lista
        private int getClosestDate(String date)
        {
            DateTime dtmDate = DateTime.Parse(date);
            int cntIdx = 0;
            for (cntIdx = dateIdxArray.Count-1; cntIdx >= 0; cntIdx--)
            {
                DateTime dtmCompared = DateTime.Parse( words[dateIdxArray[cntIdx] ].getLastVisitDate() );
                if( dtmDate.CompareTo(dtmCompared) >= 0) {
                    break;   
                }
            }
            return cntIdx+1;
        }

        public List<Word> wrdRemind(int n)
        {
            if (n > words.Count())
                n = words.Count();

            List<Word> ret = new List<Word>();
            int idx;
            for (int i = 0; i < n; i++) {
                idx = dateIdxArray[i];
                ret.Add(words[idx]);
                dateIdxArray.Add(idx);
            }
            dateIdxArray.RemoveRange(0,n);


            foreach(Word r in ret)
            {
                r.updateLastVisit();
            }
            return ret;
        }
       
    }



    public class Dict_ITA : Dictionary
    {
        // inte. = interiezione o esclamativo
        //POS = part of speech 
        public static List<String> POS = new List<string>() { "sost.", "agg.", "arti.", "prono.", "numer.", "vrb.", "avv.", "prep.", "congiu.", "inte." };
        
    }
    /**------------------------------------------------------------
     *                                                            |
        Text is the "mother" class of Word,Expression and Novel   |
                                                                  |
     --------------------------------------------------------------*/

    public class Text
    {
        protected string _title ;
        protected string _origin;
        protected string _note;
        protected DateTime creation_date;
        protected DateTime lastVisit_date;

        public string getCreationDate()
        {
            return creation_date.Day+"/"+creation_date.Month+"/"+creation_date.Year;
        }

        public string getLastVisitDate()
        {
            return lastVisit_date.Day + "/" + lastVisit_date.Month + "/" + lastVisit_date.Year;
        }

        public string title
        {
            get => _title;
            set => _title = value;
        }

        public string origin
        {
            get => _origin;
            set => _origin = value;
        }

        public string note
        {
            get => _note;
            set => _note = value;
        }

        public Text()
        {
            creation_date = DateTime.UtcNow;
        }

        public Text(string title, string origin, string note, DateTime creation_date, DateTime lastVisit_date)
        {
            _title = title ?? throw new ArgumentNullException(nameof(title));
            _origin = origin ?? throw new ArgumentNullException(nameof(origin));
            _note = note ?? throw new ArgumentNullException(nameof(note));
            this.creation_date = creation_date;
            this.lastVisit_date = lastVisit_date;
        }

        public Text(string title, string origin, string note)
        {
            _title = title ?? throw new ArgumentNullException(nameof(title));
            _origin = origin ?? throw new ArgumentNullException(nameof(origin));
            _note = note ?? throw new ArgumentNullException(nameof(note));
            this.creation_date = DateTime.UtcNow;
        }

        public void updateLastVisit()
        {
            this.lastVisit_date = DateTime.UtcNow;
        }

        public virtual string toString()
        {
            string tmp_origin = origin.Replace("\n","\\n");
            string tmp_note = note.Replace("\n","\\n");
            string ret = "Text{  title:"+_title+";"+  "creation date:"+creation_date.ToString() + ";  last visit date:"+ lastVisit_date.ToString()+ ";}\n"
                         +"origin:["+tmp_origin+"];\n"
                         +"note:["+tmp_note+"];\n";
            return ret;
        }


    }


    /** ---------------------------------------------
     *                                              |  
         Word, it uses Definition and Form classes  |       
                                                    |
        --------------------------------------------- */


    public class Word : Text
    {
        private List<Definition> definitions;
        private List<Form> forms;
        private string _type;

        public Word() : base()
        {
            definitions = new List<Definition>();
            forms = new List<Form>();
        }

        public Word(string word, string origin, string note, DateTime creationDate, DateTime lastVisit_date, string type)
            : base(word,origin,note,creationDate,lastVisit_date)
        {
           _type = type;
            definitions = new List<Definition>();
            forms = new List<Form>();
        }

        public Word(string word, string origin, string note, string type)
            : base(word, origin, note)
        {
            _type = type;
            definitions = new List<Definition>();
            forms = new List<Form>();
        }

        public string getType()
        {
            return _type;
        }

        public void setType(string type)
        {
            this._type = type;
        }

        public void addForm(Form f)
        {
            if(f != null) forms.Add(f);
        }

        public void addDefinition(Definition f)
        {
            if(f != null) definitions.Add(f);
        }
        
        public Definition getDefinition(int idx)
        {
            if (idx < definitions.Count) return definitions[idx];
            else return null;
        }

        public Definition removeDefinition(int idx)
        {
            if (idx < definitions.Count)
            {
                Definition def = definitions[idx];
                definitions.RemoveAt(idx);
                return def;
            }
            else return null;
        }
        

        public int getDefinitionCount()
        {
            return definitions.Count;
        }
        
        public List<Form> getForms()
        {
            return forms;
        }
        public override string toString()
        {
            string defs = "";
            for(int i = 0; i< definitions.Count; i++)
                defs += (i+1)+"."+definitions[i].toString()+ "\n";

            string frms= "";
            foreach (var f in forms)
                frms += f.toString() + " ";

            string ret =  base.toString()+
                          "Word{  "+
                         "type:[" + _type + "];  " +
                         "forms:["+frms+ "];  }\n" +
                         "defs:[" + defs + "];";

            return  ret;
        }

        public List<Definition> GetDefinitions()
        {
            return definitions;
        }

        public int getDefsWithTranslation()
        {
            int ret = 0;
            foreach (Definition def in definitions)
                if (def.getTranslationCount() != 0) ret++;

            return ret;
        }

        public bool hasADefinitionWithTranslation()
        {
            bool tro = false;
            foreach (Definition def in definitions) {
                if (def.getTranslationCount() != 0)
                {
                    tro = true;
                    break;
                }
            }

            return tro;
        }

        public string normalized()
        {
            string str = title + "(" + getType() + ")" + "\n";
            int cntCounter = 1;
            foreach (Definition dfnDef in GetDefinitions())
            {
                str += (cntCounter++) + "." + dfnDef.definition + "\n";
                if (dfnDef.getSynonyms().Count > 0)
                {
                    str += "SINONIMI:";
                    foreach (Text txtText in dfnDef.getSynonyms())
                        str += txtText.title + ",";

                    str = str.Remove(str.Count() - 1);
                    str += "\n";
                }

                if (dfnDef.getContraries().Count > 0)
                {
                    str += "CONTRARI:";
                    foreach (Text txtText in dfnDef.getSynonyms())
                        str += txtText.title + ",";
                    str = str.Remove(str.Count() - 1);
                    str += "";
                }
            }
            return str;
        }
    }

    /** ------------------------
         DEFINITION            |
        ----------------------- */
    public class Definition
    {
        private string _definition;
        private List<Text> synonyms;
        private List<Text> contraries;
        private List< Translation > translations;

        
        public string definition
        {
            get => _definition;
            set => _definition = value;
        }
        public Definition(string definition)
        {
            synonyms = new List<Text>();
            contraries = new List<Text>();
            translations = new List<Translation >();
            _definition = definition ?? throw new ArgumentNullException(nameof(definition));
        }

        public void addSynonym(Text t)
        {
            if (t != null) synonyms.Add(t);
        }
        public void addContrary(Text t)
        {
            if (t != null) contraries.Add(t);
        }
        public void addTranslation(Translation t)
        {
            if (t != null )
                translations.Add(t);
        }

        public void clearSynonyms()
        {
            synonyms.Clear();
        }

        public void clearContraries()
        {
            contraries.Clear();
        }

        public List<Text> getSynonyms()
        {
            return synonyms;
        }

        public List<Text> getContraries()
        {
            return contraries;
        }

        public List<Translation> getTranslations()
        {
            return translations;
        }

        public string toString()
        {
            string syns = "";
            string contrs = "";
            string trans = "";

            foreach (Text s in synonyms)
                syns += s.title + " ";

            foreach(Text s in contraries)
                contrs += s.title + " ";

            foreach(var s in translations)
                trans += s.toString()+ " ";

            string tmp_definition = _definition.Replace("\n","\\n");
            string ret= "Definition{  "+
                        "synms:["+syns+"];  "+
                        "contrs:["+contrs+"];  "+
                        "tranlas:["+trans+"];  "+
                        "}\n"+
                        "definition:[" + tmp_definition + "];  ";

            return ret;
        }

        public int getTranslationCount()
        {
            return translations.Count();
        }

    }

    /**------------------ 
     * FORM             |
     --------------------*/
    public  class Form 
    {
        private string _form;
        private string _type;

        public string form
        {
            get => _form;
            set => _form = value;
        }

        public string type
        {
            get => _type;
            set => _form = value;
        }

        public Form(string form, string type)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form));
            _type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public string toString()
        {
            string ret = "Form{  "+_type+ ":"+ _form+"  ;}";
            return ret;
        }
    }

    /** ------------------------------------------          
        Expression                                |  
       -------------------------------------------*/

    public class Expression : Text
    {
        private string _explanation;
        private string _text;
        private List<Translation> translations;

        public string explanation
        {
            get => _explanation;
            set => _explanation = value;
        }
        public string text
        {
            get => _text;
            set => _text = value;
        }
        public Expression() : base() { }

        public Expression(string title, string origin, string note, DateTime creationDate, DateTime lastVisit_date, string text,string explanation)
            : base(title, origin, note, creationDate, lastVisit_date)
        { _explanation = explanation; translations = new List<Translation>(); _text = text; }


        public Expression(string title, string origin, string note, string text, string explanation)
            : base(title, origin, note)
        { _explanation = explanation; translations = new List<Translation>();  _text = text; }


        public void addTranslation(Translation translation)
        {
            if(translation != null)
                translations.Add(translation);
        }

        public int getTranslationCount()
        {
            return translations.Count();
        }

        public List<Translation> getTranslations()
        {
            return translations;
        }

        public override string toString()
        {
            string trans = "";
            foreach (var s in translations)
                trans += s.toString() + " ";

            string ret =  base.toString()+
                          "Expression{  " +
                          "trans:[" + trans+"]; }\n"+
                          "expl:[\n" + _explanation + "];  ";

            return ret;
        }

    }
    /** ------------------------------------------
  *                                            |      
     Novel                                     |      
                                               |
                                               |
    -------------------------------------------*/
    public class Novel : Text
    {
        private string _text;
        private string _author;
        private List< Translation > translations;

        public string text
        {
            get => _text;
            set => _text = value;
        }

        public string author
        {
            get => _author;
            set => _author = value;
        }

        public int getTranslationCount()
        {
            return translations.Count();
        }

        public Novel(): base() { }
        
        public Novel(string title, string origin, string note, DateTime creationDate, DateTime lastVisit_date, string text, string author)
            :base(title, origin, note, creationDate, lastVisit_date)
        {
            if(text != null )_text = text;
            if(author != null) _author = author;
            translations = new List<Translation>();
        }

        public Novel(string title, string origin, string note, DateTime creationDate, DateTime lastVisit_date)
            : base(title, origin, note, creationDate, lastVisit_date)
        { translations = new List<Translation>(); }

        public Novel(string title, string origin, string note,string text, string author)
           : base(title, origin, note)
        {
            if (text != null) _text = text;
            if (author != null) _author = author;
            translations = new List<Translation>();
        }

        public List<Translation> getTranslations()
        {
            return translations;
        }

        public void setText(string text)
        {
            if(text != null)
                _text = text;
        }

        public void setAuthor(string author)
        {
            if (author != null)
                _author = author;
        }

        public void addTranslation(Translation translation)
        {   
            if(translation != null)
                translations.Add(translation);
        }

       public override string toString()
        {

            string trans = "";
            foreach (var s in translations)
                trans += s.toString() + " " ;

            string ret = base.toString()+
                         "Novel{  " +
                         "author:"+ _author+"\n"+
                         "trans:["+ trans + "];}\n"+
                         "text:[\n" + _text + "]  ";

            return ret;
        }
    }

    public class Translation
    {
        private int dicID;
        private string lang;
        private Text translated;

        public Translation(int dicID,string lang,Text translated)
        {
            if(dicID > 0)
             this.dicID = dicID;

            if (lang != null)
                this.lang = lang;

            if(translated != null)
             this.translated = translated;
        }

        public int getDicID()
        {
            return dicID;
        }

        public Text getTranslated()
        {
            return translated;
        }

        public string getLang()
        {
            return lang;
        }

        public String toString()
        {
            return lang + " - " + translated.title;
        }
    }


    public class IndexBook
    {
        private NodeOfIdx root;

        public IndexBook()
        {
            this.root = new NodeOfIdx();
        }

        public void add(Text txt)
        {
            add(txt.title,0,root, txt);
        }

        private void add(string title,int index,NodeOfIdx node, Text wrd)
        {
            if(index == title.Length)
            {
                node.setText(wrd);
                return;
            }

            char ch = title[index];

            if (!node.containsKey(ch))
                node.addNode(ch);

            add(title,index + 1, node.at(ch),wrd );
        }

        public Text search(string word)
        {
            return search(word, 0, root);
        }

        private Text search(string word, int index, NodeOfIdx node)
        {
            if (index == word.Length)
                return node.getText();

            char ch = word[index];
            if (!node.containsKey(ch))
                return null;

            return search(word, index + 1 , node.at(ch));
        }
        

        public bool remove(string w)
        {
            NodeOfIdx node = root;
            List<NodeOfIdx> list = new List<NodeOfIdx>();
            for( int i = 0; i< w.Length; i++)
            {
                char ch = w[i];
                if( ! node.containsKey(ch))
                    return true;

                node = node.at(ch);
                list.Add(node);
            }

            for( int i = list.Count-1; i > 0; i--)
            {
                if (list[i].hasChild())
                {
                    list[i].nullfyText();
                    break;
                }
                else list[i - 1].erase(w[i]);
            }
            return false;
        }
    }

    // il private della classe è sostituito con internal
    internal class NodeOfIdx
    {
        private Dictionary<char, NodeOfIdx> alphabet;
        private Text txt = null;

        public NodeOfIdx()
        {alphabet = new Dictionary<char, NodeOfIdx>();}

        public bool containsKey(char key)
        { return alphabet.ContainsKey(key); }

        public bool addNode(char key)
        {
            if(!containsKey (key)) {
                alphabet.Add(key,new NodeOfIdx() );
                return false;
            } return true;
        }

        public NodeOfIdx at(char key)
        {
            return containsKey(key) ? alphabet[key] : null;
        }

        public bool setText(Text wrd)
        {
            if (txt == null && wrd != null)
            {
                txt = wrd;
                return true;
            }
            else return false;
        }

        public bool nullfyText()
        {
            txt = null;
            return false;
        }

        public bool hasChild()
        {
            return alphabet.Count == 0 ? false : true ;
        }

        public bool erase(char ch)
        {
            if(!containsKey(ch))return true;
            alphabet.Remove(ch);
            return false;
        }

        internal Text getText()
        {
            return txt;
        }
    }

}
