using UnityEngine;

public class EnergyGameEvent : GameEvent
{
    private EnergyType energyType;
    private Coords coords;
    private string country;

    private GameObject powerplantPrefab;

    public EnergyGameEvent(string date, EnergyType energy, float lat, float lon, string country) : base(date) {
        this.energyType = energy;
        this.coords.latitude = lat;
        this.coords.longitude = lon;
        this.country = country;

        this.powerplantPrefab = Resources.Load<GameObject>("Prefabs/PowerPlant");
    }
    public override void ExecuteEvent()
    {
        // Create powerplant
        GameObject powerplant = GameObject.Instantiate(powerplantPrefab);
        powerplant.GetComponent<PowerPlantController>().init(coords, energyType, country);
    }
}