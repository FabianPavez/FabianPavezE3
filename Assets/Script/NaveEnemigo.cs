using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveEnemigo : MonoBehaviour 
{

	[SerializeField]
	GameObject balablanca;


	float fireRate;
	float nextFire;
	void Start () 
	{
		ObjectPooling.PreLoad(balablanca, 20);
		fireRate = 1f;
		nextFire = Time.time;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameObject.FindWithTag("Player") == true)
		{
			CheckIfTimeToFire();
		}
		
	}
	
	void CheckIfTimeToFire()
	{
		if (Time.time > nextFire) 
		
		{
			
			nextFire = Time.time + fireRate;
			Vector2 vector = Salida();

			GameObject c = ObjectPooling.GetObject(balablanca);
			c.transform.position = vector;
			StartCoroutine(DeSpawn(balablanca, c, 4.0f));
		}
		
	}
	IEnumerator DeSpawn(GameObject primitive, GameObject go, float time)
	{

		yield return new WaitForSeconds(time);
		ObjectPooling.RecicleObject(primitive, go);

	}
	Vector2 Salida()
	{
		Vector2 vector = new Vector2(transform.position.x, transform.position.y);

		return vector;
	}
}
