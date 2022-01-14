using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartDonjon : MonoBehaviour
{
    public PlayerCaracteristique player;
    public string donjon;
    public BaisserGrille grille;

    [Serializable]
    public struct  PosMonstre
    {
        public int[] index;
    }
    [SerializeField]

    public GameObject[] lieu;
    public PosMonstre[] index;
    public int[] combat;
    public GameObject[] position;


    public GameObject[] bossLieu;
    public int[] bossIndex;
    public int[] bossCombat;
    public GameObject[] bossPosition;


    public void Change()
    {
        grille.Open();
        for (int i = 0; i!= lieu.Length; i++)
        {
            lieu[i].GetComponent<Donjon>().combat = combat[i];
            lieu[i].GetComponent<Donjon>().player = player;
            lieu[i].GetComponent<Donjon>().index = index[i].index;
            lieu[i].GetComponent<Donjon>().lieu = lieu[i];
            lieu[i].GetComponent<Donjon>().position = position[i];
            lieu[i].GetComponent<Donjon>().Charger();
        }

        for (int i = 0; i != bossLieu.Length; i++)
        {

            bossLieu[i].GetComponent<DonjonBoss>().combat = bossCombat[i];
            bossLieu[i].GetComponent<DonjonBoss>().player = player;
            bossLieu[i].GetComponent<DonjonBoss>().index = bossIndex[i] ;
            bossLieu[i].GetComponent<DonjonBoss>().position = bossPosition[i];
            bossLieu[i].GetComponent<DonjonBoss>().lieu = bossLieu[i];
            bossLieu[i].GetComponent<DonjonBoss>().Charger();
        }
    }
}
