using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Instantiating Scene manager
    public static Manager Instance;
    public GameObject Player;
    public bool isFight = false;
    public int PlayerMaxHealth = 10;
    public int PlayerHp;
    public bool isPlayerTurn = true;
    public bool isEnemyCharging = false;
    public bool isPlayerDefending = false;

    private void Awake()
    {
        // Creating singleton
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        PlayerHp = PlayerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
