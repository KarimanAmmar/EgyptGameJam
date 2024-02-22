using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Colony/CollectEggData", order = 1)]
public class GameEvents : ScriptableObject
{
    UnityAction gameAction;
    public UnityAction GameAction { get { return gameAction; } set { gameAction = value; } }
}
