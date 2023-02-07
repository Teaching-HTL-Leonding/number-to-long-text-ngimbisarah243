using System;

const string INVALID_INPUT = "not a valid input!";
const string MINUS = "minus";
const int MAX = 999999999;


RunNumberFormatter();

string DigitIntoLongText(long number)
{
    string numberInText = string.Empty;
    if (number < 0) { number *= -1; numberInText += MINUS; }

    switch (number)
    {
        case 0: numberInText += "zero"; break;
        case 1: numberInText += "one"; break;
        case 2: numberInText += "two"; break;
        case 3: numberInText += "three"; break;
        case 4: numberInText += "four"; break;
        case 5: numberInText += "five"; break;
        case 6: numberInText += "six"; break;
        case 7: numberInText += "seven"; break;
        case 8: numberInText += "eight"; break;
        case 9: numberInText += "nine"; break;
    }
    return numberInText;
}

string NumberIntoLongText(long number)
{
    string numberInText = string.Empty;

    const string TEEN = "teen";
    const string TWENTY = "twenty";
    const string THIRTY = "thirty";
    const string FOURTY = "fourty";
    const string FIFTY = "fifty";
    const string SIXTY = "sixty";
    const string SEVENTY = "seventy";
    const string EIGHTY = "eighty";
    const string NINETY = "ninety";
    const string HUNDRED = "hundred";
    const string THOUSAND = "thousand";
    const string MILLION = "million";


    string numberUnderHundred = string.Empty;

    string CompileANumber(long number, long divisor, string size)
    {
        string compiledNumber = NumberIntoLongText(number / divisor) + size + NumberIntoLongText(number % divisor);

        return compiledNumber;

    }


    string NumbersUnder100(long number)
    {
        if (number < 10) { numberUnderHundred = DigitIntoLongText(number); }

        else if (number < 20)
        {
            switch (number)
            {
                case 0: numberUnderHundred = ""; break;
                case 10: numberUnderHundred = "ten"; break;
                case 11: numberUnderHundred = "eleven"; break;
                case 12: numberUnderHundred = "twelve"; break;
                case 13: numberUnderHundred = "thir" + TEEN; break;
                case 15: numberUnderHundred = "fif" + TEEN; break;
                case 18: numberUnderHundred = "eigh" + TEEN; break;
                default: numberUnderHundred = DigitIntoLongText(number % 10) + TEEN; break;
            }
        }
        else
        {
            if (number < 30) { numberUnderHundred = TWENTY; }
            else if (number < 40) { numberUnderHundred = THIRTY; }
            else if (number < 50) { numberUnderHundred = FOURTY; }
            else if (number < 60) { numberUnderHundred = FIFTY; }
            else if (number < 70) { numberUnderHundred = SIXTY; }
            else if (number < 80) { numberUnderHundred = SEVENTY; }
            else if (number < 90) { numberUnderHundred = EIGHTY; }
            else if (number < 100) { numberUnderHundred = NINETY; }

            numberUnderHundred += DigitIntoLongText(number % 10);
        }

        return numberUnderHundred;
    }


    if (number < 0) { number *= -1; numberInText += MINUS; }

    if (number < 100) { numberInText += NumbersUnder100(number); }
    else if (number < 1000) { numberInText += CompileANumber(number, 100, HUNDRED); }
    else if (number < 10000) { numberInText += CompileANumber(number, 1000, THOUSAND); }
    else if (number < 100000) { numberInText += CompileANumber(number, 1000, THOUSAND); }
    else if (number < 1000000) { numberInText += CompileANumber(number, 1000, THOUSAND); }
    else if (number < 10000000) { numberInText += CompileANumber(number, 1000000, MILLION); }
    else if (number < 100000000) { numberInText += CompileANumber(number, 1000000, MILLION); }
    else if (number < 1000000000) { numberInText += CompileANumber(number, 1000000, MILLION); }

        if (numberInText.Contains("zero")) { numberInText = numberInText.Replace("zero", ""); }
    
    return numberInText;
}


void RunNumberFormatter()
{
    string input = string.Empty;
    long number = 0;
    bool isDigit = Int64.TryParse(input, out number);

    while (input != "quit")
    {

        Console.Write("Enter a number (max 999.999.999):  ");
        input = Console.ReadLine()!;
        if (input == "quit") { break; }
        isDigit = Int64.TryParse(input, out number);
        Console.Write("NumberIntoLongText:  ");

        if (isDigit)
        {
            if (number > 0) { if (number > MAX) { Console.WriteLine(INVALID_INPUT); } }
            else { if (number < MAX * -1) { Console.WriteLine(INVALID_INPUT); } }
            if (number > 0 && number < 10) { Console.WriteLine(DigitIntoLongText(number)); }
            else if (number >= MAX * -1 && number <= MAX) { Console.WriteLine(NumberIntoLongText(number)); }
        }
        else if (!isDigit) { Console.WriteLine("not a digit"); }

    }
}

