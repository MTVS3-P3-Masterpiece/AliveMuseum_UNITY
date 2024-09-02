using UnityEngine;
public class PathDrawer : MonoBehaviour
{
    public MoveBoatCurve _moveBoatCurve;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3[] waypoints1;
    private Vector3[] waypoints2;

    public Transform targetPoints1;
    public Transform targetPoints2;
    
    void Start()
    {
        _moveBoatCurve = GetComponent<MoveBoatCurve>();
        if (_moveBoatCurve == null)
        {
            Debug.LogError("PathDrawer : _moveBoatCurve is null");
        } 
        waypoints1 = new Vector3[_moveBoatCurve.targetPositions1.Count];
        waypoints2 = new Vector3[_moveBoatCurve.targetPositions2.Count];
        
        for (int i = 0; i < _moveBoatCurve.targetPositions1.Count; i++)
        {
            waypoints1[i] = _moveBoatCurve.targetPositions1[i].position;
        }
        for (int i = 0; i < _moveBoatCurve.targetPositions2.Count; i++)
        {
            waypoints2[i] = _moveBoatCurve.targetPositions2[i].position;
        }
        
    }

    private void OnDrawGizmos()
    {
        if (waypoints1 == null ||waypoints2 == null || waypoints1.Length == 0|| waypoints2.Length == 0)
            return;

        // Set Gizmo color
        Gizmos.color = Color.red;

        // Draw the path
        Vector3 previousPoint = waypoints1[0];
        for (float t = 0; t < 1; t += 0.05f)
        {
            Vector3 currentPoint = Mathf.Pow(1 - t, 3) * Vector3.zero +
                                   3 * Mathf.Pow(1 - t, 2) * t * waypoints1[0] +
                                   3 * (1 - t) * Mathf.Pow(t, 2) * waypoints1[1] +
                                   Mathf.Pow(t, 3) * waypoints1[2];
            Gizmos.DrawLine(previousPoint, currentPoint);
            previousPoint = currentPoint;
        }
        for (float t = 0; t < 1; t += 0.05f)
        {
            Vector3 currentPoint = Mathf.Pow(1 - t, 3) * targetPoints1.position +
                                   3 * Mathf.Pow(1 - t, 2) * t * waypoints2[0] +
                                   3 * (1 - t) * Mathf.Pow(t, 2) * waypoints2[1] +
                                   Mathf.Pow(t, 3) * waypoints2[2];
            Gizmos.DrawLine(previousPoint, currentPoint);
            previousPoint = currentPoint;
        }
    }
}
