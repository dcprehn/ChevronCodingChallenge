using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;
    public GameObject map;
    public int numBubblesToSpawn = 25;
    public float spawnInterval = 1f;
    // Start is called before the first frame update
    void Start()
    {
        // Start spawning bubbles
        InvokeRepeating("SpawnBubble", 2f, spawnInterval);
    }

    void SpawnBubble() {
        RectTransform mapRectTransform = map.GetComponent<RectTransform>();
        float minX = mapRectTransform.position.x - mapRectTransform.rect.width / 2;
        float maxX = minX + mapRectTransform.rect.width;
        float minY = mapRectTransform.position.y - mapRectTransform.rect.height / 2;
        float maxY = minY + mapRectTransform.rect.height;
        Vector3 spawnPos = new Vector3(Random.Range(minX / 10, maxX / 10), Random.Range(minY / 10, maxY / 10), 0f);
        GameObject newBubble = Instantiate(bubblePrefab, spawnPos, Quaternion.identity);

        numBubblesToSpawn--;
        if (numBubblesToSpawn <= 0) {
            CancelInvoke("SpawnBubble");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
