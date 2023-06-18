using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

public class Lightning : MonoBehaviour
{
    [SerializeField] private Light2D[] Lights;
    public float blitzDauer = 0.1f; // Dauer eines Blitzes
    public float blitzIntensitaet = 1f; // Maximale Intensität während des Blitzes
    
    public float timer = 0f;
    public float originalIntensitaet;

    public float delayBetweenLightning = 5f;
    [FormerlySerializedAs("isDuringLightning")] public int LightningCountDuringLightning = 0;

    // Start is called before the first frame update
    void Start()
    {
        originalIntensitaet = Lights[0].intensity;
    }

    // Update is called once per frame
    void Update()
    {
        

        // Überprüfe, ob es Zeit für einen Blitz ist
        if (delayBetweenLightning <= 0 && LightningCountDuringLightning > 0)
        {
            Blitz();
            delayBetweenLightning = Random.Range(0.1f, 0.5f);
            AudioManager.Instance.SourceSFX.PlayOneShot(AudioManager.Instance.Thunder, 0.01f);

        }
        else if(delayBetweenLightning <= 0)
        {
            delayBetweenLightning = Random.Range(3f,5f);
            LightningCountDuringLightning = Random.Range(2, 7);
        }

        delayBetweenLightning -= Time.deltaTime;

    }
    
    private void Blitz()
    {

        // Ändere die Intensität aller Spotlights während des Blitzes
        foreach (Light2D light in Lights)
        {
            light.intensity = blitzIntensitaet;
        }

        LightningCountDuringLightning--;
        // Starte einen Coroutine, um die Intensität nach dem Blitz wieder zurückzusetzen
        StartCoroutine(ResetSpotlightIntensitaet());
    }

    private IEnumerator ResetSpotlightIntensitaet()
    {
        yield return new WaitForSeconds(blitzDauer);

        // Setze die Intensität aller Spotlights auf die ursprüngliche Intensität zurück
        foreach (Light2D light in Lights)
        {
            light.intensity = originalIntensitaet;
        }
    }
}
