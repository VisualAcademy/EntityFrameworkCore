using DotNetNote.Models;
using System;
using System.Linq;

namespace DotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DotNetNoteContext())
            {
                var ideas = context.Ideas.OrderBy(i => i.Id).ToList();
                foreach (var idea in ideas)
                {
                    Console.WriteLine($"{idea.Id} - {idea.Note}");
                }
            }
        }
    }
}
