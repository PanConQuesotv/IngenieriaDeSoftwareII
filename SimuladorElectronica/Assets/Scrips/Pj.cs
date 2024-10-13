using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private int contador = 0;
    int[] cubosNecesarios = { 5, 5, 5, 2 }; // Número de cubos necesarios para cada nivel
    private int nivelActual = 0; // Nivel actual según el índice de las escenas
    public Text puntuacion;
    public float moveSpeed = 5f;         // Velocidad de movimiento del jugador
    public float mouseSensitivity = 100f; // Sensibilidad del ratón para la rotación
    public Transform cameraTransform;    // Transform de la cámara
    public Animator animator;            // Referencia al Animator principal del jugador

    // Referencias a los animators de las escenas
    public Animator SceneZeroOne1;
    public Animator SceneZeroOne2;
    public Animator SceneZeroOne3;
    public Animator SceneZeroOne4;

    public Animator SceneZeroTwo1;
    public Animator SceneZeroTwo2;
    public Animator SceneZeroTwo3;
    public Animator SceneZeroTwo4;

    public Animator SceneZeroThree1;
    public Animator SceneZeroThree2;
    public Animator SceneZeroThree3;
    public Animator SceneZeroThree4;

    public Animator SceneZeroFour;

    private float xRotation = 0f;        // Rotación en el eje X (para la cámara)

    // Array para llevar el control de las puertas abiertas
    private bool[] puertasAbiertas;

    // La propiedad CubosNecesarios no es necesaria a menos que quieras accederla desde fuera
    public int[] CubosNecesarios { get => cubosNecesarios; }

    void Start()
    {
        // Inicializar el array de puertas abiertas
        puertasAbiertas = new bool[cubosNecesarios.Length];

        // Bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        contador = 0;
        puntuacion.text = "Puntuacion: " + contador;

        // Obtener el índice de la escena actual como nivel actual
        nivelActual = SceneManager.GetActiveScene().buildIndex;
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        contador++;
        puntuacion.text = "Puntuacion: " + contador;

        // Verificar si se ha alcanzado el número necesario de cubos
        if (contador >= cubosNecesarios[nivelActual])
        {
            cambiarEscena(); // Cambia de escena si se han recogido los cubos necesarios
        }
        else
        {
            // Activar la animación correspondiente según el número de cubos recogidos
            ActivarAnimacion(contador);
        }
    }

    void Update()
    {
        MovePlayer();
        RotatePlayerAndCamera();
    }

    // Movimiento del jugador
    void MovePlayer()
    {
        // Input para el movimiento con las teclas WASD
        float moveX = Input.GetAxis("Horizontal");  // A/D o Izquierda/Derecha
        float moveZ = Input.GetAxis("Vertical");    // W/S o Adelante/Atrás

        // Movimiento en la dirección del jugador
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.position += move * moveSpeed * Time.deltaTime;

        // Calcular la velocidad del movimiento (para la animación)
        float movementSpeed = new Vector3(moveX, 0, moveZ).magnitude;

        // Actualizar el parámetro "Speed" en el Animator
        animator.SetFloat("Speed", movementSpeed);
    }

    // Rotación del jugador y de la cámara
    void RotatePlayerAndCamera()
    {
        // Input del movimiento del ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotación vertical de la cámara (eje X)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitar la rotación vertical a 90 grados

        // Aplicar la rotación a la cámara
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotar el cuerpo del jugador (eje Y)
        transform.Rotate(Vector3.up * mouseX);
    }

    // Método para activar la animación según el nivel y el número de puntos
    void ActivarAnimacion(int puntos)
    {

            switch (nivelActual)
            {
                case 1: // Nivel 1
                    if (puntos == 1 && SceneZeroOne1 != null)
                    {
                        SceneZeroOne1.Play("SceneZeroOneDoor1");
                        Debug.Log("Se activó la animación para la puerta 1 en el Nivel 1");
                    }
                    else if (puntos == 2 && SceneZeroOne2 != null)
                    {
                        SceneZeroOne2.Play("SceneZeroOneDoor2");
                        Debug.Log("Se activó la animación para la puerta 2 en el Nivel 1");
                    }
                    else if (puntos == 3 && SceneZeroOne3 != null)
                    {
                        SceneZeroOne3.Play("SceneZeroOneDoor3");
                        Debug.Log("Se activó la animación para la puerta 3 en el Nivel 1");
                    }
                    else if (puntos == 4 && SceneZeroOne4 != null)
                    {
                        SceneZeroOne4.Play("SceneZeroOneDoor4");
                        Debug.Log("Se activó la animación para la puerta 4 en el Nivel 1");
                    }
                    break;

                case 2: // Nivel 2
                    if (puntos == 1 && SceneZeroTwo1 != null)
                    {
                        SceneZeroTwo1.Play("SceneZeroTwoDoor1");
                        Debug.Log("Se activó la animación para la puerta 1 en el Nivel 2");
                    }
                    else if (puntos == 2 && SceneZeroTwo2 != null)
                    {
                        SceneZeroTwo2.Play("SceneZeroTwoDoor2");
                        Debug.Log("Se activó la animación para la puerta 2 en el Nivel 2");
                    }
                    else if (puntos == 3 && SceneZeroTwo3 != null)
                    {
                        SceneZeroTwo3.Play("SceneZeroTwoDoor3");
                        Debug.Log("Se activó la animación para la puerta 3 en el Nivel 2");
                    }
                    else if (puntos == 4 && SceneZeroTwo4 != null)
                    {
                        SceneZeroTwo4.Play("SceneZeroTwoDoor4");
                        Debug.Log("Se activó la animación para la puerta 4 en el Nivel 2");
                    }
                    break;

                case 3: // Nivel 3
                    if (puntos == 1 && SceneZeroThree1 != null)
                    {
                        SceneZeroThree1.Play("SceneZeroThreeDoor1");
                        Debug.Log("Se activó la animación para la puerta 1 en el Nivel 3");
                    }
                    else if (puntos == 2 && SceneZeroThree2 != null)
                    {
                        SceneZeroThree2.Play("SceneZeroThreeDoor2");
                        Debug.Log("Se activó la animación para la puerta 2 en el Nivel 3");
                    }
                    else if (puntos == 3 && SceneZeroThree3 != null)
                    {
                        SceneZeroThree3.Play("SceneZeroThreeDoor3");
                        Debug.Log("Se activó la animación para la puerta 3 en el Nivel 3");
                    }
                    else if (puntos == 4 && SceneZeroThree4 != null)
                    {
                        SceneZeroThree4.Play("SceneZeroThreeDoor4");
                        Debug.Log("Se activó la animación para la puerta 4 en el Nivel 3");
                    }
                    break;

                case 4: // Nivel 4
                    if (puntos == 1 && SceneZeroFour != null)
                    {
                        SceneZeroFour.Play("SceneZeroFourDoor1");
                        Debug.Log("Se activó la animación para la puerta 1 en el Nivel 4");
                    }
                    break;
            }

        }
    

    // Cambiar de escena cuando se cumplen los requisitos de cubos
    void cambiarEscena()
    {
        // Verifica si no es el último nivel
        if (nivelActual < cubosNecesarios.Length - 1)
        {
            // Cambiar a la siguiente escena (nivel)
            SceneManager.LoadScene(nivelActual + 1);
        }
        else
        {
            Debug.Log("Has completado todos los niveles");
        }
    }
}
