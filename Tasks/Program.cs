using Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Line Comparison Computation Program!");

        // Assuming user will only give input for two lines for equality and comparison
        // Create Line objects for Line 1 and Line 2
        Line line1 = CreateLine("Line 1");
        Line line2 = CreateLine("Line 2");

        // Check equality of the two lines using equals method 
        bool areEqual = line1.Equals(line2);

        if (areEqual)
        {
            Console.WriteLine("The two lines are equal based on their endpoints.");
        }
        else
        {
            Console.WriteLine("The two lines are not equal based on their endpoints.");
        }

        // Check greater of the two lines using compare method 
        bool isgreater = line1.Compare(line2);

        if(isgreater)
        {
            Console.WriteLine("Line 1 is greater than Line 2 based on their endpoints.");
        }
        else
        {
            Console.WriteLine("Line 1 is lesser than Line 2 based on their endpoints.");
        }
    }

    // Method to accept coordinates from the user and create a Line object
    static Line CreateLine(string lineName)
    {
        Console.WriteLine($"Enter coordinates for {lineName}:");
        Console.Write("x1: ");
        double x1 = double.Parse(Console.ReadLine());
        Console.Write("y1: ");
        double y1 = double.Parse(Console.ReadLine());
        Console.Write("x2: ");
        double x2 = double.Parse(Console.ReadLine());
        Console.Write("y2: ");
        double y2 = double.Parse(Console.ReadLine());

        return new Line(x1, y1, x2, y2);
    }
}