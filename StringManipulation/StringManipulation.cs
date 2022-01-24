using System.Text;

namespace Algorithms.StringManipulation;

public class StringManipulation
{
    public static int VowelsCount(string input)
    {
        int c = 0;
        var vowels = "aeoui";
        foreach (var ch in input)
        {
            if (vowels.Contains(Char.ToLower(ch)))
            {
                c++;
            }
        }

        return c;
    }

    // Reversing using Stack
    // public static string ReverseString(string input)
    // {
    //     var stack = new Stack<char>();
    //     foreach (var ch in input)
    //     {
    //         stack.Push(ch);
    //     }
    //
    //     var result = new StringBuilder();
    //     while (stack.Count != 0) result.Append(stack.Pop());
    //     return result.ToString();
    // }
    
    //Reversing without stack
    public static string ReverseString(string input)
    {
        var result = new StringBuilder();
        for (var i = input.Length - 1; i >= 0; i--) result.Append(input[i]);
        return result.ToString();
    }

    public static string ReverseOrder(string input)
    {
        var words = input.Trim().Split(" ");
        Array.Reverse(words);
        return String.Join(" ", words);
        // var result = new StringBuilder();
        // for (var i = words.Length - 1; i >= 0; i--) result.Append(words[i] + " ");
        // return result.ToString();
    }
}