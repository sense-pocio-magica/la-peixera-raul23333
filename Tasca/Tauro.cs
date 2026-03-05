namespace Joc;

using System.Runtime.ConstrainedExecution;
using Heirloom;
using Heirloom.Desktop;

class Tauro : Peix 
{
    public Tauro(Image imatge)
        : base (imatge)
    {
    }

    public override void Interactuar(Peix enemic)
    {
        switch (enemic)
        {
            case Tauro when enemic.sexe != QuinSexeEs():
                //Criar();
            break;
            case Tauro:
                Mor();
                enemic.Mor();
            break;
            case Pop:
                enemic.Mor();
            break;
            case Salmo:
                enemic.Mor();
            break;
        }
    }

}
