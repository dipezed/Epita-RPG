using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCaracteristique : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public GameObject sousParent;
    public GameObject g_inventaire;
    public GameObject erreur;
    public GameObject forge;
    public GameObject miniMap;
    public GameObject grandMap;
    public GameObject bouton;
    public GameObject gainQuete;

    public GameObject gInventaire;
    public GameObject gCaracteristique;
    public GameObject g_Menu;



    public GameObject[] ville;
    public GameObject[] combat;
    public GameObject[] donjon;

    public Transform[] spawn;
    public Transform[] donjonSpawn;
    public Vector3 atterit;

    public List<Action> action; // Les fonctions qui vont s'executer lorsque un pnj à fini de parler    
    public List<int> colision;
    public List<int> nombre;

    public Attribut attribut;
    public Items items;
    public Classes classes;
    public Monstre monstre;
    public DonjonMonster donjonMonster;

    public Fonction fonction;
    public Inventory inventaire;
    public Equipement equipement1;
    public Equipement equipement2;
    public FonctionPNJ fonctionPNJ;
    public Objet objet;
    public PlayerMouvement mouvement;
    public AllCity allCity;
    public Global_inventaire global;
    public Sort sort;
    public Quete quete;
    public EndQuete endQuete;
    public Caracteristique caracteristique;
    public SpawnPortal spawnPortal;
    public UIQuete uiQuete;

    public List<int> queteActif;
    public AudioSource audioSource;
    public AudioClip audioClip;

    public AudioSource audioCombat;
    public AudioClip audioClipCombat;
    public Menu menu;
    public int nbrMonstreEnter = 0; // le nombre de monstre qui me regarde (pour jouer un son)



    public bool canMoove = true;

    public static PlayerCaracteristique myPlayer ;
    

    public int vie;
    public int max_vie;
    public int pm;
    public int max_pm;
    public int pa;
    public int max_pa;
    public int defence;
    public int ap;
    public int force; 
    public int vitesse; 
    public int level;
    public int lvlUp;

    public int ptCaracteristique;





    void Start()
    {
        
        myPlayer = this;
        action = new List<Action>();
        action.Add(null);
        action.Add(fonctionPNJ.Combat);
        action.Add(fonctionPNJ.Achat);
        action.Add(fonctionPNJ.Quete0);

         

        



















    }

    public void CantMoove(bool res)
    {
        canMoove = res;
        miniMap.SetActive(res);
    }

    
    

}


