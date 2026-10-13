using UnityEngine;

public class MovePlayer: InputManager
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float speed = 5f;
    void FixedUpdate()
    {
        this.Move();
    }
    protected void Move()
    {
        if(AInput())
        {
            Player.transform.position += speed * Time.fixedDeltaTime * Vector3.left;
            Player.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (DInput())
        {
            Player.transform.position +=  speed * Time.fixedDeltaTime * Vector3.right;
            Player.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (SInput())
        {
            Player.transform.position += speed * Time.fixedDeltaTime * Vector3.down;
            Player.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (WInput())
        {
            Player.transform.position += speed * Time.fixedDeltaTime * Vector3.up;
            Player.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
