using UnityEngine;

#if UNITY_EDITOR
public class Gizmo_Generic : MonoBehaviour
{
    enum GizmoPreset{
        Custom,
        SETrigger,
        CandleBatch
    }

    [SerializeField] GizmoPreset gizmoPreset = GizmoPreset.Custom;
    [SerializeField] Color color = Color.white;
    [SerializeField] float radius = 0.5f;

    void OnDrawGizmos()
    {
        switch(gizmoPreset){
            case GizmoPreset.Custom:
                Gizmos.color = color;
                break;
            case GizmoPreset.SETrigger:
                Gizmos.color = Color.blue;
                break;
            case GizmoPreset.CandleBatch:
                Gizmos.color = Color.yellow;
                break;
        }
        
        Gizmos.DrawSphere(transform.position, radius);
    }
}
#endif