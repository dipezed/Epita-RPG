using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GainPopUp : MonoBehaviour
{
    
    public void TextGain(int index, PlayerCaracteristique player)
    {
        GameObject parent = transform.GetChild(1).gameObject;
        GameObject g;


        parent.SetActive(true);
        int[] classe = player.items.allGames[index].classe;

        if (classe.Length!= 1)
        {
            for (int i = 1; i != classe.Length; i++)
            {
                g = Instantiate(parent, transform);
                g.transform.GetChild(1).GetComponent<Image>().sprite =
                        player.classes.classe[classe[i]].Icon;
                g.transform.GetChild(0).GetComponent<Text>().text = player.items.allGames[index].gain[i - 1].ToString();

            }
            Destroy(parent);
        }
        else
        {
            parent.SetActive(false);
        }
          
        


        

    }
}