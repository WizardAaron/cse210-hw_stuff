public class Square : Shape
{
    private float _side;
    public Square(float side, string color) : base(color)
    {
        _side = side;
    }
    public override double GetArea()
    {
        return _side * _side;
    }
}