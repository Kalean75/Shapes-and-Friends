using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infantScroll : MonoBehaviour
{
    private float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        scrollSpeed = GameObject.FindGameObjectWithTag("MainBG").GetComponent<Scroller>().getScrollSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3((0.040f * scrollSpeed) * Time.deltaTime, 0);
    }
}
