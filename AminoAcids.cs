using System.Collections.Generic;

namespace covid_rna
{
    public class AminoAcids
    { 
        public static List<AminoAcid> List = new List<AminoAcid>
        {
            new AminoAcid { Letter = 'A', Code = "Ala", Name = "Alanine" },
            new AminoAcid { Letter = 'R', Code = "Arg", Name = "Arginine" },
            new AminoAcid { Letter = 'N', Code = "Asn", Name = "Asparagine" },
            new AminoAcid { Letter = 'D', Code = "Asp", Name = "Aspartic Acid" },
            new AminoAcid { Letter = 'C', Code = "Cys", Name = "Cysteine" },
            new AminoAcid { Letter = 'Q', Code = "Gln", Name = "Glutamine" },
            new AminoAcid { Letter = 'E', Code = "Glu", Name = "Glutamic Acid" },
            new AminoAcid { Letter = 'G', Code = "Gly", Name = "Glycine" },
            new AminoAcid { Letter = 'H', Code = "His", Name = "Histidine" },
            new AminoAcid { Letter = 'I', Code = "Ile", Name = "Isoleucine" },
            new AminoAcid { Letter = 'L', Code = "Leu", Name = "Leucine" },
            new AminoAcid { Letter = 'K', Code = "Lys", Name = "Lysine" },
            new AminoAcid { Letter = 'M', Code = "Met", Name = "Methionine" },
            new AminoAcid { Letter = 'F', Code = "Phe", Name = "Phenylanine" },
            new AminoAcid { Letter = 'P', Code = "Pro", Name = "Proine" },
            new AminoAcid { Letter = 'S', Code = "Ser", Name = "Serine" },
            new AminoAcid { Letter = 'T', Code = "Thr", Name = "Threonine" },
            new AminoAcid { Letter = 'W', Code = "Trp", Name = "Tryptophan" },
            new AminoAcid { Letter = 'Y', Code = "Tyr", Name = "Tyrosine" },
            new AminoAcid { Letter = 'V', Code = "Val", Name = "Valine" },

            new AminoAcid { Letter = 's', Code = "Ter", Name = "Stop codon" },
            new AminoAcid { Letter = '?', Code = "Unk", Name = "Unknown codon" },

        };
    }
}
