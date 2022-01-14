using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PNJParol : MonoBehaviour
{
    public PlayerCaracteristique player;
    public int fonction; // L'index des fonction 
    public BulleChat Chat;
    public PNJia pnj;
    public int quete; 


    [Serializable]
    public struct Message
    {
        public string[] texte;
        public string[] reponse;

    }

    [SerializeField]

    public Message[] message;

    public int[] level;
    public Sprite image;
    public string pseudo;
    public bool isEnter = false;

    private string[] titre;
    private string[] description;

    private int index = 0;

    public bool stay = false;

    public AudioSource audio;

    
    private void Update()
    {
        if (!stay)
        {
            if (!gameObject.GetComponent<Outline>().enabled && isEnter)
            {
                StartCoroutine(Go());
            }
        }      
        

    }
    
    public IEnumerator Go()
    {
        isEnter = false;
        yield return new WaitForSeconds(3f);
        
        pnj.nav.speed = pnj.speed;
        audio.enabled = true;
        pnj.animator.SetFloat("Speed", 6);
    }
    public void DontMove()
    {
        if (!stay)
        {
            isEnter = true;
            pnj.nav.speed = 0;
            audio.enabled = false;
            pnj.animator.SetFloat("Speed", 0);
        }

    }
    public void Speak()
    {
        index = Index(player.level);
        titre = message[index].texte;
        description = message[index].reponse;
        Chat.fonction = player.action[fonction];
        Chat.quete = quete;
        Chat.Speak(titre, description, pseudo, image);
    }

    public int Index(int niveau)
    {
        for (int i = 0; i != level.Length; i++)
        {
            if (level[i] <= niveau)
            {

                return i;
            }
        }
        return 999;
    }
    private void Start()
    {
        if (!stay)
        {
            audio.Stop();
        }
    }

}