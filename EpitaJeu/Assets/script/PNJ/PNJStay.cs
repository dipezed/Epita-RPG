using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PNJStay : MonoBehaviour
{
    public PlayerCaracteristique player;
    public int fonction; // L'index des fonction 
    public BulleChat Chat;
    
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

    public AudioSource audio;



    
    public void DontMove()
    {
        isEnter = true;        
        audio.enabled = false;       
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
}
