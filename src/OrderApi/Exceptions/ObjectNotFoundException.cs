namespace OrderApi.Exceptions;

public class ObjectNotFoundException : Exception
{
    public ObjectNotFoundException(object obj) : base($"{obj} not found!")
    { }
}