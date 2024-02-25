using UnityEngine;

public class PowerPlantController : MonoBehaviour
{
    public Coords coords;
    public EnergyType energyType;
    public string country;
    public GameObject bubblePrefab;
    public GameObject markerPrefab;
    private GameObject bubble;
    private GameObject marker;

    public void ChooseBubbleSprite() {
        switch (energyType) {
            case EnergyType.Coal:
            case EnergyType.Gas:
            case EnergyType.Oil:
                bubble.GetComponent<BubbleController>().SwitchColor(BubbleColors.Red);
                break;
            default:
                bubble.GetComponent<BubbleController>().SwitchColor(BubbleColors.Green);
                break;
        }
    }

    public void ChooseMarkerSprite() {
        switch (energyType) {
            case EnergyType.Coal:
            case EnergyType.Gas:
            case EnergyType.Oil:
                marker.GetComponent<MarkerController>().SwitchColor(BubbleColors.Red);
                break;
            default:
                marker.GetComponent<MarkerController>().SwitchColor(BubbleColors.Green);
                break;
        }
    }

    public void init(Coords coords, EnergyType energyType, string country) {
        // Set attributes
        this.coords = coords;
        this.energyType = energyType;
        this.country = country;
        // Calculate position
        this.transform.localPosition = Util.convertToWorldCoords(this.coords);
        // Set up bubble
        bubble = Instantiate(bubblePrefab, this.transform);
        bubble.GetComponent<BubbleController>().onBubblePop += SpawnMarker;
        ChooseBubbleSprite();
    }

    public void SpawnMarker() {
        // Create the marker
        marker = Instantiate(markerPrefab, this.transform);
        // Update marker color
        ChooseMarkerSprite();
        // Calculate the marker position, based on the original position of the bubble
        // Marker should be positioned so that the tip is positioned at location of the powerplant
        marker.transform.localPosition += new Vector3(0f, marker.GetComponent<SpriteRenderer>().sprite.bounds.size.y * marker.transform.localScale.y * (3f / 8f), 0f);
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