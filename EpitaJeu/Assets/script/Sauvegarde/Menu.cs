using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public PlayerCaracteristique player;
    public Sauvegarde sauvegarde;
    
    public Text level;
    public Image iLevel;

    public Button continuer;
    public Button bSauvegarde;
    public Button exit;

    private void Start()
    {
        continuer.onClick.AddListener(Continuer);
        bSauvegarde.onClick.AddListener(Sauvegarde);
    }
    public void UI()
    {
        
        level.GetComponent<Text>().text = player.lvlUp + " / " + player.level * 100;
        RectTransform rt = iLevel.transform.GetComponent<RectTransform>();
        float res = (float)player.lvlUp / (float)player.level;
        rt.sizeDelta = new Vector2(448f * (res / 100f), 34);
    }

    void Continuer()
    {
        gameObject.SetActive(false) ;
        player.CantMoove(true) ;
    }
    void Sauvegarde()
    {
        sauvegarde.SaveData();
    }
}
