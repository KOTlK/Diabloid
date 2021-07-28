using System.Collections;
using UnityEngine;
using Game.PlayerInput;
using Game.Characters.Spells;

namespace Game.Characters
{
    public class PlayerControl
    {
        private readonly Camera _camera;
        private Character _selectedEntity;

        public PlayerControl()
        {
            _camera = Storages.Storages.GameData.Camera.GetFirstItem();
        }

        public void UpdateInput()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _selectedEntity = GetEntity(Input.mousePosition);
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                MoveToMousePoint();
            }
        }

        private void MoveToMousePoint()
        {
            if (_selectedEntity != null)
            {
                _selectedEntity.Mover.MoveTo(GetPointOnGround(Input.mousePosition));
            }
        }

        private void CastSpell(Spell spell, Character entity)
        {
            entity.ActiveSpells.Add(spell);
        }

        private Vector3 GetPointOnGround(Vector3 mousePosition)
        {
            Ray ray = _camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                return hit.point;
            }
            return Vector3.zero;
        }


        private Character GetEntity(Vector3 mousePosition)
        {
            Ray ray = _camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                if (hit.collider.transform.parent.TryGetComponent<Character>(out Character player))
                {
                    return player;
                } else
                {
                    return null;
                }
            }
            return null;
        }

    }
}