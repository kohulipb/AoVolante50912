using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle1;
    [SerializeField] private GameObject obstacle2;
    [SerializeField] private GameObject obstacle3;

    private GameObject spawnedObj;
    [SerializeField] private GameObject road;
    [SerializeField] private Transform roadTrans;
    private int rnd;

    [SerializeField] private int zOffset;
    private Vector3 offset;

    private bool wasSpawned;
    private bool roadWasSpawned;
    private bool startMoving;
    private bool movingLeft;
    private bool movingRight;
    public float speed;

    private Vector3 leftMov;
    private Vector3 rightMov;
    
    private void FixedUpdate()
    {
        if (startMoving)
        {
            
            if (spawnedObj.transform.position.x == 9 || movingLeft)
            {
                Debug.Log(spawnedObj.gameObject.transform.position.x);
                spawnedObj.transform.position = Vector3.MoveTowards(spawnedObj.transform.position, new Vector3(-9, spawnedObj.transform.position.y, spawnedObj.transform.position.z), speed);
                movingLeft = true;
                movingRight = false;
            }
            if (spawnedObj.transform.position.x == -9 || movingRight)
            {
                Debug.Log(spawnedObj.gameObject.transform.position.x);
                spawnedObj.transform.position = Vector3.MoveTowards(spawnedObj.transform.position, new Vector3(9, spawnedObj.transform.position.y, spawnedObj.transform.position.z), speed);
                movingRight = true;
                movingLeft = false;
            }


        }
    }
    private void Start()
    {
        offset = new Vector3(0, 0, zOffset);
        //rightMov = new Vector3(9, spawnedObj.transform.position.y, spawnedObj.transform.position.z);
        //leftMov = new Vector3(-9, spawnedObj.transform.position.y, spawnedObj.transform.position.z);
        wasSpawned = false;
        roadWasSpawned = false;
        movingLeft = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        rnd = Random.Range(1, 3);
        if (other.gameObject.tag == "Player" && !wasSpawned) 
        {
            switch (rnd)
            {
                case 1:
                    spawnedObj = Instantiate(obstacle1, new Vector3(Random.Range(-9, 9), transform.position.y, transform.position.z)  + offset, Quaternion.identity);
                    
                    startMoving = true;
                    
                    break;
                case 2:
                    spawnedObj = Instantiate(obstacle2, new Vector3(Random.Range(-9, 9), transform.position.y, transform.position.z) + offset, Quaternion.identity);
                    
                    startMoving = true;
                    
                    break;
                case 3:
                    spawnedObj = Instantiate(obstacle3, new Vector3(Random.Range(-9, 9), transform.position.y, transform.position.z) + offset, Quaternion.identity);
                     startMoving = true;
                    
                    break;
            }
            spawnedObj.transform.position = new Vector3(9, spawnedObj.transform.position.y, spawnedObj.transform.position.z);
            wasSpawned = true;
        }
        if (this.gameObject.name == "Col3" && !roadWasSpawned) 
        {
            Instantiate(road, roadTrans.transform.position + new Vector3(0, 0, 200), Quaternion.Euler(0, 90, 0));
            roadWasSpawned = true;
        }
    }
}
