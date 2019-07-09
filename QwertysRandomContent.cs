﻿using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using System;
using QwertysRandomContent.Items.B4Items;
using QwertysRandomContent.Items.Dyes;
using Terraria.Localization;


namespace QwertysRandomContent
{
	public class QwertysRandomContent : Mod
	{
        public static QwertysRandomContent Instance;

        public static Effect CustomEffect;
        public static ModHotKey YetAnotherSpecialAbility;
        public static Vector2[] LocalCursor = new Vector2[Main.player.Length];
        public override void AddRecipeGroups()
        {
           

            RecipeGroup group = new RecipeGroup(() => Lang.misc[37].Value + " evil bow", new int[]
            {
                ItemID.DemonBow,
                ItemID.TendonBow,
            });
            
            RecipeGroup.RegisterGroup("QwertysrandomContent:EvilBows", group);

            group = new RecipeGroup(() => Lang.misc[37].Value + " Aerous Bow", new int[]
            {
                ItemType("AerousLongbow"),
                ItemType("AerousLongbowWithRandomEnchantment"),
                ItemType("AerousLongbowWithStormEnchantment"),

            });
            RecipeGroup.RegisterGroup("QwertysrandomContent:AerousBow", group);


            group = new RecipeGroup(() => Lang.misc[37].Value + " Evil Powder", new int[]
            {
                ItemID.VilePowder,
                ItemID.ViciousPowder,

            });
            RecipeGroup.RegisterGroup("QwertysrandomContent:EvilPowder", group);
            group = new RecipeGroup(() => Lang.misc[37].Value + " Silver Bar", new int[]
           {
                ItemID.SilverBar,
                ItemID.TungstenBar,

           });
            RecipeGroup.RegisterGroup("QwertysrandomContent:SilverBar", group);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
        }
        //internal static QwertysRandomContent instance;
		public const string AncientMachineHead = "QwertysRandomContent/NPCs/AncientMachine/AncientMachine_Head_Boss";
        public const string HydraHead1 = "QwertysRandomContent/NPCs/HydraBoss/MapHead1";
        public const string HydraHead2 = "QwertysRandomContent/NPCs/HydraBoss/MapHead1";
        public const string HydraHead3 = "QwertysRandomContent/NPCs/HydraBoss/MapHead1";
        public QwertysRandomContent()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
			
			
		}
        
        
        public override void UpdateUI(GameTime gameTime)
        {
            
        }
        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.myPlayer != -1 && !Main.gameMenu && Main.LocalPlayer.active)
            {
                // Make sure your logic here goes from lowest priority to highest so your intended priority is maintained.
                if (Main.LocalPlayer.GetModPlayer<FortressBiome>().TheFortress)
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/HeavenlyFortress");
                    priority = MusicPriority.Event;
                }
                
            }
        }
        public override void PostSetupContent()
        {
            
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                
                bossChecklist.Call("AddBossWithInfo", "Ancient Machine", 5.5f, (Func<bool>)(() => QwertyWorld.downedAncient), "Look into the [i:" + ItemType("AncientEmblem") + "]");
                bossChecklist.Call("AddBossWithInfo", "The Hydra", 6.000001f, (Func<bool>)(() => QwertyWorld.downedhydra), "Tempt with [i:" + ItemType("HydraSummon") + "]");
                bossChecklist.Call("AddBossWithInfo", "Rune Ghost", 12.2f, (Func<bool>)(() => QwertyWorld.downedRuneGhost), "Use a [i:" + ItemType("SummoningRune") + "] to challenge its power. [i:" + ItemType("SummoningRune") + "] drops from the dungeon's sneaking ghosts");
                bossChecklist.Call("AddBossWithInfo", "Oversized Laser-emitting Obliteration Radiation-emitting Destroyer", 13.9999f, (Func<bool>)(() => QwertyWorld.downedB4), "Use a [i:" + ItemType("B4Summon") + "]");
                bossChecklist.Call("AddEventWithInfo", "Dino Militia", 9.001f, (Func<bool>)(() => QwertyWorld.downedDinoMilitia), "Use a [i:" + ItemType("DinoEgg") + "] and they'll come to drive you extinct!");
                bossChecklist.Call("AddEventWithInfo", "Dino Militia (post Moonlord)", 15f, (Func<bool>)(() => QwertyWorld.downedDinoMilitiaHard), "Use a [i:" + ItemType("DinoEgg") + "] the militia will hold nothing back this time!");
                bossChecklist.Call("AddMiniBossWithInfo", "The Great Tyrannosaurus", 9.002f, (Func<bool>)(() => QwertyWorld.downedTyrant), "Fights with the dino militia, more likely to a apear near the end");
                bossChecklist.Call("AddBossWithInfo", "The Divine Light", 4f, (Func<bool>)(() => QwertyWorld.downedFortressBoss), "Use a [i:" + ItemType("FortressBossSummon") + "]" + " at the altar in the sky fortress");
                bossChecklist.Call("AddBossWithInfo", "Polar Exterminator", .7f, (Func<bool>)(() => QwertyWorld.downedBear), "Hibernates in the underground tundra, [i:" + ItemType("FrostCompass") + "]Helps find it");
                bossChecklist.Call("AddBossWithInfo", "Imperious", 9.4f, (Func<bool>)(() => QwertyWorld.downedBlade), "Use the [i:" + ItemType("BladeBossSummon") + "], and accept its challenge");
                bossChecklist.Call("AddBossWithInfo", "Noetnap", 5.7f, (Func<bool>)(() => QwertyWorld.downedNoetnap), "Just use the [i:" + ItemType("RitualInterupter") + "] mortal!");
            }
        }
        public static Deck<string> AMLoot = new Deck<string>();
        public override void Load()
		{
            Config.Load();
            Instance = this;
            AMLoot.Add("AncientBlade");
            AMLoot.Add("AncientSniper");
            AMLoot.Add("AncientWave");
            AMLoot.Add("AncientThrow");
            AMLoot.Add("AncientMinionStaff");
            AMLoot.Add("AncientMissileStaff");
            AMLoot.Add("AncientLongbow");
            AMLoot.Add("AncientNuke");

            // Registers a new hotkey
            YetAnotherSpecialAbility = RegisterHotKey("Yet Another Special Ability", "Mouse3");
            if (!Main.dedServ)
            {
                // Add the female leg variants
                AddEquipTexture(GetItem("LuneLeggings"), EquipType.Legs, "LuneLeggings_Female", "QwertysRandomContent/Items/Armor/Lune/LuneLeggings_FemaleLegs");
                AddEquipTexture(GetItem("GaleSwiftRobes"), EquipType.Legs, "GaleSwiftRobes_Female", "QwertysRandomContent/Items/Fortress/GaleArmor/GaleSwiftRobes_FemaleLegs");
                AddEquipTexture(new CaeliteGreavesMale(), GetItem("CaeliteGreaves"), EquipType.Legs, "CaeliteGreaves_Legs", "QwertysRandomContent/Items/Fortress/CaeliteArmor/CaeliteGreaves_Legs");
                AddEquipTexture(new CaeliteGreavesFemale(), GetItem("CaeliteGreaves"), EquipType.Legs, "CaeliteGreaves_FemaleLegs", "QwertysRandomContent/Items/Fortress/CaeliteArmor/CaeliteGreaves_FemaleLegs");

                AddEquipTexture(new TwistedDarkLegs(), GetItem("TwistedDarkLegs"), EquipType.Legs, "TwistedDarkLegs_Legs", "QwertysRandomContent/Items/Armor/TwistedDark/TwistedDarkLegs_Legs");
                AddEquipTexture(new TwistedDarkLegsFemale(), GetItem("TwistedDarkLegs"), EquipType.Legs, "TwistedDarkLegs_FemaleLegs", "QwertysRandomContent/Items/Armor/TwistedDark/TwistedDarkLegs_FemaleLegs");

                AddEquipTexture(new RhuthiniumGreavesMale(), GetItem("RhuthiniumGreaves"), EquipType.Legs, "RhuthiniumGreaves", "QwertysRandomContent/Items/Armor/Rhuthinium/RhuthiniumGreaves_Legs");
                AddEquipTexture(new RhuthiniumGreavesFemale(), GetItem("RhuthiniumGreaves"), EquipType.Legs, "RhuthiniumGreaves_FemaleLegs", "QwertysRandomContent/Items/Armor/Rhuthinium/RhuthiniumGreaves_FemaleLegs");
                AddEquipTexture(GetItem("HydraLeggings"), EquipType.Legs, "HydraLeggings_Female", "QwertysRandomContent/Items/HydraItems/HydraLeggings_FemaleLegs");
                AddEquipTexture(GetItem("ShamanLegs"), EquipType.Legs, "ShamanLegs_Female", "QwertysRandomContent/Items/Armor/Shaman/ShamanLegs_FemaleLegs");
                CustomEffect = GetEffect("Effects/CustomEffect");
                Ref<Effect> CustomEffectRef = new Ref<Effect>();
                CustomEffectRef.Value = CustomEffect;
                
                
                GameShaders.Armor.BindShader<CustomArmorShader>(ItemType("CustomDye"), new CustomArmorShader(Main.PixelShaderRef, "ArmorColored"));
                GameShaders.Armor.BindShader<CustomArmorShader2>(ItemType("CustomDye2"), new CustomArmorShader2(Main.PixelShaderRef, "ArmorColored"));
                GameShaders.Armor.BindShader<CustomArmorShader3>(ItemType("CustomDye3"), new CustomArmorShader3(Main.PixelShaderRef, "ArmorColored"));
                GameShaders.Armor.BindShader<CustomArmorShader4>(ItemType("CustomDye4"), new CustomArmorShader4(Main.PixelShaderRef, "ArmorColored"));
            }
            
            //instance = this;
			
			ModTranslation text = CreateTranslation("DinoDefeat");
			text.SetDefault("You drove the Dinosaurs to extinction!");
            text.AddTranslation(GameCulture.Russian, "Ты довел динозавров до вымирания!");
            text.AddTranslation(GameCulture.Chinese, "你导致了恐龙灭绝!");
			AddTranslation(text);

			text = CreateTranslation("DinoEventStart");
			text.SetDefault("The Dino Militia is coming!");
            text.AddTranslation(GameCulture.Russian, "Дино армия наступает!");
            text.AddTranslation(GameCulture.Chinese, "恐龙自卫军即将抵达!");
            AddTranslation(text);

            text = CreateTranslation("DinoHardStart");
            text.SetDefault("The Dino Militia ready for a rematch!");
            text.AddTranslation(GameCulture.Russian, "Дино армия готово к реваншу!");
            text.AddTranslation(GameCulture.Chinese, "恐龙自卫军准备好再战!");
            AddTranslation(text);

            text = CreateTranslation("GhostAngry");
            text.SetDefault("I haven't even been trying until now!");
            text.AddTranslation(GameCulture.Russian, "Я даже не старался до сих пор! ");
            text.AddTranslation(GameCulture.Chinese, "我到现在都没试过!");
            AddTranslation(text);

            text = CreateTranslation("GhostFurious");
            text.SetDefault("Ok, now it's personal!");
            text.AddTranslation(GameCulture.Russian, "Хорошо, теперь это личное! ");
            text.AddTranslation(GameCulture.Chinese, "好，现在归私人所有!");
            AddTranslation(text);

            text = CreateTranslation("RhuthiniumGenerates");
            text.SetDefault("Rhuthimis has blessed your world with Rhuthinium!");
            text.AddTranslation(GameCulture.Russian, "Ваш мир был благославлён Рутиниумом! ");
            text.AddTranslation(GameCulture.Chinese, "鲁锡金神祝福了你的世界，获得鲁锡金矿");
            AddTranslation(text);

            text = CreateTranslation("DivineIntro");
            text.SetDefault("You have activated my sacred altar... but you are not one of my disciples... and thus I see you as an enemy. Leave this fortress! and never return!");
            text.AddTranslation(GameCulture.Russian, "Ты активировал мой священный алтарь... но ты не один из моих учеников... и поэтому я вижу в тебе врага. Покинь эту крепость! И никогда не возвращайся! ");
            text.AddTranslation(GameCulture.Chinese, "你激活了我的圣坛…但你不是我的门徒…所以我认为你是敌人。滚出这个堡垒！永远别回来！");
            AddTranslation(text);

            text = CreateTranslation("DivineRage");
            text.SetDefault("What part of 'NEVER RETURN' did you not understand? Such foolishness will bring forth your demise...");
            text.AddTranslation(GameCulture.Russian, "Какую часть фразы 'никогда не возвращайся' Ты не понял? Такая глупость приведет тебя к смерти... ");
            text.AddTranslation(GameCulture.Chinese, "你听不明白“永远别回来”里的哪个字？这样的愚蠢会导致你的死亡……");
            AddTranslation(text);

            text = CreateTranslation("DivineRage2");
            text.SetDefault("Fool, your pride shall bring your end...");
            text.AddTranslation(GameCulture.Russian, "Глупец, твоя гордость принесет тебе конец... ");
            text.AddTranslation(GameCulture.Chinese, "傻X，你的骄傲会让你的结局…");
            AddTranslation(text);

            text = CreateTranslation("DivineMock");
            text.SetDefault("Either you're slower than a mollusket or you're trying to heal, you know I'll do that if you don't keep up...");
            text.AddTranslation(GameCulture.Russian, "Либо ты медленнее моллюска, либо ты пытаешься выздороветь, ты знаешь, я сделаю это, если ты не поспеешь ... ");
            text.AddTranslation(GameCulture.Chinese, "要么你比慢的跟蜗牛一样，要么你在想着回血，你应该知道如果你不跟上我，我会…");
            AddTranslation(text);

            text = CreateTranslation("DivineLeave");
            text.SetDefault("now do not bother coming back!");
            text.AddTranslation(GameCulture.Russian, "И больше не возвращайся!");
            text.AddTranslation(GameCulture.Chinese, "现在别想回来了!");
            AddTranslation(text);

            text = CreateTranslation("DivineStart");
            text.SetDefault("... so be it");
            text.AddTranslation(GameCulture.Russian, "... Так тому и быть");
            text.AddTranslation(GameCulture.Chinese, "...就这样吧");
            AddTranslation(text);

            text = CreateTranslation("BindKey");
            text.SetDefault("Please go to conrols and bind the 'Yet another special ability key'");
            text.AddTranslation(GameCulture.Russian, "Пожалуйста, перейдите в управление и привяжите 'Yet another special ability key'");");
            text.AddTranslation(GameCulture.Chinese, "请去控制界面设定“另一个特殊能力键”");
            AddTranslation(text);



            #region set Bonus Translations
            text = CreateTranslation("ClaySet");
            text.SetDefault("Be like a clay statue and... \n Increased morph damage and morph defense when not moving");
            text.AddTranslation(GameCulture.Russian, "Будь как глиняная статуя...\n Увеличение урона оборотня и защита оборотня когда не двигаешься");
            text.AddTranslation(GameCulture.Chinese, "像一个泥雕一样\n不移动时增加啊化形伤害和化形防御");
            AddTranslation(text);

            text = CreateTranslation("DuelistSet");
            text.SetDefault("Morph attacks against a max combo enemy always crit");   
            text.AddTranslation(GameCulture.Russian, "Атаки оборотня против максимального комбо врага всегда критует");
            text.AddTranslation(GameCulture.Chinese, "化形对受到连续近战攻击的敌人必定暴击");
            AddTranslation(text);

            text = CreateTranslation("GlassSet");
            text.SetDefault("Ranged attacks Inflict 'Arcanely tuned' \nMagic attacks chase enemies inflicted with 'Arcanely tuned'");
            text.AddTranslation(GameCulture.Russian, "Дальние атаки накладывают 'Волшебный резонанс' \nМагические атаки преследуют врагов, с помощью 'Волшебного резонанса'");
            text.AddTranslation(GameCulture.Chinese, "远程攻击造成“调和奥秘”\n魔法攻击对敌人造成“调和奥秘”");
            AddTranslation(text);

            text = CreateTranslation("LuneCrestSet");
            text.SetDefault("Shoot the moon!" + "\nDouble right click summon a moon" + "\nRanged attacks shot through the moon will be boosted");
            text.AddTranslation(GameCulture.Russian, "Стрельни в луну!" + "\nДвойной щелчок правой кнопкой мыши вызывает луну "+" \nДальние атаки, прошедшие сквозь луну, будут усилены");
            text.AddTranslation(GameCulture.Chinese, "射击月亮!\n双击右键召唤一个月亮\n穿过月亮的远程射击会被加速");
            AddTranslation(text);

            text = CreateTranslation("LuneJacketSet");
            text.SetDefault("Attacking enemies far away from you with ranged attacks will take 20% more damage and get Lune cursed");
            text.AddTranslation(GameCulture.Russian, "Атакуя врагов с дальнего расстояния вы наносите +20% урона и лунное проклятие");
            text.AddTranslation(GameCulture.Chinese, "远程攻击远离你的敌人增加20%伤害并造成月咒");
            AddTranslation(text);

            text = CreateTranslation("RCapSet");
            text.SetDefault("100% ranged crit chance when at 100% life");
            text.AddTranslation(GameCulture.Russian, "100%-й шанс критического удара при 100% жизни");
            text.AddTranslation(GameCulture.Chinese, "满血时100%暴击");
            AddTranslation(text);

            text = CreateTranslation("RCircletSet");
            text.SetDefault("Melee attacks boost magic damage and max mana" + "\nMagic attacks boost melee damage");
            text.AddTranslation(GameCulture.Russian, "Атаки ближнего боя увеличивают магический урон и максимальную Ману " + " \nМагические атаки увеличивают урон ближнего боя");
            text.AddTranslation(GameCulture.Chinese, "近战攻击强化魔法伤害和增加魔力上限\n魔法攻击强化近战伤害");
            AddTranslation(text);

            text = CreateTranslation("RGogglesSet");
            text.SetDefault("Throwing attacks confuse and poison enemies" + "\n+10% throwing damage");
            text.AddTranslation(GameCulture.Russian, "Метательные атаки сбивают с толку и отравляют врагов "+" \n + 10% к урону");
            text.AddTranslation(GameCulture.Chinese, "投掷攻击会混乱和毒杀敌人\n增加10%投掷伤害");
            AddTranslation(text);

            text = CreateTranslation("RHatSet");
            text.SetDefault("20% bonus magic damage, but this bonus goes down as your mana goes down");
            text.AddTranslation(GameCulture.Russian, "20% бонусного магического урона, но этот бонус уменьшается с уменьшением вашей маны");
            text.AddTranslation(GameCulture.Chinese, "增加20%魔法伤害奖励,但是这个奖励会随着魔力消耗而降低");
            AddTranslation(text);

            text = CreateTranslation("RHeadbandSet");
            text.SetDefault("every 1% of life missing is converted to 1% extra melee speed");
            text.AddTranslation(GameCulture.Russian, "каждый 1% пропавшей жизни конвертируется в 1% к дополнительной скорости ближнего боя");
            text.AddTranslation(GameCulture.Chinese, "每丢失1%的生命将转化为1%的额外近战伤害");
            AddTranslation(text);

            text = CreateTranslation("RMaskSet");
            text.SetDefault("Minion attacks inflict ichor and +1 max minions");
            text.AddTranslation(GameCulture.Russian, "Атаки прислужников накладывают ихор и +1 прислужник");
            text.AddTranslation(GameCulture.Chinese, "召唤物攻击造成脓血并+1召唤上限");
            AddTranslation(text);

            text = CreateTranslation("RMouthguardkSet");
            text.SetDefault("+10% throwing damage and +100% throwing velocity when near a sentry");
            text.AddTranslation(GameCulture.Russian, "+ 10% к урону и + 100% к скорости при нахождении рядом с турелью");
            text.AddTranslation(GameCulture.Chinese, "在哨兵炮台附近增加10%投掷伤害和100%投掷速度");
            AddTranslation(text);

            text = CreateTranslation("ShamanSet1");
            text.SetDefault("Press the ");
            text.AddTranslation(GameCulture.Russian, "Нажмите на...");
            text.AddTranslation(GameCulture.Chinese, "按下");
            AddTranslation(text);

            text = CreateTranslation("ShamanSet2");
            text.SetDefault(" key to to call war spirits which temporarily make minions attack much faster and you gain 40% melee speed! \n 60 second cooldown");
            text.AddTranslation(GameCulture.Russian, "Ключ к призыву военных духов, которые временно заставляют миньонов атаковать намного быстрее, и вы получаете 40% скорости ближнего боя! \n60 секунд перезарядки");
            text.AddTranslation(GameCulture.Chinese, "键召唤一个战魂\n战魂使得召唤物攻击更快，并使你增加40%近战速度\n60秒冷却时间");
            AddTranslation(text);

            text = CreateTranslation("TankSet");
            text.SetDefault("Blitzkreig!- Morph attacks deal increased damage and stun newly spawned enemies\n minions deal bonus damage against stunned enemies");
            text.AddTranslation(GameCulture.Russian, "Blitzkreig!- При атаках оборотня наносится повышенный урон и оглушаются вновь появившиеся враги \nМиньоны наносят дополнительный урон против оглушенных врагов");
            text.AddTranslation(GameCulture.Chinese, "闪电战!\n化形攻击造成更大的伤害并使新产生的敌人眩晕\n召唤物对眩晕的敌人造成额外伤害");
            AddTranslation(text);

            text = CreateTranslation("DarkSet");
            text.SetDefault("+100 max life when morphed \nWith Eye's knowledge this extra health will be filled instantly upon morphing");
            text.AddTranslation(GameCulture.Russian, "+100 макс. Жизни при трансформации \nС благославлением глаза это дополнительное здоровье будет мгновенно восполнено при трансформации");
            text.AddTranslation(GameCulture.Chinese, "化形时增加100生命上限\n配合眼之真知在化形时可以立即将多出的血量补满");
            AddTranslation(text);


            text = CreateTranslation("VCharmSet");
            text.SetDefault("+1 max minions and sentries");
            text.AddTranslation(GameCulture.Russian, "+1 прислужник и турель");
            text.AddTranslation(GameCulture.Chinese, "+1召唤上限和哨兵炮台上限");
            AddTranslation(text);

            text = CreateTranslation("VCrownSet");
            text.SetDefault("Melee attacks boost magic damage and max mana" + "\nMagic attacks boost melee damage");
            text.AddTranslation(GameCulture.Russian, "Атаки ближнего боя увеличивают магический урон и максимальную Ману" + " \nМагические атаки увеличивают урон ближнего боя");
            text.AddTranslation(GameCulture.Chinese, "近战攻击强化魔法伤害和增加魔力上限\n魔法攻击强化近战伤害");
            AddTranslation(text);

            text = CreateTranslation("VHelmetSet");
            text.SetDefault("Spelunker effect and +40% mining speed");
            text.AddTranslation(GameCulture.Russian, "эффект зелья шахтёра и +40% к скорости копания");
            text.AddTranslation(GameCulture.Chinese, "获得地下探险效果\n增加40%挖掘速度");
            AddTranslation(text);

            text = CreateTranslation("VSombreroSSet");
            text.SetDefault("Magic attacks casted soon after ranged attacks consume no mana" + "\n25% chance not to consume ammo");
            text.AddTranslation(GameCulture.Russian, "Магические атаки, применяемые вскоре после атак дальнего боя, не расходуют маны" + "\n25% шанс не использовать боеприпасы");
            text.AddTranslation(GameCulture.Chinese, "远程攻击后快速切换魔法攻击不消耗法力\n25%几率不消耗弹药");
            AddTranslation(text);

            text = CreateTranslation("VVisorSet");
            text.SetDefault("Melee attacks will continually increase your ranged damage, resets when you do a ranged attack");
            text.AddTranslation(GameCulture.Russian, "");
            text.AddTranslation(GameCulture.Chinese, "近战攻击叠加远程伤害，切换远程武器时重置");
            AddTranslation(text);

            text = CreateTranslation("CaeliteSet");
            text.SetDefault("Effects granted by this armor are 25% more effective!");
            text.AddTranslation(GameCulture.Russian, "Эффекты от этой брони на 25% эффективнее!");
            text.AddTranslation(GameCulture.Chinese, "护甲效果提高25%！");
            AddTranslation(text);

            text = CreateTranslation("GaleSet");
            text.SetDefault("You generate gale rings over time" + "\n+1% dodge chance for each active ring" + "\nDouble right click to turn the rings into knives and send them flying at your cursor");
            text.AddTranslation(GameCulture.Russian, "Вы генерируете кольца бури со временем" + "\n+ 1% шанс уклонения для каждого активного кольца" + "\nДвойной щелчок правой кнопкой мыши превращает кольца в ножи и отправляет их летать под вашим курсором");
            text.AddTranslation(GameCulture.Chinese, "随着时间的推移，会产生一个飓风环\n每一个激活的环增加1%闪避几率\n双击鼠标右键，将圆环变为刀，并飞向光标位置\n(译者注：吉尔伽美什的王之财宝??)");
            AddTranslation(text);

            text = CreateTranslation("HydraSet");
            text.SetDefault("Like a hydra, you get more 'heads' the more injured you are." + "\n+1 max minions when below 80% life" + "\n+2 max minions when below 60% life" + "\n+3 max minions when below 40% life" + "\n+4 max minions when below 20% life" + "\n+20 max minions when below 1% life");
            text.AddTranslation(GameCulture.Russian, "Подобно гидре вы получаете больше 'голов' когда вас ранят" + "\n+1 Макс количество прислужников, когда уровень жизни ниже 80%" + "\n+2 Макс количество прислужников, когда уровень жизни ниже 60%" + "\n+3 Макс количество прислужников, когда жизнь ниже 40%" + "\n+4 Макс количество прислужников, когда жизнь ниже 20%" + "\n+20 макс количество прилужников, когда жизнь ниже 1%");
            text.AddTranslation(GameCulture.Chinese, "像海德拉一样，受伤越多你也有越多的“头”\n生命低于80%时，+1召唤上限\n生命低于60%时，+2召唤上限\n生命低于40%时，+3召唤上限\n生命低于20%时，+4召唤上限\n生命低于1%时，+20召唤上限");
            AddTranslation(text);
            #endregion

            //playermale

            text = CreateTranslation("his");
            text.SetDefault("his");
            text.AddTranslation(GameCulture.Russian, "Его");
	    text.AddTranslation(GameCulture.Chinese, "他的");
            AddTranslation(text);

            text = CreateTranslation("her");
            text.SetDefault("her");
            text.AddTranslation(GameCulture.Russian, "Её");
	    text.AddTranslation(GameCulture.Chinese, "她的");
            AddTranslation(text);

            //endplayermale

            //BloodyMedalion
            text = CreateTranslation("BloodyMedalionInfo1");
            text.SetDefault(" madly drained ");
            text.AddTranslation(GameCulture.Russian, "безумно истощенный");
	    text.AddTranslation(GameCulture.Chinese, "疯狂的消耗");
            AddTranslation(text);

            text = CreateTranslation("BloodyMedalionInfo2");
            text.SetDefault(" lifeforce!");
            text.AddTranslation(GameCulture.Russian, ":Жизненная сила!");
	    text.AddTranslation(GameCulture.Chinese, "生命力!");
            AddTranslation(text);

            text = CreateTranslation("BloodyMedalionInfo3");
            text.SetDefault("Uses ");
            text.AddTranslation(GameCulture.Russian, ":Использование");
	    text.AddTranslation(GameCulture.Chinese, "消耗");
            AddTranslation(text);

            text = CreateTranslation("BloodyMedalionInfo4");
            text.SetDefault(" life!");
            text.AddTranslation(GameCulture.Russian, ":Жизнь!");
	    text.AddTranslation(GameCulture.Chinese, "生命!");
            AddTranslation(text);
            //EndBloodyMedalion

            //PrefixInfo
            text = CreateTranslation("Perfixdamage");
            text.SetDefault("% damage");
            text.AddTranslation(GameCulture.Russian, ":% урон");
	    text.AddTranslation(GameCulture.Chinese, "%伤害");
            AddTranslation(text);

            text = CreateTranslation("Perfixcriticalstrikechance");
            text.SetDefault("% critical strike chance");
            text.AddTranslation(GameCulture.Russian, ":% Шанс критического удара");
	    text.AddTranslation(GameCulture.Chinese, "%暴击率");
            AddTranslation(text);

            text = CreateTranslation("Perfixmovementspeed");
            text.SetDefault("% movement speed");
            text.AddTranslation(GameCulture.Russian, ":% Скорость передвижения");
	    text.AddTranslation(GameCulture.Chinese, "%移动速度");
            AddTranslation(text);

            text = CreateTranslation("PerfixmeleeSpeed");
            text.SetDefault("% melee speed");
            text.AddTranslation(GameCulture.Russian, ":% Скорость ближнего боя");
	    text.AddTranslation(GameCulture.Chinese, "%近战速度");
            AddTranslation(text);

            text = CreateTranslation("Perfixdefense");
            text.SetDefault(" defense");
            text.AddTranslation(GameCulture.Russian, ":Защита");
	    text.AddTranslation(GameCulture.Chinese, "防御");
            AddTranslation(text);

            text = CreateTranslation("PerfixmanaReduction");
            text.SetDefault("% reduced mana usage");
            text.AddTranslation(GameCulture.Russian, ":% Уменьшение затрат маны");
	    text.AddTranslation(GameCulture.Chinese, "%减少魔力消耗");
            AddTranslation(text);

            text = CreateTranslation("PerfixammoReduction");
            text.SetDefault("% reduced ammo usage");
            text.AddTranslation(GameCulture.Russian, ":% Уменьшение затрат патронов");
	    text.AddTranslation(GameCulture.Chinese, "%减少弹药消耗");
            AddTranslation(text);

            text = CreateTranslation("PerfixthrowVel");
            text.SetDefault("% throwing velocity");
            text.AddTranslation(GameCulture.Russian, ":% Скорость броска");
	    text.AddTranslation(GameCulture.Chinese, "%投掷速度");
            AddTranslation(text);

            text = CreateTranslation("PerfixrangedVel");
            text.SetDefault("% ranged velocity");
            text.AddTranslation(GameCulture.Russian, ":% Скорость дальнего боя");
	    text.AddTranslation(GameCulture.Chinese, "%远程攻击速度");
            AddTranslation(text);

            text = CreateTranslation("PerfixdashPower");
            text.SetDefault(" dash power");
            text.AddTranslation(GameCulture.Russian, ":% Сила рывка");
	    text.AddTranslation(GameCulture.Chinese, "冲刺力度");
            AddTranslation(text);

            text = CreateTranslation("Perfixrecovery");
            text.SetDefault(" recovery");
            text.AddTranslation(GameCulture.Russian, ": Регенерация");
	    text.AddTranslation(GameCulture.Chinese, "生命回复");
            AddTranslation(text);

            text = CreateTranslation("PerfixdodgeChance");
            text.SetDefault("% dodge chance");
            text.AddTranslation(GameCulture.Russian, ":% Шанс уклонения");
	    text.AddTranslation(GameCulture.Chinese, "%闪避几率");
            AddTranslation(text);
            //EndPrefixInfo

            //ShapeShifter
            text = CreateTranslation("morph");
            text.SetDefault(" morph ");
            text.AddTranslation(GameCulture.Russian, ":Превращение");
	    text.AddTranslation(GameCulture.Chinese, "化形");
            AddTranslation(text);

            text = CreateTranslation("morphDefense");
            text.SetDefault(" defense when morphed");
            text.AddTranslation(GameCulture.Russian, ":% Защита в другом облике");
	    text.AddTranslation(GameCulture.Chinese, "防御处于化形时");
            AddTranslation(text);

            text = CreateTranslation("MorphTypeStable");
            text.SetDefault("Morph Type: Stable");
            text.AddTranslation(GameCulture.Russian, ":% Тип превращения:Контролируемый");
	    text.AddTranslation(GameCulture.Chinese, "化形类：稳固");
            AddTranslation(text);

            text = CreateTranslation("MorphTypeQuick");
            text.SetDefault("Morph Type: Quick");
            text.AddTranslation(GameCulture.Russian, ":Тип превращения:Быстрый");
	    text.AddTranslation(GameCulture.Chinese, "化形类：快速");
            AddTranslation(text);

            text = CreateTranslation("MorphTypeInvulnerable");
            text.SetDefault("Invulnerable when morphed");
            text.AddTranslation(GameCulture.Russian, ":Неуязвимость при превращении");
	    text.AddTranslation(GameCulture.Chinese, "出于化形时无敌");
            AddTranslation(text);

            text = CreateTranslation("Morphcooldown");
            text.SetDefault(" second cooldown");
            text.AddTranslation(GameCulture.Russian, ":Второе время восстановления");
	    text.AddTranslation(GameCulture.Chinese, "秒冷却");
            AddTranslation(text);

            text = CreateTranslation("prefixMorphDamage");
            text.SetDefault("% morph damage");
            text.AddTranslation(GameCulture.Russian, ":%Урон оборотня");
	    text.AddTranslation(GameCulture.Chinese, "%化形伤害");
            AddTranslation(text);

            text = CreateTranslation("prefixMorphDef");
            text.SetDefault(" defense when morphed");
            text.AddTranslation(GameCulture.Russian, ":Защита в другом облике");
	    text.AddTranslation(GameCulture.Chinese, "防御处于化形时");
            AddTranslation(text);

            text = CreateTranslation("prefixMorphCrit");
            text.SetDefault("% morph critical strike chance");
            text.AddTranslation(GameCulture.Russian, ":% Шанс крит удара оборотня");
	    text.AddTranslation(GameCulture.Chinese, "%化形暴击率");
            AddTranslation(text);

            text = CreateTranslation("PrefixorphCooldownModifierLonger");
            text.SetDefault("% longer cooldown");
            text.AddTranslation(GameCulture.Russian, ":% Долгая передышка");
	    text.AddTranslation(GameCulture.Chinese, "%延长冷却时间");
            AddTranslation(text);

            text = CreateTranslation("PrefixorphCooldownModifierShorter");
            text.SetDefault("% shorter cooldown");
            text.AddTranslation(GameCulture.Russian, ":% Короткая передышка");
	    text.AddTranslation(GameCulture.Chinese, "%闪避几率");
            AddTranslation(text);
            
            //EndShapeShifter

            //DinoMilitia
            text = CreateTranslation("DinoMilitia");
            text.SetDefault("Dino Militia");
            text.AddTranslation(GameCulture.Russian, ":Дино армия");
	    text.AddTranslation(GameCulture.Chinese, "恐龙自卫军");
            AddTranslation(text);

            text = CreateTranslation("DinoMilitiaCleared");
            text.SetDefault("Cleared ");
            text.AddTranslation(GameCulture.Russian, ":Пройдено");
	    text.AddTranslation(GameCulture.Chinese, "已清理 ");
            AddTranslation(text);
            //EndDinoMilitia



            AddBossHeadTexture(AncientMachineHead);
            AddBossHeadTexture(HydraHead1);
            AddBossHeadTexture(HydraHead2);
            AddBossHeadTexture(HydraHead3);

            if (!Main.dedServ)
			{
				// Register a new music box
				//AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/HydraBoss"), ItemType("HydraMusicBox"), TileType("HydraMusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/EnergisedPlanetaryIncinerationClimax"), ItemType("B4MusicBox"), TileType("B4MusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/BuiltToDestroy"), ItemType("AncientMusicBox"), TileType("MusicBoxBuiltToDestroy"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/HeavenlyFortress"), ItemType("MusicBoxHeavenlyFortress"), TileType("MusicBoxHeavenlyFortress"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/TheConjurer"), ItemType("MusicBoxTheConjurer"), TileType("MusicBoxTheConjurer"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/OldDinosNewGuns"), ItemType("MusicBoxOldDinosNewGuns"), TileType("MusicBoxOldDinosNewGuns"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/HigherBeing"), ItemType("MusicBoxHigherBeing"), TileType("MusicBoxHigherBeing"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/BladeOfAGod"), ItemType("MusicBoxBladeOfAGod"), TileType("MusicBoxBladeOfAGod"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/BeastOfThreeHeads"), ItemType("MusicBoxBeastOfThreeHeads"), TileType("MusicBoxBeastOfThreeHeads"));

                //Main.playerTextures[1, 10] = TextureManager.Load("Images/Player_6_6");
                //Main.playerTextures[1, PlayerTextureID.LegSkin] = GetTexture("Items/Vanity/AltLegs"); 


            }
			
			
		}
        public override void Unload()
        {

            // Unload static references
            // You need to clear static references to assets (Texture2D, SoundEffects, Effects). 
            CustomEffect = null;
            YetAnotherSpecialAbility = null;
            Instance = null; 

        }
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            ModMessageType msgType = (ModMessageType)reader.ReadByte();
            switch (msgType)
            {
                case ModMessageType.ArrowMessage:
                    int identity = reader.ReadInt32();
                    byte owner = reader.ReadByte();
                    int realIdentity = Projectile.GetByUUID(owner, identity);
                    if (realIdentity != -1)
                    {
                        Main.projectile[realIdentity].GetGlobalProjectile<arrowHoming>().B4HomingArrow = true;
                    }
                    if (Main.netMode == 2)
                    {
                        ModPacket packet = GetPacket();
                        packet.Write((byte)ModMessageType.ArrowMessage);
                        packet.Write(identity);
                        packet.Write(owner);
                        packet.Send();
                    }
                    break;

                case ModMessageType.FinnedRandomSwimMessage:

                    int identity2 = reader.ReadInt32();
                    byte owner2 = reader.ReadByte();
                    float randomSwim = reader.Read();
                    int realIdentity2 = Projectile.GetByUUID(owner2, identity2);

                    if (realIdentity2 != -1)
                    {
                        Main.projectile[realIdentity2].ai[1] = randomSwim;
                    }

                    if (Main.netMode == 2)
                    {
                        ModPacket packet = GetPacket();
                        packet.Write((byte)ModMessageType.FinnedRandomSwimMessage);
                        packet.Write(identity2);
                        packet.Write(owner2);
                        packet.Write(randomSwim);
                        packet.Send();
                    }
                    break;
                case ModMessageType.ScaleMessage:

                    int identity3 = reader.ReadInt32();
                    byte owner3 = reader.ReadByte();

                    int realIdentity3 = Projectile.GetByUUID(owner3, identity3);

                    if (realIdentity3 != -1)
                    {
                        Main.projectile[realIdentity3].scale = 3;
                    }

                    if (Main.netMode == 2)
                    {
                        ModPacket packet = GetPacket();
                        packet.Write((byte)ModMessageType.ScaleMessage);
                        packet.Write(identity3);
                        packet.Write(owner3);

                        packet.Send();
                    }
                    break;
                case ModMessageType.UpdateClassBools:
                    int identity4 = reader.ReadInt32();
                    byte owner4 = reader.ReadByte();
                    int realIdentity4 = Projectile.GetByUUID(owner4, identity4);
                    if (realIdentity4 != -1)
                    {
                        BitsByte flags = reader.ReadByte();
                        Main.projectile[realIdentity4].melee = flags[0];
                        Main.projectile[realIdentity4].ranged = flags[1];
                        Main.projectile[realIdentity4].magic = flags[2];
                        Main.projectile[realIdentity4].minion = flags[3];
                        Main.projectile[realIdentity4].thrown = flags[4];
                        Main.projectile[realIdentity4].GetGlobalProjectile<MorphProjectile>().morph = flags[5];
                    }
                    if (Main.netMode == 2)
                    {
                        UpdateProjectileClass(Main.projectile[realIdentity4]);
                    }
                    break;
                case ModMessageType.UpdateLocalCursor:
                    byte playerIndex = reader.ReadByte();
                    Vector2 Cursor = reader.ReadVector2();

                    LocalCursor[playerIndex] = Cursor;
                    if (Main.netMode == 2)
                    {
                        ModPacket packet = GetPacket();
                        packet.Write((byte)ModMessageType.UpdateLocalCursor); // Message type, you would need to create an enum for this
                        packet.Write(playerIndex);
                        packet.WriteVector2(Cursor);
                        packet.Send();
                    }
                    break;
                case ModMessageType.UpdatePlayerVelocity:
                    byte playerIndex2 = reader.ReadByte();
                    Vector2 vel = reader.ReadVector2();

                    Main.player[playerIndex2].velocity = vel;
                    if (Main.netMode == 2)
                    {
                        UpdatePlayerVelocity(playerIndex2, vel);
                        NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, playerIndex2);
                    }
                    break;
                case ModMessageType.UpdatePlayerPosition:
                    byte playerIndex3 = reader.ReadByte();
                    Vector2 pos = reader.ReadVector2();

                    Main.player[playerIndex3].position = pos;
                    
                    if (Main.netMode == 2)
                    {
                        UpdatePlayerPosition(playerIndex3, pos);
                        NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, playerIndex3);
                        
                    }
                    break;
                case ModMessageType.ProjectileAIUpdate:
                    int identity6 = reader.ReadInt32();
                    byte owner6 = reader.ReadByte();
                    int realIdentity6 = Projectile.GetByUUID(owner6, identity6);
                    float ai0 = reader.ReadSingle();
                    float ai1 = reader.ReadSingle();
                    if (realIdentity6 != -1)
                    {
                        Main.projectile[realIdentity6].ai[0] = ai0;
                        Main.projectile[realIdentity6].ai[1] = ai1;
                        if (Main.netMode == 2)
                        {
                            ProjectileAIUpdate(Main.projectile[realIdentity6]);
                        }
                    }
                    
                    break;
                case ModMessageType.DivineCall:
                    QwertyWorld.FortressBossQuotes();
                    Vector2 summonAt = reader.ReadVector2();
                    int npcID = NPC.NewNPC((int)summonAt.X, (int)summonAt.Y, NPCType("FortressBoss"));
                    break;
                case ModMessageType.StartDinoEvent:
                    QwertyWorld.DinoEvent = true;
                    QwertyWorld.DinoKillCount = 0;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
                    }
                        
                    break;

            }
        }
        
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            QwertyWorld modWorld = (QwertyWorld)GetModWorld("QwertyWorld");
            if (QwertyWorld.DinoEvent)
            {
                int index = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
                LegacyGameInterfaceLayer orionProgress = new LegacyGameInterfaceLayer("Dino Militia",
                    delegate
                    {
                        DrawDinoEvent(Main.spriteBatch);
                        return true;
                    },
                    InterfaceScaleType.UI);
                layers.Insert(index, orionProgress);
            }
        }
        
        public void DrawDinoEvent(SpriteBatch spriteBatch)
        {
           
            if (QwertyWorld.DinoEvent && !Main.gameMenu)
            {
                float scaleMultiplier = 0.5f + 1 * 0.5f;
                float alpha = 0.5f;
                Texture2D progressBg = Main.colorBarTexture;
                Texture2D progressColor = Main.colorBarTexture;
                Texture2D orionIcon = GetTexture("Items/DinoItems/DinoEgg");
                const string orionDescription = "Dino Militia";
                Color descColor = new Color(39, 86, 134);

                Color waveColor = new Color(255, 241, 51);
                Color barrierColor = new Color(255, 241, 51);

                try
                {
                    //draw the background for the waves counter
                    const int offsetX = 20;
                    const int offsetY = 20;
                    int width = (int)(200f * scaleMultiplier);
                    int height = (int)(46f * scaleMultiplier);
                    Rectangle waveBackground = Utils.CenteredRectangle(new Vector2(Main.screenWidth - offsetX - 100f, Main.screenHeight - offsetY - 23f), new Vector2(width, height));
                    Utils.DrawInvBG(spriteBatch, waveBackground, new Color(63, 65, 151, 255) * 0.785f);

                    //draw wave text

                    string waveText = Language.GetTextValue("Mods.QwertysRandomContent.DinoMilitiaCleared") + (int)(((float)QwertyWorld.DinoKillCount / (NPC.downedMoonlord ? 300:150))*100) + "%";
                    Utils.DrawBorderString(spriteBatch, waveText, new Vector2(waveBackground.X + waveBackground.Width / 2, waveBackground.Y), Color.White, scaleMultiplier, 0.5f, -0.1f);

                    //draw the progress bar

                    if (QwertyWorld.DinoKillCount == 0)
                    {

                    }
                   // Main.NewText(MathHelper.Clamp((modWorld.DinoKillCount/modWorld.MaxDinoKillCount), 0f, 1f));
                    Rectangle waveProgressBar = Utils.CenteredRectangle(new Vector2(waveBackground.X + waveBackground.Width * 0.5f, waveBackground.Y + waveBackground.Height * 0.75f), new Vector2(progressColor.Width, progressColor.Height));
                    Rectangle waveProgressAmount = new Rectangle(0, 0, (int)(progressColor.Width  * MathHelper.Clamp(((float)QwertyWorld.DinoKillCount / (float)(NPC.downedMoonlord ? 300 : 150)), 0f, 1f)), progressColor.Height);
                    Vector2 offset = new Vector2((waveProgressBar.Width - (int)(waveProgressBar.Width * scaleMultiplier)) * 0.5f, (waveProgressBar.Height - (int)(waveProgressBar.Height * scaleMultiplier)) * 0.5f);

                    spriteBatch.Draw(progressBg, waveProgressBar.Location.ToVector2() + offset, null, Color.White * alpha, 0f, new Vector2(0f), scaleMultiplier, SpriteEffects.None, 0f);
                    spriteBatch.Draw(progressBg, waveProgressBar.Location.ToVector2() + offset, waveProgressAmount, waveColor, 0f, new Vector2(0f), scaleMultiplier, SpriteEffects.None, 0f);

                    //draw the icon with the event description

                    //draw the background
                    const int internalOffset = 6;
                    Vector2 descSize = new Vector2(154, 40) * scaleMultiplier;
                    Rectangle barrierBackground = Utils.CenteredRectangle(new Vector2(Main.screenWidth - offsetX - 100f, Main.screenHeight - offsetY - 19f), new Vector2(width, height));
                    Rectangle descBackground = Utils.CenteredRectangle(new Vector2(barrierBackground.X + barrierBackground.Width * 0.5f, barrierBackground.Y - internalOffset - descSize.Y * 0.5f), descSize);
                    Utils.DrawInvBG(spriteBatch, descBackground, descColor * alpha);

                    //draw the icon
                    int descOffset = (descBackground.Height - (int)(32f * scaleMultiplier)) / 2;
                    Rectangle icon = new Rectangle(descBackground.X + descOffset, descBackground.Y + descOffset, (int)(32 * scaleMultiplier), (int)(32 * scaleMultiplier));
                    spriteBatch.Draw(orionIcon, icon, Color.White);

                    //draw text

                    Utils.DrawBorderString(spriteBatch, Language.GetTextValue("Mods.QwertysRandomContent.DinoMilitia"), new Vector2(barrierBackground.X + barrierBackground.Width * 0.5f, barrierBackground.Y - internalOffset - descSize.Y * 0.5f), Color.White, 0.80f, 0.3f, 0.4f);
                }
                catch (Exception e)
                {
                    ErrorLogger.Log(e.ToString());
                }
            }
        }
        public static void UpdateProjectileClass(Projectile projectile)
        {

            ModPacket packet = Instance.GetPacket();
            packet.Write((byte)ModMessageType.UpdateClassBools); // Message type, you would need to create an enum for this
            packet.Write(projectile.identity); // tells which projectile is being modified by the effect, the effect is then applied on the receiving end
            packet.Write((byte)projectile.owner);
            BitsByte flags = new BitsByte();
            flags[0] = projectile.melee;
            flags[1] = projectile.ranged;
            flags[2] = projectile.magic;
            flags[3] = projectile.minion;
            flags[4] = projectile.thrown;
            flags[5] = projectile.GetGlobalProjectile<MorphProjectile>().morph;
            packet.Write(flags);
            packet.Send();

        }
        public static void UpdatePlayerVelocity(int playerIndex, Vector2 velocity)
        {
            ModPacket packet = Instance.GetPacket();
            packet.Write((byte)ModMessageType.UpdatePlayerVelocity);
            packet.Write((byte)playerIndex);
            packet.WriteVector2(velocity);
            packet.Send();
        }
        public static void UpdatePlayerPosition(int playerIndex, Vector2 position)
        {
            ModPacket packet = Instance.GetPacket();
            packet.Write((byte)ModMessageType.UpdatePlayerPosition);
            packet.Write((byte)playerIndex);
            packet.WriteVector2(position);
            packet.Send();
        }
        public static void ProjectileAIUpdate(Projectile projectile)
        {
            ModPacket packet = Instance.GetPacket();
            packet.Write((byte)ModMessageType.ProjectileAIUpdate); // Message type, you would need to create an enum for this
            packet.Write(projectile.identity); // tells which projectile is being modified by the effect, the effect is then applied on the receiving end
            packet.Write((byte)projectile.whoAmI); // the player that shot the projectile, will be useful later
            packet.Write(projectile.ai[0]);
            packet.Write(projectile.ai[1]);
            packet.Send();
        }

    }
    enum ModMessageType : byte
    {
        ArrowMessage,
        FinnedRandomSwimMessage,
        ScaleMessage,
        TurretSetupMessage,
        UpdateClassBools,
        UpdateLocalCursor,
        UpdatePlayerVelocity,
        UpdatePlayerPosition,
        ProjectileAIUpdate,
        DivineCall,
        StartDinoEvent

    }
    public class CaeliteGreavesMale : EquipTexture
    {
    }

    public class CaeliteGreavesFemale : EquipTexture
    {
        public override bool DrawLegs()
        {
            return false;
        }
    }
    public class TwistedDarkLegs : EquipTexture
    {
    }

    public class TwistedDarkLegsFemale : EquipTexture
    {
        public override bool DrawLegs()
        {
            return false;
        }
    }
    public class RhuthiniumGreavesMale : EquipTexture
    {
       
    }

    public class RhuthiniumGreavesFemale : EquipTexture
    {
        
    }
}
