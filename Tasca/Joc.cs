namespace Joc;

using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using Heirloom;
using Heirloom.Desktop;
class Joc
{
    private Image Fons, TauroMascle, TauroFamella, PeixMascle, PeixFamella, Pop, TortugaMascle, TortugaFamella;
    private int alturaPantalla, ampladaPantalla;
    private int tauronsFamelles, tauronsMascles, peixosFamellas, peixosMascles, pops, tortuguesFamelles, tortuguesMascles;
    private Peixera peixera = new Peixera();
    public Joc(int alturaP, int ampladaP, Image fons, Image tauroMascle, Image tauroFamella, Image peixMascle, Image peixFamella, Image pop, Image tortugaMascle, Image tortugaFamella, int tauronsF, int tauronsM, int peixosF, int peixosM, int pops, int tortuguesF, int tortuguesM)
    {
        alturaPantalla = alturaP;
        ampladaPantalla = ampladaP;
        Fons = fons;
        TauroMascle = tauroMascle;
        TauroFamella = tauroFamella;
        PeixMascle = peixMascle;
        PeixFamella = peixFamella;
        Pop = pop;
        TortugaMascle = tortugaMascle;
        TortugaFamella = tortugaFamella;
        tauronsFamelles = tauronsF;
        tauronsMascles = tauronsM;
        peixosFamellas = peixosF;
        peixosMascles = peixosM;
        this.pops = pops;
        tortuguesFamelles = tortuguesF;
        tortuguesMascles = tortuguesM;
    }

    public void Iniciar(GraphicsContext g)
    {
        g.DrawImage(Fons, new Rectangle(0, 0, ampladaPantalla, alturaPantalla));
        foreach(var p in peixera.peixos)
        {
            if (p.EstaViu())
            {
                p.Dibuixar(g);
                p.EsTrobaAUnAltrePeix(peixera.peixera!);
                p.Moure();
            }
        }
        peixera.NetejarMorts();

    }

    public void CrearPeixos()
    {
        for(int i = 0; i <= tauronsFamelles; i ++) peixera.peixos.Add(new Tauro(TauroFamella));

        for(int i = 0; i <= tauronsMascles; i ++) peixera.peixos.Add(new Tauro(TauroMascle));

        for(int i = 0; i <= pops; i ++) peixera.peixos.Add(new Pop(Pop));

        for(int i = 0; i <= peixosFamellas; i ++) peixera.peixos.Add(new Salmo(PeixFamella));

        for(int i = 0; i <= peixosMascles; i ++) peixera.peixos.Add(new Salmo(PeixMascle));

        for(int i = 0; i <= tortuguesFamelles; i ++) peixera.peixos.Add(new Tortuga(TortugaFamella));

        for(int i = 0; i <= tortuguesMascles; i ++) peixera.peixos.Add(new Tortuga(TortugaMascle));
    }

    public void Criar(Peix peix)
    {
        switch (peix)
        {
            case Tauro:
                peixera.peixos.Add(new Tauro());
            break;
            case Tortuga:
                peixera.peixos.Add(new Tortuga());
            break;
            case Peix:
                peixera.peixos.Add(new Peix());
            break;
        }
    }
}