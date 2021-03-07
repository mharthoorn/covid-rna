using System;
using System.Linq;
using System.Threading.Tasks;

namespace covid_rna
{

    class Program
    {

        static async Task Main(string[] args)
        {
            var parser = await RnaParser.Build();
            var virus = parser.ReadCodons(Data.VirusRna).ToList();
            var vaccine = parser.ReadCodons(Data.VaccineRna).ToList();

            Console.WriteLine($"Virus: RNA length: {Data.VirusRna.Length}, Amino length: {virus.Count}");
            Console.WriteLine($"Vaccine: RNA length: {Data.VaccineRna.Length}, Amino length: {vaccine.Count}");

            var strain = virus.ToAminoString();
            Print.ColorizedAminoAcidStrain(virus);
            //Print.AminoPatternFrequencies(strain);
        }
    }
}
