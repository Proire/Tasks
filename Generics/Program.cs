namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generics Practise Using Players");

            GenericPlayersList<International> InternationalPlayers = new GenericPlayersList<International>();
            InternationalPlayers.AddPlayer(new International("Will Jacks","Batsman"));
            InternationalPlayers.AddPlayer(new International("Faf Duplesis", "Batsman"));
            InternationalPlayers.AddPlayer(new International("rent Boult", "Bowler"));

            GenericPlayersList<Domestic> DomesticPlayers = new GenericPlayersList<Domestic>();
            DomesticPlayers.AddPlayer(new Domestic("Shaharukh khan", "Batsman"));
            DomesticPlayers.AddPlayer(new Domestic("Jitesh Sharma", "Batsman"));
            DomesticPlayers.AddPlayer(new Domestic("Mukesh Kumar", "Bowler"));
        }
    }
}
