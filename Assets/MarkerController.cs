using SharpUI.Source.Common.UI.Elements.TooltipInfo;
using TMPro;
using UnityEngine;

public class MarkerController : MonoBehaviour
{
    public ITooltip hoverTooltip;
    public TMP_Text tooltipText;

    public void Awake() {
        hoverTooltip = this.GetComponentInChildren<ITooltip>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        hoverTooltip.BindContent(tooltipText.GetComponent<RectTransform>());
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

    internal void ShowTooltip()
    {
        var rectTransform = this.GetComponent<RectTransform>();
        hoverTooltip.ShowToLeftOf(rectTransform);
    }

    internal void HideTooltip()
    {
        hoverTooltip.Hide();
    }
}