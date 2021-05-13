using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSwitcher : MonoBehaviour
{
    List<GameObject> cars;
    int currentCarId;

    void Start()
    {
        PopulateCarList();
    }

    private void PopulateCarList()
    {
        cars = new List<GameObject>();
        foreach (Transform child in transform)
        {
            cars.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
        cars[currentCarId].SetActive(true);
    }

    public void SwitchLeft()
    {
        cars[currentCarId].SetActive(false);
        currentCarId = (currentCarId == 0) ? cars.Count - 1 : currentCarId - 1;
        cars[currentCarId].SetActive(true);
    }

    public void SwitchRight()
    {
        cars[currentCarId].SetActive(false);
        currentCarId = (currentCarId == cars.Count - 1) ? 0 : currentCarId + 1;
        cars[currentCarId].SetActive(true);
    }
}
