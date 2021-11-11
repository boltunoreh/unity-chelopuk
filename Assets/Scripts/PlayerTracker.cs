using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    public Transform trackedObject;

    public float updateSpeed = 3;

    public Vector2 trackingOffset;

    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _offset = (Vector3) trackingOffset;
        _offset.z = transform.position.z - trackedObject.position.z;
    }

    private void Update()
    {
        float xDiff = Mathf.Abs(transform.position.x - trackedObject.position.x);
        if (xDiff > 1)
        {
            updateSpeed *= xDiff;
        }
    }

    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, trackedObject.position + _offset,
            updateSpeed * Time.deltaTime);
    }
}
