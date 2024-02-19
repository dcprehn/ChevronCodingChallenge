using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;
    public GameObject map;
    public struct WorldCoords {
        public float x;
        public float y;
    };
    // Start is called before the first frame update
    void Start()
    {
        SpawnBubble();
    }

    void SpawnBubble() {
        // For testing purposes, spawn a bubble at each intersection of prominent latitude/longitude lines
        float[] longitudes = {-150f, -120f, -90f, -60f, -30f, 0f, 30f, 60f, 90f, 120f, 150f, 180f};
        float[] latitudes = {-75f, -60f, -45f, -30f, -15f,  0f, 15f, 30f, 45f, 60f, 75f};

        foreach (float longitude in longitudes) {
            foreach (float latitude in latitudes) {
                WorldCoords coord = convertToWorldCoords(latitude, longitude);
                Vector3 spawnPos = new Vector3(coord.x, coord.y, -1f);
                GameObject newBubble = Instantiate(bubblePrefab, spawnPos, Quaternion.identity);
            }
        }
    }

    private WorldCoords convertToWorldCoords(float latitude, float longitude) {
        RectTransform mapRectTransform = map.GetComponent<RectTransform>();
        // Define latitude/longitude bounds
        const float MIN_LATITUDE = -71f;
        const float MAX_LATITUDE = 71f;
        const float MIN_LONGITUDE = -180f;
        const float MAX_LONGITUDE = 180f;
        // Calculate the scaled latitude
        float latitudeScale = Mathf.Log(Mathf.Tan(0.25f * Mathf.PI + 0.5f * Mathf.Deg2Rad * latitude));
        float latitudeRange = (MAX_LATITUDE - MIN_LATITUDE) * Mathf.Deg2Rad;
        // Calculate x and y pixels for given latitude/longitude
        float xPixel = (longitude + MAX_LONGITUDE) * (mapRectTransform.rect.width / (MAX_LONGITUDE - MIN_LONGITUDE));
        float yPixel = (mapRectTransform.rect.height / 2.0f) - (mapRectTransform.rect.height * latitudeScale / (2 * latitudeRange));
        // Calculate world coords based on the pixels
        WorldCoords converted = new WorldCoords
        {
            x = mapRectTransform.position.x + (xPixel - mapRectTransform.rect.width / 2.0f),
            y = mapRectTransform.position.y - (yPixel - mapRectTransform.rect.height / 2.0f)
        };

        return converted;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
