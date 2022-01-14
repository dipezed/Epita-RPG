using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fonction : MonoBehaviour
{
    public Items items;

    public int Search(string _nom, Items.Game[] _game)
    {

        for (int i = 0; i != items.size; i++)
        {
            if (_game[i].Name == _nom)
            {
                return i;
            }
        }

        return 9999;
    }

    public int Index(int _lieu, List<int> _liste)
    {
        for (int i = 0; i != _liste.Count; i++)
        {
            if (_lieu == _liste[i])
            {
                return i;
            }
        }
        return 999;
    }

    public void Change(string _name)
    {
        SceneManager.LoadScene(_name);
    }

    public static void Lettre(string lettre, PlayerCaracteristique player)
    {
        player.bouton.SetActive(true);
        player.bouton.transform.GetChild(0).GetChild(0).transform.GetComponent<Text>().text = lettre;
    }

    public static void LvlUp(int lvl,PlayerCaracteristique player)
    {
        player.lvlUp += lvl;
        int a = player.lvlUp % (player.level * 100);
        
        player.level += (player.lvlUp / (player.level * 100));
       
        player.lvlUp = a;
        print(player.lvlUp);



        
    }

    public static void VerifQuete (PlayerCaracteristique player,int action)
    {
        List<int> quete = player.queteActif;
        bool continuer = true;
        foreach (int i in quete)
        {
            int a = 0;
            foreach(int s in player.quete.quest[i].index)
            {
                if (s == action)
                {
                    player.quete.quest[i].fait[a] += 1;
                    Fonction.FinQuete(player, i);
                    continuer = false;
                    break;
                }
                a++;
            }
            if (!continuer)
            {
                break;
            }
            
        }
    }
    public static void FinQuete (PlayerCaracteristique player, int _index)
    {
        Quete.Quest quete = player.quete.quest[_index];
        bool res = true;
        for (int s = 0; s != quete.fait.Count; s++)
        {
            if (quete.fait[s] < quete.requis[s])
            {
                res = false;
                break;
            }
        }
        if (res)
        {
            player.queteActif.Remove(_index);
            player.gainQuete.SetActive(true);
            player.endQuete.Active(_index);
        }
    }

    public static IEnumerator Erreur (PlayerCaracteristique player, string erreur)
    {
        player.erreur.SetActive(true);
        player.erreur.transform.GetChild(1).GetComponent<Text>().text = erreur;
        
        yield return new WaitForSeconds(5f);
        player.erreur.SetActive(false);
    }

    public static void Combat (PlayerCaracteristique player , int _index)
    {
        player.allCity.ActiveCombat(_index, false);
    }
    public static IEnumerator Donjon(PlayerCaracteristique player, int _index, StartDonjon.PosMonstre[] normalIndex, int[] bossIndex)
    {
        yield return new WaitForSeconds(0.001f);
        player.allCity.Donjon(_index, false,normalIndex, bossIndex);
    }






}
