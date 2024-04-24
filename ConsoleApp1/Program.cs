namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Program();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        void Program()
        {
            bool running = true;
            string[] operations = ["+", "-", "*", "/"];


            while (running)
            {
                try
                {
                    string operation = GetOperation();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Current operation: {operation}");
                    Console.ResetColor();
                    int num1 = GetNumber(1);
                    int num2 = GetNumber(2);
                    double result = Calculate(operation, num1, num2);


                    Console.WriteLine($"result is : {result}");

                    Console.WriteLine("Do you want to perform another calculation? (Y/n)");
                    string continueCalc = Console.ReadLine();

                    if (continueCalc?.ToLower() != "y" && continueCalc != "")
                    {
                        running = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }
            }

            double Calculate(string operation, int num1, int num2)
            {
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        else
                        {
                            throw new Exception(
                                "Error: Cannot divide by zero."
                            );
                        }

                        break;
                    default:
                        throw new Exception(
                            "Invalid operator.");
                }

                return result;
            }

            string GetOperation(int currentIndex = 0)
            {
                int index = currentIndex;

                Console.Clear();

                Console.WriteLine("Choose an operation");
                for (int i = 0; i < operations.Length; i++)
                {
                    if (i == index)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }

                    Console.WriteLine(operations[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    // Move up in the list
                    index = (index - 1 + operations.Length) % operations.Length;
                    return GetOperation(index);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    // Move down in the list
                    index = (index + 1) % operations.Length;
                    return GetOperation(index);
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    // User has confirmed their choice
                    // Console.Clear(); // Clear the console before returning
                    return operations[index];
                }


                Console.WriteLine("select an operation");
                var operation = Console.ReadLine();

                if (operation == null || !Array.Exists(operations, item => item == operation))
                    throw new Exception("Fucked");

                return operation;
            }

            int GetNumber(byte index)
            {
                Console.WriteLine("enter #" + index + "number");
                var number = Console.ReadLine();
                
                if (number == "")
                {
                    return GetNumber(index);
                }

                return int.Parse(number);
            }
        }
    }
}