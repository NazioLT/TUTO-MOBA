using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputsManager : MonoBehaviour
{
    public static InputsManager instance { private set; get; }

    [SerializeField] private UnityEvent fireEvent = new UnityEvent();

    private Mouse mouse;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;

        mouse = Mouse.current;
    }

    private void OnFire() => fireEvent.Invoke();
    public Vector2 MousePos => mouse.position.ReadValue();
}
