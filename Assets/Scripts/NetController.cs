using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetController : MonoBehaviour
{
    public float speed;
    public GameObject sheepHerd;
    public GameObject wolfPack;
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            Vector3 rotation = gameObject.transform.rotation.eulerAngles;
            rotation.z -= (Input.GetAxis("Horizontal") / 2);
            gameObject.transform.rotation = Quaternion.Euler(rotation);
        }
        Vector3 finalPos = transform.position + transform.up * Time.deltaTime * speed;
        //press W to double speed
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            finalPos += transform.up * Time.deltaTime * speed * 2;
        }
        //Debug.Log(finalPos.magnitude);
        if (finalPos.magnitude < 40)
        {
            transform.position = finalPos;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Sheep")
        {
            sheepHerd.GetComponent<Flock>().EatSheep(collision.gameObject);
            GameManager.score += 1;
        }
        else if (collision.transform.tag == "Wolf")
        {
            wolfPack.GetComponent<Flock>().EatSheep(collision.gameObject);
            GameManager.score -= 20;
        }
    }
}
