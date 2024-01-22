public class CaesarCipher
{
    public static string Encrypt(string text, int shift)
    {
        char[] result = text.ToCharArray();

        for (int i = 0; i < result.Length; i++)
        {
            if (char.IsLetter(result[i]))
            {
                char offset = char.IsUpper(result[i]) ? 'A' : 'a';
                result[i] = (char)((result[i] + shift - offset) % 26 + offset);
            }
        }

        return new string(result);
    }

    public static string Decrypt(string text, int shift)
    {
        return Encrypt(text, 26 - shift);
    }
}
