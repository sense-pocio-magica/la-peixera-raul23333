namespace Joc;

using System.Runtime.ConstrainedExecution;
using System.Text;
using Heirloom;
using Heirloom.Desktop;

abstract class Peix
{
    protected static Random rnd = new Random();
    protected Joc joc;
    private const int AmpleCasella = 60;
    private const int AltCasella = 40;   
    public enum Sexe
    {
        Famella, Mascle
    }
    public Sexe sexe;
    public bool viu = true;
    protected Direccio direccioAct;
    public Direccio DireccioAct
    {
        get => direccioAct;
        set => direccioAct = value;
    }
    protected bool EsUnaCria = true;
    public enum Direccio
    {
        Dreta, Esquerra, Adalt, Abaix
    }
    public int x, y ;
    protected int novaX, novaY;
    protected Image Imatge;

    public Peix(Image imatgeMascle, Image imatgeFamella, Joc j, Sexe? sexeOpcional = null)
    {
        joc = j;
        if (sexeOpcional.HasValue) sexe = sexeOpcional.Value;
        else GenerarSexeRandom();

        Imatge = sexe == Sexe.Mascle ? imatgeMascle : imatgeFamella;
        DireccioInicial();
        GenerarPosicioRandom();
    }

    public virtual void GenerarPosicioRandom()
    {
        if (EsUnaCria)
        {
            y = rnd.Next(0, 20);
            x = rnd.Next(0, 20);
            EsUnaCria = false;
        }
    }
    public Rectangle Rect()
    {
        return new Rectangle (x * AmpleCasella, y * AltCasella, AmpleCasella, AltCasella);
    }

    public Sexe QuinSexeEs()
    {
        return sexe;
    }

    public void CanviarDireccio()
    {
        Direccio novaDireccio;

        do
        {
            novaDireccio = (Direccio)rnd.Next(0, 4);
        } while(direccioAct == novaDireccio);
        direccioAct = novaDireccio;
    }

    protected void GenerarSexeRandom()
    {
        sexe = (Sexe)rnd.Next(0, 2);
    }

    public virtual void DireccioInicial()
    {
        direccioAct = (Direccio)rnd.Next(0, 4);
    }

    public void Dibuixar(GraphicsContext g)
    {
        g.DrawImage(Imatge, Rect());
    }
    public virtual void Moure()
    {
        novaX = x;
        novaY = y;

        switch (direccioAct)
        {
            case Direccio.Dreta:
                novaX = (x + 1) % 20;
            break;

            case Direccio.Esquerra:
                novaX = (x - 1 + 20) % 20;
            break;

            case Direccio.Adalt:
                novaY = (y - 1 + 20) % 20;
            break;

            case Direccio.Abaix:
                novaY = (y + 1) % 20;
            break;
        }
    }

    public virtual void EsTrobaAUnAltrePeix(Peix[,] peixera)
    {
        Peix enemic = peixera[novaX, novaY];
        if (enemic is null)
        {
            peixera[x, y] = null;
            y = novaY;
            x = novaX;
            peixera[novaX, novaY] = this;
        }
        else
        {
            Interactuar(enemic, this);
        }
    }

    public abstract void Interactuar(Peix enemic, Peix mare);

    public bool EstaViu()
    {
        return viu;
    }
    public void Mor()
    {
        viu = false;
    }

    public Direccio DireccioAleatoriaFill(Direccio pare, Direccio mare)
    {
        Direccio nova;
        do
        {
            nova = (Direccio)rnd.Next(0, 4);
        } while (nova == pare || nova == mare);
        return nova;
    }
}
