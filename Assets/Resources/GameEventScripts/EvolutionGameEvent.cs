using System;
using SharpUI.Source.Common.UI.Elements.Dialogs;
using UnityEngine;

public class EvolutionGameEvent : GameEvent
{
    private string description;
    private GameObject dialogPrefab;
    private TimeDateSO timeDateSO;
    private Coords coords;
    private GameObject bubblePrefab;

    public EvolutionGameEvent(string date, float lat, float lon, string description) : base(date) {
        this.description = description;
        this.coords.latitude = lat;
        this.coords.longitude = lon;

        this.dialogPrefab = Resources.Load<GameObject>("Prefabs/EvolutionDialog");
        this.timeDateSO = Resources.Load<TimeDateSO>("ScriptableObjects/TimeDate");
        this.bubblePrefab = Resources.Load<GameObject>("Prefabs/Bubble");
    }
    public override void ExecuteEvent()
    {
        // Create Yellow Bubbble
        Vector2 bubblePosition = Util.convertToWorldCoords(this.coords);
        GameObject bubble = GameObject.Instantiate(bubblePrefab, bubblePosition, Quaternion.identity);
        bubble.GetComponent<BubbleController>().SwitchColor(BubbleColors.Yellow);
        bubble.GetComponent<BubbleController>().onBubblePop += ShowEvolutionDialog;
    }

    private void ShowEvolutionDialog()
    {
        // Create Evolution Dialog
        GameObject canvasUI = GameObject.Find("UI Canvas");
        if (canvasUI != null) {
            GameObject dialog = GameObject.Instantiate(dialogPrefab, canvasUI.transform);
            dialog.transform.localPosition = Vector3.zero;
            dialog.GetComponent<Dialog>().SetDescription(description);
            dialog.GetComponent<Dialog>().SetNegativeButtonVisible(false);
            dialog.GetComponent<Dialog>().SetPositiveButtonVisible(false);
            dialog.GetComponent<Dialog>().SetCloseButtonVisible(false);
            dialog.GetComponent<Dialog>().Show();
            timeDateSO.Pause();
            Debug.Log("New Game Evolution!\nDate: " + this.timestamp.ToString());
        } else {
            Debug.LogError("UI Canvas not found in the scene");
        }
    }
}