using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour {
	[SerializeField]
	private TMP_InputField _weightInputField;

	[SerializeField]
	private TMP_InputField _priceInputField;

	public float weight => GetFloatFromInputField(_weightInputField);

	public float price => GetFloatFromInputField(_priceInputField);

	public float unitPrice => price / weight;
	private TextMeshProUGUI itemText;

	private void Awake() {
		itemText = GetComponent<TextMeshProUGUI>();
	}

	public float GetFloatFromInputField(TMP_InputField inputField) {
		string inputValue = inputField.text;
		float floatValue;

		if (float.TryParse(inputValue, out floatValue))
			return floatValue;
		else
			return 0.0f;
	}

	public void UpdateName() {
		int index = transform.GetSiblingIndex();
		index++;
		itemText.text = "Item " + index;
	}
}