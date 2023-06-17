using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightHandler : MonoBehaviour
{
    public static FightHandler Instance;

    public GameObject enemy;
    public GameObject enemySpawnPos;
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
        GameObject enemyInstance = Instantiate(enemy, enemySpawnPos.transform);
        enemyInstance.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Debug.Log(enemyInstance.transform.localScale);
        //enemyInstance.transform.position = enemySpawnPos.transform.position;
    }
}
