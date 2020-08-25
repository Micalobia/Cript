using Syroot.BinaryData;

namespace Cript.Nbt
{
    public class TAG_End : TAG
    {
        public override sbyte ID => TAG_END;
        internal static void WriteEnd(BinaryDataWriter file) => file.Write((byte)0);
        protected internal override void WritePayload(BinaryDataWriter file) => WriteEnd(file);
        protected internal override void Write(BinaryDataWriter file) => WriteEnd(file);
        internal static sbyte ReadPayload(BinaryDataReader file) => (sbyte)(file.ReadSByte() == 0 ? 0 : throw new System.IO.IOException("Went to read a TAG_END, got something else"));
        internal static TAG_End Read(BinaryDataReader file)
        {
            ReadPayload(file);
            return new TAG_End();
        }
    }
}
