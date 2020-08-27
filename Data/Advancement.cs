namespace Cript.Data
{
    public struct Advancement
    {
        public string NamespacedID;
        public bool Value;
        public string Criteria;
        public Advancement(string namespacedID, bool value = true, string criteria = null)
        {
            NamespacedID = namespacedID;
            Value = value;
            Criteria = criteria;
        }
        public override string ToString() => $"{NamespacedID}={(Criteria == null ? Value.ToString() : $"{{{Criteria}={Value}}}")}";
    }
}
