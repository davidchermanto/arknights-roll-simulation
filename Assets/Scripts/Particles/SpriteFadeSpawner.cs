using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFadeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    [SerializeField] private int countHorizontal;
    [SerializeField] private int countVertical;

    [SerializeField] private float horizontalMinimumY;
    [SerializeField] private float horizontalMaximumY;

    [SerializeField] private float verticalMinimumX;
    [SerializeField] private float verticalMaximumX;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < countHorizontal; i++)
        {
            GameObject newObject = Instantiate(prefab);

            newObject.transform.SetParent(transform);
            newObject.transform.position = new Vector3(0, Random.Range(horizontalMinimumY, horizontalMaximumY));
        }

        for(int i = 0; i < countVertical; i++)
        {
            GameObject newObject = Instantiate(prefab);

            newObject.transform.SetParent(transform);
            newObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            newObject.transform.position = new Vector3(Random.Range(verticalMinimumX, verticalMaximumX), 0);
        }
    }
}
