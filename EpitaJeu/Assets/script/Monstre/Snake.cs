using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    
    public Animator animator;
    public Transform waypoint;
    public bool attaquer = false;
    public PlayerCaracteristique player;
    public int combat;


    private void OnTriggerStay(Collider colision)
    {
        if (colision.CompareTag("Player") && !attaquer)
        {
            StartCoroutine(Attaque());
        }

    }
    



    public IEnumerator Attaque()
    {        

        player.CantMoove(false);
        Vector3 v = new Vector3(player.sousParent.transform.position.x, transform.position.y, player.sousParent.transform.position.z );
        transform.LookAt(v);

        Fonction.Combat(player, combat);
        attaquer = true;
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.position = waypoint.position;
        animator.Play("Attaque");
    }

}
