using UnityEngine;

public class Util {
    public static Vector2 convertToWorldCoords(Coords coords) {
        RectTransform mapRectTransform = GameObject.Find("Map").GetComponent<RectTransform>();
        // Define latitude/longitude bounds
        const float MIN_LATITUDE = -71f;
        const float MAX_LATITUDE = 71f;
        const float MIN_LONGITUDE = -180f;
        const float MAX_LONGITUDE = 180f;
        // Calculate the scaled latitude
        float latitudeScale = Mathf.Log(Mathf.Tan(0.25f * Mathf.PI + 0.5f * Mathf.Deg2Rad * coords.latitude));
        float latitudeRange = (MAX_LATITUDE - MIN_LATITUDE) * Mathf.Deg2Rad;
        // Calculate x and y pixels for given latitude/longitude
        float xPixel = (coords.longitude + MAX_LONGITUDE) * (mapRectTransform.rect.width / (MAX_LONGITUDE - MIN_LONGITUDE));
        float yPixel = (mapRectTransform.rect.height / 2.0f) - (mapRectTransform.rect.height * latitudeScale / (2 * latitudeRange));
        // Calculate world coords based on the pixels
        Vector2 converted = new()
        {
            x = mapRectTransform.position.x + (xPixel - mapRectTransform.rect.width / 2.0f),
            y = mapRectTransform.position.y - (yPixel - mapRectTransform.rect.height / 2.0f)
        };

        return converted;
    }
}