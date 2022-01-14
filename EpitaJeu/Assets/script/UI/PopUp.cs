using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public PlayerCaracteristique player;
    public GainPopUp gainPopUp;

    public GameObject parent;
    public Image icone;
    public Text description;
    public Text titre;
    public Button fermer;
    public Button supprimer;
    public Button utiliser;


    private int index = 0;
    private int id = 0;




    void Start()
    {
        // Ajout des listeners à mes boutons
        Button btn0 = fermer.GetComponent<Button>();
        btn0.onClick.AddListener(Close);

        Button btn1 = supprimer.GetComponent<Button>();
        btn1.onClick.AddListener(Supprimer);

        Button btn2 = utiliser.GetComponent<Button>();
        btn2.onClick.AddListener(Utiliser);


    }


    public void Modification(int _index, int _id)
    {
        // _id = l'item cliquer (son index) 
        // _index = l'index dans l'inventaire de l'item cliqué 
        int i = 2;
        while (true)
        {
            try
            {
                GameObject parent = transform.GetChild(0).GetChild(0).GetChild(i).gameObject;
                Destroy(parent);

            }
            catch
            {
                break;
            }
            i++;
        }
        id = _id;
        index = _index;
        // Je change le design de mon popup par chaque élément de l'item select 
        icone.transform.GetComponent<Image>().sprite = player.items.allGames[_index].Icon;
        description.transform.GetComponent<Text>().text = player.items.allGames[_index].Description;
        titre.transform.GetComponent<Text>().text = player.items.allGames[_index].Name;
        if (player.items.allGames[index].classe[0] == 10)
        {
            utiliser.transform.GetChild(0).GetComponent<Text>().color = new Color(0f, 0f, 0f, 0f);
        }
        else
        {
            utiliser.transform.GetChild(0).GetComponent<Text>().color = new Color(255f, 249f, 196f, 255f);
        }



       
       gainPopUp.TextGain(_index, player);


    }


    public void Close()
    {
        parent.SetActive(false);
    }

    public void Supprimer()
    {
        if (player.inventaire.inventaireNombre[id] <= 1)
        {
            player.inventaire.inventaire.RemoveAt(id);
            player.inventaire.inventaireNombre.RemoveAt(id);
            player.inventaire.Decaler();
            Close();
        }
        else
        {
            player.inventaire.inventaireNombre[id] -= 1;
            player.inventaire.Decaler();
        }

    }

    public void Utiliser()
    {
        int[] p = player.items.allGames[index].classe;
        int itemToChange = 0;

        // Si consomable 
        if (p[0] == 11)
        {
            player.attribut.Classe(p, player.items.allGames[index].gain, 1);
            Supprimer();

        }
        else
        {
            if (p[0] == 10)
            {
                //dz
            }
            else
            {

                if (p[0] == 12 || p[0] == 13 || p[0] == 14 || p[0] == 15)
                {
                    player.equipement1.Changer(index, p[0] - 12);
                    itemToChange = player.equipement1.indexItem[p[0] - 12];
                    player.equipement1.indexItem[p[0] - 12] = index;


                }
                else
                {
                    player.equipement2.Changer(index, p[0] - 16);
                    itemToChange = player.equipement2.indexItem[p[0] - 16];
                    player.equipement2.indexItem[p[0] - 16] = index;

                }
                // Je supprime les caractéristique de mon equipement ancien
                player.attribut.Classe(player.items.allGames[itemToChange].classe, player.items.allGames[itemToChange].gain, -1);




                if (player.inventaire.inventaireNombre[id] >= 2)
                {
                    player.inventaire.inventaireNombre[id] -= 1;
                }
                else
                {
                    player.inventaire.inventaire.RemoveAt(id);
                    player.inventaire.inventaireNombre.RemoveAt(id);
                }
                int lieu = player.fonction.Index(itemToChange, player.inventaire.inventaire);
                if (lieu != 999)
                {
                    player.inventaire.inventaireNombre[lieu] += 1;
                }
                else
                {
                    player.inventaire.Add(itemToChange, 1);

                }

                player.inventaire.Decaler();
                Close();
            }
        }
        
        


    }

}

