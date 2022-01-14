using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sauvegarde : MonoBehaviour
{
    public PlayerCaracteristique player;

    private void Start()
    {
        GetData();
    }
    public  void SaveData()
    {
        SaveCatacteristique();
        SaveInventory();
        SaveOther();
    }

    public void SaveInventory()
    {
        List<int> liste = player.global.inventory.inventaire;
        List<int> nombre = player.global.inventory.inventaireNombre ;
        for (int i = 0; i!=liste.Count; i++)
        {
            PlayerPrefs.SetInt("inventaire"+i, liste[i]);            
            PlayerPrefs.SetInt("inventaireNombre" + i, nombre[i]);
        }
        PlayerPrefs.SetInt("inventaire" + liste.Count, 0);
        PlayerPrefs.SetInt("inventaireNombre" + liste.Count, 0);
        liste = player.global.inventory.equipement;
        for (int i = 0; i != liste.Count; i++)
        {
            PlayerPrefs.SetInt("equipement" + i, liste[i]);            
        }
    }


    public void SaveCatacteristique()
    {
        PlayerPrefs.SetInt("vie",player.vie);
        PlayerPrefs.SetInt("max_vie", player.max_vie);
        PlayerPrefs.SetInt("pm", player.pm);
        PlayerPrefs.SetInt("max_pm", player.max_pm);
        PlayerPrefs.SetInt("pa", player.pa);
        PlayerPrefs.SetInt("max_pa", player.max_pa);
        PlayerPrefs.SetInt("defence", player.defence);
        PlayerPrefs.SetInt("ap", player.ap);
        PlayerPrefs.SetInt("force", player.force);
        PlayerPrefs.SetInt("vitesse", player.vitesse);
        PlayerPrefs.SetInt("level", player.level);
        PlayerPrefs.SetInt("lvlUp", player.lvlUp);
        PlayerPrefs.SetInt("ptCaracteristique", player.ptCaracteristique);

        int[] point = player.caracteristique.nbrPoint;
        for (int i = 0; i != point.Length; i++)
        {
            PlayerPrefs.SetInt("point" + i, point[i]);
        }
    }

    public void SaveOther()
    {
        PlayerPrefs.SetFloat("x", player.sousParent.transform.position.x);
        PlayerPrefs.SetFloat("y", player.sousParent.transform.position.y);
        PlayerPrefs.SetFloat("z", player.sousParent.transform.position.z);
    }

    public void GetData()
    {
        GetInventory();
        GetCatacteristique();
        GetOther();
    }
    public void GetInventory()
    {
        List<int> liste = player.global.inventory.inventaire;
        List<int> nombre = player.global.inventory.inventaireNombre;
        int i = 0;
        player.global.inventory.inventaire = new List<int>();
        player.global.inventory.inventaireNombre = new List<int>();
        while (PlayerPrefs.GetInt("inventaireNombre" + i, 0) != 0)
        {                      
            player.global.inventory.inventaire.Add(PlayerPrefs.GetInt("inventaire" + i, 0));
            player.global.inventory.inventaireNombre.Add(PlayerPrefs.GetInt("inventaireNombre" + i, 0));                
            i++;                        
        }

        
        for (int s = 0; s != player.global.inventory.equipement.Count; s++)
        {
            player.global.inventory.equipement[s] = PlayerPrefs.GetInt("equipement" + s,0);
        }
    }

    public void GetCatacteristique()
    {
        player.vie = PlayerPrefs.GetInt("vie", 0);
        player.max_vie = PlayerPrefs.GetInt("max_vie", 0);
        player.pm = PlayerPrefs.GetInt("pm", 0);
        player.max_pm = PlayerPrefs.GetInt("max_pm", 0);
        player.pa = PlayerPrefs.GetInt("pa", 0);
        player.max_pa = PlayerPrefs.GetInt("max_pa", 0);
        player.defence = PlayerPrefs.GetInt("defence", 0);
        player.ap = PlayerPrefs.GetInt("ap", 0);
        player.force = PlayerPrefs.GetInt("force", 0);
        player.level = PlayerPrefs.GetInt("level", 0);
        player.lvlUp = PlayerPrefs.GetInt("lvlUp", 0);

        player.ptCaracteristique = PlayerPrefs.GetInt("ptCaracteristique", 0);

        
        for (int i = 0; i != player.caracteristique.nbrPoint.Length; i++)
        {
            player.caracteristique.nbrPoint[i] = PlayerPrefs.GetInt("point" + i, 0);
        }
    }
    public void GetOther()
    {
        player.sousParent.transform.position = new Vector3(
            PlayerPrefs.GetFloat("x", 0),
            PlayerPrefs.GetFloat("y", 0),
            PlayerPrefs.GetFloat("z", 0));
    }
    
}
