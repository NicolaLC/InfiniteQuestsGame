using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
  Rigidbody2D rigidbody;

  [SerializeField]
  Vector2 movementSpeed = new Vector2(5, 0);

  [SerializeField]
  Vector2 runningSpeed = new Vector2(7, 0);


  private bool isFlip = false;
  private bool isRunning = false;


  // Start is called before the first frame update
  void Start()
  {
    rigidbody = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
    {
      isRunning = Input.GetKey(KeyCode.LeftShift);
      if (Input.GetKey(KeyCode.D))
      {
        // move right
        rigidbody.MovePosition(rigidbody.position + new Vector2(isRunning ? runningSpeed.x : movementSpeed.x, 0) * Time.deltaTime);
        CheckFlip(false);
      }
      if (Input.GetKey(KeyCode.A))
      {
        // move left
        rigidbody.MovePosition(rigidbody.position - new Vector2(isRunning ? runningSpeed.x : movementSpeed.x, 0) * Time.deltaTime);
        CheckFlip(true);
      }
    }

  }

  private void CheckFlip(bool isLeft)
  {
    if (isLeft && !isFlip)
    {
      isFlip = true;
      Vector3 newScale = transform.localScale;
      newScale.x *= -1;
      transform.localScale = newScale;
    }
    else if (!isLeft && isFlip)
    {
      isFlip = false;
      Vector3 newScale = transform.localScale;
      newScale.x *= -1;
      transform.localScale = newScale;
    }
  }
}
