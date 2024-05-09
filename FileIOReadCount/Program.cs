namespace FileIOReadCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Read Count");
            using (var stream = File.AppendText(@"C:\Users\proir\Desktop\Training\Tasks\FileIOReadCount\temp.txt"))
            {
                int stop;
                do
                {
                    Console.WriteLine("\nEnter the input : ");
                    string input = Console.ReadLine();

                    stream.WriteLine(input);
                    Console.WriteLine("\nDo you want to add more ");
                    if (Console.ReadLine() == "y")
                    {
                        stop = 1;
                    }
                    else
                    {
                        stop = 0;
                    }

                }
                while (stop != 0);
            }
            int count = 0;
            var readfile = File.ReadAllText(@"C:\Users\proir\Desktop\Training\Tasks\FileIOReadCount\temp.txt");
            Console.WriteLine(readfile);
            Console.WriteLine("Number of lines in file "+ readfile.Split("\n").Length);
           
        }
    }
}
