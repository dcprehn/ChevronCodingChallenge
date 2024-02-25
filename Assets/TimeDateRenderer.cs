using UnityEngine;
using TMPro;
using System;

public class TimeDateRenderer : MonoBehaviour
{
    public TMP_Text timeDateText;
    public TimeDateSO timeDateSO;
    public float timeDelta;
    // Start is called before the first frame update
    void Start()
    {
        timeDateSO.time = new DateTime(2024, 2, 20);
        timeDateSO.isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeDateSO.isPaused) {
            timeDateSO.time = timeDateSO.time.AddSeconds(timeDelta);
            timeDateText.text = timeDateSO.time.ToString();
        }
    }
}
