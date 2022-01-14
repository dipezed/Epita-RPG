using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Inventory :    MonoBehaviour
{

    public PlayerCaracteristique player;
    public GameObject gFenetre;
    public Fenetre fenetre;
    public Global_inventaire global;
    public List<int> inventaire;
    public List<int> inventaireNombre;
    public List<int> equipement;

    public int index = 0;
    public Sprite active;
    public Sprite desactive;

    public List<int> sort;
    public List<int> equipeSort;


    public void UI(int _index)
    {
        index = _index;
        Items.Game[] items = player.items.allGames;

        for (int i = 0; i!= 4;i++)
        {
            GameObject g = transform.GetChild(i).gameObject;
            for (int s = 0; s!= 5; s++)
            {
                GameObject p = g.transform.GetChild(s).gameObject;
                p.transform.GetComponent<Button>().onClick.RemoveAllListeners();
                try
                {
                    Items.Game item = items[inventaire[index]];
                    p.transform.GetChild(1).GetComponent<Image>().sprite = item.Icon;
                    p.transform.GetChild(1).GetComponent<Image>().enabled = true;

                    p.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = inventaireNombre[index].ToString();
                    p.transform.GetChild(2).gameObject.SetActive(true);

                    if (player.fonction.Index(inventaire[index], equipement) == 999)
                    {
                        p.transform.GetChild(0).GetComponent<Image>().enabled = false;
                    }
                    else
                    {
                        p.transform.GetChild(0).GetComponent<Image>().enabled = true;
                    }

                    p.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
                    p.GetComponent<Image>().sprite = active;
                    
                    p.transform.GetComponent<Button>().AddEventListener(index, ItemClicked);
                    index++;

                }
                catch
                {

                    p.transform.GetChild(1).GetComponent<Image>().enabled = false;
                    p.transform.GetChild(2).gameObject.SetActive(false);
                    p.transform.GetChild(0).GetComponent<Image>().enabled = false;
                    p.GetComponent<Image>().sprite = desactive;
                    p.GetComponent<Image>().color = new Color(255f, 255f, 255f, 155f);
                }     

                
                }
        }
    }
    public void ItemClicked (int _index)
    {
        global.UI(inventaire[_index]);
        
        fenetre.UI(inventaire[_index], _index);

        gFenetre.SetActive(true);
    }


    public void Add(int _item, int quantite)
    {
        // Pour ajouter un item  l'inventaire
        inventaire.Add(_item);
        inventaireNombre.Add(quantite);
    }

    public void UISpell (int _index)
    {
        index = _index;
        Sort.Sortilege[] spell = player.sort.sort;
        for (int i = 0; i != 4; i++)
        {
            GameObject g = transform.GetChild(i).gameObject;
            for (int s = 0; s != 5; s++)
            {
                GameObject p = g.transform.GetChild(s).gameObject;
                p.transform.GetComponent<Button>().onClick.RemoveAllListeners();
                try
                {
                    Sort.Sortilege item = spell[sort[index]];
                    p.transform.GetChild(1).GetComponent<Image>().sprite = item.Icon;
                    p.transform.GetChild(1).GetComponent<Image>().enabled = true;
                    
                    p.transform.GetChild(2).gameObject.SetActive(false);

                    if (player.fonction.Index(sort[index], equipeSort) == 999)
                    {
                        p.transform.GetChild(0).GetComponent<Image>().enabled = false;
                    }
                    else
                    {
                        p.transform.GetChild(0).GetComponent<Image>().enabled = true;
                    }

                    p.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
                    p.GetComponent<Image>().sprite = active;

                    p.transform.GetComponent<Button>().AddEventListener(index, SortClick);
                    index++;

                }
                catch
                {

                    p.transform.GetChild(1).GetComponent<Image>().enabled = false;
                    p.transform.GetChild(2).gameObject.SetActive(false);
                    p.transform.GetChild(0).GetComponent<Image>().enabled = false;
                    p.GetComponent<Image>().sprite = desactive;
                    p.GetComponent<Image>().color = new Color(255f, 255f, 255f, 155f);
                }


            }
        }

    }

    public void SortClick(int _index)
    {
        global.UISpell(inventaire[_index]);

        fenetre.UISpell(inventaire[_index], _index);

        gFenetre.SetActive(true);
    }
    public void Decaler()
    {
        //
    }

}
