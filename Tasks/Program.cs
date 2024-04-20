using Tasks;

Console.WriteLine("Welcome to Line Comparison Computation Application");

// Accept input from the user for the coordinates of the two points
Console.Write("Enter x-coordinate of first point: ");
double x1 = double.Parse(Console.ReadLine());

Console.Write("Enter y-coordinate of first point: ");
double y1 = double.Parse(Console.ReadLine());

Console.Write("Enter x-coordinate of second point: ");
double x2 = double.Parse(Console.ReadLine());

Console.Write("Enter y-coordinate of second point: ");
double y2 = double.Parse(Console.ReadLine());

// Create a Line object with the provided coordinates
Line line = new(x1, y1, x2, y2);

// Calculate the length of the line
double length = line.CalculateLength();

Console.WriteLine($"Length of the line: {length}");
