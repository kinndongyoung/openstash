using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor (typeof(OSMelee))]
public class OSMeleeInspector : Editor {
	public override void OnInspectorGUI () {
		OSMelee melee = (OSMelee) target;

		if ( !melee.item ) {
			melee.item = melee.GetComponent< OSItem > ();

			GUI.color = Color.red;
			EditorGUILayout.LabelField ( "There is no OSItem component on this object!", EditorStyles.boldLabel );
			GUI.color = Color.white;
			return;
		}
		
		EditorGUILayout.LabelField ( "Properties", EditorStyles.boldLabel );

		DrawDefaultInspector ();

		EditorGUILayout.Space ();

		EditorGUILayout.LabelField ( "Inherited attributes", EditorStyles.boldLabel );

		melee.damageIndex = EditorGUILayout.Popup ( "Damage", melee.damageIndex, melee.item.GetAttributeStrings () );
		melee.firingRateIndex = EditorGUILayout.Popup ( "Firing rate", melee.firingRateIndex, melee.item.GetAttributeStrings () );
		melee.rangeIndex = EditorGUILayout.Popup ( "Range", melee.rangeIndex, melee.item.GetAttributeStrings () );

		EditorGUILayout.Space ();

		EditorGUILayout.LabelField ( "Inherited sounds", EditorStyles.boldLabel );

		melee.firingSoundIndex = EditorGUILayout.Popup ( "Fire", melee.firingSoundIndex, melee.item.GetSoundStrings () );
		melee.equippingSoundIndex = EditorGUILayout.Popup ( "Equip", melee.equippingSoundIndex, melee.item.GetSoundStrings () );
		melee.holsteringSoundIndex = EditorGUILayout.Popup ( "Holster", melee.holsteringSoundIndex, melee.item.GetSoundStrings () );
		
		EditorGUILayout.Space ();

		EditorGUILayout.LabelField ( "Inherited animations", EditorStyles.boldLabel );

		if ( melee.animation ) {
			List< string > animationNames = new List< string  > ();

			foreach ( AnimationState state in melee.animation ) {
				animationNames.Add ( state.name );
			}

			melee.firingAnimationIndex = EditorGUILayout.Popup ( "Equip", melee.equippingAnimationIndex, animationNames.ToArray () );
			melee.firingAnimationIndex = EditorGUILayout.Popup ( "Holster", melee.holsteringAnimationIndex, animationNames.ToArray () );
			melee.firingAnimationIndex = EditorGUILayout.Popup ( "Fire", melee.firingAnimationIndex, animationNames.ToArray () );
		
		} else {
			EditorGUILayout.LabelField ( "No animations on this item!" );
		
		}
	}
}
