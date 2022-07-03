using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRaycaster : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;

    private Camera cam;
    private InputController inputs;
    [SerializeField] private PlayerMotor player;

    private void Start()
    {
        cam = Camera.main;
        inputs = InputController.instance;
    }

    public void StartRay()
    {
        Ray _ray = cam.ScreenPointToRay(inputs.MousePos);
        RaycastHit _hit;

        if (Physics.Raycast(_ray.origin, _ray.direction, out _hit, Mathf.Infinity, groundLayer))
        {
            player.MoveTo(_hit.point);
        }
    }
}