using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Sparc.TagCloud;

namespace TagCloud
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new TagCloudAnalyzer()
                .ComputeTagCloud(File.ReadAllLines("Tags.txt"));

            Console.WriteLine(string.Join(
                Environment.NewLine,
                words.Select(p => p.Count+" " + p.Text).ToArray()));
            Console.ReadLine();
        }
    }
}
