using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;


public class ObjectShrink : MonoBehaviour
{
    [SerializeField] private float holdTime;
    [SerializeField] private float shrinkTime;

    private Vector3 initialSize;

    // Start is called before the first frame update
    void Start()
    {
        initialSize = transform.localScale;

        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        float timer = 0;

        yield return new WaitForSeconds(holdTime);

        while (timer < 1)
        {
            timer += Time.deltaTime / shrinkTime;

            transform.localScale = Vector3.Lerp(initialSize, new Vector3(), timer);

            yield return new WaitForEndOfFrame();
        }
    }
}
