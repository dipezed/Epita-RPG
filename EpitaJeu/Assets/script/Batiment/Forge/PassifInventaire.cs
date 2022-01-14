using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PassifInventaire : MonoBehaviour
{

    public PlayerCaracteristique player;

    public void UI(int _index)
    {
        Delete();
        GameObject parent = transform.GetChild(0).gameObject;
        GameObject g;
        int[] classe = player.items.allGames[_index].classe;
        int[] gain = player.items.allGames[_index].gain;
        int taille = classe.Length;
        for (int i = 1; i != taille; i++)
        {
            g = Instantiate(parent, transform);
            g.transform.GetChild(0).GetComponent<Image>().sprite = player.classes.classe[classe[i]].Icon;
            g.transform.GetChild(1).GetComponent<Text>().text =
                gain[i - 1].ToString() + " " + player.classes.classe[classe[i]].Name;


        }
        Destroy(parent);
    }

    public void Delete()
    {
        int i = 1;
        while (true)
        {
            try
            {
                GameObject p = transform.GetChild(i).gameObject;
                Destroy(p);
            }
            catch
            {
                break;
            }
            i++;
        }

    }
}
