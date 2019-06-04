using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Variables/GameObject Variable")]
public class GameObjectVariable : ScriptableObject
{
    public GameObject value;

    private void OnEnable()
    {
        value = null;
    }
}
