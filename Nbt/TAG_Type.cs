namespace Cript.Nbt
{
    public enum TAG_Type : sbyte
    {
        END = TAG.TAG_END,
        BYTE = TAG.TAG_BYTE,
        SHORT = TAG.TAG_SHORT,
        INT = TAG.TAG_INT,
        LONG = TAG.TAG_INT,
        FLOAT = TAG.TAG_FLOAT,
        DOUBLE = TAG.TAG_DOUBLE,
        BYTE_ARRAY = TAG.TAG_BYTE_ARRAY,
        STRING = TAG.TAG_STRING,
        LIST = TAG.TAG_LIST,
        COMPOUND = TAG.TAG_COMPOUND,
        INT_ARRAY = TAG.TAG_INT_ARRAY,
        LONG_ARRAY = TAG.TAG_LONG_ARRAY
    }

    internal static class TAGTypeExtension
    {
        public static sbyte Value(this TAG_Type type) => (sbyte)type;
    }

    //public abstract class TAG_List : TAG
    //{
    //    public override sbyte ID => 9;
    //    public TAG_List(string name) : base(name) { }

    //    public static (sbyte, TAG_List) Read(BinaryDataReader file)
    //    {
    //        string name = ReadName(file);
    //        (sbyte, TAG_List) t = ReadPayload(file);
    //        t.Item2.name = name;
    //        return t;
    //    }
    //    public static (sbyte, TAG_List) ReadPayload(BinaryDataReader file)
    //    {
    //        sbyte id = TAG_Byte.ReadPayload(file);
    //        int size = TAG_Int.ReadPayload(file);
    //        TAG_List mainret;
    //        switch (id)
    //        {
    //            case TAG_BYTE:
    //                {
    //                    TAG_List<TAG_Byte> ret = new TAG_List<TAG_Byte>();
    //                    for (int i = 0; i < size; i++) ret.Add(new TAG_Byte(null, TAG_Byte.ReadPayload(file)));
    //                    mainret = ret;
    //                    break;
    //                }
    //            case TAG_SHORT:
    //                {
    //                    TAG_List<TAG_Short> ret = new TAG_List<TAG_Short>();
    //                    for (int i = 0; i < size; i++) ret.Add(new TAG_Short(null, TAG_Short.ReadPayload(file)));
    //                    mainret = ret;
    //                    break;
    //                }
    //            case TAG_INT:
    //                {
    //                    TAG_List<TAG_Int> ret = new TAG_List<TAG_Int>();
    //                    for (int i = 0; i < size; i++) ret.Add(new TAG_Int(null, TAG_Int.ReadPayload(file)));
    //                    mainret = ret;
    //                    break;
    //                }
    //            case TAG_LONG:
    //                {
    //                    TAG_List<TAG_Long> ret = new TAG_List<TAG_Long>();
    //                    for (int i = 0; i < size; i++) ret.Add(new TAG_Long(null, TAG_Long.ReadPayload(file)));
    //                    mainret = ret;
    //                    break;
    //                }
    //            case TAG_FLOAT:
    //                {
    //                    TAG_List<TAG_Float> ret = new TAG_List<TAG_Float>();
    //                    for (int i = 0; i < size; i++) ret.Add(new TAG_Float(null, TAG_Float.ReadPayload(file)));
    //                    mainret = ret;
    //                    break;
    //                }
    //            case TAG_DOUBLE:
    //                {
    //                    TAG_List<TAG_Double> ret = new TAG_List<TAG_Double>();
    //                    for (int i = 0; i < size; i++) ret.Add(new TAG_Double(null, TAG_Double.ReadPayload(file)));
    //                    mainret = ret;
    //                    break;
    //                }
    //            case TAG_BYTE_ARRAY:
    //                {
    //                    TAG_List<TAG_Byte_Array> ret = new TAG_List<TAG_Byte_Array>();
    //                    for (int i = 0; i < size; i++) ret.Add(new TAG_Byte_Array(null, TAG_Byte_Array.ReadPayload(file)));
    //                    mainret = ret;
    //                    break;
    //                }
    //            case TAG_STRING:
    //                {
    //                    TAG_List<TAG_String> ret = new TAG_List<TAG_String>();
    //                    for (int i = 0; i < size; i++) ret.Add(new TAG_String(null, TAG_String.ReadPayload(file)));
    //                    mainret = ret;
    //                    break;
    //                }
    //            case TAG_LIST:
    //                {
    //                    TAG_List<TAG_List_Pair> ret = new TAG_List<TAG_List_Pair>();
    //                    (sbyte, TAG_List) t;
    //                    for (int i = 0; i < size; i++) ret.Add(new TAG_List_Pair((t = ReadPayload(file)).Item1, t.Item2));
    //                    mainret = ret;
    //                    break;
    //                }
    //            case TAG_COMPOUND:
    //                {
    //                    TAG_List<TAG_Compound> ret = new TAG_List<TAG_Compound>();
    //                    for (int i = 0; i < size; i++) ret.Add(new TAG_Compound(null, TAG_Compound.ReadPayload(file)));
    //                    mainret = ret;
    //                    break;
    //                }
    //            case TAG_INT_ARRAY:
    //                {
    //                    TAG_List<TAG_Int_Array> ret = new TAG_List<TAG_Int_Array>();
    //                    for (int i = 0; i < size; i++) ret.Add(new TAG_Int_Array(null, TAG_Int_Array.ReadPayload(file)));
    //                    mainret = ret;
    //                    break;
    //                }
    //            case TAG_LONG_ARRAY:
    //                {
    //                    TAG_List<TAG_Long_Array> ret = new TAG_List<TAG_Long_Array>();
    //                    for (int i = 0; i < size; i++) ret.Add(new TAG_Long_Array(null, TAG_Long_Array.ReadPayload(file)));
    //                    mainret = ret;
    //                    break;
    //                }
    //            case TAG_END:
    //            default:
    //                return (TAG_END, new TAG_List<TAG_End>());
    //        }
    //        return (id, mainret);
    //    }
    //}

    //internal class TAG_List_Pair : TAG
    //{
    //    public override sbyte ID => throw new NotImplementedException();

    //    protected internal override void WritePayload(BinaryDataWriter file) => throw new NotImplementedException();

    //    public sbyte type;
    //    public TAG_List list;

    //    public TAG_List_Pair(sbyte type, TAG_List list)
    //    {
    //        this.type = type;
    //        this.list = list;
    //    }
    //}
}
