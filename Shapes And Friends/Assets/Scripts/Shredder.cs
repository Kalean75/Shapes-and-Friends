using UnityEngine;

public class Shredder : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		//removes gameobject from game
		Destroy(collision.gameObject);
		GameObject.FindGameObjectWithTag("Spawner").GetComponent<FriendSpawner>().currentlySpawnedFriends--;
	}
}
