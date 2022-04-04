using System.Collections;

namespace MikroWorm
{
    public static class ByteExtensions
    {
        internal static bool Equals(this byte[] arg1, byte[] arg2) => StructuralComparisons.StructuralEqualityComparer.Equals(arg1, arg2);

        internal static byte[][] Split(this byte[] input, byte[] delimiter)
        {
            var length = delimiter.Length;

            int skip = 0;
            var result = new List<List<byte>>() { new List<byte>() };

            for (int b = (delimiter.Length - 1); b < input.Length; b++)
            {
                byte[] selected = input.Skip(skip++).Take(length).ToArray();
                if (Equals(selected, delimiter))
                {
                    result.Add(new List<byte>());
                    continue;
                }

                result.Last().Add(input[b]);
            }

            return result.Select(r => r.ToArray()).ToArray();
        }
    }
}