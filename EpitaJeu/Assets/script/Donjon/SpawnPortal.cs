using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPortal : MonoBehaviour
{
    public PlayerCaracteristique player;   
    public GameObject lieuPortal;
    
    
    // Niveau F = 0 , E = 1  ... S = 6 //

    public void Spawn(Transform position, int _time,int number,int niveau, TableauQuete tableau)
    {

        tableau.liste.Add(number);
        GameObject g = Instantiate(  player.donjonMonster.donjon1[number].design , lieuPortal.transform);
        g.transform.position = position.position; 
        g.transform.GetChild(2).GetComponent<SceneDonjon>().player = player;
        StartCoroutine(Delete(_time, g,tableau,number));
    }
    public IEnumerator Delete (int _time, GameObject _g, TableauQuete tableau, int number)
    {
        yield return new WaitForSeconds(_time);
        tableau.liste.Remove(number);
        Destroy(_g);
      
        
    }

}
