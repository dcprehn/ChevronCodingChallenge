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

    // Delegates
    public delegate void OnBubblePop();
    public OnBubblePop onBubblePop;

    // Start is called before the first frame update
    private void Start()
    {
        scaleMin = transform.localScale.x * 0.8f;
        scaleMax = transform.localScale.x * 1.2f;
        scaleSpeed  = (scaleMax - scaleMin) / 3f;

        hoverMin = transform.localPosition.y - 10f;
        hoverMax = transform.localPosition.y + 10f;
        hoverSpeed = (hoverMax - hoverMin) / 5f;
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

    public void Pop()
    {
        // Signal bubble pop event
        onBubblePop?.Invoke();
        // Delete the bubble
        Destroy(gameObject);
    }

    public void SwitchColor(BubbleColors color) {
        Sprite chosenSprite = null;
        switch (color) {
            case BubbleColors.Blue:
                chosenSprite = Resources.Load<Sprite>("Sprites/bubble_blue");
                break;
            case BubbleColors.Green:
                chosenSprite = Resources.Load<Sprite>("Sprites/bubble_green");
                break;
            case BubbleColors.Red:
                chosenSprite = Resources.Load<Sprite>("Sprites/bubble_red");
                break;
            case BubbleColors.Yellow:
                chosenSprite = Resources.Load<Sprite>("Sprites/bubble_yellow");
                break;
        }

        if (chosenSprite != null) {
            this.GetComponent<SpriteRenderer>().sprite = chosenSprite;
        } else {
            Debug.Log("Bubble sprite not found! Color was " + color.ToString());
        }
    }
}

// Bubble color enum
public enum BubbleColors {
    Red,
    Yellow,
    Green,
    Blue
};