using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetController : MonoBehaviour
{
    public float speed;
    public GameObject sheepHerd;
    public GameObject wolfPack;
    public float turnSpeed;
    void Update()
    {
        //if pressing left or right
        if (Input.GetAxis("Horizontal") != 0)
        {
            //turning code
            Vector3 rotation = gameObject.transform.rotation.eulerAngles;
            if (Input.GetAxisRaw("Vertical") == -1)//if slowing down
            {
                rotation.z -= (Input.GetAxis("Horizontal") / 2);//double turn speed
            }
            else
            {
                rotation.z -= (Input.GetAxis("Horizontal") / 4);//regular turn speed
            }
            gameObject.transform.rotation = Quaternion.Euler(rotation);
        }
        //move forward constantly
        Vector3 finalPos = transform.position + transform.up * Time.deltaTime * speed;
        //press W to double speed
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            finalPos += transform.up * Time.deltaTime * speed * 2;
        }//press S to halve speed
        else if (Input.GetAxisRaw("Vertical") == -1)
        {
            finalPos -= transform.up * Time.deltaTime * speed / 2;
        }
        //Debug.Log(finalPos.magnitude);
        //if final position after moving is inside the barrel
        if (finalPos.magnitude < 40)
        {
            transform.position = finalPos;//move
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if colliding with sheep
        if (collision.transform.tag == "Sheep")
        {
            sheepHerd.GetComponent<Flock>().EatSheep(collision.gameObject);//destroy sheep
            GameManager.score += 1;
        }//else if colliding with wolf
        else if (collision.transform.tag == "Wolf")
        {
            wolfPack.GetComponent<Flock>().EatSheep(collision.gameObject);//destroy wolf
            GameManager.score -= 20;
        }
    }
}
