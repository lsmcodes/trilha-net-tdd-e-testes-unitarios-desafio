using System.Text;
using Calculator.Models;

Console.OutputEncoding = Encoding.UTF8;

BasicCalculator calculator = new(new MyConsole(), new BasicCalculator());
bool showMenu = true;

while(showMenu)
{
    Console.Clear();
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1 - Adição");
    Console.WriteLine("2 - Subtração");
    Console.WriteLine("3 - Divisão");
    Console.WriteLine("4 - Multiplicação");
    Console.WriteLine("5 - Mostrar histórico");
    Console.WriteLine("6 - Sair");
    string option = Console.ReadLine();

    switch(option)
    {
        case "1":
            calculator.Calculate("1", '+');
            break;
        case "2":
            calculator.Calculate("2", '-');
            break;
        case "3":
            calculator.Calculate("3", '/');
            break;
        case "4":
            calculator.Calculate("4", 'x');
            break;
        case "5":
            calculator.Calculate("5");
            break;
        case "6":
            showMenu = false;
            break;
    }
}
