using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class BackgroundFunction : MonoBehaviour
{

    public static BackgroundFunction instance;

    public Layer Background = new Layer();
    public Layer Cinematic = new Layer();
    public Layer Foreground = new Layer();

    void Awake()
    {
        instance = this;
    }


    [System.Serializable]
    public class Layer
    {
        public GameObject root;
        public GameObject newImageObjectReference;
        public RawImage activeImage;

        public List<RawImage> allImage = new List<RawImage>();

        public void SetTexture(Texture texture)
        {

            if (texture != null)
            {
                if (activeImage == null)
                    CreateNewActiveImage();

                activeImage.texture = texture;
                activeImage.color = DLGlobalFunction.SetAlpha(activeImage.color, 1f);

            }

            else
            {
                if (activeImage != null)
                {
                    allImage.Remove(activeImage);
                    GameObject.DestroyImmediate(activeImage.gameObject);
                    activeImage = null;
                }
            }

        }

        public void TransitionToTexture(Texture texture, float speed = 2f, bool smooth = false)
        {
            if (activeImage != null && activeImage.texture == texture)
				return;

			StopTransition();
			textureTransition = BackgroundFunction.instance.StartCoroutine(TextureTransition(texture, speed, smooth));
        }

        void StopTransition()
        {
            if(isTextureTransition)
				BackgroundFunction.instance.StopCoroutine(textureTransition);

			textureTransition = null;
        }

        /// <summary>
        /// proses transisi memunculkan gambar
        /// </summary>
        public bool isTextureTransition {get{return textureTransition != null;}}
		Coroutine textureTransition = null;
        IEnumerator TextureTransition(Texture texture, float speed = 2f, bool smooth = false)
        {
            if (texture != null)
            {
                for (int i = 0; i < allImage.Count; i++)
                {
                    RawImage image = allImage[i];
                    if (image.texture == texture)
                    {
                        activeImage = image;
                        break;
                    }
                }

                if (activeImage == null || activeImage.texture != texture)
                {
                    CreateNewActiveImage();
                    activeImage.texture = texture;
                    activeImage.color = DLGlobalFunction.SetAlpha(activeImage.color, 0f);
                }
            }
            else
                activeImage = null;

            while (DLGlobalFunction.TransitionRawImages(ref activeImage, ref allImage, speed, smooth))
                yield return new WaitForEndOfFrame();

            StopTransition();
        }

        void CreateNewActiveImage()
        {
            GameObject ob = Instantiate(newImageObjectReference, root.transform) as GameObject;
            ob.SetActive(true);

            RawImage raw = ob.GetComponent<RawImage>();
            activeImage = raw;
            allImage.Add(raw);
        }
    }
}