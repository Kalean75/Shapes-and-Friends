using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Funeral : MonoBehaviour
{
	public static int totalFriends;
	public TextMeshProUGUI textBox;
	[SerializeField] float Creditstimer = 20f;
	// Update is called once per frame
	void Start()
    {
		getTotalFriends();
    }
	void Update()
	{
		if(GameObject.Find("Player"))
		{
			totalFriends = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getTotalFriends();
		}
		Creditstimer -= Time.deltaTime;
		if(Creditstimer <= 0)
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
