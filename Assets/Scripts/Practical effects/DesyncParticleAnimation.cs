using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class DesyncParticleAnimation : MonoBehaviour
{
    void Start()
    {
        //Random.InitState(gameObject.GetInstanceID() * Mathf.RoundToInt(transform.position.x) * Mathf.RoundToInt(transform.position.z));
        ParticleSystem.TextureSheetAnimationModule animationModule = GetComponent<ParticleSystem>().textureSheetAnimation;

        var framesCount = animationModule.numTilesX * animationModule.numTilesY;
        var frame = Mathf.Round(Random.Range(0, framesCount));
        animationModule.startFrame = frame/framesCount;
    }
}
