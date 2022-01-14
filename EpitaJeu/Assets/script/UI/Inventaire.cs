using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate () {
            OnClick(param);
        });
    }
}
public class Inventaire : MonoBehaviour


{

    private int taille;
    public PlayerCaracteristique player;
    public List<int> inventaire;
    public List<int> inventaireNombre;
    private GameObject parent;
    public GameObject fenetre;
    public PopUp popUp;


    // Start is called before the first frame update
    void Start()
    {
        taille = (int)inventaire.Count / 5;
        if (inventaire.Count % 5 != 0)
        {
            taille++;
        }
        UI();
        


    }

    // Update is called once per frame
    void ItemClicked(int itemIndex)
    {
        popUp.Modification(inventaire[itemIndex], itemIndex); // Affiche le pop up d'utilisation de chaque item 
        fenetre.SetActive(true);


    }

    public void Decaler()
    {
        // Raffraichi la liste de mon inventaire
        for (int i = 1; i != taille; i++)
        {
            GameObject p = transform.GetChild(i).gameObject;
            Destroy(p);
        }
        UI();
    }
    public void UI()
    {
        taille = (int)inventaire.Count / 5;
        if (inventaire.Count % 5 != 0)
        {
            taille++;
        }
        if (taille < 6)
        {
            taille = 6;
        }

        
        

        // La liste d'item
        parent = transform.GetChild(0).gameObject;
        GameObject g;
        int index = 0;

        for (int i = 0; i != taille; i++)
        {
            g = Instantiate(parent, transform);
            g.transform.name = "Inventaire";

            for (int s = 0; s != 5; s++)
            {

                try
                {
                    g.transform.GetChild(s).GetChild(0).GetComponent<Image>().sprite
                        = player.items.allGames[inventaire[index]].Icon;

                    g.transform.GetChild(s).GetChild(1).GetComponent<Text>().text
                        = inventaireNombre[index].ToString();

                    g.transform.GetChild(s).GetComponent<Button>().AddEventListener(index, ItemClicked);

                    index++;
                }
                catch
                {
                    g.transform.GetChild(s).GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    g.transform.GetChild(s).GetChild(1).GetComponent<Text>().text = "";
                }
            }
        }
        Destroy(parent);
        transform.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
    }

    public void Add(int _item, int quantite)
    {
        // Pour ajouter un item � l'inventaire
        inventaire.Add(_item);
        inventaireNombre.Add(quantite);
    }
}