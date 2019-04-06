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
}
