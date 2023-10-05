using System;

public interface IAttribute
{
    public event EventHandler OnAttributeChanged;

    public int GetAttributeNormalized();

    public int GetAttributeValue();
}