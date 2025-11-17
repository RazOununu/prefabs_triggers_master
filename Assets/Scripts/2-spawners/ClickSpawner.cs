using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This component spawns the given object whenever the player clicks a given key.
 */
public class ClickSpawner : MonoBehaviour
{
    [SerializeField] protected InputAction spawnAction = new InputAction(type: InputActionType.Button);
    [SerializeField] protected GameObject prefabToSpawn;
    [SerializeField] protected Vector3 velocityOfSpawnedObject;

    //1. for Update()
    [SerializeField] private float fireBreak = 0.2f; //5 in 1s
    private float nextValidTime = 0f;

    void OnEnable()
    {
        spawnAction.Enable();
    }

    void OnDisable()
    {
        spawnAction.Disable();
    }

    protected virtual GameObject spawnObject()
    {
        Debug.Log("Spawning a new " + prefabToSpawn.name);

        // Step 1: spawn the new object.
        Vector3 positionOfSpawnedObject = transform.position;  // span at the containing object position.
        Quaternion rotationOfSpawnedObject = Quaternion.identity;  // no rotation.
        GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);

        // Step 2: modify the velocity of the new object.
        Mover newObjectMover = newObject.GetComponent<Mover>();
        if (newObjectMover)
        {
            newObjectMover.SetVelocity(velocityOfSpawnedObject);
        }

        return newObject;
    }

    //Update()--> every frame
    private void Update()
    {
        //if (spawnAction.WasPressedThisFrame()) {
        //2. IsPressed + validTime
        if (spawnAction.IsPressed() && Time.time >= nextValidTime)
        {
            spawnObject();
            nextValidTime = Time.time + fireBreak; //3. update valid time
        }
    }
}
