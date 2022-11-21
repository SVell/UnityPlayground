using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace SVell.PopupUI 
{
	public class Popup : MonoBehaviour
	{
		[SerializeField] private UnityEvent onOpen;
		[SerializeField] private UnityEvent onClose;

		private BaseScene parentScene;
		
		private Animator animator;
		
		public BaseScene ParentScene { get; set; }

		/// <summary>
		/// Unity's Awake method.
		/// </summary>
		protected virtual void Awake()
		{
			animator = GetComponent<Animator>();
		}

		/// <summary>
		/// Unity's Start method.
		/// </summary>
		protected virtual void Start()
		{
			onOpen.Invoke();
		}

		/// <summary>
		/// Closes the popup.
		/// </summary>
		public virtual void Close()
		{
			onClose.Invoke();
			if (parentScene != null)
			{
				parentScene.ClosePopup();
			}
			if (animator != null)
			{
				animator.Play("Close");
				StartCoroutine(DestroyPopup());
			}
			else
			{
				Destroy(gameObject);
			}
		}

		/// <summary>
		/// Utility coroutine to automatically destroy the popup after its closing animation has finished.
		/// </summary>
		/// <returns>The coroutine.</returns>
		protected virtual IEnumerator DestroyPopup()
		{
			yield return new WaitForSeconds(0.5f);
			Destroy(gameObject);
		}
	}
}
