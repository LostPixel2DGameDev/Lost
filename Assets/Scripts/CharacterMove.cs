using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    private Rigidbody2D rigidbody2;
    public float speed;
    public int length;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float HInput = Input.GetAxis("Horizontal");
        float VInput = Input.GetAxis("Vertical");

        rigidbody2.velocity = new Vector2(HInput * speed, VInput * speed);

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(length);
    }
}
