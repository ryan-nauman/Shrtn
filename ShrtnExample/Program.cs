using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shrtn;
using Shrtn.Entity.Encoders;
using Shrtn.Entity;

namespace BaseEncoderDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ulong> tests = new List<ulong>() { 0, 1, 4, 69, 932, 6903, 69382, 504967, 4028492, 902409102, 1403102045, ulong.MaxValue };

            string crockfordLower = string.Empty;
            string crockfordMixed = string.Empty;
            string zbase32 = string.Empty;
            string binary = string.Empty;
            string hexadecimal = string.Empty;

            Console.OutputEncoding = System.Text.Encoding.UTF8;

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
