using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBehaviour : MonoBehaviour
{
    public GameObject sheepHerd;
    //done in awake because doing it in start triggers it too late
    private void Awake()
    {
        sheepHerd = GameObject.Find("SheepHerd");
    }
    //eat if collider hits agent tagged sheep
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.transform.tag);
        if (collision.transform.tag == "Sheep")
        {
            sheepHerd.GetComponent<Flock>().EatSheep(collision.gameObject);
        }
    }
}
