using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systeme_expert_geometrie.FACTS
{
    public class IntFact : IFact
    {
        public string Name { get; set; }
        public object Value { get; }
        public int Level { get; set; }
        public string Question { get; set; }


        public IntFact(string name, int value, string question, int level)
        {
            Name = name;
            Value = value;
            Question = question;
            Level = level;
        }

        public override string ToString()
        {
            return String.Format("{0} = {1} ({2})", Name, Value, Level);
        }
    }
}
