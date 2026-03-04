using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    private Vector2 moveInput;

    // Automatically called by input sys
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        //only w and s
        float forward = moveInput.y;

        Vector3 movement = new Vector3(0, 0, forward);

        transform.position += movement * speed * Time.deltaTime;

        // Lock player to the line 
        Vector3 pos = transform.position;
        pos.x = 0f;
        pos.y = 0.017f;
        transform.position = pos;
    }
}