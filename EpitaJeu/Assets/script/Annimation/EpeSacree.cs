using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpeSacree : MonoBehaviour
{
    public Transform waypoint;
    public GameObject enemie;
    public PlayerCaracteristique player;
    private bool start = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && start)
        {
            StartCoroutine( Spawn());
            //Get();
            start = false;
        }
    }

    public IEnumerator Spawn()
    {
        player.CantMoove(false);
        yield return new WaitForSeconds(1f);
        GameObject ennemi = Instantiate(enemie, waypoint.transform.position, Quaternion.identity);
        enemie.transform.GetComponent<Boss>().player = player;
        Vector3 v = new Vector3(player.sousParent.transform.position.x, transform.position.y, player.sousParent.transform.position.z);
        enemie.transform.LookAt(v);
    }

    public void Get()
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);
        player.global.inventory.Add(4, 1);

    }
}
