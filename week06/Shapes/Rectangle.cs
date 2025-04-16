public class Rectangle : Shape
{
    private double _length;
    private double _width;
    public Rectangle(float length, float width, string color) : base(color)
    {
        _length = length;
        _width = width;
    }
    public override double GetArea()
    {
        return _length * _width;
    }
}