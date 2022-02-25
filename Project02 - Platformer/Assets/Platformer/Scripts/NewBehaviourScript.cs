using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float accumulatedTime = 0f;
    private float totalRoundTime = 400f;
    [SerializeField] private TMP_Text timer;
    
    
    // Update is called once per frame
    void Update()
    {
        accumulatedTime += Time.deltaTime;
        if (accumulatedTime > 1f)
        {
            totalRoundTime = totalRoundTime - 1f;
            accumulatedTime = 0f;
            timer.SetText("\n" + totalRoundTime.ToString());
        }
        
        
    }
}
