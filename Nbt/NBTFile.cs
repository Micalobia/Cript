using Ionic.Zlib;
using Syroot.BinaryData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cript.Nbt
{
    /// <summary>
    /// Represets an NBT File, can be compressed or uncompressed
    /// </summary>
    public sealed class NBTFile : TAG_Compound
    {
        /// <summary>
        /// Writes an uncompressed NBT file to the designated path
        /// </summary>
        /// <param name="path">The path to write to</param>
        public void Write(string path)
        {
            using (FileStream f = new FileStream(path, FileMode.Create)) Write(f);
        }

        internal void Write(Stream stream)
        {
            using (BinaryDataWriter w = new BinaryDataWriter(stream, Encoding.UTF8, true))
            {
                w.ByteOrder = ByteOrder.BigEndian;
                Write(w);
            }
        }

        /// <summary>
        /// Writes a compressed NBT file to the designated path
        /// </summary>
        /// <param name="path">The path to write to</param>
        public void WriteGZip(string path)
        {
            using (FileStream f = new FileStream(path, FileMode.Create))
            using (GZipStream g = new GZipStream(f, CompressionMode.Compress, CompressionLevel.BestCompression, true))
                Write(g);
        }

        /// <summary>
        /// Reads an NBT file and puts it in an NBTFile object
        /// </summary>
        /// <param name="path">The path to read from</param>
        /// <returns>The NBTFile object</returns>
        public static NBTFile FromFile(string path)
        {
            using (FileStream f = new FileStream(path, FileMode.Open))
            {
                NBTFile ret = new NBTFile();
                bool iscomp = true;
                int _b = f.ReadByte();
                if (_b == -1 || _b != 0x1f) iscomp = false;
                iscomp = iscomp ? f.ReadByte() == 0x8b : iscomp;
                f.Seek(0L, SeekOrigin.Begin);
                f.Seek(0L, SeekOrigin.Begin);
                using (MemoryStream m = new MemoryStream((int)f.Length))
                {
                    if (iscomp) using (GZipStream g = new GZipStream(f, CompressionMode.Decompress, true)) g.CopyTo(m, (int)f.Length);
                    else f.CopyTo(m);
                    m.Seek(1L, SeekOrigin.Begin);
                    using (BinaryDataReader b = new BinaryDataReader(m, Encoding.UTF8, true))
                    {
                        b.ByteOrder = ByteOrder.BigEndian;
                        ret = Read(b).ToFile();
                    }
                }
                return ret;
            }
        }
    }
}
