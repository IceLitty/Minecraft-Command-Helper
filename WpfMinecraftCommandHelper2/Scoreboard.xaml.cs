using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// Scoreboard.xaml 的交互逻辑
    /// </summary>
    public partial class Scoreboard : MetroWindow
    {
        public Scoreboard()
        {
            InitializeComponent();
            AllSelData asd = new AllSelData();
            for (int i = 0; i < asd.getScore1Count(); i++)
            {
                tabScoreCommand.Items.Add(asd.getScore1(i));
            }
            for (int i = 0; i < asd.getScore2Count(); i++)
            {
                tabScoreAtVar.Items.Add(asd.getScore2(i));
            }
            for (int i = 0; i < asd.getScore3Count(); i++)
            {
                tabScoreData1.Items.Add(asd.getScore3(i));
            }
            for (int i = 0; i < asd.getScore4Count(); i++)
            {
                tabScoreData2.Items.Add(asd.getScore4(i));
            }
            tabScoreCommand.SelectedIndex = 0;
            tabScoreAtVar.SelectedIndex = 0;
            tabScoreData1.SelectedIndex = 0;
            tabScoreData2.SelectedIndex = 0;
        }

        private void tabScoreCommand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabScoreCommand.SelectedIndex == 1)
            {
                tabScoreBox.Text = "指令用法：/scoreboard objectives list\r\n\r\n列出所有的计分板项目。（可能数量众多，慎用）";
            }
            else if (tabScoreCommand.SelectedIndex == 2)
            {
                tabScoreBox.Text = "指令用法：/scoreboard objectives add <计分板名称> <计分依据> [显示名称]\r\n\r\n添加一个计分板项目。";
            }
            else if (tabScoreCommand.SelectedIndex == 3)
            {
                tabScoreBox.Text = "指令用法：/scoreboard objectives remove <计分板名称>\r\n\r\n删除一个计分板项目。";
            }
            else if (tabScoreCommand.SelectedIndex == 4)
            {
                tabScoreBox.Text = "指令用法：/scoreboard objectives setdisplay <计分板显示位置> [计分板名称]\r\n\r\n设置计分板的分数显示位置，如不填写名称参数则移除该位置所有显示。";
            }
            else if (tabScoreCommand.SelectedIndex == 5)
            {
                tabScoreBox.Text = "指令用法：/scoreboard players set <选择器-玩家名> <计分板名称> <计分板内数值> [NBT标签]\r\n\r\n设置选择器选中的玩家指定计分板内的分数。（数值-2147483648-2147483647）";
            }
            else if (tabScoreCommand.SelectedIndex == 6)
            {
                tabScoreBox.Text = "指令用法：/scoreboard players add <选择器-玩家名> <计分板名称> <计分板内数值> [NBT标签]\r\n\r\n增加选择器选中的玩家指定计分板内的分数。（数值0-2147483647）";
            }
            else if (tabScoreCommand.SelectedIndex == 7)
            {
                tabScoreBox.Text = "指令用法：/scoreboard players remove <选择器-玩家名> <计分板名称> <计分板内数值> [NBT标签]\r\n\r\n减少选择器选中的玩家指定计分板内的分数。（数值0-2147483647）";
            }
            else if (tabScoreCommand.SelectedIndex == 8)
            {
                tabScoreBox.Text = "指令用法：/scoreboard players reset <选择器-玩家名> [计分板名称]\r\n\r\n重置选择器选中的玩家指定的计分板分数，如不指定计分板分数则清除该玩家所有计分板分数。";
            }
            else if (tabScoreCommand.SelectedIndex == 9)
            {
                tabScoreBox.Text = "指令用法：/scoreboard players list\r\n\r\n列出所有计分板上的玩家。";
            }
            else if (tabScoreCommand.SelectedIndex == 10)
            {
                tabScoreBox.Text = "指令用法：/scoreboard players enable <选择器-玩家名> <触发器>\r\n\r\n允许玩家使用/trigger命令增加/设置自己的某计分板分数。";
            }
            else if (tabScoreCommand.SelectedIndex == 11)
            {
                tabScoreBox.Text = "指令用法：/scoreboard players test <选择器-玩家名> <计分板名称> <最小值> <最大值>\r\n\r\n检测玩家指定计分板的分数是否在指定范围内，包含最大值和最小值。";
            }
            else if (tabScoreCommand.SelectedIndex == 12)
            {
                tabScoreBox.Text = "指令用法：/scoreboard players operation <选择器A-玩家名> <计分板名称A> <操作式> <选择器B-玩家名> <计分板名称B>\r\n\r\n用数学方式来判断、更改计分板内分数。\r\n\r\n操作式解释如下：\r\n+=\tA=A+B（A等于A与B的和）\r\n-=\tA=A-B（A等于A减去B的差）\r\n*=\tA=A*B（A等于A于B的乘积）\r\n/=\tA=A/B（A等于A除以B的商）\r\n%=\tA=A/B...（求A除以B的余数）\r\n=\tA=B（将B的值赋给A）\r\n<\tA=Math.Min(A,B)（如果B比A小则赋值给A）\r\n>\tA=Math.Max(A,B)（如果B比A大则赋值给A）\r\n><\tA<->B（交换A与B的值，唯一能改变B的值的操作式）\r\n\r\n*选择器可由星号“*”来选定所有玩家";
            }
            else if (tabScoreCommand.SelectedIndex == 13)
            {
                tabScoreBox.Text = "指令用法：/scoreboard teams list\r\n\r\n列出计分板上所有的组。";
            }
            else if (tabScoreCommand.SelectedIndex == 14)
            {
                tabScoreBox.Text = "指令用法：/scoreboard teams add <队伍名称> [显示的队伍名称]\r\n\r\n新建一个计分板队伍。（请不要在原版内使用Bukkit插件所赋予的彩色代码！是无效的！）";
            }
            else if (tabScoreCommand.SelectedIndex == 15)
            {
                tabScoreBox.Text = "指令用法：/scoreboard teams remove <队伍名称>\r\n\r\n删除一个计分板队伍。";
            }
            else if (tabScoreCommand.SelectedIndex == 16)
            {
                tabScoreBox.Text = "指令用法：/scoreboard teams empty <队伍名称>\r\n\r\n将计分板队伍内的所有玩家移除队伍。";
            }
            else if (tabScoreCommand.SelectedIndex == 17)
            {
                tabScoreBox.Text = "指令用法：/scoreboard teams join <队伍名称>\r\n\r\n玩家指令。加入指定名称的计分板队伍，并非为显示名称！";
            }
            else if (tabScoreCommand.SelectedIndex == 18)
            {
                tabScoreBox.Text = "指令用法：/scoreboard teams leave\r\n\r\n玩家指令。退出当前计分板队伍。";
            }
            else if (tabScoreCommand.SelectedIndex == 19)
            {
                tabScoreBox.Text = "指令用法：/scoreboard teams option <队伍名称> <设置项目> <设置的值>\r\n\r\n针对指定队伍设定各项设置。\r\n\r\n设置项目如下：\r\n\r\ncolor 设置颜色，颜色包含：\r\n\tblack\t\t黑色\r\n\tdark_blue\t\t深蓝\r\n\tdark_green\t深绿\r\n\tdark_aqua\t湛蓝\r\n\tdark_red\t\t深红\r\n\tdark_purple\t深紫\r\n\tglod\t\t金色\r\n\tgray\t\t灰色\r\n\tdark_gray\t\t深灰\r\n\tblue\t\t蓝色\r\n\tgreen\t\t绿色\r\n\taqua\t\t青色\r\n\tred\t\t红色\r\n\tlight_purple\t亮紫\r\n\tyellow\t\t黄色\r\n\twhite\t\t白色\r\n\treset\t\t清除\r\n\t共16种颜色，1种额外功能。\r\n\r\nfriendlyFire 设置友军伤害，值为true或false，默认为true，默认状态下该组成员可互相造成伤害，当设为false后不可造成任何伤害。\r\n\r\nseeFriendlyInvisibles 设置是否可见同队伍隐身效果。当设为true后，同队伍的玩家隐身时可看见半透明的外形，反之亦然。\r\n\r\nnametagVisibility 设置指定队伍的玩家头顶上的名称标签是否隐藏，值如下：\r\n\talways 始终显示，默认。\r\n\tnever 永不显示。\r\n\thideForOtherTeams 对其他队伍隐藏。\r\n\thideForOwnTeam 只对本组隐藏。\r\n\r\ndeathMessageVisibility 设置指定队伍的玩家死亡信息隐藏，值同上。";
            }
            else if (tabScoreCommand.SelectedIndex == 20)
            {
                tabScoreBox.Text = "格式\r\n\ttrigger <对象> <add|set> <值>\r\n参数\r\n\t对象\r\n\t\t计分板对象\r\n\tadd\r\n\t\t将值加入计分板对象的原值中\r\n\tset\r\n\t\t将值赋进计分板对象的原值中\r\n";
            }
            else if (tabScoreCommand.SelectedIndex == 21)
            {
                tabScoreBox.Text = "stats指令可更新计分板对象分数或其他指令\r\n\r\n格式\r\n\tstats block <x> <y> <z> clear <状态>\r\n\tstats block <x> <y> <z> set <状态> <选择器> <对象>\r\n\tstats entity <选择器2> clear <状态>\r\n\tstats entity <选择器2> set <状态> <选择器> <对象>\r\n参数\r\n\tx y z\r\n\t\t方块坐标\r\n\t状态\r\n\t\t可以是以下几种：\r\n\t\t\tAffectedBlocks\t\t返回该指令会影响到多少方块\r\n\t\t\tAffectedEntities\t返回该指令会影响到多少实体\r\n\t\t\tAffectedItems\t\t返回该指令会影响到多少物品\r\n\t\t\tQueryResult\t\t\t返回该指令结果\r\n\t\t\tSuccessCount\t\t返回该指令成功次数\r\n\t选择器\r\n\t\t此处只有玩家名或目标选择器才能获得有用的结果，当然玩家名在这里可以是假的，不一定真实存在\r\n\t选择器2\r\n\t\t必须为玩家名或目标选择器\r\n\t对象\r\n\t\t计分板对象名\r\n举例\r\n\t离位于0,64,0的方块最近的玩家如果有任何执行成功就更新至计分板对象MyObj\r\n\t\tstats block 0 64 0 set QueryResult @p MyObj\r\n\t停止位于0,64,0的方块更新计分板对象执行成功的计数\r\n\t\tstats block 0 64 0 clear SuccessCount\r\n\t给最近的凋零骷髅更新受它影响的方块至计分板对象NumBlocks上的#FakePlayer玩家\r\n\t\tstats entity @e[type=WitherSkull,c=1] set AffectedBlocks #FakePlayer NumBlocks\r\n";
            }
            else
            {
                tabScoreBox.Text = "";
            }
        }

        private void tabScoreAtVar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabScoreAtVar.SelectedIndex == 1)
            {
                tabScoreBox.Text = "选择器举例：@p[x=0]\r\n\r\nx=0指的是以某个点为中心搜索，其中x的坐标为0。";
            }
            else if (tabScoreAtVar.SelectedIndex == 2)
            {
                tabScoreBox.Text = "选择器举例：@p[y=0]\r\n\r\ny=0指的是以某个点为中心搜索，其中y的坐标为0。";
            }
            else if (tabScoreAtVar.SelectedIndex == 3)
            {
                tabScoreBox.Text = "选择器举例：@p[z=0]\r\n\r\nz=0指的是以某个点为中心搜索，其中z的坐标为0。";
            }
            else if (tabScoreAtVar.SelectedIndex == 4)
            {
                tabScoreBox.Text = "选择器举例：@p[dx=5]\r\n\r\ndx=5指的是以设定坐标点后x轴偏移5格。";
            }
            else if (tabScoreAtVar.SelectedIndex == 5)
            {
                tabScoreBox.Text = "选择器举例：@p[dy=5]\r\n\r\ndy=5指的是以设定坐标点后y轴偏移5格。";
            }
            else if (tabScoreAtVar.SelectedIndex == 6)
            {
                tabScoreBox.Text = "选择器举例：@p[dz=5]\r\n\r\ndz=5指的是以设定坐标点后z轴偏移5格。";
            }
            else if (tabScoreAtVar.SelectedIndex == 7)
            {
                tabScoreBox.Text = "选择器举例：@p[r=10]\r\n\r\nr=10指的是设定坐标点后（如没设定则坐标点为命令方块本身）在半径为10的范围内进行选择。";
            }
            else if (tabScoreAtVar.SelectedIndex == 8)
            {
                tabScoreBox.Text = "选择器举例：@p[rm=1]\r\n\r\nrm=1指的是设定坐标点后（如没设定则坐标点为命令方块本身）在半径为1的范围外进行选择。";
            }
            else if (tabScoreAtVar.SelectedIndex == 9)
            {
                tabScoreBox.Text = "选择器举例：@p[rx=5]\r\n\r\nrx=5指的是设定坐标点后（如没设定则坐标点为命令方块本身）在x轴半径为5的范围内进行选择。（可选负值所以没有rz、rzm参数）";
            }
            else if (tabScoreAtVar.SelectedIndex == 10)
            {
                tabScoreBox.Text = "选择器举例：@p[rxm=1]\r\n\r\nrxm=1指的是设定坐标点后（如没设定则坐标点为命令方块本身）在x轴半径为1的范围外进行选择。（可选负值所以没有rz、rzm参数）";
            }
            else if (tabScoreAtVar.SelectedIndex == 11)
            {
                tabScoreBox.Text = "选择器举例：@p[ry=5]\r\n\r\nry=5指的是设定坐标点后（如没设定则坐标点为命令方块本身）在y轴半径为5的范围内进行选择。";
            }
            else if (tabScoreAtVar.SelectedIndex == 12)
            {
                tabScoreBox.Text = "选择器举例：@p[rym=1]\r\n\r\nrym=1指的是设定坐标点后（如没设定则坐标点为命令方块本身）在y轴半径为1的范围外进行选择。";
            }
            else if (tabScoreAtVar.SelectedIndex == 13)
            {
                tabScoreBox.Text = "选择器举例：@p[m=0/1/2/3]\r\n\r\nm=？指的是在玩家的指定模式下再进行选择。（0为生存模式，1为创造模式，2为冒险模式，3为旁观模式）";
            }
            else if (tabScoreAtVar.SelectedIndex == 14)
            {
                tabScoreBox.Text = "选择器举例：@a[c=1]\r\n\r\nc=1指的是搜索到玩家的数量为1个，而用于@a、@e、@r都是非单个结果选择器，c=1可以使搜索结果为1个，@p就是@a[c=1]，另外c的值为负值的时候是从最远的地方开始进行搜索，例如@p[r=500,c=-1]可以让命令方块在半径500的范围内选择最远的那个玩家。";
            }
            else if (tabScoreAtVar.SelectedIndex == 15)
            {
                tabScoreBox.Text = "选择器举例：@p[l=50]\r\n\r\nl=50指的是在等级50以下的玩家中再进行搜索。（包含最大值）";
            }
            else if (tabScoreAtVar.SelectedIndex == 16)
            {
                tabScoreBox.Text = "选择器举例：@p[lm=20]\r\n\r\nlm=20指的是在等级20以上的玩家中再进行搜索。（包含最小值）";
            }
            else if (tabScoreAtVar.SelectedIndex == 17)
            {
                tabScoreBox.Text = "选择器举例：@p[score_ABC=50]\r\n\r\nscore_ABC=50指的是在ABC这个计分板中寻找分数最大为50的玩家。（包含最大值）";
            }
            else if (tabScoreAtVar.SelectedIndex == 18)
            {
                tabScoreBox.Text = "选择器举例：@p[score_ABC_min=20]\r\n\r\nscore_ABC_min=20指的是在ABC这个计分板中寻找分数至少为20的玩家。（包含最小值）";
            }
            else if (tabScoreAtVar.SelectedIndex == 19)
            {
                tabScoreBox.Text = "选择器举例：@p[team=ABC]\r\n\r\nteam=ABC指的是在ABC这个计分板队伍中寻找玩家。";
            }
            else if (tabScoreAtVar.SelectedIndex == 20)
            {
                tabScoreBox.Text = "选择器举例：@p[name=IceLitty]\r\n\r\nname=IceLitty指的是寻找名字为IceLitty的玩家。";
            }
            else if (tabScoreAtVar.SelectedIndex == 21)
            {
                tabScoreBox.Text = "选择器举例：@e[type=Player]\r\n\r\ntype=Player指的是寻找玩家这一类型的实体。";
            }
            else if (tabScoreAtVar.SelectedIndex == 22)
            {
                tabScoreBox.Text = "选择器举例：@e[id=2147483647]\r\n\r\nid=2147483647指的是寻找uuid为2147483647的实体，在summon命令里可以自定义uuid，范围从-2147483648到2147483647。";
            }
            else if (tabScoreAtVar.SelectedIndex == 23)
            {
                tabScoreBox.Text = "特殊说明、举例：\r\n\r\n例如@e[type=!Player]则可以搜索到非玩家的实体，@e[name=!IceLitty]则可以搜索名称不为IceLitty的实体。\r\n\r\n@a、p、r都只能选择玩家实体，@e除外。\r\n\r\n如果前四个参数分别是x、y、z、r的时候可以省略标签直接写值，例如@e[1,3,2,5,type=Player]则是选择坐标在(1,3,2)处，半径为5的范围内搜索玩家。";
            }
            else if (tabScoreAtVar.SelectedIndex == 24)
            {
                tabScoreBox.Text = "选择器举例：@e[tag=tag1]\r\n\r\n可以选定所有含有{Tags:[{\"tag1\"}]}NBT标签的实体。";
            }
            else
            {
                tabScoreBox.Text = "";
            }
        }

        private void tabScoreData1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabScoreData1.SelectedIndex == 1)
            {
                tabScoreBox.Text = "我们可以使用/blockdata ~ ~-1 ~ {} 命令来查看下方方块的数据标签，具体举例在下一个选择框中讲到。";
            }
            else if (tabScoreData1.SelectedIndex == 2)
            {
                tabScoreBox.Text = "/testforblock <X> <Y> <Z> <方块名> <Meta值> [NBT标签]\r\n\r\n这则命令则可用于检测XYZ坐标的方块和此命令里阐述的方块形态是否一致。";
            }
            else if (tabScoreData1.SelectedIndex == 3)
            {
                tabScoreBox.Text = "我们还可以用/entitydata @e[r=1] {} 来探测命令方块半径1格内的实体的数据标签，具体举例在下一个选择框中讲到。";
            }
            else if (tabScoreData1.SelectedIndex == 4)
            {
                tabScoreBox.Text = "/testfor <实体> [NBT标签]\r\n\r\n这则命令是用于探测任何实体的，同时也可以检测该实体的数据标签是否和命令中阐述的一致。";
            }
            else if (tabScoreData1.SelectedIndex == 5)
            {
                tabScoreBox.Text = "全程自翻转译，有误请提出：\r\n http://minecraft.gamepedia.com/Commands";
            }
            else if (tabScoreData1.SelectedIndex == 6)
            {
                tabScoreBox.Text = "格式\r\n\tclone <x1> <y1> <z1> <x2> <y2> <z2> <x> <y> <z> [判定模式] [克隆模式] [方块名]\r\n参数\r\n\tx1 y1 z1 x2 y2 z2\r\n\t\t定义区间\r\n\tx y z\r\n\t\t粘贴的点，始终为西北方最下层的点。\r\n\t判定模式\r\n\t\tfiltered\t只复制和方块名相同的方块\r\n\t\tmasked\t\t复制非空气方块\r\n\t\treplace\t\t全部复制\r\n\t克隆模式\r\n\t\tforce\t\t即使和复制区域有重叠也强制复制\r\n\t\tmove\t\t将复制区域移过去，只有被移除的地方会被空气方块替换\r\n\t\tnormal\t\t正常复制\r\n\t方块名\r\n\t\t例minecraft:stone\r\n";
            }
            else if (tabScoreData1.SelectedIndex == 7)
            {
                tabScoreBox.Text = "格式\r\n\tfill <x1> <y1> <z1> <x2> <y2> <z2> <方块名> [Meta值] [旧方块处理] [NBT标签]\r\n\tfill指令同样可有替换方块的功能：\r\n\tfill <x1> <y1> <z1> <x2> <y2> <z2> <方块名> <Meta值> replace [要替换成的方块名] [要替换成的Meta值]\r\n参数\r\n\tx1 y1 z1 x2 y2 z2\r\n\t\t选择区域\r\n\t方块名\r\n\tMeta值\r\n\t要替换成的方块名、Meta值\r\n\t旧方块处理\r\n\t\tdestroy\t使用破坏方块的方法，会掉落正常掉落的方块\r\n\t\thollow\t仅替换掉外围一圈的方块，内部用空气代替\r\n\t\tkeep\t仅替换掉空气方块\r\n\t\toutline\t仅替换掉外围一圈的方块，内部不处理\r\n\t\treplace\t默认选项，替换掉全部方块包括空气，方块不掉落\r\n\tNBT标签\r\n\t\t例如{CustomName:Fred}\r\n举例\r\n\t将指定区域全部的橙色染色硬化粘土替换成金块\r\n\t\t/fill 52 63 -1516 33 73 -1536 minecraft:gold_block 0 replace minecraft:stained_hardened_clay 1\r\n\t将7x7x3区域内直接换成水\r\n\t\t/fill ~-3 ~-3 ~-3 ~3 ~-1 ~3 minecraft:water 0\r\n\t创建一个围绕玩家的木板小盒子\r\n\t\t/fill ~-3 ~ ~-4 ~3 ~4 ~4 minecraft:planks 2 hollow\r\n";
            }
            else if (tabScoreData1.SelectedIndex == 8)
            {
                tabScoreBox.Text = "格式\r\n\tachievement <give|take> <成就名|*> [玩家名]\r\n参数\r\n\t成就名\r\n\t\t游戏内tab键可补全，格式如achievement.成就名\r\n\t\t* 代表全成就\r\n\t玩家名\r\n\t\t可以是玩家名或选择器，如果没定义的话则是命令执行者，该命令在命令方块中不可无此参数执行\r\n\t举例\r\n\t\t给自己获得Overkill成就\r\n\t\t\tachievement give achievement.overkill\r\n\t\t给Alice获得TakingInventory成就\r\n\t\t\tachievement give achievement.openInventory Alice\r\n\t\t移除所有玩家所有成就\r\n\t\t\tachievement take * @a\r\n";
            }
            else if (tabScoreData1.SelectedIndex == 9)
            {
                tabScoreBox.Text = "格式\r\n\tclear [玩家名] [物品名] [Meta值] [最大清除数量] [NBT标签]\r\n参数\r\n\t玩家名\r\n\t\t可以是玩家名或选择器，如果没定义的话则是命令执行者，该命令在命令方块中不可无此参数执行\r\n\t物品名\r\n\t\t要清除的物品，如果没定义则清空选择玩家的全部背包\r\n\tMeta值\r\n\t\t要清除的物品Meta值，如果为-1或没定义则清空所有指定的物品，不判定Meta值\r\n\t最大清除数量\r\n\t\t最大清楚物品的数量，如果为-1或没定义则最大限度的清空物品，如果为0则不清除任何物品，但会有执行指令成功的判定，可以以此来制作冒险地图判断玩家背包是否有此物品\r\n\tNBT标签\r\n\t\t物品的NBT标签，例如“{display:{Name:Fred}}”\r\n举例\r\n\t清除你的物品\r\n\t\tclear\r\n\t清除Alice的物品\r\n\t\tclear Alice\r\n\t清除Alice背包中的羊毛\r\n\t\tclear Alice minecraft:wool\r\n\t清除Alice背包中橙色羊毛\r\n\t\tclear Alice minecraft:wool 1\r\n\t清除最近的玩家背包中带有锋利I附魔的金剑，无视数量和Meta/Damage值\r\n\t\tclear @p minecraft:golden_sword -1 -1 {ench:[{id:16s,lvl:1s}]}\r\n";
            }
            else if (tabScoreData1.SelectedIndex == 10)
            {
                tabScoreBox.Text = "格式\r\n\texecute <实体> <x> <y> <z> <指令>\r\n\t或含有检测方块指令\r\n\texecute <实体> <x> <y> <z> detect <x2> <y2> <z2> <方块名> <数据值> <指令>\r\n参数\r\n\t实体\r\n\t\t使用选择器来选择实体，如果选择了多个实体，每个实体都会执行一次判断/指令\r\n\tx y z\r\n\t\t选择实体后在实体的什么位置执行指令，也可以是实际坐标，但必须在-30000000到30000000之间的值\r\n\t指令\r\n\t\t执行的指令\r\n\tx2 y2 z2\r\n\t\t检测实体的指定位置是什么方块，也可以是实际坐标是什么方块，同上\r\n\t方块名和数据值\r\n\t\t同上\r\n举例\r\n\t在僵尸处召唤落雷\r\n\t\texecute @e[type=Zombie] ~ ~ ~ summon LightningBolt\r\n\t如果僵尸踩在任何种类的沙子上，召唤落雷\r\n\t\texecute @e[type=Zombie] ~ ~ ~ detect ~ ~-1 ~ minecraft:sand -1 summon LightningBolt\r\n\t当世界中至少有10种实体时，在离第10个实体最近的玩家处召唤爬行者\r\n\t\texecute @e[c=10] ~ ~ ~ execute @p ~ ~ ~ summon Creeper\r\n";
            }
            else if (tabScoreData1.SelectedIndex == 11)
            {
                tabScoreBox.Text = "格式\r\n\tgamerule <规则名> [值]\r\n参数\r\n\t规则名\r\n\t\t名称\t\t\t\t解释\t\t\t\t\t默认值\r\n\t\tcommandBlockOutput\t\t命令方块是否输出到聊天栏\t\ttrue\r\n\t\tdisableElytraMovementCheck\t服务端测速是否不检测滑翔翼\t\tfalse\r\n\t\tdoDaylightCycle\t\t\t时间是否流动\t\t\t\ttrue\r\n\t\tdoEntityDrops\t\t\t实体是否掉落\t\t\t\ttrue\r\n\t\tdoFireTick\t\t\t火焰是否蔓延\t\t\t\ttrue\r\n\t\tdoMobLoot\t\t\t生物是否掉落\t\t\t\ttrue\r\n\t\tdoMobSpawning\t\t\t生物是否自然生成\t\t\ttrue\r\n\t\tdoTileDrops\t\t\t方块是否掉落\t\t\t\ttrue\r\n\t\tkeepInventory\t\t\t玩家死亡是否保留背包\t\t\tfalse\r\n\t\tlogAdminCommands\t\t是否把Admin指令记录进日志\t\ttrue\r\n\t\tmobGriefing\t\t\t生物*是否破坏方块\t\t\ttrue\r\n\t\tnaturalRegeneration\t\t玩家是否在满饥饿下自然回血*\t\ttrue\r\n\t\trandomTickSpeed\t\t\t随机Tick影响*\t\t\t\t3\r\n\t\treducedDebugInfo\t\t减少F3界面显示的内容\t\t\tfalse\r\n\t\tsendCommandFeedback\t\t显示命令反馈\t\t\t\ttrue\r\n\t\tshowDeathMessages\t\t显示死亡信息\t\t\t\ttrue\r\n\t\tspawnRadius\t\t\tSpawn范围\t\t\t\t10\r\n\t\tspectatorsGenerateChunks\t\t观察者视角生成区块的范围\t\ttrue\r\n\t*这里的生物是指爬行者、僵尸、末影人、恶魂、凋零、末影龙、兔子、羊、村民\r\n\t*自然回血不指效果影响的回血，例如金苹果，自然回复的状态等\r\n\t*随机Tick如果为0则20Ticks=1秒，默认为3\r\n\t值\r\n\t\t设置对应规则的值\r\n举例\r\n\t停止昼夜交替\r\n\t\tgamerule doDaylightCycle false\r\n\t停止自然回血\r\n\t\tgamerule naturalRegeneration false\r\n\t定义新规则MyNewRule并值为10\r\n\t\tgamerule MyNewRule 10\r\n";
            }
            else if (tabScoreData1.SelectedIndex == 12)
            {
                tabScoreBox.Text = "格式\r\n\tplaysound <声音> <源> <玩家名> [x] [y] [z] [音量] [音调] [最小音量]\r\n参数\r\n\t声音\r\n\t\t在资源包或mc本体的sounds.json内定义，例如mob.pig.say\r\n\t源\r\n\t\t必须是master、music、record、weather、block、hostile、neutral、player、ambient或voice\r\n\t玩家名\r\n\t\t能听到声音的玩家，必须是玩家名或选择器\r\n\tx y z\r\n\t\t播放声音的坐标位置\r\n\t音量\r\n\t\t声音在多远距离内可以听见，必须大于0.0。当值小于1.0时，声音显得小并传播距离短，值大于1.0时，声音并不会变的更大但是能传播的更远。为1.0时范围是16个方块，相乘计算。\r\n\t音调\r\n\t\t必须为0.0和2.0之间，默认1.0。\r\n\t最小音量\r\n\t\t必须为0.0和1.0之间。\r\n";
            }
            else if (tabScoreData1.SelectedIndex == 13)
            {
                tabScoreBox.Text = "格式\r\n\tstopsound <玩家名> [源] [声音]\r\n参数\r\n\t玩家名\r\n\t\t必须是玩家名或选择器\r\n\t源\r\n\t\t必须是master、music、record、weather、block、hostile、neutral、player、ambient或voice\r\n\t声音\r\n\t\t要停止播放的声音，例如mob.pig.say\r\n";
            }
            else if (tabScoreData1.SelectedIndex == 14)
            {
                tabScoreBox.Text = "格式\r\n\ttp [目标玩家] <目的玩家>\r\n\ttp [目的玩家] <x> <y> <z> [<yaw> <pitch>]\r\n\tteleport <目标实体> <x> <y> <z> [<y-rot> <x-rot>]\r\n参数\r\n\t目标玩家\r\n\t\t将A玩家tp至B玩家处，目标玩家为A玩家，目的玩家为B玩家\r\n\t目的玩家\r\n\t\t将自己tp至B玩家处，目的玩家为B玩家\r\n\t目的实体\r\n\t\t将B实体tp至指定坐标处\r\n\tx y z\r\n\t\t坐标\r\n\tyaw y-rot\r\n\t\t-180.0为正北，-90.0为正东，0.0为正南，90.0为正西，可用~符代指保留原方向\r\n\tpitch x-rot\r\n\t\t-90.0为正上，90.0为正下，可用~符代指保留原方向\r\n";
            }
            else
            {
                tabScoreBox.Text = "";
            }
        }

        private void tabScoreData2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabScoreData2.SelectedIndex == 1)
            {
                //方块 - 头 | 玩家头 | IceLitty
                tabScoreBox.Text = "实例：\r\n{\r\n    Owner:{\r\n        Id:\" -Player's UUID- \",\r\n        Properties:{\r\n            textures:[\r\n                0:{\r\n                    Value:\" -Base64 Encode- \",\r\n                },\r\n            ],\r\n        },\r\n        Name:\"IceLitty\",\r\n    },\r\n    Rot:12b,\r\n    x:-223,\r\n    y:67,\r\n    z:341,\r\n    id:\"Skull\",\r\n    SkullType:3b,\r\n}\r\n\r\n玩家头共分为{Owner,Rot,x,y,z,id,SkullType}这7个大类，Owner里所包含的是头的信息，Rot则是旋转角度，xyz是这个方块所在的坐标，id则是指方块的类型，SkullType是头方块特有的属性，3b为玩家头。\r\n\r\nOwner里再细分，分为{Id,Properties,Name}3大类，Id为玩家的UUID，规律是8+4+4+12位数字和小写字母的混合，正版由Mojang生成UUID，一个玩家只能拥有一个UUID，不可改变。Properties为头的属性，Name则是这个玩家的名称。\r\n\r\n继续细分，Properties分为{textures}这个数组，其中第0位里保存着一个名为Value的值，这个值的格式为一个base64编码后的数值，解码后为如下字符：\r\n\r\n{\r\n    \"timestamp\": -Value- ,\r\n    \"profileId\":\" -Value- \",\r\n    \"profileName\":\"IceLitty\",\r\n    \"textures\":{\r\n        \"SKIN\":{\r\n            \"url\":\" -Skin URL- \",\r\n            \"metadata\":{\r\n                \"model\":\"slim\"\r\n            }\r\n        }\r\n    }\r\n}\r\n\r\n其中timestamp和profileId以及url因为隐私问题均已隐藏值。\r\n\r\nprofileId为玩家profile的Id序列号，可由正版启动器获取到。\r\n\r\nprofileName为玩家profile对应的玩家名，同可又正版启动器获取到。\r\n\r\ntextures/SKIN/url为玩家的完整皮肤的地址，由Mojang提供。\r\n\r\ntextures/SKIN/metadata/model为玩家皮肤是粗胳膊还是细胳膊的标志，如上，细胳膊的值为slim，粗胳膊则没有这项键。\r\n\r\ntextures/CAPE则是玩家的披风，同理。";
            }
            else if (tabScoreData2.SelectedIndex == 2)
            {
                //方块 - 花盆 | 带有茜草花
                tabScoreBox.Text = "实例：\r\n{\r\n    Item:\"minecraft:red_flower\",\r\n    x:-223,\r\n    y:67,\r\n    z:341,\r\n    Data:3,\r\n    id:\"FlowerPot\",\r\n}\r\n\r\n花盆里的就简单多了，分{Item,x,y,z,Data,id}6类，xyz自然是指方块的坐标，id也是指方块的类型，那么Data是什么呢，就是Meta附加值，因为Item是red_flower的时候，是有很多种花都是这个名称的，那么就要用Data来区分具体是哪一种花了，Data为3b的时候是茜草花。";
            }
            else if (tabScoreData2.SelectedIndex == 3)
            {
                //方块 - 唱片机 | 带有自定义物品
                tabScoreBox.Text = "实例：\r\n{\r\n    x:-223,\r\n    y:67,\r\n    z:341,\r\n    id:\"RecordPlayer\",\r\n    RecordItem:{\r\n        id:\"minecraft:glass\",\r\n        Count:100b,\r\n        tag:{\r\n            ench:[],\r\n            HideFlags:0,\r\n        },\r\n        Damage:0s,\r\n    },\r\n}\r\n\r\n唱片机的实例，物品当然是用/setblock命令来塞进去的，那么包含了如下结构：\r\n\r\n{x,y,z,id,RecordItem}5种，前四种就不用多说了，最后一种是唱片机特有的标签呢：\r\n\r\n{id,Count,Damage,tag}4种，分别是物品的id，物品的数量，物品的附加值，以及物品的更多标签。\r\n\r\n如果是正常的唱片机的话，那么id应该也就是正常的cd物品名。\r\n\r\ntag标签里则可以带更多的信息，如附魔属性、物品自定义名称、LORE、自定义高级属性以及隐藏标签的属性。";
            }
            else if (tabScoreData2.SelectedIndex == 4)
            {
                //实体 - 物品 | 一本书的掉落物品状态
                tabScoreBox.Text = "实例：\r\n{\r\n    Motion:[\r\n        0:-3.3982047028943443E-15d,\r\n        1:-0.0d,\r\n        2:-2.642266014594985E-14d,\r\n    ],\r\n    UUIDLeast:-5642266585314148059L,\r\n    UUIDMost:-4983469374521913660L,\r\n    Health:5s,\r\n    Invulnerable:0b,\r\n    Air:300s,\r\n    Fire:-1s,\r\n    OnGround:1b,\r\n    Dimension:0,\r\n    PortalCooldown:0,\r\n    Rotation:[\r\n        0:161.75696f,\r\n        1:0.0f,\r\n    ],\r\n    Thrower:\"IceLitty\",\r\n    FallDistance:0.0f,\r\n    PickupDelay:0s,\r\n    Age:56s,\r\n    Item:{\r\n        id:\"minecraft:written_book\",\r\n        Count:1b,\r\n        tag:{\r\n            pages:[\r\n                0:\"{\r\n                    text:\\\"炸裂吧苦力怕们！\\\",\r\n                    color:dark_red,bold:true,\r\n                    underlined:true,\r\n                    clickEvent:{\r\n                        action:run_command,\r\n                        value:\\\"/entitydata @e[type=Creeper,r=10] {ignited:1}\\\"\r\n                    },\r\n                    bold:true,\r\n                    underlined:true\r\n                }\",\r\n            ],\r\n            author:\"作者\",\r\n            title:\"书名\",\r\n        },\r\n        Damage:0s,\r\n    },\r\n    Pos:[\r\n        0:-219.40957294412024d,\r\n        1:65.0d,\r\n        2:316.58362342233676d,\r\n    ],\r\n}\r\n\r\n这次的举例是一个实体，是掉落的物品，选用的物品则是一本修改过的书。\r\n\r\nMotion就是动量，代表这个物体运动的方向以及力度，012分别代表xyz。\r\n\r\nUUIDLeast和UUIDMost代表的是这个物体所在的UUID区间。\r\n\r\n实体都有血量，这个物品也有，所以遇到岩浆会消失，这个掉落物的Health标签为5s，也就是5点血，2.5颗心。\r\n\r\nInvulnerable:0b代表这个物品不会受到上天的眷顾，碰到岩浆当然会扣血，如果实体的Invulnerable标签为1b的话，那么谁都伤不了TA了。\r\n当然，上天的眷顾，上天自然可以伤害TA，例如虚空和指令。\r\n\r\nAir为控制呼吸值，负值为在水中。\r\n\r\nFire为控制燃烧事件，负值为不在燃烧。\r\n\r\nOnGround为标识实体是在地上还是在空中，1b为在地上。\r\n\r\nDimension为控制物体的大小。\r\n\r\nPortalCooldown未知，未测试。\r\n\r\nRotation控制旋转相关。\r\n\r\nThrower为掉落物特有的标签，值表示为是谁扔出的物品，由此可以检测到特定玩家是否扔出了物品/某样物品。\r\n\r\nFallDistance为掉落距离。\r\n\r\nPickupDelay为拿起的延迟，-32768为拿不起来。\r\n\r\nAge为物品刷新等待时间，-32768为永不刷新。\r\n\r\nItem则表示这个物品是什么，包含物品的属性。\r\n\r\nPos则为这个实体的坐标。";
            }
            else if (tabScoreData2.SelectedIndex == 5)
            {
                //实体 - 末影水晶 | 无修改的末地加血机
                tabScoreBox.Text = "实例：\r\n{\r\n    Motion:[\r\n        0:0.0d,\r\n        1:0.0d,\r\n        2:0.0d,\r\n    ],\r\n    FallDistance:0.0f,\r\n    UUIDMost:3263486090785540746L,\r\n    Pos:[\r\n        0:-213.4773198104888d,\r\n        1:65.0d,\r\n        2:323.4897947925165d,\r\n    ],\r\n    UUIDLeast:-6975436761504391194L,\r\n    Fire:0s,\r\n    Invulnerable:0b,\r\n    Air:0s,\r\n    OnGround:0b,\r\n    Dimension:0,\r\n    PortalCooldown:0,\r\n    Rotation:[\r\n        0:0.0f,\r\n        1:0.0f,\r\n    ],\r\n}\r\n\r\n此页为末影水晶的实体实时标签，此页包含的标签已全部在上一页阐述完毕。";
            }
            else if (tabScoreData2.SelectedIndex == 6)
            {
                // < 以下为英文Wiki翻译 - 实体格式解析 >
                tabScoreBox.Text = "请往下翻哟~\r\n已更新。";
            }
            else if (tabScoreData2.SelectedIndex == 7)
            {
                //数据格式
                tabScoreBox.Text = "Byte    整数，范围-128至127，mc中经常用于做布尔值判断（0/1）。\r\nShort    整数，范围-32768至32767。\r\nInt    整数，范围-2147483648至2147483647。\r\nLong    整数，范围-2^63至2^63-1。\r\nFloat    单精度浮点数，最大值约3.4*10^38。\r\nDouble    双精度浮点数，最大值约1.8*10^308。\r\nByte_Array    字节数组，最大元素数量范围2^31-9至2^31-1。\r\nString    字符串，UTF-8编码字符串，长度为32767字节。\r\nList    列表，最大元素数量范围2^31-9。\r\nCompound    复合NBT类，例如{}里可以包含很多子项目。\r\nInt_Array    数组，最大元素数量范围2^31-9至2^31-1。\r\n然而说这些并没有用，下面是旧版本的解答，可能有误但是却能帮助理解，故留。\r\n\r\n格式介绍：\r\n值分很多种，small、int、long、float、double、string、byte等等，这些值在MC里的的表示形式目前被Mojang规范化，如下：\r\n\r\n（以下值皆为0）\r\nsmall        0s\r\nint        0\r\nlong        0L\r\nfloat        0f\r\ndouble        0d\r\nstring        \"\"\r\nbyte        0b\r\n\r\n其中一个额外值为list，译为列表，因为就是用来存东西的，包含数列和无序列表。\r\n无序列表用{}或[]涵盖所有子项，例：[{a},{b},{c}]则是无名称的无序列表内有a、b、c三个键、值。\r\n有序列表通常使用0:1:2:的方式来排序，例如[0:{a},1:{b}]则表示无名称的有序列表内包含包括在0内的a和包括在1内的b两个键、值。\r\n\r\n特别说明，string中仍然有可能用到string类型的数值，那么如何区分\"A\"C\"B\"是AB中有C还是AB是string而C不是呢？如下：\r\n\r\n\"A\\\"C\\\"B\"\r\n\r\n特用到了java等高级语言的转义字符。“\\”为转义字符，“\\\"”为转义后的双引号，这样就会把C当作string类型的值，而包含在AB中了。";
            }
            else if (tabScoreData2.SelectedIndex == 8)
            {
                //实体皆有的标签
                tabScoreBox.Text = "{Glowing:0}    1代表这个实体发光。\r\n\r\n{Tags:[{\"tag1\"},{\"tag2\"}]}    给实体加上tags，用于选择器的选择。\r\n\r\n{id:Zombie}    此标签代表这个实体的种类，可以填除玩家之外的任何种类。\r\n\r\n{Pos:[0:0.0d,1:0.0d,2:0.0d]}    代表实体所在坐标，012分别代表xyz。\r\n\r\n{Motion:[0:0.0d,1:0.0d,2:0.0d]}    代表实体的运动方向和运动速度，012分别代表xyz，速度单位为米/Tick。\r\n\r\n{Rotation:[0:0.0d,1:0.0d]}    0代表绕Y轴顺时针旋转的角度（yaw），西面为0.0d，最大360度。1代表从水平线上下旋转的角度（pitch），水平线为0，值从-90到90度。\r\n\r\n{FallDistance:0.0f}    代表实体坠落的距离，值越高将获得更多的摔落伤害。\r\n\r\n{Fire:0s}    默认为-20s，无火焰。数值代表离燃烧状态结束还剩多少Tick。\r\n\r\n{Air:0s}    在空气中最高值为300s，可以在水下憋15秒才开始扣血。如果值为0s则下水就开始每秒1滴血的速度扣血。\r\n\r\n{OnGround:0b}    如果接触地面，则为1b，不接触则为0b。\r\n\r\n{Dimension:0}    未知用法。实体只在正常世界值为0，下界为-1，末地为1。\r\n\r\n{Invulnerable:0b}    值为1b则表示不会受到任何的伤害，例如喷溅药水和鱼钩，TNT等，但是仍可被创造模式的玩家所攻击/破坏。\r\n\r\n{PortalCooldown:0}    传送冷却的倒计时，每次传送后此值将设置为900Tick（45秒），然后逐渐降为0。\r\n\r\n{UUIDMost:}    实体UUID区间的最大量。\r\n\r\n{UUIDLeast:}    实体UUID区间的最小量。\r\n\r\n{UUID:}    实体的UUID，在实体加载后将被移除。（1.9移除）\r\n\r\n{CustomName:\"Dinnerbone\"}    实体的自定义名称。\r\n\r\n{CustomNameVisible:0b}    实体是否拥有自定义名称，0b为否，1b为是。\r\n\r\n{Silent:0b}    0b为默认，1b为静音。\r\n\r\n{Riding:{}}    实体的骑乘标签。（1.9移除）\r\n    {id等:}    实体的所有标签。\r\n        ...    实体的所有标签。\r\n\r\n{Passengers:[]}    实体的骑乘标签。\r\n    [0:{...},1:{}]    实体所骑乘的标签。\r\n        {id:Zombie,Passengers:[...]}\r\n\r\n{CommandStats:{}}    关于最后命令执行修改的信息标识计分板的参数相关项。\r\n    {SuccessCountObjective:0b}    最后一个成功执行的命令中对象的名字，值为0b或1b。\r\n    {SuccessCountName:\"\"}    最后一个成功执行的命令中玩家的名字，值为string类型玩家名。\r\n    {AffectedBlocksObjectuve:0}    最后一个命令更改了多少的方块，值为int型数字。\r\n    {AffectedBlocksName:\"\"}    最后一个命令更改了多少方块的玩家的名字，值为string类型玩家名。\r\n    {AffectedEntitiesObjective:0}    同上，改变实体。\r\n    {AffectedEntitiesName:\"\"}    同上，改变实体。\r\n    {AffectedItemsObjective:0}    同上，改变物品。\r\n    {AffectedItemsName:\"\"}    同上，改变物品。\r\n    {QueryResultObjective:0}    同上，搜索结果。\r\n    {QueryResultName:\"\"}    同上，搜索结果。";
            }
            else if (tabScoreData2.SelectedIndex == 9)
            {
                //生物皆有的标签
                tabScoreBox.Text = "{HealF:20f}    实体的血量，1f为半颗心。如果此标签存在，Health标签则忽略。（1.9移除）\r\n\r\n{Health:20f}    旧标签，如果HealF标签不存在则使用此标签作为主要血量计量。（1.9以后由short类型改为float类型）\r\n\r\n{AbsorptionAmount:0.0f}    伤害吸收药水效果的额外生命值。\r\n\r\n{AttackTime:0s}    每次攻击都有延迟，此值就是当前的攻击延迟。\r\n\r\n{HurtTime:0s}    每次攻击后闪红（受到伤害）的延迟。\r\n\r\n{HurtByTimestamp:0}    最后一次被攻击，手动修改的值不会影响到自然更新。\r\n\r\n{DeathTime:0s}    死亡时间，单位Tick，控制死亡动画，值为0表示活着。\r\n\r\n{Attributes:[]}    生物属性。\r\n    [0:{}]    生物属性第0个。\r\n        {Name:|}    属性的名称。\r\n            generic.attackDamage    攻击力属性。\r\n            generic.followRange    跟踪距离属性。\r\n            generic.maxHealth    最大血量属性。\r\n            generic.knockbackResistance    击退距离属性。\r\n            generic.movementSpeed    移动速度属性。\r\n        {Base:0d}    属性等级。\r\n        {Modifiers:{}}    属性修饰符。\r\n            {Name:|}    修饰符名称。\r\n                ...    同上名称。\r\n            {Amount:0d}    同上等级。\r\n            {Operation:0}    计算方法，0则直接加值，1则Base乘以Amount，2则Base乘以1加Amount的和。\r\n            {UUIDMost:0L}    UUID区间的最大值。\r\n            {UUIDLeast:0L}    UUID区间的最小值。\r\n    [1:{}]    更多属性。\r\n\r\n{ActiveEffects:[]}    状态效果。\r\n    [{\r\n        {Id:0b}    状态效果的ID。\r\n        {Amplifier:0b}    药水效果等级，0b等于1b。\r\n        {Duration:0}    药水效果持续时间，单位Tick。\r\n        {Ambient:0b}    如果为1b就说明这个效果是来源于信标的，效果动画会减少。\r\n        {ShowParticles:1b}    如果为0b则隐藏药水效果的动画。\r\n    },{}]\r\n\r\n{ArmorItems:[]}    装备栏。\r\n    {0:{}}    脚部。\r\n    {1:{}}    腿部。\r\n    {2:{}}    胸部。\r\n    {3:{}}    头部。\r\n\r\n{HandItems:[]}    武器栏。\r\n    {0:{}}    主手武器（默认右手）。\r\n    {1:{}}    副手武器（默认左手）。\r\n\r\n{ArmorDropChances:[]}    装备掉落几率。\r\n    [0:0.085f,]    脚部。\r\n    [1:0.085f,]    腿部。\r\n    [2:0.085f,]    胸部。\r\n    [3:0.085f]    头部。\r\n\r\n{HandDropChances:[]}\r\n    [0:0.085f]    主手武器（默认右手）。\r\n    [1:0.085f]    副手武器（默认左手）。\r\n\r\n{LeftHanded:0}    默认0，右手为主手，1为左手主手。\r\n\r\n{DeathLootTable:\"minecraft:chests/simple_dungeon\"}    可选项，生物的死亡掉落表。\r\n\r\n{DeathLootTableSeed:1234L}    可选项，用于掉落表的种子，0或省略将随机生成。\r\n\r\n{CanPickUpLoot:0b}    如果为1b则可以捡起装备穿，捡起武器来攻击或防卫。\r\n\r\n{NoAI:0b}    如果为1b则不给予AI控制。\r\n\r\n{PersistenceRequired:0b}    如果为1b则生物不会自然刷新掉。\r\n\r\n{Leashed:0b}    为1b则表示生物被拴绳拴住。\r\n\r\n{Leash:{}}    拴绳的标签。\r\n    {UUIDMost:0L}    同上，拴绳连接到的实体。\r\n    {UUIDLeast:0L}    同上。\r\n    {X:0}    拴绳连接到栅栏的X轴坐标。\r\n    {Y:0}    同上，Y轴。\r\n    {Z:0}    同上，Z轴。\r\n\r\n{Team:\"\"}    这个标签不是生物NBT数据的一部分，但是在生成时使用它。它可以让生物加入该计分板组。";
            }
            else if (tabScoreData2.SelectedIndex == 10)
            {
                //可以喂养和可以驯服的生物标签
                tabScoreBox.Text = "关于喂养：\r\n{InLove:0}    生物在冒出红心动画到寻找配偶结束的剩余时间，单位为Tick，0表示不在寻找。\r\n{Age:0}    如果值为负数则表示为小动物阶段，当大于等于0时为成年阶段，大于0则为多长时间可以再次喂养的倒计时。\r\n{ForcedAge:0}    年龄值，会递增。\r\n\r\n关于驯服：\r\n{Owner:\"\"}    主人的玩家名，1.8之后以OwnerUUID为主，空值为无主人。\r\n{OwnerUUID:}    主人的UUID值，空值无主人。\r\n{Sitting:1b}    1b为坐下，0b为站立的状态。";
            }
            else if (tabScoreData2.SelectedIndex == 11)
            {
                tabScoreBox.Text = "蝙蝠：\r\n{BatFlags:0b}    1b则表示倒挂在方块上，0b则是飞行中。";
            }
            else if (tabScoreData2.SelectedIndex == 12)
            {
                tabScoreBox.Text = "鸡：\r\n{IsChickenJockey:0b}    如果鸡可以自然刷掉则为1b，其他效果未知。但是即使设置为0b，小僵尸仍然可以控制。\r\n{EggLayTime:0}    0的时候生蛋，逐渐减少该值，生蛋后重设该值为6000至12000内随机。";
            }
            else if (tabScoreData2.SelectedIndex == 13)
            {
                tabScoreBox.Text = "苦力怕：\r\n{powered:0b}    如果为1b则已经开始充能并闪光。\r\n{ExplosionRadius:3b}    自爆允许范围，默认3格内。\r\n{Fuse:30s}    引信时间，默认30Ticks。\r\n{ignited:0b}    如果为1b则表示被打火石点燃即将爆炸。";
            }
            else if (tabScoreData2.SelectedIndex == 14)
            {
                tabScoreBox.Text = "末影龙：\r\n{DragonPhase:6}    末影龙当前的动作。0为盘旋，1为准备喷射火球，2为飞向传送门准备着陆，3为着陆在传送门上，4为离开传送门，5为登陆后准备吐龙息，6为登陆后看向玩家并吐出龙息，7为登陆后开始聚气吼玩家，8为冲撞玩家，9为飞向传送门即将死亡，10为徘徊。";
            }
            else if (tabScoreData2.SelectedIndex == 15)
            {
                tabScoreBox.Text = "末影人：\r\n{carried:0s}    末影人手中方块的ID，0表示无。\r\n{carriedData:0s}    同上，附加值。";
            }
            else if (tabScoreData2.SelectedIndex == 16)
            {
                tabScoreBox.Text = "末影螨：\r\n{Lifetime:0}    末影螨存在的时长，达到2400则消失。\r\n{PlayerSpawned:0b}    当值为1b时末影人会攻击末影螨。";
            }
            else if (tabScoreData2.SelectedIndex == 17)
            {
                tabScoreBox.Text = "马：\r\n{Bred:0b}    未知标签。配种后将保持0。\r\n{ChestedHorse:0b}    如果有背包则为1b。\r\n{EatingHaystack:0b}    如果在吃草则为1b。\r\n{HasReproduced:0b}    未使用的键，值保持为0b。\r\n{Tame:0b}    被驯服则为1b。\r\n{Temper:0}    范围从0到100，更高的值代表马更容易被驯服。\r\n{Type:0}    马的种类，0为马，1为驴，2为骡，3为僵尸马，4为骷髅马。\r\n{Variant:0}    马的变种。\r\n{OwnerName:\"\"}    主人玩家名。\r\n{OwnerUUID:}    主人的UUID。\r\n{Items:{}}    如果是有箱子的马才有此项，背包。\r\n    {...}    背包内物品NBT。\r\n{ArmorItem:{}}    如果是有马甲槽的马才有此项，装备栏。\r\n{SaddleItem:{}}    如果是有鞍的马才有此项，鞍栏。\r\n{Saddle:0b}    如果为1b则有鞍，0b反之。\r\n{SkeletonTrap:0b}    是否是骷髅马陷阱，1b为是。\r\n{SkeletonTrapTime:0}    每Tick加1，这个值为18000也就是15分钟后，骷髅马自动消失（Despawn）。";
            }
            else if (tabScoreData2.SelectedIndex == 18)
            {
                tabScoreBox.Text = "恶魂：\r\n{ExplosionPower:1}    恶魂的火焰弹爆炸威力，默认为1。";
            }
            else if (tabScoreData2.SelectedIndex == 19)
            {
                tabScoreBox.Text = "深海守护者：\r\n{Elder:0b}    如果为1b则是守护者大长老。";
            }
            else if (tabScoreData2.SelectedIndex == 20)
            {
                tabScoreBox.Text = "史莱姆&岩浆史莱姆：\r\n{Size:3}    默认值为1-3分别是小中大号的史莱姆，值的最小值为0。\r\n{wasOnGround:0b}    如果为1b则表示在地面上。";
            }
            else if (tabScoreData2.SelectedIndex == 21)
            {
                tabScoreBox.Text = "豹猫：\r\n{CatType:0}    0为野猫，1为燕尾猫，2为虎斑猫，3为暹罗。";
            }
            else if (tabScoreData2.SelectedIndex == 22)
            {
                tabScoreBox.Text = "猪：\r\n{Saddle:0b}    如果为1b则会有个鞍在猪身上。";
            }
            else if (tabScoreData2.SelectedIndex == 23)
            {
                tabScoreBox.Text = "僵尸猪人：\r\n{IsVillager:0b}    1b则为僵尸村民。\r\n{IsBaby:0b}    1b则为小僵尸猪人。\r\n{ConversionTime:0}    -1时不被转换为村民，转换倒计时。\r\n{CanBreakDoors:0b}    0b则破坏不了木门，1b则可以，默认0。\r\n{VillagerProfession:0}    用于确定村民职业状态。\r\n{Anger:0s}    -32768到0之间是无仇恨，1到32767是有仇恨状态。每Tick减一，直到等于0。但是如果你打了它并且没离开视觉范围，则仍然会追着。被攻击后此值会随机到400和800之间。\r\n{HurtBy:\"xxxxxxxx-xxxx-xxx-xxxx-xxxxxxxxxxxx\"}    则是被谁攻击了，值为玩家的UUID。";
            }
            else if (tabScoreData2.SelectedIndex == 24)
            {
                tabScoreBox.Text = "兔子：\r\n{RabbitType:0}    兔子的种类，0棕色，1白色，2黑色，3黑白条纹，4金色，5盐白色，99杀手兔。\r\n{MoreCarrotTicks:0}    每一次达到0的时候将会吃掉种植下来的胡萝卜。";
            }
            else if (tabScoreData2.SelectedIndex == 25)
            {
                tabScoreBox.Text = "羊：\r\n{Sheared:0b}    为1的时候即被剪过毛。\r\n{Color:0b}    特殊值，0-15，代表羊的颜色，顺序为：白、橙、品红、淡蓝、黄、亮绿、粉、深灰、灰、青、紫、蓝、棕、绿、红、黑。";
            }
            else if (tabScoreData2.SelectedIndex == 26)
            {
                tabScoreBox.Text = "潜影贝：\r\n{Peek:0b}    这个Shulker的头部高度\r\n{AttachFace:0b}    这个Shulker面朝方向\r\n{APX:0}    类似X坐标\r\n{APY:0}    类似Y坐标\r\n{APZ:0}    类似Z坐标\r\n\r\n潜影弹：\r\n{Owner:{}}    所属Shulker\r\n    {X:0}    X轴坐标\r\n    {Y:0}    Y轴坐标\r\n    {Z:0}    Z轴坐标\r\n    {L:-1L}    所属Shulker的UUIDLeast标签\r\n    {M:1L}    所属Shulker的UUIDMost标签\r\n{Steps:50}    \r\n{Target:{}}    目标，内容子键和Owner相同，L和M为目标的UUIDLeast/Most\r\n{TXD:0.0d}    向X轴移动的动量\r\n{TYD:0.0d}    向Y轴移动的动量\r\n{TZD:0.0d}    向Z轴移动的动量";
            }
            else if (tabScoreData2.SelectedIndex == 27)
            {
                tabScoreBox.Text = "骷髅：\r\n{SkeletonType:0b}    0b则为普通骷髅，1b则是凋零骷髅。";
            }
            else if (tabScoreData2.SelectedIndex == 28)
            {
                tabScoreBox.Text = "村民：\r\n{Profession:0}    村民的外观材质，也会影响自由刷出的交易项目。\r\n{Riches:0}    未使用，增加绿宝石的数量给村民。\r\n{Career:0}    村民的从事职业，如果为0，下一次交易刷新后将会给他一个新职业并且把职业等级重置为1。\r\n{CareerLevel:0}    村民职业的等级，影响到刷出的交易物品好坏，同时如果此值特别高，则不会刷新交易。\r\n{Willing:0b}    村民要结婚生子了就为1b，否则为0b。\r\n{Inventory:[]}    村民的背包，共8槽位。\r\n    [{..},{..}]    物品NBT。\r\n{Offers:{}}    村民的交易项目。\r\n    {Recipes:[]}    交易列表。\r\n        [{\r\n            {buy:{}}    所需要的交易物A。\r\n            {buyB:{}}    所需要的交易物B。\r\n            {sell:{}}    所出售的交易物。\r\n            {rewardExp:0b}    如果为1b则交易成功会获得经验球。\r\n            {maxUses:12}    此项交易最大可交易次数，超过将关闭交易，每次刷新会随机在2-12。\r\n            {uses:0}    成功交易次数。\r\n        }]";
            }
            else if (tabScoreData2.SelectedIndex == 29)
            {
                tabScoreBox.Text = "铁傀儡：\r\n{PlayerCreated:0b}    如果为1b则表示是由玩家建造的铁傀儡，永远不会攻击玩家。";
            }
            else if (tabScoreData2.SelectedIndex == 30)
            {
                tabScoreBox.Text = "凋零：\r\n{Invul:0}    表示凋零的无敌时间还剩多少Tick，0表示已经结束。";
            }
            else if (tabScoreData2.SelectedIndex == 31)
            {
                tabScoreBox.Text = "狼：\r\n{Angry:0b}    如果为1b则表示狼发怒状态，会攻击你。\r\n{CollarColor:14}    狼的项圈颜色，颜色表见羊。";
            }
            else if (tabScoreData2.SelectedIndex == 32)
            {
                tabScoreBox.Text = "僵尸：\r\n{IsVillager:0b}    1b则为僵尸村民。\r\n{IsBaby:0b}    1b则为小僵尸。\r\n{ConversionTime:0}    -1时不被转换为村民，转换倒计时。\r\n{CanBreakDoors:0b}    0b则破坏不了木门，1b则可以。\r\n{VillagerProfession:1}    僵尸村民被治愈后的村民种类。";
            }
            else if (tabScoreData2.SelectedIndex == 33)
            {
                tabScoreBox.Text = "[{},{}]    Root\r\n    {Count:1b}    物品数量。\r\n    {Damage:0s}    物品Damage/Meta值。\r\n    {id:\"minecraft:grass\"}    物品ID，如果省略则为石头。\r\n    {tag:{...}}    物品其他tag。\r\n        {...}    其他NBT。";
            }
            else if (tabScoreData2.SelectedIndex == 34)
            {
                tabScoreBox.Text = "{xTile:0s}    物品所在区块的X轴。\r\n{yTile:0s}    物品所在区块的Y轴。\r\n{zTile:0s}    物品所在区块的Z轴。\r\n{inTile:\"minecraft:grass\"}    抛射物所在的方块ID。";
            }
            else if (tabScoreData2.SelectedIndex == 35)
            {
                tabScoreBox.Text = "{tag:{}}    Root\r\n    {CustomPotionEffects:[{},{}]}    自定义药水NBT效果。\r\n        {Id:0b}    药水效果的ID。\r\n        {Amplifier:0b}    药水效果的等级，0为1级。\r\n        {Duration:600}    药水效果的时间。\r\n        {Ambient:0b}    是否由信标提供的buff。\r\n        {ShowParticles:1b}    是否显示特效。\r\n    {Potion:\"minecraft:strong_poison\"}    默认药水效果的名称";
            }
            else if (tabScoreData2.SelectedIndex == 36)
            {
                tabScoreBox.Text = "弓箭&药水箭&发光箭：\r\n{shake:0b}    当攻击到方块为1b，否则为0b。\r\n{inData:0b}    箭矢所在方块的Meta值。\r\n{pickup:0b}    0b的时候不能被玩家捡起，1b可以由生jian存模式的玩家捡起，2b只可以被创造模式的玩家捡起。\r\n{player:0b}    如果pickup未使用，此值又为1b，那么箭矢将可以被玩家捡起。\r\n{life:0s}    箭矢一旦运动，此项则变为0s，每Tick值递增1，当值为1200s时，箭矢将被刷新。\r\n{damage:1d}    代表这根箭矢的攻击力，如为0d则无伤害。\r\n{inGround:0b}    当落地后则为1b。如果为0b时将不可拾取。\r\n{Duration:200}    发光状态的时长，单位Tick。\r\n{tag:{...}}    可带药水效果的NBT，见药水NBT格式页。";
            }
            else if (tabScoreData2.SelectedIndex == 37)
            {
                tabScoreBox.Text = "末影龙&小&火焰弹&凋零头：\r\n{direction:[]}    格式为[0.0,0.0,0.0]共3个double类型值，表示运动方向。\r\n{life:600}    如果实体移动则重置为0，每Tick递增直到600时移除实体（Despawn）。\r\n{power:[]}    和direction相同但不含阻力。\r\n{ExplosionPower:1}    爆炸威力。";
            }
            else if (tabScoreData2.SelectedIndex == 38)
            {
                tabScoreBox.Text = "雪球&鸡蛋&末影珍珠&经验瓶&药水瓶：\r\n{shake:0b}    当攻击到方块为1b，否则为0b。\r\n{ownerName:\"\"}    玩家名，投掷者。\r\n{Potion:{}}    物品格式，格式如下：\r\n    {Count:1b}    物品数量\r\n    {Damage:0s}    损害值\r\n    {id:\"minecraft:splash_potion\"}    物品ID\r\n    {tag:{...}}    物品NBT\r\n        {CustomPotionEffects:[{},{}]}    药水效果\r\n            {Id:0b}    药水ID\r\n            {Amplifier:0b}    等级\r\n            {Duration:0}    时长\r\n            {Ambient:0b}    是否信标\r\n            {ShowParticles:0b}    是否显示特效\r\n        {Potion:\"minecraft:strong_poison\"}    默认药水效果";
            }
            else if (tabScoreData2.SelectedIndex == 39)
            {
                tabScoreBox.Text = "掉落物品：\r\n{Age:0s}    未接触时增长此值，6000Ticks后约5分钟，该物品刷新，如果此值为-32768，则此值不会递增，也就是不会被刷新。\r\n{Health:5s}    默认5s，物品可以承受来自岩浆、火焰、掉落的铁砧和爆炸等伤害，如果此值为0则摧毁此掉落物。\r\n{PickupDelay:0s}    物品不能被捡起的时长，单位为Tick，每Tick递减，为0时可捡起物品，如果设为32767则停止递减，捡不起来。\r\n{Owner:\"\"}    物品的主人玩家名，如果不为空值，那么只有这个玩家才可以捡起该物品。\r\n{Thrower:\"\"}    扔出改物品的玩家名，用于给钻石的成就。\r\n{Item:[{},{}]}    物品NBT。";
            }
            else if (tabScoreData2.SelectedIndex == 40)
            {
                tabScoreBox.Text = "经验球：\r\n{Age:0s}    未接触时增长此值，6000Ticks后约5分钟，该物品刷新，如果此值为-32768，则此值不会递增，也就是不会被刷新。\r\n{Health:0b}    由于保存为byte类型的数据，所以此值的范围是0-255。为0的时候则刷新。\r\n{Value:0s}    捡起经验球可获得的经验数量。";
            }
            else if (tabScoreData2.SelectedIndex == 41)
            {
                tabScoreBox.Text = "所有的运输实体：\r\n{CustomDisplayTile:0b}    1b则显示自定义方块在矿车里。\r\n{DisplayTile:\"\"}    自定义方块的ID。\r\n{DisplayData:0}    自定义方块的Meta值。\r\n{DisplayOffset:0}    自定义方块对于矿车的距离，正值为高，负值为低，当为16时刚好高过一倍距离。";
            }
            else if (tabScoreData2.SelectedIndex == 42)
            {
                tabScoreBox.Text = "船：\r\n{Type:\"\"}    船的类型，有以下：\r\n    boat\r\n    spruce_boat\r\n    birch_boat\r\n    jungle_boat\r\n    acacia_boat\r\n    dark_oak_boat";
            }
            else if (tabScoreData2.SelectedIndex == 43)
            {
                tabScoreBox.Text = "运输矿车和动力矿车：\r\n{Items:{}}    物品NBT。\r\n\r\n动力矿车：\r\n{PushX:0d}    沿X轴的力，用于平滑的加减速。\r\n{PushZ:0d}    沿Z轴的力，用于平滑的加减速。\r\n{Fuel:0s}    动力矿车内的燃料剩下多少Ticks可供运作。";
            }
            else if (tabScoreData2.SelectedIndex == 44)
            {
                tabScoreBox.Text = "刷怪笼矿车：\r\n所有刷怪笼的标签都继承。\r\n\r\nTNT矿车：\r\n{TNTFuse:-1}    引信时间，-1为未激活，单位为Tick。\r\n\r\n漏斗矿车：\r\n{Items:[]}    物品列表\r\n{TransferCooldown:0}    传输物品的冷却时间，0为无传输，其余数值在1-8之间。\r\n{Enabled:1b}    1b则允许漏斗吸走物品。\r\n{LootTable:\"\"}    下一次吸附的物品。\r\n{LootTableSeed:1234L}    种子。";
            }
            else if (tabScoreData2.SelectedIndex == 45)
            {
                tabScoreBox.Text = "命令方块矿车：\r\n{Command:\"\"}    命令方块内的命令。\r\n{SuccessCount:0}    成功执行数。\r\n{LastOutput:\"\"}    命令方块上一个执行的命令。\r\n{TrackOutput:0b}    在命令方块GUI上O为1b，X为0b，当1b时上一个执行的命令将被储存，0b则不储存。";
            }
            else if (tabScoreData2.SelectedIndex == 46)
            {
                tabScoreBox.Text = "点燃的TNT：\r\n{Fuse:80b}    引信时间，默认80s，约4秒。";
            }
            else if (tabScoreData2.SelectedIndex == 47)
            {
                tabScoreBox.Text = "沙子、砂砾、龙蛋、铁砧、掉落沙：\r\n{TileID:0}    方块ID，现在支持1-4095的范围，取代了以往的{Tile:0b}标签。\r\n{Block:\"\"}    方块的名称，例如minecraft:stone。\r\n{TileEntityData:{}}    可选项，实体标签。\r\n{Data:0b}    方块的Meta值。\r\n{Time:0b}    方块掉落产生实体存在的时间，单位Tick，如果设为0，则会变为1Tick一闪而过，当值大于600，或大于100时方块Y轴位置小于等于0，则刷新。\r\n{DropItem:0b}    为1b则掉落成可拾起物品。\r\n{HurtEntities:0b}    1b时掉落会使被击中生物扣血。\r\n{FallHurtMax:0}    掉落伤害的最大值，默认40即20颗心。\r\n{FallHurtAmount:0.0f}    由下落距离乘以该值计算出掉落伤害的值，默认为2。";
            }
            else if (tabScoreData2.SelectedIndex == 48)
            {
                tabScoreBox.Text = "范围药水效果云：\r\n{Age:600}    存在时间。\r\n{Color:16777215}    RGB颜色。\r\n{Duration:600}    最大存在时间，逐渐减小半径。\r\n{ReapplicationDelay:0}    重新应用效果的延迟，越小频率越高。\r\n{WaitTime:0}    刚开始产生云的扩散时间。\r\n{DurationOnUse:666f}    未知。\r\n{Radius:30f}    范围。\r\n{RadiusOnUse:-1f}    根据药水效果逐渐增加的范围，默认为负值。\r\n{RadiusPerTick:-1f}    每Tick逐渐增加的范围，默认为负值。\r\n{Particle:\"\"}    药水显示的特效名。\r\n{Potion:\"\"}    默认药水效果的名字。\r\n{Effects:[{},{}]}    自定义药水效果。\r\n    {Ambient:1b}\r\n    {Amplifier:1b}\r\n    {Id:0b}\r\n    {ShowParticles:1b}\r\n    {Duration:600}";
            }
            else if (tabScoreData2.SelectedIndex == 49)
            {
                tabScoreBox.Text = "盔甲架：\r\n{DisabledSlots:}    不允许编辑的槽位，大于等于2039583为不允许编辑和替换所有槽位。\r\n        槽位说明：共有3*5个指示槽位，按照顺序共分为可移除、可替换和可放置三种操作以及头盔、胸甲、护腿、靴子和手持武器五种位置，需要多项勾选互相加即可得值。\r\n        头盔    胸甲    护腿    靴子    手持\r\n    可移除    16    8    4    2    1\r\n    可替换    4096    2048    1024    512    128\r\n    可放置    1048576    524288    262144    131072    65536\r\n{ArmorItems:[]}    装备栏。\r\n    [0:{},1:{},2:{},3:{}]    分别为脚、腿、胸和头。\r\n{HandItems:[]}    武器栏。\r\n    [0:{},1:{}]    对应主手武器和副手武器。\r\n{LeftHanded:0}    1为左手为主手。\r\n{Marker:0b}    为1b则完全隐身，意为标记，但还是会有非常小的碰撞箱。\r\n{Invisible:0b}    如果为1b，则骨架隐形。\r\n{NoBasePlate:0b}    如果为1b则不显示基座。\r\n{NoGravity:0b}    如果为1b则处于无重力环境，保持原来的高度。\r\n{Pose:{}}    盔甲架动作。\r\n    {Body:[]}    身体。\r\n        [0.0f,0.0f,0.0f]    分别为XYZ的角度。\r\n    {LeftArm:[]}    左臂。\r\n    {RightArm:[]}    右臂。\r\n    {LeftLeg:[]}    左腿。\r\n    {RightLeg:[]}    右腿。\r\n    {Head:[]}    头部。\r\n{ShowArms:0b}    如果为1b则显示胳膊。\r\n{Small:0b}    如果为1b则为小盔甲架。";
            }
            else if (tabScoreData2.SelectedIndex == 50)
            {
                tabScoreBox.Text = "画和展示框：\r\n{TileX:0}    1.8之前，坐标为实体所在的坐标，1.8以后，坐标为画所依附的方块的坐标。\r\n{TileY:0}    同上。\r\n{TileZ:0}    同上。\r\n{Facing:0b}    在1.8以后，代表了朝向，0为南，1为西，2为北，3为东。\r\n{Item:{}}    物品NBT。\r\n{ItemDropChance:1.0f}    掉落几率，默认1.0。\r\n{ItemRotation:0b}    物品顺时针旋转45度的次数。\r\n\r\n画：\r\n{Motive:\"Aztec2\"}    画中的内容。列表如下（由小到大，wiki见\"http://minecraft.gamepedia.com/Painting\"）：\r\nKebab    Aztec    Alban    Aztec2    Bomb    Plant    Wasteland\r\nWanderer    Graham\r\nPool    Courbet    Sunset    Sea    Creebet\r\nMatch    Bust    Stage    Void    SkullAndRoses    Wither\r\nFighters\r\nSkeleton    DonkeyKong    Pointer    Pigscene    BurningSkull";
            }
            else if (tabScoreData2.SelectedIndex == 51)
            {
                tabScoreBox.Text = "末影水晶：\r\n{ShowBottom:1b}    0b则不显示底座。\r\n{BeamTarget:{X:1,Y:2,Z:3}}    末影水晶加血效果的目标坐标。";
            }
            else if (tabScoreData2.SelectedIndex == 52)
            {
                tabScoreBox.Text = "烟花火箭：\r\n{Life:0}    实体可以飞的时间，单位Tick。\r\n{LifeTime:0}    实体爆炸前的时间，单位Tick。在飞前将被运算好：(Flight + 1) * 10 + random(0 to 5) + random(0 to 6)。\r\n{FilreworksItem:{...}}    烟花火箭包含的物品及效果。\r\n    {tag:{}}\r\n        {Explosion:{}}\r\n            {Flicker:0b}    1b则有闪烁特效。\r\n            {Trail:0b}    1b则有轨迹特效。\r\n            {Type:0b}    0为小球，1为大球，2为星形，3为爬行者形，4为爆裂。\r\n            {Colors:16777215}      十进制RGB颜色代码。\r\n            {FadeColors:16777215}      十进制RGB颜色代码，渐变用。\r\n        {Fireworks:{}}\r\n            {Flight:20b}    烟花持续时间，从-128至127。\r\n            {Explosions:[{},{}]}    见上方Explotion的tag。";
            }
            else if (tabScoreData2.SelectedIndex == 53)
            {
                tabScoreBox.Text = "附魔书：\r\n{ench:[]}    附魔主标签。\r\n    [{\r\n        {id:0s}    附魔ID。\r\n        {lvl:0s}    附魔等级。\r\n    },{}]\r\n{StoredEnchantments:[]}    附魔书的特殊标签。\r\n{RepairCost:0}    此物品用铁砧的消耗。";
            }
            else if (tabScoreData2.SelectedIndex == 54)
            {
                tabScoreBox.Text = "方块实体：\r\n{id:\"\"}    方块的id。\r\n{x:0}    x轴位置。\r\n{y:0}    y轴位置。\r\n{z:0}    z轴位置。";
            }
            else if (tabScoreData2.SelectedIndex == 55)
            {
                tabScoreBox.Text = "旗帜：\r\n{Base:0}    旗帜的基色。\r\n{Patterns:[]}    旗帜的图案。\r\n    [{\r\n        {Color:0}    图案某一层的颜色。\r\n        {Pattern:|}    某一层的图案，共38图案可选。\r\n    }]";
            }
            else if (tabScoreData2.SelectedIndex == 56)
            {
                tabScoreBox.Text = "信标：\r\n{Lock:\"\"}    上锁。\r\n{Levels:0}    主效果等级。\r\n{Primary:0}    主效果ID。0为无。\r\n{Secondary:0}    副效果ID。";
            }
            else if (tabScoreData2.SelectedIndex == 57)
            {
                tabScoreBox.Text = "酿造台：\r\n{Lock:\"\"}    上锁。\r\n{Items:[0:{},1:{},...]}    物品NBT，0为左侧，1为中间，2为右侧，3为药水输出栏。\r\n{BrewTime:0}    酿造时间，单位Tick。\r\n{Fuel:0b}    燃料剩余时间。";
            }
            else if (tabScoreData2.SelectedIndex == 58)
            {
                tabScoreBox.Text = "箱子：\r\n{Lock:\"\"}    上锁。\r\n{Items:{}}    物品NBT。\r\n{LootTable:\"\"}\r\n{LootTableSeed:1234L}";
            }
            else if (tabScoreData2.SelectedIndex == 59)
            {
                tabScoreBox.Text = "红石比较器：\r\n{OutputSignal:13}    红石模拟信号的强度。";
            }
            else if (tabScoreData2.SelectedIndex == 60)
            {
                tabScoreBox.Text = "命令方块：\r\n{CommandStats:{}}    命令激发状态\r\n    {...}    见之前内容。\r\n{Lock:\"\"}    上锁。\r\n{Command:\"\"}    命令。\r\n{SuccessCount:0}    成功执行次数。\r\n{LastOutput:\"\"}    最后输出。\r\n{TrackOutput:0b}    是否保留输出。\r\n{powered:0b}    1b为接受到红石信号。\r\n{auto:0b}    1b为自动执行。\r\n{conditionMet:1b}    1b为指向它的命令方块执行成功，0b为失败，如遇上非连锁命令方块则始终为1b。";
            }
            else if (tabScoreData2.SelectedIndex == 61)
            {
                tabScoreBox.Text = "投掷器&发射器：\r\n{Items:{}}    物品NBT。\r\n{Lock:\"\"}    上锁。";
            }
            else if (tabScoreData2.SelectedIndex == 62)
            {
                tabScoreBox.Text = "EndGateway：\r\n{Age:0}    传送门存在的时间，单位ticks，低于200时将发出紫色的光。\r\n{ExactTeleport:0b}    1则将实体准确的传送到该坐标处而不是坐标的附近。\r\n{ExitPortal:{}}    传送门目标点\r\n    {X:0}    X轴坐标\r\n    {Y:0}    Y轴坐标\r\n    {Z:0}    Z轴坐标";
            }
            else if (tabScoreData2.SelectedIndex == 63)
            {
                tabScoreBox.Text = "花盆：\r\n{Item:[]}    物品NBT，支持的如下：\r\n    树种    minecraft:sapling    ID 6\r\n    高草    minecraft:tallgrass    ID 31\r\n    枯木    minecraft:deadbush    ID 32\r\n    蒲公英    minecraft:yellow_flower    ID 37\r\n    罂粟    minecraft:red_flower    ID 38\r\n    棕色蘑菇    minecraft:brown_mushroom    ID 39\r\n    红色蘑菇    minecraft:red_mushroom    ID 40\r\n    仙人掌    minecraft:cactus    ID 81\r\n    *其他方块/物品皆可以设置，但是不会渲染，打掉花盆将会掉落出物品。\r\n{Data:0}    Meta值。";
            }
            else if (tabScoreData2.SelectedIndex == 64)
            {
                tabScoreBox.Text = "熔炉：\r\n{BurnTime:0s}    燃烧剩余时间，单位Tick。\r\n{CookTime:0s}    可以烧烤的时间，如果BurnTime为0，此值也为0，当此值为200时，物品将烤熟。\r\n{CookTimeTotal:0s}    物品烤熟的时间。\r\n{Items:{}}    物品NBT。\r\n{Lock:\"\"}    上锁。";
            }
            else if (tabScoreData2.SelectedIndex == 65)
            {
                tabScoreBox.Text = "漏斗：\r\n{Lock:\"\"}    上锁。\r\n{Items:[]}    物品。\r\n{TransferCooldown:0}    距离下次传输物品剩余的时间，单位Tick，范围从1-8，如果是0则无传输。\r\n{LootTable:\"\"}\r\n{LootTableSeed:1234L}";
            }
            else if (tabScoreData2.SelectedIndex == 66)
            {
                tabScoreBox.Text = "刷怪笼：\r\n{SpawnPotentials:[]}    刷怪清单。\r\n    {Type:|}    实体类型。\r\n    {Weight:0}    实体刷出比例。\r\n    {Properties:[]}    实体属性。\r\n{EntityId:|}    实体ID。\r\n{SpawnData:{}}    刷怪数据。\r\n{SpawnCount:0s}    刷怪数量。\r\n{SpawnRange:0s}    刷怪半径。\r\n{Delay:0s}    当前刷怪延迟。\r\n{MinSpawnDelay:0s}    最小刷怪延迟。\r\n{MaxSpawnDelay:0s}    最大刷怪延迟。\r\n{MaxNearbyEntities:0s}    最大半径内刷怪数量。\r\n{RequiredPlayerRange:0s}    需求玩家所在半径内。";
            }
            else if (tabScoreData2.SelectedIndex == 67)
            {
                tabScoreBox.Text = "音乐盒：\r\n{note:0b}    音阶\r\n/playsound指令全部声音wiki链接：http://minecraft.gamepedia.com/Sounds.json \r\n{powered:0b}    1b则接受到红石信号。\r\n\r\n唱片机：\r\n{Record:0}    0表示无唱片，此外其他值会覆盖RecordItem内的设置。\r\n{RecordItem:{}} 物品NBT，只能包含一种物品，多种物品请设置带NBT的箱子方块。";
            }
            else if (tabScoreData2.SelectedIndex == 68)
            {
                tabScoreBox.Text = "活塞：\r\n{blockId:0}    推动的方块id。\r\n{blockData:0}    推动的方块Meta。\r\n{facing:0}    推出活塞壁的朝向。\r\n{progress:0.0f}    方块被推的最多多远。\r\n{extending:0b}    1b表示方块推出去了。";
            }
            else if (tabScoreData2.SelectedIndex == 69)
            {
                tabScoreBox.Text = "告示牌：\r\n{Text1:\"{}\"}    告示牌第一行\r\n{Text2:\"{}\"}    告示牌第二行\r\n{Text3:\"{}\"}    告示牌第三行\r\n{Text4:\"{}\"}    告示牌第四行\r\n*1.9以后必须四行的标签都有才能正常设置。";
            }
            else if (tabScoreData2.SelectedIndex == 70)
            {
                tabScoreBox.Text = "头：\r\n{SkullType:0b}    头类型，3为玩家头。\r\n{ExtraType:\"\"}    玩家名。\r\n{Rot:0b}    面向。和告示牌一致。\r\n{Owner:{}}    玩家头信息。\r\n    {Id:\"\"}    玩家UUID。\r\n    {Name:\"\"}    玩家名。\r\n    {Properties:{}}\r\n        {textures:[]}\r\n            {Signature:\"\"}\r\n            {Value:\"\"}";
            }
            else if (tabScoreData2.SelectedIndex == 71)
            {
                //书与笔-成书
                tabScoreBox.Text = "{resolved:0b}    设为1b则是表示打开阅读过的书。\r\n{generation:0}    0表示此书是原作，1表示是复制原作的作品，2是复制复制作的作品，3为赝品，数值大于1后将无法复制。\r\n{author:\"\"}    作者玩家名。\r\n{title:\"\"}    书名。\r\n{pages:[]}    书内容。";
            }
            else if (tabScoreData2.SelectedIndex == 72)
            {
                //地图
                tabScoreBox.Text = "{map_is_scaling:0b}    地图缩放后则为1b。\r\n{Decorations:\"{}\"}    地图上显示的标志列表。\r\n    {id:\"\"}    标志的ID。\r\n    {type:0b}    标志的类型，见texture/map/map_icons.png。\r\n    {x:0d}    X位置。\r\n    {z:0d}    Z位置。\r\n    {rot:0d}    标志的旋转角度。    {ColorMap:0}    设置填充地图里覆盖/设置物品材质标记的颜色。";
            }
            else if (tabScoreData2.SelectedIndex == 73)
            {
                tabScoreBox.Text = "结构方块：\r\n{name:\"\"}    结构的名称\r\n{author:\"\"}    结构的作者，普通结构设置为问号“?”\r\n{metadata:\"\"}    结构的自定义数据，看上去未使用\r\n{posX:0}    结构的X坐标\r\n{posY:0}    结构的Y坐标\r\n{posZ:0}    结构的Z坐标\r\n{sizeX:0}    结构的X大小，可能是长度\r\n{sizeY:0}    结构的Y大小，可能是高度\r\n{sizeZ:0}    结构的Z大小，可能是深度\r\n{rotation:\"\"}    结构的旋转样式，可以是\"NONE\",\"CLOCKWISE_90\",\"CLOCKWISE_180\",或\"COUNTERCLOCKWISE_90\"\r\n{mirror:\"\"}    结构的镜像样式，可以是\"NONE\",\"LEFT_RIGHT\",或\"FRONT_BACK\"\r\n{mode:\"\"}    结构方块的运行模式，可以是\"SAVE\",\"LOAD\",\"CORNER\",或\"DATA\"\r\n{ignoreEntities:0b}    0为结构忽略实体\r\n";
            }
            else if (tabScoreData2.SelectedIndex == 74)
            {
                //额外附赠 - 资源包模型解析 - 模型数据
                tabScoreBox.Text = "//模型包模型数据\r\n{\r\n    \"variants\": {\r\n    //确定改方块所有变种的主观属性\r\n        \"snowy=false\": [\r\n        //当该方块的特定值=某值时，使用此属性，[]内的值可以多项\r\n            { \"model\": \"grass_normal\", \"x\": 0, \"y\": 90, \"uvlock\": false, \"weight\": 1 }\r\n            //model：对应的方块模型文件，文件位置来于 assets/minecraft/models/blocks\r\n            //x：旋转模型，值为0/90/180/270\r\n            //y：旋转模型，值为0/90/180/270\r\n            //uvlock：材质是否固定后不随方块的旋转而旋转\r\n            //weight：这条属性被使用的权重，1为100%则一定使用，如要做成像mcpatcher的随机贴图功能一类的，就需要改变这个权重\r\n            //另外这个权重只在多属性中使用，因为多属性中一定要满100%才行\r\n        ],\r\n        \"snowy=true\": { \"model\": \"grass_snowed\", \"x\": 0, \"y\": 0, \"uvlock\": false }\r\n        //也可以为单属性的\r\n    }\r\n}\r\n\r\n//Wiki上的例子：\r\n\"snowy=false\": [\r\n            { \"model\": \"grass_normal\" },\r\n            { \"model\": \"grass_normal\", \"y\": 90 },\r\n            { \"model\": \"grass_normal\", \"y\": 180 },\r\n            { \"model\": \"grass_normal\", \"y\": 270 }\r\n        ],\r\n//中，由于多属性的部分使用了相同的模型，故自动分配了四条属性各25%的几率出现，所以现在放草方块可以看出不一样方向的花纹了~\r\n";
            }
            else if (tabScoreData2.SelectedIndex == 75)
            {
                //额外附赠 - 资源包模型解析 - 模型变体
                tabScoreBox.Text = "//模型包模型文件\r\n{\r\n    \"__comment\": \"Information about this texture pack.\",\r\n    \"parent\": \"blocks/xxx\",\r\n    //继承父类模型，有此项就不应设置elements\r\n    \"ambientocclusion\": true,\r\n    //环境光遮蔽\r\n    \"inventoryRender3D\": false,\r\n    //背包渲染3D？Wiki上并没有这条\r\n    \"textures\": {\r\n    //贴图材质\r\n        \"textureName\": \"blocks/xxx\",\r\n        //自定义材质\r\n        \"particle\": \"blocks/xxx\"\r\n        //方块破碎粒子效果材质\r\n    },\r\n    \"elements\": [{\r\n    //模型的元素，立方体\r\n        \"__comment\": \"Information about this model part.\",\r\n        \"from\": [ x1, y1, z1 ],\r\n        //立面点左上 Top/Up(横向移动) - Front/South - Left/West(横向移动)\r\n        \"to\": [ x2, y2, z2 ],\r\n        //立面点右下 水平于N指向轴 - 高度 - 垂直于N指向轴\r\n        //注意整个模型的坐标范围需要控制在-16~32之间，可小数\r\n        \"shade\": false,\r\n        //定义渲染的阴影（是否锋利？）\r\n        \"rotation\": {\r\n        //元素的旋转\r\n            \"origin\": [ x, y, z ],\r\n            //旋转点\r\n            \"rescale\": true,\r\n            //重新调整大小与方块的大小一致\r\n            \"axis\": \"x/y/z\",\r\n            //旋转某轴\r\n            \"angle\": 45\r\n            //旋转度数，只允许使用-45/-22.5/0/22.5/45这些度数\r\n        },\r\n        \"faces\": {\r\n        //贴图\r\n        //六面体，up/down/north/south/west/east\r\n        //xy从贴图左上开始的坐标，hw为高宽的坐标\r\n        //rotation 旋转贴图，值为0/90/180/270\r\n        //cullface 平面剔除：指定当此方向有方块接触该方块时，该方向的贴图去除\r\n        //tintindex 色彩索引：使用硬编码色彩索引来使材质上色\r\n        //texture 贴图名称，在textures里定义\r\n        //uvlock 材质是否固定后不随方块的旋转而旋转。但是wiki上这条只在模型数据那个文件里才出现。\r\n            \"down\":  { \"uv\": [ x, y, h, w ], \"rotation\": 0 , \"cullface\": \"west\", \"tintindex\": 0, \"texture\": \"#textureName\", \"uvlock\": true },\r\n            \"up\":    { \"uv\": [ x, y, h, w ], \"texture\": \"#textureName\" },\r\n            \"north\": { \"uv\": [ x, y, h, w ], \"texture\": \"#textureName\" },\r\n            \"south\": { \"uv\": [ x, y, h, w ], \"texture\": \"#textureName\" },\r\n            \"west\":  { \"uv\": [ x, y, h, w ], \"texture\": \"#textureName\" },\r\n            \"east\":  { \"uv\": [ x, y, h, w ], \"texture\": \"#textureName\" }\r\n        }\r\n    },]\r\n}\r\n";
            }
            else if (tabScoreData2.SelectedIndex == 76)
            {
                //额外附赠 - 资源包模型解析 - 物品模型
                tabScoreBox.Text = "//模型包物品模型\r\n{\r\n    \"parent\": \"builtin/generated\",\r\n    //从assets/minecraft/models读取文件\r\n    //仍旧是父类，和方块模型不同的是，填写\"builtin/generated\"，可以设置各layer#贴图，\r\n    //填写\"builtin/entity\"，目前只能用于箱子，末影箱，头颅和旗帜\r\n    //\"builtin/compass\"和\"builtin/clock\"分别是给指南针和时钟使用的\r\n    \"textures\": {\r\n    //贴图材质\r\n        \"layer0\": \"items/spawn_egg\",\r\n        //layer#：0是最底下那层，可以定义多层贴图在一层上，例如刷怪蛋和皮革装备（药水和附魔书等不是！）\r\n        \"layer1\": \"items/spawn_egg_overlay\"\r\n        //另：layer#必须要和parent: \"builtin/generated\"一同使用\r\n        \"textureName\": \"blocks/xxx\",\r\n        //自定义材质\r\n        \"particle\": \"blocks/xxx\"\r\n        //例如吃食物的粒子效果，屏障的粒子效果等，若不填默认使用layer0的材质\r\n    },\r\n    \"elements\": [{\r\n    //模型的元素，立方体，这部分和模型文件里的元素部分略有减少，如和原版一样仅扁平单层模型则不需要写此项\r\n        \"__comment\": \"Information about this model part.\",\r\n        \"from\": [ x1, y1, z1 ],\r\n        //立面点左上 Top/Up(横向移动) - Front/South - Left/West(横向移动)\r\n        \"to\": [ x2, y2, z2 ],\r\n        //立面点右下 水平于N指向轴 - 高度 - 垂直于N指向轴\r\n        //注意整个模型的坐标范围需要控制在-16~32之间，可小数\r\n        \"rotation\": {\r\n        //元素的旋转\r\n            \"origin\": [ x, y, z ],\r\n            //旋转点\r\n            \"axis\": \"x/y/z\",\r\n            //旋转某轴\r\n            \"angle\": 45\r\n            //旋转度数，只允许使用-45/-22.5/0/22.5/45这些度数\r\n        },\r\n        \"faces\": {\r\n        //贴图\r\n        //六面体，up/down/north/south/west/east\r\n        //xy从贴图左上开始的坐标，hw为高宽的坐标\r\n        //rotation 旋转贴图，值为0/90/180/270\r\n        //cull 指不可见元素是否需要渲染\r\n        //tintindex 色彩索引：使用硬编码色彩索引来使材质上色\r\n        //texture 贴图名称，在textures里定义\r\n            \"down\":  { \"uv\": [ x, y, h, w ], \"rotation\": 0 , \"cull\": \"false\", \"tintindex\": 0, \"texture\": \"#textureName\" },\r\n            \"up\":    { \"uv\": [ x, y, h, w ], \"texture\": \"#textureName\" },\r\n            \"north\": { \"uv\": [ x, y, h, w ], \"texture\": \"#textureName\" },\r\n            \"south\": { \"uv\": [ x, y, h, w ], \"texture\": \"#textureName\" },\r\n            \"west\":  { \"uv\": [ x, y, h, w ], \"texture\": \"#textureName\" },\r\n            \"east\":  { \"uv\": [ x, y, h, w ], \"texture\": \"#textureName\" }\r\n        }\r\n    },],\r\n    \"display\": {\r\n    //显示相关\r\n        \"thirdperson\": {\r\n        //第三人称\r\n            \"rotation\": [ x, y, z ],\r\n            //旋转角度\r\n            \"translation\": [ x, y, z ],\r\n            //移动位置\r\n            \"scale\": [ x, y, z ]\r\n            //缩放大小\r\n        },\r\n        \"firstperson\": { ... },\r\n        //第一人称\r\n        \"gui\": { ... },\r\n        //在界面（Graphical User Interface）中显示\r\n        \"head\": { ... },\r\n        //戴在头上的样子（按E打开背包查看，如果想调整F5视角请修改第三人称）\r\n        \"ground\": { ... },\r\n        //地面上物品\r\n        \"fixed\": { ... },\r\n        //指物品展示框中的样子\r\n    },\r\n        //http://www.mcbbs.net/thread-432724-1-1.html 新闻贴\r\n    \"overrides\": [\r\n    //重写的部分\r\n        {\r\n            \"predicate\": {\r\n                \"damaged\": 1,\r\n                //表示damage值发生变化\r\n                \"damage\": 0.3\r\n                //损坏物品的damage值\r\n            },\r\n            \"model\": \"item/carrot_on_a_stick_02\"\r\n            //对应damage值所使用的模型（子模型可继承父模型来实现）\r\n        },\r\n        {\r\n            \"predicate\": {\r\n                \"pulling\": 1,\r\n                //拉弓，同damaged标签\r\n                \"pull\": 0.65\r\n                //拉弓程度，同damage标签\r\n            },\r\n            \"model\": \"item/bow_pulling_0\"\r\n        },\r\n        {\r\n            \"predicate\": {\r\n                \"cast\": 1\r\n                //鱼鳔投掷出去，同damaged标签\r\n                \"damaged\": 1,\r\n                \"damage\": 0.3\r\n                //根据damage值来显示不同的鱼竿模型，同理？\r\n            },\r\n            \"model\": \"item/fishing_rod_cast\"\r\n        },\r\n        {\r\n            \"predicate\": {\r\n                \"angle\": 0.484375\r\n                //指南针的方向，同damage标签\r\n            },\r\n            \"model\": \"item/compass_00\"\r\n        },\r\n        {\r\n            \"predicate\": {\r\n                \"time\": 0.0078125\r\n                //钟的时间，同damage标签\r\n            },\r\n            \"model\": \"item/clock_01\"\r\n        },\r\n                //1.9之后：\r\n        {\r\n            \"predicate\": {\r\n                \"damaged\": 1,\r\n                //表示damage值发生变化\r\n                \"damage\": 0.65,\r\n                //损坏物品的damage值（0-1，浮点数）\r\n                \"stack_size\": 64\r\n                //物品堆叠数量？\r\n            },\r\n            \"model\": \"item/任何物品\"\r\n            //或者\"block/任何物品\"也行哦\r\n        },\r\n    ]\r\n}\r\n";
            }
            else
            {
                tabScoreBox.Text = "";
            }
        }
    }
}
