using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerClickHandler
{
    //Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        // Check if the clicked game object is a bubble
        if (gameObject.CompareTag("Bubble")) {
            BubbleController bubbleController = GetComponent<BubbleController>();
            bubbleController.pop();
        }
    }
}