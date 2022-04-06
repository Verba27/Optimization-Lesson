using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public bool spreadShot = false;

	[Header("General")]
	public Transform gunBarrel;
	public ParticleSystem shotVFX;
	public AudioSource shotAudio;
	public float fireRate = .1f;
	public int spreadAmount = 1;

	[Header("Bullets")]
	public GameObject bulletPrefab;

	float timer;

	private GameObject[] bulletPool;
	[SerializeField] private GameObject bulletParanet;
	private int pooledAmount = 1000;

	void Start()
	{
		bulletPool = new GameObject[pooledAmount];
		for (int i = 0; i < pooledAmount; i++)
		{
			GameObject createdObj = (GameObject)Instantiate(bulletPrefab);
			createdObj.transform.SetParent(bulletParanet.transform);
			createdObj.SetActive(false);
			bulletPool[i] = createdObj;
		}
		
	}

	void Update()
	{
		timer += Time.deltaTime;

		if (Input.GetButton("Fire1") && timer >= fireRate)
		{
			
			Vector3 rotation = gunBarrel.rotation.eulerAngles;
			rotation.x = 0f;

			if (spreadShot)
				SpawnBulletSpread(rotation);
			else
				SpawnBullet(rotation);
			

			timer = 0f;

			if (shotVFX)
				shotVFX.Play();

			if (shotAudio)
				shotAudio.Play();
		}
	}

	void SpawnBullet(Vector3 rotation)
	{
		for (int j = 0; j < bulletPool.Length; j++)
		{
			if (!bulletPool[j].activeInHierarchy)
			{
				bulletPool[j].SetActive(true);
				bulletPool[j].transform.position = gunBarrel.position;
				bulletPool[j].transform.rotation = Quaternion.Euler(rotation);
				break;
			}
		}

	}

	void SpawnBulletSpread(Vector3 rotation)
	{
		int max = spreadAmount / 2;
		int min = -max;

		Vector3 tempRot = rotation;
		for (int x = min; x < max; x++)
		{
			tempRot.x = (rotation.x + 3 * x) % 360;

			for (int y = min; y < max; y++)
			{
				tempRot.y = (rotation.y + 3 * y) % 360;

				var bullet = Array.Find(bulletPool, j => !j.activeInHierarchy);
				bullet.SetActive(true);
						
				bullet.transform.position = gunBarrel.position;
				bullet.transform.rotation = Quaternion.Euler(tempRot);

				
			}
		}
	}

}

