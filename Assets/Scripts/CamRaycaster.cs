using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CamRaycaster : MonoBehaviour
{
    private Vector3 moveTarget;

    [SerializeField] private LayerMask groundLayer;

    private Camera cam;
    private InputsManager inputs;

    private void Start()
    {
        cam = GetComponent<Camera>();
        inputs = InputsManager.instance;
    }

    public void StartRay()
    {
        Ray _ray = cam.ScreenPointToRay(inputs.MousePos);
        RaycastHit _hit;

        if (Physics.Raycast(_ray.origin, _ray.direction, out _hit, float.MaxValue, groundLayer))
        {
            moveTarget = _hit.point;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(moveTarget, 0.5f);
    }
}