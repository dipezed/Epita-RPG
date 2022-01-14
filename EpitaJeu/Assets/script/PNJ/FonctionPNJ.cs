using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FonctionPNJ : MonoBehaviour
{
    public PlayerCaracteristique player;
    //0
    public void Combat()
    {
        StartCoroutine(player.allCity.Active(1, false));
        
    }
    //1
    public void Achat ()
    {
        player.forge.SetActive(true);
        player.canMoove = (false);
    }
    //2
    public void Quete0()
    {
        Fonction.VerifQuete(player, 0);
    }
}
