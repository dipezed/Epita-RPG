using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{

    public Transform position;
    public PlayerCaracteristique player;
    public int index = 1;

    


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            StartCoroutine(Active(index, false));
        }
    }

    public IEnumerator Active(int _index, bool _close)
    {
        yield return new WaitForSeconds(0.2f);
        player.sousParent.GetComponent<CharacterController>().enabled = false;
        if (!_close)
        {
            if (_index < player.ville.Length)
            {
                player.ville[0].SetActive(false);
                player.atterit = position.transform.position;
                player.ville[_index].SetActive(true);
                player.allCity.index = _index;
                player.sousParent.transform.position = player.spawn[_index].transform.position;
            }
        }
        else
        {
            player.ville[player.allCity.index].SetActive(false);
            player.sousParent.transform.position = player.atterit;
            player.ville[0].SetActive(true);
            player.allCity.index = 0;
        }
        player.sousParent.GetComponent<CharacterController>().enabled = true;

    }

    public void Donjon(int _index, bool _close, StartDonjon.PosMonstre[] normalIndex, int[] bossIndex)
    {
        player.sousParent.GetComponent<CharacterController>().enabled = false;
        if (!_close)
        {
            if (_index < player.donjon.Length)
            {
                player.ville[0].SetActive(false);
                player.atterit = position.transform.position;
                player.ville[_index].SetActive(true);

                player.donjon[_index].GetComponent<StartDonjon>().index = normalIndex;
                player.donjon[_index].GetComponent<StartDonjon>().bossIndex = bossIndex;
                player.donjon[_index].GetComponent<StartDonjon>().Change();

                player.allCity.index = _index;
                player.sousParent.transform.position = player.spawn[_index].transform.position;
            }
        }
        else
        {
            player.donjon[player.allCity.index].SetActive(false);
            player.sousParent.transform.position = player.atterit;
            player.donjon[0].SetActive(true);
            player.allCity.index = 0;
        }
        player.sousParent.GetComponent<CharacterController>().enabled = true;

    }
}
