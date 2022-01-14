using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCity : MonoBehaviour
{
    
    public PlayerCaracteristique player;

    
    public int index = 0;



    public IEnumerator Active (int _index,bool _close)
    {
        yield return new WaitForSeconds(0.01f);
        player.sousParent.GetComponent<CharacterController>().enabled = false ;
        if (!_close) 
        {
            if (_index < player.ville.Length)
            {
                player.ville[0].SetActive(false);
                player.atterit = player.sousParent.transform.position;
                player.ville[_index].SetActive(true) ;
                index = _index ;
                player.sousParent.transform.position = player.spawn[_index].transform.position;
            }
        }
        else
        {
            player.ville[index].SetActive(false);
            player.sousParent.transform.position = player.atterit;
            player.ville[0].SetActive(true);
            index = 0;
        }
        player.sousParent.GetComponent<CharacterController>().enabled = true;

    }

    public void ActiveCombat(int _index, bool _close)
    {
        player.sousParent.GetComponent<CharacterController>().enabled = false;
        if (!_close)
        {
            if (_index < player.combat.Length)
            {
                player.ville[0].SetActive(false);
                player.atterit = player.sousParent.transform.position;
                player.combat[_index].SetActive(true);
                index = _index;
                player.sousParent.transform.position = player.spawn[_index].transform.position;
            }
        }
        else
        {
            player.combat[index].SetActive(false);
            player.sousParent.transform.position = player.atterit;
            player.combat[0].SetActive(true);
            index = 0;
        }
        player.sousParent.GetComponent<CharacterController>().enabled = true;

    }
    public IEnumerator Donjon (int _index, bool _close, StartDonjon.PosMonstre[] normalIndex, int[] bossIndex)
    {
        yield return new WaitForSeconds(0.01f);
        
        player.sousParent.GetComponent<CharacterController>().enabled = false;
        if (!_close)
        {
            if (_index < player.donjon.Length)
            {
                player.ville[0].SetActive(false);
                player.atterit = player.sousParent.transform.position;
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
