namespace Joc;

using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using Heirloom;
using Heirloom.Desktop;

class Peixera
{
    public Peix?[,] peixera;
    public List<Peix> peixos = new List<Peix>();

    public Peixera()
    {
        peixera = new Peix[20, 20];
    }

    public void NetejarMorts()
    {
        var morts = peixos.RemoveAll(p => p.EstaViu() == false);

        for(int i = 0; i <= 19; i++)
        {
            for(int j = 0; j <= 19; j++)
            {
                if(peixera?[i, j] != null && peixera?[i, j].EstaViu() == false)
                {
                    peixera[i, j] = null;
                }
            }
        }
    }
}
