using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    private Image flash;

    [SerializeField] private int flashCount;
    [SerializeField] private float opacityMin;
    [SerializeField] private float opacityMax;
    [SerializeField] private float flashInterval;
    [SerializeField] private float flashInitialDelay;

    [SerializeField] private float scaleX;
    [SerializeField] private float scaleY;

    [SerializeField] private bool repeat;
    [SerializeField] private int repeatCount;
    [SerializeField] private float repeatDelayMin;
    [SerializeField] private float repeatDelayMax;

    private void Start()
    {
        flash = GetComponent<Image>();

        StartCoroutine(StartFlash());
    }

    private IEnumerator StartFlash()
    {
        yield return new WaitForSeconds(flashInitialDelay);

        float repeatCurrent = 0;

        while (repeatCurrent < repeatCount)
        {
            for (int i = 0; i < flashCount; i++)
            {
                if (i % 4 == 0 || i % 4 == 1)
                {
                    flash.color = new Color(flash.color.r, flash.color.g, flash.color.b, 0);
                }
                else
                {
                    flash.color = new Color(flash.color.r, flash.color.g, flash.color.b, Random.Range(opacityMin, opacityMax));
                }

                if (i == flashCount)
                {
                    flash.transform.rotation = Quaternion.Euler(0, 0, 0);
                    flash.transform.localScale = new Vector3(1, 2);
                }
                else
                {
                    int randomDirection;

                    if (i % 2 == 0)
                    {
                        randomDirection = Random.Range(0, 2);
                    }
                    else
                    {
                        randomDirection = Random.Range(0, 4);
                    }

                    switch (randomDirection)
                    {
                        case 0:
                            flash.transform.rotation = Quaternion.Euler(0, 0, 0);
                            flash.transform.localScale = new Vector3(scaleX, scaleY);
                            break;
                        case 1:
                            flash.transform.localScale = new Vector3(scaleX, scaleY);
                            flash.transform.rotation = Quaternion.Euler(0, 0, 180);
                            break;
                        case 2:
                            flash.transform.rotation = Quaternion.Euler(0, 0, 90);
                            flash.transform.localScale = new Vector3(scaleY, scaleX);
                            break;
                        case 3:
                            flash.transform.localScale = new Vector3(scaleY, scaleX);
                            flash.transform.rotation = Quaternion.Euler(0, 0, 270);
                            break;
                        default:
                            break;
                    }
                }

                yield return new WaitForSeconds(flashInterval);

                flash.color = new Color(flash.color.r, flash.color.g, flash.color.b, 0);
            }

            if (repeatCurrent >= repeatCount)
            {
                break;
            }

            repeatCurrent++;

            yield return new WaitForSeconds(Random.Range(repeatDelayMin, repeatDelayMax));
        }

        Destroy(flash.gameObject);
    }

}
