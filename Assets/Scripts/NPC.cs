using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class NPC : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {

        }
        
    }
}
