using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ImageFade : MonoBehaviour
{
    [SerializeField] private float holdTime;
    [SerializeField] private float fadeTime;

    [SerializeField] private float initialAlpha = 1;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(image.color.r,
            image.color.g, image.color.b, initialAlpha);

        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        float timer = 0;

        yield return new WaitForSeconds(holdTime);

        while (timer < 1)
        {
            timer += Time.deltaTime / fadeTime;
            image.color = new Color(image.color.r,
                image.color.g, image.color.b, Mathf.Lerp(initialAlpha, 0, timer));

            yield return new WaitForEndOfFrame();
        }
    }
}
