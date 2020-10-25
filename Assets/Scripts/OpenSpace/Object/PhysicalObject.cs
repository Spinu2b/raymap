﻿using Newtonsoft.Json;
using OpenSpace.Collide;
using OpenSpace.Visual;
using OpenSpace.Visual.Deform;
using OpenSpace.Visual.ISI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace OpenSpace.Object {
    public class PhysicalObject : IEquatable<PhysicalObject>, IEngineObject {
        public Pointer offset;
        public Pointer off_visualSet;
        public Pointer off_collideSet;
        public Pointer off_visualBoundingVolume;
        public Pointer off_collideBoundingVolume;
        public VisualSetLOD[] visualSet;
        public ushort visualSetType = 0;
        public GeometricObjectCollide collideMesh;
        public Vector3? scaleMultiplier = null;
        private GameObject gao = null;
        public GameObject Gao {
            get {
                if (gao == null) InitGameObject();
                return gao;
            }
        }

        private bool initGameObjectCompliantLogicRunIndicatorFlag = false;

        public void RunWholeProperInitializationProcessForAnimationExportPurposesWithMockedUnityApiInvocations()
        {
            if (!initGameObjectCompliantLogicRunIndicatorFlag)
            {
                InitGameObjectCompliantLogicWithoutUnityApiUsageForAnimationExportPurposes();
            }            
        }

        public DeformSet Bones {
            get {
                for (int i = 0; i < visualSet.Length; i++) {
                    if (visualSet[i].obj != null && visualSet[i].obj is GeometricObject && ((GeometricObject)visualSet[i].obj).bones != null) {
                        return ((GeometricObject)visualSet[i].obj).bones;
                    }
                }
                return null;
            }
		}

        private void InitGameObject()
        {
            ActualInitGameObject(mockUnityApi: false);
        }

        private void InitGameObjectCompliantLogicWithoutUnityApiUsageForAnimationExportPurposes()
        {
            ActualInitGameObject(mockUnityApi: true);
            initGameObjectCompliantLogicRunIndicatorFlag = true;
        }

        private void ActualInitGameObject(bool mockUnityApi) {
            if (!mockUnityApi)
            {
                gao = new GameObject("[PO]");
            }            
            for (int i = 0; i < visualSet.Length; i++) {
                if (visualSet[i].obj == null) continue;

                switch (visualSet[i].obj) {
                    case GeometricObject m:
                        if (m.name != "Mesh")
                        {
                            if (!mockUnityApi)
                            {
                                Gao.name = "[PO] " + m.name;
                            }                            
                        }
                        break;
                    case PatchGeometricObject mod:
                        if (mod.mesh != null && mod.mesh.name != "Mesh") {
                            if (!mockUnityApi)
                            {
                                Gao.name = "[PO] " + mod.mesh.name;
                            }                            
                        }
                        if (!mockUnityApi)
                        {
                            Gao.name += " - Patch";
                        }                        
                        break;
                }
                // Initialize children
                if (!mockUnityApi)
                {
                    if (visualSet[i].obj.Gao != null)
                    {
                        visualSet[i].obj.Gao.transform.parent = Gao.transform;
                    }
                } else
                {
                    visualSet[i].obj.RunWholeProperInitializationProcessForAnimationExportPurposesWithMockedUnityApiInvocations();
                }                
            }

            if (!mockUnityApi)
            {
                if (visualSet.Length > 1)
                { // = number of LOD
                    LODComponent lod = Gao.AddComponent<LODComponent>();
                    lod.visualSet = visualSet;
                    lod.gameObjects = visualSet.Select(v => v.obj.Gao).ToArray();
                    /*float bestLOD = po.visualSet.Min(v => v.LODdistance);
                    foreach (VisualSetLOD lod in po.visualSet) {
                        if (lod.obj.Gao != null && lod.LODdistance != bestLOD) lod.obj.Gao.SetActive(false);
                    }*/
                }
                if (collideMesh != null && collideMesh.Gao != null)
                {
                    collideMesh.Gao.transform.parent = Gao.transform;
                }
            }            
        }

        private SuperObject superObject;
		public SuperObject SuperObject {
			get { return superObject; }
		}

		public PhysicalObject(Pointer offset, SuperObject so = null) {
            this.offset = offset;
			this.superObject = so;
            visualSet = new VisualSetLOD[0];
        }
        public override bool Equals(System.Object obj) {
            return obj is PhysicalObject && this == (PhysicalObject)obj;
        }
        public override int GetHashCode() {
            return offset.GetHashCode();
        }

        public bool Equals(PhysicalObject other) {
            return this == (PhysicalObject)other;
        }

        public static bool operator ==(PhysicalObject x, PhysicalObject y) {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            return x.offset == y.offset;
        }
        public static bool operator !=(PhysicalObject x, PhysicalObject y) {
            return !(x == y);
        }

        public static PhysicalObject Read(Reader reader, Pointer offset, SuperObject so = null, Radiosity radiosity = null) {
            PhysicalObject po = new PhysicalObject(offset, so);
			//MapLoader.Loader.print("PO @ " + offset);
			// Header
			po.off_visualSet = Pointer.Read(reader);
            po.off_collideSet = Pointer.Read(reader);
            po.off_visualBoundingVolume = Pointer.Read(reader);
            if (Settings.s.engineVersion > Settings.EngineVersion.TT && Settings.s.game != Settings.Game.LargoWinch) {
                if (Settings.s.engineVersion < Settings.EngineVersion.R3) {
                    po.off_collideBoundingVolume = po.off_visualBoundingVolume;
                    reader.ReadUInt32();
                } else {
                    po.off_collideBoundingVolume = Pointer.Read(reader);
                }
            }

            // Parse visual set
            Pointer.DoAt(ref reader, po.off_visualSet, () => {
                ushort numberOfLOD = 1;
                po.visualSetType = 0;
				if (Settings.s.game == Settings.Game.LargoWinch) {
					po.visualSet = new VisualSetLOD[1];
					po.visualSet[0] = new VisualSetLOD();
					po.visualSet[0].obj = null;
					po.visualSet[0].off_data = po.off_visualSet;
					po.visualSet[0].LODdistance = 5f;
				} else if (Settings.s.game == Settings.Game.R2Revolution) {
					po.visualSet = new VisualSetLOD[1];
					po.visualSet[0] = new VisualSetLOD();
					po.visualSet[0].obj = MapLoader.Loader.meshObjects.FirstOrDefault(p => p.offset == po.off_visualSet);
					po.visualSet[0].off_data = po.off_visualSet;
					po.visualSet[0].LODdistance = 5f;
				} else {
					if (Settings.s.platform != Settings.Platform.DC) {
						reader.ReadUInt32(); // 0
						numberOfLOD = reader.ReadUInt16();
						//if (numberOfLOD > 1) MapLoader.Loader.print("Found a PO with " + numberOfLOD + " levels of detail @ " + offset);
						po.visualSetType = reader.ReadUInt16();
						if (numberOfLOD > 0) {
							Pointer off_LODDistances = Pointer.Read(reader);
							Pointer off_LODDataOffsets = Pointer.Read(reader);
							reader.ReadUInt32(); // always 0? RLI table offset
							if (Settings.s.engineVersion > Settings.EngineVersion.Montreal) reader.ReadUInt32(); // always 0? number of RLI
							po.visualSet = new VisualSetLOD[numberOfLOD];
							for (uint i = 0; i < numberOfLOD; i++) {
								po.visualSet[i] = new VisualSetLOD();
							}
							Pointer.DoAt(ref reader, off_LODDistances, () => {
								for (uint i = 0; i < numberOfLOD; i++) {
									// if distance > the float at this offset, game engine uses next LOD if there is one
									po.visualSet[i].LODdistance = reader.ReadSingle();
								}
							});
							Pointer.DoAt(ref reader, off_LODDataOffsets, () => {
								for (uint i = 0; i < numberOfLOD; i++) {
									po.visualSet[i].off_data = Pointer.Read(reader);
								}
							});
						}
					} else {
						// Platform = Dreamcast
						Pointer.Read(reader); // Material pointer?
						Pointer off_data = Pointer.Read(reader);
						reader.ReadUInt32(); // always 0?
						reader.ReadUInt32(); // always 0?
						po.visualSet = new VisualSetLOD[1];
						po.visualSet[0].off_data = off_data;
						po.visualSet[0].LODdistance = 5f;
					}
				}
                int radiosityLODIndex = 0;
                for (uint i = 0; i < numberOfLOD; i++) {
                    Pointer.DoAt(ref reader, po.visualSet[i].off_data, () => {
                        switch (po.visualSetType) {
                            case 0:
                                if(po.visualSet[i].obj == null) po.visualSet[i].obj = GeometricObject.Read(reader, po.visualSet[i].off_data, radiosity: radiosity?.lod?[radiosityLODIndex++]);
                                break;
                            case 1:
								if (po.visualSet[i].obj == null) po.visualSet[i].obj = PatchGeometricObject.Read(reader, po, po.visualSet[i].off_data);
                                break;
                            default:
                                MapLoader.Loader.print("unknown type " + po.visualSetType + " at offset: " + offset);
                                break;
                        }
                    });
                }
            });

            // Parse collide set
            Pointer.DoAt(ref reader, po.off_collideSet, () => {
				if (Settings.s.game == Settings.Game.R2Revolution) {
					// Read collide mesh object here directly
					po.collideMesh = GeometricObjectCollide.Read(reader, po.off_collideSet);
				} else {
					// Read collide set containing collide mesh
					uint u1 = reader.ReadUInt32(); // 0, zdm
					uint u2 = reader.ReadUInt32(); // 0, zdd
					uint u3 = reader.ReadUInt32(); // 0, zde
					Pointer off_zdr = Pointer.Read(reader);
					Pointer.DoAt(ref reader, off_zdr, () => {
						po.collideMesh = GeometricObjectCollide.Read(reader, off_zdr);
					});
				}
            });
            MapLoader.Loader.physicalObjects.Add(po);
            return po;
        }

        // Call after clone
        public void Reset() {
            gao = null;
        }

        public PhysicalObject Clone() {
            return ActualClone(mockUnityApi: false);
        }

        public PhysicalObject CloneWithMockedUnityApi() {
            return ActualClone(mockUnityApi: true);
        }

        private PhysicalObject ActualClone(bool mockUnityApi)
        {
            PhysicalObject po = (PhysicalObject)MemberwiseClone();
            po.visualSet = new VisualSetLOD[visualSet.Length];
            po.Reset();
            for (int i = 0; i < visualSet.Length; i++)
            {
                po.visualSet[i].LODdistance = visualSet[i].LODdistance;
                po.visualSet[i].off_data = visualSet[i].off_data;
                if (mockUnityApi) {
                    po.visualSet[i].obj = visualSet[i].obj.CloneWithMockedUnityApi();
                } else {
                    po.visualSet[i].obj = visualSet[i].obj.Clone();
                }                
            }
            if (collideMesh != null) {
                if (mockUnityApi) {
                    po.collideMesh = collideMesh.CloneWithMockedUnityApi();
                } else {
                    po.collideMesh = collideMesh.Clone();
                }                
            }
            return po;
        }

        public void Destroy() {
			//MapLoader.Loader.physicalObjects.Remove(this);
			if (visualSet != null) visualSet = null;
			if (collideMesh != null) collideMesh = null;
			if (gao != null) GameObject.Destroy(gao);
        }

		public void UpdateViewCollision(bool viewCollision) {
            if (gao == null) return;
			foreach (VisualSetLOD l in visualSet) {
				if (l.obj != null) {
					GameObject gao = l.obj.Gao;
					if (gao != null) gao.SetActive(!viewCollision);
				}
			}
			if (collideMesh != null) collideMesh.SetVisualsActive(viewCollision);
		}
    }
}
