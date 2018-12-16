using UnityEngine;

public class SwanMove : MonoBehaviour
{
    float moveSpeed = 4;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(22, 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > -22)
        {
            transform.Translate(Vector3.right * -moveSpeed * Time.deltaTime);
        }
        else
        {
            Start();
        }
    }
}
