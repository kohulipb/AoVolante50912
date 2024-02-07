using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 distance;
    [Header("Offset manipulation")]
    [SerializeField] private float distanceX;
    [SerializeField] private float distanceY;
    [SerializeField] private float distanceZ;

    private void Start()
    {
        distance = new Vector3(distanceX, -(distanceY), distanceZ);
        
    }
    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = target.position - distance;
    }
}
