using UnityEngine;

public class BubbleController : MonoBehaviour
{
    //  Scale Oscillation variables
    private float scaleMin;
    private float scaleMax;
    private float scaleSpeed;

    // Hover Oscillation variables
    private float hoverMin;
    private float hoverMax;
    private float hoverSpeed;

    // original position variable
    private Vector2 originalPosition;

    //  Marker prefab
    public GameObject markerPrefab;

    // Sprites
    private Sprite redBubbleSprite;
    private Sprite greenBubbleSprite;
    private Sprite yellowBubbleSprite;
    private Sprite blueBubbleSprite;

    // Bubble color enum
    public enum BubbleColors {
        Red,
        Yellow,
        Green,
        Blue
    };

    private void Awake() {
        redBubbleSprite = Resources.Load<Sprite>("Sprites/bubble_red");
        greenBubbleSprite = Resources.Load<Sprite>("Sprites/bubble_green");
        yellowBubbleSprite = Resources.Load<Sprite>("Sprites/bubble_yellow");
        blueBubbleSprite = Resources.Load<Sprite>("Sprites/bubble_blue");
    }

    // Start is called before the first frame update
    private void Start()
    {
        scaleMin = transform.localScale.x * 0.8f;
        scaleMax = transform.localScale.x * 1.2f;
        scaleSpeed  = (scaleMax - scaleMin) / 3f;

        hoverMin = transform.localPosition.y - 10f;
        hoverMax = transform.localPosition.y + 10f;
        hoverSpeed = (hoverMax - hoverMin) / 5f;

        originalPosition = transform.localPosition;
    }

    
    // Update is called every frame
    private void Update() {
        // Bubble should oscillate between min and max hover position
        transform.localPosition += new Vector3(0f, hoverSpeed, 0f) * Mathf.Sin(2f * Time.fixedTime) * Time.deltaTime;

        // Bubble should oscillate between min and max scale
        if (transform.localScale.x < scaleMin || transform.localScale.x > scaleMax) {
            scaleSpeed *= -1;
        }
        transform.localScale += new Vector3(scaleSpeed, scaleSpeed, 0f) * Time.deltaTime;
    }

    public void pop()
    {
        // Calculate the marker position, based on the original position of the bubble
        // Marker should be positioned so that the tip is positioned at the bubble's center
        SpriteRenderer markerSprite = markerPrefab.GetComponent<SpriteRenderer>();
        float markerHeight = markerSprite.sprite.bounds.size.y;
        Vector2 markerPosition = new(originalPosition.x, originalPosition.y + (markerHeight * markerPrefab.transform.localScale.y / 2f));
        // Create the marker
        Instantiate(markerPrefab, markerPosition, markerPrefab.transform.rotation);
        // Delete the bubble
        Destroy(gameObject);
    }

    public void switchColor(BubbleColors color) {
        Sprite chosenSprite = null;
        switch (color) {
            case BubbleColors.Blue:
                chosenSprite = (Sprite)blueBubbleSprite;
                break;
            case BubbleColors.Green:
                chosenSprite = (Sprite)greenBubbleSprite;
                break;
            case BubbleColors.Red:
                chosenSprite = (Sprite)redBubbleSprite;
                break;
            case BubbleColors.Yellow:
                chosenSprite = (Sprite)yellowBubbleSprite;
                break;
        }

        if (chosenSprite != null) {
            this.GetComponent<SpriteRenderer>().sprite = chosenSprite;
        } else {
            Debug.Log("Sprite not found! Color was " + color.ToString());
        }
    }
}
