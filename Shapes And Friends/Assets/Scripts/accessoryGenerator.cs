using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accessoryGenerator : MonoBehaviour
{
    [Header("Possible Accessories")]
    [SerializeField] List<Sprite> accessories = new List<Sprite>();
    SpriteRenderer accessory;
    // Start is called before the first frame update
    void Start()
    {
        accessory = GetComponent<SpriteRenderer>();
        generateAccesory(Random.Range(0, accessories.Count + 1));
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void generateAccesory(int index)
    {
        if(index < accessories.Count)
		{
            accessory.sprite = accessories[index];
        }
    }
}
