namespace ShapeLibrary
{
    public abstract class Shape
    {
        private string name;
        public string Name { get => name; init { name = value; } }
        public abstract double Area { get; }

        public Shape(string name)
        {
            this.name = name;
        }

        public virtual string GetInfo() => $"Shape: {this.Name}\n";

        //public abstract double GetPerimetr(); 
    }
}