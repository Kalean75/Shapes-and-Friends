using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageOfLife : MonoBehaviour
{
	public TextMeshProUGUI textBox;
	public GameObject collider;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		//string[] Stage = { "Kindergarten", "Elementary", "Home School", "Highschool" }; //List of which stages of life is load from. 
		string[] Stage = {"Apprentice", "Cultist", "Prophet", "Saint" };
		if (collision.CompareTag("Player"))
		{
			int i = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getStageOfLife();//Get current stage of life from player
			textBox.text = Stage[i];
			GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().changeStageOfLife();//Change player stage of life to the next stage
			collider.SetActive(false);//Disable collider prefab
		}
	}

}
