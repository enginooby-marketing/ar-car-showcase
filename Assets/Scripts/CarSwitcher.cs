using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CarSwitcher : MonoBehaviour
{
    List<GameObject> cars;
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
        cars[AppController.Instance.currentCarId].SetActive(true);
    }

    public void SwitchLeft()
    {
        cars[AppController.Instance.currentCarId].SetActive(false);
        AppController.Instance.currentCarId = (AppController.Instance.currentCarId == 0) ? cars.Count - 1 : AppController.Instance.currentCarId - 1;
        cars[AppController.Instance.currentCarId].SetActive(true);
    }

    public void SwitchRight()
    {
        cars[AppController.Instance.currentCarId].SetActive(false);
        AppController.Instance.currentCarId = (AppController.Instance.currentCarId == cars.Count - 1) ? 0 : AppController.Instance.currentCarId + 1;
        cars[AppController.Instance.currentCarId].SetActive(true);
    }
}
