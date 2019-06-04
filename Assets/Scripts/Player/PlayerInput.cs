using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameStateData gameState;
    [SerializeField] private Projectile projectile;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float forceMultiplyerTime = 6;
    private float buttonHeldTime = 1;
    private float originalTime = 1;
    private new Transform transform;

    private void Awake()
    {
        transform = base.transform;
    }

    private void Update()
    {
        if (gameState.state == GameState.FETCH_MODE)
            return;
        
        if (Input.GetMouseButton(0))
            buttonHeldTime += Time.deltaTime;

        if (Input.GetMouseButtonUp(0))
        {
            if (buttonHeldTime > forceMultiplyerTime)
                buttonHeldTime = forceMultiplyerTime;

            Projectile p = Instantiate(projectile, cameraTransform.position, transform.rotation);
            p.Throw(cameraTransform.forward, buttonHeldTime);
            buttonHeldTime = originalTime;
        }
    }
}
