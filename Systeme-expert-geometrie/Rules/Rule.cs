using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systeme_expert_geometrie.Rules
{
    public class Rule
    {
        public List<IFact> Premises { get; set; }
        public IFact Conclusion { get; set; }

        public string Name { get; set; }

        public Rule(string name, List<IFact> premises, IFact conclusion)
        {
            Name = name;
            Premises = premises;
            Conclusion = conclusion;
        }

        public override string ToString()
        {
            return String.Format("{0} : IF ({1}) THEN {2}", Name, String.Join(" AND ", Premises), Conclusion.ToString());
        }
    }
}
