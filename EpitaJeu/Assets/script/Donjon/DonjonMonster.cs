using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 


public class DonjonMonster : MonoBehaviour
{
    [Serializable]
    public struct Donjon1
    {
        public string niveau;  

        public int lieu;
        public GameObject design;
    }
    [SerializeField]
    public Donjon1[] donjon1; 

}
