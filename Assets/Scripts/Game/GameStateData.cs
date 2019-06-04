using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { THROW_MODE, FETCH_MODE }

[CreateAssetMenu]
public class GameStateData : ScriptableObject
{
    public GameState state { get; private set; }

    private void OnEnable()
    {
         state = GameState.THROW_MODE;
    }

    public void ToggleState()
    {
        if (state == GameState.FETCH_MODE)
            state = GameState.THROW_MODE;
        else
            state = GameState.FETCH_MODE;
    }
}
