using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Items : MonoBehaviour
{
    [Serializable]
    public struct Game
    {
        public string Name;
        public string Description;
        public Sprite Icon;
        public int[] classe;
        public int[] gain;
        public int[] requis;
        public int[] nombre;
        public int[] cout;
        public int rareter;
    }


    [SerializeField]
    public Game[] allGames;


    public int size;

    public PlayerCaracteristique player;

    private void Start()
    {
        // print(player.classes.gain[allGames[2].classe[1]].Name);
        // print(allGames[player.listeUI.inventaire[0]].Description);
        // print(allGames[player.equipement1].Name);
    }

}
