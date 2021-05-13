using UnityEngine;
using TMPro;
using Newtonsoft.Json;

public partial class Wit3D : MonoBehaviour
{
    public TextMeshProUGUI HandleLabel;
    public Animator animator;

    private void HandleWitResponse(string jsonString)
    {
        if (jsonString != null)
        {

            Root responseObject = JsonConvert.DeserializeObject<Root>(jsonString);

            if (responseObject.entities.DoorEntity == null || responseObject.intents == null)
            {
                HandleLabel.text = "Invalid command";
            }
            else
            {
                string action = responseObject.intents[0].name;
                string entity = responseObject.entities.DoorEntity[0].name;
                HandleLabel.text = "Action: " + action + " - Entity: " + entity;
                ExecuteCommand(action, entity);
            }
        }

    }

    private void ExecuteCommand(string action, string entity)
    {
        animator.SetTrigger(action + "-" + entity);
    }
}