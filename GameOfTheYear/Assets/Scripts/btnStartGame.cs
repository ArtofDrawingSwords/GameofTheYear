using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace FMG
{
	public class btnStartGame : MonoBehaviour, IPointerClickHandler {
		
		public virtual void OnPointerClick(PointerEventData eventData)
		{
			Debug.Log ("Starting Game..." );
			Application.LoadLevel("Scene1");
		}
	}
}
