using System.Globalization;

namespace Illumonos.Extensions.Strings;

public static partial class StringExtensions
{
    /// <summary>
    /// Reverses the characters in the specified string while preserving visually combined characters, such as emoji and accented letters.
    /// </summary>
    /// <param name="value">The string to reverse.</param>
    /// <returns>
    /// A new string with the visual characters in reverse order. This includes correct handling of combined characters like emoji and letters with accents.
    /// If the input string is empty or contains only one character, it is returned unchanged.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the <paramref name="value"/> parameter is <c>null</c>.
    /// </exception>
    public static string Reverse(this string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        
        if (value.Length <= 1)
        {
            return value;
        }

        TextElementEnumerator enumerator = StringInfo.GetTextElementEnumerator(value);
        List<string> elements = [];

        while (enumerator.MoveNext())
        {
            elements.Add(enumerator.GetTextElement());
        }
        
        elements.Reverse();

        return string.Concat(elements);
    }
}