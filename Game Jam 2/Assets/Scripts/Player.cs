using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
//    public NavMeshSurface surface;
    public int populationValue = 0;
    public int populationCapacity = 10;
    public int woodValue = 0;
    public int stoneValue = 0;
    public int foodValue = 0;
    public float consumptionRate = 10f;
    public int prepDuration;
    public int winterDuration;
    public bool Winter;
    public GameObject clone;
    public GameObject townHall;
    public GameObject villager;
    public bool building;
    public Text[] resourceDisplays;
    List<GameObject> pooledObjects;

    // Start is called before the first frame update
    void Start()
    {
//        surface.BuildNavMesh();
        resourceDisplays[0].text = woodValue.ToString();
        resourceDisplays[1].text = stoneValue.ToString();
        resourceDisplays[2].text = foodValue.ToString();
        resourceDisplays[3].text = populationValue.ToString() + "/" + populationCapacity.ToString();
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < populationCapacity; i++)
        {
            GameObject obj = Instantiate(villager);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        int index = 5;
        while (index > 0)
        {
            Spawn(index);
            index--;
        }
    }

    public void Train(GameObject villager)
    {
        var script = villager.GetComponent<Building>();
        if(foodValue< script.GetFCost())
        {
            Debug.Log("not enough resources");
        }
        else
        {
            Spawn(1);
        }
    }
    public void Spawn(int j)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].SetActive(true);
                pooledObjects[i].transform.position = townHall.transform.position + new Vector3(j - 2, -0.25f, -1);
                ChangePopulation(1);
                return;
            }
        }
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
                Debug.Log(clone.transform.position);
                Place(clone);
                Debug.Log("Placing");
            }
            else if (Input.GetMouseButtonDown(1))
            {
                building = false;
                clone.SetActive(false);
                Debug.Log("Cancel");
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 temp;
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                temp = hit.point;
            }
            Debug.Log(hit.collider.name);
            if (hit.collider.tag == "Villager")
            {
                VillagerAI.Select(hit.collider.gameObject);
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
        var script = gameObject.GetComponent<Building>();
        if(woodValue < script.GetWCost() || stoneValue < script.GetSCost())
        {
            Debug.Log("not enough resources");
            building = false;
            clone.SetActive(false);
            return;
        }
        ChangeWood(-script.GetWCost());
        ChangeStone(-script.GetSCost());
        Instantiate(clone);
        Debug.Log(clone.tag);
        if(clone.tag == "Cottage")
        {
            ChangePopulationCap(5);
        }
        if(clone.tag == "Storehouse")
        {
            consumptionRate -= 0.5f;
        }
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
        for (int i = 0; i < value; i++)
        {
            GameObject obj = Instantiate(villager);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        resourceDisplays[3].text = populationValue.ToString() + "/" + populationCapacity.ToString();
    }
    public void ChangePopulation(int value)
    {
        populationValue += value;
        resourceDisplays[3].text = populationValue.ToString() + "/" + populationCapacity.ToString();
    }
}
