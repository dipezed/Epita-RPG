using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;




public class Interface : MonoBehaviour
{
    public PlayerCaracteristique player;
    public List<int> items;
    private int taille;
    private GameObject parent;

    public IconeText icone;
    public UIRequis uI;
    public PassifInventaire passif;
    public bool cout = true;
    private void Start()
    {
       
        UI();
        

        
    }
    public void UI()
    {
        Delete();
        taille = (int)items.Count;


        parent = transform.GetChild(0).gameObject;
        GameObject g;

        for (int i = 0; i != taille; i++)
        {
            g = Instantiate(parent, transform);
            Button btn0 = g.GetComponent<Button>();
            btn0.enabled = true;
            g.GetComponent<Image>().enabled = true;
            btn0.AddEventListener(items[i], Click);
            g.transform.GetChild(0).GetComponent<Image>().sprite = player.items.allGames[items[i]].Icon;
            g.transform.GetChild(0).GetComponent<Image>().enabled = true;

        }
        Destroy(parent);
    }
    public void Click(int _index)
    {
        icone.cout = cout;
        
        icone.Change(_index);
        if (cout)
        {
            uI.UICout(_index);
        }
        else
        {
            uI.UI(_index);
        }
        
        passif.UI(_index);
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
        i++;
    }

}
