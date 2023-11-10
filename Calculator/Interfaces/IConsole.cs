namespace Calculator.Interfaces;

public interface IConsole
{
    void Clear();
    void WriteLine(string message);
    string ReadLine();
    ConsoleKeyInfo ReadKey();
}