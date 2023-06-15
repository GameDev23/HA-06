using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start from sub");
    }

    // Update is called once per frame

    public override void Update()
    {
        Debug.Log("Update from Sub");
    }

    public override void attack()
    {
        Debug.Log("Sub attack");
    }
}
