namespace Joc;

using System.Runtime.ConstrainedExecution;
using Heirloom;
using Heirloom.Desktop;

class Salmo : Peix 
{
    public Salmo(Image imatgeMascle, Image imatgeFamella, Joc joc, Sexe? sexeOpcional = null)
        : base (imatgeMascle, imatgeFamella, joc, sexeOpcional)
    {
    }

    public override void Interactuar(Peix enemic, Peix mare)
    {
        switch (enemic)
        {
            case Tauro:
                Mor();
            break;
            case Salmo when enemic.sexe != QuinSexeEs():
                joc.Criar(this, mare);
            break;
            case Salmo:
                Mor();
                enemic.Mor();
            break;
        }
    }

}
