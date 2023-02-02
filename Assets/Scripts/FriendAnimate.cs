using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendAnimate : MonoBehaviour
{
    public Animator friendanim;
    public RuntimeAnimatorController runner;
    // Start is called before the first frame update
    void Start()
    {
        friendanim.runtimeAnimatorController = runner;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
