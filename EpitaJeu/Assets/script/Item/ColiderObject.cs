using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderObject : MonoBehaviour
{
    public PlayerCaracteristique player;
    public int item;
    private int lieu = 999;
    private int size;



    private void OnTriggerEnter(Collider colision)
    {
        if (colision.transform.CompareTag("Player"))
        {           
            
            lieu = player.fonction.Index(item, player.colision);



            if (lieu != 999)
            {
                player.nombre[lieu] += 1;

            }
            else
            {
                player.colision.Add(item);
                player.nombre.Add(1);

            }
            size = player.nombre.Count;
            
            player.objet.UI();            
            lieu = player.fonction.Index(item, player.colision);
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            
            lieu = player.fonction.Index(item, player.colision);
            try
            {

                if (player.colision[lieu] != item)
                {
                    Destroy(gameObject.transform.parent.gameObject);
                    ApperUI();
                }
            }
            catch
            {

                Destroy(gameObject.transform.parent.gameObject);
                ApperUI();
            }
        }


    }


    private void OnTriggerExit(Collider colision)
    {
        if (colision.transform.CompareTag("Player"))
        {

            lieu = player.fonction.Index(item, player.colision);

            if (player.nombre[lieu] >= 2)
            {
                player.nombre[lieu] -= 1;
                
            }
            else
            {
                player.colision.Remove(item);
                player.nombre.RemoveAt(lieu);
            }


            ApperUI();

        }
    }


    public void ApperUI()
    {

        if (player.nombre.Count == 0)
        {
            player.objet.moi.SetActive(false);
            player.bouton.SetActive(false);
        }
        else
        {
            Fonction.Lettre("E", player);
            player.objet.moi.SetActive(true);
            //player.objet.UI();
        }
    }
}
