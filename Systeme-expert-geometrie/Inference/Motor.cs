using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systeme_expert_geometrie.Facts;
using Systeme_expert_geometrie.FACTS;
using Systeme_expert_geometrie.IHM;
using Systeme_expert_geometrie.Rules;

namespace Systeme_expert_geometrie.Inference
{
    public class Motor
    {

        private FactsBase fDB;
        private RulesBase rDB;
        private HumanInterface ihm;

        public Motor(HumanInterface _ihm)
        {
            ihm = _ihm;
            fDB = new FactsBase();
            rDB = new RulesBase();
        }

        internal int AskIntVAlue(string p)
        {
            return ihm.AskIntValue(p);
        }

        internal bool AskBoolValue(string p)
        {
            return ihm.AskBoolValue(p);
        }

        private int CanApply(Rule r)
        {
            int maxLevel = -1;
            foreach (IFact f in r.Premises)
            {
                IFact foundFact = fDB.Search(f.Name);
                if (foundFact == null)
                {
                    if (f.Question != null)
                    {
                        foundFact = FactFactory.Fact(f, this);
                        fDB.AddFact(foundFact);
                        maxLevel = Math.Max(maxLevel, 0);
                    }
                    else
                    {
                        return -1;
                    }
                }

                if (!foundFact.Value.Equals(f.Value))
                {
                    return -1;
                }
                else
                {
                    maxLevel = Math.Max(maxLevel, foundFact.Level);
                }
            }

            return maxLevel;
        }

        private Tuple<Rule, int> FindUsableRule(RulesBase rBase)
        {
            foreach (Rule r in rBase.Rules)
            {
                int level = CanApply(r);
                if (level != -1)
                {
                    return Tuple.Create(r, level);
                }

            }
            return null;
        }

        public void Solve()
        {
            bool moreRules = true;
            RulesBase usableRules = new RulesBase();
            usableRules.Rules = new List<Rule>(rDB.Rules);
            fDB.Clear();

            while (moreRules)
            {
                Tuple<Rule, int> ruleToApply = FindUsableRule(usableRules);
                if(ruleToApply != null)
                {
                    IFact newFact = ruleToApply.Item1.Conclusion;
                    newFact.Level = ruleToApply.Item2 + 1;
                    fDB.AddFact(newFact);
                    usableRules.Remove(ruleToApply.Item1);
                }
                else
                {
                    moreRules = false;
                }
            }

            ihm.PrintFacts(fDB.Facts);
        }


        public void AddRule(string ruleStr)
        {
            string[] splitName = ruleStr.Split(new string[] { " : " }, StringSplitOptions.RemoveEmptyEntries);
            if (splitName.Length == 2)
            {
                string name = splitName[0];
                string[] splitPremConcl = splitName[1].Split(new string[] { "IF", " THEN " }, StringSplitOptions.RemoveEmptyEntries);
                if (splitPremConcl.Length == 2)
                {
                    List<IFact> premises = new List<IFact>();
                    string[] premisesStr = splitPremConcl[0].Split(new string[] { " AND " }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string prem in premisesStr)
                    {
                        IFact premise = FactFactory.Fact(prem);
                        premises.Add(premise);
                    }

                    string conclStr = splitPremConcl[1].Trim();
                    IFact conclusion = FactFactory.Fact(conclStr);

                    rDB.Add(new Rule(name, premises, conclusion));
                }
            }
        }
    }
}
