namespace _7._6._multitool;
class Program
{
    enum MenuOptions { Rekenmachine=1, PasswordTester, DrawRectangle, ComputerSolver, Exit };
    static void Main(string[] args)
    {
        MultitoolMenu();
    }

    // Game menu
    static void MultitoolMenu()
    {
        Console.WriteLine("Wat wil je doen?");
        Console.WriteLine("1. Rekenmachine.");
        Console.WriteLine("2. Password tester.");
        Console.WriteLine("3. Draw rectangle.");
        Console.WriteLine("4. Computer Solver");
        Console.WriteLine("5. Sluit het programma af.");

        int userChoice = int.Parse(Console.ReadLine());

        MenuOptions choice = (MenuOptions)userChoice;

        switch (choice)
        {
            case MenuOptions.Rekenmachine:
                Calculator();
                MultitoolMenu();
                break;
            case MenuOptions.PasswordTester:
                PasswordTester();
                MultitoolMenu();
                break;
            case MenuOptions.DrawRectangle:
                DrawRectangle();
                MultitoolMenu();
                break;
            case MenuOptions.ComputerSolver:
                ComputerSolver();
                MultitoolMenu();
                break;
            case MenuOptions.Exit:
                System.Environment.Exit(1);
                break;
            default:
                Console.WriteLine("Geen geldige keuze");
                break;
        }
    }

    static void Calculator()
    {
        double number1 = Input.AskDouble("Geef cijfer 1 op: ");
        double number2 = Input.AskDouble("Geef cijfer 2 op: ");
        Console.WriteLine("Geef een operator op: ");
        string operatorChoice = Console.ReadLine();
        double resultCalculator = PerformCalculation(operatorChoice, number1, number2);
        if(resultCalculator >= 0)
        {
            Console.WriteLine($"{number1} {operatorChoice} {number2} = {resultCalculator}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{number1} {operatorChoice} {number2} = {resultCalculator}");
            Console.ResetColor();

        }

    }

    static void PasswordTester()
    {
        string userPass = Input.AskString("Geef je paswoord op? ");
        if (userPass == "C#ISSOCOOL")
        { 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Toegelaten");
             Console.ResetColor();
        }
        else
        {
             Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Verboden");
             Console.ResetColor();
        } 
    }

    static void DrawRectangle()
    {
        int lengte = Input.AskInteger("Geef de lengte op: ");
        int breedte = Input.AskInteger("Geef de breedte op: ");
        string drawSymbol = Input.AskString("Geef je teken symbool op (bvb. *, +, -)");

        printLengte(lengte, drawSymbol);
        printBreedte(breedte, lengte, drawSymbol);
        printLengte(lengte, drawSymbol);

    }

    static void ComputerSolver()
    {
        Console.WriteLine("Zet de computer aan");
        string answer1 = Input.AskString("Gaat de computer aan?");
        if(answer1=="ja")
        {
            string answer2 = Input.AskString("Zijn er foutboodschappen?");
            if(answer2 == "ja")
            {
                Console.WriteLine("Zoek de foutboodschap op via Google");
            }
            else if(answer2 == "nee")
            {
                Console.WriteLine("Hoera");
            }
            else
            {
                Console.WriteLine("Verkeerde ingave");
            }
        }
        else if(answer1=="nee")
        {
            string answer3 = Input.AskString("Brand het powerlichtje?");
            if(answer3=="ja")
            {
                string answer4= Input.AskString("Zet het scherm aan, is het probleem hiermee opgelost?");
                if(answer4=="ja")
                {
                    Console.WriteLine("Hoera");
                }
                else if(answer4=="nee")
                {
                    Console.WriteLine("Zet de computer af");
                    ComputerSolver();
                }
                else
                {
                    Console.WriteLine("Verkeerde ingave");
                }
            }
            else if(answer3=="nee")
            {
                string answer5 = Input.AskString("Controleer de kabels, is het probleem hiermee opgelost?");
                if(answer5=="ja")
                {
                    Console.WriteLine("Hoera");
                }
                else if(answer5=="nee")
                {
                    Console.WriteLine("Zet de computer af");
                    ComputerSolver();
                }
                else
                {
                    Console.WriteLine("Verkeerde ingave");
                }
            }
            else
            {
                Console.WriteLine("Verkeerde ingave");
            }
        }
        else
        {
            Console.WriteLine("Verkeerde ingave");
        }


    }

    public static double PerformCalculation(string operatorChoice, double number1, double number2)
    {
        if (operatorChoice == "+")
        {
            return number1 + number2;
        }

        if (operatorChoice == "-")
        {
            return number1 - number2;
        }

        if (operatorChoice == "*")
        {
            return number1 * number2;
        }

        if (operatorChoice == "/")
        {
            //if(!(number2 == 0))
            return number1 / number2;
            //else { Console.WriteLine("Division by zero not allowed"); }

        }
        else
        {
            throw new ArgumentException("Unexpected operator string: " + operatorChoice);
        }
    }

    // Lengte printen
    static void printLengte(int lengte, string drawSymbol)
    {
        for(int i=0; i<lengte; i++)
        {

        Console.Write(drawSymbol);

        }
        Console.WriteLine();
    }

    // Breedte printen
    static void printBreedte(int breedte, int lengte, string drawSymbol)
    {   
        for(int i= 0; i < (breedte -2); i++)
        {
            
            Console.Write("{0}{1}", drawSymbol,drawSymbol.PadLeft(lengte-1));
            Console.WriteLine();

        }
    }

    public static class Input
    {
        public static string AskString(string question)
        {
            Console.Write($"{question}");
            return Console.ReadLine() ?? string.Empty;
        }
        public static int AskInteger(string question)
        {
            while (true)
            {
                Console.Write($"{question}");
                if (int.TryParse(Console.ReadLine(), out int r))
                    return r;

            }
        }
        public static char AskChar(string question)
        {
            while (true)
            {
                Console.Write($"{question}");
                if (char.TryParse(Console.ReadLine(), out char r))
                    return r;

            }


        }

        public static double AskDouble(string question)
        {
            while (true)
            {
                Console.Write($"{question}");
                if (double.TryParse(Console.ReadLine(), out double r))
                    return r;

            }
        }
    }

    

}
