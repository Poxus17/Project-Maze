using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityHandler : MonoBehaviour
{
    public void ChangeQuality(int index)
    {
        QualitySettings.SetQualityLevel(index, false);
    }
}
