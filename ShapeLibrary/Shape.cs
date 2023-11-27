namespace ShapeLibrary
{
    public abstract class Shape
    {
        private string name;
        public string Name { get => name; init { name = value; } }
        public double Area { get; init; }

        public Shape(string name)
        {
            this.name = name;
        }

        public virtual string GetInfo() => $"Shape: {this.Name}\n";
    }
}