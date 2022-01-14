using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconeText : MonoBehaviour
{
    public PlayerCaracteristique player;
    public Interface inter;
    public Text titre;

    public Text descritpion;
    public Image icone;

    public Text t_actif;

    public Button close;
    public Button use;
    public bool cout = true;

    private int itemClick = 0;





    private void Start()
    {
        Button btn0 = use.GetComponent<Button>();
        btn0.onClick.AddListener(Use);

        close.GetComponent<Button>().onClick.AddListener(Close);
        inter.Click(0);
        

        //StartCoroutine(Wait());



    }

    public void Change(int _items)
    {        
        itemClick = _items;
        ChangeImage(_items);
        ChangeText(_items);
    }
    public void ChangeText(int _items)
    {
        titre.GetComponent<Text>().text = player.items.allGames[_items].Name;
        descritpion.GetComponent<Text>().text = player.items.allGames[_items].Description;
    }
    public void ChangeImage(int _items)
    {
        icone.GetComponent<Image>().sprite = player.items.allGames[_items].Icon;
    }
    public void Use()
    {
        bool peut = true;
        List<int> inventaire_nombre = player.inventaire.inventaireNombre;
        List<int> inventaire = player.inventaire.inventaire;
        int[] classe = player.items.allGames[itemClick].requis;
        int[] besoin = player.items.allGames[itemClick].nombre;
        if (cout)
        {
            classe = new int[] { 14 };
            besoin = player.items.allGames[itemClick].cout;
        }
        
        for (int i = 0; i != besoin.Length; i++)
        {
            int lieu = player.fonction.Index(classe[i], inventaire);
            if (lieu != 999)
            {
                if (inventaire_nombre[lieu] < besoin[i])
                {
                    peut = false;
                    break;
                }

            }
            else
            {
                peut = false;
                break;
            }

        }
        if (peut)
        {

            for (int i = 0; i != besoin.Length; i++)
            {
                int lieu = player.fonction.Index(classe[i], inventaire);
                player.inventaire.inventaireNombre[lieu] -= besoin[i];
                if (player.inventaire.inventaireNombre[lieu] == 0)
                {
                    player.inventaire.inventaireNombre.RemoveAt(lieu);
                    player.inventaire.inventaire.RemoveAt(lieu);
                }
            }
            int pos = player.fonction.Index(itemClick, inventaire);
            if (pos != 999)
            {
                player.inventaire.inventaireNombre[pos] += 1;
            }
            else
            {
                player.inventaire.Add(itemClick, 1);

            }
            inter.Click(itemClick);

        }



    }

    public void Close()
    {
        gameObject.SetActive(false);
        player.canMoove = true;
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.001f);
        gameObject.SetActive(false);
    }


}
