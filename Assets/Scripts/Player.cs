using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForceModule;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode jumpKey;

    private bool isFloating = false;

    private void FixedUpdate()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        float xSpeed = 0f;
        float zSpeed = 0f;
        
        if (Input.GetKey(leftKey))
        {
            xSpeed = -speed;
        }
        else if (Input.GetKey(rightKey))
        {
            xSpeed = speed;
        }

        if (Input.GetKey(upKey))
        {
            zSpeed = speed;
        } 
        else if (Input.GetKey(downKey))
        {
            zSpeed = -speed;
        }
        
        rigidBody.velocity = new Vector3 (xSpeed, 0, zSpeed);
        
        if (Input.GetKey(jumpKey) && !isFloating)
        {
            rigidBody.AddForce(Vector3.up * jumpForceModule);
            isFloating = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            isFloating = false;
        }
    }
}
