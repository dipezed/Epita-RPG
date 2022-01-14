using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIQuete : MonoBehaviour
{

    public int longueur;
    public PlayerCaracteristique player;
    public Quete quete; 

    public void UI()
    {
        Delete();
        int taille = 0;
        longueur = player.queteActif.Count;
        GameObject parent = transform.GetChild(0).gameObject;
        GameObject g;
        parent.SetActive(true);
        foreach (int i in player.queteActif)
        {
            List<string> liste = quete.quest[i].texte ;           
            g = Instantiate(parent, transform);
            
            g.transform.GetChild(0).GetComponent<Text>().text = quete.quest[i].titre;
            g.transform.name = "text";


            GameObject t;
            GameObject r;
            GameObject y = g.transform.GetChild(1).gameObject;


            

            for (int s = 0; s != liste.Count; s++)
            {
                t = Instantiate(y, g.transform);
                t.transform.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
                t.transform.GetChild(0).GetComponent<Text>().text = liste[s];
                t.transform.GetChild(1).GetComponent<Text>().text = quete.quest[i].fait[s].ToString() + " / " + quete.quest[i].requis[s];ToString();
                t.transform.name = "text";              
            }
            Destroy(y);
            

            


        }
        if (player.queteActif.Count != 0)
        {
            Destroy(parent);
        }
        else
        {
            parent.SetActive(false);
        }
        
        
        

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
        i = 4;
        while (true)
        {
            try
            {
                GameObject p = transform.GetChild(0).GetChild(i).gameObject;

                Destroy(p);
            }
            catch
            {
                break;
            }
            i++;
        }
    }

    public void Add (int _quete)
    {
        
        int lieu = player.fonction.Index(_quete, player.queteActif);
        if (lieu == 999)
        {
            player.queteActif.Add(_quete);
        }
        
    }

    public void Delete(int _index)
    {
        int resultat = player.queteActif[_index];
        Quete.Quest res = quete.quest[resultat];
        Fonction.LvlUp(res.experience, player);
        
    }


}