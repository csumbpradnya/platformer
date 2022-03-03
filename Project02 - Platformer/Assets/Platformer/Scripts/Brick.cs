using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Brick : MonoBehaviour
{
    [SerializeField] private TMP_Text coins;
    private int coinCounter;

    private GameObject mario;
    // Update is called once per frame
    void Update ()
    {
        mario = GameObject.Find("Mario");
        RaycastHit hit; 
        Score score = GameObject.Find("MarioUI").GetComponent<Score>();
        if (Physics.Raycast (mario.transform.position, Vector3.up + new Vector3(0,0.1f,0f), out hit, 1.79f)) {
            if (hit.collider.gameObject.tag == "brick") {
                    Destroy (hit.collider.gameObject);
                    score.updateScore();
                }
                else if (hit.collider.gameObject.tag == "coin")
                {
                    coinCounter++;
                    coins.SetText("xx"+coinCounter.ToString());
                    score.updateScore();
                }
            } 
    }
}
