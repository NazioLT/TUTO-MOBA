using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static InputController instance { private set; get; }

    [SerializeField] private UnityEvent fireEvent = new UnityEvent();

    private Mouse mouse;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
            return;
        }
        instance = this;

        mouse = Mouse.current;
    }

    private void OnFire() => fireEvent.Invoke();

    public Vector2 MousePos => mouse.position.ReadValue();
}