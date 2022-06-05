

namespace TestBlazorWASM.Shared.services
{
    public  class Hexa
    {
        public static string ToHex(string word)
        {
            StringBuilder result = new();
            var bytes = Encoding.Unicode.GetBytes(word);
            foreach (var letter in bytes)
            {
                result.Append(letter.ToString("X2"));
            }


            return result.ToString();


        }
        public static string FromHex(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
        }
    }
}
