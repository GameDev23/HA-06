using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightHandler : MonoBehaviour
{
    public static FightHandler Instance;

    public GameObject enemy;
    public GameObject enemySpawnPos;
    public SpriteRenderer BackgroundSpriteRenderer;
    public Sprite backgroundImage;
    public GameObject CanvasFight;
    
    public Button AttackButton;
    public Button DefendButton;
    public Button HealButton;
    public Button RunButton;

    public TextMeshProUGUI HpTextMesh;
    
    // Start is called before the first frame update
    void Start()
    {
        // Creating singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterFight()
    {
        //Activate FightUI
        CanvasFight.SetActive(true);
        
        //Spawn enemy
        enemy = Instantiate(enemy, enemySpawnPos.transform);
        //enemy.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);


    }
}
