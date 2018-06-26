using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systeme_expert_geometrie.FACTS;
using Systeme_expert_geometrie.Inference;

namespace Systeme_expert_geometrie.Facts
{
    internal static class FactFactory
    {
        internal static IFact Fact(IFact f, Motor m)
        {
            IFact newFact;
            if (f.GetType().Equals(typeof(IntFact)))
            {
                int value = m.AskIntVAlue(f.Question);
                newFact = new IntFact(f.Name, value, null, 0);
            }
            else
            {
                bool value = m.AskBoolValue(f.Question);
                newFact = new BoolFact(f.Name, value, null, 0);
            }

            return newFact;
        }

        internal static IFact Fact(string factStr)
        {
            factStr = factStr.Trim();

            if (factStr.Contains("="))
            {
                string[] nameValue = factStr.Split(new string[] { "=", "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
                if(nameValue.Length >= 2)
                {
                    string question = null;
                    if (nameValue.Length == 3)
                    {
                        question = nameValue[2].Trim();
                    }
                    return new IntFact(nameValue[0].Trim(), int.Parse(nameValue[1].Trim()), question, 0);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                bool value = true;
                if (factStr.StartsWith("!"))
                {
                    value = false;
                    factStr = factStr.Substring(1).Trim();
                }

                string[] nameQuestion = factStr.Split(new string[] { "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
                string question = null;
                if(nameQuestion.Length == 2)
                {
                    question = nameQuestion[1].Trim();
                }
                return new BoolFact(nameQuestion[0].Trim(), value, question, 0);
            }
        }


    }
}
