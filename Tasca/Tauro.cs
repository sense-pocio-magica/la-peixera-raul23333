namespace Joc;

using System.Runtime.ConstrainedExecution;
using Heirloom;
using Heirloom.Desktop;

class Tauro : Peix 
{
    private int vides = 75;
    public Tauro(Image imatgeMascle, Image imatgeFamella,Joc j, Sexe? sexeOpcional = null)
        : base (imatgeMascle, imatgeFamella, j, sexeOpcional)
    {
    }

    public override void Moure()
    {
        base.Moure();
        vides --;
        if(vides <= 0) Mor();
    }

    public override void Interactuar(Peix enemic, Peix mare)
    {
        switch (enemic)
        {
            case Tauro when enemic.sexe != QuinSexeEs():
                joc.Criar(this, mare);
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
