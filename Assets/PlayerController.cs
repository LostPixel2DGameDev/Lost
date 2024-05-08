using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public float MoveSpeed { get; private set; } = 5f;
    [field: SerializeField] public DirectionalAmination Move { get; private set; }

    private Vector2 _axisInput;
    private Rigidbody2D _rb;
    private Animator _animator;
    private DirectionalAmination _currentSet;
    private AnimationClip _currentClip;
    private Vector2 _facingDir;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _currentSet = Move;
    }

    private void Update()
    {
        AnimationClip expectedClip = _currentSet.GetFacingClip(_facingDir);
        if (_currentClip == null || _currentClip != expectedClip)
        {
            _animator.Play(expectedClip.name);
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveForce = _axisInput * MoveSpeed * Time.fixedDeltaTime;

        _rb.AddForce(moveForce);
    }

    private void OnMove(InputValue value)
    {
        _axisInput = value.Get<Vector2>();

        if (_axisInput != Vector2.zero)
        {
            _facingDir = _axisInput;
        }

    }

}
