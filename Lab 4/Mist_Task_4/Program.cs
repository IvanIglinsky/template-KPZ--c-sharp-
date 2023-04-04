
    IRenderer vectorRenderer = new VectorRenderer();
    IRenderer rasterRenderer = new RasterRenderer();

    Shape circle = new Circle(vectorRenderer);
    Shape square = new Square(vectorRenderer);
    Shape triangle = new Triangle(rasterRenderer);

    circle.Draw();
    square.Draw();
    triangle.Draw();

    Console.ReadKey();






interface IRenderer
{
    void RenderAsVector();
    void RenderAsRaster();
}

class VectorRenderer : IRenderer
{
    public void RenderAsVector()
    {
        Console.WriteLine("Rendering as vector");
    }

    public void RenderAsRaster()
    {
        Console.WriteLine("Cannot render as raster");
    }
}

class RasterRenderer : IRenderer
{
    public void RenderAsVector()
    {
        Console.WriteLine("Cannot render as vector");
    }

    public void RenderAsRaster()
    {
        Console.WriteLine("Rendering as raster");
    }
}

abstract class Shape
{
    protected IRenderer renderer;

    public Shape(IRenderer renderer)
    {
        this.renderer = renderer;
    }

    public abstract void Draw();
}

class Circle : Shape
{
    public Circle(IRenderer renderer) : base(renderer)
    {
    }

    public override void Draw()
    {
        Console.Write("Drawing Circle ");
        renderer.RenderAsVector();
    }
}

class Square : Shape
{
    public Square(IRenderer renderer) : base(renderer)
    {
    }

    public override void Draw()
    {
        Console.Write("Drawing Square ");
        renderer.RenderAsVector();
    }
}

class Triangle : Shape
{
    public Triangle(IRenderer renderer) : base(renderer)
    {
    }

    public override void Draw()
    {
        Console.Write("Drawing Triangle ");
        renderer.RenderAsRaster();
    }
}