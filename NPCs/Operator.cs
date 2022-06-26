using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Events;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.WorldBuilding;
using AlchemistNPCLite.Interface;
using Terraria.GameContent.ItemDropRules;
using System.Collections.Generic;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;

namespace AlchemistNPCLite.NPCs
{
    [AutoloadHead]
    public class Operator : ModNPC
    {
        public static bool Shop1 = true;
        public static bool Shop2 = false;
        public static bool Shop3 = false;
        public static bool Shop4 = false;
        public static bool Shop5 = false;
        public static bool Shop6 = false;
        public override string Texture
        {
            get
            {
                return "AlchemistNPCLite/NPCs/Operator";
            }
        }
        //Possibly Removed
        // public override bool Autoload(ref string name)
        // {
        // 	name = "Operator";
        // 	return true;
        // }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Operator");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Оператор");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "操作员");
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 45;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -6;

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "BossDropsShop");
            text.SetDefault("Boss Drops & Materials Shop");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Магазин лута Боссов и материалов");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "Boss掉落物&材料商店");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "BossDropsModsShop");
            text.SetDefault("Modded Boss Drops & Materials Shop");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Магазин модового лута Боссов и материалов");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "Boss掉落物&材料商店");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "VanillaTreasureBagsShop");
            text.SetDefault("Vanilla Treasure Bags Shop");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Магазин сумок стандарных Боссов");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "原版宝藏袋商店    ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "ModdedTreasureBagsShop");
            text.SetDefault("Modded Treasure Bags Shop");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Магазин сумок модовых Боссов");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "模组宝藏袋商店    ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "ModdedTreasureBagsShop2");
            text.SetDefault("Modded Treasure Bags Shop #2");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Магазин сумок модовых Боссов #2");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "模组宝藏袋商店#2    ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "ModdedTreasureBagsShop3");
            text.SetDefault("Modded Treasure Bags Shop #3");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Магазин сумок модовых Боссов #3");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "模组宝藏袋商店#3    ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "ShopChanger");
            text.SetDefault("Shop Changer");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сменить магазин");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "切换商店");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Angela");
            text.SetDefault("Angela");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Анжела");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Carmen");
            text.SetDefault("Carmen");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Кармен");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO1");
            text.SetDefault("How is your day, Manager? Can I help you?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Как ваш день, Управляющий? Могу ли я вам помочь?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "您好吗, 主管, 我能为您做什么?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO2");
            text.SetDefault("That 'The Great Thunder Bird' doesn't seems so dangerous. I am only hoping that it isn't a part of Apocalypse Bird...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Эта 'Великая Птица-Гром' не кажется такой уж опасной. Я только надеюсь, что она не является частью Птицы Апокалипсиса.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "那个'大雷鸟'看起来并不怎么危险. 我只希望它不是天启鸟的一部分...");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO3");
            text.SetDefault("Hello, Manager! Isn't this day silent, is it?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Приветствую, Управляющий! Тихий сегодня денёк, не правда ли?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "您好, 主管! 今天真安静, 不是么?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO4");
            text.SetDefault("Do you want anything special, Manager?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вам нужно что-нибудь особенное, Управляющий?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "您想要什么特别的东西吗, 主管?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO5");
            text.SetDefault("Eater of Worlds is an Abnormality with risk class TETH. And now it is contained. Do you need something from it?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пожиратель Миров - это аномалия с уровнем угрозы TETH. Теперь он захвачен. Нужно ли вам что-нибудь от него?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "世界吞噬者为异常, 危险等级: TETH. 现在它已经被写入了. 您需要些来自它的物品吗?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO6");
            text.SetDefault("If you manage to supress Ragnarok, then you could do everything imaginable.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если тебе удастся подавить Рагнарёк, то тогда ты способен на всё, что угодно.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "如果您成功阻止诸神黄昏, 那么您可以做您想做的一切.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO7");
            text.SetDefault("Eye of Cthulhu is a pretty strange creature. It seems like it is just a small part of something really dangerous. It would be better for us if it never escapes.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Глаз Ктулху - довольно странное создание. Похоже, что он является малой частью чего-то по настоящему опасного. Будет лучше если он никогда не сможет сбежать.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "克苏鲁之眼是个特别奇怪的生物. 它看起来像是个十分危险的东西的一部分. 如果它没有逃跑对我们来说更好.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO8");
            text.SetDefault("Brain of Cthulhu may look horrifying, but without its minions it can't do anything.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Мозг Ктулху может выглядеть пугающе, но без своих прислужников он не способен ни на что.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "克苏鲁之脑也许看起来很吓人, 但是失去了它的爪牙它几乎什么都做不了.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO9");
            text.SetDefault("Something changed in this world, Manager. Evil is spreading even wider, but at the same time, my sensor system caught the birth of new biome, called Hallow.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Что-то изменилось в этом мире, Управляющий. Зло разрастается ещё шире, но в то же время мои сенсоры зафиксировали рождение нового биома, называющегося Святым.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "这个世界出现了某种变动, 主管. 邪恶正在扩张, 但是与此同时, 我的传感系统发现了一个新生物群落诞生了, 叫做神圣之地.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO10");
            text.SetDefault("All these Mechanical Bosses... They definitely could have Trauma origin. What classification numbers will they get? I think they would be started as T-05-...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Все эти Механические Боссы... Они определённо могут иметь происхождение от Траумы. Какие классификационные номера им дать? Я полагаю, они будут начинаться с T-05-...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "所有的这些机械Boss... 他们肯定有创伤来源. 他们会得到什么分类号码? 我觉得可以从 T-05- 开始...");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO11");
            text.SetDefault("Goblins... Such a pathetic creatures. And the only useful things from them are just Spiky Balls and Harpoons.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Гоблины... Какие же жалкие создания. Единственные полезные вещи с них - это шипастые шары и Гарпуны.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "哥布林... 如此可怜的生物. 他们唯一有用的东西就是尖刺球和鱼叉链枪.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO12");
            text.SetDefault("Pretty strange Abnormal event... They all look as living creatures, but their 'Flying Dutchman' is definetly a ghost with HE risk class.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Довольно странное событие... Они все выглядят как живые существа, но вот их 'Летучий Голландец' - определённо призрак класса опасности HE.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "挺奇怪的异常事件... 他们都看起来像是活着的生物, 但是他们的 '飞翔荷兰人号' 的危险等级绝对有 HE.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO13");
            text.SetDefault("Martians came again. Last time they were here, several big towns were destroyed. But we could say as an excuse that we weren't as ready, as we were now.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Марсиане прибыли вновь. Последний раз когда они прибыли, было разрушено несколько крупных городов. Но, в наше оправдание можно сказать, что мы не были так готовы, как сейчас.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "火星人又来了. 上次他们来的时候, 几个大城镇被毁灭了. 但是, 恕我直言, 我们可以说我们现在还没有准备好.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO14");
            text.SetDefault("Blood Moon? Shouldn't it happen once in 666 years?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Кровавая Луна? Разве она не должна случаться один раз в 666 лет?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "血月? 这不应该每666年才发生一次吗?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO15");
            text.SetDefault("All these strange cratures just keep coming and coming to this 'Beacon'... Hope we all will survive until Dawn.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Все эти странные существа продолжают прибывать и прибывать на этот 'Маяк'... Надеюсь, мы все доживём до рассвета.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "所有的这些奇怪生物一直冲过来, 冲向这个'信标'... 真希望我们能在黎明前活下来.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO16");
            text.SetDefault("Anyway, there are some reasons for optimism. Blood Moon attracts some creatures, which cannot be seen in normal conditions.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Управляющий, не вешайте нос, все не так плохо! Кровавая Луна привлекает некоторых существ, которые обычно не появляются.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "无论怎样, 都有一些乐观的理由. 血月带来了一些生物, 平时我们都见不到的生物.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO17");
            text.SetDefault("I read a few manuscripts about creature, named Slime God. They say that he is one of the first creatures in this world.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я прочитала несколько манускриптов о существе, именуемом Бог Слизней. В них говорится, что он является одним из первых созданий этого мира");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我阅读了一些关于一个生物的手稿, 叫做史莱姆之神. 他们说这是世界上第一个生物之一.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO18");
            text.SetDefault("Yharim... I am pretty sure I heard that name before. But my memory data is corrupted. Try asking Calamitas about him...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ярим... Я уверена, что слышала это имя раньше. Но моя память повреждена. Попробуй узнать у Каламитас что-нибудь о нём...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "Yharim... 我很确定我曾经听过这个名字. 但是我的记忆数据已损坏. 试着去问问大山猪关于它的事情吧...");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO19");
            text.SetDefault("This carnivorous plant was really dangerous... Looks like it was at least HE Risk Class. Glad to see you again in one piece after all.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Этот плотоядный цветок был действительно опасен... Рада видеть, что ты не пострадал.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "这种肉食植物真的很危险...危险等级至少为 HE , 总之很高兴再次见到你平安归来");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO20");
            text.SetDefault("This ancient machine was holding celestial powers inside. With its death, world can change forever...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Эта древняя машина хранила в себе Небесные Силы. Её смерть может изменить мир навсегда.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "这古老的机器拥有着巨大的天界之力. 随着它的死亡, 世界也发生了永远的改变...");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO21");
            text.SetDefault("An insect the size of the Queen Bee defies current methods of classification. I propose insects of this size be given a new classification MI-XX. It is a wonder that nobody has used them for their own means, let us be the first.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Размеры насекомого с Королеву Пчёл бросают вызов текущим методам класификации. Я предлагаю дать насекомому таких размеров новую классификацию MI-XX. Удивительно, что ещё никто не использовал их для себя.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "一个蜂后那么大的昆虫是不符合现在的分类标准的. 我建议为他建立一个新的分类 MI-XX. 很奇怪还没有人为了自己的意愿驱使它们, 那么让我们成为第一个吧.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO22");
            text.SetDefault("It appears I was wrong about the queen bees. Their memory storage contains the ramblings of a scientist who was blinded by ambition and cruelly introduced the plague to them. Let us classify them as MP-0X.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Похоже, что я была неправа по поводу Королев Пчёл. Их память хранит бредовые мысли учёного, ослеплённого своими амбициями, того, кто жестоко заразил их чумой. Давайте классифицируем их как МР-0Х.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "看来我对蜂后的看法是错的. 它们的记忆中储存着一个被野心蒙蔽了双眼的科学家的漫谈, 他残酷地把瘟疫带给它们. 让我们把它们归类为MP-0X.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO23");
            text.SetDefault("According to my notes, this Coznix you speak of was a lesser Void Observer, classified as OB-V-01. There are greater threats waiting beyond the veil of reality.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Согласно моим записям, этот Козникс, о котором ты говорил, является малым Созерцателем Пустоты, классифицированном как OB-V-01. Похоже, что существуют ещё большие опасности за Границей Реальности.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "根据我的记录, 你所说的那个克兹尼格斯是一个较弱的虚空巡查者, 被归类为OB-V-01. 在现实的面纱后面有着更大的威胁在等待着.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO24");
            text.SetDefault("This flying scouter..... curious. From the memory banks stored in the wreckage, this looks to have been a scouting ship for the Martians, to determine how hospitable Terraria is. I fear the pilot's last moments have been transmitted to the main Martian command centre.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Эта летающая тарелка... интересно. Согласно носителям данных с места крушения, это корабль-разведчик Марсиан, целью которого является проверка того, насколько мир Террарии подходит для жизни. Боюсь, что последним, что успел сделать пилот этого корабля, была отправка сообщения в Главный Командный Центр Марсиан.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "这个飞行侦察者.....好奇. 从储存在残骸中的数据库来看, 这似乎是一艘为火星人而设的侦察船, 用来确定地球人的居住环境. 我担心飞行员最后看到的已经被上传到中央火星指挥中心.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO25");
            text.SetDefault("Turning a mages' power in on himself and trapping him within it is no easy task, but to observe cruelty of such magnitude..... Permafrost, former lord of the Ice Castle, may you see peace.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Обращение силы мага против него самого и заключение его же в ней непростая задача, но видя такую жестокость... Вечный Хлад, бывший властелин Ледяного Замка, может ты теперь обретёшь покой.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "把一个法师的力量转移到自己身上并且用它困住他并非易事, 但是观察如此残酷的行为...永冻之土, 前冰堡之王, 愿你看到和平.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO26");
            text.SetDefault("The Starplate raider is a Genius Stardust Centipede, or a G-S-C3, popular with the Martian elite as lifelong companions and raiding partners. It must have wandered far from home, judging from the transmitter memory banks I recovered.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Звёздный Рейндер это Гениальная Сороконожка Звёздной Пыли или G-S-C3, известная среди Марсианской Элиты как долгоживущий компаньон и партнёр для рейдерских экспедиций. Похоже, она ушла очень далеко от дома, судя по блокам данных, что я смогла восстановить.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "星盘袭击者是个天才星尘蜈蚣, 或是G-S-C3, 作为终身伴侣和合作伙伴在火星精英中很受欢迎. 从我恢复出的巡航机的存储芯片来看, 他一定在离家很远的地方探索着");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO27");
            text.SetDefault("I took the time to analyze the remains of this incredible creature. Every time it attacked, the entire planet seemed to resonate against its will. I can do nothing but to worry about the consequences of its death. At least, you saved Terraria of certain doom..........again.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я проанализировала останки этого невероятного существа. Каждый раз, когда оно атаковало, вся планета резонировала против его воли. Я не могу сделать ничего, кроме как волноваться о последствиях его смерти. Во всяком случае, ты спас Террарию от незавидной судьбы...... вновь.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我花了时间对这个不可思议的生物的遗体进行了分析, 每次它攻击的时候, 整个星球似乎都在它的意愿中产生共鸣, 我除了担心它的死亡的后果之外, 什么都做不了, 至少你又一次从末日中拯救了Terraria...又一次");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO28");
            text.SetDefault("Such an ancient presence is worth documenting - the material of its plates can withstand temperatures equal to the core of the Terrarian Sun! This will revolutionize containment procedures for ARS-0N prisoners if we can make materials half as resistant to heat!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Столь древняя сущность заслуживает документирования. Материалы её пластин могут выдержать температуру, равную ядру Солнца Террарии! Это революционизирует методы сдерживания для ARS-0N узников если мы сможем создать материалы, которые будут иметь хотя бы половину подобной стойкости.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "这样一个古老的存在是值得记录的--它外表的材料可以承受与地球太阳核心的温度相等的温度!如果我们能使材料具有一半的耐热性, 这将彻底改变对 ARS-0N 囚犯的控制装置!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO29");
            text.SetDefault("Whoever made the Ravager deserves to be put in HI-MAX containment. All those tortured souls....... Well, at least you put them out of their misery.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Тот, кто создал Опустошителя, заслуживает быть заключённым в Камере Максимального Содержания. Все эти измученные души.... Ну, по крайней мере ты освободил их от бренного существования.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "那些制造毁灭魔像的人就应该被关进 HI-MAX 监狱中去. 这些可怜的灵魂受尽了折磨......好吧, 至少你将他们从痛苦之渊中解放出来");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO30");
            text.SetDefault("Interesting... those Bumblebirbs were actually meant to be clones of Yharon. I’m glad that experiment was a failure!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Интересно... Эти Птицешмели должны были быть клонами Ярона. Как я рада, что этот эксперимент провалился.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "有意思...那些癫痫鸟实际上是丛林龙犽戎的克隆体. 我很高兴看到那些实验都失败了!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO31");
            text.SetDefault("You were lucky that thing got complacent and didn't open a portal to the Sun on our heads. The sheer strength and intelligence it exhibited means I need to make a whole new category for the classification of Worms.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Какое счастье, что ты не открыл портал на Солнце над нашими головами. Эта абсолютная сила и интеллект, что он продемонстрировал, означают, что мне потребуется создать совершенно новую категорию для классификации Червей.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你很幸运, 那东西膨胀了, 没有直接在你头上开个直通太阳的传送门. 他所展示出的力量和智慧, 意味着我要对蠕虫的类别做一个全新的分类");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO32");
            text.SetDefault("I have my theories about the origin of this being, frightening more than his soul (if he even has one)... Irradiates negative energy, experimentation shown how in darkness this ''oblivion energy'', irradiated light but in light places irradiated shadow. I don't know where he came from but I know that whatever it is, it must be contained at any cost!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "У меня есть теории о происхождении этого существа, которые пугают меня даже больше, чем его душа (если она у него вообще есть)... Излучает негативную энергию, поглощает свет и создаёт тени. Не знаю, откуда он пришёл, но знаю, что кто бы он ни был, его нужно сдержать любой ценой!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "对于这生物的起源我有些基本的猜测, 而不是单纯害怕他的灵魂(如果他有灵魂的话)...反辐射能量, 研究表明, 这种'湮灭能量'在黑暗中发出光芒, 在光明中辐射黑暗. 我不知道它是怎么来的, 但是我知道我们必须付出一切代价封印它.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO33");
            text.SetDefault("Supreme Calamitas has been defeated but she speaks of a being even stronger than herself. We must hope that he hasn't taken notice of us yet.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Совершенная Каламитас была побеждена, но она говорила о существе, ещё более сильном, чем она сама. Мы можем лишь надеяться, что он ещё не обратил на нас внимания.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "至尊灾厄眼被击败了, 但是他说还有一个比他更为强大的存在, 我们必须祈祷他还没有注意到我们.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO34");
            text.SetDefault("I’m honestly not sure why giant spinning skulls are the key to everything, but somehow they seem to contain the power of celestial beings within them...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я на самом деле не уверена, почему гигантские вращающиеся черепа - ключ ко всему, но каким-то образом они хранят в себе мощь божественных созданий...");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO35");
            text.SetDefault("Yeah, I know that we are the ones capturing and farming horrifying eldritch entities. But who the hell thought It was a good idea to put loot bags inside a giant monster?!?!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Да, я знаю, что мы те, кто захватывает и добывает материалы из сверхъестественных существ. Но кто чёрт возьми подумал, что будет хорошей идеей поместить сумку с ценностями внутрь гигантского чудовища?!?!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryO36");
            text.SetDefault("Кemember Manager, Treasure Bags are valuable but not everything comes inside them. That mutant man can help you get a boss's most elusive drops.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Помни, Управляющий, хотя Сумки с Сокровищами ценны, но не всё может найтись внутри. Мутант может помочь тебе добыть редчайший лут с боссов.");
            LocalizationLoader.AddTranslation(text);
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<OceanBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection(NPCID.Cyborg, AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.Steampunker, AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.Clothier, AffectionLevel.Dislike);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("Mods.AlchemistNPCLite.Bestiary.Operator")
            });
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 50;
            NPC.lifeMax = 1000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Steampunker;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (NPC.downedBoss2 && AlchemistNPCLite.modConfiguration.OperatorSpawn)
            {
                return true;
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {
            string Angela = Language.GetTextValue("Mods.AlchemistNPCLite.Angela");
            string Carmen = Language.GetTextValue("Mods.AlchemistNPCLite.Carmen");

            return new List<string>() {
                Angela,
                Carmen
            };
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (!Main.hardMode)
            {
                damage = 20;
            }
            if (Main.hardMode && !NPC.downedMoonlord)
            {
                damage = 75;
            }
            if (NPC.downedMoonlord)
            {
                damage = 500;
            }
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 10;
            randExtraCooldown = 5;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            attackDelay = 10;
            if (!Main.hardMode)
            {
                projType = 14;
            }
            if (Main.hardMode && !NPC.downedMoonlord)
            {
                attackDelay = 10;
                projType = 279;
            }
            if (NPC.downedMoonlord)
            {
                attackDelay = 4;
                projType = 638;
            }
        }

        public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
        {
            scale = 1f;
            closeness = 20;
            if (!Main.hardMode)
            {
                item = ItemID.FlintlockPistol;
            }
            if (Main.hardMode && !NPC.downedMoonlord)
            {
                item = ItemID.Shotgun;
            }
            if (NPC.downedMoonlord)
            {
                item = ItemID.VortexBeater;
            }
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
        }


        public override string GetChat()
        {                                           //npc chat
            string EntryO1 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO1");
            string EntryO2 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO2");
            string EntryO3 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO3");
            string EntryO4 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO4");
            string EntryO5 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO5");
            string EntryO6 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO6");
            string EntryO7 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO7");
            string EntryO8 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO8");
            string EntryO9 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO9");
            string EntryO10 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO10");
            string EntryO11 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO11");
            string EntryO12 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO12");
            string EntryO13 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO13");
            string EntryO14 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO14");
            string EntryO15 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO15");
            string EntryO16 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO16");
            string EntryO17 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO17");
            string EntryO18 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO18");
            string EntryO19 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO19");
            string EntryO20 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO20");
            string EntryO21 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO21");
            string EntryO22 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO22");
            string EntryO23 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO23");
            string EntryO24 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO24");
            string EntryO25 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO25");
            string EntryO26 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO26");
            string EntryO27 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO27");
            string EntryO28 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO28");
            string EntryO29 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO29");
            string EntryO30 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO30");
            string EntryO31 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO31");
            string EntryO32 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO32");
            string EntryO33 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO33");
            string EntryO34 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO34");
            string EntryO35 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO35");
            string EntryO36 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO36");

            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);

            if (Main.bloodMoon)
            {
                switch (Main.rand.Next(3))
                {
                    case 0:
                        return EntryO14;
                    case 1:
                        return EntryO15;
                    case 2:
                        return EntryO16;
                }
            }
            if (Main.invasionType == 1)
            {
                return EntryO11;
            }
            if (Main.invasionType == 3)
            {
                return EntryO12;
            }
            if (Main.invasionType == 4)
            {
                return EntryO13;
            }
            if (Main.rand.Next(5) == 0)
            {
                if (!WorldGen.crimson)
                {
                    return EntryO5;
                }
                if (WorldGen.crimson)
                {
                    return EntryO8;
                }
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            if (Calamity != null && NPC.downedBoss3)
            {
            	if (Main.rand.Next(7) == 0)
            	{
            		return EntryO17;
            	} 
            }
            */
            if (NPC.downedPlantBoss)
            {
                if (Main.rand.Next(7) == 0)
                {
                    return EntryO19;
                }
            }
            if (NPC.downedGolemBoss)
            {
                if (Main.rand.Next(7) == 0)
                {
                    return EntryO20;
                }
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            if (Calamity != null && NPC.downedMoonlord)
            {
            	if (Main.rand.Next(7) == 0)
            	{
            		return EntryO18;
            	} 
            }
            if (ModLoader.GetMod("ThoriumMod") != null)
            {
            	if (Main.rand.Next(6) == 0)
            	{
            		return EntryO2;

            	} 
            }
            if (ModLoader.GetMod("ThoriumMod") != null && Main.hardMode)
            {
            	if (Main.rand.Next(6) == 0)
            	{
            	return EntryO6;
            	}
            }
            */
            if (Main.rand.Next(5) == 0 && Main.hardMode)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return EntryO9;
                    case 1:
                        return EntryO10;
                }
            }
            if (Main.rand.Next(5) == 0 && NPC.downedQueenBee)
            {
                return EntryO21;
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            if (Calamity != null && Main.hardMode)
            {
                if (Main.rand.Next(5) == 0 && (bool)Calamity.Call("Downed", "plaguebringer goliath"))
                {
                    return EntryO22;
                }
                if (Main.rand.Next(5) == 0 && (bool)Calamity.Call("Downed", "cryogen"))
                {
                    return EntryO25;
                }
                if (Main.rand.Next(5) == 0 && (bool)Calamity.Call("Downed", "providence"))
                {
                    return EntryO28;
                }
                if (Main.rand.Next(5) == 0 && (bool)Calamity.Call("Downed", "ravager"))
                {
                    return EntryO29;
                }
                if (Main.rand.Next(5) == 0 && (bool)Calamity.Call("Downed", "bumblebirb"))
                {
                    return EntryO30;
                }
                if (Main.rand.Next(5) == 0 && (bool)Calamity.Call("Downed", "dog"))
                {
                    return EntryO31;
                }
                if (Main.rand.Next(5) == 0 && (bool)Calamity.Call("Downed", "supreme calamitas"))
                {
                    return EntryO33;
                }
            }

            if (ModLoader.GetMod("ThoriumMod") != null && Main.hardMode)
            {
                if (Main.rand.Next(5) == 0 && ThoriumModDownedFallenBeholder)
                {
                    return EntryO23;
                }
                if (Main.rand.Next(5) == 0 && ThoriumModDownedStarScout)
                {
                    return EntryO24;
                }
            }

            if (ModLoader.GetMod("SacredTools") != null && Main.hardMode)
            {
                if (Main.rand.Next(5) == 0 && SacredToolsDownedAbbadon)
                {
                    return EntryO32;
                }
            }

            if (ModLoader.GetMod("SpiritMod") != null && Main.hardMode)
            {
                if (Main.rand.Next(5) == 0 && SpiritModDownedStarplateRaider)
                {
                    return EntryO26;
                }
                if (Main.rand.Next(5) == 0 && SpiritModDownedOverseer)
                {
                    return EntryO27;
                }
            }
			*/
            switch (Main.rand.Next(6))
            {
                case 0:
                    return EntryO1;
                case 1:
                    return EntryO3;
                case 2:
                    return EntryO4;
                case 3:
                    return EntryO34;
                case 4:
                    return EntryO35;
                default:
                    return EntryO7;
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            string BossDropsShop = Language.GetTextValue("Mods.AlchemistNPCLite.BossDropsShop");
            string BossDropsModsShop = Language.GetTextValue("Mods.AlchemistNPCLite.BossDropsModsShop");
            string VanillaTreasureBagsShop = Language.GetTextValue("Mods.AlchemistNPCLite.VanillaTreasureBagsShop");
            string ModdedTreasureBagsShop = Language.GetTextValue("Mods.AlchemistNPCLite.ModdedTreasureBagsShop");
            string ModdedTreasureBagsShop2 = Language.GetTextValue("Mods.AlchemistNPCLite.ModdedTreasureBagsShop2");
            string ModdedTreasureBagsShop3 = Language.GetTextValue("Mods.AlchemistNPCLite.ModdedTreasureBagsShop3");
            string ShopChanger = Language.GetTextValue("Mods.AlchemistNPCLite.ShopChanger");
            button = BossDropsShop;
            if (!Main.expertMode)
            {
                button2 = BossDropsModsShop;
            }
            if (Main.expertMode)
            {
                button2 = ShopChanger;
            }
            if (Shop1)
            {
                button = BossDropsShop;
            }
            if (Shop2)
            {
                button = BossDropsModsShop;
            }
            if (Shop3)
            {
                button = VanillaTreasureBagsShop;
            }
            if (Shop4)
            {
                button = ModdedTreasureBagsShop;
            }
            if (Shop5)
            {
                button = ModdedTreasureBagsShop2;
            }
            if (Shop6)
            {
                button = ModdedTreasureBagsShop3;
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                if (!Main.expertMode)
                {
                    Shop1 = true;
                    Shop2 = false;
                    Shop3 = false;
                    Shop4 = false;
                    Shop5 = false;
                    Shop6 = false;
                    shop = true;
                }
                if (Main.expertMode)
                {
                    shop = true;
                    ShopChangeUIO.visible = false;
                }
            }
            else
            {
                if (!Main.expertMode)
                {
                    Shop2 = true;
                    Shop1 = false;
                    Shop3 = false;
                    Shop4 = false;
                    Shop5 = false;
                    Shop6 = false;
                    shop = true;
                }
                if (Main.expertMode)
                {
                    if (!ShopChangeUIO.visible) ShopChangeUIO.timeStart = Main.GameUpdateCount;
                    ShopChangeUIO.visible = true;
                }
            }
        }
        // IMPLEMENT WHEN WEAKREFERENCES FIXED
        /*
        public bool ThoriumModDownedGTBird
        {
            get { return ThoriumMod.ThoriumWorld.downedThunderBird; }
        }
        public bool ThoriumModDownedQueenJelly
        {
            get { return ThoriumMod.ThoriumWorld.downedJelly; }
        }
        public bool ThoriumModDownedViscount
        {
            get { return ThoriumMod.ThoriumWorld.downedBat; }
        }
        public bool ThoriumModDownedStorm
        {
            get { return ThoriumMod.ThoriumWorld.downedStorm; }
        }
        public bool ThoriumModDownedChampion
        {
            get { return ThoriumMod.ThoriumWorld.downedChampion; }
        }
        public bool ThoriumModDownedStarScout
        {
            get { return ThoriumMod.ThoriumWorld.downedScout; }
        }
        public bool ThoriumModDownedBoreanStrider
        {
            get { return ThoriumMod.ThoriumWorld.downedStrider; }
        }
        public bool ThoriumModDownedFallenBeholder
        {
            get { return ThoriumMod.ThoriumWorld.downedFallenBeholder; }
        }
        public bool ThoriumModDownedLich
        {
            get { return ThoriumMod.ThoriumWorld.downedLich; }
        }
        public bool ThoriumModDownedAbyssion
        {
            get { return ThoriumMod.ThoriumWorld.downedDepthBoss; }
        }
        public bool ThoriumModDownedRagnarok
        {
            get { return ThoriumMod.ThoriumWorld.downedRealityBreaker; }
        }

        public bool SacredToolsDownedDecree
        {
            get { return SacredTools.ModdedWorld.downedDecree; }
        }
        public bool SacredToolsDownedPumpkin
        {
            get { return SacredTools.ModdedWorld.downedPumpboi; }
        }
        public bool SacredToolsDownedHarpyPreHM
        {
            get { return SacredTools.ModdedWorld.downedHarpy; }
        }
        public bool SacredToolsDownedAraneas
        {
            get { return SacredTools.ModdedWorld.downedAraneas; }
        }
        public bool SacredToolsDownedHarpyHM
        {
            get { return SacredTools.ModdedWorld.downedRaynare; }
        }
        public bool SacredToolsDownedPrimordia
        {
            get { return SacredTools.ModdedWorld.downedPrimordia; }
        }
        public bool SacredToolsDownedAbbadon
        {
            get { return SacredTools.ModdedWorld.OblivionSpawns; }
        }
        public bool SacredToolsDownedAraghur
        {
            get { return SacredTools.ModdedWorld.FlariumSpawns; }
        }
        public bool SacredToolsDownedLunarians
        {
            get { return SacredTools.ModdedWorld.downedLunarians; }
        }
        public bool SacredToolsDownedChallenger
        {
            get { return SacredTools.ModdedWorld.downedChallenger; }
        }

        public bool SpiritModDownedScarabeus
        {
            get { return SpiritMod.MyWorld.downedScarabeus; }
        }
        public bool SpiritModDownedBane
        {
            get { return SpiritMod.MyWorld.downedReachBoss; }
        }
        public bool SpiritModDownedFlier
        {
            get { return SpiritMod.MyWorld.downedAncientFlier; }
        }
        public bool SpiritModDownedStarplateRaider
        {
            get { return SpiritMod.MyWorld.downedRaider; }
        }
        public bool SpiritModDownedInfernon
        {
            get { return SpiritMod.MyWorld.downedInfernon; }
        }
        public bool SpiritModDownedDusking
        {
            get { return SpiritMod.MyWorld.downedDusking; }
        }
        public bool SpiritModDownedEtherialUmbra
        {
            get { return SpiritMod.MyWorld.downedSpiritCore; }
        }
        public bool SpiritModDownedIlluminantMaster
        {
            get { return SpiritMod.MyWorld.downedIlluminantMaster; }
        }
        public bool SpiritModDownedAtlas
        {
            get { return SpiritMod.MyWorld.downedAtlas; }
        }
        public bool SpiritModDownedOverseer
        {
            get { return SpiritMod.MyWorld.downedOverseer; }
        }

        public bool EnigmaDownedSharkron
        {
            get { return Laugicality.LaugicalityWorld.downedDuneSharkron; }
        }
        public bool EnigmaDownedHypothema
        {
            get { return Laugicality.LaugicalityWorld.downedHypothema; }
        }
        public bool EnigmaDownedRagnar
        {
            get { return Laugicality.LaugicalityWorld.downedRagnar; }
        }
        public bool EnigmaDownedAnDio
        {
            get { return Laugicality.LaugicalityWorld.downedAnDio; }
        }
        public bool EnigmaDownedAnnihilator
        {
            get { return Laugicality.LaugicalityWorld.downedAnnihilator; }
        }
        public bool EnigmaDownedSlybertron
        {
            get { return Laugicality.LaugicalityWorld.downedSlybertron; }
        }
        public bool EnigmaDownedSteamTrain
        {
            get { return Laugicality.LaugicalityWorld.downedSteamTrain; }
        }
        public bool EnigmaDownedEtheria
        {
            get { return Laugicality.LaugicalityWorld.downedTrueEtheria; }
        }

        public bool PinkymodDownedST
        {
            get { return pinkymod.Global.Pinkyworld.downedSunlightTrader; }
        }
        public bool PinkymodDownedMS
        {
            get { return pinkymod.Global.Pinkyworld.downedMythrilSlime; }
        }
        public bool PinkymodDownedVD
        {
            get { return pinkymod.Global.Pinkyworld.downedValdaris; }
        }
        public bool PinkymodDownedAD
        {
            get { return pinkymod.Global.Pinkyworld.downedAbyssmalDuo; }
        }

        public bool AAModDownedMonarch
        {
            get { return AAMod.AAWorld.downedMonarch; }
        }
        public bool AAModDownedGrips
        {
            get { return AAMod.AAWorld.downedGrips; }
        }
        public bool AAModDownedTruffleToad
        {
            get { return AAMod.AAWorld.downedToad; }
        }
        public bool AAModDownedBrood
        {
            get { return AAMod.AAWorld.downedBrood; }
        }
        public bool AAModDownedHydra
        {
            get { return AAMod.AAWorld.downedHydra; }
        }
        public bool AAModDownedSerpent
        {
            get { return AAMod.AAWorld.downedSerpent; }
        }
        public bool AAModDownedDjinn
        {
            get { return AAMod.AAWorld.downedDjinn; }
        }
        public bool AAModDownedEquinox
        {
            get { return AAMod.AAWorld.downedEquinox; }
        }
        public bool AAModDownedSisters
        {
            get { return AAMod.AAWorld.downedSisters; }
        }
        public bool AAModDownedYamata
        {
            get { return AAMod.AAWorld.downedYamata; }
        }
        public bool AAModDownedAkuma
        {
            get { return AAMod.AAWorld.downedAkuma; }
        }
        public bool AAModDownedZero
        {
            get { return AAMod.AAWorld.downedZero; }
        }
        public bool AAModDownedShen
        {
            get { return AAMod.AAWorld.downedZero; }
        }

        public bool EADownedWasteland
        {
            get { return ElementsAwoken.MyWorld.downedWasteland; }
        }
        public bool EADownedWyrm
        {
            get { return ElementsAwoken.MyWorld.downedAncientWyrm; }
        }
        public bool EADownedInfernace
        {
            get { return ElementsAwoken.MyWorld.downedInfernace; }
        }
        public bool EADownedScourgeFighter
        {
            get { return ElementsAwoken.MyWorld.downedScourgeFighter; }
        }
        public bool EADownedRegaroth
        {
            get { return ElementsAwoken.MyWorld.downedRegaroth; }
        }
        public bool EADownedObsidious
        {
            get { return ElementsAwoken.MyWorld.downedObsidious; }
        }
        public bool EADownedPermafrost
        {
            get { return ElementsAwoken.MyWorld.downedPermafrost; }
        }
        public bool EADownedAqueous
        {
            get { return ElementsAwoken.MyWorld.downedAqueous; }
        }
        public bool EADownedGuardian
        {
            get { return ElementsAwoken.MyWorld.downedGuardian; }
        }
        public bool EADownedVolcanox
        {
            get { return ElementsAwoken.MyWorld.downedVolcanox; }
        }
        public bool EADownedVoidLevi
        {
            get { return ElementsAwoken.MyWorld.downedVoidLeviathan; }
        }
        public bool EADownedAzana
        {
            get { return ElementsAwoken.MyWorld.downedAzana; }
        }
        public bool EADownedAncients
        {
            get { return ElementsAwoken.MyWorld.downedAncients; }
        }

        public bool ReDownedChicken
        {
            get { return Redemption.RedeWorld.downedKingChicken; }
        }
        public bool ReDownedThorn
        {
            get { return Redemption.RedeWorld.downedThorn; }
        }
        public bool ReDownedKeeper
        {
            get { return Redemption.RedeWorld.downedTheKeeper; }
        }
        public bool ReDownedCrystal
        {
            get { return Redemption.RedeWorld.downedXenomiteCrystal; }
        }
        public bool ReDownedIEye
        {
            get { return Redemption.RedeWorld.downedInfectedEye; }
        }
        public bool ReDownedKingSlayer
        {
            get { return Redemption.RedeWorld.downedSlayer; }
        }
        public bool ReDownedVCleaver
        {
            get { return Redemption.RedeWorld.downedVlitch1; }
        }
        public bool ReDownedVGigipede
        {
            get { return Redemption.RedeWorld.downedVlitch2; }
        }
        public bool ReDownedObliterator
        {
            get { return Redemption.RedeWorld.downedVlitch3; }
        }
        public bool ReDownedPZero
        {
            get { return Redemption.RedeWorld.downedPatientZero; }
        }
        public bool ReDownedThornRe
        {
            get { return Redemption.RedeWorld.downedThornPZ; }
        }
        public bool ReDownedGolemRe
        {
            get { return Redemption.RedeWorld.downedEaglecrestGolemPZ; }
        }
        public bool ReDownedNebuleus
        {
            get { return Redemption.RedeWorld.downedNebuleus; }
        }
		*/
        // Possibly redundant with ModGlobalNPC
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            base.ModifyNPCLoot(npcLoot);

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Summoning.APMC>(), 1));
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            if (Shop1)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Lens);
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.DemoniteOre);
                shop.item[nextSlot].shopCustomPrice = 1500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.ShadowScale);
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.RottenChunk);
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.CrimtaneOre);
                shop.item[nextSlot].shopCustomPrice = 1500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.TissueSample);
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Vertebrae);
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                if (NPC.downedQueenBee)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.BeeWax);
                    shop.item[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.Stinger);
                    shop.item[nextSlot].shopCustomPrice = 75000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.JungleSpores);
                    shop.item[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.Vine);
                    shop.item[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                }
                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.Feather);
                    shop.item[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.Bone);
                    shop.item[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                }
                if (AlchemistNPCLiteWorld.downedSandElemental)
                {
                    shop.item[nextSlot].SetDefaults(3783);
                    shop.item[nextSlot].shopCustomPrice = 200000;
                    nextSlot++;
                }
                if (NPC.downedMechBossAny)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.SoulofLight);
                    shop.item[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.SoulofNight);
                    shop.item[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.SoulofFlight);
                    shop.item[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                }
                if (NPC.downedMechBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.SoulofFright);
                    shop.item[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                }
                if (NPC.downedMechBoss1)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.SoulofMight);
                    shop.item[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                }
                if (NPC.downedMechBoss2)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.SoulofSight);
                    shop.item[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.BlackLens);
                    shop.item[nextSlot].shopCustomPrice = 200000;
                    nextSlot++;
                }
                if (NPC.downedMechBoss1 && NPC.downedMechBoss3 && NPC.downedMechBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.HallowedBar);
                    shop.item[nextSlot].shopCustomPrice = 20000;
                    nextSlot++;
                }
                if (NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.Ectoplasm);
                    shop.item[nextSlot].shopCustomPrice = 35000;
                    nextSlot++;
                }
                if (NPC.downedMoonlord)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.FragmentSolar);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.FragmentNebula);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.FragmentVortex);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.FragmentStardust);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                }
            }
            if (Shop2)
            {
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
                if (ModLoader.GetMod("ThoriumMod") != null)
                {
                	addModItemToShop(ThoriumMod, "Petal", 10000, ref shop, ref nextSlot);
                	if (NPC.downedMoonlord)
                	{
                		addModItemToShop(ThoriumMod, "WhiteDwarfFragment", 100000, ref shop, ref nextSlot);
                		addModItemToShop(ThoriumMod, "CometFragment", 100000, ref shop, ref nextSlot);
                		addModItemToShop(ThoriumMod, "CelestialFragment", 100000, ref shop, ref nextSlot);
                	}
                	if (NPC.downedGolemBoss)
                	{
                		addModItemToShop(ThoriumMod, "BrokenHeroFragment", 250000, ref shop, ref nextSlot);
                	}
                }
                if (ModLoader.GetMod("SpiritMod") != null)
                {
                	if (NPC.downedGolemBoss)
                	{
                		addModItemToShop(SpiritMod, "BrokenParts", 500000, ref shop, ref nextSlot);
                		addModItemToShop(SpiritMod, "BrokenStaff", 500000, ref shop, ref nextSlot);
                	}
                }
                if (ModLoader.GetMod("LithosArmory") != null)
                {
                	if (NPC.downedGolemBoss)
                	{
                		addModItemToShop(LithosArmory, "BrokenHeroFlail", 500000, ref shop, ref nextSlot);
                		addModItemToShop(LithosArmory, "BrokenHeroGreatbow", 500000, ref shop, ref nextSlot);
                		addModItemToShop(LithosArmory, "BrokenHeroShotgun", 500000, ref shop, ref nextSlot);
                		addModItemToShop(LithosArmory, "BrokenHeroSling", 500000, ref shop, ref nextSlot);
                		addModItemToShop(LithosArmory, "BrokenHeroSpear", 500000, ref shop, ref nextSlot);
                		addModItemToShop(LithosArmory, "BrokenHeroWand", 500000, ref shop, ref nextSlot);
                	}
                }
				*/
                if (Calamity != null)
                {
                    if ((bool)Calamity.Call("Downed", "hive mind"))
                    {
                        addModItemToShop(Calamity, "TrueShadowScale", 20000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "perforators"))
                    {
                        addModItemToShop(Calamity, "BloodSample", 20000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "slime god"))
                    {
                        addModItemToShop(Calamity, "EbonianGel", 25000, ref shop, ref nextSlot);
                        addModItemToShop(Calamity, "PurifiedGel", 30000, ref shop, ref nextSlot);
                    }
                    if (NPC.downedMechBoss2)
                    {
                        addModItemToShop(Calamity, "BlightedLens", 150000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "calamitas doppelganger"))
                    {
                        addModItemToShop(Calamity, "UnholyCore", 100000, ref shop, ref nextSlot);
                    }
                    if (NPC.downedPlantBoss || (bool)Calamity.Call("Downed", "cryogen"))
                    {
                        addModItemToShop(Calamity, "EssenceofEleum", 25000, ref shop, ref nextSlot);
                    }
                    if (NPC.downedPlantBoss || (bool)Calamity.Call("Downed", "aquatic scourge"))
                    {
                        addModItemToShop(Calamity, "EssenceofCinder", 25000, ref shop, ref nextSlot);
                    }
                    if (NPC.downedPlantBoss || (bool)Calamity.Call("Downed", "brimstone elemental"))
                    {
                        addModItemToShop(Calamity, "EssenceofChaos", 25000, ref shop, ref nextSlot);
                    }
                    if (NPC.downedPlantBoss)
                    {
                        addModItemToShop(Calamity, "Tenebris", 30000, ref shop, ref nextSlot);
                        addModItemToShop(Calamity, "Lumenite", 50000, ref shop, ref nextSlot);
                        addModItemToShop(Calamity, "DepthCells", 30000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "astrum aureus"))
                    {
                        addModItemToShop(Calamity, "AstralJelly", 50000, ref shop, ref nextSlot);
                        addModItemToShop(Calamity, "Stardust", 10000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "leviathan"))
                    {
                        addModItemToShop(Calamity, "LivingShard", 30000, ref shop, ref nextSlot);
                    }
                    if (NPC.downedPlantBoss)
                    {
                        addModItemToShop(Calamity, "SolarVeil", 50000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "ravager"))
                    {
                        addModItemToShop(Calamity, "BarofLife", 100000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "astrum deus"))
                    {
                        addModItemToShop(Calamity, "MeldBlob", 10000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "profaned guardians"))
                    {
                        addModItemToShop(Calamity, "UnholyEssence", 50000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "polterghast"))
                    {
                        addModItemToShop(Calamity, "BloodOrb", 50000, ref shop, ref nextSlot);
                        addModItemToShop(Calamity, "Phantoplasm", 100000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "dog") && AlchemistNPCLiteWorld.downedDOGPumpking)
                    {
                        addModItemToShop(Calamity, "NightmareFuel", 120000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "dog") && AlchemistNPCLiteWorld.downedDOGIceQueen)
                    {
                        addModItemToShop(Calamity, "EndothermicEnergy", 120000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "buffed mothron"))
                    {
                        addModItemToShop(Calamity, "DarksunFragment", 150000, ref shop, ref nextSlot);
                    }
                }
            }
            if (Shop3)
            {
                if (!NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Notes.InformatingNote>());
                    nextSlot++;
                }
                if (NPC.downedBoss3 && Main.expertMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.KingSlimeBossBag);
                    shop.item[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.EyeOfCthulhuBossBag);
                    shop.item[nextSlot].shopCustomPrice = 350000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.EaterOfWorldsBossBag);
                    shop.item[nextSlot].shopCustomPrice = 500000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.BrainOfCthulhuBossBag);
                    shop.item[nextSlot].shopCustomPrice = 500000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.QueenBeeBossBag);
                    shop.item[nextSlot].shopCustomPrice = 750000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.SkeletronBossBag);
                    shop.item[nextSlot].shopCustomPrice = 1000000;
                    nextSlot++;
                }
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
                if (ModLoader.GetMod("ThoriumMod") != null)
				{
					if (DD2Event.DownedInvasionT1)
					{
						addModItemToShop(ThoriumMod, "DarkMageBag", 1000000, ref shop, ref nextSlot);
					}
				}
				*/
                if (Main.hardMode && Main.expertMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.WallOfFleshBossBag);
                    shop.item[nextSlot].shopCustomPrice = 1500000;
                    nextSlot++;
                }
                if (NPC.downedQueenSlime && Main.expertMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.QueenSlimeBossBag);
                    shop.item[nextSlot].shopCustomPrice = 1500000;
                    nextSlot++;
                }
                if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && Main.expertMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.DestroyerBossBag);
                    shop.item[nextSlot].shopCustomPrice = 2000000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.TwinsBossBag);
                    shop.item[nextSlot].shopCustomPrice = 2000000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.SkeletronPrimeBossBag);
                    shop.item[nextSlot].shopCustomPrice = 2000000;
                    nextSlot++;
                }
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
                if (ModLoader.GetMod("ThoriumMod") != null)
				{
					if (DD2Event.DownedInvasionT2 && NPC.downedMechBossAny)
					{
						addModItemToShop(ThoriumMod, "OgreBag", 2500000, ref shop, ref nextSlot);
					}
				}
				*/
                if (NPC.downedPlantBoss && Main.expertMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.PlanteraBossBag);
                    shop.item[nextSlot].shopCustomPrice = 2500000;
                    nextSlot++;
                }
                if (NPC.downedEmpressOfLight && Main.expertMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.FairyQueenBossBag);
                    shop.item[nextSlot].shopCustomPrice = 2500000;
                    nextSlot++;
                }
                if (NPC.downedGolemBoss && Main.expertMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.GolemBossBag);
                    shop.item[nextSlot].shopCustomPrice = 3000000;
                    nextSlot++;
                }
                if (DD2Event.DownedInvasionT3 && NPC.downedGolemBoss)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.BossBagBetsy);
                    shop.item[nextSlot].shopCustomPrice = 3500000;
                    nextSlot++;
                }
                if (NPC.downedFishron && Main.expertMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.FishronBossBag);
                    shop.item[nextSlot].shopCustomPrice = 3500000;
                    nextSlot++;
                }
                if (NPC.downedMoonlord && Main.expertMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.MoonLordBossBag);
                    shop.item[nextSlot].shopCustomPrice = 4000000;
                    nextSlot++;
                }
            }
            if (Shop4)
            {
                if (Calamity != null)
				{
                    if (NPC.downedBoss3 && Main.expertMode)
                    {
                    	if ((bool)Calamity.Call("Downed", "desert scourge"))
                    	{
                    		addModItemToShop(Calamity, "DesertScourgeBag", 350000, ref shop, ref nextSlot);
                    	}
                    	if ((bool)Calamity.Call("Downed", "crabulon"))
                    	{
                    		addModItemToShop(Calamity, "CrabulonBag", 650000, ref shop, ref nextSlot);
                    	}
                    	if ((bool)Calamity.Call("Downed", "hive mind") || (bool)Calamity.Call("Downed", "perforators"))
                    	{
                    		addModItemToShop(Calamity, "HiveMindBag", 1000000, ref shop, ref nextSlot);
                    		addModItemToShop(Calamity, "PerforatorBag", 1000000, ref shop, ref nextSlot);
                    	}
                    	if ((bool)Calamity.Call("Downed", "slime god"))
                    	{
                    		addModItemToShop(Calamity, "SlimeGodBag", 1750000, ref shop, ref nextSlot);
                    	}
                    	if ((bool)Calamity.Call("Downed", "cryogen"))
                    	{
                    		addModItemToShop(Calamity, "CryogenBag", 2000000, ref shop, ref nextSlot);
                    	}
                    	if ((bool)Calamity.Call("Downed", "brimstone elemental"))
                    	{
                    		if (!(bool)Calamity.Call("Downed", "providence"))
                    		{
                    			addModItemToShop(Calamity, "BrimstoneWaifuBag", 2000000, ref shop, ref nextSlot);
                    		}
                    		if ((bool)Calamity.Call("Downed", "providence"))
                    		{
                    			addModItemToShop(Calamity, "BrimstoneWaifuBag", 5000000, ref shop, ref nextSlot);
                    		}
                    	}
                    	if ((bool)Calamity.Call("Downed", "aquatic scourge"))
                    	{
                    		addModItemToShop(Calamity, "AquaticScourgeBag", 2000000, ref shop, ref nextSlot);
                    	}
                    	if ((bool)Calamity.Call("Downed", "calamitas doppelganger"))
                    	{
                    		if (!(bool)Calamity.Call("Downed", "providence"))
                    		{
                    			addModItemToShop(Calamity, "CalamitasBag", 3000000, ref shop, ref nextSlot);
                    		}
                    		if ((bool)Calamity.Call("Downed", "providence"))
                    		{
                    			addModItemToShop(Calamity, "CalamitasBag", 5000000, ref shop, ref nextSlot);
                    		}
                    	}
                    	if ((bool)Calamity.Call("Downed", "leviathan"))
                    	{
                    		addModItemToShop(Calamity, "LeviathanBag", 3500000, ref shop, ref nextSlot);
                    	}
                    	if (!(bool)Calamity.Call("Downed", "providence") && (bool)Calamity.Call("Downed", "astrum aureus"))
                    	{
                    		addModItemToShop(Calamity, "AstrageldonBag", 3000000, ref shop, ref nextSlot);
                    	}
                    	if ((bool)Calamity.Call("Downed", "providence") && (bool)Calamity.Call("Downed", "astrum aureus"))
                    	{
                    		addModItemToShop(Calamity, "AstrageldonBag", 5000000, ref shop, ref nextSlot);
                    	}
                    	if ((bool)Calamity.Call("Downed", "astrum deus"))
                    	{
                    		addModItemToShop(Calamity, "AstrumDeusBag", 3500000, ref shop, ref nextSlot);
                    	}
                    	if ((bool)Calamity.Call("Downed", "plaguebringer goliath"))
                    	{
                    		addModItemToShop(Calamity, "PlaguebringerGoliathBag", 4000000, ref shop, ref nextSlot); 
                    	}
                    	if ((bool)Calamity.Call("Downed", "ravager"))
                    	{
                    		addModItemToShop(Calamity, "RavagerBag", 4000000, ref shop, ref nextSlot); 
                    	}
                    	if ((bool)Calamity.Call("Downed", "bumblebirb"))
                    	{
                    		addModItemToShop(Calamity, "BumblebirbBag", 3000000, ref shop, ref nextSlot);
                    	}
                    	if ((bool)Calamity.Call("Downed", "providence"))
                    	{
                    		addModItemToShop(Calamity, "ProvidenceBag", 6000000, ref shop, ref nextSlot);
                    	}
                    	if ((bool)Calamity.Call("Downed", "polterghast"))
                    	{
                    		addModItemToShop(Calamity, "PolterghastBag", 7500000, ref shop, ref nextSlot);
                    	}
                    	if ((bool)Calamity.Call("Downed", "old duke"))
                    	{
                    		addModItemToShop(Calamity, "OldDukeBag", 8500000, ref shop, ref nextSlot);
                    	}
                    	if ((bool)Calamity.Call("Downed", "dog"))
                    	{
                    		addModItemToShop(Calamity, "DevourerofGodsBag", 10000000, ref shop, ref nextSlot);
                    	}
                    	if ((bool)Calamity.Call("Downed", "yharon"))
                    	{
                    		addModItemToShop(Calamity, "YharonBag", 15000000, ref shop, ref nextSlot);
                    	}
                    }
                }
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
                if (ModLoader.GetMod("ThoriumMod") != null)
                {
                    if (NPC.downedBoss3)
                    {
                        if (ThoriumModDownedGTBird)
                        {
                            addModItemToShop(ThoriumMod, "ThunderBirdBag", 500000, ref shop, ref nextSlot);
                        }
                        if (ThoriumModDownedQueenJelly)
                        {
                            addModItemToShop(ThoriumMod, "JellyFishBag", 750000, ref shop, ref nextSlot);
                        }
                        if (ThoriumModDownedViscount)
                        {
                            addModItemToShop(ThoriumMod, "CountBag", 850000, ref shop, ref nextSlot);
                        }
                        if (ThoriumModDownedStorm)
                        {
                            addModItemToShop(ThoriumMod, "GraniteBag", 1000000, ref shop, ref nextSlot);
                        }
                        if (ThoriumModDownedChampion)
                        {
                            addModItemToShop(ThoriumMod, "HeroBag", 1000000, ref shop, ref nextSlot);
                        }
                        if (ThoriumModDownedStarScout)
                        {
                            addModItemToShop(ThoriumMod, "ScouterBag", 1250000, ref shop, ref nextSlot);
                        }
                        if (Main.hardMode)
                        {
                            if (ThoriumModDownedBoreanStrider)
                            {
                                addModItemToShop(ThoriumMod, "BoreanBag", 1500000, ref shop, ref nextSlot);
                            }
                            if (ThoriumModDownedFallenBeholder)
                            {
                                addModItemToShop(ThoriumMod, "BeholderBag", 2000000, ref shop, ref nextSlot);
                            }
                            if (ThoriumModDownedLich)
                            {
                                addModItemToShop(ThoriumMod, "LichBag", 3000000, ref shop, ref nextSlot);
                            }
                            if (ThoriumModDownedAbyssion)
                            {
                                addModItemToShop(ThoriumMod, "AbyssionBag", 3500000, ref shop, ref nextSlot);
                            }
                        }
                        if (NPC.downedMoonlord)
                        {
                            if (ThoriumModDownedRagnarok)
                            {
                                addModItemToShop(ThoriumMod, "RagBag", 5000000, ref shop, ref nextSlot);
                            }
                        }
                    }
                }

                if (ModLoader.GetMod("SacredTools") != null)
                {
                    if (NPC.downedBoss3)
                    {
                        if (SacredToolsDownedDecree)
                        {
                            addModItemToShop(SacredTools, "DecreeBag", 330000, ref shop, ref nextSlot);
                        }
                        if (SacredToolsDownedPumpkin)
                        {
                            addModItemToShop(SacredTools, "PumpkinBag", 500000, ref shop, ref nextSlot);
                        }
                        if (SacredToolsDownedHarpyPreHM)
                        {
                            addModItemToShop(SacredTools, "HarpyBag", 1000000, ref shop, ref nextSlot);
                        }
                        if (SacredToolsDownedAraneas)
                        {
                            addModItemToShop(SacredTools, "AraneasBag", 1500000, ref shop, ref nextSlot);
                        }
                        if (SacredToolsDownedHarpyHM)
                        {
                            addModItemToShop(SacredTools, "HarpyBag2", 2000000, ref shop, ref nextSlot);
                        }
                        if (SacredToolsDownedPrimordia)
                        {
                            addModItemToShop(SacredTools, "PrimordiaBag", 3000000, ref shop, ref nextSlot);
                        }
                        if (SacredToolsDownedAbbadon)
                        {
                            addModItemToShop(SacredTools, "OblivionBag", 5000000, ref shop, ref nextSlot);
                        }
                        if (SacredToolsDownedAraghur)
                        {
                            addModItemToShop(SacredTools, "SerpentBag", 7500000, ref shop, ref nextSlot);
                        }
                        if (SacredToolsDownedLunarians)
                        {
                            addModItemToShop(SacredTools, "LunarBag", 10000000, ref shop, ref nextSlot);
                        }
                        if (SacredToolsDownedChallenger)
                        {
                            addModItemToShop(SacredTools, "ChallengerBag", 15000000, ref shop, ref nextSlot);
                        }
                    }
                }
				*/
            }
            if (Shop5)
            {
                if (!NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Notes.InformatingNote>());
                    nextSlot++;
                }
                if (NPC.downedBoss3 && Main.expertMode)
                {
                    // IMPLEMENT WHEN WEAKREFERENCES FIXED
                    /*
                    if (ModLoader.GetMod("AAMod") != null)
                    {
                        if (AAModDownedMonarch)
                        {
                            addModItemToShop(AAMod, "MonarchBag", 150000, ref shop, ref nextSlot);
                        }
                        if (AAModDownedGrips)
                        {
                            addModItemToShop(AAMod, "GripsBag", 300000, ref shop, ref nextSlot);
                        }
                        if (AAModDownedTruffleToad)
                        {
                            addModItemToShop(AAMod, "TruffleBag", 350000, ref shop, ref nextSlot);
                        }
                        if (AAModDownedBrood)
                        {
                            addModItemToShop(AAMod, "BroodBag", 500000, ref shop, ref nextSlot);
                        }
                        if (AAModDownedHydra)
                        {
                            addModItemToShop(AAMod, "HydraBag", 750000, ref shop, ref nextSlot);
                        }
                        if (AAModDownedSerpent)
                        {
                            addModItemToShop(AAMod, "SerpentBag", 1000000, ref shop, ref nextSlot);
                        }
                        if (AAModDownedDjinn)
                        {
                            addModItemToShop(AAMod, "DjinnBag", 1000000, ref shop, ref nextSlot);
                        }
                        if (AAModDownedEquinox)
                        {
                            addModItemToShop(AAMod, "DBBag", 2500000, ref shop, ref nextSlot);
                            addModItemToShop(AAMod, "NCBag", 2500000, ref shop, ref nextSlot);
                        }
                        if (AAModDownedSisters)
                        {
                            addModItemToShop(AAMod, "AHBag", 5000000, ref shop, ref nextSlot);
                        }
                        if (AAModDownedYamata)
                        {
                            addModItemToShop(AAMod, "YamataBag", 5000000, ref shop, ref nextSlot);
                        }
                        if (AAModDownedAkuma)
                        {
                            addModItemToShop(AAMod, "AkumaBag", 5000000, ref shop, ref nextSlot);
                        }
                        if (AAModDownedZero)
                        {
                            addModItemToShop(AAMod, "ZeroBag", 10000000, ref shop, ref nextSlot);
                        }
                        if (AAModDownedShen)
                        {
                            addModItemToShop(AAMod, "ShenCache", 15000000, ref shop, ref nextSlot);
                        }
                    }
                    if (ModLoader.GetMod("SpiritMod") != null)
                    {
                        if (SpiritModDownedScarabeus)
                        {
                            addModItemToShop(SpiritMod, "BagOScarabs", 300000, ref shop, ref nextSlot);
                        }
                        if (SpiritModDownedBane)
                        {
                            addModItemToShop(SpiritMod, "ReachBossBag", 500000, ref shop, ref nextSlot);
                        }
                        if (SpiritModDownedFlier)
                        {
                            addModItemToShop(SpiritMod, "FlyerBag", 750000, ref shop, ref nextSlot);
                        }
                        if (SpiritModDownedStarplateRaider)
                        {
                            addModItemToShop(SpiritMod, "SteamRaiderBag", 1000000, ref shop, ref nextSlot);
                        }
                        if (SpiritModDownedInfernon)
                        {
                            addModItemToShop(SpiritMod, "InfernonBag", 2000000, ref shop, ref nextSlot);
                        }
                        if (SpiritModDownedDusking)
                        {
                            addModItemToShop(SpiritMod, "DuskingBag", 2500000, ref shop, ref nextSlot);
                        }
                        if (SpiritModDownedEtherialUmbra)
                        {
                            addModItemToShop(SpiritMod, "SpiritCoreBag", 2500000, ref shop, ref nextSlot);
                        }
                        if (SpiritModDownedIlluminantMaster)
                        {
                            addModItemToShop(SpiritMod, "IlluminantBag", 3000000, ref shop, ref nextSlot);
                        }
                        if (SpiritModDownedAtlas)
                        {
                            addModItemToShop(SpiritMod, "AtlasBag", 4000000, ref shop, ref nextSlot);
                        }
                        if (SpiritModDownedOverseer)
                        {
                            addModItemToShop(SpiritMod, "OverseerBag", 8000000, ref shop, ref nextSlot);
                        }
                    }
                    if (ModLoader.GetMod("Laugicality") != null)
                    {
                        if (EnigmaDownedSharkron)
                        {
                            addModItemToShop(Laugicality, "DuneSharkronTreasureBag", 300000, ref shop, ref nextSlot);
                        }
                        if (EnigmaDownedHypothema)
                        {
                            addModItemToShop(Laugicality, "HypothemaTreasureBag", 500000, ref shop, ref nextSlot);
                        }
                        if (EnigmaDownedRagnar)
                        {
                            addModItemToShop(Laugicality, "RagnarTreasureBag", 750000, ref shop, ref nextSlot);
                        }
                        if (EnigmaDownedAnDio)
                        {
                            addModItemToShop(Laugicality, "AnDioTreasureBag", 1000000, ref shop, ref nextSlot);
                        }
                        if (EnigmaDownedAnnihilator)
                        {
                            addModItemToShop(Laugicality, "AnnihilatorTreasureBag", 2000000, ref shop, ref nextSlot);
                        }
                        if (EnigmaDownedSlybertron)
                        {
                            addModItemToShop(Laugicality, "SlybertronTreasureBag", 2000000, ref shop, ref nextSlot);
                        }
                        if (EnigmaDownedSteamTrain)
                        {
                            addModItemToShop(Laugicality, "SteamTrainTreasureBag", 2000000, ref shop, ref nextSlot);
                        }
                    }
                    if (ModLoader.GetMod("pinkymod") != null)
                    {
                        if (PinkymodDownedST)
                        {
                            addModItemToShop(pinkymod, "STBag", 500000, ref shop, ref nextSlot);
                        }
                        if (PinkymodDownedMS)
                        {
                            addModItemToShop(pinkymod, "HOTCTreasureBag", 750000, ref shop, ref nextSlot);
                            addModItemToShop(pinkymod, "MythrilBag", 1000000, ref shop, ref nextSlot);
                        }
                        if (PinkymodDownedVD)
                        {
                            addModItemToShop(pinkymod, "Valdabag", 1500000, ref shop, ref nextSlot);
                        }
                        if (PinkymodDownedAD)
                        {
                            addModItemToShop(pinkymod, "GatekeeperTreasureBag", 2500000, ref shop, ref nextSlot);
                        }
                    }
					*/
                }
            }
            if (Shop6)
            {
                if (!NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Notes.InformatingNote>());
                    nextSlot++;
                }
                if (NPC.downedBoss3 && Main.expertMode)
                {
                    // IMPLEMENT WHEN WEAKREFERENCES FIXED
                    /*
                    if (ModLoader.GetMod("ElementsAwoken") != null)
                    {
                        if (EADownedWasteland)
                        {
                            addModItemToShop(ElementsAwoken, "WastelandBag", 300000, ref shop, ref nextSlot);
                        }
                        if (EADownedInfernace)
                        {
                            addModItemToShop(ElementsAwoken, "InfernaceBag", 500000, ref shop, ref nextSlot);
                        }
                        if (EADownedScourgeFighter)
                        {
                            addModItemToShop(ElementsAwoken, "ScourgeFighterBag", 1500000, ref shop, ref nextSlot);
                        }
                        if (EADownedRegaroth)
                        {
                            addModItemToShop(ElementsAwoken, "RegarothBag", 1750000, ref shop, ref nextSlot);
                        }
                        if (EADownedPermafrost)
                        {
                            addModItemToShop(ElementsAwoken, "PermafrostBag", 2250000, ref shop, ref nextSlot);
                        }
                        if (EADownedObsidious)
                        {
                            addModItemToShop(ElementsAwoken, "ObsidiousBag", 2250000, ref shop, ref nextSlot);
                        }
                        if (EADownedAqueous)
                        {
                            addModItemToShop(ElementsAwoken, "AqueousBag", 2500000, ref shop, ref nextSlot);
                        }
                        if (EADownedWyrm)
                        {
                            addModItemToShop(ElementsAwoken, "TempleKeepersBag", 2750000, ref shop, ref nextSlot);
                        }
                        if (EADownedGuardian)
                        {
                            addModItemToShop(ElementsAwoken, "GuardianBag", 3000000, ref shop, ref nextSlot);
                        }
                        if (EADownedVolcanox)
                        {
                            addModItemToShop(ElementsAwoken, "VolcanoxBag", 5000000, ref shop, ref nextSlot);
                        }
                        if (EADownedVoidLevi)
                        {
                            addModItemToShop(ElementsAwoken, "VoidLeviathanBag", 6000000, ref shop, ref nextSlot);
                        }
                        if (EADownedAzana)
                        {
                            addModItemToShop(ElementsAwoken, "AzanaBag", 8000000, ref shop, ref nextSlot);
                        }
                        if (EADownedAncients)
                        {
                            addModItemToShop(ElementsAwoken, "AncientsBag", 10000000, ref shop, ref nextSlot);
                        }
                    }
                    if (ModLoader.GetMod("Redemption") != null)
                    {
                        if (ReDownedChicken)
                        {
                            addModItemToShop(Redemption, "KingChickenBag", 150000, ref shop, ref nextSlot);
                        }
                        if (ReDownedThorn)
                        {
                            addModItemToShop(Redemption, "ThornBag", 250000, ref shop, ref nextSlot);
                        }
                        if (ReDownedKeeper)
                        {
                            addModItemToShop(Redemption, "TheKeeperBag", 350000, ref shop, ref nextSlot);
                        }
                        if (ReDownedCrystal)
                        {
                            addModItemToShop(Redemption, "XenomiteCrystalBag", 500000, ref shop, ref nextSlot);
                        }
                        if (ReDownedIEye)
                        {
                            addModItemToShop(Redemption, "InfectedEyeBag", 1000000, ref shop, ref nextSlot);
                        }
                        if (ReDownedKingSlayer)
                        {
                            addModItemToShop(Redemption, "SlayerBag", 1500000, ref shop, ref nextSlot);
                        }
                        if (ReDownedVCleaver)
                        {
                            addModItemToShop(Redemption, "VlitchCleaverBag", 2000000, ref shop, ref nextSlot);
                        }
                        if (ReDownedVGigipede)
                        {
                            addModItemToShop(Redemption, "VlitchGigipedeBag", 3000000, ref shop, ref nextSlot);
                        }
                        if (ReDownedObliterator)
                        {
                            addModItemToShop(Redemption, "OmegaOblitBag", 5000000, ref shop, ref nextSlot);
                        }
                        if (ReDownedPZero)
                        {
                            addModItemToShop(Redemption, "PZBag", 6000000, ref shop, ref nextSlot);
                        }
                        if (ReDownedThornRe && ReDownedGolemRe)
                        {
                            addModItemToShop(Redemption, "ThornPZBag", 7000000, ref shop, ref nextSlot);
                        }
                        if (ReDownedNebuleus)
                        {
                            addModItemToShop(Redemption, "NebBag", 10000000, ref shop, ref nextSlot);
                        }
                    }
					*/
                }
            }
        }
        private void addModItemToShop(Mod mod, String itemName, int price, ref Chest shop, ref int nextSlot)
        {
            if (mod.TryFind<ModItem>(itemName, out ModItem currItem))
                shop.item[nextSlot].SetDefaults(currItem.Type);
            shop.item[nextSlot].shopCustomPrice = price;
            nextSlot++;
        }
    }
}