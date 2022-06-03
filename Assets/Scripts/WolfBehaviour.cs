using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBehaviour : MonoBehaviour
{
    public GameObject sheepHerd;

    private void Awake()
    {
        sheepHerd = GameObject.Find("SheepHerd");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.transform.tag);
        if (collision.transform.tag == "Sheep")
        {
            sheepHerd.GetComponent<Flock>().EatSheep(collision.gameObject);
        }
    }
}
