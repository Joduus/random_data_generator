using System;
using System.IO;

namespace Random_data
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "randomdata.dat";
            var fileSize = (long)Math.Pow(2, 30) * 5; // 5 GiB
            
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                var bytesLeft = fileSize;
                var singleWriteOperationSize = 1024;
                Byte[] buffer = new byte[singleWriteOperationSize];
                var random = new Random();
                for (; 0 < bytesLeft; bytesLeft -= singleWriteOperationSize)
                {
                    random.NextBytes(buffer);
                    binaryWriter.Write(buffer);
                }
            }
        }
    }
}
