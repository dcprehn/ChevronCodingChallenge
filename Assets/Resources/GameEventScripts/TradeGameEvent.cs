using UnityEngine;

public class TradeGameEvent : GameEvent
{
    private Coords coords1;
    private Coords coords2;
    private GameObject bubblePrefab;
    private GameObject tradeRoutePrefab;

    public TradeGameEvent(string date, float lat1, float lon1, float lat2, float lon2) : base(date) {
        this.coords1.latitude = lat1;
        this.coords1.longitude = lon1;
        this.coords2.latitude = lat2;
        this.coords2.longitude = lon2;

        this.bubblePrefab = Resources.Load<GameObject>("Prefabs/Bubble");
        this.tradeRoutePrefab = Resources.Load<GameObject>("Prefabs/TradeRoute");
    }
    public override void ExecuteEvent()
    {
        // Create Blue Bubbble
        Coords bubbleSpawnCoords;
        bubbleSpawnCoords.latitude = coords1.latitude + (coords2.latitude - coords1.latitude) / 2f;
        bubbleSpawnCoords.longitude = coords1.longitude + (coords2.longitude - coords1.longitude) / 2f;
        Vector2 bubblePosition = Util.convertToWorldCoords(bubbleSpawnCoords);
        GameObject bubble = GameObject.Instantiate(bubblePrefab, bubblePosition, Quaternion.identity);
        bubble.GetComponent<BubbleController>().SwitchColor(BubbleColors.Blue);
        bubble.GetComponent<BubbleController>().onBubblePop += ShowTradeRoute;
    }

    private void ShowTradeRoute()
    {
        // Create Line between coordinates
        GameObject tradeRoutes = GameObject.Find("TradeRoutes");
        if (tradeRoutes != null) {
            GameObject route = GameObject.Instantiate(tradeRoutePrefab, tradeRoutes.transform);
            LineRenderer line = route.GetComponent<LineRenderer>();
            line.SetPosition(0, Util.convertToWorldCoords(coords1));
            line.SetPosition(1, Util.convertToWorldCoords(coords2));
            line.startWidth = 3f;
            line.endWidth = 3f;
            line.startColor = Color.cyan;
            line.endColor = Color.cyan;
            line.material = new Material(Shader.Find("Unlit/Color"))
            {
                color = Color.cyan,
                renderQueue = 0
            };
            Debug.Log("New Trade Route!\nStart location: (" + coords1.latitude + ", " + coords1.longitude + ")\nEnd location: (" + coords2.latitude + ", " + coords2.longitude + ")");
        } else {
            Debug.LogError("TradeRoutes not found in the scene");
        }
    }
}