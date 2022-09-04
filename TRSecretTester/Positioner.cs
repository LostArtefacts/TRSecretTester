using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TRFDControl;
using TRFDControl.FDEntryTypes;
using TRFDControl.Utilities;
using TRLevelReader;
using TRLevelReader.Helpers;
using TRLevelReader.Model;
using TRLevelReader.Model.Enums;
using TRRandomizerCore.Helpers;

namespace TRSecretTester
{
    public class Positioner
    {
        private static readonly ushort _allFlagBits = 0x3E00;
        private static readonly List<FDTrigAction> _removeTriggerActions = new List<FDTrigAction>
        {
            FDTrigAction.LookAtItem, FDTrigAction.Object
        };

        public enum StartPosition
        {
            Default,
            Entity,
            Custom
        };

        public string DataFolder { get; set; }
        public string LevelName { get; set; }
        public bool LimitEntities { get; set; }
        public int EntityLimit { get; set; }
        public bool MoveKeyItems { get; set; }
        public bool MovePuzzleItems { get; set; }
        public bool OpenDoors { get; set; }
        public bool AddFlares { get; set; }
        public StartPosition StartPos { get; set; }
        public int MatchEntityPosition { get; set; }
        public Location LaraCustomLocation { get; set; }

        private Config _config;

        public void Save()
        {
            _config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("TRSecretTester.json"));

            string lvlPath = Path.Combine(DataFolder, LevelName);
            uint version = DetectVersion(lvlPath);
            if (version == Versions.TR1)
            {
                TRLevel level = new TR1LevelReader().ReadLevel(lvlPath);
                Save(level);
                new TR1LevelWriter().WriteLevelToFile(level, lvlPath);
            }
            else if (version == Versions.TR2)
            {
                TR2Level level = new TR2LevelReader().ReadLevel(lvlPath);
                Save(level);
                new TR2LevelWriter().WriteLevelToFile(level, lvlPath);
            }
            else if (version == Versions.TR3a || version == Versions.TR3b)
            {
                TR3Level level = new TR3LevelReader().ReadLevel(lvlPath);
                Save(level);
                new TR3LevelWriter().WriteLevelToFile(level, lvlPath);
            }
            else
            {
                throw new ArgumentException("Unrecognised level");
            }
        }

        private uint DetectVersion(string path)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                return reader.ReadUInt32();
            }
        }

        private void Save(TRLevel level)
        {
            List<TREntity> entities = level.Entities.ToList();
            MoveLara(entities, _config.TR1LaraPositions[LevelName]);

            if (LimitEntities)
            {
                FDControl floorData = new FDControl();
                floorData.ParseFromLevel(level);

                LimitLevelEntities(entities, _config.TR1EntityRemovals, floorData);
                level.Entities = entities.ToArray();
                level.NumEntities = (uint)entities.Count;
                floorData.WriteToLevel(level);
            }

            if (MoveKeyItems)
            {
                TREntity lara = Array.Find(level.Entities, e => e.TypeID == (short)TREntities.Lara);
                foreach (TREntity ent in level.Entities)
                {
                    if (TR1EntityUtilities.IsKeyItemType((TREntities)ent.TypeID))
                    {
                        ent.X = lara.X;
                        ent.Y = lara.Y;
                        ent.Z = lara.Z;
                        ent.Room = lara.Room;
                        ent.Flags = _allFlagBits;
                    }
                }
            }

            if (OpenDoors)
            {
                bool pred(TREntity e) =>
                    TR1EntityUtilities.IsDoorType((TREntities)e.TypeID) ||
                    (TREntities)e.TypeID == TREntities.Trapdoor1 ||
                    (TREntities)e.TypeID == TREntities.Trapdoor2 ||
                    (TREntities)e.TypeID == TREntities.Trapdoor3;

                foreach (TREntity door in Array.FindAll(level.Entities, pred))
                {
                    door.Flags = _allFlagBits;
                }
            }
        }

        private void Save(TR2Level level)
        {
            List<TR2Entity> entities = level.Entities.ToList();
            MoveLara(entities, _config.TR2LaraPositions[LevelName]);

            if (LimitEntities)
            {
                FDControl floorData = new FDControl();
                floorData.ParseFromLevel(level);

                LimitLevelEntities(entities, _config.TR2EntityRemovals, floorData);
                level.Entities = entities.ToArray();
                level.NumEntities = (uint)entities.Count;
                floorData.WriteToLevel(level);
            }

            if (MoveKeyItems)
            {
                TR2Entity lara = Array.Find(level.Entities, e => e.TypeID == (short)TR2Entities.Lara);
                foreach (TR2Entity ent in level.Entities)
                {
                    if (TR2EntityUtilities.IsKeyItemType((TR2Entities)ent.TypeID))
                    {
                        ent.X = lara.X;
                        ent.Y = lara.Y;
                        ent.Z = lara.Z;
                        ent.Room = lara.Room;
                        ent.Flags = _allFlagBits;
                    }
                }
            }

            if (OpenDoors)
            {
                bool pred(TR2Entity e) =>
                    TR2EntityUtilities.IsDoorType((TR2Entities)e.TypeID) ||
                    (TR2Entities)e.TypeID == TR2Entities.Trapdoor1 ||
                    (TR2Entities)e.TypeID == TR2Entities.Trapdoor2 ||
                    (TR2Entities)e.TypeID == TR2Entities.Trapdoor3;

                foreach (TR2Entity door in Array.FindAll(level.Entities, pred))
                {
                    door.Flags = _allFlagBits;
                }
            }

            if (AddFlares)
            {
                TR2Entity flares = Array.Find(level.Entities, e => _config.TR2EntityRemovals.Contains(e.TypeID));
                if (flares != null)
                {
                    TR2Entity lara = Array.Find(level.Entities, e => e.TypeID == (short)TR2Entities.Lara);
                    flares.TypeID = (short)TR2Entities.Flares_S_P;
                    flares.X = lara.X;
                    flares.Y = lara.Y;
                    flares.Z = lara.Z;
                    flares.Room = lara.Room;
                    flares.Flags = _allFlagBits;
                    flares.Intensity1 = flares.Intensity1 = -1;
                }
            }
        }

        private void Save(TR3Level level)
        {
            List<TR2Entity> entities = level.Entities.ToList();
            MoveLara(entities, _config.TR3LaraPositions[LevelName]);

            if (LimitEntities)
            {
                FDControl floorData = new FDControl();
                floorData.ParseFromLevel(level);

                LimitLevelEntities(entities, _config.TR3EntityRemovals, floorData);
                level.Entities = entities.ToArray();
                level.NumEntities = (uint)entities.Count;
                floorData.WriteToLevel(level);
            }

            if (MoveKeyItems || MovePuzzleItems)
            {
                FDControl floorData = new FDControl();
                floorData.ParseFromLevel(level);
                TR2Entity lara = Array.Find(level.Entities, e => e.TypeID == (short)TR3Entities.Lara);
                for (int i = 0; i < level.NumEntities; i++)
                {
                    TR2Entity ent = level.Entities[i];
                    TR3Entities type = (TR3Entities)ent.TypeID;
                    if ((MoveKeyItems && TR3EntityUtilities.IsKeyItemType(type)) || (MovePuzzleItems && TR3EntityUtilities.IsPuzzleType(type)))
                    {
                        if (!IsTR3Secret(ent, i, level, floorData))
                        {
                            ent.X = lara.X;
                            ent.Y = lara.Y;
                            ent.Z = lara.Z;
                            ent.Room = lara.Room;
                            ent.Flags = _allFlagBits;
                        }
                    }
                }
            }

            if (OpenDoors)
            {
                foreach (TR2Entity door in Array.FindAll(level.Entities, e => TR3EntityUtilities.IsTrapdoor((TR3Entities)e.TypeID) || TR3EntityUtilities.IsDoorType((TR3Entities)e.TypeID)))
                {
                    door.Flags = _allFlagBits;
                }
            }

            if (AddFlares)
            {
                TR2Entity flares = Array.Find(level.Entities, e => _config.TR3EntityRemovals.Contains(e.TypeID));
                if (flares != null)
                {
                    TR2Entity lara = Array.Find(level.Entities, e => e.TypeID == (short)TR3Entities.Lara);
                    flares.TypeID = (short)TR3Entities.Flares_P;
                    flares.X = lara.X;
                    flares.Y = lara.Y;
                    flares.Z = lara.Z;
                    flares.Room = lara.Room;
                    flares.Flags = _allFlagBits;
                }
            }
        }
        
        private bool IsTR3Secret(TR2Entity entity, int entityIndex, TR3Level level, FDControl floorData)
        {
            Predicate<FDEntry> pred = new Predicate<FDEntry>
            (
                e =>
                    e is FDTriggerEntry trig && trig.TrigType == FDTrigType.Pickup
                 && trig.TrigActionList.Count > 1
                 && trig.TrigActionList[0].TrigAction == FDTrigAction.Object
                 && trig.TrigActionList[1].TrigAction == FDTrigAction.SecretFound
            );

            TRRoomSector sector = FDUtilities.GetRoomSector(entity.X, entity.Y, entity.Z, entity.Room, level, floorData);
            if (sector.FDIndex != 0)
            {
                if (floorData.Entries[sector.FDIndex].Find(pred) is FDTriggerEntry trigger && trigger.TrigActionList[0].Parameter == entityIndex)
                {
                    return true;
                }
            }

            return false;
        }

        private void MoveLara(List<TREntity> entities, Location defaultLocation)
        {
            TREntity lara = entities.Find(e => e.TypeID == (short)TREntities.Lara);

            if (StartPos == StartPosition.Default)
            {
                lara.X = defaultLocation.X;
                lara.Y = defaultLocation.Y;
                lara.Z = defaultLocation.Z;
                lara.Room = (short)defaultLocation.Room;
            }
            else if (StartPos == StartPosition.Custom)
            {
                lara.X = LaraCustomLocation.X;
                lara.Y = LaraCustomLocation.Y;
                lara.Z = LaraCustomLocation.Z;
                lara.Room = (short)LaraCustomLocation.Room;
            }
            else
            {
                TREntity otherPos = entities[MatchEntityPosition];
                lara.X = otherPos.X;
                lara.Y = otherPos.Y;
                lara.Z = otherPos.Z;
                lara.Room = otherPos.Room;
            }
        }

        private void MoveLara(List<TR2Entity> entities, Location defaultLocation)
        {
            TR2Entity lara = entities.Find(e => e.TypeID == (short)TR2Entities.Lara);

            if (StartPos == StartPosition.Default)
            {
                lara.X = defaultLocation.X;
                lara.Y = defaultLocation.Y;
                lara.Z = defaultLocation.Z;
                lara.Room = (short)defaultLocation.Room;
            }
            else if (StartPos == StartPosition.Custom)
            {
                lara.X = LaraCustomLocation.X;
                lara.Y = LaraCustomLocation.Y;
                lara.Z = LaraCustomLocation.Z;
                lara.Room = (short)LaraCustomLocation.Room;
            }
            else
            {
                TR2Entity otherPos = entities[MatchEntityPosition];
                lara.X = otherPos.X;
                lara.Y = otherPos.Y;
                lara.Z = otherPos.Z;
                lara.Room = otherPos.Room;
            }
        }

        private void LimitLevelEntities(List<TREntity> entities, List<short> removeTypes, FDControl floorData)
        {
            if (LimitEntities && entities.Count > EntityLimit)
            {
                Dictionary<int, TREntity> oldPositions = new Dictionary<int, TREntity>();
                Dictionary<TREntity, int> newPositions = new Dictionary<TREntity, int>();
                for (int i = 0; i < entities.Count; i++)
                {
                    oldPositions[i] = entities[i];
                }

                for (int i = entities.Count - 1; i >= 0; i--)
                {
                    if (entities.Count <= EntityLimit)
                    {
                        break;
                    }

                    if (removeTypes.Contains(entities[i].TypeID))
                    {
                        entities.RemoveAt(i);
                    }
                }

                for (int i = 0; i < entities.Count; i++)
                {
                    newPositions[entities[i]] = i;
                }

                foreach (List<FDEntry> entryList in floorData.Entries.Values)
                {
                    foreach (FDEntry entry in entryList)
                    {
                        if (entry is FDTriggerEntry trigger)
                        {
                            for (int i = trigger.TrigActionList.Count - 1; i >= 0; i--)
                            {
                                FDActionListItem action = trigger.TrigActionList[i];
                                if (_removeTriggerActions.Contains(action.TrigAction) && oldPositions.ContainsKey(action.Parameter))
                                {
                                    if (newPositions.ContainsKey(oldPositions[action.Parameter]))
                                    {
                                        action.Parameter = (ushort)newPositions[oldPositions[action.Parameter]];
                                    }
                                    else
                                    {
                                        trigger.TrigActionList.RemoveAt(i);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void LimitLevelEntities(List<TR2Entity> entities, List<short> removeTypes, FDControl floorData)
        {
            if (LimitEntities && entities.Count > EntityLimit)
            {
                Dictionary<int, TR2Entity> oldPositions = new Dictionary<int, TR2Entity>();
                Dictionary<TR2Entity, int> newPositions = new Dictionary<TR2Entity, int>();
                for (int i = 0; i < entities.Count; i++)
                {
                    oldPositions[i] = entities[i];
                }

                for (int i = entities.Count - 1; i >= 0; i--)
                {
                    if (entities.Count <= EntityLimit)
                    {
                        break;
                    }

                    if (removeTypes.Contains(entities[i].TypeID))
                    {
                        entities.RemoveAt(i);
                    }
                }

                for (int i = 0; i < entities.Count; i++)
                {
                    newPositions[entities[i]] = i;
                }

                foreach (List<FDEntry> entryList in floorData.Entries.Values)
                {
                    foreach (FDEntry entry in entryList)
                    {
                        if (entry is FDTriggerEntry trigger)
                        {
                            for (int i = trigger.TrigActionList.Count - 1; i >= 0; i--)
                            {
                                FDActionListItem action = trigger.TrigActionList[i];
                                if (_removeTriggerActions.Contains(action.TrigAction) && oldPositions.ContainsKey(action.Parameter))
                                {
                                    if (newPositions.ContainsKey(oldPositions[action.Parameter]))
                                    {
                                        action.Parameter = (ushort)newPositions[oldPositions[action.Parameter]];
                                    }
                                    else
                                    {
                                        trigger.TrigActionList.RemoveAt(i);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}