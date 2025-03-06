using UnityEngine;

public class Airplane : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float enginePower = 20f; // thrust force
    [SerializeField] float liftBooster = 0.5f; // lift force
    [SerializeField] float drag = 0.001f; // drag force
    [SerializeField] float angularDrag = 0.001f;

    [SerializeField] float yawPower = 50f;
    [SerializeField] float picthPower = 50f;
    [SerializeField] float rollPower = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void FixedUpdate() // constant update per round 0.02sec
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * enginePower);
        }// end if for moving Airplane forward
        Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBooster);
        rb.linearDamping = rb.linearVelocity.magnitude * drag;
        rb.angularDamping = rb.linearVelocity.magnitude * angularDrag;

        float yaw = Input.GetAxis("Horizontal") * yawPower;
        float pitch = Input.GetAxis("Vertical") * picthPower;
        float roll = Input.GetAxis("Roll") * rollPower;

        rb.AddTorque(transform.up * yaw);
        rb.AddTorque(transform.right * pitch);
        rb.AddTorque(transform.forward * roll);
    }
}// End Airplane
