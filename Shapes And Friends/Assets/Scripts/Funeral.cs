using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Funeral : MonoBehaviour
{
	public static int totalFriends;
	public TextMeshProUGUI textBox;
	// Update is called once per frame
	void Start()
    {
		getTotalFriends();
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			totalFriends = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getTotalFriends();
			SceneManager.LoadScene(2);
		}
	}

	public void getTotalFriends()
    {
		textBox.text = totalFriends.ToString();
    }
}
