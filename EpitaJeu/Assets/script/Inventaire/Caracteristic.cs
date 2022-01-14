using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caracteristic : MonoBehaviour
{
    public PlayerCaracteristique player;
    public void UI (int index)
    {
        Items.Game item = player.items.allGames[index];
        int s = 1;
        while (true)
        {
            try
            {
                GameObject p = transform.GetChild(s).gameObject;
                Destroy(p);
                s++;
            }
            catch
            {
                break;
            }            
        }
        GameObject parent = transform.GetChild(0).gameObject;
        parent.SetActive(true);
        for (int i = 1; i != item.classe.Length; i++)
        {
            GameObject g = Instantiate(parent, transform);
            g.transform.name = "gameobject";
            g.transform.GetChild(0).GetComponent<Image>().sprite = player.classes.classe[item.classe[i]].Icon;
            g.transform.GetChild(0).GetComponent<Image>().enabled = true;
            g.transform.GetChild(1).GetComponent<Text>().text = player.classes.classe[item.classe[i]].Name;
            g.transform.GetChild(1).GetComponent<Text>().enabled = true; 
            g.transform.GetChild(2).GetComponent<Text>().text = item.gain[i-1].ToString();
            g.transform.GetChild(2).GetComponent<Text>().enabled = true;
        }
        if (item.classe.Length > 1)
        {
            Destroy(parent);
        }
        else
        {
            parent.SetActive(false);
        }
        
    }

    public void UIspell (int index)
    {
        Sort.Sortilege sort = player.sort.sort[index];
        int s = 1;
        while (true)
        {
            try
            {
                GameObject p = transform.GetChild(s).gameObject;
                Destroy(p);
                s++;
            }
            catch
            {
                break;
            }
        }
        GameObject parent = transform.GetChild(0).gameObject;
        for (int i = 0; i != sort.classe.Length; i++)
        {
            GameObject g = Instantiate(parent, transform);
            g.transform.name = "gameobject";
            g.transform.GetChild(0).GetComponent<Image>().sprite = player.classes.classe[sort.classe[i]].Icon;
            g.transform.GetChild(0).GetComponent<Image>().enabled = true;
            g.transform.GetChild(1).GetComponent<Text>().text = player.classes.classe[sort.classe[i]].Name;
            g.transform.GetChild(1).GetComponent<Text>().enabled = true;
            g.transform.GetChild(2).GetComponent<Text>().text = sort.degat[i].ToString();
            g.transform.GetChild(2).GetComponent<Text>().enabled = true;
        }   
        Destroy(parent);
    }

}
