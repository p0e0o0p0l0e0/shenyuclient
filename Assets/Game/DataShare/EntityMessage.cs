using System;


public enum EntityMessage
{
	///<Battle>
	BATTLE_ENTER_AUTOATTACK_FAIL = 100,// 不能进入战斗
	BATTLE_AUTOATTCK_START,
	BATTLE_AUTOATTCK_END,
	BATTLE_ERROR_DISTANCE,
	BATTLE_ERROR_DIR,
	BATTLE_KILL,
	DALUANDOU_KILL_PLAYER,
	BATTLE_JION_KILL,
	BATTLE_KILLED,
	BATTLE_KILLED_BY_NPC,
	BATTLE_KILLED_BY_PLAYER,
	BATTLE_KILLED_BY_GUILD_PLAYER,
	BATTLE_REVIVE,

	BATTLE_MISS_ATTCKER = 120,// 对[&]失误
	BATTLE_MISS_VICTIM,// [&]对你失误
	BATTLE_BLOCK_ATTCKER,//[&]格挡了伤害
	BATTLE_BLOCK_VICTIM,//你格挡了[&]伤害
	BATTLE_DAMAGE_ATTCKER,// 对[&]造成&效果&伤害(吸收&)
	BATTLE_DAMAGE_VICTIM,// [&]对你造成&效果&伤害(吸收&)
	BATTLE_DAMAGE_REFLECT,// 对[&]反射&伤害
	BATTLE_DAMAGE_REFLECTED,// [&]对你反射&伤害
	BATTLE_DAMAGE_RECOVER_HP,// 伤害输出增加&生命

    BATTLE_HOT_CASTER,// 施法者加血
    BATTLE_HOT_TARGET,// 目标加血

	BATTLE_SPELL_USE_MELEE = 180,// 启用近战主技能
	BATTLE_SPELL_USE_RANGE,// 启用远程主技能

	///<通用>
	SEALED_DATA_ERROR_0 = 200,// 配置数据出错>
	SEALED_DATA_ERROR_1,// 配置数据[&]出错
	SEALED_DATA_NOT_EXIST_0, // 配置数据不存在
	SEALED_DATA_NOT_EXIST_1, // 配置数据[&]不存在

	DYNAMIC_PASSWORD_ERROR = 300,// 验证码错误
	DYNAMIC_PASSWORD_EMPTY, // 请先获取验证码
	DYNAMIC_PASSWORD_EXPIRE, // 验证码过期, 请重新获取
	DYNAMIC_PASSWORD_BUSSY, // 验证码获取过于平凡

	PLAYER_ONLINE = 400,// [&]上线
	PLAYER_OFFLING,// [&]下线
	PLAYER_NOT_ONLINE_0,// 不在线
	PLAYER_NOT_ONLINE_1,// [&]不在线
	PLAYER_NOT_EXIST_0,// 不存在
	PLAYER_NOT_EXIST_1,// [&]不存在
	PLAYER_REQ_STATE_MATCH_FAIL,
	PLAYER_NOT_STATE_MATCH_FAIL,

	GM_LOCKED = 500, // 管理员已经关闭此功能
	RIGHT_TO_LOW,//权限不足
	PASSWORD_FAIL, // 密码错误
	ACTION_BUSY, // 操作繁忙
	TIME_ERROR,	// 使用加速外挂
	OPERATE_FAUL, // 挂机犯规
	OPERATE_FAUL_CD, // 挂机犯规剩余冷却时间&

	COUNT_OUT = 600, // 次数不足
	COUNT_OUT_1, // 次数不足&次
	AREADY_EXIST,//[&]已经存在
	NOT_EXIST,// [&]不存在
	AREADY_OWN, // [&]已经拥有
	NOT_OWN, // [&]还未拥有
	REQUEST,// 需要[&]
	NOT_ENOUGH_0, // 不足
	NOT_ENOUGH_1, // 不足&
	NOT_ENOUGH_2, // [&]不足&
	RESERVE_VALUE_NOT_ENOUGH_0, // 剩余额度不足
	RESERVE_VALUE_NOT_ENOUGH_1, // 剩余额度为&
	RESERVE_COUNT_NOT_ENOUGH_0, // 剩余数量不足
	RESERVE_COUNT_NOT_ENOUGH_1, // 剩余数量为&
	AREADY_PASS_0, // 已经通过
	AREADY_PASS_1, // 已经通过[&]
	NOT_PASS_0, // 没有通过
	NOT_PASS_1, // 没有通过[&]
	INVITE_ALREADY, // 已经邀请

	BUY_OUT = 700, // 购买次数已用完
	BUY_OUT_1, // 购买次数超过&次, 不能购买
	BUY_COUNT, // 购买一次
	BUY_COUNT_1, // 购买&次

	CHAT_GROUP_NOT_EXIST = 750, // 聊天频道不存在

	MEMBER_FULL_0 = 800, // 成员数量已满
	MEMBER_FULL_1, // 成员数量已满&个
	MEMBER_NOT_ENOUGH_0, // 成员数量不足
	MEMBER_NOT_ENOUGH_1, // 成员数量不足&个

	CHANNEL_COOLING = 900, // &冷却中, 剩余&时间
	TIME_UN_READY, // 时间未到
	TIME_UN_READY_1, // 剩余时间&
	TIME_OUT, // 已经过期
	TIME_OUT_1, // 已经过期&

	FUNC_ADD = 1000, // 新增[&]
	FUNC_CLOSED, // [&]未开启
	FUNC_POLICY_ERROR, // [&]关闭此功能
	FUNC_CLOSED_GM, // [&]暂时被GM关闭

	INPUT_BUSY = 1100, // 输入过于平凡
	INPUT_EMPTY, // 输入不能为空
	INPUT_FAIL_LEN, // 输入长度为&-&
	RESERVE_STRING, // 含有保留词汇
	NAME_EXIST, // 名字已存在
	NAME_EMPTY, // 名字为空
	SETTING_UPDATE,// 设置成功
	SETTING_ERROR, // 设置异常
	TAKE_SUCCESS, // 领取成功
	TAKE_FAIL_EXIST, // 已经领取过
	OPERATE_SUCCESS,	// 操作成功
	OPERATE_ERROR,	// 操作异常
	OPERATE_CLOSED_GM, // 操作暂时被禁止
	UPDATE_SUCCESS,	// 更新成功
	UPDATE_ERROR,	// 更新失败

	TRANSPORT = 1200, // 传送成功
	TRANSPORT_FAIL_TO_NEAR, // 距离太近, 不需要传送
	SPACE_CLOSED, // 地图已经关闭
	SPACE_CLOSE, // [&地图]关闭
	SPACE_FORBID_EXIT, // 地图没有结束, 无法退出
	SPACE_EXPIRE, // 地图已经结束

	///<Attribute>
	LEVEL_UP = 1300,// 您升级为&级
	LEVEL_NOT_ENOUGH0,// 等级不足
	LEVEL_NOT_ENOUGH1,// 等级不足(需要&级)
	LEVEL_NOT_ENOUGH2,// 等级不匹配(需要&-&级)
	LEVEL_OUT,// 等级已封顶
	HP_UP,// 生命上升
	XP_UP,// 获得经验
	XP_NOT_ENOUGH,// 经验不足&
	XP_COST,// 经验消耗&
	OCCUPATION_ERROR,// 职业不满足
	POWER_NOT_ENOUGH_0,// 体力不足
	POWER_NOT_ENOUGH_1,// 体力不足&
	POWER_ADD,// 获得&体力
	POWER_DEL,// 消耗&体力

	///<Item>
	ITEM_ADD = 1400,
	ITEM_ADD_CNT,
	ITEM_DEL,// 删除&个&物品
	ITEM_USE,// 使用&物品
	ITEM_RECOVER,// 道具处于冷却状态
	ITEM_UNABLE_USE,//	无法使用
	ITEM_BAD,// [&]耐久度为零, 无法使用
	ITEM_UNABLE_REPAIR,//	该物品不可修理
	ITEM_NOT_NEED_REPAIR,//	[&]耐久度满, 无需修理
	ITEM_DURABILTY_DEL, // [&]耐久度下降&
	ITEM_DURABILTY_LOW, // [&]耐久度不足&%
	ITEM_EQUIP,// 装备&
	ITEM_DE_EQUIP,// 卸下&
	ITEM_UN_READY,// &还未到激活(剩余&时间)
	ITME_CLOSE,// &已经失效(过期&时间)
	ITEM_USE_LEVEL_FAIL,//&使用等级不够
	ITEM_USE_NOT_OPEN,//&暂时没有开放
	ITME_LICENCE_ERROR,//礼包激活码错误
	ITME_LICENCE_OLD,//礼包激活码已经被使用过
	ITME_LICENCE_SAME,//同类型礼包不能重复领取
	ITME_LICENCE_SUC,//礼包领取&个&成功
	ITEM_USE_FAIL_EXIST,// 使用失败, &存在
	ITEM_SALE,// 出售[&]
	ITEM_DIS_SALE,// [&]物品无法出售
	ITEM_BUY_BACK,// 物品回购成功
	ITEM_USE_COUNT_COST,// [&]使用次数消耗&次
	ITEM_USE_COUNT_OUT,// [&]使用次数已经用完(&次)
	ITEM_EXCHANGE_COUNT_COST,// [&]兑换消耗&次
	ITEM_EXCHANGE_COUNT_OUT,// [&]兑换不足(&次)
	ITEM_BUY_COUNT_OUT,// [&]购买次数已经用完(&次)
	ITEM_RECEIVE_COUNT_OUT,// [&]获得次数已经用完(&次)
	ITEM_DRAW_OUT_FAIL,// 物品无法拆分
	ITEM_DRAW_OUT_SUCCESS,// 物品拆分成功
	ITEM_STACK_NOT_ENOUGH_0,// 物品叠加数量不足
	ITEM_STACK_NOT_ENOUGH_1,// 物品叠加数量不足&
    ITEM_HP_MAX,// 满血无法使用&物品

    ///<Quest>
    QUEST_ADD = 1500,// 获得[&]
	QUEST_DEL,// 放弃[&]
	QUEST_ABANDON_FAIL, // [&]不能放弃
	QUEST_SUCCESS,//	 完成[&]
	QUEST_FAILURE,//	 [&]失败
	QUEST_DOUBLE_RECEIVE_FAIL, // 任务双倍领取失败
	DAILY_QUEST_REFRESH_FAIL, // 每日任务刷新失败
	DAILY_QUEST_COMPLETE_FAIL, // 每日任务不能完成
	DAILY_QUEST_QUALITY_UP_FAIL, // 每日任务升级失败
	DAILY_QUEST_QUALITY_UP, // 每日任务升级
	DAILY_QUEST_QUALITY_FULL, // 每日任务已经是顶级
	DAILY_QUEST_XP,// 获得&每日奖励积分
	RANDOM_QUEST_EXIST,// 卷轴任务已经存在, 不能在使用任务卷轴
	QUEST_SAME_EXIST,// 不能同时重复接取同任务
	QUEST_SELECT_OPTION_ITEM, // 请选择一个可选物品
	QUEST_LOOP_COUNT_OUT, // 任务次数(&次)已经用完
	QUEST_EXIST, // [&]已经存在

	///<Friend>
	FRIEND_ADD = 1600,// 您和&成为好友
	FRIEND_DEL,//	&已从好友名单中删除
	FRIEND_FULL,//	您的好友名单已满
	FRIEND_FULL1,//	对方的好友名单已满
	FRIEND_AREADY, // &已经是您的好友
	FRIEND_INVITEE_EMPTY,// 没有好友可以推荐
	BLACK_FRIEND_ADD,// 您将&归到黑名单
	BLACK_FRIEND_DEL,//您将&排出黑名单
	BLACK_FRIEND_FULL,//	您的黑名单名单已满
	BLACK_FRIEND_AREADY, // &已经是在黑名单
	FRIEND_INVITE_FAIL,// 您的邀请被&拒绝
	FRIEND_INVITOR_TO_MANY,// 剩余好友数量(&)小于候选人数量

	///<Bag>
	BAG_ITEM_NULL = 1700,//	找不到物品
	BAG_FULL,//	背包栏已满
	BAG_PACKAGE_ENTER_BAG, // &个&进入包裹
	BAG_PACKAGE_ENTER_BAG_LIST, // &进入包裹
	BAG_SLOT_LOCKED, // 背包栏位未开启
	BAG_ITEM_DROP_FAIL, // 不能丢弃

	///<Shortcut>
	SHORTCUT_NOT_FOR_ITEM = 1800,//	不能为&建立快捷方式
	SHORTCUT_ERROR,//	不能建立快捷方式

	///<Money>
	YINPIAO_UNENOUGH = 1900,// 银票不足&
	YINPIAO_RECEIVE,//获得&银票
	YINPIAO_SPEND,//花费&银票
	YINPIAO_REPLACE, //银票代购&次
	JINPIAO_UNENOUGH,//金票不足&
	JINPIAO_RECEIVE,//获得&金票
	JINPIAO_SPEND,//花费&金票
	JINZI_UNENOUGH,//金子不足&
	JINZI_RECEIVE,//获得&金子
	JINZI_SPEND,//花费&金子
	JINZI_TRANSFER_INF, // 金子转赠每次下限为&
	JINZI_TRANSFER_NOT_ENOUGH, // 金子转赠每日上限&, 剩余额度仅为&

	///<Space>
	SPACE_WIN = 2000,// 您在&取得胜利
	SPACE_FAIL,// 您在&失败了
	SPACE_CHANGE_FAIL,// 切换地图失败
	///<SpaceGroup>
	SPACE_GROUP_PASS = 2050, // [&]已经全部通关
	///<SpaceHeroLevel>
	SPACE_HERO_LEVEL_UP = 2060,// 您升级为&级
	SPACE_HERO_LEVEL_NOT_ENOUGH0,// 等级不足
	SPACE_HERO_LEVEL_NOT_ENOUGH1,// 等级不足(需要&级)
	SPACE_HERO_LEVEL_NOT_ENOUGH2,// 等级不匹配(需要&-&级)
	SPACE_HERO_LEVEL_EFFECT,// 恭喜你获得了[&]升级效果
	SPACE_HERO_XP_UP,// 获得经验

	///<SpaceEvent>
	SPACE_EVENT_0 = 2100, // [&]发生了
	SPACE_EVENT_1, // [&]执行了[&]

	///<SpaceBirthController>
	SPACE_CONTROLLER_COMPLETE = 2200,// [&]已经完成
	SPACE_CONTROLLER_UNCOMPLETE,// [&]尚未完成

	///<Invite>
	INVITED_BUSY = 2300, //&正忙
	INVITE_SUCCESS, // &接受邀请
	INVITE_FAIL, // &拒绝邀请

	///<Mail>
	MAIL_TARGET_FULL = 2400, // &邮件已满
	MAIL_SEND_SUCCESS, // 发送成功
	MAIL_SEND_FAIL_NO_PLAYER, // 发送失败, 没有指定的用户
	MAIL_SEND_FAIL_PLAYER_EMPTY, // 收件人为空
	MAIL_SEND_FAIL_TITLE_EMPTY, // 邮件标题为空
	MAIL_SEND_FAIL_CONTENT_EMPTY, // 邮件内容为空
	MAIL_LOOT, // 获得一份奖励邮件

	///<MarketItem>
	MARKET_ITEM_BUY_COUNT_NOT_ENOUGH = 2500,// 购买次数不足&

	///<BigSpacePK>
	BIG_SPACE_PK_START = 2600, // 切磋开始
	BIG_SPACE_PK_END, // 切磋结束
	BIG_SPACE_PK_WIN, // PK胜出
	BIG_SPACE_PK_LOSE, // PK败退
	BIG_SPACE_PK_INVITE_FAIL, // PK邀请失败

	///<Guild>
	GUILD_CREATE_SUCCESS = 2700,// 成功创建工会
	GUILD_CREATE_FAIL_SAME_NAME,// 创建失败, 工会重名
	GUILD_LEVEL_UP,// 工会升级
	GUILD_SELF_ENTER,// 加入&工会
	GUILD_SELF_EXIT,// 退出&工会
	GUILD_OTHER_ENTER,// &加入工会
	GUILD_OTHER_EXIT,// &退出工会
	GUILD_APPLY,// 申请加入&工会
	GUILD_APPLYS,// 申请加入&工会
	GUILD_APPLY_IN_PLAYER_FULL,// 申请行会数量已满(&个)
	GUILD_APPLY_IN_GUILD_FULL,// 申请人数数量已满(&个)
	GUILD_AGREE_APPLY,// 加入工会申请被&通过
	GUILD_DISAGREE_APPLY,// 加入工会申请被&否决
	GUILD_NEED_EXIT,// 必须先脱离工会
	GUILD_XP_NOT_ENOUGH,// 行会经验不足
	GUILD_APPLYER_OWNED,// 已经加入其他行会
	GUILD_EMPTY,// 需要行会才能使用
	GUILD_IMPEACH_FAIL_TIME, // 弹劾时间不足
	GUILD_SMALL_SPACE_START,// 行会副本[&]开始
	GUILD_SMALL_SPACE_END,// 行会副本[&]结束
	GUILD_SMALL_SPACE_EXIST,// 行会副本[&]已经存在
	GUILD_SMALL_SPACE_NOT_READY,// 行会副本[&]未开启
	GUILD_SMALL_SPACE_ENTER,// [&]进入行会副本[&]
	GUILD_DICESION_LOW_0, //行会权限不足
	GUILD_POSITION_LOW_1, //行会权限不足, 需要[&]及以上职位
	GUILD_POSITION_COUNT_OUT_0, // 职位人数已满
	GUILD_POSITION_COUNT_OUT_1, // 职位人数已满&个
	GUILD_ACTIVITY_SEAT_START, // 行会活动报名成功
	GUILD_ACTIVITY_SEAT_END, // 结束行会活动报名

	///<Faction>
	FACTION_UPDATE = 2800, // 阵营更新
	FACTION_NOT_MATCH, // 阵营不匹配
	FACTION_NOT_EXIST, // 阵营不存在

	///<SpaceObject>
	SPACE_OBJECT_BUSY = 2900, // 物件冷却中, 剩余&时间

	///<Activity>
	ACTIVITY_START = 3000, // [&]开始
	ACTIVITY_END, // [&]结束
	ACTIVITY_CLOSED,// [&]未开
	ACTIVITY_ENTER,// 参与[&]
	ACTIVITY_ENTER_COUNTED,// 消耗一次活动次数
	ACTIVITY_ENTER_COUNT_OUT,// 活动进入次数(&/&)已满
	ACTIVITY_EXIT,// 离开[&]
	ACTIVITY_DEACTIVE, // 活动未开始

	///<Goal>
	GOAL_COMPLETE = 3100,//完成成就&

	///<Trade>
	TRADE_NOT_EXIST = 3200,// 交易不存在
	TRADE_PRICE_UPDATE,// 价格更新
	TRADE_DEL,// 交易取消
	TRADE_DEL_FAIL,// 交易取消失败
	//
	TRADE_ITEM_FULL = 3210, //物品交易栏已满
	TRADE_ITEM_RECEIVE,// 物品交易成功
	TRADE_ITEM_COUNT_NOT_ENOUGH, //交易物品数量不足&个
	TRADE_ITEM_ADD,// 新增物品交易&个[&]
	TRADE_ITEM_OUT_COUNT_OUT, // [&]的出售次数已经用完(&次)
	TRADE_ITEM_AUCTION_COUNT_OUT,//竞价次数用完
	TRADE_ITEM_AUCTION_PRICE_LOW,//竞价失败(价格没有竞争力)
	TRADE_ITEM_AUCTION_PRICE_HIGHT,//竞价过高
	TRADE_ITEM_AUCTION_SUC,//竞价成功
	TRADE_ITEM_ADD_FAIL_PRICE,//价格异常
	//
	TRADE_MONEY0_FULL = 3250, // 官银交易栏已满
	TRADE_MONEY0_RECEIVE,// 交易成功, 或得&官银
	TRADE_MONEY0_ADD,// 新增交易&官银
	//
	TRADE_MONEY1_FULL = 3260, // 金子交易栏已满
	TRADE_MONEY1_RECEIVE,// 交易成功, 或得&金子
	TRADE_MONEY1_ADD,// 新增交易&金子

	///
	ATTENTION_ADD = 3300, //添加关注[&]
	ATTENTION_DEL, //取消关注[&]

	///<Party>
	PARTY_IN_PARTY = 3400,// 组队已经存在
	PARTY_EXIST,// [&]已经存在
	PARTY_NOT_EXIST, //组队不存在
	PARTY_CREATE,// 创建[&]
	PARTY_ADD_MEMBER,// [&]加入
	PARTY_DEL_MEMBER,// [&]退出
	PARTY_MEMBER_EXIST,// [&]已经存在
	PARTY_MEMBER_FULL, // 人员已满
	PARTY_MEMBER_OUT, // 人数最多&个
	PARTY_INVITE,// 邀请[&]
	PARTY_INVITED,// [&]已经被邀请
	PARTY_INVITEE_IN_OTHER,// [&]已经在其他队伍
	PARTY_INVITEE_AGREE, // [&]接受了邀请
	PARTY_INVITEE_DESAGREE,// [&]拒绝了邀请
	PARTY_APPLY, // 申请加入[&]
	PARTY_RECOMMAND, // [&]推荐了[&]
	PARTY_RECOMMAND_AGREE, // [&]接受了请求[&]
	PARTY_SPACE_UPDATE, // 地图更新成功
    PARTY_MATCH_TEAM_START, // 匹配队伍开始
    PARTY_MATCH_TEAM_END,   // 匹配队伍结束

    PARTY_MATCH_READY_FAIL, // 匹配没有准备好
	PARTY_MATCH_START,// 匹配开始
	PARTY_MATCH_END,// 匹配结束
	PARTY_MATCHING, // 匹配中不能操作
	PARTY_SPACE_EMPTY,// 匹配地图为空
	PARTY_SPACE_MEMBER_COUNT_OUT,// 人数超过[&]的上限&
	PARTY_SPACE_MEMBER_COUNT_NOT_ENOUGH,// 人数不足&
	PARTY_SPACE_MEMBER_COUNT_ERROR,// 人数&不在[&]的范围(&, &)内
	PARTY_SPACE_MEMBER_LEVEL_ERROR, // [&]无法满足[&]地图的等级需求&
	PARTY_APPLY_EMPTY, // 对方没有匹配
	PARTY_NOT_FIND_RIGHT, // 没有找到合适的队伍
    PARTY_VOTE_START, // 队长发起投票踢人

	///<Hero>
	HERO_ADD = 3500, // 获得[&]英雄
	HERO_NOT_EXIST, // 不存在[&]英雄
	HERO_ALREADY_EXIST, // 已经存在这个英雄
	HERO_WORKING_EMPTY, // 没有出战英雄
	HERO_LEVEL_UP,// [&]英雄升级
	HERO_LEVEL_FAIL, // 英雄等级不足
	HERO_NOT_ENOUGH_0, // 英雄数量不够
	HERO_NOT_ENOUGH_1, // 英雄数量不够&个

	HERO_QUALITY_UP = 3520,// 英雄品质升为[&]
	HERO_QUALITY_NOT_ENOUGH0,// 英雄品质不足
	HERO_QUALITY_NOT_ENOUGH1,// 英雄品质不足(需要[&])
	HERO_QUALITY_NOT_ENOUGH2,// 英雄品质不匹配(需要[&]-[&])
	HERO_QUALITY_OUT,// 英雄品质已封顶

	HERO_EQUIP = 3530,// [&]英雄装备[&]
	HERO_EQUIP_EXIST, // [&]英雄装备已经存在
	HERO_EQUIP_NOT_FULL, // [&]英雄装备不满

	HERO_STAR_UP = 3540, // [&]英雄升星
	HERO_STAR_OUT, // [&]英雄星级已满

	HERO_SPELL_LEVEL_UP = 3550, // [&]英雄[&]技能升级
	HERO_SPELL_LEVEL_OUT, // [&]英雄[&]技能满级
	HERO_SPELL_LOCKED, // 技能没有开启
    HERO_SPELL_INDEX_ERROR, //无效的技能索引
    HERO_SPELL_UID_INVALID, //无效的技能ID
	HERO_SPELL_ILLEGAL,	//技能不匹配(职业、性别、或主角等级)

	HERO_WORKING_MASTER_EMPTY = 3560, // 必须有Master出战
	HERO_WORKING_MASTER_ERROR, // 只能有一个Master出战

	HERO_WEAPON_LEVEL_UP = 3580, // [&]英雄武器升级
	HERO_WEAPON_LEVEL_OUT, // [&]英雄武器等级已满

	//<Spell>
	SPELL_CD = 3600, // [&]技能冷却中

	///<HeroKid>
	HERO_KID_ADD = 3700, // 获得[&]卡通角色
	HERO_KID_LEVEL_UP, // [&]升级
	HERO_KID_NOT_EXIST, // [&]不存在

	///<DayGift>
	DAY_GIFT_COUNT_OUT = 3800, // 今日已签到, 请明日再来

	ACTIVITY_DAY_GIFT_COUNT_OUT = 3820, // 今日已签到, 请明日再来

	///<Score>
	SCORE_ADD = 3900, // 获得[&]&分
	SCORE_DEL, // 消费[&]&分
	SCORE_NOT_ENOUGH,// [&]不足&

	///<DiscoverSpace>
	DISCOVER_SPACE_BUILDING_AREAY_OWN = 4000, // 建筑已经被占领
	DISCOVER_SPACE_HERO_DEAD, // 英雄已经死亡

	///<Account>
	SHENFENZHENG_EMPTY = 5000,// 身份证为空
	MOBILE_PHONE_EMPTY, // 电话号码为空
	BANK_NUMBER_EMPTY, // 银行卡为空

	///<HTTP>
	HTTP_MOBILEPHONE_NUMBER_ERROR = 5300, // 手机号格式不正确
	HTTP_ACCOUNT_NOT_BIND_MOBILEPHONE, // 没绑定过手机
	HTTP_SHENFENZHENG_ID_FORMAT_ERROR = 5310, // 身份证格式不正确
	HTTP_SHENFENZHENG_REPATE_BIND_ERROR, // 不能重复绑定身份证
	HTTP_SHENFENZHENG_NAME_INCONFORMITY_ERROR, // 身份证正确，姓名不一致 不予覆盖原注册时提供的身份证 视作绑定不成功
	HTTP_SHENFENZHENG_NOTEXST_ERROR, //身份证在公安库中不存在 不予覆盖原注册时提供的身份证 视作绑定不成功
	HTTP_ACCOUNT_NOT_BIND_BANK = 5320, // 没绑定过支付宝
	HTTP_BANK_FORMAT_ERROR, //支付宝帐号不是邮箱或手机格式
	HTTP_SENDMESSAGE_CONTENT_ERROR = 5330, // 短信内容过长
}
