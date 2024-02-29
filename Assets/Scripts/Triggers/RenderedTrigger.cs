using UnityEngine;

public class RenderedTrigger : BaseTrigger
{
    [SerializeField] Renderer renderer; //Renderer.

    private void Update()
    {
        if(!active)
            return;
        
        if (renderer.isVisible)
            Trigger();
    }
}
