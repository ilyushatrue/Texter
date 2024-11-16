using System.Collections;

namespace Texter.Domain.Errors.Base;
public class ErrorList : IEnumerable<Error>
{
    private readonly List<Error> _errors = new List<Error>();

    public void Add(Error error)
    {
        _errors.Add(error);
    }

    public IEnumerator<Error> GetEnumerator()
    {
        return _errors.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count => _errors.Count;

    public Error this[int index] => _errors[index];
}
