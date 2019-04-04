using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationManager : Player
{
    public Text text;
    
    void Update()
    {
        text.text = populationValue.ToString() + "/" + populationCapacity.ToString();
    }
    public static void ChangePopulation(int value)
    {
        populationValue += value;
    }
    public static void ChangePopulationCap(int value)
    {
        populationCapacity += value;
    }

}
