using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendSpawner : MonoBehaviour
{
    //[SerializeField] float maxSpawnRate = 100f;
    //[SerializeField] float minSpawnRate = 10f;
    [SerializeField] float childHoodSpawnTimer = 1f;
    [SerializeField] float adolescentSpawnTimer = 3f;
    [SerializeField] float youngAdultSpawnTimer = 8f;
    [SerializeField] float adultSpawnTimer = 30f;
    float spawnTimer;
    //[SerializeField] int MaxSpawnedFriends = 1;
    [SerializeField] GameObject friend;
    //[SerializeField] GameObject spawner;
    //private int currentlySpawnedFriends = 0;
    // Start is called before the first frame update
    void Start()
    {
		//spawnTimer = Random.Range(minSpawnRate, maxSpawnRate);
		spawnTimer = Random.Range(0, childHoodSpawnTimer);
	}

    // Update is called once per frame
    void Update()
	{
		int i = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getStageOfLife();
		if (i > 0 && i < 4)
		{
			spawnTimer -= Time.deltaTime;
		}
		//setSpawnTimer(i);
		//Debug.Log(spawnTimer);
		if (spawnTimer <= 0f)
		{
			Instantiate(friend, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
			//incrementCurrentlySpawnedFriends();
			setSpawnTimer(i);
			//Debug.Log(currentlySpawnedFriends);
		}

	}

	private void setSpawnTimer(int i)
	{
		switch (i)
		{
			case 1:
				spawnTimer = Random.Range(childHoodSpawnTimer, adolescentSpawnTimer);
				break;
			case 2:
				spawnTimer = Random.Range(adolescentSpawnTimer, youngAdultSpawnTimer);
				break;
			case 3:
				spawnTimer = Random.Range(youngAdultSpawnTimer, adultSpawnTimer);
				break;
			case 4:
				spawnTimer = 10000f;
				break;
			default:
				break;
		}
	}
}
