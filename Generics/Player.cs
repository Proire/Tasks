using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class GenericPlayersList<T>
    {
        public void AddPlayer(T input) { }
    }

    internal class Player(string name)
    {
        protected string Name { get; set; } = name;

    }

    internal class International(string name,string style):Player(name)
    { 
        public string style {  get; set; } = style;

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"Player Name is {Name} and Style is {style}");
        }
    }

    internal class Domestic(string name,string style):Player(name)
    {
        public string style { get; set; } = style;

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"Player Name is {Name} and Style is {style}");
        }
    }
}
