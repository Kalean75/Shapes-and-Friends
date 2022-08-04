using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StageOfLife : MonoBehaviour
{
	public TextMeshProUGUI textBox;
	public new GameObject collider;
	private bool moving;
	private bool next;
	float scrollSpeed;
	void Start()
    {
		moving = false;
		next = false;
		scrollSpeed = GameObject.FindGameObjectWithTag("MainBG").GetComponent<Scroller>().getScrollSpeed();
	}
	void Update()
    {
        if (moving)
        {
			scrollSpeed = GameObject.FindGameObjectWithTag("MainBG").GetComponent<Scroller>().getScrollSpeed();
			transform.position += new Vector3((0.0625f*scrollSpeed) * Time.deltaTime, 0);
			GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.white, Time.deltaTime * 1);
			if (next)
			{
				GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().changeStageOfLife();//Change player stage of life to the next stage
				next = false;
			}
		}

	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		string[] Stage = { "Childhood", "Adolecense", "Young Adulthood", "Adulthood", "Elder","Death" }; //List of which stages of life is load from.
		
		//string[] Stage = {"Apprentice", "Cultist", "Prophet", "Saint" };
		if (collision.CompareTag("UI")) { 
			collider.SetActive(false);//Disable collider prefab
			int i = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getStageOfLife();//Get current stage of life from player
			textBox.text = Stage[i];
			
			if (i > 4)
            {
				scrollSpeed = 0.0125f;
				SceneManager.LoadScene(2);
            }
			moving = true;
			next = true;
		}
	}

}
