using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Singleton instance
    public static PlayerController Instance { get; private set; }
    public Player player;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        player = new Player();
    }

}
