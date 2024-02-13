using UnityEngine;

public class SectionDoorComponent : MonoBehaviour
{
    [SerializeField] int targetScene;
    [SerializeField] int targetSection;
    [SerializeField] IntVariable sectionToLoad;
    [SerializeField] Vector3 targetPositionValue;
    [SerializeField] Vector3 targetEulerRotationValue;
    [SerializeField] Vector3Variable targetPositionVar;
    [SerializeField] Vector3Variable targetEulerRotationVar;

    public void Open(){
        sectionToLoad.value = targetSection;
        targetPositionVar.value = targetPositionValue;
        targetEulerRotationVar.value = targetEulerRotationValue;
        PersistantManager.instance.LoadScene(targetScene);
    }
}
