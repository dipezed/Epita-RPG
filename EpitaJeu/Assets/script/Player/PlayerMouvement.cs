using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    
    public bool inventaire = false;
    public bool carte = false;

    public PlayerCaracteristique player;

    public CharacterController controller;
    public float speed;
    public float turnsmoothtime;
    float turnSmooth;
    public float Gravity = -9.81f;
    public Transform cam;
    public float sensibilite;
    public float sens;
    

    public GameObject camera;
    public GameObject camera_carte;

    public Vector2 turn;

    public Texture2D cursorTexture;

    public AudioClip audioClip;
    public AudioSource audio;
    public bool isPlayerSound = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //KeyCode.Escape
        if (Input.GetKeyUp("p"))
        {
            player.g_Menu.SetActive(true);
            player.CantMoove(false);
            player.menu.UI();
        }
        if (Input.GetKeyUp("i") && (player.canMoove || inventaire))
        {
            inventaire = !inventaire;
            player.gInventaire.SetActive(inventaire);
            player.global.UI(0);
            if (!inventaire)
            {
                player.gCaracteristique.SetActive(false);
            }
            player.CantMoove(!inventaire);

            Curseur.Change(cursorTexture);
        }
            
        if (Input.GetKeyUp("e") && player.canMoove)
        {
            player.objet.TakeItem();
        }

        if (Input.GetKeyUp("n")&& (player.canMoove || carte))
        {
            carte = !carte;
            player.grandMap.SetActive(carte);
            player.uiQuete.UI();
            player.CantMoove(!carte);
        }
        
        
        Vector3 move = new Vector3(0, 0, 0);
        if (player.canMoove)
        {
            camera.transform.GetComponent<Cinemachine.CinemachineFreeLook>().m_XAxis.m_MaxSpeed = sensibilite; 
            Cursor.visible = false;
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            transform.rotation = Quaternion.Euler(0f, cam.eulerAngles.y, 0f);

            if (direction.magnitude >= 0.1f)
            {
                player.animator.SetFloat("Speed", 12);
                float targetAnlge = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAnlge, ref turnSmooth, turnsmoothtime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                
                

                move = Quaternion.Euler(0f, targetAnlge, 0f) * Vector3.forward;
                move.y += Gravity * Time.deltaTime;

                controller.Move(move * speed * Time.deltaTime);
                StartCoroutine(PlaySound());
                

                
                


            }
            else
            {
                player.animator.SetFloat("Speed", 0);
            }   
            
            
        }
        else
        {
            player.animator.SetFloat("Speed", 0);
            Cursor.visible = true;
            camera.transform.GetComponent<Cinemachine.CinemachineFreeLook>().m_XAxis.m_MaxSpeed = 0;
        }
        move.y += Gravity * Time.deltaTime;
        controller.Move(move * speed * Time.deltaTime);




    }
    public IEnumerator PlaySound()
    {
        if (!isPlayerSound)
        {
            isPlayerSound = true;
            audio.clip = audioClip;
            audio.Play();
            yield return new WaitForSeconds(0.2f);
            isPlayerSound = false;
        }
    }

    

}
