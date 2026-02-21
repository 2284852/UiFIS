using System.Drawing;


namespace pr_6
{
    public class Planet
    {
        public string Name { get; set; }
        public float OrbitRadius { get; set; }
        public float Speed { get; set; }
        public float Size { get; set; }
        public Color Color { get; set; }
        public float Angle { get; set; }
        public string Description { get; set; }

        public Planet(string name, float orbitRadius, float speed,
                     float size, Color color, float startAngle, string description = "")
        {
            Name = name;
            OrbitRadius = orbitRadius;
            Speed = speed;
            Size = size;
            Color = color;
            Angle = startAngle;
            Description = description;
        }
    }
}
