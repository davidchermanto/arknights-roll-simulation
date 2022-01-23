using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLightSpawner : MonoBehaviour
{
    [SerializeField] private GameObject folder;

    [SerializeField] private GameObject prefab;

    [SerializeField] private float countPerSecond;
    [SerializeField] private float offsetPercentage;

    private float intervalPerSpawn;

    private float timer = 0;

    [Header("Position")]
    [SerializeField] private float limitLeftX;
    [SerializeField] private float limitRightX;

    [SerializeField] private float limitBottomY;
    [SerializeField] private float limitUpY;

    private void Start()
    {
        intervalPerSpawn = (1 / countPerSecond) * (1 + Random.Range(-offsetPercentage, offsetPercentage));
    }

    private void Update()
    {
        timer += Time.deltaTime / intervalPerSpawn;

        if(timer >= 1)
        {
            timer -= 1;

            GameObject newObject = Instantiate(prefab);
            newObject.transform.position = new Vector3(Random.Range(limitLeftX, limitRightX), Random.Range(limitBottomY, limitUpY));
            newObject.transform.SetParent(folder.transform);

            intervalPerSpawn = (1 / countPerSecond) * (1 + Random.Range(-offsetPercentage, offsetPercentage));
        }
    }
}
