using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpVersion14Samples
{
    //----------------------------------------------------------------------------------------------------
    // 2. Implicit Span Conversions
    //
    //C# 14 introduces first-class support for System.Span<T> and System.ReadOnlySpan<T> in the language. 
    //----------------------------------------------------------------------------------------------------
    public class ImplicitSpanConversions
    {
        public static void ProcessSpan(Span<byte> data)
        {
            Console.WriteLine("Processing Array Data:");
            foreach (var b in data)
                Console.WriteLine(b);
        }

        public static void ProcessSpan(ReadOnlySpan<byte> data)
        {
            Console.WriteLine("Processing Span Data:");
            foreach (var b in data)
                Console.WriteLine(b);
        }
    }
}
