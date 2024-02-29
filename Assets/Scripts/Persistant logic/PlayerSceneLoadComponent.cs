using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSceneLoadComponent : MonoBehaviour
{
    [SerializeField] Vector3Variable targetPositionVar;
    [SerializeField] Vector3Variable targetEulerRotationVar;

    public void MatchTransform(){

        if(!LoadFlags.movementLoad) 
            return;
        transform.position = targetPositionVar.value;
        transform.eulerAngles = targetEulerRotationVar.value;
        LoadFlags.movementLoad = false;
        SaveManager.instance.SaveGame();
    }
}
