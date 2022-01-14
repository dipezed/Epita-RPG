using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Global_inventaire : MonoBehaviour
{
    public PlayerCaracteristique player;
    public Inventory inventory;
    public Caracteristic caracteristic;
    public Caracteristique caracteristique; // le Troisieme (sort, inventaire, caract .. )

    public Text titre; 

    public Button bInventaire;    
    public Button bCaracteristique;
    public Button bSort;
    public Button bExit;

    public GameObject armure;
    public GameObject ressource;

    public Button bPrecedant;
    public Button bSuivant;

    public Text tDescriptionTitre;
    public Text tDescription;

    public int index = 0;
    public int lieu = 0;

    public List<int> liste;
    public int position = 0;

    public Text level;
    public Image iLevel;



    void Start()
    {
        bInventaire.onClick.AddListener(Inventaire);

        bCaracteristique.onClick.AddListener(Caracteristique);
        bSort.onClick.AddListener(Sort);
        bExit.onClick.AddListener(Exit);    
        
        bSuivant.onClick.AddListener(Suivant);
        bPrecedant.onClick.AddListener(Precedant);
        liste = new List<int>();
        position = 0;
        liste = inventory.inventaire;
        UI(0);
        

        

    }
    public void UI(int _index)
    {
        level.GetComponent<Text>().text = player.lvlUp + " / " + player.level*100;

        RectTransform rt = iLevel.transform.GetComponent<RectTransform>();

        float res = (float)player.lvlUp / (float) player.level;

        rt.sizeDelta = new Vector2(448f * (res/100f), 34);

        


        index = _index;
        tDescriptionTitre.GetComponent<Text>().text = player.items.allGames[index].Name;
        tDescription.GetComponent<Text>().text = player.items.allGames[index].Description;        
        caracteristic.UI(_index);
        inventory.UI(lieu);
    }

    public void UISpell (int _index)
    {
        index = _index;

        tDescriptionTitre.GetComponent<Text>().text = player.sort.sort[index].Name;
        tDescription.GetComponent<Text>().text = player.sort.sort[index].Description;
        caracteristic.UIspell(_index);
        inventory.UISpell(lieu);
    }




    void Inventaire()
    {
        position = 0;
        liste = inventory.inventaire;
        UI(0);
        titre.GetComponent<Text>().text = "Inventaire";
    }
    void Caracteristique()
    {
        player.gCaracteristique.SetActive(true);
        caracteristique.UI();
        gameObject.SetActive(false);
    }
    void Sort()
    {
        lieu = 0;
        position = 2;
        liste = inventory.sort;
        UISpell(0);
        titre.GetComponent<Text>().text = "Sortilège";
    }
    void Exit()
    {
        gameObject.SetActive(false);
        player.mouvement.inventaire = false;
        player.CantMoove(true);
    }
    void Suivant()
    {
        if (liste.Count > lieu + 20)
        {
            lieu += 20;
            Test();
        }
    }
    void Precedant()
    {
        if (lieu >= 20)
        {
            lieu -= 20;
            Test();
        }
    }
    public void Test ()
    {
        if (0 == position)
        {
            inventory.UI(lieu);
            UI(index);
        }
        else
        {
            inventory.UISpell(lieu);
            UISpell(index);
        }
    }


}
