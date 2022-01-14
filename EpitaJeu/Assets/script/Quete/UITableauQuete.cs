using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UITableauQuete : MonoBehaviour
{
    public PlayerCaracteristique player;
    public int index;
    public Quete quete;
    public List<int> liste;
    public int lieu;
    public Button suivant;
    public Button precedant;
    public Button close;

    public GameObject king;
    public Sprite iSelect;
    public Sprite iDeselect;




    void Start()
    {
        suivant.onClick.AddListener(Suivant);

        precedant.onClick.AddListener(Precedant);

        close.onClick.AddListener(Close);
        
    }
    public void UI(int _index)
    {
        Delete();


        index = _index;
        Quete.Quest[] quest = quete.quest;
        GameObject parent = transform.GetChild(0).gameObject;
        int position = liste.Count / (index + 3);
        if (position == 0)
        {
            position = liste.Count % 3;
        }
        else
        {
            position = 3;
        }
        
        parent.SetActive(true);
        for (int i = index; i != index + position; i++)
        {
            GameObject g = Instantiate(parent, transform);
            g.GetComponent<Button>().onClick.RemoveAllListeners();
            g.GetComponent<Button>().AddEventListener(liste[i], onClick);

            int pos = player.fonction.Index(liste[i], player.queteActif);
            if (pos == 999)
            {
                g.GetComponent<Image>().sprite = iDeselect;
            }
            else
            {
                g.GetComponent<Image>().sprite = iSelect;
            }
            g.transform.GetChild(0).GetComponent<Text>().text = quest[liste[i]].titre;
            GameObject p = g.transform.GetChild(1).gameObject;
            p.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = quest[liste[i]].niveauRequis;
            p.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = quest[liste[i]].experience.ToString() + " Exp";
            
            for (int k = 0; k!= 4; k++)
            {
                try
                {
                    int s = quest[liste[i]].objet[k];
                    GameObject t = p.transform.GetChild(2).GetChild(1).GetChild(k).gameObject;
                    
                    t.SetActive(true);
                    t.transform.GetComponent<Text>().text = player.items.allGames[s].Name;
                }
                catch
                {
                    GameObject t = p.transform.GetChild(2).GetChild(1).GetChild(k).gameObject;
                    t.SetActive(false);
                }
                
            }
            
            
        }
        if (position != 0)
        {
            Destroy(parent);
        }
        else
        {
            parent.SetActive(false);
        }
         
        
    }

    public void Delete()
    {
        int i = 1;
        while (i != 3)
        {
            try
            {
                GameObject p = transform.GetChild(i).gameObject;
                Destroy(p);
                i++;
            }
            catch
            {
                break;
            }
        }

        

    }

    void Suivant()
    {
        if (liste.Count > lieu + 3)
        {
            lieu += 3;
            UI(lieu);
        }
    }
    void Precedant()
    {
        if (lieu >= 3)
        {
            lieu -= 3;
            UI(lieu);
        }
    }
    public void onClick(int _index)
    {
        int position = player.fonction.Index(_index, player.queteActif);
        if (position == 999)
        {
            player.queteActif.Add(_index);
        }
        else
        {
            player.queteActif.RemoveAt(position);
        }
        UI(lieu);
    }
    void Close()
    {
        king.SetActive(false);
        player.CantMoove(true);
    }
}
