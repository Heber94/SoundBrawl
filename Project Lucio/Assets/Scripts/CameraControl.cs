using UnityEngine;

public class CameraControl : MonoBehaviour
{
	//Time between the camera would start to move and the time the camera actually starts to move (to make it smooth)
    public float m_DampTime = 0.1f;                 
	//Kind of a padding to prevent the tanks to touch the limits of the camera
    public float m_ScreenEdgeBuffer = 2f;           
	//Minimun size of the camera
    public float m_MinSize = 6.5f;                  
	//Number of targets the camera has to cover
    public Transform[] m_Targets; 


    private Camera m_Camera;
	//How fast it zooms
    private float m_ZoomSpeed;                      
	//Desired position: in the middle of all the tanks
    private Vector3 m_DesiredPosition;              


    private void Awake()
    {
        Time.timeScale = 1;
        m_Camera = gameObject.GetComponent<Camera>();
    }

	//So that it moves in the same function that the tanks move
    private void FixedUpdate()
    {
        Move();
        Zoom();
    }


    private void Move()
    {
        FindAveragePosition();
		Vector3 velocity = Vector3.zero;
		Vector3 desiredPos = new Vector3 (m_DesiredPosition.x, m_DesiredPosition.y, transform.position.z);
		//first arg: current position. Second arg: Where do we want to go. Third arg: current velocity. Fourth arg: how much time do we want it to take
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, m_DampTime);
    }


    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        for (int i = 0; i < m_Targets.Length; i++)
        {
			//For instance, if a tank is dead, we do not want it to be taken into consideration
            if (!m_Targets[i].gameObject.activeSelf)
                continue;

            averagePos += m_Targets[i].position;
            numTargets++;
        }

        if (numTargets > 0) {
			averagePos /= numTargets;
		}

		m_DesiredPosition = averagePos;
    }


    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, requiredSize, ref m_ZoomSpeed, m_DampTime);
    }


    private float FindRequiredSize()
    {
		//To get the desired position depending on the rig of the camera
        Vector3 desiredLocalPos = transform.InverseTransformPoint(m_DesiredPosition);

        float size = 0f;

        for (int i = 0; i < m_Targets.Length; i++)
        {
			//For instance, if a target is dead, we do not want it to be taken into consideration
            if (!m_Targets[i].gameObject.activeSelf)
                continue;

            Vector3 targetLocalPos = transform.InverseTransformPoint(m_Targets[i].position);

            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

			//Whether the target is going away by the horizontal or vertical direction, we take the max of both
            size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.y));

            size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.x) / m_Camera.aspect);
        }
        
		//Extra distance so that it makes sure the target is into the zoom
        size += m_ScreenEdgeBuffer;

		//To prevent zooming too much, we have the min size
        size = Mathf.Max(size, m_MinSize);

        return size;
    }

	//Setting the default configuration
    public void SetStartPositionAndSize()
    {
        FindAveragePosition();

        transform.position = m_DesiredPosition;

        m_Camera.orthographicSize = FindRequiredSize();
    }
}