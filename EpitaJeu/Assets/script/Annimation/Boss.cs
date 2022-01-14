using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{

   
    public NavMeshAgent nav;
    public Animator animator;
    
    
    public PlayerCaracteristique player;
    
    public float speed;
    public bool wait = false;   


    void Update()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.sousParent.transform.position) <= 5f)
            {
                player.canMoove = true;
                StartCoroutine(Attaque());
            }
        }

    }
    private void OnTriggerStay(Collider colision)
    {
        if (colision.CompareTag("Player"))
        {
            Destination(colision.transform.position);
        }
    }


    public IEnumerator Attaque()
    {
        
        //nav.Stop();
        nav.isStopped = true;
        player.CantMoove(false);
        Vector3 v = new Vector3(player.sousParent.transform.position.x, transform.position.y, player.sousParent.transform.position.z);
        transform.LookAt(v);
        yield return new WaitForSeconds(1);
        transform.LookAt(v);
        nav.speed = 0;
        animator.Play("Attaque");
        animator.SetFloat("Speed", 0);
    }
    public void Destination(Vector3 _location)
    {               
        if (!wait)
        {
            animator.SetFloat("Speed", 12);
            nav.speed = speed;
            nav.SetDestination(_location);
            wait = true;
        }
 
    }


}
