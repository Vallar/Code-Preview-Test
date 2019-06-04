using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Int Variable")]
public class IntVariable : ScriptableObject
{
    public int value;

    private void OnEnable()
    {
        value = 0;
    }
}
