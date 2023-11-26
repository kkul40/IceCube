using Cainos.LucidEditor;
using UnityEngine;

namespace Cainos.PixelArtPlatformer_VillageProps
{
    public class Chest : MonoBehaviour, IInteractable
    {
        [FoldoutGroup("Reference")] public Animator animator;

        public GameObject finishScreen;
        public AudioClip chestSound;

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

        public void Collect()
        {
            Open();
            //GameObject.FindObjectOfType<UiManager>().OpenFinishSeason();
            MusicManager.instance.PlayAudio(chestSound);
            
            InvokeRepeating("Play", 5, 1);

            
        }
        public void Play()
        {
            finishScreen.SetActive(true);
            Time.timeScale = 0.0f;
        }

        
    }
}