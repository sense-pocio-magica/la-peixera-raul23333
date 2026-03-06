namespace Joc;

using System.Runtime.ConstrainedExecution;
using Heirloom;
using Heirloom.Desktop;

class Pop : Peix 
{
    public Pop(Image imatge, Joc j)
        : base (imatge, imatge, j)
    {
        sexe = Sexe.Mascle;
    }

    public override void GenerarPosicioRandom()
    {
        y = rnd.Next(0, 2) == 0 ? 0 : 19;
        x = rnd.Next(0, 20);
    }

    public override void Moure()
    {
        if(x == 0 && y == 0)
        {
            if(direccioAct == Direccio.Adalt) direccioAct = Direccio.Dreta;
            else if(direccioAct == Direccio.Esquerra) direccioAct = Direccio.Abaix;
        } 
        else if (x == 19 && y == 0)
        {
            if(direccioAct == Direccio.Abaix) direccioAct = Direccio.Dreta;
            else if(direccioAct == Direccio.Esquerra) direccioAct = Direccio.Adalt;
        }
        else if (x == 0 && y == 19)
        {
            if(direccioAct == Direccio.Dreta) direccioAct = Direccio.Abaix;
            else if(direccioAct == Direccio.Adalt) direccioAct = Direccio.Esquerra;
        }
        else if (x == 19 && y == 19)
        {
            if(direccioAct == Direccio.Dreta) direccioAct = Direccio.Adalt;
            else if(direccioAct == Direccio.Abaix) direccioAct = Direccio.Esquerra;
        }

        base.Moure();
    }

    public override void Interactuar(Peix enemic, Peix mare)
    {
        switch (enemic)
        {
            case Tauro:
                Mor();
            break;
            case Pop:
                CanviarDireccio();
            break;
        }
    }

}
