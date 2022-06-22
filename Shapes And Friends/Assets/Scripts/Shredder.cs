using UnityEngine;

public class Shredder : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		//removes gameobject from game
		Destroy(collision.gameObject);
		if(GameObject.FindGameObjectWithTag("Spawner").GetComponent<FriendSpawner>().getCurrentlySpawnedFriends() > 0)
		{
			GameObject.FindGameObjectWithTag("Spawner").GetComponent<FriendSpawner>().decrementCurrentlySpawnedFriends();
		}
	}
}
