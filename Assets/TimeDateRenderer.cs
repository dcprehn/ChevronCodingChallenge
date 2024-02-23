using UnityEngine;
using TMPro;
using System;

public class TimeDateRenderer : MonoBehaviour
{
    public TMP_Text timeDateText;
    public TimeDateSO timeDateSO;
    // Start is called before the first frame update
    void Start()
    {
        timeDateSO.time = new DateTime(2024, 2, 26);
    }

    // Update is called once per frame
    void Update()
    {
        timeDateSO.time = timeDateSO.time.AddMinutes(1f);
        timeDateText.text = timeDateSO.time.ToString();
    }
}
