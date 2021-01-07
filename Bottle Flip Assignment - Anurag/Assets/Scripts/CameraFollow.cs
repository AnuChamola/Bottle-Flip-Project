using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Vector2 offset;
    private Vector2 threshold;
    public float speed;

    [Range(1,10)]
    public float smooth;
    // Start is called before the first frame update
     void Start()
    {
        threshold = CalculateThreshold();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 follow = target.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        
        Vector3 newPos = transform.position;
        if(Mathf.Abs(xDifference) >= threshold.x)
        {
            newPos.x = follow.x;
        }
       
        transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
    }

   private Vector3 CalculateThreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x -= offset.x;
        t.y -= offset.y;
        return t;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Vector2 border = CalculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }
}
