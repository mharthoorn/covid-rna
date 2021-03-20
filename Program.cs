using System;
using System.Linq;
using RnaAnalysis;


var parser = await RnaParser.Build();
var virus = parser.ReadCodons(Data.VirusRna).ToList();
var vaccine = parser.ReadCodons(Data.VaccineRna).ToList();

Console.WriteLine($"Virus: RNA length: {Data.VirusRna.Length}, Amino length: {virus.Count}");
Console.WriteLine($"Vaccine: RNA length: {Data.VaccineRna.Length}, Amino length: {vaccine.Count}");


Print.DiffColorizedAminoAcidStrain(virus, vaccine);

//var strainA = virus.ToAminoString();
//var strainB = vaccine.ToAminoString();
//Print.ColorizedAminoAcidStrain(virus);
//Print.AminoPatternFrequencies(strain);
