using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forge : MonoBehaviour
{
    public bool contact = false;
    public PlayerCaracteristique player;
    public List<int> items;
    public Interface forge;

    public bool cout;


    public void UI()
    {
        forge.cout = cout;
        forge.items = items;
        player.forge.SetActive(true);
        forge.Click(items[0]);
        forge.UI();
        player.CantMoove(false);
    }
}
