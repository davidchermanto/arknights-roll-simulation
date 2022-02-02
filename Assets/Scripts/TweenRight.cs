using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenRight : MonoBehaviour
{
    [SerializeField] private bool UI;

    [SerializeField] private float distance;
    [SerializeField] private float duration;

    void Start()
    {
        StartCoroutine(MoveRight());
    }

    private IEnumerator MoveRight()
    {
        float timer = 0;

        float width = Screen.currentResolution.width;
        float height = Screen.currentResolution.height;

        Vector3 initialPos = transform.position;
        Vector3 targetPos;

        if (UI)
        {
            targetPos = new Vector3(initialPos.x + (distance * height / 100), initialPos.y);
        }
        else
        {
            targetPos = new Vector3(initialPos.x + distance, initialPos.y);
        }

        while(timer < 1)
        {
            timer += Time.deltaTime / duration;

            transform.position = Vector3.Lerp(initialPos, targetPos, timer);

            yield return new WaitForEndOfFrame();
        }
    }
}
