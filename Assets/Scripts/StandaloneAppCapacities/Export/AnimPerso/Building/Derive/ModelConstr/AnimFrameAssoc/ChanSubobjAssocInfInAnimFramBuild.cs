using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model;
using Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Model.AnimClipsDesc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StandaloneAppCapacities.Export.AnimPerso.Building.Derive.ModelConstr.AnimFrameAssoc
{
    public class ChannelsSubobjectsAssociationInfosInAnimationFrameBuilder :
        AnimationFramesDataUsedAssociationInfosBuilder<SubobjectsChannelsAssociation, string>
    {
        protected override string GetKey(SubobjectsChannelsAssociation subobjectsChannelsAssociation)
        {
            return subobjectsChannelsAssociation.subobjectsChannelsAssociationIdentifier;
        }
    }
}
