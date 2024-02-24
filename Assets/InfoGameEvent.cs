using SharpUI.Source.Common.UI.Elements.Dialogs;
using UnityEngine;

public class InfoGameEvent : GameEvent
{
    private string description;
    private GameObject dialogPrefab;
    private TimeDateSO timeDateSO;

    public InfoGameEvent(string date, string description) : base(date) {
        this.description = description;

        this.dialogPrefab = Resources.Load<GameObject>("Prefabs/DialogDefault");
        this.timeDateSO = Resources.Load<TimeDateSO>("ScriptableObjects/TimeDate");
    }
    public override void ExecuteEvent()
    {
        // Create Info Dialog
        GameObject canvasUI = GameObject.Find("UI Canvas");
        if (canvasUI != null) {
            GameObject dialog = GameObject.Instantiate(dialogPrefab, canvasUI.transform);
            dialog.transform.localPosition = new Vector3(0f, 0f, -1f);
            dialog.GetComponent<Dialog>().SetDescription(description);
            dialog.GetComponent<Dialog>().SetNegativeButtonVisible(false);
            dialog.GetComponent<Dialog>().SetPositiveButtonVisible(false);
            dialog.GetComponent<Dialog>().SetCloseButtonVisible(false);
            dialog.GetComponent<Dialog>().Show();
            timeDateSO.Pause();

        } else {
            Debug.LogError("UI Canvas not found in  the scene");
        }
    }
}