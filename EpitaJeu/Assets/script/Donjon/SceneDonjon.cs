using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDonjon : MonoBehaviour
{
    public PlayerCaracteristique player;
    public int index;
    public int[] bossIndex;
    public StartDonjon.PosMonstre[] normalIndex;
    
    public Transform position;
    


   


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine( Donjon(index,false));
        }
        
    }

    public IEnumerator Donjon(int _index, bool _close)
    {
        yield return new WaitForSeconds(0.01f);
        
        player.sousParent.GetComponent<CharacterController>().enabled = false;
        if (!_close)
        {
            if (_index < player.donjon.Length)
            {
                player.ville[0].SetActive(false);
                player.atterit = position.transform.position;
                player.donjon[_index].SetActive(true);

                player.donjon[_index].GetComponent<StartDonjon>().index = normalIndex;
                player.donjon[_index].GetComponent<StartDonjon>().bossIndex = bossIndex;
                player.donjon[_index].GetComponent<StartDonjon>().Change();

                index = _index;
                player.sousParent.transform.position = player.donjonSpawn[_index].transform.position;
                
            }
        }
        else
        {
            player.donjon[index].SetActive(false);
            player.sousParent.transform.position = player.atterit;
            player.donjon[0].SetActive(true);
            index = 0;
        }
        player.sousParent.GetComponent<CharacterController>().enabled = true;

    }
}
