using System.Collections;
using UnityEngine;
using Game.PlayerInput;
using Game.Characters.Spells;

namespace Game.Characters
{
    public class PlayerControl
    {
        private readonly Camera _camera;

        public PlayerControl()
        {
            _camera = Storages.Storages.GameData.Camera.GetFirstItem();
        }

        public void UpdateInput()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                var entity = GetEntity(Input.mousePosition);
                Cast(new IncreaseStrength(entity.Provider, entity), entity);
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                var entity = GetEntity(Input.mousePosition);
                Cast(new IncreaseLuck(entity.Provider, entity), entity);
            }
        }

        private void Cast(Spell spell, Character entity)
        {
            if (entity.NoActiveSpell(spell))
            {
                entity.AddSpell(spell);
            }
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