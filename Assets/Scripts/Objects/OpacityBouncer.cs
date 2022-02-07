using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

public class OpacityBouncer : MonoBehaviour
{
    [Range(0, 5)]
    [SerializeField] private float minIntensity;
    [Range(0, 5)]
    [SerializeField] private float maxIntensity;

    [SerializeField] private float interval;

    private Light2D light2d;
    [SerializeField] private float timer = 0;
    [SerializeField] private bool isIncreasing;

    private void Start()
    {
        light2d = GetComponent<Light2D>();
    }

    void Update()
    {
        timer += Time.deltaTime / interval;

        if (isIncreasing)
        {
            light2d.intensity = Mathf.Lerp(minIntensity, maxIntensity, timer);
        }
        else
        {
            light2d.intensity = Mathf.Lerp(maxIntensity, minIntensity, timer);
        }

        if (timer > 1)
        {
            if (isIncreasing)
            {
                isIncreasing = false;
            }
            else
            {
                isIncreasing = true;
            }

            timer -= 1;
        }
    }
}
