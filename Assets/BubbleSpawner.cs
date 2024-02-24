using System;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject powerPlantPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //SpawnPowerPlants();
    }

    void SpawnPowerPlants() {
        // For testing purposes, spawn a bubble at each intersection of prominent latitude/longitude lines
        float[] longitudes = {-150f, -120f, -90f, -60f, -30f, 0f, 30f, 60f, 90f, 120f, 150f, 180f};
        float[] latitudes = {-75f, -60f, -45f, -30f, -15f,  0f, 15f, 30f, 45f, 60f, 75f};

        foreach (float longitude in longitudes) {
            foreach (float latitude in latitudes) {
                Vector3 spawnPos = new Vector3(0f, 0f, 0f);
                GameObject newPowerPlant = Instantiate(powerPlantPrefab, spawnPos, Quaternion.identity);
                Coords spawnCoords;
                spawnCoords.latitude = latitude;
                spawnCoords.longitude = longitude;
                Array energyTypes = Enum.GetValues(typeof(EnergyType));
                System.Random random = new System.Random();
                EnergyType energyType = (EnergyType)energyTypes.GetValue(random.Next(0, energyTypes.Length));
                newPowerPlant.GetComponent<PowerPlantController>().init(spawnCoords, energyType, "US");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
