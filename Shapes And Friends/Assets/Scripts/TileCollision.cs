using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCollision : MonoBehaviour
{
    float scrollSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        scrollSpeed = GameObject.FindGameObjectWithTag("Background").GetComponent<Scroller>().getScrollSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-scrollSpeed * Time.deltaTime, 0);
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
        //Debug.Log(collision.tag);
        if(collision.CompareTag("Player"))
		{
            ParticleSystem particle = GetComponent<ParticleSystem>();
            particle.transform.position = (this.GetComponent<Collider2D>().transform.position - collision.transform.position).normalized;
            particle.transform.rotation = new Quaternion(-collision.transform.rotation.x, -collision.transform.rotation.y, collision.transform.rotation.z, collision.transform.rotation.w);
            particle.Play();
        }
    }
    /*private void OnTriggerExit2D(Collider2D collision)
    {
       // Debug.Log(collision.tag);
        if (collision.CompareTag("Player"))
        {
            ParticleSystem particle = GetComponent<ParticleSystem>();
            particle.transform.position = this.GetComponent<Collider2D>().ClosestPoint(new Vector2(collision.transform.position.x, collision.transform.position.y));
            particle.Play();
        }
    }*/
}
