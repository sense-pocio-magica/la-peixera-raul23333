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
    private const int Fps = 5;

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
            Image FonsInici = new Image("imatges/fonsInici.png");
            Image FonsFinal = new Image("imatges/fonsFinal.png");


            joc = new Joc(AlturaPantalla, AmpladaPantalla, fons, tauroMascle, tauroFamella, peixMascle, peixFamella, pop, tortugaMascle, tortugaFamella, 10, 10, 50, 50, 15, 6, 6, FonsInici, FonsFinal, _finestra);
            joc.CrearPeixos();

            var loop = GameLoop.Create(_finestra.Graphics, OnUpdate, Fps);
            loop.Start();
        });
    }

    private static void OnUpdate(GraphicsContext gfx, float dt)
    {
        joc.Iniciar(gfx);
    }
    // Xavi no he utilitzat interfícies pq com tots utilitzen els mateixos mètodes doncs és millor amb abstract,
    // i després jo he fet q quan es troben dos peixos q no interactuen doncs es queden aturats fins q algú se'ls mengi.
}