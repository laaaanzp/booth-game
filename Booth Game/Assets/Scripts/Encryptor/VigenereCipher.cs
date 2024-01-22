using System.Text;

public class VigenereCipher
{
    public static string Encrypt(string text, string key)
    {
        StringBuilder result = new StringBuilder();
        int keyIndex = 0;

        for (int i = 0; i < text.Length; i++)
        {
            char currentChar = text[i];

            if (char.IsLetter(currentChar))
            {
                char offset = char.IsUpper(currentChar) ? 'A' : 'a';
                char keyChar = char.ToUpper(key[keyIndex % key.Length]);

                result.Append((char)((currentChar + keyChar - 2 * offset) % 26 + offset));
                keyIndex++;
            }
            else
            {
                result.Append(currentChar);
            }
        }

        return result.ToString();
    }

    public static string Decrypt(string text, string key)
    {
        StringBuilder result = new StringBuilder();
        int keyIndex = 0;

        for (int i = 0; i < text.Length; i++)
        {
            char currentChar = text[i];

            if (char.IsLetter(currentChar))
            {
                char offset = char.IsUpper(currentChar) ? 'A' : 'a';
                char keyChar = char.ToUpper(key[keyIndex % key.Length]);

                result.Append((char)((currentChar - keyChar + 26) % 26 + offset));
                keyIndex++;
            }
            else
            {
                result.Append(currentChar);
            }
        }

        return result.ToString();
    }
}
