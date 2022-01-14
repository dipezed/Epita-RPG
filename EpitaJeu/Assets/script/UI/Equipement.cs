using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Equipement : MonoBehaviour
{
    public int[] indexItem;
    public Items items;
    public PlayerCaracteristique player;


    private void Start()
    {
        for (int i = 0; i != indexItem.Length; i++)
        {
            Changer(indexItem[i], i);
        }
    }

    public void Changer(int _item, int _index)
    {
        //player.attribut.Classe(items.allGames[_item].classe, items.allGames[_item].gain, 1);

        GameObject parent = transform.GetChild(_index).gameObject;
        parent.transform.GetChild(0).GetComponent<Image>().sprite = items.allGames[_item].Icon;
    }





}