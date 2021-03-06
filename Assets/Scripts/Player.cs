using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    private float initialSpeed;

    private bool _isRunning;
    public bool isRunning
    {
        get { return _isRunning; }
    }
    
    private bool _isCutting;
    public bool isCutting
    {
        get { return _isCutting; }
    }

    [SerializeField] private bool _isRolling;
    public bool isRolling
    {
        get { return _isRolling; }
    }

    private Rigidbody2D rigidBody;
    private Vector2 _direction;
    public Vector2 direction
    {
        get { return _direction; }
    }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    private void Update()
    {
        OnInput();
        OnRun();
        OnRolling();
        OnCutting();
    }

    private void FixedUpdate()
    {
        OnMove();
    }


    #region Movement

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rigidBody.MovePosition(rigidBody.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isRolling = true;
            speed = runSpeed;
        }
        if (Input.GetMouseButtonUp(1))
        {
            _isRolling = false;
            speed = initialSpeed;
        }
    }

    void OnCutting() {
        if (Input.GetMouseButtonDown(0))
        {
            _isCutting = true;
            speed = 0f;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isCutting = false;
            speed = initialSpeed;
        }
    }

    #endregion Movement


}
