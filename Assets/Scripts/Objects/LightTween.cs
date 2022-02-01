using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

public class LightTween : MonoBehaviour
{
    [SerializeField] private Light2D globalLight;

    [SerializeField] private float fadeDuration;

    [SerializeField] private float initialIntensity;
    [SerializeField] private float targetIntensity;

    private void Start()
    {
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        float timer = 0;
        float currentIntensity = initialIntensity;

        while(timer < 1)
        {
            timer += Time.deltaTime / fadeDuration;

            globalLight.intensity = Mathf.Lerp(currentIntensity, targetIntensity, timer);

            yield return new WaitForEndOfFrame();
        }
    }
}
