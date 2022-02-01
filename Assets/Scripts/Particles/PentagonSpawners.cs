using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentagonSpawners : MonoBehaviour
{
    [SerializeField] private GameObject folder;

    [SerializeField] private GameObject prefab;

    [SerializeField] private int countMin;
    [SerializeField] private int countMax;

    [SerializeField] private int maxXLeft;
    [SerializeField] private int maxXRight;

    [SerializeField] private int maxYDown;
    [SerializeField] private int maxYUp;

    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;

    [SerializeField] private float initialWait;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(initialWait);

        for (int i = 0; i < Random.Range(countMin, countMax); i++)
        {
            GameObject newPentagon = Instantiate(prefab);

            newPentagon.transform.SetParent(folder.transform);
            newPentagon.transform.position = new Vector3(Random.Range(maxXLeft, maxXRight), Random.Range(maxYDown, maxYUp));
            newPentagon.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0, 360f));

            float size = Random.Range(minSize, maxSize);
            newPentagon.transform.localScale = new Vector3(newPentagon.transform.localScale.x * size, newPentagon.transform.localScale.y * size, 1);
        }
    }
}
