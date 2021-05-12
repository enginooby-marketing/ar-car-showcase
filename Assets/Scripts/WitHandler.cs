using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using TMPro;
using Newtonsoft.Json;

public partial class Wit3D : MonoBehaviour
{
    public TextMeshProUGUI HandleLabel;

    void HandleWitResponse(string jsonString)
    {
        if (jsonString != null)
        {
            // ResponseObject responseObject = JsonUtility.FromJson<ResponseObject>(jsonString);
            // ResponseObject responseObject = new ResponseObject();
            Root responseObject = JsonConvert.DeserializeObject<Root>(jsonString);
            // JsonConvert.PopulateObject(jsonString, responseObject);
            print(responseObject.text);
            // print(responseObject.entities.entityItems[0].name);

            // if (responseObject.entities.entity != null)
            // {
            //     foreach (EntityItem entityItem in responseObject.entities.entity.entityItems)
            //     {
            //         Debug.Log(entityItem.confidence);
            //         HandleLabel.text = entityItem.name;
            //         commandValid = true;
            //     }
            // }
        }

    }

}