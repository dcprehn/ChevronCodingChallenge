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
        transform.localScale += new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime;
    }
}
