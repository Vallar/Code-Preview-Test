using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRegisterSelf : MonoBehaviour
{
    [SerializeField] private TransformVariable variable;

    private void OnEnable()
    {
        variable.value = transform;
    }
}
