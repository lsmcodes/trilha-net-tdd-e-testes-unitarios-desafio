namespace Calculator.Interfaces;

public interface ICalculator
{
    string[] Format(string expression, char signal);
    void Calculate(string option, char signal);
    double Add(string expression);
    double Subtract(string expression);
    double Divide(string expression);
    double Multiply(string expression);
    List<string> ShowHistory();
}