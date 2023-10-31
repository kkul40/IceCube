using Cainos.LucidEditor;
using UnityEngine;

namespace Cainos.PixelArtPlatformer_VillageProps
{
    public class Chest : MonoBehaviour
    {
        [FoldoutGroup("Reference")] public Animator animator;

        private bool isOpened;

        [FoldoutGroup("Runtime")]
        [ShowInInspector]
        [DisableInEditMode]
        public bool IsOpened
        {
            get => isOpened;
            set
            {
                isOpened = value;
                animator.SetBool("IsOpened", isOpened);
            }
        }

        [FoldoutGroup("Runtime")]
        [Button("Open")]
        [HorizontalGroup("Runtime/Button")]
        public void Open()
        {
            IsOpened = true;
        }

        [FoldoutGroup("Runtime")]
        [Button("Close")]
        [HorizontalGroup("Runtime/Button")]
        public void Close()
        {
            IsOpened = false;
        }
    }
}