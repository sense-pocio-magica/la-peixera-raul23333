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
    private int rondes = 0;
    int estat = 2;
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
        switch (estat)
        {
            case 1:
                g.DrawImage(Fons, new Rectangle(0, 0, ampladaPantalla, alturaPantalla));
                //if() estat = 2;
            break;
            case 2:
                rondes ++;
                if(rondes >= 100) estat = 3;

                g.DrawImage(Fons, new Rectangle(0, 0, ampladaPantalla, alturaPantalla));
                foreach(var p in peixera.peixos.ToList())
                {
                    if (p.EstaViu())
                    {
                        p.Dibuixar(g);
                        p.Moure();
                        p.EsTrobaAUnAltrePeix(peixera.peixera!);
                    }
        }
        peixera.NetejarMorts();
            break;
            case 3:
                g.DrawImage(Fons, new Rectangle(0, 0, ampladaPantalla, alturaPantalla));
                //if() estat = 1;
            break;
        }

    }

    public void CrearPeixos()
    {
        for(int i = 0; i < tauronsFamelles; i ++)
        {
            Peix t = new Tauro(TauroMascle, TauroFamella, this, Peix.Sexe.Mascle);
            peixera.peixos.Add(t);
            peixera.peixera[t.x, t.y] = t;
        }

        for(int i = 0; i < tauronsMascles; i ++)
        {
            Peix t = new Tauro(TauroMascle, TauroFamella, this, Peix.Sexe.Famella);
            peixera.peixos.Add(t);
            peixera.peixera[t.x, t.y] = t;
        }

        for(int i = 0; i < pops; i ++)
        {
            Peix p = new Pop(Pop, this);
            peixera.peixos.Add(p);
            peixera.peixera[p.x, p.y] = p;
        }

        for(int i = 0; i < peixosFamellas; i ++)
        {
            Peix p = new Salmo(PeixMascle, PeixFamella, this, Peix.Sexe.Famella);
            peixera.peixos.Add(p);
            peixera.peixera[p.x, p.y] = p;
        }

        for(int i = 0; i < peixosMascles; i ++)
        {
            Peix p = new Salmo(PeixMascle, PeixFamella, this, Peix.Sexe.Mascle);
            peixera.peixos.Add(p);
            peixera.peixera[p.x, p.y] = p;
        }

        for(int i = 0; i < tortuguesFamelles; i ++)
        {
            Peix t = new Tortuga(TortugaMascle, TortugaFamella, this, Peix.Sexe.Famella);
            peixera.peixos.Add(t);
            peixera.peixera[t.x, t.y] = t;
        }

        for(int i = 0; i < tortuguesMascles; i ++)
        {
            Peix t = new Tortuga(TortugaMascle, TortugaFamella, this, Peix.Sexe.Mascle);
            peixera.peixos.Add(t);
            peixera.peixera[t.x, t.y] = t;
        }
    }

    public void Criar(Peix peix, Peix mare)
    {
        switch (peix)
        {
            case Tauro:
                var tauroFill = new Tauro(TauroMascle, TauroFamella, this);
                tauroFill.DireccioAct = tauroFill.DireccioAleatoriaFill(mare.DireccioAct, peix.DireccioAct);
                peixera.peixos.Add(tauroFill);
                peixera.peixera[tauroFill.x, tauroFill.y] = tauroFill;
            break;
            case Tortuga:
                var tortugaFill = new Tortuga(TortugaMascle, TortugaFamella, this);
                tortugaFill.DireccioAct = tortugaFill.DireccioAleatoriaFill(mare.DireccioAct, peix.DireccioAct);
                peixera.peixos.Add(tortugaFill);
                peixera.peixera[tortugaFill.x, tortugaFill.y] = tortugaFill;
            break;
            case Salmo:
                var peixFill = new Salmo(PeixMascle, PeixFamella, this);
                peixFill.DireccioAct = peixFill.DireccioAleatoriaFill(mare.DireccioAct, peix.DireccioAct);
                peixera.peixos.Add(peixFill);
                peixera.peixera[peixFill.x, peixFill.y] = peixFill;
            break;
        }
    }
}