﻿using Newtonsoft.Json;
using OpenSpace.Loader;
using OpenSpace.Object;
using OpenSpace.Visual.Deform;
using OpenSpace.Visual.ISI;
using OpenSpace.Visual.PS2Optimized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace OpenSpace.Visual {
    /// <summary>
    /// Mesh data (both static and dynamic)
    /// </summary>
    public class GeometricObject : IGeometricObject, IEngineObject {
        public Pointer offset;
		
        public Pointer off_vertices;
        public Pointer off_normals;
        public Pointer off_blendWeights;
        public Pointer off_materials;
        public Pointer off_element_types;
        public Pointer off_elements;
        public Pointer off_mapping; // Revolution only
        public uint lookAtMode;
        public ushort num_vertices;
        public ushort num_elements;
		public Pointer off_parallelBoxes;
		public ushort num_parallelBoxes;
		public Vector3 sphereCenter = Vector3.zero;
		public float sphereRadius = 0;

		[JsonIgnore]
        public string name;
        public Vector3[] vertices = null;
        public Vector3[] normals = null;
        public float[][] blendWeights = null;
        public ushort[] element_types = null;
		public int[][] mapping = null;
        public IGeometricObjectElement[] elements = null;
        public DeformSet bones = null;

		public Pointer<PS2OptimizedSDCStructure> optimizedObject;
		public uint ps2IsSinus;
		public RadiosityLOD radiosity;

		public bool morphed = false;
		public Vector3[] MorphedVertices {
			get {
				return vertices;
			}
			set {
				if ((value != null) || morphed) {
					morphed = (value != null);
					Vector3[] morphedVerts = morphed ? value : vertices;
					// Update elements
					for (int k = 0; k < num_elements; k++) {
						if (elements[k] == null || element_types[k] != 1) continue;
						GeometricObjectElementTriangles el = (GeometricObjectElementTriangles)elements[k];
						if (el != null) el.UpdateMeshVertices(morphedVerts);
					}
				}
			}
		}

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

		public SuperObject so;
		public SuperObject SuperObject => so;

		public GeometricObject(Pointer offset) {
            this.offset = offset;
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
				gao = new GameObject(name);
			}           
			/*System.Diagnostics.Stopwatch w = new System.Diagnostics.Stopwatch();
			w.Start();*/

			if (!mockUnityApi)
            {
				gao.tag = "Visual";
				gao.layer = LayerMask.NameToLayer("Visual");
			}            
            if (bones != null) {
				if (!mockUnityApi)
                {
					GameObject child = bones.Gao;
					child.transform.SetParent(gao.transform);
					child.transform.localPosition = Vector3.zero;
				} else
                {
					bones.RunWholeProperInitializationProcessForAnimationExportPurposesWithMockedUnityApiInvocations();
				}                
            }
            for (uint i = 0; i < num_elements; i++) {
                if (elements[i] != null) {
					if (!mockUnityApi)
                    {
						GameObject child = elements[i].Gao;
						child.transform.SetParent(gao.transform);
						child.transform.localPosition = Vector3.zero;
					} else
                    {
						elements[i].RunWholeProperInitializationProcessForAnimationExportPurposesWithMockedUnityApiInvocations();
					}                    
                }
            }
			if (!mockUnityApi)
            {
				if (lookAtMode != 0)
				{
					BillboardBehaviour billboard = gao.AddComponent<BillboardBehaviour>();
					billboard.mode = (BillboardBehaviour.LookAtMode)lookAtMode;
				}
			}            
			/*MapLoader.Loader.print("GEO: " + offset + " - " + w.ElapsedMilliseconds);
			w.Stop();*/
		}

        public void ReinitBindposes() {
            if (bones != null) {
                for (uint i = 0; i < num_elements; i++) {
                    if (elements[i] != null) {
                        if (elements[i] is GeometricObjectElementTriangles) {
                            ((GeometricObjectElementTriangles)elements[i]).ReinitBindPoses();
                        }
                    }
                }
            }
        }

        public static GeometricObject Read(Reader reader, Pointer offset, RadiosityLOD radiosity = null, PatchGeometricObject mod = null) {
            MapLoader l = MapLoader.Loader;
			//l.print("Geometric Object: " + offset);
            GeometricObject m = new GeometricObject(offset);
			m.radiosity = radiosity;
			if (Settings.s.game == Settings.Game.LargoWinch) {
				uint flags = reader.ReadUInt32();
				m.num_vertices = reader.ReadUInt16();
				m.num_elements = reader.ReadUInt16();
				m.off_element_types = Pointer.Read(reader);
				m.off_elements = Pointer.Read(reader);
				m.off_vertices = Pointer.Read(reader);
				m.off_normals = Pointer.Read(reader);
				m.sphereRadius = reader.ReadSingle(); // bounding volume radius
				float sphereX = reader.ReadSingle(); // x
				float sphereZ = reader.ReadSingle(); // z
				float sphereY = reader.ReadSingle(); // y
				m.sphereCenter = new Vector3(sphereX, sphereY, sphereZ);
				m.lookAtMode = reader.ReadUInt32();
			} else if (Settings.s.game == Settings.Game.R2Revolution) {
				m.off_element_types = Pointer.Read(reader);
				m.off_elements = Pointer.Read(reader);
				uint flags = reader.ReadUInt32();
				m.sphereRadius = reader.ReadSingle(); // bounding volume radius
				float sphereX = reader.ReadSingle(); // x
				float sphereZ = reader.ReadSingle(); // z
				float sphereY = reader.ReadSingle(); // y
				m.sphereCenter = new Vector3(sphereX, sphereY, sphereZ);
				m.off_mapping = Pointer.Read(reader);
				m.num_vertices = reader.ReadUInt16();
				m.num_elements = reader.ReadUInt16();
				m.off_vertices = Pointer.Read(reader);
				m.off_normals = Pointer.Read(reader);
				m.lookAtMode = flags & 3;
			} else {
				if (Settings.s.engineVersion <= Settings.EngineVersion.Montreal) m.num_vertices = (ushort)reader.ReadUInt32();
				m.off_vertices = Pointer.Read(reader);
				m.off_normals = Pointer.Read(reader);
				if (Settings.s.engineVersion < Settings.EngineVersion.R3) {
					m.off_materials = Pointer.Read(reader);
				} else {
					m.off_blendWeights = Pointer.Read(reader);
				}
				if (Settings.s.mode != Settings.Mode.RaymanArenaGC 
					&& Settings.s.mode != Settings.Mode.RaymanArenaGCDemo_2002_03_07
					&& Settings.s.game != Settings.Game.RM
					&& Settings.s.mode != Settings.Mode.DonaldDuckPKGC
					&& !(Settings.s.platform == Settings.Platform.PS2 && Settings.s.engineVersion == Settings.EngineVersion.R3)) {
					reader.ReadInt32();
				}
				if (Settings.s.engineVersion <= Settings.EngineVersion.Montreal) m.num_elements = (ushort)reader.ReadUInt32();
				m.off_element_types = Pointer.Read(reader);
				m.off_elements = Pointer.Read(reader);
				if (Settings.s.engineVersion == Settings.EngineVersion.R2) {
					reader.ReadInt32();
					reader.ReadInt32();
				}
				reader.ReadInt32();
				if (Settings.s.engineVersion > Settings.EngineVersion.Montreal) {
					m.off_parallelBoxes = Pointer.Read(reader);
				} else {
					reader.ReadInt32();
				}
				if (Settings.s.game == Settings.Game.Dinosaur) {
					reader.ReadInt32();
					reader.ReadInt32();
					reader.ReadInt32();
				}
				if (Settings.s.engineVersion > Settings.EngineVersion.Montreal) {
					m.lookAtMode = reader.ReadUInt32();
					//if (m.lookAtMode != 0) l.print(m.lookAtMode);
					m.num_vertices = reader.ReadUInt16();
					m.num_elements = reader.ReadUInt16();
					reader.ReadUInt16();
					m.num_parallelBoxes = reader.ReadUInt16();
					m.sphereRadius = reader.ReadSingle(); // bounding volume radius
					float sphereX = reader.ReadSingle(); // x
					float sphereZ = reader.ReadSingle(); // z
					float sphereY = reader.ReadSingle(); // y
					m.sphereCenter = new Vector3(sphereX, sphereY, sphereZ);
					reader.ReadInt32();
					if (Settings.s.engineVersion == Settings.EngineVersion.R3) {
						reader.ReadInt32();
						if (!(Settings.s.platform == Settings.Platform.PS2 && (Settings.s.game == Settings.Game.RM || Settings.s.game == Settings.Game.RA))) {
							reader.ReadInt16();
							if (Settings.s.platform == Settings.Platform.PS2) {
								reader.ReadInt16();
								reader.ReadUInt32();
							}
						}
					}
				} else {
					reader.ReadInt32();
					reader.ReadInt32();
					m.sphereRadius = reader.ReadSingle(); // bounding volume radius
					float sphereX = reader.ReadSingle(); // x
					float sphereZ = reader.ReadSingle(); // z
					float sphereY = reader.ReadSingle(); // y
					m.sphereCenter = new Vector3(sphereX, sphereY, sphereZ);
				}
			}
            m.name = "Mesh @ " + offset;
            if (Settings.s.hasNames) m.name = reader.ReadString(0x32);
			if (Settings.s.platform == Settings.Platform.PS2 && Settings.s.engineVersion >= Settings.EngineVersion.R3) {
				reader.Align(0x4);
				reader.ReadUInt32();
				reader.ReadUInt32();
				m.optimizedObject = new Pointer<PS2OptimizedSDCStructure>(reader, resolve: false);
				reader.ReadUInt32();
				reader.ReadUInt32();
				if (Settings.s.game == Settings.Game.R3) {
					m.ps2IsSinus = reader.ReadUInt32();
				}
			}
            // Vertices
			Pointer.DoAt(ref reader, m.off_vertices, () => {
				m.vertices = new Vector3[m.num_vertices];
				for (int i = 0; i < m.num_vertices; i++) {
					float x = reader.ReadSingle();
					float z = reader.ReadSingle();
					float y = reader.ReadSingle();
					m.vertices[i] = new Vector3(x, y, z);
				}
			});
			if (mod != null) {
				for (int i = 0; i < mod.num_properties; i++) {
					PatchGeometricObjectProperty prop = mod.properties[i];
					if (prop.ind_vertex < m.vertices.Length) {
						m.vertices[prop.ind_vertex] += prop.pos;
					}
				}
			}
			// Normals
			Pointer.DoAt(ref reader, m.off_normals, () => {
				m.normals = new Vector3[m.num_vertices];
				for (int i = 0; i < m.num_vertices; i++) {
					float x = reader.ReadSingle();
					float z = reader.ReadSingle();
					float y = reader.ReadSingle();
					m.normals[i] = new Vector3(x, y, z);
				}
			});
            Pointer.DoAt(ref reader, m.off_blendWeights, () => {
                m.blendWeights = new float[4][];
                /*reader.ReadUInt32(); // 0
                R3Pointer off_blendWeightsStart = R3Pointer.Read(reader);
                R3Pointer.Goto(ref reader, off_blendWeightsStart);*/
                for (int i = 0; i < 4; i++) {
                    Pointer off_blendWeights = Pointer.Read(reader);
                    Pointer.DoAt(ref reader, off_blendWeights, () => {
                        m.blendWeights[i] = new float[m.num_vertices];
                        for (int j = 0; j < m.num_vertices; j++) {
                            m.blendWeights[i][j] = reader.ReadSingle();
                        }
                    });
                }
                reader.ReadUInt32();
                reader.ReadUInt32();
                reader.ReadUInt32();
                reader.ReadUInt32();
            });
			Pointer.DoAt(ref reader, m.off_mapping, () => {
				// Revolution only
				reader.ReadUInt32();
				Pointer.Read(reader);
				Pointer off_mappingBlocks = Pointer.Read(reader);
				Pointer.Read(reader);
				Pointer.Read(reader);
				ushort num_mappingBlocks = reader.ReadUInt16();
				reader.ReadUInt16();
				Pointer.DoAt(ref reader, off_mappingBlocks, () => {
					m.mapping = new int[num_mappingBlocks][];
					for (int i = 0; i < num_mappingBlocks; i++) {
						Pointer off_mapping = Pointer.Read(reader);
						Pointer.DoAt(ref reader, off_mapping, () => {
							m.mapping[i] = new int[m.num_vertices];
							for (int j = 0; j < m.num_vertices; j++) {
								m.mapping[i][j] = reader.ReadUInt16();
								if (m.mapping[i][j] >= m.num_vertices) l.print(m.offset);
							}
						});
					}
				});
			});
            // Read element types & initialize arrays
            Pointer.Goto(ref reader, m.off_element_types);
            m.element_types = new ushort[m.num_elements];
            m.elements = new IGeometricObjectElement[m.num_elements];
            for (uint i = 0; i < m.num_elements; i++) {
                m.element_types[i] = reader.ReadUInt16();
            }
			// Process elements
			for (uint i = 0; i < m.num_elements; i++) {
                Pointer.Goto(ref reader, m.off_elements + (i * 4));
                Pointer block_offset = Pointer.Read(reader);
                Pointer.Goto(ref reader, block_offset);
                switch (m.element_types[i]) {
                    case 1: // Material
                        m.elements[i] = GeometricObjectElementTriangles.Read(reader, block_offset, m);
                        break;
                    case 3: // Sprite
                        m.elements[i] = GeometricObjectElementSprites.Read(reader, block_offset, m);
                        break;
                    case 13:
					case 15:
                        m.bones = DeformSet.Read(reader, block_offset, m);
                        m.elements[i] = m.bones;
                        break;
                    default:
                        m.elements[i] = null;
                        /*1 = indexedtriangles
                        2 = facemap
                        3 = sprite
                        4 = TMesh
                        5 = points
                        6 = lines
                        7 = spheres
                        8 = alignedboxes
                        9 = cones
                        13 = deformationsetinfo*/
                        l.print("Unknown geometric element type " + m.element_types[i] + " at offset " + block_offset);
                        break;
                }
			}
			ReadMeshFromATO(reader, m);
			if (Settings.s.platform == Settings.Platform.PS2 && Settings.s.engineVersion == Settings.EngineVersion.R3) {
				m.optimizedObject?.Resolve(reader, onPreRead: opt => opt.isSinus = m.ps2IsSinus);
				m.ReadMeshFromSDC();
			}
			//m.InitGameObject();
            return m;
        }

		private void ReadMeshFromSDC() {
			if (optimizedObject?.Value == null) return;
			PS2OptimizedSDCStructure sdc = optimizedObject.Value;
			int sdcIndex = 0;
			for (int i = 0; i < num_elements; i++) {
				if (element_types[i] != 1) continue;
				PS2OptimizedSDCStructureElement sdcEl = sdc.elements[sdcIndex];
				GeometricObjectElementTriangles mainEl = elements[i] as GeometricObjectElementTriangles;
				if (mainEl.visualMaterial == null) mainEl.visualMaterial = sdc.visualMaterials[sdcIndex];
				//MapLoader.Loader.print(name + " - " + mainEl.visualMaterial.offset);
				if (sdc.visualMaterials[sdcIndex] != mainEl.visualMaterial) {
					Debug.LogWarning("SDC and Main materials did not match!");
				}
				mainEl.sdc = sdcEl;
				
				sdcIndex++;
			}
		}

		private static void ReadMeshFromATO(Reader reader, GeometricObject m) {
			// Revolution only: Before creating the gameobject, read the actual model data from the ATO
			if (Settings.s.game == Settings.Game.R2Revolution) {
				MapLoader l = MapLoader.Loader;
				List<GeometricObject> meshObjects = new List<GeometricObject>();
				for (uint i = 0; i < m.num_elements; i++) {
					if (m.element_types[i] == 1) {
						R2PS2Loader ps2l = (R2PS2Loader)l;
						meshObjects.Add(ps2l.ato.meshes[ps2l.ato.meshes.Length - 1 - ps2l.meshesRead - meshObjects.Count]);
					}
				}
				if (meshObjects.Count > 0) {
					int currentSubblock = 0;
					int curNumVertices = 0;
					bool tryMapping = true;
					if (m.vertices == null) {
						m.num_vertices = (ushort)meshObjects.Sum(mesh => mesh.num_vertices);
						m.vertices = new Vector3[m.num_vertices];
						m.normals = new Vector3[m.num_vertices];
						tryMapping = false;
					}
					for (int i = 0; i < meshObjects.Count; i++) {
						GeometricObject mo = meshObjects[i];
						while (currentSubblock < m.num_elements && m.element_types[currentSubblock] != 1) {
							currentSubblock++;
						}
						GeometricObjectElementTriangles me = (GeometricObjectElementTriangles)m.elements[currentSubblock];
						GeometricObjectElementTriangles moe = ((GeometricObjectElementTriangles)mo.elements[0]);
						if (!tryMapping) {
							Array.Copy(mo.vertices, 0, m.vertices, curNumVertices, mo.num_vertices);
							if (mo.normals != null) {
								Array.Copy(mo.normals, 0, m.normals, curNumVertices, mo.num_vertices);
							}
							me.OPT_mapping_vertices = Enumerable.Range(curNumVertices, mo.num_vertices).ToArray();
							curNumVertices += mo.num_vertices;
						} else {
							me.OPT_mapping_vertices = new int[moe.OPT_num_mapping_entries];
							for (int j = 0; j < mo.vertices.Length; j++) {
								me.OPT_mapping_vertices[j] = Array.IndexOf(m.vertices, mo.vertices[j]);
								if (me.OPT_mapping_vertices[j] == -1 || me.OPT_mapping_vertices[j] != Array.IndexOf(m.vertices, mo.vertices[j])) {
									Debug.LogError("Failed matching vertices between Renderware and OpenSpace");
								}
							}
						}
						me.OPT_disconnectedTriangles = moe.OPT_disconnectedTriangles;
						me.OPT_num_disconnectedTriangles = moe.OPT_num_disconnectedTriangles;
						me.triangles = null;
						me.num_triangles = 0;
						me.num_uvMaps = moe.num_uvMaps;
						me.num_uvs = moe.num_uvs;
						me.uvs = moe.uvs;
						me.OPT_mapping_uvs = moe.OPT_mapping_uvs;
						me.OPT_num_mapping_entries = moe.OPT_num_mapping_entries;
						me.vertexColors = moe.vertexColors;
						currentSubblock++;
						if (me.lightmap_index != -1) {
							R2PS2Loader ps2l = ((R2PS2Loader)l);
							string id_r = me.lightmap_index.ToString("D3") + "." + 0;
							//l.print(id_r + " - " + me.num_disconnected_triangles + " - " + m.num_vertices + " - " + mo.num_vertices);
							Texture2D lm = ps2l.GetLightmap(id_r);
							if (me.visualMaterial != null) {
								if (lm != null) {
									string id_g = me.lightmap_index.ToString("D3") + "." + 1;
									string id_b = me.lightmap_index.ToString("D3") + "." + 2;
									Texture2D lm_g = ps2l.GetLightmap(id_g);
									Texture2D lm_b = ps2l.GetLightmap(id_b);
									if (lm_g != null && lm_b != null) {
										for (int j = 0; j < lm.width; j++) {
											for (int k = 0; k < lm.height; k++) {
												Color r = lm.GetPixel(j, k);
												Color g = lm_g.GetPixel(j, k);
												Color b = lm_b.GetPixel(j, k);
												lm.SetPixel(j, k, new Color(r.a, g.a, b.a, 1f));
											}
										}
										lm.Apply();
									}
								} else {
									lm = new Texture2D(1, 1);
									lm.SetPixel(0, 0, Color.white);
									lm.wrapMode = TextureWrapMode.Clamp;
									lm.filterMode = FilterMode.Bilinear;
									lm.Apply();
								}
								Vector2[] lightmapUVs = new Vector2[mo.num_vertices];
								Pointer.DoAt(ref reader, ps2l.off_lightmapUV[me.lightmap_index], () => {
									for (int j = 0; j < mo.num_vertices; j++) {
										lightmapUVs[j] = new Vector2(reader.ReadSingle(), reader.ReadSingle());
									}
								});
								me.AddLightmap(lm, lightmapUVs);
							}
						}
					}
					((R2PS2Loader)l).meshesRead += (uint)meshObjects.Count;
				}
			}
		}

        // Call after clone
        public void Reset() {
            gao = null;
        }

        public IGeometricObject Clone() {
			return ActualClone(mockUnityApi: false);
		}

        public IGeometricObject CloneWithMockedUnityApi()
        {
			return ActualClone(mockUnityApi: true);
        }

		private IGeometricObject ActualClone(bool mockUnityApi)
        {
			GeometricObject m = (GeometricObject)MemberwiseClone();
			m.Reset();
			m.elements = new IGeometricObjectElement[num_elements];
			for (uint i = 0; i < m.num_elements; i++)
			{
				if (elements[i] != null) {
					if (mockUnityApi) {
						m.elements[i] = elements[i].CloneWithMockedUnityApi(m);
                    } else {
						m.elements[i] = elements[i].Clone(m);
					}					
					if (m.elements[i] is DeformSet) m.bones = (DeformSet)m.elements[i];
				}
			}
			m.MorphedVertices = null;
			return m;
		}
    }
}
