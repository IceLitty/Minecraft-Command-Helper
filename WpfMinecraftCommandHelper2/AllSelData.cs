using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;

namespace WpfMinecraftCommandHelper2
{
    public class AllSelData
    {
        private string nowLang = "cn";

        public AllSelData()
        {
            nowLang = getLangFile();
        }

        public string getLangFile()
        {
            List<string> txt = new List<string>();
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\lang"))
            {
                List<string> wtxt = new List<string>();
                wtxt.Add("cn");
                using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + @"\lang", FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        for (int i = 0; i < wtxt.Count; i++)
                        {
                            sw.WriteLine(wtxt[i]);
                        }
                    }
                }
            }
            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\lang", Encoding.UTF8))
            {
                int lineCount = 0;
                while (sr.Peek() > 0)
                {
                    lineCount++;
                    string temp = sr.ReadLine();
                    txt.Add(temp);
                }
            }
            try
            {
                return txt[0];
            }
            catch (Exception)
            {
                File.Delete(Directory.GetCurrentDirectory() + @"\lang");
                return "cn";
                //throw;
            }
        }

        private string[] itemNameList = {
                                                "<请选择一项物品>",
												"TNT",
												"鞍",
												"白桦木楼梯",
												"白桦木门",
												"白桦木栅栏",
												"白桦木栅栏门",
												"拌线钩",
												"比较器",
												"冰",
												"冰 - 浮冰",
												"玻璃",
												"玻璃 - 白色染色玻璃板",
												"玻璃 - 彩色玻璃",
												"玻璃板",
												"玻璃瓶",
												"草方块",
												"唱片_11",
												"唱片_13",
												"唱片_blocks",
												"唱片_cat",
												"唱片_chirp",
												"唱片_far",
												"唱片_mall",
												"唱片_mellohi",
												"唱片_stal",
												"唱片_strad",
												"唱片_wait",
												"唱片_ward",
												"唱片机",
												"船",
												"床",
												"从林木楼梯",
												"从林木门",
												"从林木栅栏门",
												"丛林木栅栏",
												"打火石",
												"蛋",
												"蛋糕",
												"地图",
												"地图 - 画好的地图",
												"地狱岩",
												"地狱疣",
												"地狱栅栏",
												"地狱砖",
												"地狱砖块",
												"地狱砖台阶",
												"恶魂之泪",
												"发射器",
												"腐肉",
												"附魔台",
												"甘蔗",
												"干草块",
												"高草",
												"告示牌",
												"告示牌 - 靠墙的告示牌",
												"告示牌 - 站立的告示牌",
												"耕地",
												"弓",
												"骨头",
												"海晶灯",
												"海晶砂砾",
												"海晶石",
												"海晶碎片",
												"海绵",
												"合成台",
												"荷叶",
												"黑曜石",
												"红色蘑菇块",
												"红沙楼梯",
												"红沙石",
												"红石",
												"红石 - 激活的红石比较器",
												"红石 - 未激活的红石比较器",
												"红石 - 激活的红石中继器",
												"红石 - 未激活的红石中继器",
												"红石灯",
												"红石灯 - 激活的红石灯",
												"红石火把",
												"红石火把 - 未激活的红石火把",
												"红石块",
												"红石矿",
												"红石矿 - 激活的红石矿",
												"红石线",
												"花盆",
												"画",
												"活塞",
												"活塞 - 粘性活塞",
												"活塞壁",
												"火",
												"火把",
												"火焰弹",
												"火药",
												"鸡肉",
												"鸡肉 - 熟鸡肉",
												"基岩",
												"剪刀",
												"箭矢 - 普通",
												"金铲",
												"金锄",
												"金锭",
												"金斧",
												"金镐",
												"金合欢木楼梯",
												"金合欢木门",
												"金合欢木栅栏",
												"金合欢木栅栏门",
												"金护腿",
												"金剑",
												"金块",
												"金矿",
												"金粒",
												"金苹果",
												"金头盔",
												"金胸甲",
												"金靴子",
												"经验瓶",
												"菌丝",
												"可可豆",
												"空气",
												"枯木",
												"矿车",
												"矿车 - TNT矿车",
												"矿车 - 动力矿车",
												"矿车 - 漏斗矿车",
												"矿车 - 命令方块矿车",
												"矿车 - 运输矿车",
												"盔甲架",
												"拉杆",
												"炼药锅",
												"烈焰棒",
												"烈焰粉",
												"灵魂沙",
												"龙蛋",
												"漏斗",
												"萝卜",
												"萝卜 - 已种植",
												"萝卜 - 金胡萝卜",
												"绿宝石",
												"绿宝石块",
												"绿宝石矿",
												"马铠 - 铁马铠",
												"马铠 - 金马铠",
												"马铠 - 钻石马铠",
												"马铃薯",
												"马铃薯 - 已种植",
												"马铃薯 - 烤马铃薯",
												"马铃薯 - 有毒的马铃薯",
												"煤块",
												"煤矿",
												"煤炭",
												"面包",
												"命令方块",
												"命名牌",
												"蘑菇 - 红色蘑菇",
												"蘑菇 - 棕色蘑菇",
												"蘑菇煲",
												"末地传送门方块",
												"末地传送门框架",
												"末地石",
												"末影箱",
												"末影珍珠",
												"末影之眼",
												"木板",
												"木铲",
												"木锄",
												"木斧",
												"木稿",
												"木棍",
												"木剑",
												"木楼梯",
												"木门",
												"木台阶",
												"木台阶 - 双木台阶",
												"木制按钮",
												"木制陷阱门",
												"南瓜",
												"南瓜灯",
												"南瓜梗",
												"南瓜派",
												"南瓜种子",
												"泥土",
												"酿造台",
												"牛排",
												"牛排 - 熟牛排",
												"皮革",
												"皮革护腿",
												"皮革头盔",
												"皮革胸甲",
												"皮革靴子",
												"苹果",
												"屏障",
												"蒲公英",
												"旗帜",
												"旗帜 - 上半层旗帜",
												"旗帜 - 下半层旗帜",
												"青金石块",
												"青金石矿",
												"曲奇",
												"染料",
												"日光检测器",
												"日光 - 月光检测器",
												"熔炉",
												"熔炉 - 燃烧的熔炉",
												"沙砾",
												"沙石",
												"沙石楼梯",
												"沙子",
												"深色橡木楼梯",
												"深色橡木门",
												"深色橡木栅栏",
												"深色橡木栅栏门",
												"深色橡树木门",
												"石铲",
												"石锄",
												"石斧",
												"石稿",
												"石剑",
												"石楼梯",
												"石台阶",
												"石台阶 - 双石台阶2",
												"石台阶2",
												"石头",
												"石英",
												"石英块",
												"石英矿",
												"石英楼梯",
												"石质按钮",
												"石砖",
												"石砖楼梯",
												"史莱姆块",
												"史莱姆球",
												"书",
												"书 - 成书",
												"书 - 附魔书",
												"书架",
												"书与笔",
												"树苗",
												"树叶",
												"树叶2 - 金合欢树叶",
												"刷怪蛋",
												"刷怪蛋 - 石头怪物蛋",
												"刷怪笼",
												"拴绳",
												"双层花",
												"双层台阶",
												"水",
												"水 - 流动水",
												"燧石",
												"锁链护腿",
												"锁链头盔",
												"锁链胸甲",
												"锁链靴子",
												"苔石",
												"糖",
												"藤蔓",
												"梯子",
												"铁铲",
												"铁锄",
												"铁锭",
												"铁斧",
												"铁镐",
												"铁轨",
												"铁轨 - 充能铁轨",
												"铁轨 - 激活铁轨",
												"铁轨 - 探测铁轨",
												"铁护腿",
												"铁剑",
												"铁块",
												"铁矿",
												"铁栏杆",
												"铁门",
												"铁头盔",
												"铁胸甲",
												"铁靴子",
												"铁砧",
												"桶",
												"桶 - 牛奶",
												"桶 - 水桶",
												"桶 - 岩浆桶",
												"头",
												"投掷器",
												"兔肉",
												"兔 - 熟兔肉",
												"兔 - 兔肉煲",
												"兔 - 兔子脚",
												"兔 - 兔子皮",
												"碗",
												"物品展示框",
												"西瓜",
												"西瓜块",
												"西瓜 - 闪烁的西瓜",
												"西瓜梗",
												"西瓜种子",
												"下界传送门方块",
												"下界之星",
												"仙人掌",
												"线",
												"陷阱门 - 铁质陷阱门",
												"陷阱箱",
												"箱子",
												"小麦",
												"小麦种子",
												"信标",
												"雪层",
												"雪块",
												"雪球",
												"压力板 - 木制压力板",
												"压力板 - 轻质测重压力板",
												"压力板 - 石质压力板",
												"压力板 - 重质测重压力板",
												"烟花火箭",
												"烟火之星",
												"岩浆",
												"岩浆 - 流动岩浆",
												"岩浆膏",
												"羊毛",
												"羊毛地毯",
												"羊肉",
												"羊肉 - 熟羊肉",
												"药水瓶",
												"音符盒",
												"罂粟花",
												"萤石粉",
												"萤石块",
												"鱼",
												"鱼 - 熟鱼",
												"鱼竿",
												"鱼竿 - 胡萝卜钓竿",
												"羽毛",
												"原木",
												"原木2 - 金合欢木",
												"原石",
												"原石墙",
												"云杉木楼梯",
												"云杉木门",
												"云杉木门",
												"云杉木栅栏",
												"云杉木栅栏门",
												"栅栏",
												"栅栏门",
												"粘土",
												"粘土 - 白色染色粘土",
												"粘土 - 硬化粘土",
												"粘土块",
												"蜘蛛网",
												"蜘蛛眼",
												"蜘蛛眼 - 发酵蛛眼",
												"纸",
												"指南针",
												"中继器",
												"钟",
												"猪排",
												"猪排 - 熟猪排",
												"砖块",
												"砖块楼梯",
												"砖头",
												"棕色蘑菇块",
												"钻石",
												"钻石铲",
												"钻石锄",
												"钻石斧",
												"钻石镐",
												"钻石护腿",
												"钻石剑",
												"钻石矿",
												"钻石头盔",
												"钻石胸甲",
												"钻石靴子",
												"钻石块",
                                                "紫珀台阶",
                                                "竖纹紫珀块",
                                                "紫珀块",
                                                "紫珀楼梯",
                                                "末地石砖",
                                                "末地烛",
                                                "紫影植物",
                                                "紫影花",
                                                "紫影果",
                                                "爆裂紫影果",
                                                "甜菜种子",
                                                "甜菜根",
                                                "甜菜根汤",
                                                "箭矢 - 光灵箭",
                                                "箭矢 - 淬药箭",
                                                "末地折跃门",
                                                "草径",
                                                "药水瓶 - 喷溅",
                                                "药水瓶 - 挥发",
                                                "盾牌",
                                                "龙息瓶",
                                                "命令方块 - 重复",
                                                "命令方块 - 绑定",
                                                "鞘翅",
                                                "结构方块"
                                              };

        string[] itemSel = {
                            "<NeedAnItemName>",
			                "minecraft:tnt",
			                "minecraft:saddle",
			                "minecraft:birch_stairs",
			                "minecraft:birch_door",
			                "minecraft:birch_fence",
			                "minecraft:birch_fence_gate",
			                "minecraft:tripwire_hook",
			                "minecraft:comparator",
			                "minecraft:ice",
			                "minecraft:packed_ice",
			                "minecraft:glass",
			                "minecraft:stained_glass_pane",
			                "minecraft:stained_glass",
			                "minecraft:glass_pane",
			                "minecraft:glass_bottle",
			                "minecraft:grass",
			                "minecraft:record_11",
			                "minecraft:record_13",
			                "minecraft:record_blocks",
			                "minecraft:record_cat",
			                "minecraft:record_chirp",
			                "minecraft:record_far",
			                "minecraft:record_mall",
			                "minecraft:record_mellohi",
			                "minecraft:record_stal",
			                "minecraft:record_strad",
			                "minecraft:record_wait",
			                "minecraft:record_ward",
			                "minecraft:jukebox",
			                "minecraft:boat",
			                "minecraft:bed",
			                "minecraft:jungle_stairs",
			                "minecraft:jungle_door",
			                "minecraft:jungle_fence_gate",
			                "minecraft:jungle_fence",
			                "minecraft:flint_and_steel",
			                "minecraft:egg",
			                "minecraft:cake",
			                "minecraft:map",
			                "minecraft:filled_map",
			                "minecraft:netherrack",
			                "minecraft:nether_wart",
			                "minecraft:nether_brick_fence",
			                "minecraft:netherbrick",
			                "minecraft:nether_brick",
			                "minecraft:nether_brick_stairs",
			                "minecraft:ghast_tear",
			                "minecraft:dispenser",
			                "minecraft:rotten_flesh",
			                "minecraft:enchanting_table",
			                "minecraft:reeds",
			                "minecraft:hay_block",
			                "minecraft:tallgrass",
			                "minecraft:sign",
			                "minecraft:wall_sign",
			                "minecraft:standing_sign",
			                "minecraft:farmland",
			                "minecraft:bow",
			                "minecraft:bone",
			                "minecraft:sea_lantern",
			                "minecraft:prismarine_crystals",
			                "minecraft:prismarine",
			                "minecraft:prismarine_shard",
			                "minecraft:sponge",
			                "minecraft:crafting_table",
			                "minecraft:waterlily",
			                "minecraft:obsidian",
			                "minecraft:red_mushroom_block",
			                "minecraft:red_sandstone_stairs",
			                "minecraft:red_sandstone",
			                "minecraft:redstone",
			                "minecraft:powered_comparator",
			                "minecraft:unpowered_comparator",
			                "minecraft:powered_repeater",
			                "minecraft:unpowered_repeater",
			                "minecraft:redstone_lamp",
			                "minecraft:lit_redstone_lamp",
			                "minecraft:redstone_torch",
			                "minecraft:unlit_redstone_torch",
			                "minecraft:redstone_block",
			                "minecraft:redstone_ore",
			                "minecraft:lit_redstone_ore",
			                "minecraft:redstone_wire",
			                "minecraft:flower_pot",
			                "minecraft:painting",
			                "minecraft:piston",
			                "minecraft:sticky_piston",
			                "minecraft:piston_head",
			                "minecraft:fire",
			                "minecraft:torch",
			                "minecraft:fire_charge",
			                "minecraft:gunpowder",
							"minecraft:chicken",
							"minecraft:cooked_chicken",
							"minecraft:bedrock",
							"minecraft:shears",
							"minecraft:arrow",
							"minecraft:golden_shovel",
							"minecraft:golden_hoe",
							"minecraft:gold_ingot",
							"minecraft:golden_axe",
							"minecraft:golden_pickaxe",
							"minecraft:acacia_stairs",
							"minecraft:acacia_door",
							"minecraft:acacia_fence",
							"minecraft:acacia_fence_gate",
							"minecraft:golden_leggings",
							"minecraft:golden_sword",
							"minecraft:gold_block",
							"minecraft:gold_ore",
							"minecraft:gold_nugget",
							"minecraft:golden_apple",
							"minecraft:golden_helmet",
							"minecraft:golden_chestplate",
							"minecraft:golden_boots",
							"minecraft:experience_bottle",
							"minecraft:mycelium",
							"minecraft:cocoa",
							"minecraft:air",
							"minecraft:deadbush",
							"minecraft:minecart",
							"minecraft:tnt_minecart",
							"minecraft:furnace_minecart",
							"minecraft:hopper_minecart",
							"minecraft:command_block_minecart",
							"minecraft:chest_minecart",
							"minecraft:armor_stand",
							"minecraft:lever",
							"minecraft:cauldron",
							"minecraft:blaze_rod",
							"minecraft:blaze_powder",
							"minecraft:soul_sand",
							"minecraft:dragon_egg",
							"minecraft:hopper",
							"minecraft:carrot",
							"minecraft:carrots",
							"minecraft:golden_carrot",
							"minecraft:emerald",
							"minecraft:emerald_block",
							"minecraft:emerald_ore",
							"minecraft:iron_horse_armor",
							"minecraft:golden_horse_armor",
							"minecraft:diamond_horse_armor",
							"minecraft:potato",
							"minecraft:potatoes",
							"minecraft:baked_potato",
							"minecraft:poisonous_potato",
							"minecraft:coal_block",
							"minecraft:coal_ore",
							"minecraft:coal",
							"minecraft:bread",
							"minecraft:command_block",
							"minecraft:name_tag",
							"minecraft:red_mushroom",
							"minecraft:brown_mushroom",
							"minecraft:mushroom_stew",
							"minecraft:end_portal",
							"minecraft:end_portal_frame",
							"minecraft:end_stone",
							"minecraft:ender_chest",
							"minecraft:ender_pearl",
							"minecraft:ender_eye",
							"minecraft:planks",
							"minecraft:wooden_shovel",
							"minecraft:wooden_hoe",
							"minecraft:wooden_axe",
							"minecraft:wooden_pickaxe",
							"minecraft:stick",
							"minecraft:wooden_sword",
							"minecraft:oak_stairs",
							"minecraft:wooden_door",
							"minecraft:wooden_slab",
							"minecraft:double_wooden_slab",
							"minecraft:wooden_button",
							"minecraft:trapdoor",
							"minecraft:pumpkin",
							"minecraft:lit_pumpkin",
							"minecraft:pumpkin_stem",
							"minecraft:pumpkin_pie",
							"minecraft:pumpkin_seeds",
							"minecraft:dirt",
							"minecraft:brewing_stand",
							"minecraft:beef",
							"minecraft:cooked_beef",
							"minecraft:leather",
							"minecraft:leather_leggings",
							"minecraft:leather_helmet",
							"minecraft:leather_chestplate",
							"minecraft:leather_boots",
							"minecraft:apple",
							"minecraft:barrier",
							"minecraft:yellow_flower",
							"minecraft:banner",
							"minecraft:wall_banner",
							"minecraft:standing_banner",
							"minecraft:lapis_block",
							"minecraft:lapis_ore",
							"minecraft:cookie",
							"minecraft:dye",
							"minecraft:daylight_detector",
							"minecraft:daylight_detector_inverted",
							"minecraft:furnace",
							"minecraft:lit_furnace",
							"minecraft:gravel",
							"minecraft:sandstone",
							"minecraft:sandstone_stairs",
							"minecraft:sand",
							"minecraft:dark_oak_stairs",
							"minecraft:dark_oak_door",
							"minecraft:dark_oak_fence",
							"minecraft:dark_oak_fence_gate",
							"minecraft:dark_oak_door",
							"minecraft:stone_shovel",
							"minecraft:stone_hoe",
							"minecraft:stone_axe",
							"minecraft:stone_pickaxe",
							"minecraft:stone_sword",
							"minecraft:stone_stairs",
							"minecraft:stone_slab",
							"minecraft:double_stone_slab2",
							"minecraft:stone_slab2",
							"minecraft:stone",
							"minecraft:quartz",
							"minecraft:quartz_block",
							"minecraft:quartz_ore",
							"minecraft:quartz_stairs",
							"minecraft:stone_button",
							"minecraft:stonebrick",
							"minecraft:stone_brick_stairs",
							"minecraft:slime",
							"minecraft:slime_ball",
							"minecraft:book",
							"minecraft:written_book",
							"minecraft:enchanted_book",
							"minecraft:bookshelf",
							"minecraft:writable_book",
							"minecraft:sapling",
							"minecraft:leaves",
							"minecraft:leaves2",
							"minecraft:spawn_egg",
							"minecraft:monster_egg",
							"minecraft:mob_spawner",
							"minecraft:lead",
							"minecraft:double_plant",
							"minecraft:double_stone_slab",
							"minecraft:water",
							"minecraft:flowing_water",
							"minecraft:flint",
							"minecraft:chainmail_leggings",
							"minecraft:chainmail_helmet",
							"minecraft:chainmail_chestplate",
							"minecraft:chainmail_boots",
							"minecraft:mossy_cobblestone",
							"minecraft:sugar",
							"minecraft:vine",
							"minecraft:ladder",
							"minecraft:iron_shovel",
							"minecraft:iron_hoe",
							"minecraft:iron_ingot",
							"minecraft:iron_axe",
							"minecraft:iron_pickaxe",
							"minecraft:rail",
							"minecraft:golden_rail",
							"minecraft:activator_rail",
							"minecraft:detector_rail",
							"minecraft:iron_leggings",
							"minecraft:iron_sword",
							"minecraft:iron_block",
							"minecraft:iron_ore",
							"minecraft:iron_bars",
							"minecraft:iron_door",
							"minecraft:iron_helmet",
							"minecraft:iron_chestplate",
							"minecraft:iron_boots",
							"minecraft:anvil",
							"minecraft:bucket",
							"minecraft:milk_bucket",
							"minecraft:water_bucket",
							"minecraft:lava_bucket",
							"minecraft:skull",
							"minecraft:dropper",
							"minecraft:rabbit",
							"minecraft:cooked_rabbit",
							"minecraft:rabbit_stew",
							"minecraft:rabbit_foot",
							"minecraft:rabbit_hide",
							"minecraft:bowl",
							"minecraft:item_frame",
							"minecraft:melon",
							"minecraft:melon_block",
							"minecraft:speckled_melon",
							"minecraft:melon_stem",
							"minecraft:melon_seeds",
							"minecraft:portal",
							"minecraft:nether_star",
							"minecraft:cactus",
							"minecraft:string",
							"minecraft:iron_trapdoor",
							"minecraft:trapped_chest",
							"minecraft:chest",
							"minecraft:wheat",
							"minecraft:wheat_seeds",
							"minecraft:beacon",
							"minecraft:snow_layer",
							"minecraft:snow",
							"minecraft:snowball",
							"minecraft:wooden_pressure_plate",
							"minecraft:light_weighted_pressure_plate",
							"minecraft:stone_pressure_plate",
							"minecraft:heavy_weighted_pressure_plate",
							"minecraft:fireworks",
							"minecraft:firework_charge",
							"minecraft:lava",
							"minecraft:flowing_lava",
							"minecraft:magma_cream",
							"minecraft:wool",
							"minecraft:carpet",
							"minecraft:mutton",
							"minecraft:cooked_mutton",
							"minecraft:potion",
							"minecraft:noteblock",
							"minecraft:red_flower",
							"minecraft:glowstone_dust",
							"minecraft:glowstone",
							"minecraft:fish",
							"minecraft:cooked_fish",
							"minecraft:fishing_rod",
							"minecraft:carrot_on_a_stick",
							"minecraft:feather",
							"minecraft:log",
							"minecraft:log2",
							"minecraft:cobblestone",
							"minecraft:cobblestone_wall",
							"minecraft:spruce_stairs",
							"minecraft:spruce_door",
							"minecraft:spruce_door",
							"minecraft:spruce_fence",
							"minecraft:spruce_fence_gate",
							"minecraft:fence",
							"minecraft:fence_gate",
							"minecraft:clay_ball",
							"minecraft:stained_hardened_clay",
							"minecraft:hardened_clay",
							"minecraft:clay",
							"minecraft:web",
							"minecraft:spider_eye",
							"minecraft:fermented_spider_eye",
							"minecraft:paper",
							"minecraft:compass",
							"minecraft:repeater",
							"minecraft:clock",
							"minecraft:porkchop",
							"minecraft:cooked_porkchop",
							"minecraft:brick_block",
							"minecraft:brick_stairs",
							"minecraft:brick",
							"minecraft:brown_mushroom_block",
							"minecraft:diamond",
							"minecraft:diamond_shovel",
							"minecraft:diamond_hoe",
							"minecraft:diamond_axe",
							"minecraft:diamond_pickaxe",
							"minecraft:diamond_leggings",
							"minecraft:diamond_sword",
							"minecraft:diamond_ore",
							"minecraft:diamond_helmet",
							"minecraft:diamond_chestplate",
							"minecraft:diamond_boots",
                            "minecraft:diamond_block",
                            "minecraft:purpur_slab",
                            "minecraft:purpur_pillar",
                            "minecraft:purpur_block",
                            "minecraft:purpur_stairs",
                            "minecraft:end_bricks",
                            "minecraft:end_rod",
                            "minecraft:chorus_plant",
                            "minecraft:chorus_flower",
							"minecraft:chorus_fruit",
							"minecraft:chorus_fruit_popped",
                            "minecraft:beetroot_seeds",
							"minecraft:beetroot",
							"minecraft:beetroot_soup",
                            "minecraft:spectral_arrow",
                            "minecraft:tipped_arrow",
                            "minecraft:end_gateway",
                            "minecraft:grass_path",
                            "minecraft:splash_potion",
                            "minecraft:lingering_potion",
                            "minecraft:shield",
                            "minecraft:dragon_breath",
                            "minecraft:repeating_command_block",
                            "minecraft:chain_command_block",
                            "minecraft:elytra",
                            "minecraft:structure"
                           };

        private string[] hideList = {
                                        "0 - 全部显示",
										"1 - 隐藏附魔",
										"2 - 隐藏自定义属性",
										"3 - 隐藏附魔和自定义属性",
										"4 - 隐藏不可破坏属性",
										"5","6","7",
										"8 - 隐藏可破坏单独物品属性",
										"9","10","11","12","13","14","15",
										"16 - 隐藏只可放置在指定方块上属性",
										"17","18","19","20","21","22","23","24","25","26","27","28","29","30","31",
										"32 - 隐藏大部分信息（药水信息，书作者，烟花效果等）",
										"33","34","35","36","37","38","39","40","41","42","43","44","45","46","47","48","49","50","51","52","53","54","55","56","57","58","59","60","61","62",
										"63 - 隐藏所有的信息，除了物品名和Lore文本"
                                    };

        private string[] hideListEN = {
                                        "0 - All Show",
                                        "1 - Hide Enchant",
                                        "2 - Hide Attribute",
                                        "3 - Hide Enchant And Attribute",
                                        "4 - Hide Unbreaking",
                                        "5","6","7",
                                        "8 - Hide Only Break Something",
                                        "9","10","11","12","13","14","15",
                                        "16 - Hide Only Place on Something",
                                        "17","18","19","20","21","22","23","24","25","26","27","28","29","30","31",
                                        "32 - Hide Most Infomation like Potion, Author of Book, Type of fireworks",
                                        "33","34","35","36","37","38","39","40","41","42","43","44","45","46","47","48","49","50","51","52","53","54","55","56","57","58","59","60","61","62",
                                        "63 - Hide All Infomation EXCEPT Item Name And Lore"
                                    };

        string[] atSel = {
                            "<NeedAnEntityName>",
							"<NeedAPlayerName>",
                            "All",
							"Animal",
							"Monster",
							"Mob",
							"Player",
                            "Item",
							"Ozelot",
							"Bat",
							"Villager",
							"Chicken",
							"Wolf",
							"EntityHorse",
							"MushroomCow",
							"Squid",
							"Cow",
							"VillagerGolem",
							"Rabbit",
							"SnowMan",
							"Sheep",
							"Pig",
							"Minecart",
							"MinecartSpawner",
							"MinecartChest",
							"ArmorStand",
							"EnderCrystal",
							"EyeOfEnderSignal",
							"ThrownExpBottle",
							"ThrownEnderpearl",
							"ThrownPotion",
							"LightningBolt",
							"LeashKnot",
							"ItemFrame",
							"SmallFireball",
							"FireworksRocketEntity",
							"WitherSkull",
							"CaveSpider",
							"Silverfish",
							"Ghast",
							"Guardian",
							"Zombie",
							"PigZombie",
							"Giant",
							"Skeleton",
							"Blaze",
							"Endermite",
							"Enderman",
							"Witch",
							"Creeper",
							"Slime",
							"LavaSlime",
							"Spider",
							"WitherBoss",
							"EnderDragon",
                            "PrimedTnt",
                            "FallingSand",
                            "MinecartHopper",
                            "MinecartRideable",
                            "Shulker",
                            "ShulkerBullet",
                            "TippedArrow",
                            "SpectralArrow",
                            "DragonFireball",
                            "AreaEffectCloud"
                         };

        string[] atSelNameList = {
                                    "<请选择一项实体>",
									"<玩家名>",
									"全部",
									"动物",
									"怪物",
									"生物",
									"玩家",
									"物品",
									"豹猫",
									"蝙蝠",
									"村民",
									"鸡",
									"狼",
									"马",
									"蘑菇牛",
									"墨鱼",
									"牛",
									"铁傀儡",
									"兔子",
									"雪人",
									"羊",
									"猪",
									"矿车",
									"矿车 - 刷怪箱矿车",
									"矿车 - 运输矿车",
									"盔甲架",
									"末影水晶",
									"末影之眼信号",
									"扔出的经验瓶",
									"扔出的末影珍珠",
									"扔出的药水瓶",
									"闪电",
									"拴绳结",
									"物品展示框",
									"小火球",
									"烟花火箭",
									"凋零骷髅",
									"洞穴蜘蛛",
									"蠹虫",
									"恶魂",
									"海底神殿守卫者",
									"僵尸",
									"僵尸猪人",
									"巨型僵尸",
									"骷髅弓箭手",
									"烈焰人",
									"末影螨",
									"末影人",
									"女巫",
									"爬行者",
									"史莱姆",
									"岩浆史莱姆",
									"蜘蛛",
									"凋零",
									"末影龙",
									"点燃的TNT",
									"掉落沙",
                                    "矿车 - 漏斗矿车",
                                    "*矿车 - 可乘矿车",
                                    "*潜匿之贝",
                                    "*潜匿之贝导弹",
                                    "*弓箭 - 附魔箭",
                                    "*弓箭 - 光箭",
                                    "*末影龙火焰弹",
                                    "*范围效果云"
                                 };

        string[] effectStr = { 	
                                "<请选择一项>",
								"<清除效果>",
								"饱和",
								"急迫",
								"抗火",
								"抗性提升",
								"力量",
								"伤害吸收",
								"生命恢复",
								"生命提升",
								"水下呼吸",
								"瞬间治疗",
								"速度",
								"跳跃提升",
								"夜视",
								"隐身",
								"凋零",
								"反胃",
								"缓慢",
								"饥饿",
								"失明",
								"瞬间伤害",
								"挖掘疲劳",
								"虚弱",
								"中毒",
                                "*发光",
                                "*升空",
                                "*幸运",
                                "*霉运"
                             };

        string[] effectSel = {
                                "<NeedChooseAnEffect>",
                                "clear",
								"minecraft:saturation",
								"minecraft:haste",
								"minecraft:fire_resistance",
								"minecraft:resistance",
								"minecraft:strength",
								"minecraft:absorption",
								"minecraft:regeneration",
								"minecraft:health_boost",
								"minecraft:water_breathing",
								"minecraft:instant_health",
								"minecraft:speed",
								"minecraft:jump_boost",
								"minecraft:night_vision",
								"minecraft:invisibility",
								"minecraft:wither",
								"minecraft:nausea",
								"minecraft:slowness",
								"minecraft:hunger",
								"minecraft:blindness",
								"minecraft:instant_damage",
								"minecraft:mining_fatigue",
								"minecraft:weakness",
								"minecraft:poison",
                                "minecraft:glowing",
                                "minecraft:levitation",
                                "minecraft:luck",
                                "minecraft:unluck"
                             };

        string[] effectSelID = { "ERROR", "ERROR", "23", "3", "12", "11", "5", "22", "10", "21", "13", "6", "1", "8", "16", "14", "20", "9", "2", "17", "15", "7", "4", "18", "19" };

        string[] particleSel = {
                                    "<NeedChooseAParticle>",
									"iconcrack",
									"blockcrack",
									"blockdust",
									"explode",
									"largeexplode",
									"hugeexplosion",
									"fireworksSpark",
									"bubble",
									"splash",
									"wake",
									"suspended",
									"depthsuspend",
									"crit",
									"magicCrit",
									"smoke",
									"largesmoke",
									"spell",
									"instantSpell",
									"mobSpell",
									"mobSpellAmbient",
									"witchMagic",
									"dripWater",
									"dripLava",
									"angryVillager",
									"happyVillager",
									"townaura",
									"note",
									"portal",
									"enchantmenttable",
									"flame",
									"lava",
									"footstep",
									"cloud",
									"reddust",
									"snowballpoof",
									"snowshovel",
									"slime",
									"heart",
									"barrier",
									"droplet",
									"take",
									"mobappearance",
                                    "dragonbreath",
                                    "endRod",
                                    "sweepAttack",
                                    "damageIndicator"
                               };

        string[] particleStrEn = {
                                "<NeedChooseAParticle>",
								"iconcrack_(id)_(meta)",
								"blockcrack_(id)",
								"blockdust_(id)",
								"explode",
								"largeexplode",
								"hugeexplosion",
								"fireworksSpark",
								"bubble",
								"splash",
								"wake",
								"suspended",
								"depthsuspend",
								"crit",
								"magicCrit",
								"smoke",
								"largesmoke",
								"spell",
								"instantSpell",
								"mobSpell",
								"mobSpellAmbient",
								"witchMagic",
								"dripWater",
								"dripLava",
								"angryVillager",
								"happyVillager",
								"townaura",
								"note",
								"portal",
								"enchantmenttable",
								"flame",
								"lava",
								"footstep",
								"cloud",
								"reddust",
								"snowballpoof",
								"snowshovel",
								"slime",
								"heart",
								"barrier",
								"droplet",
								"take",
								"mobappearance",
                                "dragonbreath",
                                "endRod",
                                "sweepAttack",
                                "damageIndicator"
                               };

        string[] particleStrCn = {
                                    "<请选择一项>",
									"图标效果 - 吃东西/扔鸡蛋/雪球/爆裂瓶/末影之眼/工具损坏的效果",
									"方块效果 - 破坏方块/画等效果",
									"方块效果 - 破坏盔甲架、掉落效果",
									"小爆炸 - 怪物死亡或蠹虫进入方块的效果",
									"大爆炸 - 恶魂火球，凋零头或末影龙死亡效果",
									"巨型爆炸 - 末影龙死亡或剪哞菇时的效果",
									"烟花尾部或爆炸后效果",
									"气泡 - 水中气泡或深海守护者、鱼竿的效果",
									"水里的实体、狼抖掉身上的水或船尾部的效果",
									"钓鱼鱼上钩前的效果",
									"在水下的效果",
									"深色粒子效果（未使用）",
									"攻击实体、弓箭效果",
									"带有锋利/亡灵杀手/节肢杀手的剑、斧的效果",
									"小型烟 - 火把/点燃的TNT/掉落物/发射器/熔炉/刷怪笼等效果",
									"大型烟 - 火焰/动力矿车/烈焰人等效果",
									"爆裂瓶、经验瓶的效果",
									"瞬间治疗、瞬间伤害爆裂瓶效果",
									"带有状态效果的生物、村民生成交易的效果",
									"信标效果",
									"女巫的效果",
									"滴落的雨滴、湿海绵、下雨时的树叶效果",
									"滴落的岩浆效果",
									"村庄中攻击村民后的效果",
									"骨粉催熟、村民交易后或喂养小动物的效果",
									"菌丝上的效果、类似depthsuspend",
									"音符盒音符效果",
									"下界传送门、末影生物和道具、末影箱或龙蛋的效果",
									"书架旁附魔台的效果",
									"火把上的火焰、熔炉、岩浆史莱姆、刷怪笼的效果",
									"岩浆上蹦出的火花效果",
									"脚印",
									"小型云雾 - 未使用",
									"激活的红石线、红石效果",
									"扔雪球、创建凋零或铁傀儡的雪片效果",
									"创建雪人的效果（同上）",
									"史莱姆的效果",
									"喂养、驯服的效果",
									"屏障方块的显示效果",
									"下雨的效果",
									"未知 - 目前无实际效果（也无particle显示）",
									"深海守护者从屏幕下至上的效果",
                                    "末影龙的龙息",
                                    "末影柱的颗粒物",
                                    "剑的攻击效果",
                                    "伤害显示效果"
                                 };

        string[] fireworkTypeStr = {
                                    "小球状",
									"大球状",
									"星形状",
									"爬行者",
									"散射状"
                                   };

        string[] fireworkTypeStrEn = {
                                    "Small Ball",
                                    "Big Ball",
                                    "Star",
                                    "Creeper",
                                    "Scattering"
                                   };

        string[] signDirectionStr = {
                                        "0 - 南",
										"1",
										"2 - 西南",
										"3",
										"4 - 西",
										"5",
										"6 - 西北",
										"7",
										"8 - 北",
										"9",
										"10 - 东北",
										"11",
										"12 - 东",
										"13",
										"14 - 东南",
										"15"
                                    };

        string[] signDirectionStrEn = {
                                        "0 - South",
                                        "1",
                                        "2 - SouthWest",
                                        "3",
                                        "4 - West",
                                        "5",
                                        "6 - NorthWest",
                                        "7",
                                        "8 - North",
                                        "9",
                                        "10 - NorthEast",
                                        "11",
                                        "12 - East",
                                        "13",
                                        "14 - SouthEast",
                                        "15"
                                    };

        string[] colorStr = {
                                "black",
								"gray",
								"dark_gray",
								"white",
								"red",
								"dark_red",
								"yellow",
								"gold",
								"green",
								"dark_green",
								"blue",
								"dark_blue",
								"aqua",
								"dark_aqua",
								"light_purple",
								"dark_purple"
                            };

        string[] colorString = {
                                    "黑色",
									"灰色",
									"深灰色",
									"白色",
									"红色",
									"深红色",
									"黄色",
									"金色",
									"绿色",
									"深绿色",
									"蓝色",
									"深蓝色",
									"青色",
									"深青色",
									"亮紫色",
									"深紫色"
                               };

        string[] slotSel = {
                                "<NeedChooseASlot>",
								"slot.weapon.mainhand",
                                "slot.weapon.offhand",
								"slot.armor.head",
								"slot.armor.chest",
								"slot.armor.legs",
								"slot.armor.feet",
								"slot.hotbar.0",
								"slot.hotbar.1",
								"slot.hotbar.2",
								"slot.hotbar.3",
								"slot.hotbar.4",
								"slot.hotbar.5",
								"slot.hotbar.6",
								"slot.hotbar.7",
								"slot.hotbar.8",
								"slot.inventory.0",
								"slot.inventory.1",
								"slot.inventory.2",
								"slot.inventory.3",
								"slot.inventory.4",
								"slot.inventory.5",
								"slot.inventory.6",
								"slot.inventory.7",
								"slot.inventory.8",
								"slot.inventory.9",
								"slot.inventory.10",
								"slot.inventory.11",
								"slot.inventory.12",
								"slot.inventory.13",
								"slot.inventory.14",
								"slot.inventory.15",
								"slot.inventory.16",
								"slot.inventory.17",
								"slot.inventory.18",
								"slot.inventory.19",
								"slot.inventory.20",
								"slot.inventory.21",
								"slot.inventory.22",
								"slot.inventory.23",
								"slot.inventory.24",
								"slot.inventory.25",
								"slot.inventory.26",
								"slot.container.0",
								"slot.container.1",
								"slot.container.2",
								"slot.container.3",
								"slot.container.4",
								"slot.container.5",
								"slot.container.6",
								"slot.container.7",
								"slot.container.8",
								"slot.container.9",
								"slot.container.10",
								"slot.container.11",
								"slot.container.12",
								"slot.container.13",
								"slot.container.14",
								"slot.container.15",
								"slot.container.16",
								"slot.container.17",
								"slot.container.18",
								"slot.container.19",
								"slot.container.20",
								"slot.container.21",
								"slot.container.22",
								"slot.container.23",
								"slot.container.24",
								"slot.container.25",
								"slot.container.26",
								"slot.container.27",
								"slot.container.28",
								"slot.container.29",
								"slot.container.30",
								"slot.container.31",
								"slot.container.32",
								"slot.container.33",
								"slot.container.34",
								"slot.container.35",
								"slot.container.36",
								"slot.container.37",
								"slot.container.38",
								"slot.container.39",
								"slot.container.40",
								"slot.container.41",
								"slot.container.42",
								"slot.container.43",
								"slot.container.44",
								"slot.container.45",
								"slot.container.46",
								"slot.container.47",
								"slot.container.48",
								"slot.container.49",
								"slot.container.50",
								"slot.container.51",
								"slot.container.52",
								"slot.container.53",
								"slot.enderchest.0",
								"slot.enderchest.1",
								"slot.enderchest.2",
								"slot.enderchest.3",
								"slot.enderchest.4",
								"slot.enderchest.5",
								"slot.enderchest.6",
								"slot.enderchest.7",
								"slot.enderchest.8",
								"slot.enderchest.9",
								"slot.enderchest.10",
								"slot.enderchest.11",
								"slot.enderchest.12",
								"slot.enderchest.13",
								"slot.enderchest.14",
								"slot.enderchest.15",
								"slot.enderchest.16",
								"slot.enderchest.17",
								"slot.enderchest.18",
								"slot.enderchest.19",
								"slot.enderchest.20",
								"slot.enderchest.21",
								"slot.enderchest.22",
								"slot.enderchest.23",
								"slot.enderchest.24",
								"slot.enderchest.25",
								"slot.enderchest.26",
								"slot.horse.armor",
								"slot.horse.chest",
								"slot.horse.saddle",
								"slot.horse.0",
								"slot.horse.1",
								"slot.horse.2",
								"slot.horse.3",
								"slot.horse.4",
								"slot.horse.5",
								"slot.horse.6",
								"slot.horse.7",
								"slot.horse.8",
								"slot.horse.9",
								"slot.horse.10",
								"slot.horse.11",
								"slot.horse.12",
								"slot.horse.13",
								"slot.horse.14",
								"slot.villager.0",
								"slot.villager.1",
								"slot.villager.2",
								"slot.villager.3",
								"slot.villager.4",
								"slot.villager.5",
								"slot.villager.6",
								"slot.villager.7"
                           };

        string[] slotSelStr = {
                                "<请选择对应的物品栏号码>",
								"武器栏 - 主手",
                                "武器栏 - 副手 #-106",
                                "装备栏 - 头盔 #100",
                                "装备栏 - 胸甲 #101",
                                "装备栏 - 护腿 #102",
                                "装备栏 - 靴子 #103",
								"热键栏 - 0 #0",
                                "热键栏 - 1 #1",
                                "热键栏 - 2 #2",
                                "热键栏 - 3 #3",
                                "热键栏 - 4 #4",
                                "热键栏 - 5 #5",
                                "热键栏 - 6 #6",
                                "热键栏 - 7 #7",
                                "热键栏 - 8 #8",
                                "背包栏 - 0 #9",
                                "背包栏 - 1 #10",
                                "背包栏 - 2 #11",
                                "背包栏 - 3 #12",
                                "背包栏 - 4 #13",
                                "背包栏 - 5 #14",
                                "背包栏 - 6 #15",
                                "背包栏 - 7 #16",
                                "背包栏 - 8 #17",
                                "背包栏 - 9 #18",
                                "背包栏 - 10 #19",
                                "背包栏 - 11 #20",
                                "背包栏 - 12 #21",
                                "背包栏 - 13 #22",
                                "背包栏 - 14 #23",
                                "背包栏 - 15 #24",
                                "背包栏 - 16 #25",
                                "背包栏 - 17 #26",
                                "背包栏 - 18 #27",
                                "背包栏 - 19 #28",
                                "背包栏 - 20 #29",
                                "背包栏 - 21 #30",
                                "背包栏 - 22 #31",
                                "背包栏 - 23 #32",
                                "背包栏 - 24 #33",
                                "背包栏 - 25 #34",
                                "背包栏 - 26 #35",
								"容器栏(大小箱子熔炉等) - 0",
								"容器栏(大小箱子熔炉等) - 1",
								"容器栏(大小箱子熔炉等) - 2",
								"容器栏(大小箱子熔炉等) - 3",
								"容器栏(大小箱子熔炉等) - 4",
								"容器栏(大小箱子熔炉等) - 5",
								"容器栏(大小箱子熔炉等) - 6",
								"容器栏(大小箱子熔炉等) - 7",
								"容器栏(大小箱子熔炉等) - 8",
								"容器栏(大小箱子熔炉等) - 9",
								"容器栏(大小箱子熔炉等) - 10",
								"容器栏(大小箱子熔炉等) - 11",
								"容器栏(大小箱子熔炉等) - 12",
								"容器栏(大小箱子熔炉等) - 13",
								"容器栏(大小箱子熔炉等) - 14",
								"容器栏(大小箱子熔炉等) - 15",
								"容器栏(大小箱子熔炉等) - 16",
								"容器栏(大小箱子熔炉等) - 17",
								"容器栏(大小箱子熔炉等) - 18",
								"容器栏(大小箱子熔炉等) - 19",
								"容器栏(大小箱子熔炉等) - 20",
								"容器栏(大小箱子熔炉等) - 21",
								"容器栏(大小箱子熔炉等) - 22",
								"容器栏(大小箱子熔炉等) - 23",
								"容器栏(大小箱子熔炉等) - 24",
								"容器栏(大小箱子熔炉等) - 25",
								"容器栏(大小箱子熔炉等) - 26",
								"容器栏(大小箱子熔炉等) - 27",
								"容器栏(大小箱子熔炉等) - 28",
								"容器栏(大小箱子熔炉等) - 29",
								"容器栏(大小箱子熔炉等) - 30",
								"容器栏(大小箱子熔炉等) - 31",
								"容器栏(大小箱子熔炉等) - 32",
								"容器栏(大小箱子熔炉等) - 33",
								"容器栏(大小箱子熔炉等) - 34",
								"容器栏(大小箱子熔炉等) - 35",
								"容器栏(大小箱子熔炉等) - 36",
								"容器栏(大小箱子熔炉等) - 37",
								"容器栏(大小箱子熔炉等) - 38",
								"容器栏(大小箱子熔炉等) - 39",
								"容器栏(大小箱子熔炉等) - 40",
								"容器栏(大小箱子熔炉等) - 41",
								"容器栏(大小箱子熔炉等) - 42",
								"容器栏(大小箱子熔炉等) - 43",
								"容器栏(大小箱子熔炉等) - 44",
								"容器栏(大小箱子熔炉等) - 45",
								"容器栏(大小箱子熔炉等) - 46",
								"容器栏(大小箱子熔炉等) - 47",
								"容器栏(大小箱子熔炉等) - 48",
								"容器栏(大小箱子熔炉等) - 49",
								"容器栏(大小箱子熔炉等) - 50",
								"容器栏(大小箱子熔炉等) - 51",
								"容器栏(大小箱子熔炉等) - 52",
								"容器栏(大小箱子熔炉等) - 53",
								"末影箱 - 0",
								"末影箱 - 1",
								"末影箱 - 2",
								"末影箱 - 3",
								"末影箱 - 4",
								"末影箱 - 5",
								"末影箱 - 6",
								"末影箱 - 7",
								"末影箱 - 8",
								"末影箱 - 9",
								"末影箱 - 10",
								"末影箱 - 11",
								"末影箱 - 12",
								"末影箱 - 13",
								"末影箱 - 14",
								"末影箱 - 15",
								"末影箱 - 16",
								"末影箱 - 17",
								"末影箱 - 18",
								"末影箱 - 19",
								"末影箱 - 20",
								"末影箱 - 21",
								"末影箱 - 22",
								"末影箱 - 23",
								"末影箱 - 24",
								"末影箱 - 25",
								"末影箱 - 26",
								"马 - 盔甲栏",
								"马 - 胸甲栏",
								"马 - 马鞍",
								"驴箱子 - 0",
								"驴箱子 - 1",
								"驴箱子 - 2",
								"驴箱子 - 3",
								"驴箱子 - 4",
								"驴箱子 - 5",
								"驴箱子 - 6",
								"驴箱子 - 7",
								"驴箱子 - 8",
								"驴箱子 - 9",
								"驴箱子 - 10",
								"驴箱子 - 11",
								"驴箱子 - 12",
								"驴箱子 - 13",
								"驴箱子 - 14",
								"村民 - 0",
								"村民 - 1",
								"村民 - 2",
								"村民 - 3",
								"村民 - 4",
								"村民 - 5",
								"村民 - 6",
								"村民 - 7"
                              };

        string[] villagerType = {
                                    "棕色，农民",
									"白色，书管",
									"紫色，神父",
									"黑色，铁匠",
									"白色，屠夫",
									"绿色，特殊"
                                };

        string[] villagerTypeEn = {
                                    "Brown, Farmer",
                                    "White, Librarian",
                                    "Purple, Fr.",
                                    "Black, Blacksmith",
                                    "White, Butcher",
                                    "Green, Special"
                                };

        string[] bannerColor = {
                                    "黑色",
									"红色",
									"绿色",
									"棕色",
									"蓝色",
									"紫色",
									"青色",
									"浅灰",
									"灰色",
									"粉色",
									"黄绿",
									"黄色",
									"淡蓝",
									"品红",
									"橙色",
									"白色"
                               };

        string[] bannerColorEn = {
                                    "Black",
                                    "Red",
                                    "Green",
                                    "Brown",
                                    "Blue",
                                    "Purple",
                                    "Cyan",
                                    "Light Gray",
                                    "Gray",
                                    "Pink",
                                    "Olivine",
                                    "Yellow",
                                    "Light Blue",
                                    "Magenta",
                                    "Orange",
                                    "White"
                               };

        string[] bannerType = {
                                "mc",
								"mr",
								"ss",
								"gra",
                                "gru",
								"tl",
								"tr",
								"bl",
								"br",
								"ls",
								"rs",
								"ts",
								"bs",
								"hh",
                                "hhb",
                                "vh",
                                "vhr",
								"dls",
								"drs",
								"cr",
								"ms",
								"cs",
								"tt",
								"bt",
								"ld",
								"rd",
                                "lud",
                                "rud",
								"tts",
								"bts",
								"flo",
								"bri",
								"sku",
								"cre",
                                "bo",
                                "cbo",
                                "sc",
                                "moj"
                              };

        private string[] bannerTypeStr = {
                                                "中心圆形",
												"中心菱形",
												"条纹形",
												"自上渐变",
												"自下渐变",
												"左上方块",
												"右上方块",
												"左下方块",
												"右下方块",
												"左侧边线",
												"右侧边线",
												"上行边线",
												"下行边线",
												"上半方形",
												"下半方形",
												"左半方形",
												"右半方形",
												"对角线（从右上角到左下角）",
												"对角线（从左下角到右上角）",
												"交叉线",
												"中平分线",
												"中垂线",
												"顶部三角",
												"底部三角",
												"左上三角",
												"右下三角",
												"左下三角",
												"右上三角",
												"顶部锯齿",
												"底部锯齿",
												"花束形",
												"墙砖形",
												"骷髅形",
												"爬行者形",
												"方框边",
												"波纹边",
												"十字",
												"Mojang"
                                            };

        private string[] bannerTypeStrEn = {
                                                "Circle in center - Roundel Banner",
                                                "Rhombus in center - Lozenge Banner",
                                                "Vertical pinstripes - Paly Banner",
                                                "Color at top - Gradient Banner",
                                                "Color at bottom - Base Gradient Banner",
                                                "Square in upper-left corner - Chief Dexter Canton Banner",
                                                "Square in upper-right corner - Chief Sinister Canton Banner",
                                                "Square in lower-left corner - Base Dexter Canton Banner",
                                                "Square in lower-right corner - Base Sinister Canton Banner",
                                                "Left third colored - Pale Dexter Banner",
                                                "Right third colored - Pale Sinister Banner",
                                                "Top third colored - Chief Fess Banner",
                                                "Bottom third colored - Base Fess Banner",
                                                "Top half colored - Per Fess Banner",
                                                "Bottom half colored - Per Fess Inverted Banner",
                                                "Left half colored - Per Pale Banner",
                                                "Right half colored - Per Pale Inverted Banner",
                                                "Line from upper-right to lower-left - Bend Sinister Banner",
                                                "Line from upper-left to lower-right - Bend Banner",
                                                "X shape - Saltire Banner",
                                                "Center horizontal line - Fess Banner",
                                                "Center vertical line - Pale Banner",
                                                "Triangle at top - Inverted Chevron Banner",
                                                "Triangle at bottom - Chevron Banner",
                                                "Upper-left half colored - Per Bend Sinister Banner",
                                                "Lower-right half colored - Per Bend Sinister Inverted Banner",
                                                "Lower-left half colored - Per Bend Inverted Banner",
                                                "Upper-right half colored - Per Bend Banner",
                                                "Scallop shapes at top - Chief Indented Banner",
                                                "Scallop shapes at bottom - Base Indented Banner",
                                                "Flower icon - Flower Charge Banner",
                                                "Brick pattern - Masoned Banner",
                                                "Skull and Crossbones - Skull Charge Banner",
                                                "Creeper face - Creeper Charge Banner",
                                                "Border - Bordure Banner",
                                                "Fancy border - Bordure Indented Banner",
                                                "Emblazons a cross - Cross Banner",
                                                "Mojang logo - Mojang Charge Banner"
                                            };


        private byte[,] tabBannerColorSel = {
                                                {25,25,25},
                                                {153,51,51},
                                                {102,127,51},
                                                {102,76,51},
                                                {51,76,178},
                                                {127,63,178},
                                                {76,127,153},
                                                {153,153,153},
                                                {76,76,76},
                                                {242,172,165},
                                                {172,204,25},
                                                {229,229,51},
                                                {102,153,216},
                                                {178,76,216},
                                                {216,127,51},
                                                {255,255,255}
                                            };//15*3

        private string[] mainStr = {
                                        "为什么戳我呢？",
										"很好玩吗_(:3」∠)_",
										"不知道你喜不喜欢我呢……",
										"也许是吧。",
										"哼。",
										"欸？",
										"擦擦口水啦！",
										"该睡觉了。",
										"不知道你会不会惊呆呢，哈哈o(^▽^)o",
										"嗯…也许是吧……",
										"我饿了！",
										"你好，我是MCH看板娘~",
										"什么？你不知道什么是看板娘？Emm……",
										"新界面好看吧？(●'◡'●)",
										"啊勒~你说什么？？",
										"不开心…",
										"还好吧。",
										"一个人呆在这里很无聊的……",
										"想出去玩玩。",
										"这里真安静呀~",
										"一个人都没有……",
										"感谢你来陪我o(^▽^)o",
										"卖萌是什么，可以吃吗？",
										"可以…哟。",
										"我的主人不会画画啦……",
										"我的外观可是主人定义好的哟！",
										"至少我觉得挺不错的。",
										"好啦，程序有问题的话欢迎反馈，点关于里的QQ就行了！",
										"MCH的话应该只会做原版的高级指令。",
										"说不定哟？"
                                   };

        private string[] scoreStr1 = {
                                        "< 请先选择本框并了解各类计分板命令后再继续 >",
										"/scoreboard objectives list",
										"/scoreboard objectives add",
										"/scoreboard objectives remove",
										"/scoreboard objectives setdisplay",
										"/scoreboard players set",
										"/scoreboard players add",
										"/scoreboard players remove",
										"/scoreboard players reset",
										"/scoreboard players list",
										"/scoreboard players enable",
										"/scoreboard players test",
										"/scoreboard players operation",
										"/scoreboard teams list",
										"/scoreboard teams add",
										"/scoreboard teams remove",
										"/scoreboard teams empty",
										"/scoreboard teams join",
										"/scoreboard teams leave",
										"/scoreboard teams option"
                                     };

        private string[] scoreStr2 = {
                                        "< 本例所为选择器附加参数的说明 >",
										"x",
										"y",
										"z",
										"dx",
										"dy",
										"dz",
										"r",
										"rm",
										"rx",
										"rxm",
										"ry",
										"rym",
										"m",
										"c",
										"l",
										"lm",
										"score_<name>",
										"score_<name>_min",
										"team",
										"name",
										"type",
										"id",
										"< 其他 >"
                                     };

        private string[] scoreStr3 = { 
                                        "< 本例所为方块/实体探测数据的说明 >",
                                        "/blockdata",
                                        "/testforblock",
                                        "/entitydata",
                                        "/testfor",
                                        "< 更多指令说明 >",
                                        "/clone",
                                        "/fill"
                                   };

        private string[] scoreStr4 = {
                                        "< 本例所为方块/实体数据的解析 >",
                                        "方块 - 头 | 玩家头 | IceLitty",
                                        "方块 - 花盆 | 带有茜草花",
                                        "方块 - 唱片机 | 带有自定义物品",
                                        "实体 - 物品 | 一本书的掉落物品状态",
                                        "实体 - 末影水晶 | 无修改的末地加血机",
                                        "< 以下为英文Wiki翻译 - 实体格式解析 >",
                                        "< 数据格式 >",
                                        "< 实体皆有的标签 >",
                                        "< 生物皆有的标签 >",
                                        "< 可以喂养和可以驯服的生物标签 >",
                                        "蝙蝠",//11
                                        "鸡",//12
                                        "爬行者",//13
                                        "末影龙",//14
                                        "末影人",//15
                                        "末影螨",//16
                                        "马",//17
                                        "恶魂",//18
                                        "远古守卫者",//19
                                        "史莱姆&岩浆史莱姆",//20
                                        "豹猫",//21
                                        "猪",//22
                                        "僵尸猪人",//23
                                        "兔子",//24
                                        "羊",//25
                                        "潜隐贝&潜隐弹",//26
                                        "骷髅",//27
                                        "村民",//28
                                        "铁傀儡",//29
                                        "凋零",//30
                                        "狼",//31
                                        "僵尸",//32
                                        "< 物品NBT格式 >",//33
                                        "< 抛射/弹射物NBT格式 >",//34
                                        "< 药水NBT格式 >",//35
                                        "弓箭&药水箭&发光箭",//36
                                        "末影龙&小&火焰弹&凋零头",//37
                                        "雪球&鸡蛋&末影珍珠&经验瓶&药水瓶",//38
                                        "掉落的实体",//39
                                        "经验珠",//40
                                        "< 所有的运输实体 >",//41
                                        "船",//42
                                        "运输矿车&动力矿车",//43
                                        "刷怪笼矿车&TNT矿车&漏斗矿车",//44
                                        "命令方块矿车",//45
                                        "点燃的TNT",//46
                                        "沙子&砂砾&龙蛋&铁砧&掉落沙",//47
                                        "范围药水效果云",//48
                                        "盔甲架",//49
                                        "画和展示框",//50
                                        "末影水晶",//51
                                        "烟花火箭",//52
                                        "附魔书",//53
                                        "方块实体",//54
                                        "旗帜",//55
                                        "信标",//56
                                        "酿造台",//57
                                        "箱子",//58
                                        "红石比较器",//59
                                        "命令方块",//60
                                        "投掷器&发射器",//61
                                        "EndGateway",//62
                                        "花盆",//63
                                        "熔炉",//64
                                        "漏斗",//65
                                        "刷怪笼",//66
                                        "音乐盒&唱片机",//67
                                        "活塞",//68
                                        "告示牌",//69
                                        "头",//70
										"书与笔-成书",
										"地图",
                                        "额外附赠 - 资源包模型解析 - 模型数据",
                                        "额外附赠 - 资源包模型解析 - 模型变体",
                                        "额外附赠 - 资源包模型解析 - 物品模型"
                                   };

        private int[] biomeIndex = { 
                                        -1,0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,127,128,129,130,131,132,133,134,140,149,151,155,156,157,158,160,161,162,163,164,165,166,167
                                   };

        private string[] biomeStr = {
                                        "<未加载>",
										"海洋",
										"草原",
										"沙漠",
										"峭壁",
										"森林",
										"针叶林",
										"沼泽",
										"河流",
										"下界",
										"天空",
										"冻洋",
										"冻河",
										"冰原",
										"冰山",
										"蘑菇岛",
										"蘑菇岛海岸",
										"沙滩",
										"沙漠山丘",
										"森林山丘",
										"针叶林山丘",
										"峭壁边缘",
										"丛林",
										"丛林山丘",
										"丛林边缘",
										"深海",
										"石滩",
										"寒冷沙滩",
										"桦木森林",
										"桦木森林山丘",
										"黑森林",
										"冷针叶林",
										"冷针叶林山丘",
										"大型针叶林",
										"大型针叶林山丘",
										"峭壁+",
										"热带草原",
										"热带高原",
										"平顶山",
										"平顶山高原 F",
										"平顶山高原",
                                        "虚空",
                                        "草原 M",
                                        "向日葵平原",
										"沙漠 M",
										"极端的山丘 M",
										"花的森林",
										"针叶林 M",
										"沼泽 M",
										"冰刺平原",
										"丛林 M",
										"丛林边缘 M",
										"白桦森林 M",
										"桦木森林 M",
										"黑森林 M",
										"冷针叶林 M",
										"红木森林",
										"红木山丘",
										"峭壁+ M",
										"热带草原 M",
										"热带高原 M",
										"平顶山（岩柱）",
										"平顶山高原 F M",
										"平顶山高原 M"
                                    };

        private string[] biomeStrEn = {
                                        "<Unload>",
                                        "Ocean",
                                        "Plains",
                                        "Desert",
                                        "Extreme Hills",
                                        "Forest",
                                        "Taiga",
                                        "Swampland",
                                        "River",
                                        "Hell",
                                        "The End",
                                        "Frozen Ocean",
                                        "Frozen River",
                                        "Ice Plains",
                                        "Ice Mountains",
                                        "Mushroom Island",
                                        "Mushroom Island Shore",
                                        "Beach",
                                        "Desert Hills",
                                        "Forest Hills",
                                        "Taiga Hills",
                                        "Extreme Hills Edge",
                                        "Jungle",
                                        "Jungle Hills",
                                        "Jungle Edge",
                                        "Deep Ocean",
                                        "Stone Beach",
                                        "Cold Beach",
                                        "Birch Forest",
                                        "Birch Forest Hills",
                                        "Roofed Forest",
                                        "Cold Taiga",
                                        "Cold Taiga Hills",
                                        "Mega Taiga",
                                        "Mega Taiga Hills",
                                        "Extreme Hills+",
                                        "Savanna",
                                        "Savanna Plateau",
                                        "Mesa",
                                        "Mesa Plateau F",
                                        "Mesa Plateau",
                                        "The Void",
                                        "Plains M",
                                        "Sunflower Plains",
                                        "Desert M",
                                        "Extreme Hills M",
                                        "Flower Forest",
                                        "Taiga M",
                                        "Swampland M",
                                        "Ice Plains Spikes",
                                        "Jungle M",
                                        "Jungle Edge M",
                                        "Birch Forest M",
                                        "Birch Forest Hills M",
                                        "Roofed Forest M",
                                        "Cold Taiga M",
                                        "Mega Spruce Taiga",
                                        "Redwood Taiga Hills M",
                                        "Extreme Hills+ M",
                                        "Savanna M",
                                        "Savanna Plateau M",
                                        "Mesa (Bryce)",
                                        "Mesa Plateau F M",
                                        "Mesa Plateau M"
                                    };

        private string[] uniColor = {
                                        "",
                                        @"\u00A70",
                                        @"\u00A71",
                                        @"\u00A72",
                                        @"\u00A73",
                                        @"\u00A74",
                                        @"\u00A75",
                                        @"\u00A76",
                                        @"\u00A77",
                                        @"\u00A78",
                                        @"\u00A79",
                                        @"\u00A7a",
                                        @"\u00A7b",
                                        @"\u00A7c",
                                        @"\u00A7d",
                                        @"\u00A7e",
                                        @"\u00A7f",
                                        @"\u00A7k",
                                        @"\u00A7l",
                                        @"\u00A7m",
                                        @"\u00A7n",
                                        @"\u00A7o",
                                        @"\u00A7r",
                                        ""
                                    };

        private string[] uniColorStr = {
                                        "无",
                                        "黑色",
                                        "深蓝色",
                                        "深绿色",
                                        "湖蓝色",
                                        "深红色",
                                        "紫色",
                                        "金色",
                                        "灰色",
                                        "深灰色",
                                        "蓝色",
                                        "绿色",
                                        "天蓝色",
                                        "红色",
                                        "粉色",
                                        "黄色",
                                        "白色",
                                        "随机字符",
                                        "粗体",
                                        "删除线",
                                        "下划线",
                                        "斜体",
                                        "重置文字样式",
                                        "换行请回车"
                                    };

        private string[] uniColorStrEn = {
                                        "None",
                                        "Black",
                                        "Dark Blue",
                                        "Dark Green",
                                        "Lake Blue",
                                        "Dark Red",
                                        "Purple",
                                        "Gold",
                                        "Gray",
                                        "Dark Gray",
                                        "Blue",
                                        "Green",
                                        "Sky Blue",
                                        "Red",
                                        "Pink",
                                        "Yellow",
                                        "White",
                                        "Random",
                                        "Bold",
                                        "Strikethrough",
                                        "Underline",
                                        "Italic",
                                        "Reset Format",
                                        "Use Enter to make New Line"
                                    };

        public string getUniColor(int index)
        {
            if (index < 0 || index > (uniColor.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                return uniColor[index];
            }
        }

        public string getUniColorStr(int index)
        {
            if (index < 0 || index > (uniColorStr.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                if (nowLang != "cn") { return uniColorStrEn[index]; } else { return uniColorStr[index]; }
            }
        }

        public int getUniColorStrCount() { return uniColorStr.Count(); }

        public int getBiomeID(int index)
        {
            if (index < 0 || index > (biomeIndex.Count() - 1))
            {
                return -1;
            }
            else
            {
                return biomeIndex[index];
            }
        }

        public string getBiomeStr(int index)
        {
            if (index < 0 || index > (biomeStr.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                if (nowLang != "cn") { return biomeStrEn[index]; } else { return biomeStr[index]; }
            }
        }

        public int getBiomeCount() { return biomeStr.Count(); }

        public string getScore1(int index)
        {
            if (index < 0 || index > (scoreStr1.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                return scoreStr1[index];
            }
        }

        public int getScore1Count() { return scoreStr1.Count(); }

        public string getScore2(int index)
        {
            if (index < 0 || index > (scoreStr2.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                return scoreStr2[index];
            }
        }

        public int getScore2Count() { return scoreStr2.Count(); }

        public string getScore3(int index)
        {
            if (index < 0 || index > (scoreStr3.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                return scoreStr3[index];
            }
        }

        public int getScore3Count() { return scoreStr3.Count(); }

        public string getScore4(int index)
        {
            if (index < 0 || index > (scoreStr4.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                return scoreStr4[index];
            }
        }

        public int getScore4Count() { return scoreStr4.Count(); }

        public string getMainStr(int index)
        {
            if (index < 0 || index > (mainStr.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                return mainStr[index];
            }
        }

        public int getMainStrCount() { return mainStr.Count(); }

        public byte[] getBannerColorArray(int index)
        {
            if (index < 0 || index > (tabBannerColorSel.GetLength(0) - 1))
            {
                return new byte[] { 0, 0, 0 };
            }
            else
            {
                return new byte[] { tabBannerColorSel[index, 0], tabBannerColorSel[index, 1], tabBannerColorSel[index, 2] };
            }
        }

        public string getBannerType(int index)
        {
            if (index < 0 || index > (bannerType.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                return bannerType[index];
            }
        }

        public string getBannerTypeStr(int index)
        {
            if (index < 0 || index > (bannerTypeStr.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                if (nowLang != "cn") { return bannerTypeStrEn[index]; } else { return bannerTypeStr[index]; }
            }
        }

        public int getBannerTypeCount() { return bannerTypeStr.Count(); }

        public string getBannerColorStr(int index)
        {
            if (index < 0 || index > (bannerColor.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                if (nowLang != "cn") { return bannerColorEn[index]; } else { return bannerColor[index]; }
            }
        }

        public int getBannerColorCount() { return bannerColor.Count(); }

        public string getVillagerType(int index)
        {
            if (index < 0 || index > (villagerType.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                if (nowLang != "cn") { return villagerTypeEn[index]; } else { return villagerType[index]; }
            }
        }

        public int getVillagerTypeCount() { return villagerType.Count(); }

        public string getSlot(int index)
        {
            if (index < 0 || index > (slotSel.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                return slotSel[index];
            }
        }

        public string getSlotStr(int index)
        {
            if (index < 0 || index > (slotSelStr.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                if (nowLang != "cn") { return slotSel[index]; } else { return slotSelStr[index]; }
            }
        }

        public int getSlotStrCount() { return slotSelStr.Count(); }

        public string getColor(int index)
        {
            if (index < 0 || index > (colorStr.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                return colorStr[index];
            }
        }

        public string getColorStr(int index) 
        {
            if (index < 0 || index > (colorString.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                if (nowLang != "cn") { return colorStr[index]; } else { return colorString[index]; }
            }
        }

        public int getColorStrCount() { return colorString.Count(); }

        public string getSignDirectionStr(int index) 
        {
            if (index < 0 || index > (signDirectionStr.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                if (nowLang != "cn") { return signDirectionStrEn[index]; } else { return signDirectionStr[index]; }
            }
        }

        public int getSignDirectionStrCount() { return signDirectionStr.Count(); }

        public string getFireworkTypeStr(int index)
        {
            if (index < 0 || index > (fireworkTypeStr.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                if (nowLang != "cn") { return fireworkTypeStrEn[index]; } else { return fireworkTypeStr[index]; }
            }
        }

        public int getFireworkTypeStrCount() { return fireworkTypeStr.Count(); }

        public string getParticle(int index)
        {
            if (index < 0 || index > (particleSel.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                return particleSel[index];
            }
        }

        public string getParticleStrEn(int index)
        {
            if (index < 0 || index > (particleStrEn.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                return particleStrEn[index];
            }
        }

        public string getParticleStrCn(int index)
        {
            if (index < 0 || index > (particleStrCn.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                if (nowLang != "cn") { return particleStrEn[index]; } else { return particleStrCn[index]; }
            }
        }

        public int getParticleStrCount() { return particleStrCn.Count(); }

        public string getEffect(int index, bool numberID)
        {
            if (numberID)
            {
                if (index < 0 || index > (effectSelID.Count() - 1))
                {
                    return "IndexError";
                }
                else
                {
                    return effectSelID[index];
                }
            }
            else
            {
                if (index < 0 || index > (effectSel.Count() - 1))
                {
                    return "IndexError";
                }
                else
                {
                    return effectSel[index];
                }
            }
        }

        public string getEffectStr(int index) 
        {
            if (index >= 0 && index < effectStr.Count())
            {
                if (nowLang != "cn") { return effectSel[index]; } else { return effectStr[index]; }
            }
            else
            {
                return "IndexError";
            }
        }

        public int getEffectStrCount() { return effectStr.Count(); }

        public string getAt(int index)
        {
            if (index < 0 || index > (atSel.Count() - 1))
            {
                return "IndexError";
            }
            else
            {
                return atSel[index];
            }
        }

        public string getAtNameList(int index) 
        {
            if (index >= 0 && index < atSelNameList.Count())
            {
                if (nowLang != "cn") { return atSel[index]; } else { return atSelNameList[index]; }
            }
            else
            {
                return "IndexError";
            }
        }

        public int getAtListCount() { return atSel.Count(); }

        public string getHideList(int index) 
        {
            if (index >= 0 && index < hideList.Count())
            {
                if (nowLang != "cn") { return hideListEN[index]; } else { return hideList[index]; }
            }
            else
            {
                return "IndexError";
            }
        }

        public int getHideListCount() { return hideList.Count(); }

        public string getItem(int index)
        {
            if (index >= 0 && index < itemSel.Count())
            {
                return itemSel[index];
            }
            else
            {
                return "IndexError";
            }
        }

        public string getItemNameList(int index) 
        {
            if (index >= 0 && index < itemNameList.Count())
            {
                if (nowLang != "cn") { return itemSel[index]; } else { return itemNameList[index]; }
            }
            else
            {
                return "IndexError";
            }
        }

        public int getItemNameListCount() { return itemNameList.Count(); }
    }
}
