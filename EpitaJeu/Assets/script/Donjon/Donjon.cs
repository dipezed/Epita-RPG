using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donjon : MonoBehaviour
{
    public PlayerCaracteristique player;    
    public GameObject lieu;
    public int[] index;
    public GameObject position;
    public int combat ;



    

    public void Charger()
    {
        int s = 0;
        while (true)
        {
            try
            {
                Destroy(position.transform.GetChild(s).gameObject);
                
                s++;
            }
            catch
            {
                break;
            }
        }
        
        for (int i = 0; i!= lieu.transform.childCount; i++)
        {
            GameObject g = Instantiate(player.monstre.monstre[index[Random.Range(0, index.Length)]].Icone, position.transform);             
            g.transform.position = lieu.transform.GetChild(i).position;
            g.GetComponent<Monster_IA>().nav.Warp(g.transform.position);
            g.GetComponent<Monster_IA>().waypoint = lieu.transform.GetChild(i).gameObject;
           
            g.GetComponent<Monster_IA>().player = player;
            g.GetComponent<Monster_IA>().combat = combat;
            
            g.GetComponent<MonsterVision>().monsterIA = g.GetComponent<Monster_IA>() ;
            g.GetComponent<Monster_IA>().Destination();

            g.GetComponent<MontreIndividuelle>().player = player;
            g.GetComponent<MontreIndividuelle>().Change();
        }
        
    }
}
