using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class CurrentNumberofFriends : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    // Update is called once per frame
    void Update()
    {
        textBox.text = "Friends: " + GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getCurrentNumberofFriends().ToString();
    }
}
