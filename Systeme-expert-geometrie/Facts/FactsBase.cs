using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systeme_expert_geometrie.FACTS
{
    public class FactsBase
    {

        public List<IFact> Facts { get; set; }

        public FactsBase()
        {
            Facts = new List<IFact>();
        }

        public void Clear()
        {
            Facts.Clear();
        }

        public void AddFact(IFact f)
        {
            Facts.Add(f);        
        }

        public IFact Search(string name)
        {
            return Facts.FirstOrDefault(x => x.Name.Equals(name));
        }

        public object Value(string name)
        {
            IFact f = Search(name);
            if (f == null) return null;

            return f.Value;
        }

    }
}
