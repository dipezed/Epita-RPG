using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caracteristique : MonoBehaviour
{
    public PlayerCaracteristique player;
    public Image icone;
    public Text titre;
    public Text description;
    public Text points;
    public List<Button> boutons;
    public int index = 1;
    public int id = 0;
    public Text restant;
    public Text nbrPointCaract;
    public Button reset;
    public Button add;
    public Text[] texte;

    public Global_inventaire global;

    public Button bInventaire;

    public Button bSort;
    public Button bExit;


    public int[] nbrPoint = { 0, 0, 0, 0, 0, 0 };
    public int[] prix = { 1, 2, 2, 2, 60, 60 };
    public int[] liste = { 1, 8, 7, 6, 3, 5 };


    public Text level;
    public Image iLevel;


    private void Start()
    {
        bInventaire.onClick.AddListener(Inventaire);


        bSort.onClick.AddListener(Sort);
        bExit.onClick.AddListener(Exit);



        for (int i = 0; i!= boutons.Count; i++)
        {
            boutons[i].AddEventListener(i, UIBouton);
        }
        UI();
        
        reset.onClick.AddListener(Reinitialiser);
        add.onClick.AddListener(Use);
    }
    public void UI()
    {

        level.GetComponent<Text>().text = player.lvlUp + " / " + player.level * 100;

        RectTransform rt = iLevel.transform.GetComponent<RectTransform>();

        float res = (float)player.lvlUp / (float)player.level;

        rt.sizeDelta = new Vector2(448f * (res / 100f), 34);

        int[] classe =
        {
            player.max_vie ,
            player.force ,
            player.ap ,
            player.defence,
            player.max_pa ,
            player.max_pm
        };
        for (int i = 0; i != nbrPoint.Length; i++)
        {
            texte[i].text = classe[i].ToString();
        }
        UIBouton(id);
        Fenetre();
    }
    public void UIBouton(int _index)
    {
        
        id = _index;
        index = liste[_index];
        icone.sprite = player.classes.classe[index].Icon; 
        titre.text = player.classes.classe[index].Name;
        description.text = player.classes.classe[index].Description;

        points.text = "Déjà : "+ nbrPoint[id].ToString() +" points";
        nbrPointCaract.text=  "Coût : " + prix[id].ToString() + " points";
    }

    void Use()
    {
        if (player.ptCaracteristique >= prix[id])
        {
            player.ptCaracteristique -= prix[id];
            nbrPoint[id] += 1;
            int[] rien = { 999, liste[id] };
            int[] rien2 = { 1 };
            player.attribut.Classe(rien, rien2, 1);
            UI();
        }
        else
        {
            StartCoroutine(Fonction.Erreur(player, "Vous n'avez pas assez de point"));
        }
    }

    void Reinitialiser()
    {
        for (int i = 0; i != prix.Length; i++)
        {
            player.ptCaracteristique += nbrPoint[i] * prix[i];
            int[] rien = { 999, liste[i] };
            int[] rien2 = { nbrPoint[i] };
            player.attribut.Classe(rien,  rien2, -1);
            nbrPoint[i] = 0;
        }
        UI();
    }
    public void Fenetre()
    {
        restant.text = "Points restant : " + player.ptCaracteristique;
    }


    void Inventaire()
    {
        gameObject.SetActive(false);
        player.gInventaire.SetActive(true);
        global.position = 0;
        global.liste = global.inventory.inventaire;
        global.UI(0);
        global.titre.GetComponent<Text>().text = "Inventaire";
    }

    void Sort()
    {
        gameObject.SetActive(false);
        player.gInventaire.SetActive(true);
        global.lieu = 0;
        global.position = 2;
        global.liste = global.inventory.sort;
        global.UISpell(0);
        global.titre.GetComponent<Text>().text = "Sortilège";
    }
    void Exit()
    {
        gameObject.SetActive(false);
        player.mouvement.inventaire = false;
        player.CantMoove(true);
    }


}
