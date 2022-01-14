using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribut : MonoBehaviour
{
    public PlayerCaracteristique player;

    public void Vie(int _life)
    {
        if (player.vie != player.max_vie)
        {
            player.vie += _life;
        }
    }


    public void MaxVie(int _gain)
    {
        player.max_vie += _gain;
        player.vie += _gain;
    }

    public void MaxPA (int _gain)
    {
        player.max_pa += _gain;
    }
    public void MaxPM (int _gain)
    {
        player.max_pm += _gain;
    }
    public void AP(int _ap)
    {
        player.ap += _ap;
    }
    public void Defence(int _defence)
    {
        player.defence += _defence;
    }
    public void Force(int _force)
    {
        player.force += _force;
    }

    public void Vitesse(int _vitesse)
    {
        player.vitesse += _vitesse;
    }


    public void Classe(int[] _classe, int[] _gain, int positif)
    {
        for (int i = 0; i != _classe.Length; i++)
        {
            if (_classe[i] == 0)
            {
                Vie(_gain[i - 1]);
            }

            else if (_classe[i] == 1)
            {
                MaxVie(_gain[i - 1] * positif);
            }
            else if (_classe[i] == 3)
            {
                MaxPA(_gain[i - 1] * positif);
            }
            else if (_classe[i] == 5)
            {
                MaxPM(_gain[i - 1] * positif);
            }

            else if (_classe[i] == 6)
            {
                Defence(_gain[i - 1] * positif);
            }           
            else if (_classe[i] == 7)
            {
                AP(_gain[i - 1] * positif);
            }
            else if (_classe[i] == 8)
            {
                Force(_gain[i - 1] * positif);
            }

            else if (_classe[i] == 9)
            {
                Vitesse(_gain[i - 1] * positif);
            }



        }

    }
}
