using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    public PlayerCaracteristique player;
    public string lieu = "Ville";
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (lieu == "Donjon")
            {
                
                StartCoroutine(player.allCity.Donjon(0, true, null, null)) ;
            }
            else
            {
                StartCoroutine(player.allCity.Active(0, true));
            }
            
        }
    }
    
}
