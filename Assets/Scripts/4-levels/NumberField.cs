using TMPro;
using UnityEngine;

/**
 * This component should be attached to a TextMeshPro object.
 * It allows to feed an integer number to the text field.
 */

//1. Remove- [RequireComponent(typeof(TextMeshPro))] --> for TextMeshPro, not for UI
//2. change from TextMeshPro to TMP_Text
public class NumberField : MonoBehaviour {
    private int number;

    public int GetNumber() {
        return this.number;
    }

    public void SetNumber(int newNumber) {
        this.number = newNumber;
        GetComponent<TMP_Text>().text = newNumber.ToString();
    }

    public void AddNumber(int toAdd) {
        SetNumber(this.number + toAdd);
    }
}
