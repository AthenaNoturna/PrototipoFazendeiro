using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController1 : MonoBehaviour
{
    public float speed = 20f;
    public float xRange = 15f;
    public GameObject projectilePrefab;
    private float horizontalInput;

    public InputActionAsset InputActions;
    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction menuActionPlayer;
    private InputAction menuActionUI;
    public GameObject painel;

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
        menuActionPlayer = InputSystem.actions.FindAction("Menu");
        menuActionUI = InputSystem.actions.FindAction("UIMenu");
    }
    void Update()
    {
        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        // movimenta o player para esquerda e direita a partir da entrada do usu�rio
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        // mant�m o player dentro dos limites do jogo (eixo x)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.y);
        }
        if(fireAction.WasPressedThisFrame())
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

        }
        MenuGame();
       
}
void MenuGame()
    {
         if (menuActionPlayer.WasPressedThisFrame())
        {
            painel.SetActive(true);
            InputActions.FindActionMap("Player").Disable(); 
            InputActions.FindActionMap("UI").Enable(); 
        }
        if (menuActionUI.WasPressedThisFrame())
        {
            painel.SetActive(false);
            InputActions.FindActionMap("Player").Enable(); 
            InputActions.FindActionMap("UI").Disable(); 
        }
    }
    }