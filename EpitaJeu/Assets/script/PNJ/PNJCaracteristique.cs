using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJCaracteristique : MonoBehaviour
{
    public int max_vie;
    public int vie;
    public int pa;
    public int pm;
    public int classe;
    public int ap;
    public string nom;
    public int vitesse;
    public int defence;
    public bool isInvinsible = false;

    public Animator animator;


    public IEnumerator TakeDamage(int _degat)
    {
        _degat -= defence;
        if (_degat > 0 && !isInvinsible)
        {
            vie -= _degat; 
            if (vie <= 0)
            {
                animator.Play("Mort");
                yield return new WaitForSeconds(4);
                Destroy(gameObject);
            }
            else
            {
                animator.Play("Degat");
                isInvinsible = true;
                yield return new WaitForSeconds(4);
                isInvinsible = false; 
            }            

        }
    }
    
}
