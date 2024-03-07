namespace OOP_ICT.Fourth;

public class NullableBankException : Exception
{
    public NullableBankException() {  }

    public NullableBankException(string message)
        : base(message)
    {

    }
    
    public NullableBankException(string message, Exception inner)
        : base(message, inner)
    {

    }
}