using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewPastObjectData", menuName = "\"Special\" Variables/Past object data")]
public class PastObjectData : PhysicalObject
{
    public AudioClip clip;

    [TextArea(15, 20)]
    public string transcript;

    public void Copy(PastObjectData pod)
    {
        name = pod.name;
        icon = pod.icon;
        clip = pod.clip;
        itemPrefab = pod.itemPrefab;
        transcript = pod.transcript;
    }
}
