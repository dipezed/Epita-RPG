using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Couper : MonoBehaviour
{

    public int items;
    public bool isEnter;
    public Transform waypoint;

    public int requis = 999;
    public float time;
    public PlayerCaracteristique player;
    private bool iscliquable = true;
    

    public bool canCute = true;
    public GameObject couper;

    private Mesh vivant;
    private  Material[] vivantM;
    private Material[] mort;

    public int nbrCoups;
    public int coupsFait = 0;

    private void Start()
    {
        
        vivantM = gameObject.transform.GetComponent<Renderer>().sharedMaterials;
        mort = couper.transform.GetComponent<Renderer>().sharedMaterials;
        vivant = gameObject.transform.GetComponent<MeshFilter>().sharedMesh;
    }


    

    public IEnumerator Erreur()
    {
        iscliquable = false;
        player.erreur.SetActive(true);
        player.erreur.transform.GetChild(1).GetComponent<Text>().text = "Il vous faut l'item : " + player.items.allGames[requis].Name + " !";
        yield return new WaitForSeconds(2);
        player.erreur.SetActive(false);
        iscliquable = true;

    }

    public void Take()
    {

        gameObject.tag = "Untagged";
        int classe = player.items.allGames[items].classe[0];

        GameObject projectil = player.classes.classe[classe].Asset;

        GameObject boule = Instantiate(projectil, waypoint.transform.position, Quaternion.identity);
        boule.transform.GetChild(1).GetComponent<ColiderObject>().player = player;

        if (couper == null)
        {            
            Destroy(gameObject);
        }
        else
        {
            
            gameObject.transform.GetComponent<MeshFilter>().sharedMesh = couper.transform.GetComponent<MeshFilter>().sharedMesh ;
            gameObject.GetComponent<Renderer>().materials = mort;
            StartCoroutine(Spawn(time));
        }      

        
    }
    public IEnumerator Spawn(float _time)
    {
        canCute = false;
        
        yield return new WaitForSeconds(_time);
        //gameObject.transform.GetComponent<MeshCollider>().sharedMesh = vivant;
        gameObject.transform.GetComponent<MeshFilter>().sharedMesh = vivant;
        gameObject.GetComponent<Renderer>().materials = vivantM;
        canCute = true;
        gameObject.tag = "Objet";
    }

    public void Cut()
    {
        if (iscliquable && canCute)
        {
            if (nbrCoups <= coupsFait)
            {
                int lieu = player.fonction.Index(requis, player.inventaire.inventaire);
                if (requis != 999)
                {
                    if (lieu != 999)
                    {
                        player.animator.Play("Couper");
                        player.bouton.SetActive(false);
                        Take();
                    }
                    else
                    {
                        StartCoroutine(Erreur());
                    }
                }
                else
                {
                    player.animator.Play("Couper");
                    player.bouton.SetActive(false);
                    Take();
                }
            }
            else
            {
                player.animator.Play("Couper");
                coupsFait += 1;
            }
            
        }
        
    }


}
