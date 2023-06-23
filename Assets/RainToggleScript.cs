using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainToggleScript : MonoBehaviour
{
    public float volume;
    
    // Start is called before the first frame update
    void Start()
    {
        volume = AudioManager.Instance.SourceRain.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioManager.Instance.SourceRain.volume = volume;

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        AudioManager.Instance.SourceRain.volume = 0;
    }
}
