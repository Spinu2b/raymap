using Assets.Scripts.GenericExport;
using Assets.Scripts.GenericExport.GenericExportBones.Model;
using Assets.Scripts.GenericExport.GenericExportBones.Model.DataBlocks;
using Assets.Scripts.GenericExport.Model;
using Assets.Scripts.GenericExport.Model.DataBlocks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GenericExportBones
{
    public class Perso3DDataBonesExporter
    {
        protected PersoBehaviour persoBehaviour;

        public Perso3DDataBonesExporter(PersoBehaviour persoBehaviour)
        {
            this.persoBehaviour = persoBehaviour;
        }

        public void ExportPersoAnimatedBones3DData()
        {
            persoBehaviour.playAnimation = false;
            persoBehaviour.transform.position = new UnityEngine.Vector3(0, 0, 0);
            persoBehaviour.StartCoroutine(ExportPersoAnimated3DBonesDataCoroutine());
        }

        public IEnumerator ExportPersoAnimated3DBonesDataCoroutine()
        {
            int currentState = 0;

            var result = new Perso3DBonesAnimatedData();

            while (PersoStatesHelper.HasStatesLeft(currentState, persoBehaviour))
            {
                result.states[currentState] = new Dictionary<int, FrameBonesDataBlock>();
                int currentFrame = 0;
                while (PersoStateFramesHelper.HasFramesLeftInCurrentState(persoBehaviour))
                {
                    result.states[currentState][currentFrame] =
                        FrameBonesDataBlock.GetConsolidated(result.states[currentState], currentFrame, persoBehaviour);

                    PersoStateFramesHelper.GoToNextFrame(persoBehaviour);
                    currentFrame++;
                    yield return null;
                }

                currentState = currentState + 1;
                PersoStatesHelper.GoToNextState(persoBehaviour);
                yield return null;
            }


            throw new NotImplementedException();
        }
    }
}
