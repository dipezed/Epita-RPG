using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Monstre : MonoBehaviour
{
    [Serializable]
    public struct Monster
    {
        public string Name;
        public string Niveau;
        public GameObject Icone ;
        public int Type;
        

    }


    [SerializeField]
    public Monster[] monstre;

}
