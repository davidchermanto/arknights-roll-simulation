using System.Collections;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

public class BackgroundTriangle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Light2D activeLight;
    [SerializeField] private Light2D activeLight2;

    [SerializeField] private float inDuration;
    [SerializeField] private float holdDuration;
    [SerializeField] private float outDuration;

    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;

    private float spriteOpacityMax;
    private float lightIntensityMax;

    private float timer;

    private void Start()
    {
        float size = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(size, size);

        lightIntensityMax = activeLight.intensity;
        spriteOpacityMax = sprite.color.a;

        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
        activeLight.intensity = 0;
        activeLight2.intensity = 0;

        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        timer = 0;

        while(timer < 1)
        {
            timer += Time.deltaTime / inDuration;

            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, timer * spriteOpacityMax);
            activeLight.intensity = timer * lightIntensityMax;
            activeLight2.intensity = timer * lightIntensityMax;

            yield return new WaitForEndOfFrame();
        }

        timer = 0;

        while (timer < 1)
        {
            timer += Time.deltaTime / holdDuration;

            yield return new WaitForEndOfFrame();
        }

        timer = 0;

        while (timer < 1)
        {
            timer += Time.deltaTime / outDuration;

            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, (1 - timer) * spriteOpacityMax);
            activeLight.intensity = (1 - timer) * lightIntensityMax;
            activeLight2.intensity = (1 - timer) * lightIntensityMax;

            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }
}
