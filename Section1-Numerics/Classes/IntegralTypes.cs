using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Section1_Numerics.Classess
{
    public class IntegralTypes
    {
        public static void First()
        {
            byte[] array1 = Enumerable.Range(1, 128).Select(e => (byte)e).ToArray();
            byte[] array2 = Enumerable.Range(4, 128).Select(e => (byte)e).ToArray();
            byte[] resultArray = new byte[128];
            int size = Vector<byte>.Count;

            for (int i = 0; i < array1.Length; i+=size)
            {
                var va = new Vector<byte>(array2, i);
                var vb = new Vector<byte>(array1, i);
                var result = va + vb;
                result.CopyTo(resultArray, i);
                Program.Write(resultArray[i].ToString());
            }
        }
    }
}
