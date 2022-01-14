using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontreIndividuelle : MonoBehaviour
{
    public PlayerCaracteristique player;
    public Monstre.Monster monstre;
    public int index;
   
    public void Change()
    {
        monstre = player.monstre.monstre[index];
    }
}
