using System.Collections;
using UnityEngine;
using Game.PlayerInput;
using Game.Characters.Spells;

namespace Game.Characters
{
    public class PlayerControl
    {
        private Camera _camera;

        public PlayerControl()
        {
            _camera = Storages.Storages.GameData.Camera.GetFirstItem();
        }

        public void UpdateInput()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                CastSpell();
            }
        }


        private void CastSpell()
        {
            bool isActive = false;
            RaycastHit hit = GetEntity(Input.mousePosition);
            if (hit.collider.transform.parent.TryGetComponent<Character>(out Character player))
            {
                ContinuousSpell spell = new IncreaseStrength(player.Provider, player);
                foreach (ContinuousSpell tempSpell in player.ActiveSpells)
                {
                    if(tempSpell.Name == spell.Name)
                    {
                        isActive = true;
                        break;
                    }
                }
                if (!isActive)
                {
                    player.ActiveSpells.Add(new IncreaseStrength(player.Provider, player));
                }

                Debug.Log(isActive);
            }
        }


        private RaycastHit GetEntity(Vector3 mousePosition)
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                return hit;
            }
            return new RaycastHit();
        }



    }
}