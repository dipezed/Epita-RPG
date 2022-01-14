using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Classes : MonoBehaviour
{
    [Serializable]
    public struct Gain
    {
        public string Name;
        public Sprite Icon;
        public GameObject Asset;
        public string Surnom;
        public string Description;
    }


    [SerializeField]
    public Gain[] classe;
}
