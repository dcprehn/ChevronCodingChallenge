using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    private float scaleMin = 0.2f;
    private float scaleMax = 0.3f;
    private float scaleSpeed = 0.05f;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    
    // Update is called every frame
    private void Update() {
        // Bubble should oscillate between min and max scale
        if (transform.localScale.x < scaleMin || transform.localScale.x > scaleMax) {
            scaleSpeed *= -1;
        }
        transform.localScale += new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime;
    }
}
