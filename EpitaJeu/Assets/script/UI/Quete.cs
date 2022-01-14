using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class Quete : MonoBehaviour
{
    [Serializable]
    public struct Quest
    {
        public string titre;
        public List<string> texte;
        public int experience;
        public List<int> objet;
        public List<int> gain;
        public string niveauRequis; // Le niveau pour faire la quête
        public List<int> fait;  // combien de monstre on été tué
        public List<int> requis;  // combien faut-il tuer de monstres
        public List<int> index;
    }
    [SerializeField]
    public Quest[] quest;





}
