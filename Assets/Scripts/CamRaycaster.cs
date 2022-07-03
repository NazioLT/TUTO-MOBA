using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CamRaycaster : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;

    private Camera cam;
    private InputsManager inputs;
    [SerializeField] private CharacterMotor player;

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
            player.MoveTo(_hit.point);
        }
    }
}