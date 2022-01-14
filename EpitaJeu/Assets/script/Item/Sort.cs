using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sort : MonoBehaviour
{

    [Serializable]
    public struct Sortilege
    {
        public string Name;
        public string Description;
        public Sprite Icon;
        public int[] classe;
        public int[] degat;
    }


    [SerializeField]
    public Sortilege[] sort;
}
