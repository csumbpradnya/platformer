using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text _score;
    private GameObject mario;

    public float score;
    
    public void updateScore()
    {
        score = score + 100f;
        _score.SetText("MARIO" + "        " + "        WORLD" + "\n" + score.ToString() + "                1-1");
    }
}
