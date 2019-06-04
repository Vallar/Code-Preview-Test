using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Game Events/Game Event")]
public class GameEvent : ScriptableObject
{
    public UnityEvent gameEvent = new UnityEvent();
}
