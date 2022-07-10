using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendSpawner : MonoBehaviour
{
    [SerializeField] float maxspawnRate = 100f;
    [SerializeField] float minspawnRate = 10f;
    float spawnTimer;
    //[SerializeField] int MaxSpawnedFriends = 1;
    [SerializeField] GameObject friend;
    [SerializeField] GameObject spawner;
    private int currentlySpawnedFriends = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(minspawnRate, maxspawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        //Debug.Log(spawnTimer);
        if (spawnTimer <= 0f)
        {
            Instantiate(friend, new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z), Quaternion.identity);
            incrementCurrentlySpawnedFriends();
            spawnTimer = Random.Range(minspawnRate, maxspawnRate);
            Debug.Log(currentlySpawnedFriends);
        }
        /*if (currentlySpawnedFriends <= MaxSpawnedFriends)
        {
            spawnTimer -= Time.deltaTime;
            //Debug.Log(spawnTimer);
            if (spawnTimer <= 0f)
			{
                Instantiate(friend, new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z), Quaternion.identity);
                incrementCurrentlySpawnedFriends();
                spawnTimer = Random.Range(1, spawnRate);
                Debug.Log(currentlySpawnedFriends);
            }
        }*/
    }
    /// <summary>
    /// gets the number of friends that are currently spawned by the spawner
    /// </summary>
    /// <returns>returns the number of currently spawned friends</returns>
    public int getCurrentlySpawnedFriends()
	{
        return currentlySpawnedFriends;
	}
    /// <summary>
    /// increments the number of spawned friends by 1
    /// </summary>
    /// 

    public void incrementCurrentlySpawnedFriends()
	{
        currentlySpawnedFriends++;
	}
    /// <summary>
    /// decrements the number of currently spawned friends by 1
    /// </summary>
    public void decrementCurrentlySpawnedFriends()
    {
        currentlySpawnedFriends--;
    }
}
