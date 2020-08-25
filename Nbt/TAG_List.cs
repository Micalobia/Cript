using Syroot.BinaryData;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Cript.Nbt
{
    public sealed class TAG_List : TAG, IList<TAG>
    {
        public override sbyte ID => TAG_LIST;

        public int Count => ((IList<TAG>)values).Count;

        public bool IsReadOnly => ((IList<TAG>)values).IsReadOnly;

        public TAG this[int index] { get => ((IList<TAG>)values)[index]; set => ((IList<TAG>)values)[index] = value; }

        internal List<TAG> values;
        internal sbyte type;
        public static TAG_List Empty(string name = null) => new TAG_List(name, TAG_END);
        public override string ToString() => $"{Name}:[{string.Join(",", values)}]";
        public TAG_List(string name = null, TAG_Type type = TAG_END, int capacity = 1) : this(name, type.Value(), null, 1) { }
        public TAG_List(string name, sbyte type, List<TAG> raw, int capacity) : base(name)
        {
            values = raw ?? new List<TAG>(capacity);
            this.type = type;
        }
        public void Add(TAG value)
        {
            switch (type)
            {
                case TAG_END: values.Add(value as TAG_End ?? throw new Exception("Not a TAG_End")); break;
                case TAG_BYTE: values.Add(value as TAG_Byte ?? throw new Exception("Not a TAG_Byte")); break;
                case TAG_SHORT: values.Add(value as TAG_Short ?? throw new Exception("Not a TAG_Short")); break;
                case TAG_INT: values.Add(value as TAG_Int ?? throw new Exception("Not a TAG_Int")); break;
                case TAG_LONG: values.Add(value as TAG_Long ?? throw new Exception("Not a TAG_Long")); break;
                case TAG_FLOAT: values.Add(value as TAG_Float ?? throw new Exception("Not a TAG_Float")); break;
                case TAG_DOUBLE: values.Add(value as TAG_Double ?? throw new Exception("Not a TAG_Double")); break;
                case TAG_BYTE_ARRAY: values.Add(value as TAG_Byte_Array ?? throw new Exception("Not a TAG_Byte_Array")); break;
                case TAG_STRING: values.Add(value as TAG_String ?? throw new Exception("Not a TAG_String")); break;
                case TAG_LIST: values.Add(value as TAG_List ?? throw new Exception("Not a TAG_List")); break;
                case TAG_COMPOUND: values.Add(value as TAG_Compound ?? throw new Exception("Not a TAG_Compound")); break;
                case TAG_INT_ARRAY: values.Add(value as TAG_Int_Array ?? throw new Exception("Not a TAG_Int_Array")); break;
                case TAG_LONG_ARRAY: values.Add(value as TAG_Long_Array ?? throw new Exception("Not a TAG_Long_Array")); break;
            }
        }

        private void WriteEmpty(BinaryDataWriter file)
        {
            file.Write(TAG_END);
            file.Write(0);
        }

        internal static TAG_List Read(BinaryDataReader file)
        {
            sbyte id;
            return new TAG_List(ReadName(file), id = ReadType(file), ReadPayload(file, id), 1);
        }

        internal static sbyte ReadType(BinaryDataReader file) => TAG_Byte.ReadPayload(file);
        internal static List<TAG> ReadPayload(BinaryDataReader file, sbyte id)
        {
            int size = file.ReadInt32();
            List<TAG> ret = new List<TAG>(size);
            switch (id)
            {
                case TAG_END: for (int i = 0; i < size; i++) ret.Add(TAG_End.Read(file)); break;
                case TAG_BYTE: for (int i = 0; i < size; i++) ret.Add(new TAG_Byte(null, TAG_Byte.ReadPayload(file))); break;
                case TAG_SHORT: for (int i = 0; i < size; i++) ret.Add(new TAG_Short(null, TAG_Short.ReadPayload(file))); break;
                case TAG_INT: for (int i = 0; i < size; i++) ret.Add(new TAG_Int(null, TAG_Int.ReadPayload(file))); break;
                case TAG_LONG: for (int i = 0; i < size; i++) ret.Add(new TAG_Long(null, TAG_Long.ReadPayload(file))); break;
                case TAG_FLOAT: for (int i = 0; i < size; i++) ret.Add(new TAG_Float(null, TAG_Float.ReadPayload(file))); break;
                case TAG_DOUBLE: for (int i = 0; i < size; i++) ret.Add(new TAG_Double(null, TAG_Double.ReadPayload(file))); break;
                case TAG_BYTE_ARRAY: for (int i = 0; i < size; i++) ret.Add(new TAG_Byte_Array(null, TAG_Byte_Array.ReadPayload(file))); break;
                case TAG_STRING: for (int i = 0; i < size; i++) ret.Add(new TAG_String(null, TAG_String.ReadPayload(file))); break;
                case TAG_LIST:
                    sbyte _;
                    for (int i = 0; i < size; i++) ret.Add(new TAG_List(null, _ = ReadType(file), ReadPayload(file, _), 1));
                    break;
                case TAG_COMPOUND: for (int i = 0; i < size; i++) ret.Add(new TAG_Compound(null, TAG_Compound.ReadPayload(file))); break;
                case TAG_INT_ARRAY: for (int i = 0; i < size; i++) ret.Add(new TAG_Int_Array(null, TAG_Int_Array.ReadPayload(file))); break;
                case TAG_LONG_ARRAY: for (int i = 0; i < size; i++) ret.Add(new TAG_Long_Array(null, TAG_Long_Array.ReadPayload(file))); break;
                default: throw new IndexOutOfRangeException("This list has an invalid tag type");
            }
            return ret;
        }

        protected internal override void WritePayload(BinaryDataWriter file)
        {
            if (values.Count == 0)
            {
                WriteEmpty(file);
                return;
            }
            file.Write(values[0].ID);
            file.Write(values.Count);
            foreach (TAG t in this) t.WritePayload(file);
        }

        public int IndexOf(TAG item) => ((IList<TAG>)values).IndexOf(item);
        public void Insert(int index, TAG item) => ((IList<TAG>)values).Insert(index, item);
        public void RemoveAt(int index) => ((IList<TAG>)values).RemoveAt(index);
        public void Clear() => ((IList<TAG>)values).Clear();
        public bool Contains(TAG item) => ((IList<TAG>)values).Contains(item);
        public void CopyTo(TAG[] array, int arrayIndex) => ((IList<TAG>)values).CopyTo(array, arrayIndex);
        public bool Remove(TAG item) => ((IList<TAG>)values).Remove(item);
        public IEnumerator<TAG> GetEnumerator() => ((IList<TAG>)values).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IList<TAG>)values).GetEnumerator();

        //public IEnumerator<TAG> GetEnumerator()
        //{
        //    switch(type)
        //    {
        //        case TAG_END: return value.ConvertAll(_ => _ as TAG_End).GetEnumerator();
        //        case TAG_BYTE: return value.ConvertAll(_ => _ as TAG_Byte).GetEnumerator();
        //        case TAG_SHORT: return value.ConvertAll(_ => _ as TAG_Short).GetEnumerator();
        //        case TAG_INT: return value.ConvertAll(_ => _ as TAG_Int).GetEnumerator();
        //        case TAG_LONG: return value.ConvertAll(_ => _ as TAG_Long).GetEnumerator();
        //        case TAG_FLOAT: return value.ConvertAll(_ => _ as TAG_Float).GetEnumerator();
        //        case TAG_DOUBLE: return value.ConvertAll(_ => _ as TAG_Double).GetEnumerator();
        //        case TAG_BYTE_ARRAY: return value.ConvertAll(_ => _ as TAG_Byte_Array).GetEnumerator();
        //        case TAG_STRING: return value.ConvertAll(_ => _ as TAG_String).GetEnumerator();
        //        case TAG_LIST: return value.ConvertAll(_ => _ as TAG_List).GetEnumerator();
        //        case TAG_COMPOUND: return value.ConvertAll(_ => _ as TAG_Compound).GetEnumerator();
        //        case TAG_INT_ARRAY: return value.ConvertAll(_ => _ as TAG_Int_Array).GetEnumerator();
        //        case TAG_LONG_ARRAY: return value.ConvertAll(_ => _ as TAG_Long_Array).GetEnumerator();
        //        default: throw new IndexOutOfRangeException("This list has an invalid tag type");
        //    }
        //}


        //internal static TAG_List<T> ReadPayload(BinaryDataReader file) => TAG_List.ReadPayload(file).Item2 as TAG_List<T>;
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
