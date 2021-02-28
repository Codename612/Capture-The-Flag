using UnityEngine;

public class RedZone : MonoBehaviour
{
    [SerializeField]
    public GameObject BlueCharacter;
    [SerializeField]
    public GameObject RedCharacter;

    private BluePlayer BlueCharacterData;
    private RedPlayer RedCharacterData;

    void Awake()
    {
        BlueCharacterData = BlueCharacter.GetComponent<BluePlayer>();
        RedCharacterData = RedCharacter.GetComponent<RedPlayer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Red Character")
        {
            RedCharacterData.zone = "red";
        }
        if (collision.name == "Blue Character")
        {
            BlueCharacterData.zone = "red";
        }
    }
}
