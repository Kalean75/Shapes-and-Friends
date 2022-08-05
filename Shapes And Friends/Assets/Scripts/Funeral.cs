using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Funeral : MonoBehaviour
{
	public static int totalFriends;
	public TextMeshProUGUI textBox;
	[SerializeField] float Creditstimer;
	// Update is called once per frame
	void Start()
    {
		Creditstimer = 20f;
		totalFriends = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getTotalFriends();
		getTotalFriends();
	}
	void Update()
	{
		Creditstimer -= Time.deltaTime;
		if (Creditstimer <= 0)
		{
			SceneManager.LoadScene(4);
		}
	}

	public void getTotalFriends()
    {
		textBox.text = "You made " + totalFriends.ToString() + " friends";
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			SceneManager.LoadScene(2);
		}
	}
}
