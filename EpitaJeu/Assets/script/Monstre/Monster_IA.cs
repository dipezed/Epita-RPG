using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_IA : MonoBehaviour
{
    public bool wait = false;
    public NavMeshAgent nav;
    public Animator animator;
    public GameObject waypoint;
    public int speed;
    public PlayerCaracteristique player;
    public bool attaquer = false;

    public float posAttaque = 3f;
    public int combat; 


    void Start()
    {
        nav.speed = speed;
        Destination();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, nav.destination) <= 1f && !wait )
        {            
            Destination();
            
        }

        if (Vector3.Distance(transform.position,player.sousParent.transform.position)<= posAttaque && !attaquer)
        {
            attaquer = true;
            StartCoroutine(Attaque());
            
        }
        

    }

    public void Destination()
    {
        if (!attaquer)
        {
            int locY = Random.Range(0, waypoint.transform.childCount ); // 11 et 16 sont les tailles des games objects 
            int locX = Random.Range(0, waypoint.transform.GetChild(locY).childCount );
            
            animator.SetFloat("Speed", 8);
            Transform target = waypoint.transform.GetChild(locY).GetChild(locX);
            nav.SetDestination(target.position);
        }
        
        }    

    public IEnumerator Attaque()
    {
        animator.SetFloat("Speed", 0);
        nav.isStopped = true;
        player.CantMoove(false);
        Vector3 v = new Vector3(player.sousParent.transform.position.x, transform.position.y, player.sousParent.transform.position.z);
        transform.LookAt(v);
        yield return new WaitForSeconds(1);
        transform.LookAt(v);
        nav.speed = 0;
        animator.Play("Attaque");
        animator.SetFloat("Speed", 0);
        yield return new WaitForSeconds(1);
        player.CantMoove(true);
        Fonction.Combat(player, combat);
    }

   


}
