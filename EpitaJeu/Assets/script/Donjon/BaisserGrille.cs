using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaisserGrille : MonoBehaviour
{
    public GameObject grille;
    public Transform original ;
    public Transform nouvelle;
    public bool ouvert = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ouvert)
        {
            print("open");
            grille.transform.position = nouvelle.transform.position;
            ouvert = false;
        }
    }
    public void Open ()
    {
        grille.transform.position = original.transform.position;
        ouvert = true;
    }
}
