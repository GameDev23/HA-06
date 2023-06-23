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
    public TextMeshProUGUI EnemyHP;
    public TextMeshProUGUI DialogBox;
    public Image HpBar;
    
    private Coroutine storedRoutine = null;
    
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
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        
        //TODO DELETE ENEMY HEALTH
        EnemyHP.text = "HP " + enemyScript.Healthpoints;
        
        //Set PlayerHp
        HpTextMesh.text = "HP " + Manager.Instance.PlayerHp;
        //enemy.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

    }

    public void ShowDialog(string text)
    {
        
        if(storedRoutine != null)
            StopCoroutine(storedRoutine);
        storedRoutine = StartCoroutine(buildDialog(text));
    }
    IEnumerator buildDialog(string text)
    {
        DialogBox.text = "";
        foreach (char letter in text)
        {
            DialogBox.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
