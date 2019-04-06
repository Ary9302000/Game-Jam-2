using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : Player
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateBuilding(GameObject gameObject)
    {
        clone = gameObject;
        clone.SetActive(true);
        building = true;
    }


}
