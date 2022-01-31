using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenRight : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float duration;

    void Start()
    {
        StartCoroutine(MoveRight());
    }

    private IEnumerator MoveRight()
    {
        float timer = 0;

        Vector3 initialPos = transform.position;
        Vector3 targetPos = new Vector3(initialPos.x + distance, initialPos.y);

        while(timer < 1)
        {
            timer += Time.deltaTime / duration;

            transform.position = Vector3.Lerp(initialPos, targetPos, timer);

            yield return new WaitForEndOfFrame();
        }
    }
}
