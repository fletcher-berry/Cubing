using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public enum AlgFileMode
    {
        Create,
        Open
    }

    public enum AlgFileAccess
    {
        Read, 
        ReadWrite
    }

    public class AlgFile
    {
        public int NumAlgs { get; private set; }

        private FileStream _stream;
        public AlgFileAccess FileAccess { get; private set; }
        private bool _isClosed;


        private const string headerString = "Algorithm file";

        public AlgFile(string path, AlgFileMode fileMode, AlgFileAccess fileAccess, int numAlgs = -1)
        {
            FileAccess = fileAccess;
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("path is not a valid string");
            if (!Path.GetExtension(path).Equals(".alg"))
                throw new ArgumentException("path is not the correct type of file");
            if (fileMode == AlgFileMode.Create && FileAccess == AlgFileAccess.Read)
                throw new ArgumentException("Cannot create file with only read access");
            if (fileMode == AlgFileMode.Create && numAlgs <= 0)
                throw new ArgumentException("number of algs is not positive");

            _stream = new FileStream(path, GetFileStreamMode(fileMode), System.IO.FileAccess.ReadWrite );
            if(fileMode == AlgFileMode.Create)
            {
                NumAlgs = numAlgs;
                _stream.SetLength((numAlgs + 1) * 32);
                _stream.Position = 0;
                byte[] header = Encoding.Unicode.GetBytes(headerString);
                _stream.Write(header, 0, 28);
                _stream.Write(BitConverter.GetBytes(numAlgs), 0, 4);
            }
            else
            {
                _stream.Position = 0;
                byte[] header = new byte[32];
                _stream.Read(header, 0, 32);
                for(int k = 0; k < 14; k++)
                {
                    char c = BitConverter.ToChar(header, 2 * k);
                    if (c != headerString[k])
                        throw new IOException("The file is not in the correct format");
                }
                NumAlgs = BitConverter.ToInt32(header, 28);
            }
            
            _isClosed = false;
        }

        public bool CanRead()
        {
            return !_isClosed;
        }

        public bool CanWrite()
        {
            return !_isClosed && FileAccess == AlgFileAccess.ReadWrite;
        }

        public void Close()
        {
            _stream.Close();
            _isClosed = true;
        }

        public void Flush()
        {
            _stream.Flush();
        }

        public Algorithm Read(int algNum)
        {
            if (!CanRead())
                throw new NotSupportedException("file is closed");
            if (algNum >= NumAlgs)
                throw new ArgumentOutOfRangeException("value out of range: " + algNum);
            if (algNum < 0)
                throw new ArgumentOutOfRangeException("value is negative: " + algNum);
            _stream.Position = 32 * (algNum + 1);
            byte[] algInBytes = new byte[32];
            _stream.Read(algInBytes, 0, 32);
            return new Algorithm(algInBytes);
        }

        public void Write(int algNum, Algorithm alg)
        {
            if (!CanWrite())
                throw new NotSupportedException("file is closed or does not have write permissions");
            if (algNum >= NumAlgs)
                throw new ArgumentOutOfRangeException("value out of range: " + algNum);
            if (algNum < 0)
                throw new ArgumentOutOfRangeException("value is negative: " + algNum);
            byte[] algInBytes = alg.ToByteArray();
            _stream.Position = 32 * (algNum + 1);
            _stream.Write(algInBytes, 0, 32);
        }

        private FileMode GetFileStreamMode(AlgFileMode mode)
        {
            if (mode == AlgFileMode.Create)
                return FileMode.Create;
            else
                return FileMode.Open;

        }

        private FileAccess GetFileStreamAccess(AlgFileAccess access)
        {
            if (access == AlgFileAccess.Read)
                return System.IO.FileAccess.Read;
            else return System.IO.FileAccess.ReadWrite;

        }



    }
}
