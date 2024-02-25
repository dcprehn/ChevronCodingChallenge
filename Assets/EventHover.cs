using UnityEngine;
using UnityEngine.EventSystems;

public class EventHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Detect when pointer enters the GameObject's bounds
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        // Check if the GameObject has the "Bubble" tag
        if (gameObject.CompareTag("Marker"))
        {
            // GetComponent<MarkerController>().ShowTooltip();
        }
    }

    //Detect when pointer exits the GameObject's bounds
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (gameObject.CompareTag("Marker")) {
            // GetComponent<MarkerController>().HideTooltip();
        }
    }
}