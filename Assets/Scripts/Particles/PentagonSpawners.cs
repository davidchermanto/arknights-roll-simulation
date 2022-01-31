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

    [SerializeField] private int minSize;
    [SerializeField] private int maxSize;

    private void Start()
    {
        for(int i = 0; i < Random.Range(countMin, countMax); i++)
        {
            GameObject newPentagon = Instantiate(prefab);

            newPentagon.transform.SetParent(folder.transform);
            newPentagon.transform.position = new Vector3(Random.Range(maxXLeft, maxXRight), Random.Range(maxYDown, maxYUp));
            newPentagon.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0, 360f));

            int size = Random.Range(minSize, maxSize);
            newPentagon.transform.localScale = new Vector3(size, size, 1);
        }
    }
}
