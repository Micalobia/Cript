namespace Cript.Data
{
    public class Anchor : IExecutable
    {
        public const int None = 0;
        public const int Feet = 1;
        public const int Eyes = 2;
        public int Value { get; private set; }
        public Anchor() => Value = None;
        public Anchor(int value) => Value = value & 0b11;
        private bool HasFlag(int type) => (Value & type) > 0;
        public override string ToString()
        {
            switch(Value)
            {
                case Feet: return "feet";
                case Eyes: return "eyes";
                case None:
                default:
                    return "none";
            }
        }
        public string GetExecute(int type) => Value == None ? null : $"anchored {ToString()}";
    }
}
