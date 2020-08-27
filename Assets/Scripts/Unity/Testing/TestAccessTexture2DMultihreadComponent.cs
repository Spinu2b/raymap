using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Unity.Testing
{
    public class TestAccessTexture2DMultihreadComponent : MonoBehaviour
    {
        public static void ThreadAccessTexture2DGetPixels(object texture2DObject)
        {
            Texture2D texture = texture2DObject as Texture2D;
            texture.GetPixels();
        }

        public void TestAccessingTexture2DGetPixelsMethodFromDifferentThreads()
        {
            var texture = new Texture2D(2, 2, TextureFormat.ARGB32, false);

            // set the pixel values
            texture.SetPixel(0, 0, new Color(1.0f, 1.0f, 1.0f, 0.5f));
            texture.SetPixel(1, 0, Color.clear);
            texture.SetPixel(0, 1, Color.white);
            texture.SetPixel(1, 1, Color.black);

            // Apply all SetPixel calls
            texture.Apply();

            Thread t = new Thread(ThreadAccessTexture2DGetPixels);
            t.Start(texture);
            t.Join();
        }
    }
}
