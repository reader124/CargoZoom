using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody car;
    public GameObject camera;
    public float speed;
    public float turnSpeed;
    public float camDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement controls
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            car.AddTorque(transform.up * turnSpeed * -1);
            car.AddTorque(transform.forward * turnSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            car.AddTorque(transform.up * turnSpeed);
            car.AddTorque(transform.forward * turnSpeed * -1);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            car.AddForce(transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            car.AddForce(transform.forward * speed * -1);
            car.AddTorque(transform.right * -1);
        }

        //camera motion
        float d = Vector3.Distance(camera.transform.position, car.transform.position);

        if (d > camDistance)
        {
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, transform.position, d * Time.deltaTime);
            camera.transform.LookAt(transform.position);
        }
    }
}
