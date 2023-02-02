using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendFollowPlayer : MonoBehaviour
{
    public Transform enemy;
    public Transform player;
    public float speed;
    
    public ColorChangeScript ccs;
    public Transform target;
    public GameObject coloredbody;
    public GameObject redbody;
    public GameObject bluebody;
    public GameObject whitebody;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ccs = coloredbody.GetComponent<ColorChangeScript>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = Random.Range(4f, 8f);
        redbody.transform.LookAt(player);
        bluebody.transform.LookAt(player);
        whitebody.transform.LookAt(player);
        if (ccs.is_follow_who == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        if (ccs.is_follow_who == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemy.position, speed * Time.deltaTime);
        }
        

        
    }
}
