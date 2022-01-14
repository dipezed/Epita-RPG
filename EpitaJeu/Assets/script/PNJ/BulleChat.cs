using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BulleChat : MonoBehaviour
{
    public PlayerCaracteristique player;
    public Action fonction;
    public int quete;
    public Text pseudo;
    public Text texte;
    public Text reponse;
    public Image image;

    public Button close;
    public Button use;

    private int lieu = 0;
    private int size = 0;

    private string[] titre;
    private string[] description;
    private new string name;
    private Sprite perso;


    private void Start()
    {
        close.transform.GetComponent<Button>().onClick.AddListener(Close);
        use.transform.GetComponent<Button>().onClick.AddListener(Use);
    }

    public void Speak(string[] _texte, string[] _reponse, string _pseudo, Sprite _personnage)
    {
        titre = _texte;
        description = _reponse;
        name = _pseudo;
        perso = _personnage;
        gameObject.SetActive(true);
        player.canMoove = false;
        size = _texte.Length;
        Charger();
    }

    public void Charger()
    {
        
        image.transform.GetComponent<Image>().sprite = perso;
        texte.transform.GetComponent<Text>().text = titre[lieu];
        reponse.transform.GetComponent<Text>().text = description[lieu];
        pseudo.transform.GetComponent<Text>().text = name;
    }
    public void Use()
    {
        if (lieu + 1 == size)
        {
            Close();

            if (fonction != null)
            {
                if (quete != 999)
                {
                    Quete0(quete);
                }
                else
                {
                    fonction();
                }
                
            }


        }
        else
        {
            lieu += 1;
            Charger();
        }
    }
    public void Close()
    {
        lieu = 0;
        gameObject.SetActive(false);
        player.canMoove = true;        
    }
    public void Quete0(int _lieu)
    {
        Fonction.VerifQuete(player, _lieu);
    }
}
