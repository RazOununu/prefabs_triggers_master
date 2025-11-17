using UnityEngine;

public class MoveX: MonoBehaviour{
    [SerializeField] private Collider2D right;
    [SerializeField] private Collider2D left;

    //Update()--> LateUpdate()
    private void LateUpdate(){
        Vector3 position = transform.position; //after move
        //from right to left
        if(position.x > right.bounds.max.x)
            position.x = left.bounds.min.x;
        //from left to right    
        if(position.x < left.bounds.min.x)   
            position.x = right.bounds.max.x; 

        transform.position = position;    
    }

    
}
