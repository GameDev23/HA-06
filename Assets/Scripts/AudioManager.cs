using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Instantiating Audio manager
    public static AudioManager Instance;

    public AudioClip Thunder;
    public AudioSource SourceSFX;
    
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
