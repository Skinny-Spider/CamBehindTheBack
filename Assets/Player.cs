using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public Vector3 jump;
    public float jumpForce = 1.0f;

    public float maxGroundAngle = 45f;

    public bool isGrounded;
    Rigidbody rb;

    public float mouseSensitivity;

    public float speed = 3000;

    float leftRightRot;

    List<GameObject> currentCollisions = new List<GameObject>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }



    private void OnCollisionEnter(Collision collision)
    {
        currentCollisions.Add(collision.gameObject);

        Vector3 collidedObjectNormal = collision.contacts[0].normal;

        Vector3 rigibodyNormal = new Vector3(0, 1, 0);

        float angle = Vector3.Angle(collidedObjectNormal, rigibodyNormal);
               
        if (angle < 45)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        currentCollisions.Remove(collision.gameObject);

        isGrounded = false;
    }

    

    void Update()
    {

        Debug.Log($"CurrentCollisions: {currentCollisions.Count}");

        if (transform.position.y < -50)
        {
            Respawn();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {           
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);           
        }

        leftRightRot = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity; ;
        transform.Rotate(new Vector3(0, leftRightRot));


        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Vector3 newVelocity = transform.right * speed * Time.deltaTime;
            rb.velocity = new Vector3(newVelocity.x, rb.velocity.y, newVelocity.z); 
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Vector3 newVelocity = -transform.right * speed * Time.deltaTime;
            rb.velocity = new Vector3(newVelocity.x, rb.velocity.y, newVelocity.z);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Vector3 newVelocity = transform.forward * speed * Time.deltaTime;
            rb.velocity = new Vector3(newVelocity.x, rb.velocity.y, newVelocity.z);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            Vector3 newVelocity = -transform.forward * speed * Time.deltaTime;
            rb.velocity = new Vector3(newVelocity.x, rb.velocity.y, newVelocity.z);
        }
    }

    void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}