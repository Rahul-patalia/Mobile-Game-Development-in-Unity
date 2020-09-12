using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private PlayerController playerController;

    private int horizontal = 0, vertival = 0;

    public enum Axis
    {
        Horizontal, Vertical
    }

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = 0;
        vertival = 0;

        GetKeyboardInput();
        SetMovement();
    }

    void GetKeyboardInput()
    {


        horizontal = GetAxisRaW(Axis.Horizontal);
        vertival = GetAxisRaW(Axis.Vertical);

        if (horizontal != 0)
        {
            vertival = 0;
        }
    }

    void SetMovement()
    {
        if (vertival != 0)
        {
            playerController.SetInputDirection((vertival == 1) ? PlayerDirection.UP : PlayerDirection.DOWN);
        }
        else if (horizontal != 0)
        {
            playerController.SetInputDirection((horizontal == 1) ? PlayerDirection.RIGHT : PlayerDirection.LEFT);
        }
    }

    int GetAxisRaW(Axis axis)
    {
        if (axis == Axis.Horizontal)
        {
            bool left = Input.GetKeyDown(KeyCode.LeftArrow);
            bool right = Input.GetKeyDown(KeyCode.RightArrow);

            if (left)
            {
                return -1;
            }
            if (right)
            {
                return 1;
            }
            return 0;
        }
        else if (axis == Axis.Vertical)
        {
            bool up = Input.GetKeyDown(KeyCode.UpArrow);
            bool down = Input.GetKeyDown(KeyCode.DownArrow);

            if (up)
            {
                return 1;
            }
            if (down)
            {
                return -1;
            }
            return 0;
        }
        return 0;
    }
}
