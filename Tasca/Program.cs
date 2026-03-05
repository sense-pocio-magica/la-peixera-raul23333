namespace Joc;
 
using System.Runtime.ConstrainedExecution;
using Heirloom;
using Heirloom.Desktop;

internal class Program
{
    private static Window _finestra = null!;
    private static Joc joc;
    private const int AmpladaPantalla = 1200;
    private const int AlturaPantalla = 800;
    private const int Fps = 1;

    private static void Main()
    {
        
        Application.Run(() =>
        {
            _finestra = new Window("Peixera", (AmpladaPantalla, AlturaPantalla)) { IsResizable = false };
            _finestra.MoveToCenter();

            Directory.SetCurrentDirectory(AppContext.BaseDirectory); // Chatgpt per tema imatges

            Image fons = new Image("imatges/fons.png");
            Image tauroMascle = new Image("imatges/tauroMascle.png");
            Image tauroFamella = new Image("imatges/tauroFamella.png");
            Image peixMascle = new Image("imatges/peixMascle.png");
            Image peixFamella = new Image("imatges/peixFamella.png");
            Image pop = new Image("imatges/pop.png");
            Image tortugaMascle = new Image("imatges/tortugaMascle.png");
            Image tortugaFamella = new Image("imatges/tortugaFamella.png");


            joc = new Joc(AlturaPantalla, AmpladaPantalla, fons, tauroMascle, tauroFamella, peixMascle, peixFamella, pop, tortugaMascle, tortugaFamella, 10, 10, 50, 50, 15, 3, 3);
            joc.CrearPeixos();

            var loop = GameLoop.Create(_finestra.Graphics, OnUpdate, Fps);
            loop.Start();
        });
    }

    private static void OnUpdate(GraphicsContext gfx, float dt)
    {
        joc.Iniciar(gfx);
    }
}