using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehavior : MonoBehaviour
{
    public float verticalSpeed = 0;
    public float horizontalSpeed = 5;
    public int rotationSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(horizontalSpeed * Time.deltaTime, verticalSpeed * Time.deltaTime, 0);
        transform.Rotate (0,0,rotationSpeed*Time.deltaTime*-1);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        verticalSpeed *= -1;
        horizontalSpeed *= -1;
    }
}
