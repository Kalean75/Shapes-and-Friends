using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    //serializeField makes the value editable within unity if clicking on object
    [SerializeField] float scrollSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Add renderer to background
        transform.position += new Vector3(-5 * Time.deltaTime, 0);

        if (transform.position.x < -21.5)
        {
            transform.position = new Vector3(21.5f, transform.position.y);
        }
    }
}
