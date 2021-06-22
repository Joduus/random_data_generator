using System;
using System.IO;

namespace Random_data
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.Out.WriteLine("Usage: " + System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName + " filename filesize(in GiB)");
                return;
            }
            
            string fileName = args[0];
            var fileSize = (long)Math.Pow(2, 30) * Int32.Parse(args[1]);
            
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
