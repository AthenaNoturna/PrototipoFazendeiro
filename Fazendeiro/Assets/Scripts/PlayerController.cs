using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float xRange = 15f;
    public GameObject projectilePrefab;
    private float horizontalInput;
    private InputActionAsset inputActions;

    private InputAction Pause;

    public GameObject Panel;

    void Start()
    {
        Pause = InputSystem.actions.FindAction("Pause");
    }
    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Pause.ReadValue<Vector2>().x;

        // float horizontalInput = Input.GetAxis("Horizontal");
        // movimenta o player para esquerda e direita a partir da entrada do usuario
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        // mantém o player dentro dos limites do jogo (eixo x)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.y);
        }
    
      
        
    }
    public void MoveEvent(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
    }
    public void FireEvent(InputAction.CallbackContext context)
    {
        Debug.Log("Dispara pezza");
         Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }

    private void OnEnable()
    {
        inputAction.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        inputAction.FindActionMap("Player").Disable();
    }

    private void PauseOn()
   {
         if (Pausa.WasPressedThisFrame())
        {
            panel.SetActive(true);
            InputActions.FindActionMap("Player").Disable(); 
            InputActions.FindActionMap("UI").Enable(); 
        }
        if (Pausa.WasPressedThisFrame())
        {
            panel.SetActive(false);
            InputActions.FindActionMap("Player").Enable(); 
            InputActions.FindActionMap("UI").Disable(); 
        }
    }
    
}

