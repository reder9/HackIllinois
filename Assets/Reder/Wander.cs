using UnityEngine;
using System.Collections;

/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// </summary>
/// 

public class Wander : MonoBehaviour
{
    public float speed = 5;
    float heading;
    private Rigidbody rb;
   
    void Awake()
    {
       
        rb = this.GetComponent<Rigidbody>();
        // Set random initial rotation
        heading = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(0, heading, 0);

        StartCoroutine(NewHeading());
    }

    void Update()
    {

        var forward = this.transform.forward;
        rb.velocity = forward * speed; 
    }

    /// <summary>
    /// Repeatedly calculates a new direction to move towards.
    /// Use this instead of MonoBehaviour.InvokeRepeating so that the interval can be changed at runtime.
    /// </summary>
    IEnumerator NewHeading()
    {
        while (true)
        {
            NewHeadingRoutine();
            yield return new WaitForSeconds(Random.Range(3, 5));
        }
    }

    /// <summary>
    /// Calculates a new direction to move towards.
    /// </summary>
    void NewHeadingRoutine()
    {
        heading = Random.Range(0, 360);
        this.transform.rotation = Quaternion.Euler(0, heading, 0);
    }
}