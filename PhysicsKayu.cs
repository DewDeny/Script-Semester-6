using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsKayu : MonoBehaviour
{
    public float rotateSpeed = 10;
    public Vector3 logFloatTarget;
    public float logFloatStrenght;
    public float logLength = 5;
    bool logFloat = false;

    void Start()
    {

    }

    void Update()
    {
        if (logFloat == true)
        {
            Facing();
            Float();
        }
    }
    void Facing()
    {
        Quaternion toRotation = Quaternion.LookRotation(new Vector3(0, 1, 0), Vector3.right);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * 100 * Time.deltaTime);
    }

    void Float()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        logFloatStrenght = 1*(logFloatTarget.y- transform.position.y );
        transform.Translate(Vector3.up * logFloatStrenght * Time.deltaTime,Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water" )
        {
            Debug.Log("ae!");
            logFloatTarget = other.transform.position;
            logFloat = true;
        }
    }
}