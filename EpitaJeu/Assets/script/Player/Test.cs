using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject po;
    public PlayerCaracteristique player;
    private void Update()
    {
       
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        Ray ray2 = new Ray(transform.position, transform.TransformDirection(new Vector3(0.05f,0,0.95f)));
        Ray ray3 = new Ray(transform.position, transform.TransformDirection(new Vector3(-0.05f, 0, 1.05f)));
        RaycastHit hit;
        
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0.05f, 0, 0.95f)) * 3, Color.yellow);
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-0.05f, 0, 1.05f)) * 3, Color.yellow);
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-0, 0, 1f)) * 3, Color.yellow);
        if (Physics.Raycast(ray, out hit,3)|| Physics.Raycast(ray2, out hit, 3) || Physics.Raycast(ray3, out hit, 3))
        {
            
            if (hit.transform.gameObject.tag == "Objet")
            {
                po = hit.transform.gameObject;
                po.GetComponent<Outline>().enabled = true;
                Fonction.Lettre("F", player);
                if (Input.GetKeyUp("f"))
                {
                    po.GetComponent<Couper>().player = player;
                    po.GetComponent<Couper>().Cut();                    
                }

            }
            else if (hit.transform.gameObject.tag == "Tableau")
            {
                po = hit.transform.gameObject;
                po.GetComponent<Outline>().enabled = true;
                Fonction.Lettre("F", player);
                if (Input.GetKeyUp("f"))
                {
                    po.GetComponent<TableauQuete>().Clique();
                }
            }            
            else if (hit.transform.gameObject.tag == "PNJ")
            {
                po = hit.transform.gameObject;
                po.GetComponent<Outline>().enabled = true;
                Fonction.Lettre("F", player);
                po.GetComponent<PNJParol>().DontMove();
                if (Input.GetKeyUp("f"))
                {
                    po.GetComponent<PNJParol>().Speak();
                }
            }

            else if (hit.transform.gameObject.tag == "Forge")
            {
                po = hit.transform.gameObject;
                po.GetComponent<Outline>().enabled = true;
                Fonction.Lettre("F", player);
                
                if (Input.GetKeyUp("f"))
                {
                    po.GetComponent<Forge>().UI();
                }
            }
            else
            {
                if (po != null)
                {
                    po.GetComponent<Outline>().enabled = false;
                    po = null;
                }                
                
            }
            
        }
        else
        {
            player.bouton.SetActive(false);
            if (po != null)
            {
                po.GetComponent<Outline>().enabled = false;
                po = null;
            }
        }

    }

   
}
