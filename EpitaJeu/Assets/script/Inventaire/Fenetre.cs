using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Fenetre : MonoBehaviour
{
    public PlayerCaracteristique player;
    public Global_inventaire global;
    public string[] liste = { "Equiper", "Drop", "Cancel" };
    public List<Action> fonction;
    public Items.Game game;
    public int index = 0;
    public int id = 0;
    public void UI(int _index, int _id )
    {

        print(_index+"ddd"+_id);
        game =  player.items.allGames[_index];
        index = _index;
        id = _id;
        fonction = new List<Action>();
        if (game.classe[0] == 10)
        {
            liste = new string[] { "Drop","Drop all", "Cancel" };
            fonction.Add(Drop);
            fonction.Add(DropAll);
            fonction.Add(Exit);

        }
        else if (game.classe[0] == 11)
        {
            liste = new string[] {"Utiliser", "Drop", "Cancel" };
            fonction.Add(Use);
            fonction.Add(Drop);
            fonction.Add(Exit);
        }
        else
        {
            liste = new string[] { "Equiper", "Drop", "Cancel" };
            fonction.Add(Equip);
            fonction.Add(Drop);
            fonction.Add(Exit);
        }

        
        for (int i = 0; i!= liste.Length; i++)
        {
            GameObject g = transform.GetChild(i).gameObject;
            g.transform.GetChild(0).GetComponent<Text>().text = liste[i];
            g.transform.GetComponent<Button>().onClick.RemoveAllListeners();
            g.transform.GetComponent<Button>().AddEventListener(i, ItemClicked);
        }
         
    }
    public void ItemClicked (int _index)
    {
        
        fonction[_index]();
    }
    public void Drop()
    {
        if (global.inventory.inventaireNombre[id] >= 2)
        {
            global.inventory.inventaireNombre[id] -= 1;
            global.UI(index);
        }
        else
        {
            int lieu = player.fonction.Index(index, global.inventory.equipement);
            if (lieu == 999)
            {
                global.inventory.inventaire.RemoveAt(id);
                global.inventory.inventaireNombre.RemoveAt(id);
                global.UI(0);
                Exit();
            }
            else
            {
                StartCoroutine(Fonction.Erreur(player, "Vous ne pouvez pas supprimer un item équipé"));
            }



        }
        
    }
    public void DropAll()
    {
        global.inventory.inventaire.RemoveAt(id);
        global.inventory.inventaireNombre.RemoveAt(id);
        Exit();

    }

    public void Exit()
    {
        global.UI(index);
        gameObject.SetActive(false);
    }

    public void Use()
    {
        int[] p = player.items.allGames[index].classe;
        player.attribut.Classe(p, player.items.allGames[index].gain, 1);
        Drop();
    }
    public void Equip()
    {

        List<int> equipement = global.inventory.equipement;
        List<int> classe = new List<int> ();
        for (int i = 0; i != equipement.Count; i++)
        {
            classe.Add(player.items.allGames[equipement[i]].classe[0]);
        }
        int itemToChange = player.fonction.Index(game.classe[0], classe );
        
        player.attribut.Classe(player.items.allGames[itemToChange].classe, player.items.allGames[itemToChange].gain, -1);
        int lieu = player.fonction.Index(itemToChange, global.inventory.inventaire);
        
        global.inventory.equipement[lieu] = index;
        player.attribut.Classe(player.items.allGames[index].classe, player.items.allGames[index].gain, 1);
        Exit();
    }


    public void UISpell(int _index,int _id)
    {
        game = player.items.allGames[_index];
        index = _index;
        id = _id;
        fonction = new List<Action>();
       
        liste = new string[] { "Equiper", "Deséquiper", "Cancel" };
        fonction.Add(EquipeSpell);
        fonction.Add(Desequiper);
        fonction.Add(ExitSpell);




        for (int i = 0; i != liste.Length; i++)
        {
            GameObject g = transform.GetChild(i).gameObject;
            g.transform.GetChild(0).GetComponent<Text>().text = liste[i];
            g.transform.GetComponent<Button>().onClick.RemoveAllListeners();
            g.transform.GetComponent<Button>().AddEventListener(i, ItemClicked);
        }

    }
    
    public void EquipeSpell()
    {
        List<int> equipement = global.inventory.equipeSort;
        int lieu = player.fonction.Index(index, equipement);
        if (lieu == 999)
        {
            if (equipement.Count < 6)
            {
                global.inventory.equipeSort.Add(index);
                ExitSpell();
            }
            else
            {
                StartCoroutine(Fonction.Erreur(player, "Vous avez atteint le nombre maximum de sort équipé"));
            }
        }
        else
        {
            StartCoroutine(Fonction.Erreur(player, "Vous ne pouvez pas vous équipé une seconde fois de ce sort"));
        }

    }

    public void Desequiper()
    {
        global.inventory.equipeSort.Remove(index);
        ExitSpell();
    }
    public void ExitSpell()
    {
        global.UISpell(index);
        gameObject.SetActive(false);
    }
}
