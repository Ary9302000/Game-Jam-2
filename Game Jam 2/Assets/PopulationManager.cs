using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationManager : MonoBehaviour
{
    public static int populationValue = 5;
    public static int populationCapacity = 10;
    public Text text;
    
    // Update is called once per frame
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
