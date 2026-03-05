namespace Joc;

using System.Runtime.ConstrainedExecution;
using Heirloom;
using Heirloom.Desktop;

class Salmo : Peix 
{
    public Salmo(Image imatge)
        : base (imatge)
    {
    }

    public override void Interactuar(Peix enemic)
    {
        switch (enemic)
        {
            case Tauro:
                Mor();
            break;
            case Salmo when enemic.sexe != QuinSexeEs():
                //Criar();
            break;
            case Salmo:
                Mor();
                enemic.Mor();
            break;
        }
    }

}
