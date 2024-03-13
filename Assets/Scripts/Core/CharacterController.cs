using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 20f;

    // Internal
    private Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        Vector2 movement = new Vector2(x: Input.GetAxis("Horizontal"), y: Input.GetAxis("Vertical"));
        myRigidbody2D.MovePosition(myRigidbody2D.position + movement * speed * Time.fixedDeltaTime);
    }
}
