using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private Rigidbody rb;
    [Header("Speeds")]
    [SerializeField] private int rotationSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float boostDelay;
    [SerializeField] private float boostSpeed;

    public Collider other;

    private bool isOnGround;
    private bool boostPressable = true;


    void FixedUpdate()
    {
        if(Input.GetAxis("Vertical") >=  0 && isOnGround) 
        {
            rb.AddRelativeForce(0, 0, speed*Time.fixedUnscaledDeltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetAxis("Vertical") <= 0 && isOnGround)
        {
            rb.AddRelativeForce(0, 0, speed * Time.fixedUnscaledDeltaTime * -1, ForceMode.VelocityChange);
        }
        if (Input.GetAxis("Horizontal") < 0 && isOnGround)
        {
            this.transform.Rotate(new Vector3(0, 1, 0), rotationSpeed * Time.fixedUnscaledDeltaTime);
        }
        if (Input.GetAxis("Horizontal") > 0 && isOnGround)
        {
            this.transform.Rotate(new Vector3(0, 1, 0), -1 * rotationSpeed * Time.fixedUnscaledDeltaTime) ;
        }
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            rb.AddRelativeForce(0, jumpForce, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.LeftShift) && isOnGround)
        {
            rb.AddRelativeForce(0, 0, boostSpeed * speed * Time.fixedUnscaledDeltaTime, ForceMode.VelocityChange);
            StartCoroutine(boost());
        }
        switch (isOnGround)
        {
            case true:
                rb.drag = 2f;
                break;
            case false:
                rb.drag = 0.2f;
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
       isOnGround = true;
 
        
    }
    void OnTriggerExit(Collider other)
    {
        isOnGround = false;
    }

    IEnumerator boost()
    {
            yield return new WaitForSeconds(10f);
        
    }
}
