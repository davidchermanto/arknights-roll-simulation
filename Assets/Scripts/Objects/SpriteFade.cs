using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFade : MonoBehaviour
{
    [SerializeField] private float holdTime;
    [SerializeField] private float fadeTime;

    private float initialAlpha;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialAlpha = spriteRenderer.color.a;

        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        float timer = 0;

        yield return new WaitForSeconds(holdTime);

        while(timer < 1)
        {
            timer += Time.deltaTime / fadeTime;
            spriteRenderer.color = new Color(spriteRenderer.color.r, 
                spriteRenderer.color.g, spriteRenderer.color.b, Mathf.Lerp(initialAlpha, 0, timer));

            yield return new WaitForEndOfFrame();
        }
    }
}
