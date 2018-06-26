using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systeme_expert_geometrie.FACTS
{
    public class BoolFact : IFact
    {
        public string Name { get; set; }
        public object Value { get; }
        public int Level { get; set; }
        public string Question { get; set; }


        public BoolFact(string name, bool value, string question, int level)
        {
            Name = name;
            Value = value;
            Question = question;
            Level = level;
        }

        public override string ToString()
        {
            string prefix = (bool)Value ? "" : "!";
            return String.Format("{0}{1} ({2})", prefix, Name, Level);
        }
    }
}
