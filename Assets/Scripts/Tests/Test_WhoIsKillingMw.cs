using UnityEngine;

public class Test_WhoIsKillingMw : MonoBehaviour
{
    public void OnDestroy(){
        Debug.LogError("Who is killing me?");
    }
}
