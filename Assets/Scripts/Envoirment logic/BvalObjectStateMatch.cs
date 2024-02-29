using UnityEngine;

public class BvalObjectStateMatch : MonoBehaviour
{
    [SerializeField] BoolVariable matchValue;
    [SerializeField, Tooltip("Reverse the value")] bool matchAsNot;
    valueMatchType valueMatchType; // If you ever need it

    public void MatchState()
    {
        // This is the weirdest, most far fetched piece of code I eve wrote. Good luck figuring this shit out
        gameObject.SetActive(matchAsNot ? !matchValue.value : matchValue.value);
    }
}
enum valueMatchType { ObjectActive, Test};
