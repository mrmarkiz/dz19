using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace dz19
{
    [DataContract]

    internal class Journal
    {
        private static string _path = "journals.dat";

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Publisher { get; set; }

        [DataMember]
        public DateTime PublishedAt { get; set; }

        [DataMember]
        public int PagesNum { get; set; }

        [DataMember]
        public List<Article> Articles { get; set; }

        public Journal(string name, string publisher, DateTime publishedAt, int pagesNum, List<Article> articles)
        {
            Name = name;
            Publisher = publisher;
            PublishedAt = publishedAt;
            PagesNum = pagesNum;
            Articles = articles;
        }

        public Journal() : this("", "", DateTime.MinValue, 0, new List<Article>())
        { }

        public void Init()
        {
            Console.Write("Enter name: ");
            Name = Console.ReadLine();
            Console.Write("Enter publisher: ");
            Publisher = Console.ReadLine();
            Console.Write("Enter publication date: ");
            DateTime.TryParse(Console.ReadLine(), out DateTime res);
            PublishedAt = res;
            Console.Write("Enter pages num: ");
            int.TryParse(Console.ReadLine(), out int num);
            PagesNum = num;
            string name, symNum, anons;
            List<Article> articles = new List<Article>();
            Console.WriteLine("Enter artiles info(Enter empty line to stop):");
            while (true)
            {
                Console.Write("Enter name: ");
                name = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(name))
                    break;
                Console.Write("Enter symbols num: ");
                symNum = Console.ReadLine();
                if (!int.TryParse(symNum, out num))
                    break;
                Console.Write("Enter anons: ");
                anons = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(anons))
                    break;
                articles.Add(new Article(name, num, anons));
            }
            Articles = articles;
        }

        public static void Save(List<Journal> journals)
        {
            using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                DataContractSerializer dcs = new DataContractSerializer(typeof(List<Journal>));
                dcs.WriteObject(fs, journals);
            }
        }

        public static List<Journal> Read()
        {
            List<Journal> journals = new List<Journal>();
            using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                DataContractSerializer dcs = new DataContractSerializer(typeof(List<Journal>));
                try
                {
                    journals = (List<Journal>)dcs.ReadObject(fs);
                }
                catch
                { }
            }
            return journals;
        }

        public override string ToString()
        {
            string result = $"Name: {Name}\nPublisher: {Publisher}\nPublished at: {PublishedAt.ToShortDateString()}\nNumber of pages: {PagesNum}\nArticles:\n";
            result += string.Join("\n", Articles);
            return result;
        }
    }
}
