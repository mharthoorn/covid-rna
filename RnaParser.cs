using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace covid_rna
{

    public class RnaParser
    {
        private Dictionary<string, string> AminoTable;

        private RnaParser() { }

        public static async Task<RnaParser> Build()
        {
            var table = await Data.ReadAminoCodons();
            return new RnaParser { AminoTable = table };
        }

        public IEnumerable<string> ReadTriplets(string rna)
        {
            for (int i = 0; i < rna.Length; i += 3)
            {
                var codon = rna[i..(i + 3)];
                yield return codon;

            }
        }

        public IEnumerable<Codon> ReadCodons(string rna)
        {
            foreach(var triplet in ReadTriplets(rna))
            {
                yield return TripletToCodon(triplet);
            }
        }

     
        public Codon TripletToCodon(string triplet)
        {
            var code = CodonToCode(triplet);
            var acid = FindAminoAcidByLetter(code);
            return new Codon { Triplet = triplet, AminoAcid = acid };
                

        }


        public string ReadAminos(string rna)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < rna.Length; i += 3)
            {
                var codon = rna[i..(i + 3)];
                if (AminoTable.TryGetValue(codon, out string value))
                {
                    builder.Append(value);
                }
            }
            return builder.ToString();
        }

        public char CodonToCode(string codon)
        {
            if (AminoTable.TryGetValue(codon, out string value))
            {
                return value[0];
            }
            else return '?';
        }

        public IEnumerable<char> CodonsToCodes(IEnumerable<string> codons)
        {
            foreach (var codon in codons) yield return CodonToCode(codon);
        }

        public AminoAcid FindAminoAcidByLetter(char letter)
        {
            return AminoAcids.List.Find(a => a.Letter == letter);
        }

        public string CodonName(string codon)
        {
            if (AminoTable.TryGetValue(codon, out string letter))
            {
                if (letter == "s") return "Stop";
                var acid = FindAminoAcidByLetter(letter[0]);
                return acid?.Name; 
            }
            return null;
        }
    }

    public static class RnaExtensions
    {
        public static string ToAminoString(this IEnumerable<Codon> codons)
        {
            return codons.Select(c => c.AminoAcid).AminoString();
        }

        public static string AminoString(this IEnumerable<AminoAcid> acids)
        {
            var builder = new StringBuilder();
            foreach (var acid in acids) builder.Append(acid.Letter);
            return builder.ToString();
        }

    }
}
