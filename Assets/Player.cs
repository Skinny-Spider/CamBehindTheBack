using UnityEngine;

public class Player : MonoBehaviour
{

    public Vector3 jump;
    public float jumpForce = 1.0f;

    public bool isGrounded;
    Rigidbody rb;

    public float mouseSensitivity;

    private float speed = 4.0f;

    float leftRightRot;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnCollisionExit()
    {
        isGrounded = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("####### JUMP  ######");
            
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            
        }
        
        leftRightRot = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity; ;
        transform.Rotate(new Vector3(0, leftRightRot));
       

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        
    }
}