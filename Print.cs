using System;
using System.Collections.Generic;
using System.Linq;

namespace covid_rna
{
    public class Print
    {
        static int Index(char letter) => letter - 'A' + 1;
        static ConsoleColor Color(char letter)
        {
            int index = Index(letter) % 16;
            return (ConsoleColor)index;
        }

        public static void AminoAcid(AminoAcid amino)
        {
            var indent = new string(' ', Index(amino.Letter) * 2);
            Console.Write($"{amino.Name,20} | ");
            Console.ForegroundColor = Color(amino.Letter);
            Console.Write($"{indent} {amino.Letter}");
            Console.ResetColor();
            Console.Write(" ");
            Console.WriteLine(); 
        }

        public static void RnaCompare(IEnumerable<Codon> virus, IEnumerable<Codon> vaccine)
        {
            foreach (var (vir, vac) in virus.Zip(vaccine))
            {
                string star = (vir.Triplet == vac.Triplet) ? " " : "*";
                Console.WriteLine($"{star} {vir.Triplet} -- {vac.Triplet} = {vir.AminoAcid?.Name}");

            }
        }

        public static void ColorizedAminoAcidStrain(IEnumerable<Codon> strain)
        {
            foreach (var codon in strain) Print.AminoAcid(codon.AminoAcid);
        }

        public static void AminoPatternFrequencies(string aminostrain)
        {
            var dict = Patterns.Tally(aminostrain);
            var ordered = dict.Where(i => i.Value > 1).OrderByDescending(i => i.Value);
            foreach (var item in ordered)
            {
                Console.WriteLine($"{item.Value} {item.Key}");
            }
        }
    }
}
