using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shrtn;
using Shrtn.Entity.Encoders;
using Shrtn.Entity;
using System.IO;

namespace BaseEncoderDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ulong> testIntegers = new List<ulong>() { 0, 1, 4, 69, 642, 932, 6903, 69382, 504967, 4028492, 902409102, 1403102045, ulong.MaxValue };

            ConsoleTests(testIntegers);
            UnicodeTests(testIntegers);

        }

        private static void UnicodeTests(List<ulong> testIntegers)
        {
            // Get executing directory and write file here
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
            string filename = "unicode-output.txt";
            string file = Path.Combine(path, filename);

            Console.WriteLine("Writing unicode test file to disk...");

            // Gogogo
            using (StreamWriter writer = new StreamWriter(file, false, Encoding.UTF8))
            {
                foreach (ulong u in testIntegers)
                {
                    writer.Write("{0}: ", u.ToString().PadLeft(20));
                    writer.WriteLine("{0}", Shorten.Encode(u, EncoderTypes.UnicodeSymbols));
                }
            }

            Console.WriteLine("Wrote file: {0}", file);
        }

        private static void ConsoleTests(List<ulong> tests)
        {
            string crockfordLower = string.Empty;
            string crockfordMixed = string.Empty;
            string zbase32 = string.Empty;
            string binary = string.Empty;
            string hexadecimal = string.Empty;

            foreach (ulong u in tests)
            {
                crockfordLower = Shorten.Encode(u);
                crockfordMixed = Shorten.Encode(u, EncoderTypes.CrockfordMixed);
                zbase32 = Shorten.Encode(u, EncoderTypes.ZBase32);
                binary = Shorten.Encode(u, new BinaryEncoder()); // just for fun
                hexadecimal = Shorten.Encode(u, EncoderTypes.Hexadecimal);

                Console.WriteLine("{0}:", u);
                Console.WriteLine("CrockfordLower: {0}".PadLeft(20), crockfordLower);
                Console.WriteLine("CrockfordMixed: {0}".PadLeft(20), crockfordMixed);
                Console.WriteLine("ZBase32: {0}".PadLeft(20), zbase32);
                Console.WriteLine("Binary: {0}".PadLeft(20), binary);
                Console.WriteLine("Hexadecimal: {0}".PadLeft(20), hexadecimal);
                Console.WriteLine();
            }
        }
    }
}
