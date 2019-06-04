using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameEvent dropTreatEvent;
    [SerializeField] private TransformVariable petTarget;
    [SerializeField] private GameObjectVariable treatPrefab;
    [SerializeField] private Transform treatOriginalPosition;

    public void DropTreat()
    {
        Transform t = Instantiate(treatPrefab.value, treatOriginalPosition.position, Quaternion.identity).transform;
        petTarget.value = t;
        dropTreatEvent.gameEvent.Invoke();
    }
}
