using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillsGravity : MonoBehaviour
{

    private float angle;
    private float xGravity;
    private float yGravity;

    [SerializeField] private GameObject level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angle = Mathf.Clamp(Input.acceleration.z * 100, -90, 90);

        xGravity = -angle * (9.8f / 90);
        yGravity = -9.8f + (Mathf.Abs(-angle * (9.8f / 90)));

        Physics2D.gravity = new Vector2(xGravity, yGravity);
    }
}
