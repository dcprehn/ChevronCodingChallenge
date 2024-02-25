using UnityEngine;

public class EventManager : MonoBehaviour
{
    private MinHeap<GameEvent> events;
    public TimeDateSO timeDateSO;
    // Start is called before the first frame update
    void Start()
    {
        events = new();

        //Welcome message
        events.Add(new InfoGameEvent("2024-02-25 00:00:00", "Welcome to New Day! Keep an eye out for pop-up suggestions for a better experience."));
        
        //Three red bubbles appear
        events.Add(new EnergyGameEvent("2024-03-06 00:00:00", EnergyType.Coal, 32.1944f, 119.6998f, "China"));
        events.Add(new EnergyGameEvent("2024-03-08 00:00:00", EnergyType.Gas, 25.9400f, 49.6880f, "Saudi Arabia"));
        events.Add(new EnergyGameEvent("2024-03-11 00:00:00", EnergyType.Oil, 48.7872f, 2.4033f, "France"));
        events.Add(new InfoGameEvent("2024-03-12 00:00:00", "Red bubbles are indicators that a non-renewable energy plant has been created. Too many red bubbles will lose you the game! Red bubbles can be a result of neglecting a country’s energy needs, economic struggles, or political power moves"));
        events.Add(new TradeGameEvent("2024-03-13 00:00:00", 32.1944f, 119.6998f, 25.9400f, 49.6880f));
        //Wind power is purchased
        //***ADD PURCHASING EVENT***//
        // events.Add(new InfoGameEvent("2024-02-27 00:00:00", "Wind power is the cheapest renewable energy per kWh. China is the world leader in wind power generating 655,600 GWh. Did you know that offshore wind power has the potential of generating 18 time the current global energy demand!"));
        
        //Green bubble appears at mines
        events.Add(new EnergyGameEvent("2024-06-10 00:00:00", EnergyType.Wind, 39.7606f, -105.2150f, "Colorado School of Mines"));
        events.Add(new InfoGameEvent("2024-06-11 00:00:00", "Green bubbles are indicators that a renewable energy plant has been created. Pop-each green bubble to earn ‘Green Points’ that can be used in the technology tree."));
        
        //5 Green bubble appears across US
        events.Add(new EnergyGameEvent("2024-06-15 00:00:00", EnergyType.Wind, 35.1011f, -118.3372f, "United States of America"));
        events.Add(new EnergyGameEvent("2024-06-20 00:00:00", EnergyType.Wind, 35.1011f, -118.3372f, "United States of America"));
        events.Add(new EnergyGameEvent("2024-06-30 00:00:00", EnergyType.Wind, 41.4236f, -94.6650f, "United States of America"));
        events.Add(new EnergyGameEvent("2024-07-05 00:00:00", EnergyType.Wind, 40.9200f, -94.6717f, "United States of America"));
        events.Add(new EnergyGameEvent("2024-07-15 00:00:00", EnergyType.Wind, 43.5548f, -92.7241f, "United States of America"));
        events.Add(new InfoGameEvent("2024-07-16 00:00:00", "It looks like renewable energy is spreading! Each region has different energy needs that utilize some technologies better than others. Keep upgrading the ‘Renewable Fuels’ branch in the technology tree to find out what technologies are used in each region and why."));
        //Solar power is purchased
        //***ADD PURCHASING EVENT***//
        // events.Add(new InfoGameEvent("2024-02-27 00:00:00", "Solar power is the most abundant and popular renewable energy source globally, accounting for 3.6% of the global energy needs today. Solar power is best used in sunny climates in tandem with horticulture and agriculture."));

        //2 green bubble appear in new places
        events.Add(new EnergyGameEvent("2024-10-14 00:00:00", EnergyType.Solar, 54.9638f, -6.4930f, "United Kingdom"));
        events.Add(new EnergyGameEvent("2024-10-19 00:00:00", EnergyType.Solar, 28.1839f, 73.2407f, "India"));
        //Red marker in CHN turns into green bubble
        events.Add(new EnergyGameEvent("2024-10-29 00:00:00", EnergyType.Solar, 32.1944f, 119.6998f, "China"));
        events.Add(new InfoGameEvent("2024-10-30 00:00:00", "Looks like one of the red bubbles turned green! This can happen by targeting red dots in specific regions with technologies that are more efficient in those regions."));

        //More green bubbles appear in each place with existing green markers
        //5 USA green bubbles appear
        events.Add(new EnergyGameEvent("2025-01-02 00:00:00", EnergyType.Wind, 44.9169f, -94.7356f, "United States of America"));
        events.Add(new EnergyGameEvent("2025-01-08 00:00:00", EnergyType.Wind, 36.4725f, -101.3278f, "United States of America"));
        events.Add(new EnergyGameEvent("2025-01-12 00:00:00", EnergyType.Wind, 47.0053f, -96.4356f, "United States of America"));
        events.Add(new EnergyGameEvent("2025-01-14 00:00:00", EnergyType.Solar, 41.0930f, -73.9828f, "United States of America"));
        events.Add(new EnergyGameEvent("2025-01-28 00:00:00", EnergyType.Solar, 35.4273f, -79.1263f, "United States of America"));
        //4 GBR green bubbles appear
        events.Add(new EnergyGameEvent("2025-01-03 00:00:00", EnergyType.Solar, 53.2062f, -1.1968f, "United Kingdom"));
        events.Add(new EnergyGameEvent("2025-01-07 00:00:00", EnergyType.Solar, 51.8992f, -4.8665f, "United Kingdom"));
        events.Add(new EnergyGameEvent("2025-01-15 00:00:00", EnergyType.Solar, 52.4193f, -0.2366f, "United Kingdom"));
        events.Add(new EnergyGameEvent("2025-01-22 00:00:00", EnergyType.Solar, 51.3187f, 0.9029f, "United Kingdom"));
        //4 IND green bubbles appear
        events.Add(new EnergyGameEvent("2025-01-08 00:00:00", EnergyType.Solar, 26.8278f, 70.9197f, "India"));
        events.Add(new EnergyGameEvent("2025-01-12 00:00:00", EnergyType.Solar, 16.3893f, 78.6621f, "India"));
        events.Add(new EnergyGameEvent("2025-01-17 00:00:00", EnergyType.Solar, 10.4560f, 77.9240f, "India"));
        events.Add(new EnergyGameEvent("2025-01-29 00:00:00", EnergyType.Solar, 25.8420f, 74.7580f, "India"));
        //Hydro power is purchased
        //***ADD PURCHASING EVENT***//
        // events.Add(new InfoGameEvent("2024-02-27 00:00:00", "Hydro Power is the cheapest amongst all renewable energy sources, at only 2 to 4 cents (USD). Hydro power is often heavily reliant on existing natural features like rivers, high tides, and springs."));
        //Hydrogen Fueling is purchased
        //***ADD PURCHASING EVENT***//
        // events.Add(new InfoGameEvent("2024-02-27 00:00:00", "Hydrogen fueling provides a clean energy source for long distance travel. While it still requires much research, hydrogen fueling shows promise in heavy and long distance travel like public transport and shipments."));

        //More green bubbles appear in US
        events.Add(new EnergyGameEvent("2025-04-10 00:00:00", EnergyType.Wind, 41.3017f, -89.6236f, "United States of America"));
        events.Add(new EnergyGameEvent("2025-04-20 00:00:00", EnergyType.Wind, 42.4489f, -99.8917f, "United States of America"));
        events.Add(new EnergyGameEvent("2025-04-29 00:00:00", EnergyType.Solar, 36.1971f, -80.8067f, "United States of America"));
        events.Add(new EnergyGameEvent("2025-05-15 00:00:00", EnergyType.Solar, 40.2003f, -74.5761f, "United States of America"));
        events.Add(new EnergyGameEvent("2025-05-22 00:00:00", EnergyType.Solar, 42.0761f, -71.4227f, "United States of America"));
        events.Add(new EnergyGameEvent("2025-05-30 00:00:00", EnergyType.Solar, 33.7943f, -118.2414f, "United States of America"));
        events.Add(new EnergyGameEvent("2025-06-11 00:00:00", EnergyType.Solar, 40.5358f, -74.3913f, "United States of America"));
        events.Add(new EnergyGameEvent("2025-06-20 00:00:00", EnergyType.Hydro, 44.5281f, -121.1528f, "United States of America"));
        events.Add(new EnergyGameEvent("2025-06-28 00:00:00", EnergyType.Hydro, 35.0314f, -81.4936f, "United States of America"));
        events.Add(new EnergyGameEvent("2025-07-06 00:00:00", EnergyType.Hydro, 37.1510f, -119.5047f, "United States of America"));
        //Blue bubble appears in USA and CAN
        //***ADD BLUE BUBBLE EVENT***//
        //events.Add(new InfoGameEvent("2024-02-27 00:00:00", "Blue bubbles are indicators that a clean energy trade route has been established. Countries that do not have access to renewable energies may instead import clean energy from countries with a surplus. Keep upgrading the ‘Hydrogen Fueling’ branch to increase the range of exports."));
        //green bubbles apear in CHN and CHE
        events.Add(new EnergyGameEvent("2025-10-02 00:00:00", EnergyType.Hydro, 31.4837f, 103.6032f, "China"));
        events.Add(new EnergyGameEvent("2025-10-12 00:00:00", EnergyType.Hydro, 47.3925f, 8.0442f, "Switzerland"));

        //Iceland Hint
        events.Add(new InfoGameEvent("2026-01-03 00:00:00", "Did you know that 66% of Icelands energy comes from geothermal energy plants?"));
        //Geothermal power is purchased
        //***ADD PURCHASING EVENT***//
        //events.Add(new InfoGameEvent("2024-02-27 00:00:00", "While geothermal power does not have the energy capacity to compete with wind and solar, it is the most constant renewable energy source. It is especially useful in areas with lower energy demands that struggle to implement other renewable energies"));
        events.Add(new EnergyGameEvent("2026-02-15 00:00:00", EnergyType.Geothermal, 65.6408f, -16.8565f, "Iceland"));

        //Yellow bubble appears in Saudi Arabia
        //***ADD YELLOW BUBBLE EVENT***
        events.Add(new InfoGameEvent("2026-05-03 00:00:00", "Yellow bubbles are indicators that a social, economic, or political event has turned the tide of renewable energy in a specific region. These events can be positive and influence renewable growth in a region or lead to implementation of non-renewable energy plants. These events also have the chance of developing new technologies for you."));
        //Carbon Offsets is purchased
        //***ADD PURCHASING EVENT***//
        // events.Add(new InfoGameEvent("2024-02-27 00:00:00", "Carbon offsets are a medium for individuals and corporations to be held accountable for their greenhouse emissions. Entities can trade emissions by investing in renewable projects simultaneously. By applying social and political pressure to large entities, we can help reduce the impact of their carbon emissions via carbon offsets."));

        //Yellow bubble appears in France
        //***ADD YELLOW BUBBLE EVENT***
        events.Add(new InfoGameEvent("2026-05-03 00:00:00", "With increasing awareness of ecocide in European states, the EU is pushed to sign a treaty to go carbon neutral by 2050. You have developed a new technology— Carbon Capture!"));
        //Carbon Capture technology is given for free
        //***ADD PURCHASING EVENT***//
        // events.Add(new InfoGameEvent("2024-02-27 00:00:00", "Carbon Capture helps reduce emissions in areas with high concentrations of greenhouse gasses by physically removing carbon from the atmosphere. Upgrading this branch increases the chances of a red bubble turning green."));
        //5 green bubbles appear around yellow bubble region
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Wind, 41.8559f, -1.9224f, "Spain"));
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Hydro, 60.8648f, 9.2790f, "Norway"));
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Hydro, 48.7872f, 2.4033f, "France")); //same as red marker
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Wind, 54.5000f, 7.7999f, "Germany"));
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Hydro, 41.9547f, 14.3884f, "Italy"));
        //10 green bubbles in USA
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Solar, 44.4777f, -73.1534f, "United States of America"));
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Solar, 40.5161f, -74.3400f, "United States of America"));
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Solar, 42.1091f, -72.1712f, "United States of America"));
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Hydro, 29.5940f, -98.0407f, "United States of America"));
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Hydro, 36.2399f, -106.4230f, "United States of America"));
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Hydro, 42.9506f, -85.4859f, "United States of America"));
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Hydro, 34.8158f, -118.6867f, "United States of America"));
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Hydro, 48.1802f, -116.9986f, "United States of America"));
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Hydro, 44.5620f, -83.8045f, "United States of America"));
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Hydro, 42.5484f, -106.7175f, "United States of America"));
        //5 green bubbles in Iceland
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Geothermal, 64.0373f, -21.4007f, "Iceland"));
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Geothermal, 65.7035f, -16.7735f, "Iceland"));
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Geothermal, 64.1081f, -21.2567f, "Iceland"));
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Geothermal, 63.8251f, -22.6848f, "Iceland"));
        events.Add(new EnergyGameEvent("2024-04-02 00:00:00", EnergyType.Geothermal, 63.8788f, -22.4332f, "Iceland"));
        //5 green bubbles appear in China
        events.Add(new EnergyGameEvent("2024-02-29 00:00:00", EnergyType.Hydro, 31.4837f, 103.6032f, "China"));
        events.Add(new EnergyGameEvent("2024-02-29 00:00:00", EnergyType.Hydro, 27.3488f, 100.5061f, "China"));
        events.Add(new EnergyGameEvent("2024-02-29 00:00:00", EnergyType.Hydro, 31.0400f, 103.5700f, "China"));
        events.Add(new EnergyGameEvent("2024-02-29 00:00:00", EnergyType.Hydro, 26.6661f, 106.1219f, "China"));
        events.Add(new EnergyGameEvent("2024-02-29 00:00:00", EnergyType.Wind, 43.3500f, 115.9000f, "China"));
        events.Add(new InfoGameEvent("2029-02-27 00:00:00", "The world is going green! Keep upgrading your technologies and combating climate change one day at a time!"));
    }

    // Update is called once per frame
    void Update()
    {
        if (events.Count > 0 && !timeDateSO.isPaused) {
            GameEvent nextEvent = events.Peek();
            if (nextEvent.GetTimestamp() < timeDateSO.time) {
                events.ExtractMin();
                nextEvent.ExecuteEvent();
            }
        }
    }
}
