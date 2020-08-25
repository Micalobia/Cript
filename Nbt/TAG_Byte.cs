using Syroot.BinaryData;

namespace Cript.Nbt
{
    public sealed class TAG_Byte : TAG_Number<sbyte>
    {
        public override sbyte ID => TAG_BYTE;
        /// <summary>
        /// The sNBT representation of the object
        /// </summary>
        /// <returns>The sNBT</returns>
        public override string ToString() => $"{Name}:{value}b";
        /// <summary>
        /// Initializes a TAG_Byte
        /// </summary>
        /// <param name="name">The name of the byte</param>
        /// <param name="value">The value of the byte</param>
        public TAG_Byte(string name = null, sbyte value = 0) : base(name, value) { }
        protected internal override void WritePayload(BinaryDataWriter file) => file.Write(value);
        internal static sbyte ReadPayload(BinaryDataReader file) => file.ReadSByte();
        internal static TAG_Byte Read(BinaryDataReader file) => new TAG_Byte(ReadName(file), ReadPayload(file));
    }
}
