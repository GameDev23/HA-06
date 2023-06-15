using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DavidTriggerScript : MonoBehaviour
{
    [SerializeField] private GameObject TargetPos;
    
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entered Trigger " + this.name);
            Player.transform.position = TargetPos.transform.position;
        }
    }
}
