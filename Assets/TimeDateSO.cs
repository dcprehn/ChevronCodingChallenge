using UnityEngine;
using System;

[CreateAssetMenu(fileName = "TimeDateSO", menuName = "ScriptableObjects/TimeDate")]
public class TimeDateSO : ScriptableObject
{
    public DateTime time;
    public bool isPaused;

    public void Pause() {
        isPaused = true;
    }

    public void Resume() {
        isPaused = false;
    }
}
