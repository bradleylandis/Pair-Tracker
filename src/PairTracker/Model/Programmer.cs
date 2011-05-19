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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) 
                return false;

          var that = (Programmer)obj;
          return this.Name ==that.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
