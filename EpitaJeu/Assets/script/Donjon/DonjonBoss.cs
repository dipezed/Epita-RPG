using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DonjonBoss : MonoBehaviour
{
    public PlayerCaracteristique player;

    public GameObject lieu;
    public int index;
    public GameObject position;
    public int combat;
    

   

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


        GameObject g = Instantiate(player.monstre.monstre[index].Icone , position.transform) ;

        g.transform.position = lieu.transform.GetChild(0).position;
        Destroy(g.GetComponent<MonsterVision>());
        Destroy(g.GetComponent<Monster_IA>());
        g.AddComponent<BossDonjon>();
        g.GetComponent<BossDonjon>().combat = combat ;
        g.GetComponent<BossDonjon>().player = player;
        g.GetComponent<BossDonjon>().animator = g.GetComponent<Animator>();
        g.GetComponent<MontreIndividuelle>().player = player;
        g.GetComponent<MontreIndividuelle>().Change();




    }

}
