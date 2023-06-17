using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace dz19
{
    [DataContract]

    internal class Fraction
    {
        private static string _path = "fractions.dat";

        [DataMember]
        public int Numerator { get; set; }

        [DataMember]
        public int Denominator { get; set; }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction() : this(1, 1)
        { }

        public static void Save(List<Fraction> fractions)
        {
            using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                DataContractSerializer dcs = new DataContractSerializer(typeof(List<Fraction>));
                dcs.WriteObject(fs, fractions);
            }
        }

        public static List<Fraction> Read()
        {
            List<Fraction> fracts = new List<Fraction>();
            using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                DataContractSerializer dcs = new DataContractSerializer(typeof(List<Fraction>));
                try
                {
                    fracts = (List<Fraction>)dcs.ReadObject(fs);
                }
                catch
                {
                    fracts=new List<Fraction>();
                }
            }
            return fracts;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}
