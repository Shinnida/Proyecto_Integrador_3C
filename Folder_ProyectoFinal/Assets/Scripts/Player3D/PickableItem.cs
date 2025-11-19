using UnityEngine;

public class PickableItem : MonoBehaviour
{
    public string itemName = "Objeto Genérico";
    // Puedes añadir más datos aquí (icono de inventario, etc.)

    // Esta función será llamada por el script del jugador cuando se recoja el objeto
    public void PickUp()
    {
        Debug.Log("Recogido: " + itemName);
        // Aquí se pueden añadir efectos de sonido, animaciones, etc.
        Destroy(gameObject); // Elimina el objeto de la escena
    }
}
