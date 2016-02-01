using UnityEngine;
using System.Collections;

public class AnimController : MonoBehaviour
{
    public float scaleX = .1f;
    public GameObject[] skeletons = null;

    void Start ()
    {
		scaleX = gameObject.transform.localScale.x;
        ActivateSkele(skeletons[0]);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKey(KeyCode.D))
        {
            ActivateSkele(skeletons[1]);
            scaleX = Mathf.Abs(scaleX);
        }

        if (Input.GetKey(KeyCode.A))
        {
            ActivateSkele(skeletons[1]);
            scaleX = -Mathf.Abs(scaleX);
        }

        if (Input.GetKey(KeyCode.S))
        {
            ActivateSkele(skeletons[0]);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            ActivateSkele(skeletons[2]);
        }
    }

    void LateUpdate()
    {
        transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
    }

    private void ActivateSkele(GameObject skele)
    {
        foreach (GameObject temp in skeletons)
        {
            if (temp == skele)
            {
                temp.SetActive(true);
                continue;
            }
            temp.SetActive(false);
        }
    }

}
