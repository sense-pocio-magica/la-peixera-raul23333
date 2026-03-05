namespace Joc;

using System.Runtime.ConstrainedExecution;
using System.Text;
using Heirloom;
using Heirloom.Desktop;

abstract class Peix
{
    protected static Random rnd = new Random();
    public enum Sexe
    {
        Famella, Mascle
    }
    public Sexe sexe;
    public bool viu = true;
    protected Direccio direccioAct;
    protected bool EsUnaCria = true;
    protected enum Direccio
    {
        Dreta, Esquerra, Adalt, Abaix
    }
    protected int x, y, novaX, novaY;
    protected Image Imatge;

    public Peix(Image imatge)
    {
        Imatge = imatge;
        GenerarSexeRandom();
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
        return new Rectangle (x * 60, y * 40, 60, 40);
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
    }

    protected void GenerarSexeRandom()
    {
        if (sexe == null)
        {
            sexe = (Sexe)rnd.Next(0, 2);
        }
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
            Interactuar(enemic);
        }
    }

    public abstract void Interactuar(Peix enemic);

    public bool EstaViu()
    {
        return viu;
    }
    public void Mor()
    {
        viu = false;
    }
}
