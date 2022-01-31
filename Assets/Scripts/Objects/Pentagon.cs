using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

public class Pentagon : MonoBehaviour
{
    private Light2D activeLight;
    [SerializeField] private float outDuration;

    private float lightIntensityMax;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        activeLight = GetComponent<Light2D>();
        lightIntensityMax = activeLight.intensity;

        StartCoroutine(TurnOff());
    }

    // Update is called once per frame
    private IEnumerator TurnOff()
    {
        while (timer < 1)
        {
            timer += Time.deltaTime / outDuration;

            activeLight.intensity = (1 - timer) * lightIntensityMax;

            yield return new WaitForEndOfFrame();
        }
        
        if(timer >= 1)
        {
            Destroy(gameObject);
        }
    }
}
