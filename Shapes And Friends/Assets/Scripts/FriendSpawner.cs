using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendSpawner : MonoBehaviour
{
    [SerializeField] float maxSpawnRate = 100f;
    [SerializeField] float minSpawnRate = 10f;
    float spawnTimer;
    //[SerializeField] int MaxSpawnedFriends = 1;
    [SerializeField] GameObject friend;
    //[SerializeField] GameObject spawner;
    //private int currentlySpawnedFriends = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(minSpawnRate, maxSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        //Debug.Log(spawnTimer);
        if (spawnTimer <= 0f)
        {
            Instantiate(friend, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            //incrementCurrentlySpawnedFriends();
            spawnTimer = Random.Range(minSpawnRate, maxSpawnRate);
            //Debug.Log(currentlySpawnedFriends);
        }
      
    }
}
