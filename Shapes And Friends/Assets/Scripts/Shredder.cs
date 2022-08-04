using UnityEngine;

public class Shredder : MonoBehaviour
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="collision"></param>
	private void OnTriggerEnter2D(Collider2D collision)
	{
		//removes gameobject from game
		if(!collision.CompareTag("Player") && !collision.CompareTag("NPC") && !collision.CompareTag("Spawner"))
		{
			Destroy(collision.gameObject);
		}
	}
}
