using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public float verticalSpeed = 5;
    public float horizontalSpeed = 0;
    public int rotationSpeed = 200;
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
