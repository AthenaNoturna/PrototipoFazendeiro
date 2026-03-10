using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class AnotherPlayerControl : MonoBehaviour
{
    public float speed = 20f;
    public float xRange = 15f;
    public GameObject projectilePrefab;
    public InputActionAsset InputActions;
    private InputAction moveAction;
    private Input fireAction;
    private float horizontalInput;

    // Update is called once per frame

    void Update()
    {
        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        // mantém o player dentro dos limites do jogo (eixo x)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.y);
            if (fireAction.WasPressedThisFrame())
            {
                Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            }
        }
    }
    public void MoveEvent(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
    }
    public void FireEvent(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }


    // Update is called once per frame
    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();

    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();

    }
    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Jump");
    }


}
