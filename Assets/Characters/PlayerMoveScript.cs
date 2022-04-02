using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    // Speed of movement
    public float moveSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 pos = transform.position;
        pos.x += h * moveSpeed * Time.deltaTime;
        pos.y += v * moveSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
