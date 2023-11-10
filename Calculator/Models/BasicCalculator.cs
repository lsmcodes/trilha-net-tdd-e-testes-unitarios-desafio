using Calculator.Interfaces;

namespace Calculator.Models
{
    public class BasicCalculator : ICalculator
    {
        List<string> history;
        private IConsole _console;
        private ICalculator _calculator;

        public BasicCalculator()
        {
            history = new();
        }

        public BasicCalculator(IConsole console, ICalculator calculator)
        {
            history = new();
            _console = console;
            _calculator = calculator;
        }

        public string[] Format(string expression, char signal)
        {
            string[] numbers = expression.Split($"{signal}");
            return numbers;
        }

        public void Calculate(string option, char signal = ' ')
        {
            _console.Clear();
            if(!option.Equals("5"))
            {
                _console.WriteLine($"Escreva sua expressão dessa forma: \"2{signal}2\"");
                string expression = _console.ReadLine();
                double result = 0;

                switch(option)
                {
                    case "1":
                        result = _calculator.Add(expression);
                        break;
                    case "2":
                        result = _calculator.Subtract(expression);
                        break;
                    case "3":
                        result = _calculator.Divide(expression);
                        break;
                    case "4":
                        result = _calculator.Multiply(expression);
                        break;
                    default:
                        _console.WriteLine("Opção inválida.");
                        break;
                }

                _console.WriteLine($"O resultado é {result}.");
            }
            else
            {
                _console.WriteLine("Histórico:");
                _calculator.ShowHistory().ForEach(_console.WriteLine);
            }
            
            _console.WriteLine("\nAperte qualquer tecla para voltar");
            _console.ReadKey();
        }

        public double Add(string expression)
        {
            history.Insert(0, expression);
            string[] numbers = Format(expression, '+');

            return numbers.Select(int.Parse).Aggregate((subTotal, number) => subTotal + number);
        }

        public double Subtract(string expression)
        {
            history.Insert(0, expression);
            string[] numbers = Format(expression, '-');

            return numbers.Select(int.Parse).Aggregate((subTotal, number) => subTotal - number);
        }

        public double Divide(string expression)
        {
            history.Insert(0, expression);
            string[] numbers = Format(expression, '/');

            return numbers.Select(int.Parse).Aggregate((subTotal, number) => subTotal / number);
        }

        public double Multiply(string expression)
        {
            history.Insert(0, expression);
            string[] numbers = Format(expression, 'x');
            
            return numbers.Select(int.Parse).Aggregate((subTotal, number) => subTotal * number);
        }

        public List<string> ShowHistory()
        {
            return history;
        }
    }
}