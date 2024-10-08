using UnityEngine;

public class XObjectConnector : MonoBehaviour
{
    private Collider currentCollider; // Almacena el collider con el que está conectado
    private bool isConnected = false; // Estado de conexión

    private void OnTriggerEnter(Collider other)
    {
        // Comprobar si el collider pertenece a un objeto con tag "Connector"
        if (other.CompareTag("ConnectorPart")) // Cambia el tag a uno que uses para las partes individuales de los colliders
        {
            Debug.Log($"XObject ha colisionado con {other.gameObject.name}");

            // Solo conectar si aún no está conectado
            if (!isConnected)
            {
                ConnectToCollider(other);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Desconectar solo si estamos saliendo del collider al que estamos conectados
        if (other == currentCollider)
        {
            Debug.Log($"XObject ha salido de {other.gameObject.name}");
            DisconnectFromCollider();
        }
    }

    private void ConnectToCollider(Collider collider)
    {
        if (!isConnected)
        {
            Debug.Log($"Conectando a {collider.gameObject.name}");
            // Alinear XObject con el collider
            transform.position = collider.transform.position;

            // Guardar el collider al que se ha conectado
            currentCollider = collider;

            isConnected = true;
        }
    }

    private void DisconnectFromCollider()
    {
        if (isConnected)
        {
            Debug.Log($"Desconectando de {currentCollider.gameObject.name}");
            // Desconectar
            currentCollider = null;
            isConnected = false;
        }
    }
}
