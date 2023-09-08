using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIComponent : MonoBehaviour
{
    protected delegate void ComponentPersonalEvents();

    protected event ComponentPersonalEvents LaunchComponentPersonalEvents;
    protected event ComponentPersonalEvents CloseComponentPersonalEvents;

    [Header("Component settings")]
    [Space(2)]
    public GameEvent[] LaunchComponentPublicEvents;
    public GameEvent[] CloseComponentPublicEvents;

    [Tooltip("false for fire personal first")] public bool FirePublicFirst = false;

    public void LaunchComponent()
    {
        gameObject.SetActive(true);

        if (FirePublicFirst)
        {
            RaisePublicEvents(true);
            RaisePersonalEvents(true);
        }
        else
        {
            RaisePersonalEvents(true);
            RaisePublicEvents(true);
        }
            
    }

    public void CloseComponent()
    {
        if (FirePublicFirst)
        {
            RaisePublicEvents(false);
            RaisePersonalEvents(false);
        }
        else
        {
            RaisePersonalEvents(false);
            RaisePublicEvents(false);
        }

        gameObject.SetActive(false);
    }

    /// <param name="launch">false for close events</param>
    void RaisePersonalEvents(bool launch)
    {
        if (launch)
        {
            if (LaunchComponentPersonalEvents != null)
                LaunchComponentPersonalEvents();
        }  
        else
            if (CloseComponentPersonalEvents != null)
                    CloseComponentPersonalEvents();
    }

    /// <param name="launch">false for close events</param>
    void RaisePublicEvents(bool launch)
    {
        GameEvent[] pointer = launch ? LaunchComponentPublicEvents : CloseComponentPublicEvents;

        foreach (GameEvent ge in pointer)
            ge.Raise();
    }

    public virtual void PersonalEventBindings() { }

    private void OnDestroy()
    {
        Debug.Log(gameObject.name + "Has been disabled");
        if (LaunchComponentPersonalEvents != null)
        {
            System.Delegate[] deletegates = LaunchComponentPersonalEvents.GetInvocationList();
            for (int i = 0; i < deletegates.Length; i++)
            {
                //Remove all event
                LaunchComponentPersonalEvents -= deletegates[i] as ComponentPersonalEvents;
            }
        }

        if (CloseComponentPersonalEvents != null)
        {
            System.Delegate[] deletegates = CloseComponentPersonalEvents.GetInvocationList();
            for (int i = 0; i < deletegates.Length; i++)
            {
                //Remove all event
                CloseComponentPersonalEvents -= deletegates[i] as ComponentPersonalEvents;
            }
        }
    }
}
