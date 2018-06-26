using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systeme_expert_geometrie
{
    public  interface IFact
    {
        string Name { get; set; }
        object Value { get; }
        int Level { get; set; }
        string Question { get; set; }

    }
}
