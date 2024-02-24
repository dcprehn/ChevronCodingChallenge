using UnityEngine;

public class EventManager : MonoBehaviour
{
    private MinHeap<GameEvent> events;
    public TimeDateSO timeDateSO;
    // Start is called before the first frame update
    void Start()
    {
        events = new();
        events.Add(new EnergyGameEvent("2024-02-29 00:00:00", EnergyType.Coal, 31.23042f, 121.4737f, "China"));
        events.Add(new EnergyGameEvent("2024-03-02 00:00:00", EnergyType.Gas, 52.52001f, 13.40495f, "Germany"));
        events.Add(new InfoGameEvent("2024-02-27 00:00:00", "This is a test message. Hello Devin!"));
    }

    // Update is called once per frame
    void Update()
    {
        if (events.Count > 0) {
            GameEvent nextEvent = events.Peek();
            if (nextEvent.GetTimestamp() < timeDateSO.time) {
                events.ExtractMin();
                nextEvent.ExecuteEvent();
            }
        }
    }
}
