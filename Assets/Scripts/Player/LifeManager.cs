using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
	[SerializeField] private GameObject diyingEffect;
	[SerializeField] private GameObject reStartButton;
    private PlayerController myController;
    private Rigidbody2D myRigid;
	private bool gameEnd = false; //���� ����

	private void Awake() //���۽� ��ũ ����
	{
		gameEnd = false;
		myController = GetComponent<PlayerController>();
		myRigid = GetComponent<Rigidbody2D>();
		GameReady();
	}

	private void OnCollisionEnter2D(Collision2D collision) //�浹�� ��ũ ����
	{
		Stop();
		if (collision.gameObject == GameObject.Find("Food") && !gameEnd) GameClear();
		else if (!gameEnd) GameManager.instance.GameOver();
	}

	private void Stop()
	{
		myController.enabled = false;
		myRigid.gravityScale = 0f;
		myRigid.velocity = Vector2.zero;
		myRigid.angularVelocity = 0f;
	}

	public void GameReady()
	{
		gameObject.SetActive(true);
		gameEnd = false;
		Stop();
		transform.position = Vector2.zero;
		transform.rotation = Quaternion.Euler(0, 0, -40);
	}

	public void GameClear()
	{
		GameManager.instance.GameClear();
		gameEnd = true;
	}

	public void GameOver()
	{
		diyingEffect.SetActive(false);
		diyingEffect.transform.position = transform.position;
		diyingEffect.SetActive(true);
		gameEnd = true;
	}

	public void GameStart() //���� ���� �Լ�
	{
		myController.enabled = true;
	}
}
