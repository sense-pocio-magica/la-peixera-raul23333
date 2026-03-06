namespace Joc;

using System.Runtime.ConstrainedExecution;
using Heirloom;
using Heirloom.Desktop;

class Tortuga : Peix 
{
    public Tortuga(Image imatgeMascle, Image imatgeFamella, Joc j, Sexe? sexeOpcional = null)
        : base (imatgeMascle, imatgeFamella, j, sexeOpcional)
    {
    }

    public override void Interactuar(Peix enemic, Peix mare)
    {
        switch (enemic)
        {
            case Tauro:
                enemic.CanviarDireccio();
            break;
            case Tortuga when enemic.sexe != QuinSexeEs():
                joc.Criar(this, mare);
            break;
            case Tortuga:
                Mor();
                enemic.Mor();
            break;
        }
    }

}
