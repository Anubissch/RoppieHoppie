using UnityEngine;

public class Movement : MonoBehaviour

{
    [SerializeField]
    int speed = 10;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float yatay = Input.GetAxis("Horizontal");

        float dikey = Input.GetAxis("Vertical");
        Vector3 hareket = new Vector3(yatay * speed, 0.0f, dikey * speed);
        rb.AddForce(hareket);
    }
}
