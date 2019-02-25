using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_spawn_pool : MonoBehaviour
{
    GameObject[] micepool;
    public int spawnAmount;
    public GameObject mousePrefab;
    public float spawnRate = 4f;
    private float timeSinceSpawn;
    private int currentMouse = 0;
    private Transform trans;
    private Vector2 tempPosition = new Vector2(-20, -20);
    private Vector2 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        spawnPosition = trans.transform.position;
        micepool = new GameObject[spawnAmount];
        for (int i = 0; i < spawnAmount; i++)
        {
            micepool[i] = (GameObject)Instantiate(mousePrefab, tempPosition, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn >= spawnRate)
        {
            Rigidbody2D mouserb2d = micepool[currentMouse].GetComponent<Rigidbody2D>();
            mouserb2d.velocity = new Vector2(0, 0);
            micepool[currentMouse].transform.position = new Vector2(trans.transform.position.x, trans.transform.position.y);
            micepool[currentMouse].GetComponent<mouseai1>().spawner = true;

            currentMouse++;
            
            if (currentMouse >= spawnAmount)
            {
                currentMouse = 0;
            }
            timeSinceSpawn = 0;
        }
    }
}
