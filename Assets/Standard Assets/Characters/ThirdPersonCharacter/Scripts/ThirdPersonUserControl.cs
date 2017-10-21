using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class ThirdPersonUserControl : MonoBehaviour
{
    private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward = Vector3.forward;             // The current forward direction of the camera
    private Vector3 m_Move;

    public bool isPlayerOne = true;
    public GameObject BALL_PREFAB;
    public float ballForce = 10;
    String str_player = "";
    public float timeBetweenShots = 1f;
    private float lastTimeShot;

    public AudioClip shotSound;

    private void Start()
    {
        // get the transform of the main camera
        if (Camera.main != null)
        {
            m_Cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
            // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
        }
        lastTimeShot = -timeBetweenShots;

        // get the third person character ( this should never be null due to require component )
        m_Character = GetComponent<ThirdPersonCharacter>();
        if (isPlayerOne)
            str_player = "PlayerOne";
        else
            str_player = "PlayerTwo";
    }


    private void Update()
    {

    }


    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        //SHOOTING
        if (CrossPlatformInputManager.GetAxis(str_player + "Shoot") > 0 && isAbleToShoot())
        {
            lastTimeShot = Time.realtimeSinceStartup;
            Vector3 newBallPosition = new Vector3(this.transform.position.x, 1, this.transform.position.z);

            GameObject newBall = Instantiate(BALL_PREFAB, newBallPosition, Quaternion.identity, this.transform);

            Vector3 newBallForce = new Vector3(0, 0, ballForce);
            newBallForce = this.transform.rotation * newBallForce;
            newBall.GetComponent<Rigidbody>().AddRelativeForce(newBallForce, ForceMode.VelocityChange);
        }

        //MOVEMENT
        // read inputs
        float h = CrossPlatformInputManager.GetAxis(str_player + "Horizontal");
        float v = CrossPlatformInputManager.GetAxis(str_player + "Vertical");

        // calculate move direction to pass to character
            // calculate camera relative direction to move:
        m_Move = v*m_CamForward + h*m_Cam.right;
#if !MOBILE_INPUT
		// walk speed multiplier
	    if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 1.5f;
#endif

        // pass all parameters to the character control script
        m_Character.Move(m_Move, false, false);
    }

    bool isAbleToShoot()
    {
        return (Time.realtimeSinceStartup - lastTimeShot >= timeBetweenShots);
    }
}
