using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFlagsAgent : MonoBehaviour
{
    public bool MovementLoad{
        set => LoadFlags.movementLoad = value;
    }

    public bool NewGameLoad{
        set => LoadFlags.newGameLoad = value;
    }

    public bool DeathLoad{
        set => LoadFlags.deathLoad = value;
    }
}

public static class LoadFlags
{
    public static bool movementLoad = false;
    public static bool newGameLoad = false;
    public static bool deathLoad = false;
}

