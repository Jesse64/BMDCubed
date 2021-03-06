﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using grendgine_collada;
using OpenTK;

namespace BMDCubed.src.BMD.Skinning
{
    class SkinningManager
    {
        public DrawData Drw1Data;
        public SkeletonData SkelData;

        public SkinningManager(Grendgine_Collada scene)
        {
            Grendgine_Collada_Skin skinning = GetSkinningInfo(scene);

            SkelData = new SkeletonData(scene, skinning);

            if (skinning != null)
            {
                Drw1Data = new DrawData(skinning, SkelData.FlatHierarchy, SkelData.BonesWithGeometry);
            }
        }

        private Grendgine_Collada_Skin GetSkinningInfo(Grendgine_Collada scene)
        {
            if (scene.Library_Controllers == null)
                return null;

            if (scene.Library_Controllers.Controller == null)
                return null;

            Grendgine_Collada_Skin skinning = null;

            foreach (Grendgine_Collada_Controller con in scene.Library_Controllers.Controller)
            {
                if (con.Skin != null)
                    skinning = con.Skin;
            }

            return skinning;
        }
    }
}
