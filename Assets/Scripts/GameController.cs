using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [FormerlySerializedAs("ball")] public GameObject Ball;
    private float maxWidth;
    private float time = 2;
    private GameObject newBall;
    
    
    // Start is called before the first frame update
    void Start()
    {
        var screenPos = new Vector3(Screen.width, 0, 0);
        var moveWidth = Camera.main.ScreenToWorldPoint(screenPos);
        var ballWidth = Ball.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = moveWidth.x - ballWidth;
    }

    private void FixedUpdate()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            time = Random.Range(1.5f, 2.0f);
            var posX = Random.Range(-maxWidth, maxWidth);
            var posY = transform.position.y;
            var pos = new Vector3(posX, posY);
            newBall = Instantiate(Ball, pos, Quaternion.identity);
            Destroy(newBall, 10);
        }
    }
}
