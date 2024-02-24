using UnityEngine;

public class MarkerController : MonoBehaviour
{

    // Start is called before the first frame update
    private void Start()
    {

    }

    
    // Update is called every frame
    private void Update() {

    }

    public void SwitchColor(BubbleColors color) {
        Sprite chosenSprite = null;
        switch (color) {
            case BubbleColors.Blue:
                chosenSprite = Resources.Load<Sprite>("Sprites/marker_blue");
                break;
            case BubbleColors.Green:
                chosenSprite = Resources.Load<Sprite>("Sprites/marker_green");
                break;
            case BubbleColors.Red:
                chosenSprite = Resources.Load<Sprite>("Sprites/marker_red");
                break;
            case BubbleColors.Yellow:
                chosenSprite = Resources.Load<Sprite>("Sprites/marker_yellow");
                break;
        }

        if (chosenSprite != null) {
            this.GetComponent<SpriteRenderer>().sprite = chosenSprite;
        } else {
            Debug.Log("Marker sprite not found! Color was " + color.ToString());
        }
    }
}