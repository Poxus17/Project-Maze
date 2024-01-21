using System;
using System.Collections.Generic;
using UnityEngine;

public class HidingManager : MonoBehaviour
{
    private GameObject player;

    public static HidingManager instance;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = CentralAI.Instance.player;

    }
}
