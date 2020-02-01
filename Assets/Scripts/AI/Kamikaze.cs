using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour
{
    Move move;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateMoveDirection()
    {
        move.SetMove(Vector2.left);
    }

    void Attack()
    {

    }

}
