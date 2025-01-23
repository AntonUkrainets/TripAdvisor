namespace UniversalParser.SharedKernel.Interfaces;

public interface IParser<T>
{
    IEnumerable<T> Parse(string source);

    bool CanParse(string source);
}