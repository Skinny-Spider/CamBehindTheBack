using UnityEngine;

public class Player : MonoBehaviour
{
    public float mouseSensitivity;

    private float speed = 4.0f;

    float leftRightRot;
    void Start()
    {

    }


    void Update()
    {

        leftRightRot = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity; ;
        


        transform.Rotate(new Vector3(0, leftRightRot));
       

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.up * 7 * Time.deltaTime;
        }
    }
}