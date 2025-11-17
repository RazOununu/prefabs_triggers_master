using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This component moves its object when the player clicks the arrow keys.
 */
public class InputMover : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 10f;

    [SerializeField]
    InputAction move = new InputAction(
        type: InputActionType.Value, expectedControlType: nameof(Vector2));

    //1.
    private SpriteRenderer s;
    private Color originalColor;

    void OnEnable()
    {
        move.Enable();
    }

    void OnDisable()
    {
        move.Disable();
    }

    void Start()
    {
        //2.
        s = GetComponent<SpriteRenderer>();
        originalColor = s.color;
    }


    void Update()
    {
        Vector2 moveDirection = move.ReadValue<Vector2>();
        //3.
        //color = component, Color = class
        if (moveDirection.x > 0)
            s.color = Color.red;
        else if (moveDirection.x < 0)
            s.color = Color.green;
        else
            s.color = originalColor;

        Vector3 movementVector = new Vector3(moveDirection.x, moveDirection.y, 0) * speed * Time.deltaTime;
        transform.position += movementVector;
        //transform.Translate(movementVector);
        // NOTE: "Translate(movementVector)" uses relative coordinates - 
        //       it moves the object in the coordinate system of the object itself.
        // In contrast, "transform.position += movementVector" would use absolute coordinates -
        //       it moves the object in the coordinate system of the world.
        // It makes a difference only if the object is rotated.
    }
}
