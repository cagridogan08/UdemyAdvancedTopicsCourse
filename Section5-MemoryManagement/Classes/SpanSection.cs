using Section2_Reflection.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Section5_MemoryManagement.Classes
{
    internal class SpanSection
    {
        public static void Demo1()
        {
            unsafe
            {
                byte* pointer = stackalloc byte[100];
                Span<byte> memory = new Span<byte>(pointer, 100);

                IntPtr unmanagedPtr = Marshal.AllocHGlobal(123);
                Span<byte> unmanagedMemory = new Span<byte>(unmanagedPtr.ToPointer(), 123);

                Marshal.FreeHGlobal(unmanagedPtr);

                char[] array = "hello".ToCharArray();
                Span<char> arrayMemory = array;
                ReadOnlySpan<char> more = "hi there".AsSpan();

                Actions.writeLine($"Out span has {more.Length} elements");

                arrayMemory.Fill('x');
                Actions.writeLine(array);
                arrayMemory.Clear();
            }
        }
    }
}
