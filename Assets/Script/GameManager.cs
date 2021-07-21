using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

    public class GameManager : MonoBehaviour
    {
        public GameObject[] hearts;
        public static int vida = 3;
        public AudioSource musica;
        public GameObject instanciarPj;
        public static GameManager instancia;
        public GameState estado;
        public static event Action<GameState> GameStateCambiado;
        
    public static GameManager Instancia

    {
        get
        {
            return instancia;
        }
    }
    public enum GameState
    {
        Wait, Gameplay, GameOver, RoundOver
    }
    public void Update()
        {
        
        if (vida < 1)
            {
                Destroy(hearts[0].gameObject);
                CambiarGameState(GameState.GameOver);

            }
            else if (vida < 2)
            {
            Destroy(hearts[1].gameObject);
            Destroy(hearts[2].gameObject);


            }
            else if (vida < 3)
            {
                Destroy(hearts[2].gameObject);

            }

    }
        public void Start()
        {
        CambiarGameState(GameState.Gameplay);
            musica = GetComponent<AudioSource>();
        
        }
        public void CambiarGameState(GameState nuevoEstado)
        {
            estado = nuevoEstado;
            switch (nuevoEstado)
            {
                case GameState.Wait:
                    Debug.Log("Wait");
                    StartCoroutine(Inicio());
                    break;
                case GameState.Gameplay:
                    Debug.Log("Gameplay");
                    break;
                case GameState.GameOver:
                    Debug.Log("GameOver");  
                    break;
                case GameState.RoundOver:
                    Debug.Log("RoundOver"); 
                    break;
                    throw new ArgumentOutOfRangeException(nameof(nuevoEstado), nuevoEstado, null);
            }
            GameStateCambiado?.Invoke(nuevoEstado);

        }
        IEnumerator Inicio()
        {
            yield return new WaitForSeconds(1);
            CambiarGameState(GameState.Gameplay);
        }
    public static void Daño(int d)
    {
        vida -= d;
    }
    IEnumerator spaun()
    {
        yield return new WaitForSeconds(1);
        GameObject.FindWithTag("Player").SetActive(true);
    }
   

    
        
        private void Awake()
        {
            instancia = this;
            SpawnPersonaje();

        }
        void SpawnPersonaje()
        {
            Instantiate(instanciarPj);
        }
    
    

    }



