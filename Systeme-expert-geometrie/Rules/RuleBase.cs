using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systeme_expert_geometrie.Rules
{
    public class RulesBase
    {
        public List<Rule> Rules { get; set; }

        public RulesBase()
        {
            Rules = new List<Rule>();
        }

        public void Clear()
        {
            Rules.Clear();
        }

        public void Add(Rule r)
        {
            Rules.Add(r);
        }

        public void Remove(Rule r)
        {
            Rules.Remove(r);
        }
    }
}
