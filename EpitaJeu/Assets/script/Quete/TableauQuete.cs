using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableauQuete : MonoBehaviour
{
    public UITableauQuete quete;
    public PlayerCaracteristique player;
    public Transform[] position;
    public List<int> liste;
    public int durer = 10;


    public void Clique()
    {
        quete.liste = liste;
        quete.king.gameObject.SetActive(true);
        quete.UI(0);
        player.CantMoove(false);
    }
    private void Start()
    {
        StartCoroutine(Spawn());
    }
    public IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(durer+1);

            player.spawnPortal.Spawn(
                position[Random.Range(0, position.Length)],
                durer,
                0,
                0,
                this);

        }
    }
}
