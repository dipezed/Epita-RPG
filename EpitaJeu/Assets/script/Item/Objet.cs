using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objet : MonoBehaviour
{
    public PlayerCaracteristique player;
    public GameObject moi;
    private GameObject parent;


    
    public void UI()
    {
        
        gameObject.SetActive(true);
        List<int> liste = player.colision;
        List<int> nombre = player.nombre;
        int taille = liste.Count;

        if (taille != 0)
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

       




        RectTransform rt = transform.GetComponent<RectTransform>();




        rt.sizeDelta = new Vector2(180, (taille) * 135); // Je met 53 pour avoir un petit espace entre chaque item 
        parent = transform.GetChild(0).gameObject;
        parent.transform.GetComponent<Image>().enabled = true;
        parent.transform.GetComponent<Button>().enabled = true;
        parent.transform.GetChild(0).GetComponent<Text>().enabled = true;
        parent.transform.GetChild(1).GetComponent<Image>().enabled = true;
        parent.transform.GetChild(2).GetComponent<Text>().enabled = true;
        parent.transform.GetChild(3).GetComponent<Image>().enabled = true;
        GameObject g;

       
        for (int i = 0; i != taille; i++)
        {
            g = Instantiate(parent, transform);

            
            g.transform.GetChild(0).GetComponent<Text>().text    = player.items.allGames[liste[i]].Name;


            g.transform.GetChild(1).GetComponent<Image>().sprite
                    = player.items.allGames[liste[i]].Icon;

            g.transform.GetChild(2).GetComponent<Text>().text
                    = nombre[i].ToString();


        }
        Destroy(parent);
    }
    public void TakeItem()
    {
        if (player.colision.Count != 0)
        {
            List<int> liste = player.colision;
            List<int> nombre = player.nombre;


            int lieu = player.fonction.Index(liste[0], player.inventaire.inventaire);
            if (lieu != 999)
            {

                player.inventaire.inventaireNombre[lieu] += nombre[0];
            }
            else
            {

                player.inventaire.Add(liste[0], nombre[0]);
            }


            player.nombre.RemoveAt(0);
            player.colision.RemoveAt(0);


            player.inventaire.Decaler();

        }
    }

}
