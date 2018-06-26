using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systeme_expert_geometrie.Rules;

namespace Systeme_expert_geometrie.IHM
{
    public interface HumanInterface
    {
        int AskIntValue(string question);
        bool AskBoolValue(string question);
        void PrintFacts(List<IFact> facts);
        void PrintRules(List<Rule> rules);
    }
}
