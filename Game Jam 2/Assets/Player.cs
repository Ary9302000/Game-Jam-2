using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int populationValue = 5;
    public int populationCapacity = 10;
    public int woodValue = 0;
    public int stoneValue = 0;
    public int foodValue = 0;
    public float consumptionRate = 10f;
    public int prepDuration;
    public int winterDuration;
    public bool Winter;
    public GameObject clone;
    public bool building;
    public Text[] resourceDisplays;

    // Start is called before the first frame update
    void Start()
    {
        resourceDisplays[0].text = woodValue.ToString();
        resourceDisplays[1].text = stoneValue.ToString();
        resourceDisplays[2].text = foodValue.ToString();
        resourceDisplays[3].text = populationValue.ToString() + "/" + populationCapacity.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (building)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 temp;
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, 9))
            {
                temp = hit.point;
                clone.transform.position = temp;
                clone.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Place(clone);
                Debug.Log("Placing");
            } else if (Input.GetMouseButtonDown(1))
            {
                building = false;
                clone.SetActive(false);
                Debug.Log("Cancel");
            }
        }
    }

    public void CreateBuilding(GameObject gameObject)
    {

        clone = gameObject;
        clone.SetActive(true);
        Debug.Log(clone.name);
        building = true;
        Debug.Log("BuildingSelected");
    }
    public void Place(GameObject gameObject)
    {
        Instantiate(clone, clone.transform.position, clone.transform.rotation);
        Debug.Log(clone.tag);
        if(clone.tag == "Cottage")
        {
            ChangePopulationCap(5);
        }
        if(clone.tag == "Storehouse")
        {
            consumptionRate -= 0.5f;
        }
        // Deduct resources
        building = false;
        clone.SetActive(false);
    }
    public void ChangeWood(int value)
    {
        woodValue += value;
        resourceDisplays[0].text = woodValue.ToString();
    }
    public void ChangeFood(int value)
    {
        foodValue += value;
        resourceDisplays[2].text = foodValue.ToString();
    }
    public void ChangeStone(int value)
    {
        stoneValue += value;
        resourceDisplays[1].text = stoneValue.ToString();
    }
    public void ChangePopulationCap(int value)
    {
        populationCapacity += value;
        resourceDisplays[3].text = populationValue.ToString() + "/" + populationCapacity.ToString();
    }
    public void ChangePopulation(int value)
    {
        populationValue += value;
        resourceDisplays[3].text = populationValue.ToString() + "/" + populationCapacity.ToString();
    }
}
