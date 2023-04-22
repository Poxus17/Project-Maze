using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreehouseEntranceHandler : MonoBehaviour
{
    [SerializeField] Vector3 treehouseBase;
    [SerializeField] Vector3 treehouseTop;
    [SerializeField] float transitionSpeed;
    [SerializeField] bool startUp;
    [SerializeField] UnityEngine.Events.UnityEvent ChangeState;
    public BoolVariable inTreehouse;

    private void Start()
    {
        inTreehouse.value = startUp;
    }

    public void OnUseTreehouseDoor()
    {
        StartCoroutine(TreehouseTransition());
    }

    IEnumerator TreehouseTransition()
    {
        FadeManager.instance.Fade(true);

        yield return new WaitForSeconds(2f);

        inTreehouse.value = inTreehouse.value ? false : true;
        transform.position = inTreehouse.value ? treehouseTop : treehouseBase;
        ChangeState.Invoke();

        FadeManager.instance.Fade(false);
    }
}
