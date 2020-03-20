using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            ScenariuUnu();
        }

        static void ScenariuUnu()
        {
            var scenarioOne = new ScenariuUnu();
            var refUnu = new SelfReference();
            refUnu.Name = "Prima referinta";
            scenarioOne.AddReference(refUnu);

            var refDoi = new SelfReference();
            refDoi.Name = "A doua referinta";
            refDoi.ParentSelfReference = refUnu;
            scenarioOne.AddReference(refDoi);

            var refTrei = new SelfReference();
            refTrei.Name = "A treia referinta";
            refTrei.ParentSelfReference = refDoi;
            scenarioOne.AddReference(refTrei);

            foreach (var reference in scenarioOne.GetAllReferences())
            {
                if (reference.ParentSelfReference != null)
                    Console.WriteLine($"Reference {reference.Name} with parent {reference.ParentSelfReference.Name}");
            }
        }
    }
}
