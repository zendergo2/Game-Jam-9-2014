using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;
	public float gravity;
	private Vector2 currSpeed;
	private Vector2 currGravity;
	private Vector2 currJump;
	private bool canJump;

	// FixedUpdate is called once per physics frame
	void Update ()
	{
		currSpeed = Input.GetAxis ("Horizontal") * Vector2.right * moveSpeed * Time.deltaTime;
		currGravity = -Vector2.up * gravity * Time.deltaTime;
		currJump = Input.GetAxis ("Vertical") * Vector2.up * jumpHeight;

		if (noCollideXRight() && currSpeed.x >= 0)
			transform.Translate (currSpeed);
		else if (noCollideXLeft() && currSpeed.x <= 0)
			transform.Translate (currSpeed);

		if (noCollideYUp() && currJump.y > 0 && canJump)
			jump(currJump);
		else if (noCollideYDown())
			transform.Translate (currGravity);
	}

	bool noCollideXRight()
	{
		Vector2 originTop = new Vector2(transform.position.x + 0.51f, transform.position.y + 0.51f);
		Vector2 originBottom = new Vector2(transform.position.x + 0.51f, transform.position.y - 0.51f);
		RaycastHit2D hitTop = Physics2D.Raycast(originTop, Vector2.right, 0.01f);
		RaycastHit2D hitBottom = Physics2D.Raycast(originBottom, Vector2.right, 0.01f);

		if (hitBottom.collider == null && hitTop.collider == null)
			return true;
		else if (hitBottom.collider.tag == "Moveable" || hitTop.collider.tag == "Moveable")
			return true;
		else
			return false;
	}

	bool noCollideXLeft()
	{
		Vector2 originTop = new Vector2(transform.position.x - 0.51f, transform.position.y + 0.51f);
		Vector2 originBottom = new Vector2(transform.position.x - 0.51f, transform.position.y - 0.51f);
		RaycastHit2D hitTop = Physics2D.Raycast(originTop, -Vector2.right, 0.01f);
		RaycastHit2D hitBottom = Physics2D.Raycast(originBottom, -Vector2.right, 0.01f);
		
		if (hitBottom.collider == null && hitTop.collider == null)
			return true;
		else if (hitBottom.collider.tag == "Moveable" || hitTop.collider.tag == "Moveable")
			return true;
		else
      		return false;
  	}

	bool noCollideYDown()
	{
		Vector2 originRight = new Vector2(transform.position.x + 0.51f, transform.position.y - .501f);
		Vector2 originLeft = new Vector2(transform.position.x - 0.51f, transform.position.y - .501f);
		RaycastHit2D hitRight = Physics2D.Raycast(originRight, -Vector2.up, 0.1f);
		RaycastHit2D hitLeft = Physics2D.Raycast(originLeft, -Vector2.up, 0.1f);

		if (hitRight.collider == null && hitLeft.collider == null)
			return true;
		else
		{
			canJump = true;
			return false;
		}
	}

	bool noCollideYUp()
	{
		Vector2 originRight = new Vector2(transform.position.x + 0.51f, transform.position.y + .51f);
		Vector2 originLeft = new Vector2(transform.position.x - 0.51f, transform.position.y + .51f);
		RaycastHit2D hitRight = Physics2D.Raycast(originRight, Vector2.up, 0.1f);
		RaycastHit2D hitLeft = Physics2D.Raycast(originLeft, Vector2.up, 0.1f);
		
		if (hitRight.collider == null && hitLeft.collider == null)
			return true;
		else
			return false;
	}

	void jump(Vector2 currJump)
	{
		transform.Translate (currJump);
		canJump = false;
	}
}
