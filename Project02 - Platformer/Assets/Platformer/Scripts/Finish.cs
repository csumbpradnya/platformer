using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Mario");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mario")
        {
            Debug.Log("You win");
        }
    }
}
