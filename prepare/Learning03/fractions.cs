using System;
using System.Diagnostics.Contracts;

public class Fraction
{   

    //The class should have two attributes for the top and bottom numbers.
    //Make sure the attributes are private.
    private int _numerator;
    private int _denominator;


    //Constructor that has no parameters that initializes the number to 1/1.
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    
    }

    //Constructor that has one parameter for the top and that initializes the denominator to 1.
    // So that if you pass in the number 5, the fraction would be initialized to 5/1.

    public Fraction(int wholeNumber)
    {
        _numerator = wholeNumber;
        _denominator = 1;
    }

    //Constructor that has two parameters, one for the top and one for the bottom.
    public Fraction(int top, int bottom)
    {
        _numerator = top;
        _denominator = bottom;
    }

    public string GetFractionString()
    {
        string text = $"{_numerator}/{_denominator}";
        return text;
    }
    public double GetDecimalValue()
    {
        // Notice that this is not stored as a member variable.
        // Is will be recomputed each time this is called.
        return (double)_numerator / (double)_denominator;
    }
}