using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendSpawner : MonoBehaviour
{
    [SerializeField] float spawnRate = 100f;
    float spawnTimer;
    [SerializeField] int MaxSpawnedFriends = 1;
    [SerializeField] GameObject friend;
    [SerializeField] GameObject spawner;
    private int currentlySpawnedFriends = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(1, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlySpawnedFriends < MaxSpawnedFriends)
        {
            spawnTimer -= Time.deltaTime;
            if(spawnTimer <= 0f)
			{
                Instantiate(friend, new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z), Quaternion.identity);
                currentlySpawnedFriends++;
                spawnTimer = Random.Range(1, spawnRate);
            }
        }
    }

    public int getCurrentlySpawnedFriends()
	{
        return currentlySpawnedFriends;
	}

    public void incrementCurrentlySpawnedFriends()
	{
        currentlySpawnedFriends++;
	}
    public void decrementCurrentlySpawnedFriends()
    {
        currentlySpawnedFriends--;
    }
}
