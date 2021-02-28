using UnityEngine;

public class BluePlayer : MonoBehaviour
{
    public GameObject self;
    [SerializeField]
    private float speed;

    public string zone;
    public GameObject spawn;

    private Vector2 direction;

    public bool hasFlag = false;

    public GameObject RedCharacter;

    public Joystick joystick;

    public GameObject UIHandler;
    private Game UIManager;

    private string ID = "Blue Player";

    void Awake()
    {
        UIManager = UIHandler.GetComponent<Game>();
    }

    void Update() {
        GetJoystickInput();
        self.transform.Translate(direction * speed * Time.deltaTime);
    }

    private void GetJoystickInput()
    {
        direction = joystick.Direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Red Character")
        {
            if (zone == "red")
            {
                self.transform.position = spawn.transform.position;
                hasFlag = false;
            }
        }

        if (collision.collider.name == "Blue Return" && hasFlag)
        {
            UIManager.winner = ID;
            UIManager.GameOver();
        }
    }
}
