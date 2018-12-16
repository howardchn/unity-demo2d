using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    private float hatY;
    private float maxWidth;
    public GameObject Effect;
    
    // Start is called before the first frame update
    void Start()
    {
        hatY = transform.position.y;
        var screenPos = new Vector3(Screen.width, 0, 0);
        var moveWidth = Camera.main.ScreenToWorldPoint(screenPos).x;
        var hatWidth = GetComponent<Renderer>().bounds.extents.x;
        
        maxWidth = moveWidth - hatWidth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        var rawPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var hatPos = new Vector3(rawPos.x, hatY, 0);
        hatPos.x = Mathf.Clamp(hatPos.x, -maxWidth, maxWidth);
        GetComponent<Rigidbody2D>().MovePosition(hatPos);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var newEffect = Instantiate(Effect, transform.position, Effect.transform.rotation);
        newEffect.transform.parent = transform;
        
        Destroy(other.gameObject);
        Destroy(newEffect, 1f);
    }
}
