using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeScript : MonoBehaviour
{
    public Material red;
    public GameObject coloredbodyblue;
    public GameObject coloredbodyred;
    Collider col;
    public Transform player;
    public Transform enemy;
    bool isc = false;
    public Transform parent;
    public Transform grandparent;
    public int is_follow_who = 0;
    public GameObject whitedummy;
    public Animator friendanim;
    public RuntimeAnimatorController walker;
    public RuntimeAnimatorController idler;
    bool is_walking = false;
    // Start is called before the first frame update
    void Start()
    {
        col = coloredbodyblue.GetComponent<Collider>();
        parent = transform.parent.transform;
        friendanim.runtimeAnimatorController = idler;
        Debug.Log(parent.name);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        parent.transform.LookAt(player);
        if(is_walking)
        {
            friendanim.runtimeAnimatorController = walker;
        }
        //coloredbodyred.transform.LookAt(enemy);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FriendMakeScript fms = other.GetComponent<FriendMakeScript>();
            fms.istalking = true;
            
            if (!isc)
            {
                StartCoroutine(DelayPlayer());
                isc = true;
            }
            
            
            
            
        }
        if(other.tag == "Enemy")
        {
            FriendMakeScript fms = other.GetComponent<FriendMakeScript>();
            fms.istalking = true;
            

            if (!isc)
            {
                StartCoroutine(DelayEnemy());
                isc = true;
            }
        }
    }

    public IEnumerator DelayPlayer()
    {
        yield return new WaitForSeconds(5);
        coloredbodyblue.SetActive(true);
        
        coloredbodyred.SetActive(false);
        coloredbodyblue.transform.LookAt(player);
        FriendAnimate fa = coloredbodyblue.GetComponent<FriendAnimate>();
        fa.enabled = true;
        col.enabled = false;
        parent.tag = "Untagged";
        PlayerPrefs.SetInt("FriendsBlue", PlayerPrefs.GetInt("FriendsBlue") + 1);
        is_follow_who = 1;
        Collider coll = GetComponent<Collider>();
        coll.enabled = false;
        if (!is_walking)
        {
            is_walking = true;
        }
        
        whitedummy.SetActive(false);
        
    }
    public IEnumerator DelayEnemy()
    {
        yield return new WaitForSeconds(5);
        coloredbodyblue.SetActive(false);
        
        coloredbodyred.SetActive(true);
        coloredbodyblue.transform.LookAt(player);
        col.enabled= false;
        parent.tag = "Untagged";
        PlayerPrefs.SetInt("FriendsRed", PlayerPrefs.GetInt("FriendsRed") + 1);
        is_follow_who = 2;
        Collider coll = GetComponent<Collider>();
        coll.enabled = false;
        if(!is_walking)
        {
            is_walking = true;
        }
        
        
        whitedummy.SetActive(false);
        //this.gameObject.SetActive(false);
    }

}


