using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFlip : MonoBehaviour
{
    private Transform parent;
    public bool isFlipped;

    private Vector3 originScale;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        originScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        CheckParentFLip();
    }

    private void CheckParentFLip()
    {
        float parentX = parent.transform.localScale.x;
        if (parentX >= 0)
        {

            isFlipped = false;
            Flip();
            return;
        }
        if (parentX < 0)
        {
            isFlipped = true;
            Flip();
            return;
        }
    }

    private void Flip()
    {
        float x = originScale.x;
        float y = originScale.y;
        float z = originScale.z;

        if(isFlipped)
        {
            transform.localScale = new Vector3(-x, y, z);
            Debug.Log("FLIPPED");
            return;
        }
        if(!isFlipped)
        {
            transform.localScale = new Vector3(x, y, z);
            Debug.Log("NOT FLIPPED");
            return;
        }
    }

}
