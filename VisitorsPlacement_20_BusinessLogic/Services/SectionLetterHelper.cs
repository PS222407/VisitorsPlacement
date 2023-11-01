using System.Text;

namespace VisitorsPlacement_20_BusinessLogic.Services;

public static class SectionLetterHelper
{
    public static string GetNextAlphabet(string input)
    {
        if (string.IsNullOrEmpty(input) || !input.All(c => c >= 'A' && c <= 'Z'))
        {
            throw new ArgumentException("Input should only contain alphabets.");
        }

        StringBuilder result = new(input);

        int lastIndex = result.Length - 1;

        result[lastIndex]++;

        for (int i = 0; i <= lastIndex; i++)
        {
            if (result[i] > 'Z')
            {
                result[i] = 'A';

                if (i == 0)
                {
                    result.Insert(0, 'A');
                }
                else
                {
                    result[i - 1]++;
                }
            }
            else
            {
                break;
            }
        }

        return result.ToString();
    }
}