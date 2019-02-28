﻿#region Copyright & License Information
/*
 * Copyright 2007-2019 The OpenRA Developers (see AUTHORS)
 * This file is part of OpenRA, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version. For more
 * information, see COPYING.
 */
#endregion

using System.Collections.Generic;
using OpenRA.Mods.Common;
using OpenRA.Mods.Common.Traits;
using OpenRA.Mods.Common.Warheads;
using OpenRA.Mods.RA2.Traits;
using OpenRA.Traits;

namespace OpenRA.Mods.RA2.Warheads
{
    [Desc("Deals temportal damage to the actors with AffectedByTemporal trait.")]
    public class TemporalWarhead : TargetDamageWarhead
    {
        protected override void InflictDamage(Actor victim, Actor firedBy, HitShapeInfo hitshapeInfo, IEnumerable<int> damageModifiers)
        {
            var affectedByTemportal = victim.TraitOrDefault<AffectedByTemporal>();
            if (affectedByTemportal == null)
                return;

            var damage = Util.ApplyPercentageModifiers(Damage, damageModifiers.Append(DamageVersus(victim, hitshapeInfo)));
            affectedByTemportal.AddDamage(damage, firedBy);
        }
    }
}
