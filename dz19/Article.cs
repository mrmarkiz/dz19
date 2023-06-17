using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace dz19
{
    [DataContract]

    internal class Article
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int SymbolNum { get; set; }

        [DataMember]
        public string Anons { get; set; }

        public Article(string name, int symbolNum, string anons)
        {
            Name = name;
            SymbolNum = symbolNum;
            Anons = anons;
        }

        public Article() : this("", 0, "")
        { }

        public override string ToString()
        {
            return $"Name: {Name}\nNumber of symbols: {SymbolNum}\nAnons: {Anons}";
        }
    }
}
