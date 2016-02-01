using UnityEngine;
using System.Collections;

public class anim_code : MonoBehaviour
{
	Animator anim;

    void Start ()
	{
		anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetFloat("speed", 1);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetFloat("speed", 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetFloat("speed", 1);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetFloat("speed", 0);
        }


        if (Input.GetKey(KeyCode.S))
        {
            anim.SetFloat("speed", 1);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetFloat("speed", 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetFloat("speed", 1);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetFloat("speed", 0);
        }
	}

    
}