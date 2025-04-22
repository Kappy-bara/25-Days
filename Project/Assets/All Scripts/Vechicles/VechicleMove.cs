using UnityEngine;

public class VehicleMove : MonoBehaviour
{
    public Transform[] waypoints; 
    public float speed = 5f;
    public float rotationSpeed = 5f; 
    public float waypointTolerance = 1f;
    public float rotationTolerance = 5f;

    private int currentWaypointIndex = 0; 

    void Update()
    {
        if (waypoints.Length != 0)
        {
            MoveVehicle();
        }
    }

    void MoveVehicle()
    {
        Vector3 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (Quaternion.Angle(transform.rotation, targetRotation) < rotationTolerance)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < waypointTolerance)
        {
            currentWaypointIndex++;
            currentWaypointIndex %= waypoints.Length;
        }
    }
}
