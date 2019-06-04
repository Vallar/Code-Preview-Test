using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float cameraSensetivity = 10;
    [SerializeField] private float maxVerticalLook = 90;
    private float yAxisClamp;
    private new Transform transform;

    private void Awake()
    {
        transform = base.transform;
    }

    private void OnEnable()
    {
        yAxisClamp = 0f;
    }

    private void LateUpdate()
    {
        float xAxis = Input.GetAxis("Mouse X") * cameraSensetivity * Time.deltaTime;
        float yAxis = Input.GetAxis("Mouse Y") * cameraSensetivity * Time.deltaTime;

        yAxisClamp += yAxis;

        if (Mathf.Abs(yAxisClamp) > maxVerticalLook)
        {
            if (yAxisClamp > 0)
            {
                yAxisClamp = maxVerticalLook;
                transform.eulerAngles = new Vector3(maxVerticalLook + 180, transform.eulerAngles.y, transform.eulerAngles.z);
            }
            else
            {
                yAxisClamp = -maxVerticalLook;
                transform.eulerAngles = new Vector3(maxVerticalLook, transform.eulerAngles.y, transform.eulerAngles.z);
            }

            yAxis = 0;
        }

        transform.Rotate(Vector3.left * yAxis);
        player.Rotate(Vector3.up * xAxis);
    }
}
