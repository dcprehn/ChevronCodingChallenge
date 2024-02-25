using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int renewableEnergyRating;
    private int numRedPowerplants;
    private int numGreenPowerPlants;
    private int greenPoints;
    private int maxGreenPoints;

    public GameObject renewableEnergyBar;
    public GameObject renewableEnergyText;
    public GameObject greenPointsBar;
    public GameObject greenPointsText;

    // Start is called before the first frame update
    void Start()
    {
        renewableEnergyRating = 20;
        greenPoints = 0;
        maxGreenPoints = 1000;
        numRedPowerplants = 0;
        numGreenPowerPlants = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Update renewable energy rating
        renewableEnergyRating = 20 - numRedPowerplants + numGreenPowerPlants;
        // Update Renewable energy bar
        renewableEnergyBar.GetComponent<Image>().fillAmount = renewableEnergyRating / 100f;
        renewableEnergyText.GetComponent<TextMeshProUGUI>().text = renewableEnergyRating + "%";
        // Update Green Points bar
        greenPointsBar.GetComponent<Image>().fillAmount = (float)greenPoints / maxGreenPoints;
        greenPointsText.GetComponent<TextMeshProUGUI>().text = greenPoints + " / " + maxGreenPoints;
    }

    public void AddRedPlant() {
        numRedPowerplants++;
    }

    public void AddGreenPlant() {
        numGreenPowerPlants++;
    }

    public void AddGreenPoints(int amt) {
        greenPoints += amt;
    }

    public void SubGreenPoints(int amt) {
        greenPoints -= amt;
    }
}
