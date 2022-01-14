using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossDonjon : MonoBehaviour
{


    public Animator animator;

    public PlayerCaracteristique player;
    public bool attaquer = false;

    public float posAttaque = 3f;
    public int combat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.sousParent.transform.position) <= posAttaque && !attaquer)
        {
            attaquer = true;
            StartCoroutine(Attaque());

        }
    }
    public IEnumerator Attaque()
    {
        

        player.CantMoove(false);
        Vector3 v = new Vector3(player.sousParent.transform.position.x, transform.position.y, player.sousParent.transform.position.z);
        transform.LookAt(v);
        yield return new WaitForSeconds(1);
        transform.LookAt(v);
        animator.Play("Attaque");
        yield return new WaitForSeconds(1);
        player.CantMoove(true);
        Fonction.Combat(player, combat);
    }
}
