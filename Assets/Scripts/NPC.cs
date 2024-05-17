using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private SpriteRenderer _interactSprite;

    private Transform _playerTransform;

    private const float INTERACT_DISTANCE = 6220f;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _playerTransform = player.transform;
            Debug.Log("Player is tracked");
        }
        else
        {
            Debug.LogError("Player not found! Ensure the player GameObject is tagged with 'Player'.");
        }
    }
    // Update is called once per frame
    public void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && IsWithinInteractDistance())
        //if (Vector2.Distance(_playerTransform.position, transform.position) < 6135f)
        {
            Interact();
        }

        if (_interactSprite.gameObject.activeSelf && !IsWithinInteractDistance())
        {
            _interactSprite.gameObject.SetActive(false);
        }
        else if (!_interactSprite.gameObject.activeSelf && IsWithinInteractDistance())
        {
            _interactSprite.gameObject.SetActive(true);
        }
        
    }

    public abstract void Interact();

    private bool IsWithinInteractDistance()
    {
        if (Vector2.Distance(_playerTransform.position, transform.position) < INTERACT_DISTANCE)
        {
            //Debug.Log(Vector2.Distance(_playerTransform.position, transform.position));
            //Debug.Log("Within distance");
            return true;
        } else
        {
            //Debug.Log(Vector2.Distance(_playerTransform.position, transform.position));
            //Debug.Log("Out of distance");
            return false;
        }
        
    }
   
}
