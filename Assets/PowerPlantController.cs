using UnityEngine;

public class PowerPlantController : MonoBehaviour
{
    public Coords coords;
    public EnergyType energyType;
    public string country;
    public GameObject bubblePrefab;
    private GameObject bubble;
    private GameObject map;

    private Vector2 convertToWorldCoords() {
        RectTransform mapRectTransform = map.GetComponent<RectTransform>();
        // Define latitude/longitude bounds
        const float MIN_LATITUDE = -71f;
        const float MAX_LATITUDE = 71f;
        const float MIN_LONGITUDE = -180f;
        const float MAX_LONGITUDE = 180f;
        // Calculate the scaled latitude
        float latitudeScale = Mathf.Log(Mathf.Tan(0.25f * Mathf.PI + 0.5f * Mathf.Deg2Rad * this.coords.latitude));
        float latitudeRange = (MAX_LATITUDE - MIN_LATITUDE) * Mathf.Deg2Rad;
        // Calculate x and y pixels for given latitude/longitude
        float xPixel = (this.coords.longitude + MAX_LONGITUDE) * (mapRectTransform.rect.width / (MAX_LONGITUDE - MIN_LONGITUDE));
        float yPixel = (mapRectTransform.rect.height / 2.0f) - (mapRectTransform.rect.height * latitudeScale / (2 * latitudeRange));
        // Calculate world coords based on the pixels
        Vector2 converted = new Vector2
        {
            x = mapRectTransform.position.x + (xPixel - mapRectTransform.rect.width / 2.0f),
            y = mapRectTransform.position.y - (yPixel - mapRectTransform.rect.height / 2.0f)
        };

        return converted;
    }

    public void chooseBubbleSprite() {
        switch (energyType) {
            case EnergyType.Coal:
            case EnergyType.Gas:
            case EnergyType.Oil:
                bubble.GetComponent<BubbleController>().switchColor(BubbleColors.Red);
                break;
            default:
                bubble.GetComponent<BubbleController>().switchColor(BubbleColors.Green);
                break;
        }
    }

    public void init(Coords coords, EnergyType energyType, string country) {
        // Set attributes
        this.map = GameObject.Find("Map");
        this.coords = coords;
        this.energyType = energyType;
        this.country = country;
        // Calculate position
        this.transform.localPosition = convertToWorldCoords();
        // Set up bubble
        bubble = Instantiate(bubblePrefab, this.transform.localPosition, Quaternion.identity);
        chooseBubbleSprite();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public enum EnergyType {
    Coal,
    Gas,
    Hydro,
    Nuclear,
    Oil,
    Solar,
    Geothermal,
    Wind
}

public struct Coords {
    public float latitude;
    public float longitude;
};