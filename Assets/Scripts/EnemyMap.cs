using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMap : MonoBehaviour
{
    private bool isEntered = false;
    [SerializeField] private GameObject enemy;

    [SerializeField] private Sprite backgroundImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEntered)
        {
            if (Input.GetButtonDown("Jump"))
            {

                Debug.Log("player pressed space");
                Debug.Log("Switch to enter fight");
                FightHandler.Instance.enemy = enemy;
                FightHandler.Instance.BackgroundSpriteRenderer.sprite = backgroundImage;
                StateManager.Instance.SwitchState(StateManager.Instance.EnterFight);
            
            }
        }

    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
        if(other.CompareTag("Player"))
            isEntered = true;
    }



    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            isEntered = false;
    }
}
