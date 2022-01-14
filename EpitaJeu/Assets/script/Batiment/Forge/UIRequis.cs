using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRequis : MonoBehaviour
{
    public PlayerCaracteristique player;
    private int taille;
    private GameObject parent;


    public void UI(int _index)
    {

        Delete();
        int[] requis = player.items.allGames[_index].requis;
        int[] nombre = player.items.allGames[_index].nombre;
        taille = nombre.Length;

        parent = transform.GetChild(0).gameObject;
        GameObject g;


        for (int i = 0; i != taille; i++)
        {
            g = Instantiate(parent, transform);
            g.transform.name = "game";
            g.transform.GetChild(0).GetComponent<Text>().enabled = true;
            g.transform.GetChild(0).GetComponent<Text>().text = player.items.allGames[requis[i]].Name;
            g.transform.GetChild(2).GetComponent<Image>().enabled = true;
            g.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = player.items.allGames[requis[i]].Icon;

            int lieu = player.fonction.Index(requis[i], player.inventaire.inventaire);

            int fabriquation = 0;
            if (lieu != 999)
            {
                fabriquation = player.inventaire.inventaireNombre[lieu];

                g.transform.GetChild(1).GetComponent<Text>().text =
                    fabriquation.ToString() + "/" + nombre[i].ToString();
                g.transform.GetChild(1).GetComponent<Text>().enabled = true;
            }
            else
            {
                g.transform.GetChild(1).GetComponent<Text>().text = "0/" + nombre[i].ToString();
                g.transform.GetChild(1).GetComponent<Text>().enabled = true;
            }          

        }
        Destroy(parent);
    }

    public void UICout (int _index)
    {
        Delete();
        int[] nombre = player.items.allGames[_index].cout;
        taille = nombre.Length;

        parent = transform.GetChild(0).gameObject;
        GameObject g;


        for (int i = 0; i != taille; i++)
        {
            g = Instantiate(parent, transform);
            g.transform.name = "text";
            g.transform.GetChild(2).GetComponent<Image>().enabled = true;
            g.transform.GetChild(0).GetComponent<Text>().text = player.items.allGames[14].Name;
            g.transform.GetChild(0).GetComponent<Text>().enabled = true;


            g.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = player.items.allGames[14].Icon;

            int lieu = player.fonction.Index(14, player.inventaire.inventaire);

            int fabriquation = 0;
            if (lieu != 999)
            {
                fabriquation = player.inventaire.inventaireNombre[lieu];

                g.transform.GetChild(1).GetComponent<Text>().text =
                    fabriquation.ToString() + "/" + nombre[i].ToString();
                g.transform.GetChild(1).GetComponent<Text>().enabled = true;
            }
            else
            {
                g.transform.GetChild(1).GetComponent<Text>().text = "0/" + nombre[i].ToString();
                g.transform.GetChild(1).GetComponent<Text>().enabled = true;
            }



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
        i++;
    }
}
