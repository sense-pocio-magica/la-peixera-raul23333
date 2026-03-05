namespace Joc;

using System.Runtime.ConstrainedExecution;
using Heirloom;
using Heirloom.Desktop;

class Tortuga : Peix 
{
    public Tortuga(Image imatge)
        : base (imatge)
    {
    }

    public override void Interactuar(Peix enemic)
    {
        switch (enemic)
        {
            case Tauro:
                enemic.CanviarDireccio();
            break;
            case Tortuga when enemic.sexe != QuinSexeEs():
                //Criar();
            break;
            case Tortuga:
                Mor();
                enemic.Mor();
            break;
        }
    }

}
