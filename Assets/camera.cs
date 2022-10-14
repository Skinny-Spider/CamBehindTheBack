using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    float verticalRot;
    public float mouseSensitivity;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalRot = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity; ;
        transform.Rotate(new Vector3(verticalRot, 0));
    }
}
