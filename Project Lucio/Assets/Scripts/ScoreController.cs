using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {


    //Suma puntuación al jugador seleccionado
    public static void AddScore(Player p, int amount)
    {
        p.score += amount;
    }


}
