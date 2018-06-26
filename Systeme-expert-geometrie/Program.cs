using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systeme_expert_geometrie.IHM;
using Systeme_expert_geometrie.Inference;
using Systeme_expert_geometrie.Rules;

namespace Systeme_expert_geometrie
{
    class Program: HumanInterface
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();


            Console.ReadLine();
        }

        public bool AskBoolValue(string question)
        {
            Console.Out.WriteLine(question + " y - n");
            string res = Console.ReadLine();
            return res.Equals("y");
        }

        public int AskIntValue(string question)
        {
            Console.WriteLine(question);
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void PrintFacts(List<IFact> facts)
        {
            string res = "Solution trouvées : \n";
            res += String.Join("\n", facts.Where(x => x.Level > 0).OrderByDescending(x => x.Level));
            Console.WriteLine(res);
        }

        public void PrintRules(List<Rule> rules)
        {
            string res = "";
            res += String.Join("\n", rules);
            Console.WriteLine(res);
        }

        public void Run()
        {
            // moteur
            Console.WriteLine("** Création du moteur **");
            Motor m = new Motor(this);

            //règles
            Console.WriteLine("** Ajout des règles **");
            m.AddRule("R1 : IF (Ordre=3(Quel est l'ordre?)) THEN Triangle");
            m.AddRule("R2 : IF (Triangle AND Angle Droit (La figure a-t-elle au moins un angle droit?)) THEN Triangle Rectangle");
            m.AddRule("R3 : IF (Triangle AND Cotes Egaux=2(Combien la figure a-t-elle de cotes egaux?)) THEN Triangle Isocele");
            m.AddRule("R4 : IF (Triangle Rectangle AND Triangle Isocele) THEN Triangle Rectangle Isocele");
            m.AddRule("R5 : IF (Triangle AND Cotes Egaux=3(Combien la figure a-t-elle de cotes egaux?)) THEN Triangle Equilateral");
            m.AddRule("R6 : IF (Ordre=4(Quel est l'ordre?)) THEN Quadrilatere");
            m.AddRule("R7 : IF (Quadrilatere AND Cotes paralleles=2(Combien y'a t-il de cotes paralleles entre eux? 0 2 4?)) THEN Trapeze");
            m.AddRule("R8 : IF (Quadrilatere AND Cotes paralleles=4(Combien y'a t-il de cotes paralleles entre eux? 0 2 4?)) THEN Parallelogramme");
            m.AddRule("R9 : IF (Parallelogramme AND Angle Droit(La figure a t-elle au moins un angle droit?)) THEN Rectangle");
            m.AddRule("R10 : IF (Parallelogramme AND Cotes Egaux=4(combien la figure a t-elle de cotes egaux?)) THEN Losange");
            m.AddRule("R11 : IF (Rectangle AND Losange) THEN Carre");


            // résolution
            while (true)
            {
                Console.WriteLine("\n** résolution");
                m.Solve();
            }
        }
    }
}
