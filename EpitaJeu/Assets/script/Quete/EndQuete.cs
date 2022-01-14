using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndQuete : MonoBehaviour
{
    public PlayerCaracteristique player;
    public GameObject king;
    public Text titre;
    public Text level;
    public Image iLevel;
    public Image kingLevel;

    public void Active(int _index)
    {
        StartCoroutine(UI(_index));
    }
    public IEnumerator UI (int _index)
    {
        
        Delete();
        float delay = 0.5f;
        Quete.Quest quest = player.quete.quest[_index];
        titre.gameObject.SetActive(true);
        titre.text = quest.titre;

        yield return new WaitForSeconds(delay);

        kingLevel.gameObject.SetActive(true);
        level.GetComponent<Text>().text = player.lvlUp + " / " + player.level * 100;
        RectTransform rt = iLevel.transform.GetComponent<RectTransform>();
        float res = (float)player.lvlUp / (float)player.level;
        rt.sizeDelta = new Vector2(448f * (res / 100f), 34);
        yield return new WaitForSeconds(delay);

        Fonction.LvlUp(quest.experience, player);

        level.GetComponent<Text>().text = player.lvlUp + " / " + player.level * 100;
        rt = iLevel.transform.GetComponent<RectTransform>();
        res = (float)player.lvlUp / (float)player.level;
        rt.sizeDelta = new Vector2(448f * (res / 100f), 34);

        yield return new WaitForSeconds(delay);



        Inventory inventory = player.global.inventory;
        int lieu = player.fonction.Index(quest.objet[0], inventory.inventaire);
        
        if (lieu == 999)
        {
            inventory.Add(quest.objet[0], quest.gain[0]);
        }
        else
        {
            inventory.inventaireNombre[lieu] += quest.gain[0];
        }
        GameObject parent = transform.GetChild(0).gameObject;
        parent.SetActive(true);
        parent.transform.GetChild(1).GetComponent<Image>().sprite = player.items.allGames[quest.objet[0]].Icon;
        parent.transform.GetChild(2).GetComponent<Text>().text = player.items.allGames[quest.objet[0]].Name + " x " + quest.gain[0];

        for (int i = 1; i != quest.gain.Count; i++)
        {   
            yield return new WaitForSeconds(delay);


            
            lieu = player.fonction.Index(quest.objet[i], inventory.inventaire);
            
            if (lieu == 999)
            {
                inventory.Add(quest.objet[i], quest.gain[i]);
            }
            else
            {
                inventory.inventaireNombre[lieu] += quest.gain[i];
            }


            GameObject g = Instantiate(parent, transform);
            g.transform.GetChild(1).GetComponent<Image>().sprite = player.items.allGames[quest.objet[i]].Icon;
            g.transform.GetChild(2).GetComponent<Text>().text = player.items.allGames[quest.objet[i]].Name + " x " + quest.gain[i];

        }



        yield return new WaitForSeconds(5f);
        parent.SetActive(false);
        titre.gameObject.SetActive(false);
        kingLevel.gameObject.SetActive(false);
        king.SetActive(false);
        


    }
    public void Delete()
    {
        int i = 1;
        while (true)
        {
            try
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            catch
            {
                break;
            }
        }
    }
}
