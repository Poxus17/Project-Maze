using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] UIComponent[] UIIndex;
    [SerializeField] GameEvent[] LaunchGlobalUIEvents;
    [SerializeField] GameEvent[] CloseGlobalUIEvents;
    [SerializeField] BoolVariable[] UILocks;
    [SerializeField] BoolVariable inUI;

    GameEvent currentBoundEvent;
    UIComponent currentComponent;
    UIComponent nestedComponent;

    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        //Make sure all components have their personal, internal binding in order
        foreach(UIComponent uic in UIIndex)
        {
            uic.PersonalEventBindings();
        }

    }

    #region Handle main component
    public void LaunchUIComponent(int componentIndex)
    {
        if(PersistantManager.instance.IsLoading)
            return;

        foreach (BoolVariable bval in UILocks) // If any lock is true, straight out quit the launch
            if (bval.value)
                return; // Replace with error messege

        if(currentComponent != null)
            CloseUIComponent();

        RaiseGlobalUIEvents(LaunchGlobalUIEvents);

        currentComponent = UIIndex[componentIndex];
        currentComponent.LaunchComponent();
        inUI.value = true;
        Debug.Log("Launched UI component: " + currentComponent.name);
    }

    public void CloseUIComponent()
    {
        //I have no idea what's causing it to fire twice
        if (currentComponent == null)
            return;

        if (nestedComponent != null)
            CloseNestedObject();

        if(currentBoundEvent != null)
        {
            currentBoundEvent.Raise();
            currentBoundEvent = null;
        }

        Debug.Log("Closing UI component: " + currentComponent.name);
        currentComponent.CloseComponent();
        currentComponent = null;

        RaiseGlobalUIEvents(CloseGlobalUIEvents);
        inUI.value = false;
    }

    public void BindGameEventToExit(GameEvent gameEvent)
    {
        currentBoundEvent = gameEvent;
    }
    #endregion

    #region Handle nested component
    //Nested UI is when you need to open a screen within a screen, like inspection from inventory. You can currently only nest 1 UI
    public void LaunchNestedUIComponent(int componentIndex)
    {
        if (nestedComponent != null)
            CloseNestedObject();

        nestedComponent = UIIndex[componentIndex];
        nestedComponent.LaunchComponent();
    }

    

    public void CloseNestedObject()
    {
        if (nestedComponent == null)
            return;

        nestedComponent.CloseComponent();
        nestedComponent = null;
    }
    #endregion

    private void RaiseGlobalUIEvents(GameEvent[] events)
    {
        foreach(GameEvent ge in events)
        {
            ge.Raise();
        }
    }

}

