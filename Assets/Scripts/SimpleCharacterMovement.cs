using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class SimpleCharacterMovement : MonoBehaviour
{
    [SerializeField] Camera_3D lookingMouse;

    [Header("Move")]
    public float movingSpeed = 5;
    public float runningSpeedFactor = 1.5f;
    public float rotationSpeed = 3;
    public bool holdShiftToRun = false;
    

    private bool isRunning = false;
    private bool zoom = false;
    private bool playerHit = false;
    private Vector2 direction;
    private Animator _animator;
    private Vector2 mouseInput;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (direction.magnitude != 0)
        {
            _animator.SetFloat("Speed", isRunning?5:3);
            float speed = movingSpeed * (isRunning ? runningSpeedFactor : 1);
            transform.Translate(speed * direction.x * Time.deltaTime, 0, speed * direction.y * Time.deltaTime);
            //transform.Rotate( 0,rotationSpeed*direction.x*Time.deltaTime, 0);
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }

        lookingMouse.ReceiveInput(mouseInput);
        lookingMouse.ReceiveInputZoom(zoom);
        Debug.Log(mouseInput);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        direction = ctx.ReadValue<Vector2>();
    }

    public void Run(InputAction.CallbackContext ctx)
    {
        isRunning = holdShiftToRun && ctx.ReadValueAsButton();
    }

    public void Zoom(InputAction.CallbackContext ctx)
    {
        zoom = ctx.ReadValueAsButton();
    }

    public void MoveX(InputAction.CallbackContext ctx)
    {
        mouseInput.x = ctx.ReadValue<float>();
    }

    public void MoveY(InputAction.CallbackContext ctx)
    {
        mouseInput.y = ctx.ReadValue<float>();
    }
    
}
