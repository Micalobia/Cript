namespace Cript.Data
{
    public class Anchor : IExecutable
    {
        public readonly Anchor None = new Anchor(_none);
        public readonly Anchor Feet = new Anchor(_feet);
        public readonly Anchor Eyes = new Anchor(_eyes);
        private const string _none = null;
        private const string _feet = "feet";
        private const string _eyes = "eyes";
        private string _value;
        private Anchor(string value) => _value = value;
        public override string ToString() => _value;
        public string GetExecute(int type) => _value == null ? null : $"anchored {_value}";
    }
}
