using System;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    private DateTime startDate;
    private DateTime endDate;
    public Color endColor;
    public Color startColor;
    public TimeDateSO timeDateSO;

    // Start is called before the first frame update
    void Start()
    {
        startDate = new DateTime(2024, 2, 25);
        endDate = new DateTime(2027, 2, 25);
    }

    // Update is called once per frame
    void Update()
    {
        float percentComplete = (float)((timeDateSO.time - startDate).TotalSeconds) / (float)((endDate - startDate).TotalSeconds);
        Color currentColor = new(
            startColor.r + (endColor.r - startColor.r) * percentComplete,
            startColor.g + (endColor.g - startColor.g) * percentComplete,
            startColor.b + (endColor.b - startColor.b) * percentComplete
        );
        GetComponent<Image>().color = currentColor;
    }
}
