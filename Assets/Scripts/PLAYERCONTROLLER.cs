using UnityEngine;
using UnityEngine.InputSystem;

public class PLAYERCONTROLLER : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    
    [Header("Animation")]
    private Animator animator;
    
    private Vector2 moveInput;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        
        if (animator == null)
        {
            Debug.LogError("No se encontró el componente Animator en el GameObject");
        }
    }

    void Update()
    {
        HandleInput();
        HandleMovement();
        HandleAnimation();
    }
    
    private void HandleInput()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard != null)
        {
            Vector2 input = Vector2.zero;
            
            if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) input.y += 1;
            if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) input.y -= 1;
            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) input.x -= 1;
            if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) input.x += 1;
            
            moveInput = input.normalized;
        }
    }
    
    private void HandleMovement()
    {
        if (moveInput != Vector2.zero)
        {
            transform.Translate(moveInput * moveSpeed * Time.deltaTime);
            
            if (moveInput.x != 0)
            {
                transform.localScale = new Vector3(
                    Mathf.Sign(moveInput.x) * Mathf.Abs(transform.localScale.x),
                    transform.localScale.y,
                    transform.localScale.z
                );
            }
        }
    }
    
    private void HandleAnimation()
    {
        if (animator == null) return;
        
        // Usamos SetBool porque el parámetro 'RUN' en el Animator es de tipo Bool (Verdadero/Falso)
        float speed = moveInput.magnitude;
        animator.SetBool("RUN", speed > 0.1f);
        
        // Debug para verificar
        if (speed > 0)
        {
            Debug.Log("Speed: " + speed);
        }
    }
}