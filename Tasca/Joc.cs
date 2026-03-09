namespace Joc;

using Heirloom;
using Heirloom.Desktop;
class Joc
{
    private Image Fons, TauroMascle, TauroFamella, PeixMascle, PeixFamella, Pop, TortugaMascle, TortugaFamella, fonsInici, fonsFinal;
    private int alturaPantalla, ampladaPantalla;
    private int tauronsFamelles, tauronsMascles, peixosFamellas, peixosMascles, pops, tortuguesFamelles, tortuguesMascles;
    private Peixera peixera = new Peixera();
    private Window finestra;
    private int rondes = 0;
    int estat = 1;
    public Joc(int alturaP, int ampladaP, Image fons, Image tauroMascle, Image tauroFamella, Image peixMascle, Image peixFamella, Image pop, Image tortugaMascle, Image tortugaFamella, int tauronsF, int tauronsM, int peixosF, int peixosM, int pops, int tortuguesF, int tortuguesM, Image FonsInici, Image FonsFinal, Window Finestra)
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
        fonsInici = FonsInici;
        fonsFinal = FonsFinal;
        finestra = Finestra;
    }

    public void Iniciar(GraphicsContext g)
    {
        switch (estat)
        {
            case 1:
                g.DrawImage(fonsInici, new Rectangle(0, 0, ampladaPantalla, alturaPantalla));
                if (Input.CheckKey(Key.F1, ButtonState.Down))
                {
                    estat = 2;
                }
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
                g.DrawImage(fonsFinal, new Rectangle(0, 0, ampladaPantalla, alturaPantalla));
                MostrarRecompte(g);
                if (Input.CheckKey(Key.F2, ButtonState.Down))
                {
                    finestra.Close();
                }
            break;
        }

    }

    public void CrearPeixos()
    {
        for(int i = 0; i < tauronsFamelles; i ++)
        {
            Peix t = new Tauro(TauroMascle, TauroFamella, this, Peix.Sexe.Famella);
            peixera.peixos.Add(t);
            peixera.peixera[t.x, t.y] = t;
        }

        for(int i = 0; i < tauronsMascles; i ++)
        {
            Peix t = new Tauro(TauroMascle, TauroFamella, this, Peix.Sexe.Mascle);
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

    public void MostrarRecompte(GraphicsContext g)
    {
        var taurons = peixera.peixos.Count(p => p is Tauro && p.EstaViu());
        var salmons = peixera.peixos.Count(p => p is Salmo && p.EstaViu());
        var pops = peixera.peixos.Count(p => p is Pop && p.EstaViu());
        var tortugues = peixera.peixos.Count(p => p is Tortuga && p.EstaViu());

        g.DrawText($"Taurons: {taurons}", new Vector(50, 50), Font.Default, 40, TextAlign.Left);
        g.DrawText($"Peixos: {salmons}", new Vector(50, 80), Font.Default, 40, TextAlign.Left);
        g.DrawText($"Pops: {pops}", new Vector(50, 110), Font.Default, 40, TextAlign.Left);
        g.DrawText($"Tortugues: {tortugues}", new Vector(50, 140), Font.Default, 40, TextAlign.Left);
    } // volia fer un metode pq tot aixo es repeteix, pero clar no sabia com fer-ho pq si li passo un Peix peix 
      // no puc fer is, he buscat com fer-ho pero hauría de fer algo de type o sino un <T> que hereti de peix o algo aixi ns
}