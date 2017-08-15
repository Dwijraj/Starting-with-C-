using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Dwijraj
{
    public class Reader : BaseIO
    {
        BinaryReader br;
        /// <summary>
        /// The position to read at
        /// </summary>
        public long position
        {
            get
            {
                return br.BaseStream.Position;
            }
            set
            {
                br.BaseStream.Position = value;
            }
        }

        /// <summary>
        /// Create a Reader to read a File
        /// </summary>
        /// <param name="path">Path to the file to read</param>
        public Reader(string path)
        {
            br = new BinaryReader(File.OpenRead(path));
            this.byteOrder = ByteOrder.BigEndian;
        }
        /// <summary>
        /// Create a Reader to read a File
        /// </summary>
        /// <param name="path">Path to the file to Read</param>
        /// <param name="bo">Order of the Byte to Read</param>
        public Reader(string path,ByteOrder bo)
        {
            br = new BinaryReader(File.OpenRead(path));
            this.byteOrder = bo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte ReadByte()
        {
            return br.ReadByte();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public sbyte ReadSByte()
        {
            return (sbyte)br.ReadByte();
        }

        public void ChangeByteOrder(ByteOrder bo)
        {
            this.byteOrder = bo;
        }

        public string ReadString(int length)
        {
            return new string( br.ReadChars(length));
        }

        public string ReadUniCodeString(int length)
        {
            if (this.byteOrder == ByteOrder.BigEndian)
            {
                return Encoding.BigEndianUnicode.GetString(br.ReadBytes(length));
            }
            else
            {
                 return Encoding.Unicode.GetString(br.ReadBytes(length));
            }
        }

        public char ReadChar()
        {
            return br.ReadChar();
        }

        public char[] ReadChars(int amount)
        {
            return br.ReadChars(amount);
        }

        public short ReadInt16()
        {
            short MyShort = br.ReadInt16();
            if (this.byteOrder == ByteOrder.BigEndian)
            {
                byte[] buffer = BitConverter.GetBytes(MyShort);
                Array.Reverse(buffer);
                return BitConverter.ToInt16(buffer,0);
            }
            return MyShort;
        }
        public ushort ReadUInt16()
        {
            ushort MyShort = br.ReadUInt16();
            if (this.byteOrder == ByteOrder.BigEndian)
            {
                byte[] buffer = BitConverter.GetBytes(MyShort);
                Array.Reverse(buffer);
                MyShort= BitConverter.ToUInt16(buffer, 0);
            }
            return MyShort;
        }

        public byte[] ReadByte(int amount)
        {
            byte[] buffer = br.ReadBytes(amount);
            if (this.byteOrder == ByteOrder.LittleEndian)
            {
                Array.Reverse(buffer);
            }
            return buffer;
        }

        public void Close()
        {
            br.Close();
        }

    }
    public abstract class BaseIO
    {
        /// <summary>
        /// Order to Read
        /// </summary>
        public enum ByteOrder { BigEndian, LittleEndian };
        protected ByteOrder byteOrder;
 


    }

    public class Writer : BaseIO
    {
        BinaryWriter bw;
        public Writer(string path)
        {
            bw = new BinaryWriter(File.OpenWrite(path));
            byteOrder = ByteOrder.BigEndian;
        }
        public Writer(string path,ByteOrder bo)
        {
            bw = new BinaryWriter(File.OpenWrite(path));
            byteOrder=bo;
        }
        public long Position {

            get { return bw.BaseStream.Position; }
            set { bw.BaseStream.Position = value; }
        }

        public void WriteByte(byte toWrite)
        {
            bw.Write(toWrite);
        }

        public void WriteBytes(byte[] toWrite)
        {
            if (byteOrder == ByteOrder.BigEndian)
            {
                Array.Reverse(toWrite);
            }
            bw.Write(toWrite);
        }
        public void WriteInt16(short a)
        {
            byte[] toWrite = BitConverter.GetBytes(a);
            if (byteOrder == ByteOrder.BigEndian)
            {
                Array.Reverse(toWrite);
            }
            bw.Write(toWrite);
        }

        public void WriteString(string ToWrite)
        {
            bw.Write(ToWrite.ToCharArray());
        }
        public void WriteUnicodeString(string ToWrite)
        {
            byte[] buffer=byteOrder== ByteOrder.BigEndian? Encoding.BigEndianUnicode.GetBytes(ToWrite) :Encoding.Unicode.GetBytes(ToWrite);
            bw.Write(buffer);
        }
        public void WriteCharacter(char ToWrite)
        {
            bw.Write(ToWrite);
        }
        public void WriteCharacters(char[] ToWrite)
        {
            
            bw.Write(ToWrite);
        }

        public void Close()
        {
            bw.Close();
        }
        public void ChangeByteOrder(ByteOrder bo)
        {
            this.byteOrder=bo;
        }

    }
}
