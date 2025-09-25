using UnityEngine;
using UnityEngine.UI;

public class UpdateWorld : MonoBehaviour
{
    [SerializeField] private Text text;

    private void LateUpdate()
    {
        var worldStates = GWorld.Instance.GetWorldStates().GetStates();
        text.text = "";

        foreach (var KVP in worldStates)
        {
            text.text += $"{KVP.Key}: {KVP.Value} \n";
        }
    }
}