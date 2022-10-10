using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamPointData : MonoBehaviour
{
    [SerializeField][Range(1, 3)] int _Ring = 1;
    [SerializeField][Range(1, 4)] int _Zone = 1;

    public int ring => _Ring;
    public int zone => _Zone;
}
