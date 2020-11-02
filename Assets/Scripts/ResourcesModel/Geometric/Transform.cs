using Assets.Scripts.ResourcesModel.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ResourcesModel.Geometric
{
    /*
     * This current somewhat-mock implementation of Unity's Transform is not compliant with original Transform class
     * from Unity API! It serves only a purpose as a layer of abstraction to have convenient transform data storing objects to work with,
     * i.e. when exporting Persos using multithreading etc. (normally you cannot access Unity's Transform class from another thread
     * because of internal updating loop)
    */
    public class Transform
    {
        public Vector3 position { get; set; } = new Vector3();
        public Quaternion rotation { get; set; } = new Quaternion();
        public Vector3 lossyScale { get; set; } = new Vector3();

        public Transform GetCopy()
        {
            return (Transform)MemberwiseClone();
        }
    }
}
