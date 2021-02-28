using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject self;

    [SerializeField]
    private Transform spawn;

    [SerializeField]
    private GameObject BlueCharacter;
    [SerializeField]
    private GameObject RedCharacter;

    public Transform BluePos;
    public Transform RedPos;

    private BluePlayer BlueCharacterData;
    private RedPlayer RedCharacterData;

    void Awake()
    {
        BlueCharacterData = BlueCharacter.GetComponent<BluePlayer>();
        RedCharacterData = RedCharacter.GetComponent<RedPlayer>();
    }

    void LateUpdate()
    {
        if (RedCharacterData.hasFlag == true)
        {
            self.transform.position = RedPos.position;
        }
        if (BlueCharacterData.hasFlag == true)
        {
            self.transform.position = BluePos.position;
        }
        if (RedCharacterData.hasFlag == false && BlueCharacterData.hasFlag == false)
        {
            self.transform.position = spawn.position;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Red Character")
        {
            RedCharacterData.hasFlag = true;
            BlueCharacterData.hasFlag = false;
        }

        if (collision.collider.name == "Blue Character")
        {
            BlueCharacterData.hasFlag = true;
            RedCharacterData.hasFlag = false;
        }
    }
}
