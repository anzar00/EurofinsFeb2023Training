using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Driver Code

            IDE ide = new IDE();
            ide.Languages.Add(new CSharp());
            ide.Languages.Add(new Java());
            ide.Languages.Add(new C());
            ide.WorkWithLanguages();
        }
    }
    interface ILanguage
    {
        string GetUnit();
        string GetParadigm();
        string GetName();
    }

    class IDE
    {
        //public LangJava Java { get; set; } //This is tight coupling between IDE and LangJava and should be avoidided and program to a contract principle should be followed
        //public LangCSharp CSharp { get; set; }
        //public LangC C { get; set; }

        public List<ILanguage> Languages { get; set; } = new List<ILanguage>();

        public void WorkWithLanguages()
        {
            foreach(ILanguage L in Languages)
            {
                Console.WriteLine(L.GetName());
                Console.WriteLine(L.GetUnit());
                Console.WriteLine(L.GetParadigm());
                Console.WriteLine();
            }

        }
    }

    abstract class ObjectOriented : ILanguage
    {
        public abstract string GetName();
        public string GetParadigm()
        {
            return "ObjectOriented";
        }
        public string GetUnit()
        {
            return "Class";
        }

    }

    abstract class Procedural : ILanguage
    {
        public abstract string GetName();
        public string GetUnit()
        {
            return "Function";
        }

        public string GetParadigm()
        {
            return "Procedural";
        }
    }


    class CSharp : ObjectOriented
    {
        public override string GetName()
        {
            return "CSharp";
        }
        
    }

    class C : Procedural
    {
        public override string GetName()
        {
            return "C";
        }
    }

    class Java : ObjectOriented
    {
        public override string GetName()
        {
            return "Java";
        }
    }
    }
   
