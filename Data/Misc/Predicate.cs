namespace Cript.Data
{
    public struct Predicate
    {
        public bool Negate;
        public string NamespacedID;
        public Predicate(string name, bool negate = false)
        {
            NamespacedID = name;
            Negate = negate;
        }
    }
}
