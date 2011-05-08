namespace PairTracker.Model
{
    public class Programmer
    {
        public static Programmer Neither = new Programmer("Neither");

        public string Name { get; private set; }
        public Programmer(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
