using UnityEngine;

//this script to prevent move of spaceship the out from y limits

public class LimitsY : MonoBehaviour{
    [SerializeField] private Collider2D top;
    [SerializeField] private Collider2D bottom;
    private Collider2D playerCollider;

    private void Awake(){
        playerCollider = GetComponent<Collider2D>();
        if(!playerCollider){
            Debug.LogError("LimitsY: no Collider2D on the player");
        }
    }

    private void LateUpdate(){
        if(!playerCollider || !top || !bottom)
            return;
        float halfYOfPlayer = playerCollider.bounds.extents.y;//extents= half, middle of player
        float maxY = top.bounds.min.y- halfYOfPlayer;
        float minY = bottom.bounds.max.y + halfYOfPlayer;

        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, minY, maxY); //minY< position.y< maxY
        transform.position = position;
    }
}
