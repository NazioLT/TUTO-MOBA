using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRaycaster : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;

    private Camera cam;
    private InputController inputs;

    private Vector3 moveTarget;

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
            moveTarget = _hit.point;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(moveTarget, 0.5f);
    }
}