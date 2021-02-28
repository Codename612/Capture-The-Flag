using UnityEngine;

public class RedPlayer : MonoBehaviour
{
    public GameObject self;
    [SerializeField]
    private float speed = 2.5f;

    public string zone;
    public GameObject spawn;

    private Vector2 direction;

    public bool hasFlag = false;

    [SerializeField]
    public GameObject BlueCharacter;

    public Joystick joystick;

    public GameObject UIHandler;
    private Game UIManager;

    private string ID = "Red Player";

    void Awake()
    {
        UIManager = UIHandler.GetComponent<Game>();
    }

    void Update()
    {
        GetJoystickInput();
        self.transform.Translate(direction * speed * Time.deltaTime);
    }

    private void GetJoystickInput()
    {
        direction = joystick.Direction;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Blue Character")
        {
            if (zone == "blue")
            {
                self.transform.position = spawn.transform.position;
                hasFlag = false;
            }
        }

        if (collision.collider.name == "Red Return" && hasFlag)
        {
            UIManager.winner = ID;
            UIManager.GameOver();
        }
    }
}
