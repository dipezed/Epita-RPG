using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterVision : MonoBehaviour
{
    public Monster_IA monsterIA;
    public Animator animator;
    public int fastSpeed;
    
    
    public bool playSound = true;
    


    


    private void OnTriggerStay(Collider colision)
    {
        if (colision.CompareTag("Player") )
        {
            Destination(colision.transform.position);

        }

    }
    private void OnTriggerExit(Collider colision)
    {
        if (colision.CompareTag("Player"))
        {

            monsterIA.player.nbrMonstreEnter -= 1;
            playSound = true;
            if (monsterIA.player.nbrMonstreEnter == 0)
            {
                monsterIA.player.audioSource.Play();
                monsterIA.player.audioCombat.Pause();
            }

            


            monsterIA.wait = false;
            animator.SetFloat("Speed", 8);
            monsterIA.nav.speed = monsterIA.speed;

        }
       
    }

   

    public void Destination(Vector3 _location)
    {
        if (playSound)
        {
            monsterIA.player.nbrMonstreEnter += 1;
            playSound = false;
            if (monsterIA.player.nbrMonstreEnter == 1)
            {
                monsterIA.player.audioSource.Pause();            
                monsterIA.player.audioCombat.Play();
            }

            
            
        }
        if (!monsterIA.attaquer)
        {
            monsterIA.wait = true;
            animator.SetFloat("Speed", 12);
            monsterIA.nav.speed = fastSpeed;
            monsterIA.nav.SetDestination(_location);    
        }
        
    }
}
