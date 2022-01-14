using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PNJia : MonoBehaviour
{

    public bool wait = false;
    public NavMeshAgent nav;
    public Animator animator;
    
    public GameObject waypoint;
    public int speed ;

    public int loc = 0;
    public int acc = 1; // 1 si il fait A-> B et 2 si il fait B -> A

    public AudioSource audio;
    

    void Start()
    {
        
        nav.speed = speed;
        StartCoroutine(Destination());
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, nav.destination) <= 1f && !wait)
        {
            loc += acc;
            StartCoroutine(Destination());
        }


    }

    public IEnumerator Destination()
    {
        if (loc == waypoint.transform.childCount)
        {            
            acc = -1;
            wait = true;
            animator.SetFloat("Speed", 0);
            audio.enabled = false;
            yield return new WaitForSeconds(3);
            wait = false;
        }   
        else if (loc == -1)
        {
            acc = 1;
            wait = true;
            animator.SetFloat("Speed", 0);
            audio.enabled = false;
            yield return new WaitForSeconds(3);
            wait = false;

        }    
        else
        {
            audio.enabled = true;
            animator.SetFloat("Speed", 6);            
            nav.SetDestination(waypoint.transform.GetChild(loc).position);
        }
        
    }



    // Update is called once per frame



}
