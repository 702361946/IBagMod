using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COPanelList : MonoBehaviour
{
    public bool isStoryModeOn = true;
    #region about title and other main window
    [SerializeField] GameObject title;
    [SerializeField] GameObject playing;
    [SerializeField] GameObject curtain;
    Image imageCurtain;
    [SerializeField] GameObject btn_newGame;
    [SerializeField] GameObject[] leaf = new GameObject[2];
    Vector3 btn_newGame_startPosition;
    [SerializeField] GameObject title_total_layer;
    Vector3 titleMovePosition = new Vector3(-213, 372, 0);
    Vector3 titleTargetScale = new Vector3(1.8f, 1.8f, 1.8f);
    #region pause menu
    [SerializeField] GameObject pauseBack;
    Image pauseBackImage;
    [SerializeField] GameObject[] btnsPause = new GameObject[7];
    Vector3[] btnsPausePosition = new Vector3[7];
    [SerializeField] GameObject defaultReadSpeedStr;
    Text defaultReadSpeedStrText;
    [SerializeField] GameObject btnReadMode;
    Text btnReadModeText;
    [SerializeField] GameObject ExitSpeedSkipCurtain;
    #endregion
    #region pause menu in abyss
    [SerializeField] GameObject pause_panel_abyss;
    [SerializeField] GameObject pause_abyss_back;
    Image pause_abyss_back_image;
    [SerializeField] GameObject[] btnsAbyssPause = new GameObject[3];
    Vector3[] btnsAbyssPausePosition = new Vector3[3];
    #endregion
    #region save slot menu
    [SerializeField] GameObject saveLoadExitBtn;
    [SerializeField] GameObject saveLoadTitle;
    Vector3 saveLoadTitleStartPosition;
    Vector3 saveLoadTitleEndPosition;
    [SerializeField] GameObject saveLoadTitleStr;
    Text saveLoadTitleStrText;
    [SerializeField] GameObject[] btnSaveLoadSlot = new GameObject[8];
    Vector3[] btnSaveSlotStartPosition = new Vector3[8];
    Vector3[] btnSaveSlotEndPosition = new Vector3[8];
    Vector3[] btnLoadSlotStartPosition = new Vector3[8];
    Vector3[] btnLoadSlotEndPosition = new Vector3[8];
    [SerializeField] GameObject[] btnSaveLoadSlotBrief = new GameObject[8];
    Text[] btnSaveLoadSlotBriefText = new Text[8];
    #endregion
    #region history sentences
    [SerializeField] GameObject historySentenceLayer;
    [SerializeField] GameObject historySentencePara;
    Text historySentenceParaText;
    [SerializeField] GameObject appVersionInHistoryLayer;
    Text appVersionInHistoryLayerText;
    Vector3 targetHistorySentenceWindowsPosition = new Vector3(0, 320, 0);
    #endregion
    #region author info
    [SerializeField] GameObject authorInfoTitle;
    [SerializeField] GameObject[] mainAuthor = new GameObject[3];
    [SerializeField] Vector3[] mainAuthorStartPosition = new Vector3[3];
    [SerializeField] Vector3[] mainAuthorStartRotation = new Vector3[3];
    [SerializeField] Vector3[] mainAuthorTargetPositionIn = new Vector3[3];
    [SerializeField] Vector3[] mainAuthorTargetPositionOut = new Vector3[3];
    [SerializeField] Vector3[] mainAuthorTargetRotationIn = new Vector3[3];
    [SerializeField] Vector3[] mainAuthorTargetRotationOut = new Vector3[3];
    [SerializeField] GameObject otherAuthorInfo;
    [SerializeField] GameObject btn_closeAuthorInfo;
    Vector3 authorInfoTitleStartPosition = new Vector3(0, 530, 0);
    Vector3 authorInfoTitleTargetPosition = new Vector3(0, 450, 0);
    Vector3 otherAuthorInfoStartPosition = new Vector3(0, -700, 0);
    Vector3 otherAuthorInfoTargetPosition = new Vector3(0, -360, 0);
    [SerializeField] GameObject thankAuthorPanel;
    [SerializeField] GameObject versionStr;
    Text versionStrText;
    #endregion
    #endregion
    #region ending list
    [SerializeField] GameObject endingList;
    [SerializeField] GameObject endingListTitle;
    [SerializeField] GameObject endingListExitBtn;
    [SerializeField] GameObject endingListMoreInfo;
    Vector3 endingListMoreInfoStartPosition = new Vector3(-185, 343, 0);
    #endregion
    #region about bag cells

    COItemBoard bagCellBoardCanvas;
    [SerializeField] GameObject bagCellBoard;
    [SerializeField] GameObject panelLockHint;
    [SerializeField] GameObject readRushHint;
    Text readRushHintText;
    [SerializeField] GameObject[] autoForgeTitle = new GameObject[4];
    Text[] autoForgeTitleText = new Text[4];
    [SerializeField] Vector3 bagExitPosition;
    Vector3 startPosition = new Vector3();
    int startPositionId = 0;
    int endPositionId = 0;
    bool hasClickDown = false;
    Vector3 endPosition = new Vector3();
    [SerializeField] GameObject[] dragHintBack = new GameObject[2];
    [SerializeField] GameObject[] dragHint = new GameObject[2];
    Text[] dragHintText = new Text[2];
    [SerializeField] GameObject missionCountDownArea;
    [SerializeField] GameObject missionCountDownBar;
    [SerializeField] GameObject missionSkip;
    [SerializeField] GameObject missionCountDownTime;
    Text missionCountDownTimeText;
    #endregion
    #region about infopanel
    [SerializeField] float info_panel_trans_speed1 = 5f;
    [SerializeField] float bar_trans_speed = 5;
    [SerializeField] GameObject itemInfoPanel;
    [SerializeField] GameObject infoPanel;
    #region forge btns
    [SerializeField] GameObject btnForgePanel;
    [SerializeField] GameObject btnDissolvePanel;
    [SerializeField] GameObject btnAutoForgePanel;
    [SerializeField] GameObject btnAutoDissolvePanel;
    [SerializeField] GameObject btnForgePanelPic;
    [SerializeField] GameObject btnDissolvePanelPic;
    [SerializeField] GameObject btnAutoForgePanelPic;
    [SerializeField] GameObject btnAutoDissolvePanelPic;
    [SerializeField] GameObject btnAutoForgeToEndPanelPic;
    [SerializeField] GameObject btnAutoDissolveToEndPanelPic;
    [SerializeField] GameObject btnAutoForgeToEndStr;
    [SerializeField] GameObject btnAutoDissolveToEndStr;
    Text btnAutoForgeToEndStrText;
    Text btnAutoDissolveToEndStrText;
    [SerializeField] GameObject autoForgeTargeLvPanel;
    [SerializeField] GameObject autoDissolveTargetLvPanel;
    [SerializeField] GameObject autoForgeTargetLvStr;
    [SerializeField] GameObject autoDissolveTargetLvStr;
    InputField autoForgeTargetLvStrText;
    InputField autoDissolveTargetLvStrText;
    #endregion
    #region item info
    [SerializeField] GameObject itemName;
    [SerializeField] GameObject itemLevel;
    [SerializeField] GameObject itemDesc;
    [SerializeField] GameObject itemProgressBar;
    [SerializeField] GameObject itemProgressValue;
    [SerializeField] GameObject itemInfoPanelExitBtn;
    Text itemNameText;
    Text itemLevelText;
    Text itemDescText;
    Text itemProgressValueText;
    #endregion
    #region bag info
    [SerializeField] GameObject bagEnergyBar;
    [SerializeField] GameObject bagEnergyValue;
    [SerializeField] GameObject bagExpBar;
    [SerializeField] GameObject bagExpValue;
    [SerializeField] GameObject bagLv;
    int currentBagEnergyValue = 0;
    int currentBagExpValue = 0;
    Text bagEnergyText;
    Text bagExpText;
    Text bagLvText;
    #endregion
    #endregion
    #region superTextBulletPosition
    [SerializeField] Vector3 forgeResultPosition;
    [SerializeField] Vector3 forgeErrorPosition;
    [SerializeField] Vector3 energyGotResultPosition;
    [SerializeField] Vector3 expGotResultPosition;
    [SerializeField] Vector3 itemLvUpReportPosition;
    [SerializeField] Vector3 bagLvUpReportPosition;
    [SerializeField] Vector3 expGotFlowStartPosition;
    #endregion
    #region about story paragraph
    [SerializeField] GameObject storyParagraphBackBack;
    [SerializeField] GameObject storyParagraphBackLayer;
    GameObject storyParaBack;
    [SerializeField] GameObject storyAccHint;
    [SerializeField] GameObject storyParagraphStr;
    Text storyParagraphStrText;
    [SerializeField] GameObject storyParagraphTitleStr;
    Text storyParagraphTitleStrText;
    Color storyParagraphTextColor = new Color(0.1f, 0.1f, 0.1f, 1);
    [SerializeField] GameObject[] storyParaBackPrefab = new GameObject[3];
    [SerializeField] GameObject storyParaExitBtn;
    [SerializeField] GameObject playingPanelMission;
    [SerializeField] GameObject playingPanelItemCell;
    [SerializeField] GameObject playingPanelBagInfo;
    [SerializeField] GameObject playingPanelPausePanel;
    [SerializeField] GameObject btn_rush_reading;
    [SerializeField] GameObject playingPanelAbyssFight;
    #region 面板隐藏相关
    Vector3 playingPanelMissionShowPosition;
    Vector3 playingPanelMissionHidePosition;
    Vector3 playingPanelItemCellShowPosition;
    Vector3 playingPanelItemCellHidePosition;
    #endregion
    #endregion
    #region mission and speak bubble
    [SerializeField] GameObject LayerSpeakCenter;
    [SerializeField] GameObject[] bubblePrefab = new GameObject[7];
    [SerializeField] Vector3[] startBubblePosition = new Vector3[2];
    [SerializeField] GameObject chapterBackPrefab;
    [SerializeField] GameObject chapterStageLayer;

    [SerializeField] GameObject currentMission;
    [SerializeField] GameObject missionCheck;
    [SerializeField] GameObject missionFail;
    Text currentMissionText;

    List<GameObject> newBubbleList = new List<GameObject>();
    List<SpeakBubbleUnit> bubbleUnitList = new List<SpeakBubbleUnit>();

    const int bubbleHeight = 150;
    const int displaySideWidth = 70;
    GameObject[] bubbleArray = new GameObject[6];
    SpeakBubbleUnit[] bubbleUnitArray = new SpeakBubbleUnit[6];
    #endregion
    #region  其它模式选择界面
    [SerializeField] GameObject btn_otherModeList;
    [SerializeField] GameObject panel_otherModeList;
    #endregion
    #region 深渊相关
    [SerializeField] GameObject heroChoosedPanelInAbyss;
    #region 深渊模式战斗信息
    [SerializeField] GameObject abyss_chooseList_panel;
    [SerializeField] GameObject abyss_name_self;
    [SerializeField] GameObject abyss_hp_self;
    [SerializeField] GameObject abyss_atk_self;
    [SerializeField] GameObject abyss_name_enemy;
    [SerializeField] GameObject abyss_hp_enemy;
    [SerializeField] GameObject abyss_atk_enemy;
    Text abyss_name_self_text;
    Text abyss_hp_self_text;
    Text abyss_atk_self_text;
    Text abyss_name_enemy_text;
    Text abyss_hp_enemy_text;
    Text abyss_atk_enemy_text;

    #endregion
    #region 场景图
    [SerializeField] GameObject abyssSceneBackPic;
    Image abyssSceneBackPicImage;
    [SerializeField] List<Texture2D> abyssScenePrefab = new List<Texture2D>();
    [SerializeField] GameObject abyss_countDown;
    Text abyss_countDown_text;
    [SerializeField] GameObject abyss_stageName;
    Text abyss_stageName_text;
    [SerializeField] GameObject abyss_countDown_skip;
    #endregion
    #region 状态图标
    [SerializeField] GameObject[] heroDebuffs = new GameObject[2];
    [SerializeField] GameObject[] monsterDebuffs = new GameObject[2];
    [SerializeField] GameObject[] heroDebuffsBar = new GameObject[2];
    [SerializeField] GameObject[] monsterDebuffsBar = new GameObject[2];
    [SerializeField] GameObject[] heroDebuffsLv = new GameObject[2];
    [SerializeField] GameObject[] monsterDebuffsLv = new GameObject[2];
    Text[] heroDebuffsLvText = new Text[2];
    Text[] monsterDebuffsLvText = new Text[2];
    [SerializeField] GameObject heroErosionDef;
    [SerializeField] GameObject monsterErosionDef;
    [SerializeField] GameObject heroErosionDefBar;
    [SerializeField] GameObject monsterErosionDefBar;
    [SerializeField] GameObject heroErosionDefLv;
    [SerializeField] GameObject monsterErosionDefLv;
    Text heroErosionDefLvText;
    Text monsterErosionDefLvText;

    [SerializeField] GameObject[] heroBuffs = new GameObject[3];
    [SerializeField] GameObject[] monsterBuffs = new GameObject[3];
    [SerializeField] GameObject[] heroBuffsBar = new GameObject[3];
    [SerializeField] GameObject[] monsterBuffsBar = new GameObject[3];
    [SerializeField] GameObject[] heroBuffsLv = new GameObject[3];
    [SerializeField] GameObject[] monsterBuffsLv = new GameObject[3];
    [SerializeField] GameObject[] heroBuffsIcon = new GameObject[3];
    [SerializeField] GameObject[] monsterBuffsIcon = new GameObject[3];
    Text[] heroBuffsLvText = new Text[3];
    Text[] monsterBuffsLvText = new Text[3];
    Image[] heroBuffsIconImage = new Image[3];
    Image[] monsterBuffsIconImage = new Image[3];
    Image[] heroBuffsBarImage = new Image[3];
    Image[] monsterBuffsBarImage = new Image[3];
    #endregion
    #region 信息面板
    [SerializeField] GameObject abyss_hero_info_panel;
    [SerializeField] GameObject abyss_hero_name;
    [SerializeField] GameObject abyss_hero_weapon_info;
    [SerializeField] GameObject abyss_hero_head_info;
    [SerializeField] GameObject abyss_hero_body_info;
    [SerializeField] GameObject abyss_hero_leg_info;
    [SerializeField] GameObject abyss_hero_foot_info;
    [SerializeField] GameObject abyss_hero_set_eat_alert;
    [SerializeField] GameObject abyss_hero_set_equip_alert;
    [SerializeField] GameObject abyss_hero_set_vibration;
    Text abyss_hero_name_text;
    Text abyss_hero_weapon_info_text;
    Text abyss_hero_head_info_text;
    Text abyss_hero_body_info_text;
    Text abyss_hero_leg_info_text;
    Text abyss_hero_foot_info_text;
    Text abyss_hero_set_eat_alert_text;
    Text abyss_hero_set_equip_alert_text;
    Text abyss_hero_set_vibration_text;
    [SerializeField] GameObject[] abyss_takeDownEquip_btns = new GameObject[5];
    [SerializeField] GameObject[] abyss_equip_exp_bar = new GameObject[5];
    #endregion
    #region 受击表现显示
    [SerializeField] GameObject heroBody;
    Image heroBodyImage;
    [SerializeField] GameObject enemyBody;
    Image enemyBodyImage;
    #endregion
    #region 深渊排行榜
    [SerializeField] GameObject abyss_rankinglist_panel;
    [SerializeField] GameObject abyss_rankinglist_order_list;
    [SerializeField] GameObject abyss_rankinglist_name_list;
    [SerializeField] GameObject abyss_rankinglist_stage_list;
    [SerializeField] GameObject abyss_rankinglist_time_list;
    Text abyss_rankinglist_order_list_text;
    Text abyss_rankinglist_name_list_text;
    Text abyss_rankinglist_stage_list_text;
    Text abyss_rankinglist_time_list_text;
    [SerializeField] GameObject abyss_roundTime_hint;
    Text abyss_roundTime_hint_text;
    #endregion
    #endregion
    #region 调查问卷
    [SerializeField] GameObject surveyLayer;
    [SerializeField] GameObject surveyQuestion;
    Text surveyQuestionText;
    [SerializeField] GameObject[] surveyChoiceBtn = new GameObject[9];
    [SerializeField] GameObject[] surveyChoiceStr = new GameObject[9];
    Text[] surveyChoiceStrText = new Text[9];
    [SerializeField] GameObject[] surveyChoiceMark = new GameObject[9];
    [SerializeField] GameObject surveyPageId;
    Text surveyPageIdText;
    [SerializeField] GameObject surveyBtnPre;
    [SerializeField] GameObject surveyBtnNext;
    [SerializeField] GameObject surveyBtnComplete;
    #endregion
    #region 重要图层没有被隐藏的检查
    [SerializeField] List<GameObject> checkLayerList = new List<GameObject>();
    #endregion
    #region 合成模式按钮
    string std_color_str_1 = "#8D7A69";
    string std_color_str_2 = "#FFF3D0";
    Color std_color_1;
    Color std_color_2;
    [SerializeField] GameObject[] btn_combine_mode = new GameObject[3];
    [SerializeField] GameObject[] btn_combine_mode_str = new GameObject[3];
    Image[] btn_combine_mode_image = new Image[3];
    Text[] btn_combine_mode_str_text = new Text[3];
    [SerializeField] GameObject btn_combine_panel;
    #endregion
    #region 深渊商店
    [SerializeField] GameObject shopTotalPanel;
    [SerializeField] GameObject shopMainPanel;
    [SerializeField] GameObject shopBoardPanel;
    COItemBoard shopBoardPanelCanvas;
    [SerializeField] GameObject shopItemInfoPanel;
    #region 深渊商店标题区域
    string shop_color_str_1 = "#EFE3CF";
    string shop_color_str_2 = "#9A9979";
    Color shop_color_1;
    Color shop_color_2;
    [SerializeField] GameObject[] shopBtn = new GameObject[2];
    [SerializeField] GameObject[] shopBtnIcon = new GameObject[2];
    [SerializeField] GameObject[] shopBtnStr = new GameObject[2];
    Image[] shopBtnImage = new Image[2];
    Image[] shopBtnIconImage = new Image[2];
    Text[] shopBtnStrText = new Text[2];
    [SerializeField] GameObject shopRefreshBtn;
    #endregion
    #region 深渊商店道具信息区域
    [SerializeField] GameObject shopItemNameStr;
    Text shopItemNameStrText;
    [SerializeField] GameObject shopItemPriceStr;
    Text shopItemPriceStrText;
    [SerializeField] GameObject shopItemDescStr;
    Text shopItemDescStrText;
    [SerializeField] GameObject shopItemConfirmStr;
    Text shopItemConfirmStrText;
    [SerializeField] GameObject shopMoneyStr;
    Text shopMoneyStrText;
    #endregion
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        imageCurtain = curtain.GetComponent<Image>();
        btn_newGame_startPosition = btn_newGame.transform.localPosition;
        readRushHintText = readRushHint.GetComponent<Text>();
        btnReadModeText = btnReadMode.GetComponent<Text>();
        missionCountDownTimeText = missionCountDownTime.GetComponent<Text>();
        #region 气泡相关
        for (int i = 1; i <= 6; i++)
        {
            bubbleArray[i - 1] = null;
            bubbleUnitArray[i - 1] = null;
        }
        #endregion
        #region 合成模式按钮
        ColorUtility.TryParseHtmlString(std_color_str_1, out std_color_1);
        ColorUtility.TryParseHtmlString(std_color_str_2, out std_color_2);
        for (int i = 1; i <= 3; i++)
        {
            btn_combine_mode_image[i - 1] = btn_combine_mode[i - 1].GetComponent<Image>();
            btn_combine_mode_str_text[i - 1] = btn_combine_mode_str[i - 1].GetComponent<Text>();
        }
        SwitchCombineMode(2);
        #endregion
        #region 深渊商店
        ColorUtility.TryParseHtmlString(shop_color_str_1, out shop_color_1);
        ColorUtility.TryParseHtmlString(shop_color_str_2, out shop_color_2);
        shopTotalPanel.transform.localScale = Vector3.zero;
        shopBoardPanelCanvas = shopBoardPanel.GetComponent<COItemBoard>();
        shopBoardPanelCanvas.InitDataBoard(GameSlot.shop);
        for (int i = 1; i <= 2; i++)
        {
            shopBtnImage[i - 1] = shopBtn[i - 1].GetComponent<Image>();
            shopBtnIconImage[i - 1] = shopBtnIcon[i - 1].GetComponent<Image>();
            shopBtnStrText[i - 1] = shopBtnStr[i - 1].GetComponent<Text>();
        }
        shopItemNameStrText = shopItemNameStr.GetComponent<Text>();
        shopItemPriceStrText = shopItemPriceStr.GetComponent<Text>();
        shopItemDescStrText = shopItemDescStr.GetComponent<Text>();
        shopItemConfirmStrText = shopItemConfirmStr.GetComponent<Text>();
        shopMoneyStrText = shopMoneyStr.GetComponent<Text>();
        #endregion
        #region about save load slot menu
        saveLoadExitBtn.transform.localScale = Vector3.zero;
        saveLoadTitleStartPosition = saveLoadTitle.transform.localPosition;
        saveLoadTitleEndPosition = saveLoadTitleStartPosition - new Vector3(0, 120, 0);
        saveLoadTitleStrText = saveLoadTitleStr.GetComponent<Text>();
        for (int i = 1; i <= 8; i++)
        {
            btnLoadSlotStartPosition[i - 1] = btnSaveLoadSlot[i - 1].transform.localPosition;
            btnLoadSlotEndPosition[i - 1] = new Vector3(0, btnSaveLoadSlot[i - 1].transform.localPosition.y, 0);
            btnSaveSlotStartPosition[i - 1] = new Vector3(btnLoadSlotStartPosition[i - 1].x, btnLoadSlotStartPosition[i - 1].y + 50, 0);
            btnSaveSlotEndPosition[i - 1] = new Vector3(0, btnLoadSlotStartPosition[i - 1].y + 50, 0);
            btnSaveLoadSlotBriefText[i - 1] = btnSaveLoadSlotBrief[i - 1].GetComponent<Text>();
        }
        #endregion
        #region about pause menu
        pauseBack.transform.localScale = Vector3.zero;
        pauseBackImage = pauseBack.GetComponent<Image>();
        pauseBackImage.color = new Color(0, 0, 0, 0);
        for (int i = 1; i <= 7; i++)
        {
            btnsPausePosition[i - 1] = btnsPause[i - 1].transform.localPosition;
        }
        ResetPauseBtnsPosition();
        defaultReadSpeedStrText = defaultReadSpeedStr.GetComponent<Text>();
        #endregion
        #region about pause menu in abyss
        pause_abyss_back.transform.localScale = Vector3.zero;
        pause_abyss_back_image = pause_abyss_back.GetComponent<Image>();
        pause_abyss_back_image.color = new Color(0, 0, 0, 0);
        for (int i = 1; i <= 3; i++)
        {
            btnsAbyssPausePosition[i - 1] = btnsAbyssPause[i - 1].transform.localPosition;
        }
        ResetAbyssPauseBtnsPosition();
        #endregion
        #region history
        historySentencePara.transform.localPosition = new Vector3(-3, -386.4f, 0);
        historySentenceParaText = historySentencePara.GetComponent<Text>();
        appVersionInHistoryLayerText = appVersionInHistoryLayer.GetComponent<Text>();
        historySentenceLayer.transform.localScale = Vector3.zero;
        #endregion
        #region story para
        storyParagraphBackBack.transform.localScale = new Vector3(0, 1, 1);
        storyParaBack = Instantiate(storyParaBackPrefab[0], storyParagraphBackLayer.transform);
        storyParagraphStrText = storyParagraphStr.GetComponent<Text>();
        storyParagraphTitleStrText = storyParagraphTitleStr.GetComponent<Text>();
        storyParagraphStrText.text = "";
        storyParagraphTitleStrText.text = "";
        storyParagraphBackLayer.transform.localScale = new Vector3(0, 1, 1);
        currentMissionText = currentMission.GetComponent<Text>();
        #endregion
        #region item and bag UI component init
        itemNameText = itemName.GetComponent<Text>();
        itemLevelText = itemLevel.GetComponent<Text>();
        itemDescText = itemDesc.GetComponent<Text>();
        itemProgressValueText = itemProgressValue.GetComponent<Text>();
        bagEnergyText = bagEnergyValue.GetComponent<Text>();
        bagExpText = bagExpValue.GetComponent<Text>();
        bagLvText = bagLv.GetComponent<Text>();
        for (int i = 1; i <= 4; i++)
        {
            autoForgeTitle[i - 1].transform.localPosition = new Vector3(999, 0, 0);
            autoForgeTitleText[i - 1] = autoForgeTitle[i - 1].GetComponent<Text>();
        }
        bagCellBoardCanvas = bagCellBoard.GetComponent<COItemBoard>();
        bagCellBoardCanvas.InitDataBoard(GameSlot.dataBag);
        for (int i = 1; i <= 2; i++)
        {
            dragHintText[i - 1] = dragHint[i - 1].GetComponent<Text>();
            dragHintBack[i - 1].transform.localScale = Vector3.zero;
        }
        bagEnergyText.text = "100/100";
        bagExpText.text = "0/50";
        bagEnergyBar.transform.localScale = new Vector3(0, 1, 1);
        bagExpBar.transform.localScale = new Vector3(0, 1, 1);
        versionStrText = versionStr.GetComponent<Text>();
        versionStrText.text = "版本号：" + Application.version;
        GameStatus.hasLoadDisplay = true;
        #endregion
        #region 格子面板等隐藏
        playingPanelMissionShowPosition = playingPanelMission.transform.localPosition;
        playingPanelItemCellShowPosition = playingPanelItemCell.transform.localPosition;
        playingPanelMissionHidePosition = playingPanelMissionShowPosition + new Vector3(540, 0, 0);
        playingPanelItemCellHidePosition = playingPanelItemCellShowPosition + new Vector3(-540, 0, 0);
        #endregion
        #region forge btns
        btnAutoForgeToEndStrText = btnAutoForgeToEndStr.GetComponent<Text>();
        btnAutoDissolveToEndStrText = btnAutoDissolveToEndStr.GetComponent<Text>();
        autoForgeTargetLvStrText = autoForgeTargetLvStr.GetComponent<InputField>();
        autoDissolveTargetLvStrText = autoDissolveTargetLvStr.GetComponent<InputField>();
        #endregion
        #region 深渊相关
        abyss_name_self_text = abyss_name_self.GetComponent<Text>();
        abyss_hp_self_text = abyss_hp_self.GetComponent<Text>();
        abyss_atk_self_text = abyss_atk_self.GetComponent<Text>();
        abyss_name_enemy_text = abyss_name_enemy.GetComponent<Text>();
        abyss_hp_enemy_text = abyss_hp_enemy.GetComponent<Text>();
        abyss_atk_enemy_text = abyss_atk_enemy.GetComponent<Text>();
        heroBodyImage = heroBody.GetComponent<Image>();
        enemyBodyImage = enemyBody.GetComponent<Image>();
        abyss_countDown_text = abyss_countDown.GetComponent<Text>();
        abyss_stageName_text = abyss_stageName.GetComponent<Text>();
        abyssSceneBackPicImage = abyssSceneBackPic.GetComponent<Image>();
        
        #region 深渊状态图标
        for (int i = 1; i <= 2; i++)
        {
            heroDebuffsLvText[i - 1] = heroDebuffsLv[i - 1].GetComponent<Text>();
            monsterDebuffsLvText[i - 1] = monsterDebuffsLv[i - 1].GetComponent<Text>();
            heroDebuffs[i - 1].transform.localScale = Vector3.zero;
            monsterDebuffs[i - 1].transform.localScale = Vector3.zero;
        }
        heroErosionDefLvText = heroErosionDefLv.GetComponent<Text>();
        monsterErosionDefLvText = monsterErosionDefLv.GetComponent<Text>();
        heroErosionDef.transform.localScale = Vector3.zero;
        monsterErosionDef.transform.localScale = Vector3.zero;
        for (int i = 1; i <= 3; i++)
        {
            heroBuffsLvText[i - 1] = heroBuffsLv[i - 1].GetComponent<Text>();
            monsterBuffsLvText[i - 1] = monsterBuffsLv[i - 1].GetComponent<Text>();
            heroBuffsIconImage[i - 1] = heroBuffsIcon[i - 1].GetComponent<Image>();
            monsterBuffsIconImage[i - 1] = monsterBuffsIcon[i - 1].GetComponent<Image>();

            heroBuffsBarImage[i - 1] = heroBuffsBar[i - 1].GetComponent<Image>();
            monsterBuffsBarImage[i - 1] = monsterBuffsBar[i - 1].GetComponent<Image>();
            heroBuffs[i - 1].transform.localScale = Vector3.zero;
            monsterBuffs[i - 1].transform.localScale = Vector3.zero;
        }
        #endregion
        #region 深渊英雄装备设置信息界面
        abyss_hero_name_text = abyss_hero_name.GetComponent<Text>();
        abyss_hero_weapon_info_text = abyss_hero_weapon_info.GetComponent<Text>();
        abyss_hero_head_info_text = abyss_hero_head_info.GetComponent<Text>();
        abyss_hero_body_info_text = abyss_hero_body_info.GetComponent<Text>();
        abyss_hero_leg_info_text = abyss_hero_leg_info.GetComponent<Text>();
        abyss_hero_foot_info_text = abyss_hero_foot_info.GetComponent<Text>();
        abyss_hero_set_eat_alert_text = abyss_hero_set_eat_alert.GetComponent<Text>();
        abyss_hero_set_equip_alert_text = abyss_hero_set_equip_alert.GetComponent<Text>();
        abyss_hero_set_vibration_text = abyss_hero_set_vibration.GetComponent<Text>();
        #endregion
        #region 深渊排行榜
        abyss_rankinglist_order_list_text = abyss_rankinglist_order_list.GetComponent<Text>();
        abyss_rankinglist_name_list_text = abyss_rankinglist_name_list.GetComponent<Text>();
        abyss_rankinglist_stage_list_text = abyss_rankinglist_stage_list.GetComponent<Text>();
        abyss_rankinglist_time_list_text = abyss_rankinglist_time_list.GetComponent<Text>();
        abyss_roundTime_hint_text = abyss_roundTime_hint.GetComponent<Text>();
        #endregion
        #endregion
        #region 调查问卷
        surveyLayer.transform.localScale = Vector3.zero;
        surveyLayer.transform.localPosition = Vector3.zero;
        surveyQuestionText = surveyQuestion.GetComponent<Text>();
        surveyPageIdText = surveyPageId.GetComponent<Text>();
        for (int i = 1; i <= 9; i++)
        {
            surveyChoiceStrText[i - 1] = surveyChoiceStr[i - 1].GetComponent<Text>();
        }
        #endregion

    }
    /// <summary>
    /// 检测重要的图层没有被隐藏
    /// </summary>
    void CheckLayerNotHide()
    {
        for (int i = 1; i <= checkLayerList.Count; i++)
        {
            if (!checkLayerList[i - 1].activeSelf)
            {
                GameStatus.printErrorInfoBullet("重要图层被隐藏！！！");
                GameSound.NewMusicPage(15);
                GameStatus.CurrentSceneState = SceneState.loadingFailed;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameStatus.hasLoadAll)
        {
            if (GameStatus.hasLoadSlotData && GameStatus.hasLoadLanguage && GameStatus.hasLoadSound && GameStatus.hasLoadMapData && GameStatus.hasLoadDisplay)
            {
                GameStatus.hasLoadAll = true;
                GameStatus.CurrentSceneState = SceneState.title;
                title.transform.localScale = new Vector3(1, 1, 1);
                playing.transform.localScale = new Vector3(0, 1, 1);
                CheckLayerNotHide();
                if (LoadManager.isAllHeroOpenCheatOn)
                {
                    GameStatus.printErrorInfoBullet("数据加载错误！");
                    GameStatus.printErrorInfoBullet("数据加载错误！");
                    GameStatus.printErrorInfoBullet("数据加载错误！");
                    GameSound.NewMusicPage(15);
                }
            }
        }
        else
        {
            CheckSystemOrderList();
            if (GameStatus.CurrentSceneState != SceneState.playing || GameSlot.IsMsgBoxOn)
            {
                GameSlot.currentPlayingDragTime = 0f;
            }
            if (GameStatus.CurrentSceneState == SceneState.playing || GameStatus.CurrentSceneState == SceneState.playing_infopanel
                 || GameStatus.CurrentSceneState == SceneState.playing_story)
            {
                GameSlot.totalPlayingTime += Time.deltaTime;
                GameSlot.currentRoundPlayingTime += Time.deltaTime;
                CheckCombineModePanelDisplay();
                if (GameStatus.CurrentPlayMode == PlayMode.story)
                {
                    CheckUIHintDisplay();
                }
                else if (GameStatus.CurrentPlayMode == PlayMode.abyss)
                {
                    if (!GameSlot.IsMsgBoxOn && GameSlot.currentPlayingDragTime < 0.1f)
                    {
                        GameSlot.totalAbyssPlayingTime += Time.deltaTime;
                        GameSlot.dataBag.currentAbyssRoundTime += Time.deltaTime;
                    }
                    panelLockHint.transform.localScale = new Vector3(0, 1, 1);
                    if (!GameSlot.IsMsgBoxOn && GameSlot.currentPlayingDragTime < 0.1f)
                    {
                        UpdateAbyssFight();
                    }
                }
                if (GameStatus.CurrentSceneState == SceneState.playing)
                {
                    if (!GameSlot.IsMsgBoxOn)
                    {
                        if (!isStoryModeOn)
                        {
                            AutoSave();
                        }
                        if (GameStatus.canControl)
                        {
                            CheckBagCellClick();
                        }

                        if (GameSlot.currentPlayingDragTime < 0.1f)
                        {
                            EnergyRecover();
                            AutoCrystalForge();
                            PotionGenerate();
                            CopyItems();
                            if (GameStatus.CurrentPlayMode == PlayMode.story)
                            {
                                CheckMissionComplete();
                                UpdateShowStorySpeak();
                                CheckExitStoryParagraph();
                            }

                        }
                    }
                    CheckNumAndBarChange();
                }
                else if (GameStatus.CurrentSceneState == SceneState.playing_infopanel)
                {
                    if (!GameSlot.IsMsgBoxOn)
                    {
                        if (!isStoryModeOn)
                        {
                            AutoSave();
                        }
                        CheckPanelBtnDisplay();
                        if (GameStatus.CurrentPlayMode == PlayMode.story)
                        {
                            CheckMissionComplete();
                        }
                        if (GameSlot.IsOpenPanelRealTime)
                        {
                            EnergyRecover();
                            AutoCrystalForge();
                            PotionGenerate();
                            CopyItems();
                        }
                    }
                    CheckNumAndBarChange();
                }
                else if (GameStatus.CurrentSceneState == SceneState.playing_story)
                {
                    CheckNumAndBarChange();
                    UpdateShowStoryParagraph();
                    CheckEndingExitBtn();
                }
            }
            if ((GameStatus.CurrentSceneState == SceneState.playing && storyParagraphBackBack.transform.localScale.x < 0.02f)
                || (GameStatus.CurrentSceneState == SceneState.playing_story && GameSlot.isStoryModePanelOn))
            {
                CheckMissionDisplay();
            }
            if (GameStatus.CurrentSceneState == SceneState.abyss_shop_buy || GameStatus.CurrentSceneState == SceneState.abyss_shop_sell)
            {
                CheckCombineModePanelDisplay();
                CheckShopCellClick();
            }
            CheckClear();
        }
        CheckEscapeBtn();

    }
    void CheckEscapeBtn()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (GameStatus.CurrentSceneState == SceneState.title)
            {
                Application.Quit();
            }
            else if (GameStatus.CurrentSceneState == SceneState.playing)
            {
                if (GameStatus.CurrentPlayMode == PlayMode.story)
                {
                    ClickPauseBtn();
                }
                else if (GameStatus.CurrentPlayMode == PlayMode.abyss)
                {
                    AbyssOpenHeroInfoPanel();
                }
            }
            else if (GameStatus.CurrentSceneState == SceneState.playing_pause)
            {
                if (GameStatus.CurrentPlayMode == PlayMode.story)
                {
                    ClickPauseBtn();
                }
            }
            else if (GameStatus.CurrentSceneState == SceneState.playing_infopanel)
            {
                CloseInfoPanel();
            }
            else if (GameStatus.CurrentSceneState == SceneState.abyss_hero_info_check)
            {
                AbyssCloseHeroInfoPanel();
            }
            else if (GameStatus.CurrentSceneState == SceneState.endinglist)
            {
                CloseEndingList();
            }
            else if (GameStatus.CurrentSceneState == SceneState.abyss_choose)
            {
                ExitAbyssModeChooseList();
            }
        }
    }
    void AutoCrystalForge()
    {
        float autoCrystalForgeT = 3f;
        for (int i = 1; i <= 2; i++)
        {
            int forgeAtk = GameSlot.dataBag.GetTotalAutoForge(i);
            if (forgeAtk > 0)
            {
                int pId = 0;
                int oId = 0;
                if (i == 1)
                {
                    pId = GameSlot.dataBag.item[0].pId;
                }
                else if (i == 2)
                {
                    pId = GameSlot.dataBag.GetLeastLevelId();
                    if (pId == 0)
                    {
                        autoForgeTitle[2].transform.localPosition = new Vector3(999, 0, 0);
                        continue;
                    }
                }
                autoForgeTitle[i - 1].transform.localPosition = bagCellBoardCanvas.cellCenterPosition[pId - 1] + new Vector3(0, 130 + Mathf.Cos(Time.time * 4) * 6, 0);

                if (GameSlot.IsRecoverByReadMode)
                {
                    GameSlot.autoForgeCD[i - 1] += Time.deltaTime + GameSlot.RealReadRushPower;
                }
                if (GameSlot.autoForgeCD[i - 1] >= autoCrystalForgeT)
                {
                    GameSlot.autoForgeCD[i - 1] -= autoCrystalForgeT;

                    int iId = GameSlot.dataBag.GetItemId(pId);
                    oId = GameSlot.dataBag.GetItemOrderId(pId);
                    int lv = GameSlot.dataBag.item[oId - 1].lv;
                    if (GameStatus.CurrentSceneState != SceneState.playing_infopanel && GameStatus.CurrentSceneState != SceneState.playing)
                    {
                        return;
                    }
                    else if (lv >= GameSlot.dataBag.bagLevel * 10)
                    {
                        autoForgeTitleText[i - 1].text = SentenceBank.pack.sentences["auto"].ToString() + "("
                            + SentenceBank.pack.sentences["fullLv"].ToString() + ")";
                        return;
                    }
                    else
                    {
                        autoForgeTitleText[i - 1].text = SentenceBank.pack.sentences["auto"].ToString();
                        ItemAddProgress(pId, forgeAtk, true);

                        GameSlot.dataBag.boardHasChanged[pId - 1] = true;
                    }
                }
            }
            else
            {
                autoForgeTitle[i - 1].transform.localPosition = new Vector3(9999, 0, 0);
            }
        }
    }
    void EnergyRecover()
    {
        int energyT = 5;
        if (GameSlot.IsRecoverByReadMode)
        {
            GameSlot.energyRecoverCD += Time.deltaTime + GameSlot.RealReadRushPower;
        }
        if (GameSlot.energyRecoverCD >= energyT)
        {
            GameSlot.energyRecoverCD -= energyT;
            int recover = 5 + GameSlot.dataBag.GetTotalEnergyRecoverPlus();
            BagAddEnergy(recover);
        }
    }
    void PotionGenerate()
    {
        for (int i = 1; i <= GameSlot.dataBag.item.Count; i++)
        {
            if (GameSlot.dataBag.item[i - 1].AttriTypeList.Contains(AttributeType.generatePotion))
            {
                if (GameSlot.IsRecoverByReadMode)
                {
                    GameSlot.dataBag.item[i - 1].generateCD += Time.deltaTime + GameSlot.RealReadRushPower;
                }
                if (GameSlot.dataBag.item[i - 1].generateCD > GameSlot.dataBag.item[i - 1].MaxGenerateCD)
                {
                    GameSlot.dataBag.item[i - 1].generateCD -= GameSlot.dataBag.item[i - 1].MaxGenerateCD;
                    int emptyPosition = GameSlot.dataBag.GetFirstEmptyPosition();
                    if (emptyPosition > 0)
                    {
                        CreateItem(10, emptyPosition, GameSlot.dataBag.item[i - 1].GetValueByAttribute(AttributeType.generatePotion)[0]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
    void CopyItems()
    {
        for (int i = 1; i <= GameSlot.dataBag.item.Count; i++)
        {
            if (GameSlot.dataBag.item[i - 1].AttriTypeList.Contains(AttributeType.copyItem))
            {
                if (GameSlot.IsRecoverByReadMode)
                {
                    GameSlot.dataBag.item[i - 1].generateCD += Time.deltaTime + GameSlot.RealReadRushPower;
                }
                if (GameSlot.dataBag.item[i - 1].generateCD > GameSlot.dataBag.item[i - 1].MaxGenerateCD)
                {
                    GameSlot.dataBag.item[i - 1].generateCD -= GameSlot.dataBag.item[i - 1].MaxGenerateCD;
                    int emptyPosition = GameSlot.dataBag.GetFirstEmptyPosition();
                    if (emptyPosition > 0)
                    {
                        int itemId = GameSlot.dataBag.item[GameSlot.dataBag.item.Count - 1].id;
                        CreateItem(itemId, emptyPosition, GameSlot.dataBag.item[i - 1].GetValueByAttribute(AttributeType.copyItem)[0]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
    void CheckPanelBtnDisplay()
    {
        if (GameSlot.IsOpenDissolve)
        {
            btnDissolvePanel.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            btnDissolvePanel.transform.localScale = new Vector3(0, 0, 1);
        }
        if (GameSlot.IsOpenAutoForge)
        {
            btnAutoForgePanel.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            btnAutoForgePanel.transform.localScale = new Vector3(0, 0, 1);
        }
        if (GameSlot.IsOpenAutoDissolve)
        {
            btnAutoDissolvePanel.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            btnAutoDissolvePanel.transform.localScale = new Vector3(0, 0, 1);
        }

    }
    void CheckUIHintDisplay()
    {
        #region 加速阅读相关
        if (GameSlot.playerReadRushPower > 0.01f)
        {
            storyAccHint.transform.localScale = new Vector3(1, 1, 1);
            if (GameSlot.MissionListCount > 0)
            {
                readRushHintText.text = SentenceBank.pack.sentences["hint_cannot_speed_in_mission"].ToString();
            }
            else
            {
                readRushHintText.text = SentenceBank.pack.sentences["hint_speeding"].ToString();
            }
        }
        else
        {
            storyAccHint.transform.localScale = new Vector3(0, 1, 1);
            readRushHintText.text = "";
        }
        #region 加速阅读清CD
        if (GameSlot.playerReadRushPower > GameSlot.defaultReadSpeed)
        {
            GameSlot.playerReadRushPower -= Time.deltaTime * 0.1f;
            if (GameSlot.playerReadRushPower < GameSlot.defaultReadSpeed)
            {
                GameSlot.playerReadRushPower = GameSlot.defaultReadSpeed;
            }
        }
        #endregion
        #endregion
        if (GameSlot.current_mss.functionOpenState == 11111)
        {
            panelLockHint.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            panelLockHint.transform.localScale = new Vector3(0, 1, 1);
        }
        #region 任务倒计时相关
        if (GameSlot.current_mss.sentenceType == 4 && GameSlot.current_mss.msAfterSentence > 0)
        {
            missionCountDownArea.transform.localScale = Vector3.one;
            missionCountDownBar.transform.localScale = new Vector3(GameSlot.missionCompleteCheckCD * 1000 / GameSlot.current_mss.msAfterSentence, 1, 1);
            missionSkip.transform.localScale = Vector3.one;
            missionCountDownTimeText.text = MyStrFunc.GetRecordTimeByFloat(GameSlot.missionCompleteCheckCD);

        }
        else
        {
            missionCountDownArea.transform.localScale = Vector3.zero;
            missionSkip.transform.localScale = Vector3.zero;
        }
        #endregion
        #region 加速按钮
        if (GameStatus.CurrentSceneState == SceneState.playing)
        {
            btn_rush_reading.transform.localScale = Vector3.one;
        }
        else
        {
            btn_rush_reading.transform.localScale = Vector3.zero;
        }
        #endregion
    }
    void CheckCombineModePanelDisplay()
    {
        if (GameSlot.IsOpenAdvanceCombine &&
            (GameStatus.CurrentSceneState == SceneState.playing || GameStatus.CurrentSceneState == SceneState.playing_chapter ||
            GameStatus.CurrentSceneState == SceneState.playing_infopanel || GameStatus.CurrentSceneState == SceneState.playing_pause))
        {
            btn_combine_panel.transform.localScale = Vector3.one;
        }
        else
        {
            btn_combine_panel.transform.localScale = Vector3.zero;
        }
    }
    #region 深渊战斗更新逻辑
    void UpdateAbyssFight()
    {
        GameSlot.dataBag.UpdateAbyssFight();
        UpdateBodyDamageEffect();
        UpdateMonsterWait();
        if (GameSlot.dataBag.hero.hp <= 0)
        {
            string failStr = SentenceBank.pack.sentences["abyss_current_time"].ToString().Replace("t",
                MyStrFunc.GetRecordTimeByFloat(GameSlot.currentAbyssRoundResultTime)).Replace("n",
                (GameSlot.dataBag.currentAbyssStageId - 1).ToString());
            if (GameSlot.dataBag.currentAbyssStageId == 1)
            {
                failStr = SentenceBank.pack.sentences["abyss_current_time_on_1st_floor"].ToString();
            }
            GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["abyss_failed_title"].ToString().Replace("n",
                GameSlot.dataBag.currentAbyssStageId.ToString()), failStr, 53, true));
            if (GameStatus.CurrentSceneState == SceneState.playing_infopanel)
            {
                StartCoroutine("CloseInfoPanelCR");
            }
            StopCoroutine("heroGetDamageCR");
            StopCoroutine("heroDeadCR");
            StartCoroutine(heroDeadCR());
#if UNITY_ANDROID

                if (GameSlot.isVibrationOn)
                {
                    Handheld.Vibrate();
                }
#endif
            return;
        }
        if (GameSlot.dataBag.monsterWaitCD <= 0)
        {
            if (GameSlot.dataBag.monster.hp <= 0)
            {
                ClearMonsterBuffsIcon();
                StopCoroutine("enemyGetDamageCR");
                StopCoroutine("enemyDeadCR");
                StartCoroutine(enemyDeadCR());
                int addExp = Mathf.RoundToInt(GameSlot.dataBag.CurrentAddExp * (100 + GameSlot.dataBag.hero.AbyssExpBonus) / 100f);
                Debug.Log("addExp =" + addExp);
                GameSlot.dataBag.currentExpGot += addExp;
                AbyssDropItem();
                GameSlot.dataBag.currentMonsterId += 1;
                if (GameSlot.dataBag.currentMonsterId > GameSlot.dataBag.CurrentAbyssStage.monsterList.Count)
                {
                    int stageId = GameSlot.dataBag.currentAbyssStageId;
                    bool hasMeetShop = GameSlot.dataBag.GetShopOpen;
                    GameSlot.dataBag.FadeTradeScroll();
                    if (GameStatus.CurrentSceneState == SceneState.playing_infopanel)
                    {
                        StartCoroutine("CloseInfoPanelCR");
                    }
                    if (hasMeetShop)
                    {
                        AbyssOpenShop();
                    }
                    else
                    {
                        GameSlot.newMsgBoxList.Add(new MsgBox(
                            SentenceBank.pack.sentences["abyss_complete_stage"].ToString().Replace("n", stageId.ToString()),
                           SentenceBank.pack.sentences["abyss_to_next_stage"].ToString(), 52, true));
                    }
                    if (GameSlot.dataBag.CurrentIsAbyssBossStage)
                    {
                        GameSound.NewMusicPage(0);
                    }
                }
                else
                {
                    int mId = GameSlot.dataBag.currentMonsterId;
                    GameSlot.dataBag.monsterWaitCD = GameSlot.dataBag.CurrentAbyssStage.waitSecondsList[mId - 1] + GameSlot.dataBag.TotalAddWaitTime;
                    GameSlot.dataBag.FadeHideScroll();
                    #region BOSS层音乐渐变
                    GameSound.NewMusicPage(GameSlot.dataBag.CurrentAbyssStage.BGMId);
                    #endregion
                    #region 自动存档
                    GameSlot.SaveSlot(-1);
                    #endregion
                    int monsterId1 = GameSlot.dataBag.CurrentAbyssStage.monsterList[mId - 2];
                    string name1 = MapDataLib.abyss.abyssHeroList[monsterId1 - 1].name;

                    string str = SentenceBank.pack.sentences["abyss_complete_monster_title"].ToString().Replace("n", name1);
                    GameStatus.superTextBulletList.Add(new SuperTextBullet(str, 22, new Color(0.7f, 0.2f, 0.2f), new Vector3(0, -180, 0)));
                    LoadNextMonsterForPreview();
                }
            }
        }
    }
    float abyssNextHitDieWarningCD = 0;
    void UpdateMonsterWait()
    {
        if (GameSlot.dataBag.monsterWaitCD > 0)
        {
            GameSlot.dataBag.monsterWaitCD -= Time.deltaTime;
            if (Input.GetMouseButton(1))
            {
                Debug.Log("GameSlot.dataBag.nextMonster.NextPredictAtk = " + GameSlot.dataBag.nextMonster.NextPredictAtk);
            }
            if (GameSlot.dataBag.hero.hp <= GameSlot.dataBag.nextMonster.NextPredictAtk - GameSlot.dataBag.hero.Defence)
            {
                string str = SentenceBank.pack.sentences["abyss_hp_vs_next_warning"].ToString();
                abyss_countDown_text.text = SentenceBank.pack.sentences["abyss_count_down"].ToString().Replace(
                    "s", Mathf.CeilToInt(GameSlot.dataBag.monsterWaitCD).ToString()) + "\n" + str;
                abyssNextHitDieWarningCD += Time.deltaTime;
                if (abyssNextHitDieWarningCD > 2)
                {
                    abyssNextHitDieWarningCD -= 2;
                    GameStatus.superTextBulletList.Add(new SuperTextBullet(str, 39, new Color(0.7f, 0.2f, 0.2f),
                        new Vector3(0, -100 - GameStatus.weatherAbsorbTextBulletCount * 40, 0)));
                }
            }
            else
            {
                abyss_countDown_text.text = SentenceBank.pack.sentences["abyss_count_down"].ToString().Replace(
                    "s", Mathf.CeilToInt(GameSlot.dataBag.monsterWaitCD).ToString());
            }
            abyss_countDown_skip.transform.localScale = Vector3.one;
            if (GameSlot.dataBag.monsterWaitCD <= 0)
            {
                abyss_countDown_text.text = "";
                abyss_countDown_skip.transform.localScale = Vector3.zero;
                //BOSS层音乐渐变
                if (GameSlot.dataBag.CurrentIsAbyssBossStage)
                {
                    GameSound.NewMusicPage(18);
                }
                LoadNewMonsterInAbyss();
            }

        }
        else
        {
            abyss_countDown_text.text = "";
            abyss_countDown_skip.transform.localScale = Vector3.zero;
            if (GameSlot.dataBag.hero.hp <= GameSlot.dataBag.monster.NextPredictAtk - GameSlot.dataBag.hero.Defence)
            {
                string str = SentenceBank.pack.sentences["abyss_hp_next_will_die_warning"].ToString();
                abyss_countDown_text.text = str;
                abyssNextHitDieWarningCD += Time.deltaTime;
                if (abyssNextHitDieWarningCD > 1)
                {
                    abyssNextHitDieWarningCD -= 1;
                    GameStatus.superTextBulletList.Add(new SuperTextBullet(str, 39, new Color(0.7f, 0.2f, 0.2f),
                        new Vector3(0, -100 - GameStatus.weatherAbsorbTextBulletCount * 40, 0)));
                }
            }
        }
    }
    void UpdateBodyDamageEffect()
    {
        if (GameStatus.heroGetDamage)
        {
            GameStatus.heroGetDamage = false;
            StopCoroutine("heroGetDamageCR");
            StartCoroutine("heroGetDamageCR");
        }
        if (GameStatus.monsterGetDamage)
        {
            GameStatus.monsterGetDamage = false;
            StopCoroutine("enemyGetDamageCR");
            StartCoroutine("enemyGetDamageCR");
        }
    }
    IEnumerator heroGetDamageCR()
    {
        for (float t = 1; t >= 0; t -= Time.deltaTime * 2)
        {
            heroBodyImage.color = new Color(t, t, 1, 1);
            yield return 0;
        }
        for (float t = 0; t <= 1; t += Time.deltaTime * 2)
        {
            heroBodyImage.color = new Color(t, t, 1, 1);
            yield return 0;
        }
    }
    IEnumerator enemyGetDamageCR()
    {
        for (float t = 1; t >= 0; t -= Time.deltaTime * 2)
        {
            enemyBodyImage.color = new Color(t, t, 1, 1);
            yield return 0;
        }
        for (float t = 0; t <= 1; t += Time.deltaTime * 2)
        {
            enemyBodyImage.color = new Color(t, t, 1, 1);
            yield return 0;
        }
    }
    IEnumerator heroDeadCR()
    {
        for (float t = 1; t >= 0; t -= Time.deltaTime)
        {
            heroBodyImage.color = new Color(1, 1, 1, t);
            yield return 0;
        }
    }
    IEnumerator enemyDeadCR()
    {
        for (float t = 1; t >= 0; t -= Time.deltaTime)
        {
            enemyBodyImage.color = new Color(1, 1, 1, t);
            yield return 0;
        }
    }
    void UpdateAbyssBasicValue()
    {
        abyss_name_self_text.text = GameSlot.dataBag.hero.NameWithLv;
        abyss_hp_self_text.text = GameSlot.dataBag.hero.hp + "/" + GameSlot.dataBag.hero.HPMaxWithEquipment;
        int numLength = Mathf.FloorToInt(Mathf.Log10(GameSlot.dataBag.hero.hp)) + Mathf.FloorToInt(Mathf.Log10(GameSlot.dataBag.hero.HPMaxWithEquipment)) + 2;
        if (numLength >= 10)
        {
            abyss_hp_self_text.fontSize = 18;
        }
        else
        {
            abyss_hp_self_text.fontSize = 20;
        }
        abyss_atk_self_text.text = GameSlot.dataBag.hero.ATKWithLowHPBonus.ToString();
        UpdateAbyssHeroBuffs();
        if (GameSlot.dataBag.monsterWaitCD > 0)
        {
            abyss_name_enemy_text.text = "???";
            abyss_hp_enemy_text.text = "???";
            abyss_atk_enemy_text.text = "???";
            monsterDebuffs[0].transform.localScale = Vector3.zero;
            monsterDebuffs[1].transform.localScale = Vector3.zero;
        }
        else
        {
            abyss_name_enemy_text.text = GameSlot.dataBag.monster.NameWithLv;
            abyss_hp_enemy_text.text = GameSlot.dataBag.monster.hp + "/" + GameSlot.dataBag.monster.HPMaxWithEquipment;
            int numLength2 = Mathf.FloorToInt(Mathf.Log10(GameSlot.dataBag.monster.hp)) +
                Mathf.FloorToInt(Mathf.Log10(GameSlot.dataBag.monster.HPMaxWithEquipment)) + 2;
            if (numLength2 >= 10)
            {
                abyss_hp_enemy_text.fontSize = 18;
            }
            else
            {
                abyss_hp_enemy_text.fontSize = 20;
            }
            abyss_atk_enemy_text.text = GameSlot.dataBag.monster.ATKWithLowHPBonus.ToString();
            UpdateAbyssMonsterBuffs();
        }
    }
    void UpdateAbyssHeroBuffs()
    {
        for (int i = 1; i <= 2; i++)
        {
            if (GameSlot.dataBag.hero.debuff[i - 1].lv > 0)
            {
                heroDebuffs[i - 1].transform.localScale = Vector3.one;
                heroDebuffsBar[i - 1].transform.localScale = new Vector3(GameSlot.dataBag.hero.debuff[i - 1].ExpPct, 1, 1);
                heroDebuffsLvText[i - 1].text = GameSlot.dataBag.hero.debuff[i - 1].lv.ToString();
            }
            else
            {
                heroDebuffs[i - 1].transform.localScale = Vector3.zero;
            }
        }
        if (GameSlot.dataBag.hero.erosionDefence.lv > 0)
        {
            heroErosionDef.transform.localScale = Vector3.one;
            heroErosionDefBar.transform.localScale = new Vector3(GameSlot.dataBag.hero.erosionDefence.ExpPct, 1, 1);
            heroErosionDefLvText.text = GameSlot.dataBag.hero.erosionDefence.lv.ToString();
        }
        else
        {
            heroErosionDef.transform.localScale = Vector3.zero;
        }
        int n = GameSlot.dataBag.hero.buff.Count;
        for (int i = 1; i <= n; i++)
        {
            heroBuffs[i - 1].transform.localScale = Vector3.one;
            heroBuffsBar[i - 1].transform.localScale = new Vector3(GameSlot.dataBag.hero.buff[i - 1].ExpPct, 1, 1);
            heroBuffsLvText[i - 1].text = GameSlot.dataBag.hero.buff[i - 1].lv.ToString();
            int itemId = GameSlot.dataBag.hero.buff[i - 1].id;
            Color lvColor = MapDataLib.mdItemLib.item[itemId - 1].numColor;
            Color barColor = MapDataLib.mdItemLib.item[itemId - 1].barColor;
            heroBuffsLvText[i - 1].color = lvColor;
            heroBuffsBarImage[i - 1].color = barColor;
        }
        for (int i = n + 1; i <= 3; i++)
        {
            heroBuffs[i - 1].transform.localScale = Vector3.zero;
        }
    }
    void UpdateAbyssMonsterBuffs()
    {
        for (int i = 1; i <= 2; i++)
        {
            if (GameSlot.dataBag.monster.debuff[i - 1].lv > 0)
            {
                monsterDebuffs[i - 1].transform.localScale = Vector3.one;
                monsterDebuffsBar[i - 1].transform.localScale = new Vector3(GameSlot.dataBag.monster.debuff[i - 1].ExpPct, 1, 1);
                monsterDebuffsLvText[i - 1].text = GameSlot.dataBag.monster.debuff[i - 1].lv.ToString();
            }
            else
            {
                monsterDebuffs[i - 1].transform.localScale = Vector3.zero;
            }
        }
        if (GameSlot.dataBag.monster.erosionDefence.lv > 0)
        {
            monsterErosionDef.transform.localScale = Vector3.one;
            monsterErosionDefBar.transform.localScale = new Vector3(GameSlot.dataBag.monster.erosionDefence.ExpPct, 1, 1);
            monsterErosionDefLvText.text = GameSlot.dataBag.monster.erosionDefence.lv.ToString();
        }
        else
        {
            monsterErosionDef.transform.localScale = Vector3.zero;
        }
        int n = GameSlot.dataBag.monster.buff.Count;
        for (int i = 1; i <= n; i++)
        {
            monsterBuffs[i - 1].transform.localScale = Vector3.one;
            monsterBuffsBar[i - 1].transform.localScale = new Vector3(GameSlot.dataBag.monster.buff[i - 1].ExpPct, 1, 1);
            monsterBuffsLvText[i - 1].text = GameSlot.dataBag.monster.buff[i - 1].lv.ToString();
            int itemId = GameSlot.dataBag.monster.buff[i - 1].id;
            Color lvColor = MapDataLib.mdItemLib.item[itemId - 1].numColor;
            Color barColor = MapDataLib.mdItemLib.item[itemId - 1].barColor;
            monsterBuffsLvText[i - 1].color = lvColor;
            monsterBuffsBarImage[i - 1].color = barColor;
        }
        for (int i = n + 1; i <= 3; i++)
        {
            monsterBuffs[i - 1].transform.localScale = Vector3.zero;
        }
    }
    void UpdateAbyssBuffsIcon()
    {
        int heroCount = GameSlot.dataBag.hero.buff.Count;
        for (int i = 1; i <= heroCount; i++)
        {
            heroBuffs[i - 1].transform.localScale = Vector3.one;
            Texture2D iconTex = MapDataLib.mdItemLib.item[GameSlot.dataBag.hero.buff[i - 1].id - 1].pic;
            heroBuffsIconImage[i - 1].sprite = Sprite.Create(iconTex, new Rect(0, 0, 112, 112), new Vector2(0.5f, 0.5f));
        }
        for (int i = heroCount + 1; i <= 3; i++)
        {
            heroBuffs[i - 1].transform.localScale = Vector3.zero;
        }
        if (GameSlot.dataBag.monsterWaitCD <= 0)
        {
            int monsterCount = GameSlot.dataBag.monster.buff.Count;
            for (int i = 1; i <= monsterCount; i++)
            {
                monsterBuffs[i - 1].transform.localScale = Vector3.one;
                Texture2D iconTex = MapDataLib.mdItemLib.item[GameSlot.dataBag.monster.buff[i - 1].id - 1].pic;
                monsterBuffsIconImage[i - 1].sprite = Sprite.Create(iconTex, new Rect(0, 0, 112, 112), new Vector2(0.5f, 0.5f));
            }
            for (int i = monsterCount + 1; i <= 3; i++)
            {
                monsterBuffs[i - 1].transform.localScale = Vector3.zero;
            }
        }
    }
    void ClearMonsterBuffsIcon()
    {
        for (int i = 1; i <= 3; i++)
        {
            monsterBuffs[i - 1].transform.localScale = Vector3.zero;
        }
        for (int i = 1; i <= 2; i++)
        {
            monsterDebuffs[i - 1].transform.localScale = Vector3.zero;
        }
        monsterErosionDef.transform.localScale = Vector3.zero;
    }
    #endregion

    #region about system functions
    void AutoSave()
    {
        GameSlot.autoSaveCD += Time.deltaTime;
        if (GameSlot.autoSaveCD > 10f)
        {
            GameSlot.autoSaveCD -= 10f;
            if (MapDataLib.storyKnot.endingType[GameSlot.current_mss.largePartId - 1] == 0)
            {
                GameSlot.SaveSlot();
            }
        }
    }
    void CheckSystemOrderList()
    {
        if (GameSlot.systemOrderFunctionList.Count > 0)
        {
            GameSlot.isSystemOrderFunctionOn = true;
            if (GameSlot.systemOrderFunctionList[0] == 1)//清空存档
            {
                GameSlot.ClearStoryKnots(ClearStoryKnotsType.ManualClear);
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 2)//更新包裹总数值
            {
                UpdateCurrentBagValue();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 3)//自动分解直到消失/目标等级
            {
                AutoDissolveUntilDisappear();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 4)//自动分解直到消失立即完成/目标等级
            {
                GameSlot.dissolveUntilTargetLv = true;
                Debug.Log("target lv =" + GameSlot.targetDissolveLv);
                TryDissolveToEndStep2();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 5)//强制更新所有道具图标
            {
                bagCellBoardCanvas.UpdateItemCell();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 6)//更新道具面板
            {
                UpdateCurrentItemValue();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 7)//更新存档位摘要
            {
                UpdateSaveLoadSlotBriefText();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 8)//高级水晶分解警告
            {
                GameSlot.lastProtectDissolveWarned = false;
                Debug.Log("target lv =" + GameSlot.targetDissolveLv);
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 11)//锻造
            {
                Forge();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 17)//丢弃
            {
                ConfirmThrowItem();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 21)//召唤出包裹格子面板和任务面板
            {
                StopCoroutine("ShowPlayingUIItemAndMissionCR");
                StartCoroutine(ShowPlayingUIItemAndMissionCR());
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 22)//隐去包裹格子面板和任务面板
            {
                StopCoroutine("HidePlayingUIItemAndMissionCR");
                StartCoroutine(HidePlayingUIItemAndMissionCR());
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 23)
            {
                ClearAllBubble();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 31)//关闭锻造面板
            {
                CloseInfoPanel();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 41)//开始跳剧情
            {
                GameSlot.preIsManualReadState = GameSlot.isManualRead;
                GameSlot.isManualRead = false;
                Time.timeScale = 0.5f / (0.02f + GameSlot.defaultReadSpeed);
                ExitSpeedSkipCurtain.transform.localScale = Vector3.one;
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 42)//快速跳剧情的幕布按钮移除掉
            {
                ExitSpeedSkipCurtain.transform.localScale = Vector3.zero;
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 43)//快速跳剧情的幕布按钮无条件无弹窗移除掉
            {
                ExitSpeedSkipCurtain.transform.localScale = Vector3.zero;
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 51)//以选定的英雄开始深渊模式
            {
                StartNewAbyssGame();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 52)//深渊开始下一层
            {
                AbyssNextStage();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 53)//深渊模式失败并退出
            {
                GetResultAndExitAbyss();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 54)//深渊模式中断并退出
            {
                PauseAbyssAndReturnTitle();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 55)//深渊模式数值更新
            {
                UpdateAbyssBasicValue();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 56)//打败了一个怪物，进入下一个怪物
            {
                AbyssNextMonster();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 57)//更新面板上的设置信息
            {
                UpdateAbyssSettingText();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 58)//以1级开启深渊模式
            {
                StartNewAbyssGame(1);
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 59)//放弃深渊模式并结算
            {
                GiveUpAndExitAbyss();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 60)//打开深渊模式列表（在对话框中
            {
                EnterAbyssModeChooseList();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 61)//开始问卷
            {
                StartSurvey();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 62)//继续中断的深渊模式
            {
                ContinueAbyssGame();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 63)//放弃深渊模式之前的临时存档并从头开始
            {
                EnterAbyssModeChooseList();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 64)//确认商店刷新
            {
                PayToRefreshShopItems();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 65)//刷新BUFF图标
            {
                UpdateAbyssBuffsIcon();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 71)//还原成道具
            {
                GameSlot.dataBag.item[GameSlot.returnTargetOrderId - 1].id = GameSlot.returnToItemId;
                GameSlot.dataBag.boardHasChanged[GameSlot.returnTargetPositionId - 1] = true;
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] == 72)//还原成水晶
            {
                GameSlot.dataBag.item[GameSlot.returnTargetOrderId - 1].id = GameSlot.returnToCrystalId;
                GameSlot.dataBag.boardHasChanged[GameSlot.returnTargetPositionId - 1] = true;
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] >= 100 && GameSlot.systemOrderFunctionList[0] <= 107)//存档
            {
                GameSlot.SaveSlot(GameSlot.systemOrderFunctionList[0] - 100);
                UpdateSaveLoadSlotBriefText();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] >= 200 && GameSlot.systemOrderFunctionList[0] <= 207)////关掉暂停界面并读档
            {
                StopCoroutine("CloseLoadListCR");
                StartCoroutine("CloseLoadListCR");
                StopCoroutine("ExitPausePlayingCR");
                StartCoroutine("ExitPausePlayingCR");
                StopCoroutine("CurtainLeafInOutInPlaying");
                StartCoroutine("CurtainLeafInOutInPlaying");
                ResetPlayingUIUnits();
                GameSlot.LoadSingleSlot(GameSlot.systemOrderFunctionList[0] - 200);
                GameSlot.StartNewSentence();
                bagCellBoardCanvas.UpdateItemCell();
                UpdateCurrentBagValue();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            else if (GameSlot.systemOrderFunctionList[0] > 10000 && GameSlot.systemOrderFunctionList[0] < 20000)
            {
                StartGameFromKnot(GameSlot.systemOrderFunctionList[0] - 10000);
            }
            else if (GameSlot.systemOrderFunctionList[0] > 20000 && GameSlot.systemOrderFunctionList[0] < 30000)
            {
                StartGameFromKnotAtSwitchMission(GameSlot.systemOrderFunctionList[0] - 20000);
            }
            else if (GameSlot.systemOrderFunctionList[0] > 1000000 && GameSlot.systemOrderFunctionList[0] < 2000000)
            {
                int x = (GameSlot.systemOrderFunctionList[0] - 1000000) / 1000;
                int y = (GameSlot.systemOrderFunctionList[0] - 1000000) % 1000;
                GameSlot.StoryJumpTo(x, y);
                GameSlot.StartNewSentence();
                GameSlot.isSystemOrderFunctionOn = false;
            }
            GameSlot.systemOrderFunctionList.RemoveAt(0);
        }
    }
    #endregion

    #region about story showing
    void CheckEndingExitBtn()
    {
        if (GameSlot.current_mss.endingId > 0)
        {
            storyParaExitBtn.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            storyParaExitBtn.transform.localScale = new Vector3(0, 0, 1);
        }
    }
    void UpdateShowStorySpeak()
    {
        bool goAhead = false;
        if (GameSlot.currentSentenceState == SentenceState.readyToStart)
        {
            CheckNewSpeakBubble();
            GameSlot.currentSentenceState = SentenceState.bubbleShift;
            GameSlot.currentSentenceTime = GameSlot.bubbleShiftInTime;
            return;
        }
        if (!GameSlot.justEndOfPart || GameSlot.current_mss.canAutoJump || (GameSlot.current_mss.sentenceType == 1 && GameSlot.HasSwitch))
        {
            if (GameSlot.currentSentenceState == SentenceState.wait && GameSlot.IsRealManualRead)
            {

            }
            else
            {
                GameSlot.currentSentenceTime -= Time.deltaTime + GameSlot.RealReadRushPower;
            }
            if (GameSlot.currentSentenceTime <= 0f)
            {
                if (GameSlot.currentSentenceState == SentenceState.bubbleShift)
                {
                    if (GameSlot.current_mss.sentenceType == 1)
                    {
                        GameSlot.currentSentenceTime = 0f;
                        UpdateFadeOutSpeakBubbles();
                    }
                    GameSlot.currentSentenceState = SentenceState.reading;
                    GameSlot.currentSentenceTime = GameSlot.textFlowTime;
                    if (GameSlot.current_mss.sentenceType == 1)
                    {
                        ClearFarBubble();
                    }
                }
                else if (GameSlot.currentSentenceState == SentenceState.reading)
                {
                    if (GameSlot.current_mss.sentenceType == 1)
                    {
                        bubbleUnitArray[0].sentenceText.text = bubbleUnitArray[0].fullStr;
                    }
                    GameSlot.currentSentenceState = SentenceState.wait;
                    GameSlot.currentSentenceTime = GameSlot.current_mss.msAfterSentence * 0.001f;
                }
                else
                {
                    goAhead = true;
                    if (goAhead)
                    {
                        if (!GameSlot.justEndOfPart)
                        {
                            GameSlot.currentSentenceId += 1;
                            GameSlot.StartNewSentence();
                        }
                        else if (GameSlot.current_mss.canAutoJump)
                        {
                            GameSlot.StoryJumpTo(GameSlot.current_mss.autoJumpTo.x, GameSlot.current_mss.autoJumpTo.y);
                            GameSlot.StartNewSentence();
                        }
                        else if (GameSlot.current_mss.sentenceType == 1 && GameSlot.HasSwitch)
                        {
                            GameSlot.CheckSwitchCase();
                        }
                    }
                }
            }
            else
            {
                if (GameSlot.current_mss.sentenceType == 1)
                {
                    if (GameSlot.currentSentenceState == SentenceState.bubbleShift)
                    {
                        UpdateFadeOutSpeakBubbles();
                    }
                    else if (GameSlot.currentSentenceState == SentenceState.reading)
                    {
                        UpdateSpeakBubble();
                    }
                }
            }
        }
    }
    void CheckExitStoryParagraph()
    {
        if (GameSlot.toChangeFromStoryToPlaying)
        {
            GameSlot.toChangeFromStoryToPlaying = false;
            StartExitStoryParagraph();
        }
    }
    void StartExitStoryParagraph()
    {
        StopCoroutine("ExitStoryParagraphCR");
        StartCoroutine("ExitStoryParagraphCR");
    }
    IEnumerator ExitStoryParagraphCR()
    {
        float speedScale = 1 / GameSlot.bubbleShiftInTime;
        StartCoroutine("CurtainInOut", speedScale);
        for (float t = GameSlot.bubbleShiftInTime; t >= 0; t -= Time.deltaTime)
        {
            yield return 0;
        }
        StopCoroutine("UnHidePlayingUIUnitsCR");
        StartCoroutine(UnHidePlayingUIUnitsCR());
        storyParagraphBackLayer.transform.localScale = new Vector3(0, 1, 1);
        storyParagraphBackBack.transform.localScale = new Vector3(0, 1, 1);
        GameStatus.canControl = true;
    }
    void UpdateShowStoryParagraph()
    {
        if (GameSlot.toChangeFromPlayingToStory)
        {
            GameSlot.toChangeFromPlayingToStory = false;
            storyParagraphStrText.text = "";
            storyParagraphTitleStrText.text = "";
            StartStoryParagraphAnimation();
        }
        else if (GameSlot.toContinueStory)
        {
            GameSlot.toContinueStory = false;
            storyParagraphStrText.text = "";
            storyParagraphTitleStrText.text = "";
            StopCoroutine("StoryParagraphAnimationCR");
            StartCoroutine(StoryParagraphAnimationCR());
        }
    }
    void StartStoryParagraphAnimation()
    {
        StopCoroutine("StoryParagraphAnimationCRFull");
        StartCoroutine(StoryParagraphAnimationCRFull());
    }
    IEnumerator StoryParagraphAnimationCRFull()
    {
        float speedScale = 1 / (GameSlot.bubbleShiftInTime * 2);
        StartCoroutine("CurtainInOut", speedScale);
        StopCoroutine("HidePlayingUIUnitsCR");
        StartCoroutine(HidePlayingUIUnitsCR());

        for (float t = 0; t <= GameSlot.bubbleShiftInTime * 2; t += Time.deltaTime + GameSlot.RealReadRushPower)
        {
            yield return 0;
        }
        #region 创建新的故事图层
        Destroy(storyParaBack);
        storyParaBack = null;
        storyParaBack = Instantiate(storyParaBackPrefab[GameSlot.current_mss.diaBoxType - 1], storyParagraphBackLayer.transform);
        storyParagraphBackLayer.transform.localScale = new Vector3(1, 1, 1);
        storyParagraphBackBack.transform.localScale = new Vector3(1, 1, 1);
        #endregion
        #region 道具面板隐藏

        #endregion
        StartCoroutine(StoryParagraphAnimationCR());
    }
    IEnumerator HidePlayingUIUnitsCR()
    {
        for (float t = 0; t <= 0.7f; t += Time.deltaTime)
        {
            playingPanelMission.transform.localScale = Vector3.Lerp(playingPanelMission.transform.localScale, Vector3.zero,
                Mathf.Min(1, 15 * Time.deltaTime));
            playingPanelItemCell.transform.localScale = Vector3.Lerp(playingPanelItemCell.transform.localScale, Vector3.zero,
                Mathf.Min(1, 15 * Time.deltaTime));
            playingPanelBagInfo.transform.localScale = Vector3.Lerp(playingPanelBagInfo.transform.localScale, Vector3.zero,
                Mathf.Min(1, 15 * Time.deltaTime));
            playingPanelPausePanel.transform.localScale = Vector3.Lerp(playingPanelPausePanel.transform.localScale, Vector3.zero,
                Mathf.Min(1, 15 * Time.deltaTime));
            yield return 0;
        }
        playingPanelMission.transform.localScale = Vector3.zero;
        playingPanelItemCell.transform.localScale = Vector3.zero;
        playingPanelBagInfo.transform.localScale = Vector3.zero;
        playingPanelPausePanel.transform.localScale = Vector3.zero;
    }
    IEnumerator UnHidePlayingUIUnitsCR()
    {
        for (float t = 0; t <= 0.7f; t += Time.deltaTime)
        {
            playingPanelMission.transform.localScale = Vector3.Lerp(playingPanelMission.transform.localScale, Vector3.one,
                Mathf.Min(1, 15 * Time.deltaTime));
            playingPanelItemCell.transform.localScale = Vector3.Lerp(playingPanelItemCell.transform.localScale, Vector3.one,
                Mathf.Min(1, 15 * Time.deltaTime));
            playingPanelBagInfo.transform.localScale = Vector3.Lerp(playingPanelBagInfo.transform.localScale, Vector3.one,
                Mathf.Min(1, 15 * Time.deltaTime));
            playingPanelPausePanel.transform.localScale = Vector3.Lerp(playingPanelPausePanel.transform.localScale, Vector3.one,
                Mathf.Min(1, 15 * Time.deltaTime));
            yield return 0;
        }
        playingPanelMission.transform.localScale = Vector3.one;
        playingPanelItemCell.transform.localScale = Vector3.one;
        playingPanelBagInfo.transform.localScale = Vector3.one;
        playingPanelPausePanel.transform.localScale = Vector3.one;
    }
    IEnumerator ShowPlayingUIItemAndMissionCR()
    {
        playingPanelMission.transform.localPosition = playingPanelMissionHidePosition;
        playingPanelItemCell.transform.localPosition = playingPanelItemCellHidePosition;
        for (float t = 0; t <= 0.7f; t += Time.deltaTime)
        {
            playingPanelMission.transform.localPosition = Vector3.Lerp(playingPanelMission.transform.localPosition, playingPanelMissionShowPosition,
                Mathf.Min(1, 15 * Time.deltaTime));
            playingPanelItemCell.transform.localPosition = Vector3.Lerp(playingPanelItemCell.transform.localPosition, playingPanelItemCellShowPosition,
                Mathf.Min(1, 15 * Time.deltaTime));
            yield return 0;
        }
        playingPanelMission.transform.localPosition = playingPanelMissionShowPosition;
        playingPanelItemCell.transform.localPosition = playingPanelItemCellShowPosition;
        GameSlot.isHidingPanel = false;
    }
    IEnumerator HidePlayingUIItemAndMissionCR()
    {
        GameSlot.isHidingPanel = true;
        playingPanelMission.transform.localPosition = playingPanelMissionShowPosition;
        playingPanelItemCell.transform.localPosition = playingPanelItemCellShowPosition;
        for (float t = 0; t <= 0.7f; t += Time.deltaTime)
        {
            playingPanelMission.transform.localPosition = Vector3.Lerp(playingPanelMission.transform.localPosition, playingPanelMissionHidePosition,
                Mathf.Min(1, 15 * Time.deltaTime));
            playingPanelItemCell.transform.localPosition = Vector3.Lerp(playingPanelItemCell.transform.localPosition, playingPanelItemCellHidePosition,
                Mathf.Min(1, 15 * Time.deltaTime));
            yield return 0;
        }
        playingPanelMission.transform.localPosition = playingPanelMissionHidePosition;
        playingPanelItemCell.transform.localPosition = playingPanelItemCellHidePosition;
    }
    IEnumerator StoryParagraphAnimationCR()
    {
        storyParagraphTitleStrText.color = GameSlot.current_mss.speakerFontColor;
        storyParagraphStrText.color = GameSlot.current_mss.sentenceFontColor;
        int mode = 0;
        if (GameSlot.current_mss.speaker != "")
        {
            mode = 1;
        }

        for (float t = 0; t <= GameSlot.textFlowTime; t += Time.deltaTime + GameSlot.RealReadRushPower)
        {
            if (mode == 1)
            {
                storyParagraphTitleStrText.text = GameSlot.current_mss.speaker.Substring(0, Mathf.CeilToInt(t / (GameSlot.current_mss.msPerWord * 0.001f)));
            }
            else
            {
                storyParagraphStrText.text = GameSlot.current_mss.sentence.Substring(0, Mathf.CeilToInt(t / (GameSlot.current_mss.msPerWord * 0.001f)));
            }
            yield return 0;
        }
        for (float t = GameSlot.textFlowTime + GameSlot.bubbleShiftInTime; t <= GameSlot.waitSentenceCD; t += Time.deltaTime + GameSlot.RealReadRushPower)
        {
            yield return 0;
        }

        if (!GameSlot.justEndOfPart)
        {
            GameSlot.currentSentenceId += 1;
            GameSlot.StartNewSentence();
        }
        else if (GameSlot.current_mss.canAutoJump)
        {
            Debug.Log("jump happened");
            GameSlot.StoryJumpTo(GameSlot.current_mss.autoJumpTo.x, GameSlot.current_mss.autoJumpTo.y);
            GameSlot.StartNewSentence();
        }
        else if (GameSlot.current_mss.sentenceType == 3 && GameSlot.HasSwitch)
        {
            GameSlot.CheckSwitchCase();
        }
    }

    #region about speak bubble
    /// <summary>
    /// 气泡列表的状态：空、（入、字动、字动完后的静止区间）、静止区间后的静止瞬间、集体后移；全屏清空
    /// </summary>
    void UpdateSpeakBubble()
    {
        int n = newBubbleList.Count;
        if (n <= 0)
        {
            return;
        }
        float t = GameSlot.textFlowTime - GameSlot.currentSentenceTime;
        bubbleUnitArray[0].transform.localScale = new Vector3(1, 1, 1);
        bubbleUnitArray[0].sentenceText.text = bubbleUnitArray[0].fullStr.Substring(0,
            Mathf.CeilToInt(t / (bubbleUnitArray[0].speed * 0.001f)));
    }
    void UpdateFadeOutSpeakBubbles()
    {
        //气泡渐渐下移或消失
        float lastDelta = GameSlot.currentSentenceTime;

        if (bubbleArray[5] != null)
        {
            bubbleArray[5].transform.localScale = new Vector3(lastDelta * 0.7f, lastDelta * 0.7f, 1);
        }
        for (int i = 5; i >= 3; i--)
        {
            if (bubbleArray[i - 1] != null)
            {
                bubbleArray[i - 1].transform.localScale = new Vector3(0.7f, 0.7f, 1);
                bubbleArray[i - 1].transform.localPosition = bubbleUnitArray[i - 1].startPosition +
                    new Vector3(displaySideWidth * bubbleUnitArray[i - 1].displaySide,
                    -(i - 2) * bubbleHeight - (1 - lastDelta * 2) * bubbleHeight, 0);
            }
        }
        if (bubbleArray[1] != null)
        {
            bubbleArray[1].transform.localScale = new Vector3(0.7f + lastDelta * 0.3f, 0.7f + lastDelta * 0.3f, 1);
            bubbleArray[1].transform.localPosition = bubbleUnitArray[1].startPosition +
                new Vector3((1 - lastDelta) * displaySideWidth * bubbleUnitArray[1].displaySide,
                -(1 - lastDelta * 2) * bubbleHeight, 0);
        }
        if (bubbleArray[0] != null)
        {
            bubbleArray[0].transform.localScale = new Vector3((0.5f - lastDelta) * 2, (0.5f - lastDelta) * 2, 1);
        }
    }
    void CheckNewSpeakBubble()
    {
        if (GameSlot.current_mss.sentenceType == 5)
        {
            GameObject newChapter = Instantiate(chapterBackPrefab, chapterStageLayer.transform);
            newChapter.transform.localPosition = new Vector3(-1000, 0, 0);
            newChapter.GetComponent<SpeakBubbleUnit>().StartAnimation(GameSlot.current_mss);
        }
        else if (GameSlot.current_mss.sentenceType == 1)
        {
            newBubbleList.Add(Instantiate(bubblePrefab[GameSlot.current_mss.diaBoxType - 1], LayerSpeakCenter.transform));
            newBubbleList[newBubbleList.Count - 1].transform.localPosition =
                new Vector3(startBubblePosition[1].x * GameSlot.current_mss.side,
                startBubblePosition[1].y, startBubblePosition[1].z);
            bubbleUnitList.Add(newBubbleList[newBubbleList.Count - 1].GetComponent<SpeakBubbleUnit>());
            bubbleUnitList[bubbleUnitList.Count - 1].StartAnimation(GameSlot.current_mss);
            if (newBubbleList.Count > 6)
            {
                ClearBubble(1);
            }
            for (int i = bubbleArray.Length; i >= 2; i--)
            {
                bubbleArray[i - 1] = bubbleArray[i - 2];
                bubbleUnitArray[i - 1] = bubbleUnitArray[i - 2];
            }
            bubbleArray[0] = newBubbleList[newBubbleList.Count - 1];
            bubbleUnitArray[0] = bubbleUnitList[bubbleUnitList.Count - 1];
        }
    }
    void ClearFarBubble()
    {
        if (newBubbleList.Count > 5)
        {
            ClearBubble(1);
        }
        bubbleArray[5] = null;
        bubbleUnitArray[5] = null;
    }
    void CheckClear()
    {
        if (GameStatus.CurrentSceneState != SceneState.playing && GameStatus.CurrentSceneState != SceneState.playing_infopanel
            && GameStatus.CurrentSceneState != SceneState.playing_chapter && GameStatus.CurrentSceneState != SceneState.playing_historySentences
            && GameStatus.CurrentSceneState != SceneState.playing_loadlist && GameStatus.CurrentSceneState != SceneState.playing_pause
            && GameStatus.CurrentSceneState != SceneState.playing_savelist && GameStatus.CurrentSceneState != SceneState.playing_story
            && GameStatus.CurrentSceneState != SceneState.volume_setting && GameStatus.CurrentSceneState != SceneState.transing)
        {
            ClearAllBubble();
        }
        else
        {
            //大屏幕切换时的全屏清空。通过指令来调动（不一定所有大屏幕都清空）
        }
    }
    void ClearAllBubble()
    {
        for (int i = newBubbleList.Count; i >= 1; i--)
        {
            ClearBubble(i);
        }
        for (int i = 1; i <= 6; i++)
        {
            bubbleArray[i - 1] = null;
            bubbleUnitArray[i - 1] = null;
        }
    }
    void ClearBubble(int id)
    {
        Destroy(newBubbleList[id - 1]);
        newBubbleList[id - 1] = null;
        newBubbleList.RemoveAt(id - 1);
        bubbleUnitList[id - 1] = null;
        bubbleUnitList.RemoveAt(id - 1);
    }
    #endregion

    #region about mission
    void CheckMissionDisplay()
    {
        if (GameSlot.missionCheckedToShow)//有删除
        {
            StartShowCheckMark();
        }
        else if (GameSlot.missionFailedToShow)//有删除
        {
            Debug.Log("failed mission");
            StartShowFailMark();
        }
        else if (GameSlot.missionListChanged)//仅追加
        {
            StartMissionTextShowing(GameSlot.GetMissionListStr());
        }
    }
    void StartMissionTextShowing(string str)
    {
        GameSlot.missionListChanged = false;
        try
        {
            Color color1;
            ColorUtility.TryParseHtmlString("#C1A387", out color1);
            currentMissionText.color = color1;
        }
        catch
        {

        }
        StopCoroutine("MissionTextShowing");
        StartCoroutine("MissionTextShowing", str);
    }
    IEnumerator MissionTextShowing(string str)
    {
        GameSlot.hasCompleteMissionShowing = false;
        for (float t = 0; t <= str.Length * 0.15f; t += Time.deltaTime)
        {
            currentMissionText.text = str.Substring(0, Mathf.CeilToInt(t / 0.15f));
            yield return 0;
        }
        GameSlot.hasCompleteMissionShowing = true;
    }
    void StartShowCheckMark()
    {
        GameSlot.missionCheckedToShow = false;
        GameSlot.missionListChanged = false;
        StopCoroutine("ShowingCheckMark");
        StartCoroutine("ShowingCheckMark");
    }
    IEnumerator ShowingCheckMark()
    {
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            missionCheck.transform.localScale = new Vector3(t * 2, t * 2, 1);
            missionCheck.transform.localRotation = Quaternion.Euler(0, 0, 20 * Mathf.Cos(Time.time * 10));
            yield return 0;
        }
        for (float t = 0.5f; t <= 1f; t += Time.deltaTime)
        {
            missionCheck.transform.localScale = new Vector3(1, 1, 1);
            missionCheck.transform.localRotation = Quaternion.Euler(0, 0, 20 * Mathf.Cos(Time.time * 10));
            yield return 0;
        }
        StopCoroutine("MissionTextShowing");
        StartCoroutine("MissionTextShowing", GameSlot.GetMissionListStr());
        for (float t = 1; t <= 1.5f; t += Time.deltaTime)
        {
            missionCheck.transform.localScale = new Vector3((1.5f - t) * 2, (1.5f - t) * 2, 1);
            missionCheck.transform.localRotation = Quaternion.Euler(0, 0, 20 * Mathf.Cos(Time.time * 10));
            yield return 0;
        }
        missionCheck.transform.localScale = new Vector3(0, 0, 1);
    }
    void StartShowFailMark()
    {
        GameSlot.missionFailedToShow = false;
        GameSlot.missionListChanged = false;
        StopCoroutine("ShowingFailMark");
        StartCoroutine("ShowingFailMark");
    }
    IEnumerator ShowingFailMark()
    {
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            missionFail.transform.localScale = new Vector3(t * 2, t * 2, 1);
            missionFail.transform.localRotation = Quaternion.Euler(0, 0, 20 * Mathf.Cos(Time.time * 10));
            yield return 0;
        }
        for (float t = 0.5f; t <= 1f; t += Time.deltaTime)
        {
            missionFail.transform.localScale = new Vector3(1, 1, 1);
            missionFail.transform.localRotation = Quaternion.Euler(0, 0, 20 * Mathf.Cos(Time.time * 10));
            yield return 0;
        }
        StopCoroutine("MissionTextShowing");
        StartCoroutine("MissionTextShowing", GameSlot.GetMissionListStr());
        for (float t = 1; t <= 1.5f; t += Time.deltaTime)
        {
            missionFail.transform.localScale = new Vector3((1.5f - t) * 2, (1.5f - t) * 2, 1);
            missionFail.transform.localRotation = Quaternion.Euler(0, 0, 20 * Mathf.Cos(Time.time * 10));
            yield return 0;
        }
        missionFail.transform.localScale = new Vector3(0, 0, 1);
    }
    public void GiveUpStoryMission()
    {
        GameSlot.missionCompleteCheckCD = 0;
    }
    #endregion

    #endregion
    void CheckMissionComplete()
    {
        GameSlot.CheckMissionComplete();
    }

    #region 按钮切换
    public void SwitchCombineMode(int mode)
    {
        for (int i = 1; i <= 3; i++)
        {
            btn_combine_mode_image[i - 1].color = std_color_1;
            btn_combine_mode_str_text[i - 1].color = std_color_2;
        }
        if (mode == 1)
        {
            GameStatus.currentCombineMode = CombineBtnMode.mixture;
            btn_combine_mode_image[0].color = std_color_2;
            btn_combine_mode_str_text[0].color = std_color_1;

        }
        else if (mode == 2)
        {
            GameStatus.currentCombineMode = CombineBtnMode.combine_first;
            btn_combine_mode_image[1].color = std_color_2;
            btn_combine_mode_str_text[1].color = std_color_1;
        }
        else if (mode == 3)
        {
            GameStatus.currentCombineMode = CombineBtnMode.feed_first;
            btn_combine_mode_image[2].color = std_color_2;
            btn_combine_mode_str_text[2].color = std_color_1;
        }
    }
    public void SwitchShopMode(int mode)
    {
        for (int i = 1; i <= 2; i++)
        {
            shopBtnImage[i - 1].color = shop_color_1;
            shopBtnStrText[i - 1].color = shop_color_2;
            shopBtnIconImage[i - 1].color = shop_color_2;
        }
        if (mode == 1)
        {
            GameStatus.CurrentSceneState = SceneState.abyss_shop_buy;
            shopBtnImage[0].color = shop_color_2;
            shopBtnStrText[0].color = shop_color_1;
            shopBtnIconImage[0].color = shop_color_1;
            shopBoardPanel.transform.localScale = Vector3.one;
            shopRefreshBtn.transform.localScale = Vector3.one;
        }
        else if (mode == 2)
        {
            GameStatus.CurrentSceneState = SceneState.abyss_shop_sell;
            shopBtnImage[1].color = shop_color_2;
            shopBtnStrText[1].color = shop_color_1;
            shopBtnIconImage[1].color = shop_color_1;
            shopBoardPanel.transform.localScale = Vector3.zero;
            shopRefreshBtn.transform.localScale = Vector3.zero;
        }
        UpdateShopItemInfo();
    }
    #endregion
    #region cell click and drag
    /// <summary>
    /// 判断是格子的上方区域还是下方区域,1上2下
    /// </summary>
    /// <param name="cp">点击屏幕坐标</param>
    /// <returns>1上2下</returns>
    int GetUpOrDown(Vector3 cp)
    {
        int side = 0;
        if (cp.x > 30 && cp.x < 510 && cp.y > 150 && cp.y < 630)
        {
            int height = (Mathf.RoundToInt(cp.y) - 150) % 120;
            if (height >= 1 && height <= 60)
            {
                side = 2;
            }
            else if (height >= 61 && height <= 118)
            {
                side = 1;
            }
            return side;

        }
        else
        {
            return 0;
        }
    }
    int GetCellClickPosition(Vector3 cp)
    {
        if (cp.x > 30 && cp.x < 510 && cp.y > 150 && cp.y < 630)
        {
            int col = Mathf.CeilToInt((cp.x - 30) / 120f);
            int row = Mathf.CeilToInt((cp.y - 150) / 120f);
            row = 5 - row;
            return (row - 1) * 4 + col;

        }
        else
        {
            return 0;
        }
    }
    /// <summary>
    /// 面板点击拖动等处理
    /// </summary>
    void CheckBagCellClick()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing && !GameSlot.IsMsgBoxOn
            && !GameSlot.IsInSpeedSkip && !GameSlot.IsCurrentSentenceHidePanel)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GetCellClickPosition(Input.mousePosition) > 0)
                {
                    hasClickDown = true;
                    startPosition = Input.mousePosition;
                    startPositionId = GetCellClickPosition(Input.mousePosition);
                }
            }
            else if (Input.GetMouseButton(0))//不打开面板，就不用判断反馈显示了
            {
                GameSlot.currentPlayingDragTime += Time.deltaTime;
                if (GetCellClickPosition(Input.mousePosition) > 0)//最后的落脚点是否在格子区域内
                {
                    endPosition = Input.mousePosition;
                    endPositionId = GetCellClickPosition(Input.mousePosition);
                    int side = GetUpOrDown(Input.mousePosition);
                    int idCost = GameSlot.dataBag.GetItemId(startPositionId);
                    int idLeft = GameSlot.dataBag.GetItemId(endPositionId);

                    if (idCost > 0)//如果开始按下的位置在格子范围内且有东西
                    {
                        if (Vector3.Distance(startPosition, endPosition) > 30 && startPositionId != endPositionId)//如果发生了拖拽
                        {
                            if (idLeft > 0)//如果目标格子有东西
                            {
                                //首先判断是否是即时复制行为
                                //只有2个道具中有且仅有1个为复制水晶时才会发生
                                if (idCost == 8 && idLeft != 8)
                                {
                                    dragHintBack[0].transform.localPosition = new Vector3(-180 + (endPositionId - 1) % 4 * 120,
                                        180 + 150 - Mathf.CeilToInt(endPositionId / 4f) * 120, 0);
                                    dragHintText[0].text = SentenceBank.pack.sentences["copy"].ToString()
                                        + MapDataLib.mdItemLib.item[idLeft - 1].name;
                                    dragHintBack[0].transform.localScale = Vector3.one;
                                    dragHintBack[1].transform.localScale = Vector3.zero;
                                }
                                else if (GameSlot.IsOpenCombine)//如果已经开放了合成
                                {
                                    CombineRule combineRule = MapDataLib.mdItemLib.GetNewItemId(idCost, idLeft);
                                    int newId = combineRule.c;
                                    CombineHintType hintType = combineRule.hintType;
                                    bool isItemToCrystal = false;
                                    if (idLeft < 9 && idCost > 9)
                                    {
                                        isItemToCrystal = true;
                                    }
                                    if (newId != idLeft)
                                    {
                                        if (GameSlot.IsOpenAdvanceCombine)
                                        {
                                            if (isItemToCrystal)
                                            {
                                                dragHintBack[0].transform.localScale = Vector3.zero;
                                                dragHintBack[1].transform.localScale = Vector3.one;
                                                dragHintBack[1].transform.localPosition = new Vector3(-180 + (endPositionId - 1) % 4 * 120,
                                                    180 + 90 - Mathf.CeilToInt(endPositionId / 4f) * 120, 0);
                                                dragHintText[1].text = SentenceBank.pack.sentences["feed_exp"].ToString();
                                            }
                                            else if (GameStatus.currentCombineMode == CombineBtnMode.mixture)
                                            {
                                                if (side == 1 || side == 2)
                                                {
                                                    dragHintBack[0].transform.localPosition = new Vector3(-180 + (endPositionId - 1) % 4 * 120,
                                                        180 + 150 - Mathf.CeilToInt(endPositionId / 4f) * 120, 0);
                                                    dragHintBack[1].transform.localPosition = new Vector3(-180 + (endPositionId - 1) % 4 * 120,
                                                        180 + 90 - Mathf.CeilToInt(endPositionId / 4f) * 120, 0);
                                                    dragHintText[0].text = SentenceBank.pack.sentences[combineRule.hintType.ToString()].ToString()
                                                        + MapDataLib.mdItemLib.item[newId - 1].name;
                                                    dragHintText[1].text = SentenceBank.pack.sentences["feed_exp"].ToString();
                                                    if (side == 1)
                                                    {
                                                        dragHintBack[0].transform.localScale = Vector3.one * 1.2f;
                                                        dragHintBack[1].transform.localScale = Vector3.one * 0.8f;
                                                    }
                                                    else if (side == 2)
                                                    {
                                                        dragHintBack[0].transform.localScale = Vector3.one * 0.8f;
                                                        dragHintBack[1].transform.localScale = Vector3.one * 1.2f;
                                                    }
                                                }
                                                else
                                                {
                                                    dragHintBack[0].transform.localScale = Vector3.zero;
                                                    dragHintBack[1].transform.localScale = Vector3.zero;
                                                }
                                            }
                                            else if (GameStatus.currentCombineMode == CombineBtnMode.combine_first)
                                            {
                                                dragHintBack[0].transform.localPosition = new Vector3(-180 + (endPositionId - 1) % 4 * 120,
                                                    180 + 150 - Mathf.CeilToInt(endPositionId / 4f) * 120, 0);
                                                dragHintText[0].text = SentenceBank.pack.sentences[combineRule.hintType.ToString()].ToString()
                                                    + MapDataLib.mdItemLib.item[newId - 1].name;
                                                dragHintBack[0].transform.localScale = Vector3.one;
                                                dragHintBack[1].transform.localScale = Vector3.zero;
                                            }
                                            else if (GameStatus.currentCombineMode == CombineBtnMode.feed_first)
                                            {
                                                dragHintBack[0].transform.localScale = Vector3.zero;
                                                dragHintBack[1].transform.localScale = Vector3.one;
                                                dragHintBack[1].transform.localPosition = new Vector3(-180 + (endPositionId - 1) % 4 * 120,
                                                    180 + 90 - Mathf.CeilToInt(endPositionId / 4f) * 120, 0);
                                                dragHintText[1].text = SentenceBank.pack.sentences["feed_exp"].ToString();
                                            }
                                        }
                                        else
                                        {
                                            if (hintType == CombineHintType.combine)
                                            {
                                                dragHintBack[0].transform.localPosition = new Vector3(-180 + (endPositionId - 1) % 4 * 120,
                                                    180 + 150 - Mathf.CeilToInt(endPositionId / 4f) * 120, 0);
                                                dragHintText[0].text = SentenceBank.pack.sentences[combineRule.hintType.ToString()].ToString()
                                                    + MapDataLib.mdItemLib.item[newId - 1].name;
                                                dragHintBack[0].transform.localScale = Vector3.one;
                                                dragHintBack[1].transform.localScale = Vector3.zero;
                                            }
                                            else
                                            {
                                                dragHintBack[0].transform.localScale = Vector3.zero;
                                                dragHintBack[1].transform.localScale = Vector3.one;
                                                dragHintBack[1].transform.localPosition = new Vector3(-180 + (endPositionId - 1) % 4 * 120,
                                                    180 + 90 - Mathf.CeilToInt(endPositionId / 4f) * 120, 0);
                                                dragHintText[1].text = SentenceBank.pack.sentences["feed_exp"].ToString();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        dragHintBack[0].transform.localScale = Vector3.zero;
                                        dragHintBack[1].transform.localScale = Vector3.one;
                                        dragHintBack[1].transform.localPosition = new Vector3(-180 + (endPositionId - 1) % 4 * 120,
                                            180 + 90 - Mathf.CeilToInt(endPositionId / 4f) * 120, 0);
                                        dragHintText[1].text = SentenceBank.pack.sentences["feed_exp"].ToString();
                                    }
                                }
                                else
                                {
                                    dragHintBack[0].transform.localScale = Vector3.one;
                                    dragHintBack[1].transform.localScale = Vector3.zero;
                                    dragHintBack[0].transform.localPosition = new Vector3(-180 + (endPositionId - 1) % 4 * 120,
                                        180 + 150 - Mathf.CeilToInt(endPositionId / 4f) * 120, 0);
                                    dragHintText[0].text = SentenceBank.pack.sentences["combine_not_open"].ToString();
                                }
                            }
                            else
                            {
                                dragHintBack[0].transform.localScale = Vector3.zero;
                                dragHintBack[1].transform.localScale = Vector3.one;
                                dragHintBack[1].transform.localPosition = new Vector3(-180 + (endPositionId - 1) % 4 * 120,
                                    180 + 90 - Mathf.CeilToInt(endPositionId / 4f) * 120, 0);
                                dragHintText[1].text = SentenceBank.pack.sentences["move"].ToString();
                            }
                        }
                        else//如果只是按住
                        {
                            dragHintBack[0].transform.localScale = Vector3.one;
                            dragHintBack[1].transform.localScale = Vector3.zero;
                            dragHintBack[0].transform.localPosition = new Vector3(-180 + (startPositionId - 1) % 4 * 120,
                                180 + 150 - Mathf.CeilToInt(startPositionId / 4f) * 120, 0);
                            dragHintText[0].text = SentenceBank.pack.sentences["choosing"].ToString() + MapDataLib.mdItemLib.item[idCost - 1].name;
                        }
                    }
                    else
                    {
                        dragHintBack[0].transform.localScale = Vector3.zero;
                        dragHintBack[1].transform.localScale = Vector3.zero;
                    }
                }
                else
                {
                    dragHintBack[0].transform.localScale = Vector3.zero;
                    dragHintBack[1].transform.localScale = Vector3.zero;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                GameSlot.currentPlayingDragTime = 0f;
                dragHintBack[0].transform.localScale = Vector3.zero;
                dragHintBack[1].transform.localScale = Vector3.zero;
                if (GetCellClickPosition(Input.mousePosition) > 0 && hasClickDown)
                {
                    hasClickDown = false;
                    int side = GetUpOrDown(Input.mousePosition);
                    endPosition = Input.mousePosition;
                    if (Vector3.Distance(startPosition, endPosition) <= 30)
                    {
                        startPositionId = GetCellClickPosition(Input.mousePosition);

                        if (GameSlot.dataBag.GetItemOrderId(startPositionId) == 0)
                        {
                            #region create crystal
                            if (!GameSlot.IsOpenCreateCrystal)
                            {
                                //创造水晶功能被关闭
                                GameStatus.itemPanelEffectList.Add(new ItemPanelEffect(ParticleEffectsType.dissolve, 0.2f,
                                    new Vector3(Random.Range(-210, 210), Random.Range(-300, 120), 0)));
                                GameSound.PlaySystemSoundByMode(3);
                                RushReadStory();//顺便加速
                            }
                            else if (GameSlot.dataBag.BagEnergy >= MapDataLib.mdItemLib.GetExpNeedByLv(1))
                            {
                                GameSlot.dataBag.currentChoosedPositionId = startPositionId;
                                CreateCrystal();
                            }
                            else
                            {
                                GameStatus.superTextBulletList.Add(new SuperTextBullet(SentenceBank.pack.sentences["error_notenouphenergy"].ToString()
                                    , 39, new Color(0.7f, 0.2f, 0.2f), forgeErrorPosition));
                            }
                            #endregion
                        }
                        else
                        {
                            #region open panel
                            if (GameSlot.IsOpenPanel)
                            {
                                GameSlot.dataBag.currentChoosedPositionId = startPositionId;
                                OpenInfoPanel();
                            }
                            else
                            {
                                //打开面板功能被关闭
                                GameStatus.itemPanelEffectList.Add(new ItemPanelEffect(ParticleEffectsType.dissolve, 0.2f,
                                    new Vector3(Random.Range(-210, 210), Random.Range(-300, 120), 0)));
                                GameSound.PlaySystemSoundByMode(3);
                                RushReadStory();//顺便加速
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        endPositionId = GetCellClickPosition(Input.mousePosition);
                        if (startPositionId != endPositionId)
                        {
                            if (GameSlot.dataBag.GetItemOrderId(startPositionId) == 0)
                            {
                                //empty start, ignore
                            }
                            else if (GameSlot.dataBag.GetItemOrderId(endPositionId) == 0)
                            {
                                //empty end, move
                                int startOrderId = GameSlot.dataBag.GetItemOrderId(startPositionId);
                                int startItemId = GameSlot.dataBag.item[startOrderId - 1].id;
                                int startItemLv = GameSlot.dataBag.item[startOrderId - 1].lv;
                                int startItemProgress = GameSlot.dataBag.item[startOrderId - 1].exp;
                                float moveItemTempCD = GameSlot.dataBag.item[startOrderId - 1].generateCD;
                                RemoveItem(startPositionId);
                                int endOrderId = GameSlot.dataBag.GetInsertOrderId(endPositionId);
                                GameSlot.dataBag.AddItemByOrder(endOrderId,
                                    new DataItem(startItemId, startItemLv, startItemProgress, endPositionId, moveItemTempCD));
                            }
                            else
                            {
                                //首先判断是否是即时复制行为
                                //只有2个道具中有且仅有1个为复制水晶时才会发生
                                int idCost = GameSlot.dataBag.GetItemId(startPositionId);
                                int idLeft = GameSlot.dataBag.GetItemId(endPositionId);
                                if (idCost == 8 && idLeft != 8)
                                {
                                    int oId = GameSlot.dataBag.GetItemOrderId(startPositionId);
                                    GameSlot.dataBag.item[oId - 1].id = idLeft;
                                    GameSlot.dataBag.boardHasChanged[startPositionId - 1] = true;
                                }
                                //combine
                                else if (GameSlot.IsOpenCombine)
                                {
                                    if (!GameSlot.IsOpenAdvanceCombine)
                                    {
                                        side = 1;
                                    }
                                    else
                                    {
                                        if (GameStatus.currentCombineMode == CombineBtnMode.mixture)
                                        {

                                        }
                                        else if (GameStatus.currentCombineMode == CombineBtnMode.combine_first)
                                        {
                                            side = 1;
                                        }
                                        else if (GameStatus.currentCombineMode == CombineBtnMode.feed_first)
                                        {
                                            side = 2;
                                        }
                                    }
                                    CombineRule combineRule = MapDataLib.mdItemLib.GetNewItemId(idCost, idLeft);
                                    CombineHintType hinType = combineRule.hintType;
                                    if (hinType == CombineHintType.combine || hinType == CombineHintType.none)
                                    {
                                        CombineTwoItem(startPositionId, endPositionId, side);
                                    }
                                    else
                                    {
                                        if (GameSlot.IsOpenAdvanceCombine)
                                        {
                                            CombineTwoItem(startPositionId, endPositionId, side);
                                        }
                                        else
                                        {
                                            CombineTwoItem(startPositionId, endPositionId, 2);
                                        }
                                    }
                                }
                                else
                                {
                                    //合成功能被关闭
                                    GameStatus.itemPanelEffectList.Add(new ItemPanelEffect(ParticleEffectsType.dissolve, 0.2f,
                                        new Vector3(Random.Range(-210, 210), Random.Range(-300, 120), 0)));
                                    GameSound.PlaySystemSoundByMode(3);
                                    GameStatus.superTextBulletList.Add(new SuperTextBullet(
                                        SentenceBank.pack.sentences["combine_not_open"].ToString()
                                        , 39, new Color(0.588f, 0.478f, 0.4f), new Vector3(0, -90, 0)));
                                }
                            }
                        }
                    }
                }
                else
                {
                    //如果丢弃功能被关闭，一样不行
                    if (hasClickDown && GameSlot.IsOpenThrow)
                    {
                        endPosition = Input.mousePosition;
                        //丢出东西
                        if (GameStatus.CurrentPlayMode == PlayMode.story)
                        {
                            //如果是珍贵的东西，则弹出警告
                            GameSlot.ToConfirmThrowItemOrderId = GameSlot.dataBag.GetItemOrderId(startPositionId);
                            int startItemId = GameSlot.dataBag.item[GameSlot.ToConfirmThrowItemOrderId - 1].id;
                            string itemName = MapDataLib.mdItemLib.item[startItemId - 1].name;
                            if (GameSlot.dataBag.item[GameSlot.ToConfirmThrowItemOrderId - 1].IsLittleItem)
                            {
                                ConfirmThrowItem();
                            }
                            else
                            {
                                GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["confirm_throw_title"].ToString(),
                                    "【" + itemName + "】" + SentenceBank.pack.sentences["confirm_throw_sentence"].ToString(), 17));
                            }
                        }
                        else
                        {
                            int oId = GameSlot.dataBag.GetItemOrderId(startPositionId);
                            if (oId < 0) { return; }
                            int startItemId = GameSlot.dataBag.item[oId - 1].id;
                            int lv = GameSlot.dataBag.item[oId - 1].lv;
                            string itemName = GameSlot.dataBag.item[oId - 1].Name;
                            if (endPosition.y < 480)
                            {
                                ;
                            }
                            //投掷物判定逻辑应该是这样的：先石头后装备再食物
                            else if (endPosition.x <= 270)
                            {
                                //向我方投掷
                                if (MapDataLib.mdItemLib.item[startItemId - 1].id == 80 || MapDataLib.mdItemLib.item[startItemId - 1].id == 90)
                                {
                                    if (GameSlot.dataBag.hero.GetMinLevelEquipId <= 0)
                                    {
                                        if (GameSlot.dataBag.hero.MaxEquipLv > 0)
                                        {
                                            GameStatus.superTextBulletList.Add(new SuperTextBullet(SentenceBank.pack.sentences["abyss_fix_equip_maxout"].ToString()
                                                , 39, new Color(0.7f, 0.2f, 0.2f), new Vector3(-50, 0, 0)));
                                        }
                                        else
                                        {
                                            GameStatus.superTextBulletList.Add(new SuperTextBullet(SentenceBank.pack.sentences["abyss_fix_equip_none"].ToString()
                                                , 39, new Color(0.7f, 0.2f, 0.2f), new Vector3(-50, 0, 0)));
                                        }
                                        return;
                                    }

                                }
                                //如果是石头，则投掷伤害
                                if (MapDataLib.mdItemLib.item[startItemId - 1].IsStoneItem)
                                {
                                    DataItem newItem = new DataItem(GameSlot.dataBag.item[oId - 1]);
                                    GameSlot.dataBag.RemoveItemByOrder(oId);
                                    GameSlot.dataBag.hero.RemoveHP(MapDataLib.mdItemLib.GetThrowAtkValueByIdAndLv(startItemId, lv));
                                    GameStatus.superTextBulletList.Add(new SuperTextBullet(SentenceBank.pack.sentences["abyss_throw_attack"].ToString()
                                        , 39, new Color(0.7f, 0.2f, 0.2f), new Vector3(-50, 0, 0)));
                                    GameSlot.dataBag.hero.GetPoison(newItem);
                                    //itemIconUnitList[startPositionId - 1].UpdateItemId();
                                    UpdateAbyssBasicValue();
                                }
                                //如果是装备，则交换
                                else if (MapDataLib.mdItemLib.item[startItemId - 1].IsEquipment)
                                {
                                    GameSlot.dataBag.ExchangeEquipment(-1, MapDataLib.mdItemLib.item[startItemId - 1].EquipTypeInt, oId);
                                    UpdateAbyssBasicValue();
                                    //itemIconUnitList[startPositionId - 1].UpdateItemId();
                                }
                                //如果是补给，则立刻恢复血量或解毒
                                else if (MapDataLib.mdItemLib.item[startItemId - 1].IsInstantItem && !MapDataLib.mdItemLib.item[startItemId - 1].IsArrowBag)
                                {
                                    DataItem newItem = new DataItem(GameSlot.dataBag.item[oId - 1]);
                                    GameSlot.dataBag.RemoveItemByOrder(oId);
                                    GameSlot.dataBag.hero.RecoverFromFood(newItem, ThrowItemFromType.bag);
                                    //itemIconUnitList[startPositionId - 1].UpdateItemId();

                                    UpdateAbyssBasicValue();
                                }
                                //如果是箭袋，则飞箭
                                else if (MapDataLib.mdItemLib.item[startItemId - 1].IsArrowBag)
                                {
                                    DataItem newItem = new DataItem(GameSlot.dataBag.item[oId - 1]);
                                    GameSlot.dataBag.item[oId - 1].UseArrow();
                                    GameSlot.dataBag.boardHasChanged[startPositionId - 1] = true;
                                    if (GameSlot.dataBag.item[oId - 1].lv == 0)
                                    {
                                        GameSlot.dataBag.RemoveItemByOrder(oId);
                                    }
                                    GameSlot.dataBag.hero.RemoveHP(10 + newItem.GetValueByAttribute(AttributeType.arrow_atk)[0]);
                                    UpdateCurrentItemValue(startPositionId);
                                    GameSlot.dataBag.hero.RecoverFromFood(newItem, ThrowItemFromType.bag);
                                    UpdateAbyssBasicValue();
                                }
                            }
                            else if (endPosition.x > 270 && GameSlot.dataBag.IsMonsterAlive)
                            {
                                int mId = GameSlot.dataBag.currentMonsterId;
                                int monsterId = GameSlot.dataBag.CurrentAbyssStage.monsterList[mId - 1];
                                string name = MapDataLib.abyss.abyssHeroList[monsterId - 1].name;
                                //向敌方投掷
                                //如果是石头，则投掷伤害
                                if (MapDataLib.mdItemLib.item[startItemId - 1].IsStoneItem)
                                {
                                    DataItem newItem = new DataItem(GameSlot.dataBag.item[oId - 1]);
                                    GameSlot.dataBag.RemoveItemByOrder(oId);
                                    GameSlot.dataBag.monster.RemoveHP(MapDataLib.mdItemLib.GetThrowAtkValueByIdAndLv(startItemId, lv));
                                    GameStatus.superTextBulletList.Add(new SuperTextBullet(SentenceBank.pack.sentences["abyss_throw_attack"].ToString()
                                        , 39, new Color(0.7f, 0.2f, 0.2f), new Vector3(50, 0, 0)));
                                    GameSlot.dataBag.monster.GetPoison(newItem);
                                    
                                    UpdateAbyssBasicValue();
                                }
                                //如果是装备，则被对方装备捡漏。如果是武器，带来投掷伤害
                                else if (MapDataLib.mdItemLib.item[startItemId - 1].IsEquipment)
                                {
                                    GameSlot.dataBag.ExchangeEquipment(1, MapDataLib.mdItemLib.item[startItemId - 1].EquipTypeInt, oId);
                                    UpdateAbyssBasicValue();
                                }
                                //如果是补给，则被对方食物捡漏
                                else if (MapDataLib.mdItemLib.item[startItemId - 1].IsInstantItem && !MapDataLib.mdItemLib.item[startItemId - 1].IsArrowBag)
                                {
                                    DataItem newItem = new DataItem(GameSlot.dataBag.item[oId - 1]);
                                    GameSlot.dataBag.RemoveItemByOrder(oId);
                                    if (MapDataLib.mdItemLib.item[startItemId - 1].IsFoodOrPotion)
                                    {
                                        GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["abyss_monster_pick_up_title"].ToString(),
                                        SentenceBank.pack.sentences["abyss_monster_pick_up_food"].ToString().Replace("n", name).Replace("f", itemName), 0));
                                    }
                                    GameSlot.dataBag.monster.RecoverFromFood(newItem, ThrowItemFromType.bag);

                                    UpdateAbyssBasicValue();
                                }
                                //如果是箭袋，则飞箭
                                else if (MapDataLib.mdItemLib.item[startItemId - 1].IsArrowBag)
                                {
                                    Debug.Log("throw enemy arrowbag");
                                    DataItem newItem = new DataItem(GameSlot.dataBag.item[oId - 1]);
                                    GameSlot.dataBag.item[oId - 1].UseArrow();
                                    GameSlot.dataBag.boardHasChanged[startPositionId - 1] = true;
                                    if (GameSlot.dataBag.item[oId - 1].lv == 0)
                                    {
                                        GameSlot.dataBag.RemoveItemByOrder(oId);
                                    }
                                    GameSlot.dataBag.monster.RemoveHP(10 + newItem.GetValueByAttribute(AttributeType.arrow_atk)[0]);
                                    GameSlot.dataBag.monster.RecoverFromFood(newItem, ThrowItemFromType.bag);
                                    UpdateCurrentItemValue(startPositionId);
                                    UpdateAbyssBasicValue();
                                }
                            }

                        }
                    }
                    else
                    {
                        if (hasClickDown && GameSlot.dataBag.GetItemOrderId(startPositionId) > 0)
                        {
                            GameStatus.superTextBulletList.Add(new SuperTextBullet(
                                SentenceBank.pack.sentences["throw_not_open"].ToString()
                                , 39, new Color(0.588f, 0.478f, 0.4f), new Vector3(0, -90, 0)));
                        }
                    }
                }
                hasClickDown = false;
            }
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                string str = "CurrentSceneState = " +GameStatus.CurrentSceneState + ",IsMsgBoxOn = " + GameSlot.IsMsgBoxOn
                    + ",IsInSpeedSkip = " + GameSlot.IsInSpeedSkip + ",IsCurrentSentenceHidePanel =" + GameSlot.IsCurrentSentenceHidePanel;
                Debug.Log(str);
            }
        }
    }
    /// <summary>
    /// 商店界面点击处理
    /// </summary>
    void CheckShopCellClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GetCellClickPosition(Input.mousePosition) > 0)
            {
                hasClickDown = true;
                startPosition = Input.mousePosition;
                startPositionId = GetCellClickPosition(Input.mousePosition);
            }
        }
        else if (Input.GetMouseButton(0))
        {

        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (GetCellClickPosition(Input.mousePosition) > 0 && hasClickDown)
            {
                hasClickDown = false;
                int side = GetUpOrDown(Input.mousePosition);
                endPosition = Input.mousePosition;
                if (Vector3.Distance(startPosition, endPosition) <= 30)
                {
                    startPositionId = GetCellClickPosition(Input.mousePosition);
                    
                    if (GameStatus.CurrentSceneState == SceneState.abyss_shop_buy)
                    {
                        if (GameSlot.shop.GetItemOrderId(startPositionId) == 0)
                        {
                            ClearShopItemInfo();
                        }
                        else
                        {
                            GameSlot.shop.currentChoosedPositionId = startPositionId;
                            string str = "";
                            if (GameSlot.shop.CurrentItem.PriceCoef < 0.1f)
                            {
                                str += SentenceBank.pack.sentences["abyss_shoper"].ToString() + ":\"" + SentenceBank.pack.sentences["abyss_trash_item_buy"].ToString() + "\"";
                            }
                            else if (GameSlot.shop.CurrentItem.PriceCoef < 0.99f)
                            {
                                str += SentenceBank.pack.sentences["abyss_shoper"].ToString() + ":\"" + SentenceBank.pack.sentences["abyss_bad_item_buy"].ToString() + "\"";
                            }
                            else if (GameSlot.shop.CurrentItem.PriceCoef > 1.01f)
                            {
                                str += SentenceBank.pack.sentences["abyss_shoper"].ToString() + ":\"" + SentenceBank.pack.sentences["abyss_good_item_buy"].ToString() + "\"";
                            }
                            GameStatus.superTextBulletList.Add(new SuperTextBullet(str, 32, new Color(0.7f, 0.2f, 0.2f), new Vector3(0, -100, 0)));
                        }
                    }
                    else
                    {
                        if (GameSlot.dataBag.GetItemOrderId(startPositionId) == 0)
                        {
                            ClearShopItemInfo();
                        }
                        else
                        {
                            GameSlot.dataBag.currentChoosedPositionId = startPositionId;
                            string str = "";
                            if (GameSlot.dataBag.CurrentItem.id <= 9)
                            {
                                str += SentenceBank.pack.sentences["abyss_shoper"].ToString() + ":\"" + SentenceBank.pack.sentences["abyss_refuse_buy_crystal"].ToString() + "\"";
                            }
                            else if (GameSlot.dataBag.CurrentItem.PriceCoef < 0.1f)
                            {
                                str += SentenceBank.pack.sentences["abyss_shoper"].ToString() + ":\"" + SentenceBank.pack.sentences["abyss_trash_item_sell"].ToString() + "\"";
                            }
                            else if (GameSlot.dataBag.CurrentItem.PriceCoef < 0.99f)
                            {
                                str += SentenceBank.pack.sentences["abyss_shoper"].ToString() + ":\"" + SentenceBank.pack.sentences["abyss_bad_item_sell"].ToString() + "\"";
                            }
                            else if (GameSlot.dataBag.CurrentItem.PriceCoef > 1.01f)
                            {
                                str += SentenceBank.pack.sentences["abyss_shoper"].ToString() + ":\"" + SentenceBank.pack.sentences["abyss_good_item_sell"].ToString() + "\"";
                            }
                            GameStatus.superTextBulletList.Add(new SuperTextBullet(str, 32, new Color(0.7f, 0.2f, 0.2f), new Vector3(0, -100, 0)));
                        }
                    }
                    UpdateShopItemInfo();
                }
            }
            hasClickDown = false;
        }
    }
    void ConfirmThrowItem()
    {
        int oId = GameSlot.ToConfirmThrowItemOrderId;
        int startItemId = GameSlot.dataBag.item[oId - 1].id;
        int startItemLv = GameSlot.dataBag.item[oId - 1].lv;

        GameSlot.dataBag.RemoveItemByOrder(oId);
        GameSlot.manualThrowOutItem.Add(new Vector2Int(startItemId, startItemLv));
        
    }
    private void CombineTwoItem(int costPositionId, int leftPositionId, int side = 0)
    {
        int startOrderId = GameSlot.dataBag.GetItemOrderId(costPositionId);
        int idCost = GameSlot.dataBag.GetItemId(costPositionId);
        int idLeft = GameSlot.dataBag.GetItemId(leftPositionId);
        int readyProgress = 0;

        int endOrderId = GameSlot.dataBag.GetItemOrderId(leftPositionId);
        int lv = GameSlot.dataBag.item[endOrderId - 1].lv;
        int progress = GameSlot.dataBag.item[endOrderId - 1].exp;

        readyProgress = GameSlot.dataBag.ValueOfCombine(startOrderId);
        int removePositionId1 = costPositionId;
        GameStatus.itemPanelEffectList.Add(new ItemPanelEffect(ParticleEffectsType.dissolve, 2, Vector3.zero));
        GameStatus.itemPanelEffectList.Add(new ItemPanelEffect(ParticleEffectsType.forge, 1, Vector3.zero));

        #region check item change
        CombineRule combineRule = MapDataLib.mdItemLib.GetNewItemId(idCost, idLeft);
        int newId = combineRule.c;
        #endregion
        ItemNewData newValue = MapDataLib.mdItemLib.GetNewItemData(lv, progress, readyProgress, GameSlot.dataBag.bagLevel * 10);

        GameSlot.dataBag.item[endOrderId - 1].exp = newValue.progress;
        
        if (newValue.level > lv)
        {
            GameStatus.superTextBulletList.Add(new SuperTextBullet(SentenceBank.pack.sentences["lv"] + "+" + (newValue.level - lv)
                , 39, new Color(0.7f, 0.2f, 0.2f), bagCellBoardCanvas.cellCenterPosition[endPositionId - 1]));
            GameSlot.dataBag.item[endOrderId - 1].lv = newValue.level;

            BagAddExp(endPositionId, Mathf.RoundToInt(newValue.getExp * (100 + GameSlot.dataBag.GetTotalExpBonus()) / 100f), false);
        }
        #region overflow energy
        if (newValue.overflow > 0)
        {
            BagAddEnergy(newValue.overflow);
        }
        #endregion

        bool IdChanged = false;
        if (newId != idLeft)
        {
            if (idCost > 9 && idLeft < 9)
            {
                IdChanged = false;
            }
            else if (side == 1)
            {
                IdChanged = true;
            }
            else
            {
                IdChanged = false;
            }
        }
        else
        {
            IdChanged = false;
        }
        if (IdChanged)
        {
            GameSlot.dataBag.item[endOrderId - 1].id = newId;
            GameSlot.dataBag.boardHasChanged[leftPositionId - 1] = true;
            RemoveItem(removePositionId1);
        }
        else
        {
            RemoveItem(removePositionId1);
            bagCellBoardCanvas.itemIconUnitList[endPositionId - 1].ChangeValue();
        }
        UpdateCurrentBagValue();
        #region 根据合成类型不同播放不同音效
        if (IdChanged)
        {
            if (newId <= 9)
            {
                GameSound.PlayCombineCrystalSound();
            }
            else
            {
                GameSound.PlayCombineItemSound();
            }
        }
        else
        {
            GameSound.PlayFeedExpSound();
        }
        #endregion
    }
    #region 锻造挂机相关
    public void AddForgeTargetLv(int delta)
    {
        GameSlot.targetForgeLv += delta;
        CheckTargetLvLegal();
    }
    public void AddDissolveTargetLv(int delta)
    {
        GameSlot.targetDissolveLv += delta;
        CheckTargetLvLegal();
    }
    void CheckTargetLvLegal()
    {
        int maxLv = GameSlot.dataBag.CurrentItem.CurrentMaxLevel;
        if (GameSlot.targetForgeLv < GameSlot.dataBag.CurrentItem.lv)
        {
            GameSlot.targetForgeLv = GameSlot.dataBag.CurrentItem.lv;
        }
        if (GameSlot.targetForgeLv > maxLv)
        {
            GameSlot.targetForgeLv = maxLv;
        }
        if (GameSlot.targetDissolveLv < 0)
        {
            GameSlot.targetDissolveLv = 0;
        }
        if (GameSlot.targetDissolveLv > GameSlot.dataBag.CurrentItem.lv)
        {
            GameSlot.targetDissolveLv = GameSlot.dataBag.CurrentItem.lv;
        }
        UpdateTargetLv();
    }
    public void TargetLvForgeValueChanged()
    {
        try
        {
            GameSlot.targetForgeLv = int.Parse(autoForgeTargetLvStrText.text);
            Debug.Log(GameSlot.targetForgeLv);
            CheckTargetLvLegal();
        }
        catch
        {
            autoForgeTargetLvStrText.text = GameSlot.targetForgeLv.ToString();
        }
    }
    public void TargetLvDissolveValueChanged()
    {
        try
        {
            GameSlot.targetDissolveLv = int.Parse(autoDissolveTargetLvStrText.text);
            Debug.Log(GameSlot.targetDissolveLv);
            CheckTargetLvLegal();
        }
        catch
        {
            autoDissolveTargetLvStrText.text = GameSlot.targetDissolveLv.ToString();
        }
    }
    void UpdateTargetLv()
    {
        autoForgeTargetLvStrText.text = GameSlot.targetForgeLv.ToString();
        autoDissolveTargetLvStrText.text = GameSlot.targetDissolveLv.ToString();
    }
    #endregion
    public void TryForgeToEnd()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing_infopanel)
        {
            StopCoroutine("OpenPanelAutoForgeCR");
            StopCoroutine("OpenPanelAutoDissolveCR");

            int startLv = GameSlot.dataBag.CurrentItem.lv;
            int endLv = startLv;
            float clickTime = 0;
            int result = TryForge(true);
            while (result == 0 && GameStatus.CurrentSceneState == SceneState.playing_infopanel)
            {
                #region 时间扣除
                if (GameSlot.toShowMissionList.Count > 0 && GameSlot.IsLimitTimeStaticMission)
                {
                    if (GameSlot.missionCompleteCheckCD < GameSlot.MaxMissionMS)
                    {
                        if (GameSlot.IsOpenPanelRealTime)
                        {
                            clickTime = 0.16f;
                        }
                        else
                        {
                            clickTime = 0.016f;
                        }
                        GameSlot.missionCompleteCheckCD -= clickTime;
                        if (GameSlot.missionCompleteCheckCD < 0)
                        {
                            return;
                        }
                    }
                }
                #endregion
                result = TryForge(true);//目标等级在里面判断，因为要输出具体反馈信息
            }
            GameSound.PlaySystemSound(9);
            UpdateCurrentItemValue();
            UpdateCurrentBagValue();
        }
    }
    public void TryDissolveToEnd()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing_infopanel)
        {
            StopCoroutine("OpenPanelAutoForgeCR");
            StopCoroutine("OpenPanelAutoDissolveCR");

            GameSlot.dissolveUntilTargetLv = false;
            TryDissolveToEndStep2();
        }
    }
    void TryDissolveToEndStep2()
    {
        int startLv = GameSlot.dataBag.CurrentItem.lv;
        int endLv = startLv;

        int forgeAtk = (1 + GameSlot.dataBag.GetTotalForgeAtkPlus()) * 5;
        int expDelta = 0;
        expDelta = GameSlot.dataBag.CurrentItem.exp;

        if (GameSlot.dataBag.CurrentItem.lv <= GameSlot.targetDissolveLv)
        {
            return;
        }

        int result = TryDissolve(true);
        float clickTime = 0;
        while (result == 0)
        {
            #region 时间扣除
            if (GameSlot.toShowMissionList.Count > 0 && GameSlot.IsLimitTimeStaticMission)
            {
                if (GameSlot.missionCompleteCheckCD < GameSlot.MaxMissionMS)
                {
                    if (GameSlot.IsOpenPanelRealTime)
                    {
                        clickTime = 0.16f;
                    }
                    else
                    {
                        clickTime = 0.016f;
                    }
                    GameSlot.missionCompleteCheckCD -= clickTime;
                    if (GameSlot.missionCompleteCheckCD < 0)
                    {

                        return;
                    }
                }
            }
            #endregion
            if (!GameSlot.dissolveUntilTargetLv && GameSlot.dataBag.BagEnergyIsFull)
            {
                break;
            }
            if (GameSlot.dataBag.CurrentItem.lv <= GameSlot.targetDissolveLv)
            {
                break;
            }
            result = TryDissolve(true);
        }
        if (GameSlot.dissolveUntilTargetLv)
        {
            Debug.Log("end of dissolve");
            GameSlot.dissolveUntilTargetLv = false;
        }
        else
        {
            if (GameStatus.CurrentSceneState == SceneState.playing_infopanel)
            {
                if (GameSlot.dataBag.CurrentChoosedOrderId == 0)
                {

                }
                else if (GameSlot.dataBag.CurrentItem.lv <= GameSlot.targetDissolveLv)
                {
                    GameStatus.superTextBulletList.Add(new SuperTextBullet(SentenceBank.pack.sentences["has_reached_target_lv"].ToString()
                        , 39, new Color(0.7f, 0.2f, 0.2f), forgeErrorPosition));
                }
                else
                {
                    GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["bag_energy_has_full"].ToString(),
                       SentenceBank.pack.sentences["dissolve_until_target_lv"].ToString(), 4,
                       SentenceBank.pack.sentences["stop_dissolve"].ToString(), 0));
                }
            }
        }
        GameSound.PlaySystemSound(10);
        UpdateCurrentItemValue();
        UpdateCurrentBagValue();
    }
    public void OpenPanelAutoForge()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing_infopanel)
        {
            StopCoroutine("OpenPanelAutoForgeCR");
            StopCoroutine("OpenPanelAutoDissolveCR");
            StartCoroutine("OpenPanelAutoForgeCR");
            GameSlot.itemInfoPanelState = ItemInfoPanelState.auto_forge;
        }
    }
    IEnumerator OpenPanelAutoForgeCR()
    {
        for (float t1 = 0; t1 <= 0.5f; t1 += Time.deltaTime)
        {
            btnAutoForgePanelPic.transform.localPosition = Vector3.Lerp(btnAutoForgePanelPic.transform.localPosition,
                new Vector3(20, 0, 0), info_panel_trans_speed1 * Time.deltaTime);
            btnAutoForgeToEndPanelPic.transform.localPosition = Vector3.Lerp(btnAutoForgeToEndPanelPic.transform.localPosition,
                new Vector3(-100, 0, 0), info_panel_trans_speed1 * Time.deltaTime);
            btnAutoDissolvePanelPic.transform.localPosition = Vector3.Lerp(btnAutoDissolvePanelPic.transform.localPosition,
                new Vector3(0, 0, 0), info_panel_trans_speed1 * Time.deltaTime);
            btnAutoDissolveToEndPanelPic.transform.localPosition = Vector3.Lerp(btnAutoDissolveToEndPanelPic.transform.localPosition,
                new Vector3(0, 0, 0), info_panel_trans_speed1 * Time.deltaTime);

            
            yield return 0;
        }
        float t = 0;
        int result = TryForge();
        int p = 1;
        List<float> deltaTs = new List<float>();
        float deltaT = 0;
        deltaTs = MyStrFunc.getTempoList_4_4();
        int lv = GameSlot.dataBag.CurrentItem.lv;
        while (result == 0 && GameStatus.CurrentSceneState == SceneState.playing_infopanel
            && GameSlot.itemInfoPanelState == ItemInfoPanelState.auto_forge)
        {
            t += Time.deltaTime;
            if (t > deltaT)
            {
                t -= deltaT;
                if (p <= deltaTs.Count)
                {
                    deltaT = deltaTs[p - 1];
                    p += 1;
                }
                else
                {
                    deltaTs = MyStrFunc.getTempoList_4_4();
                    p = 1;
                    deltaT = deltaTs[p - 1];
                    p += 1;
                }
                result = TryForge();//目标等级在里面判断，因为要输出具体反馈信息
            }
            yield return 0;
        }
    }
    public void OpenPanelAutoDissolve()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing_infopanel)
        {
            StopCoroutine("OpenPanelAutoForgeCR");
            StopCoroutine("OpenPanelAutoDissolveCR");
            GameSlot.dissolveUntilTargetLv = false;
            StartCoroutine("OpenPanelAutoDissolveCR");
            GameSlot.itemInfoPanelState = ItemInfoPanelState.auto_dissolve;
        }
    }
    void AutoDissolveUntilDisappear()
    {
        GameSlot.dissolveUntilTargetLv = true;
        StopCoroutine("OpenPanelAutoForgeCR");
        StopCoroutine("OpenPanelAutoDissolveCR");
        StartCoroutine("OpenPanelAutoDissolveCR");
    }
    IEnumerator OpenPanelAutoDissolveCR()//这里是点击分解挂机按钮
    {
        for (float t1 = 0; t1 <= 0.5f; t1 += Time.deltaTime)
        {
            btnAutoForgePanelPic.transform.localPosition = Vector3.Lerp(btnAutoForgePanelPic.transform.localPosition,
                new Vector3(0, 0, 0), info_panel_trans_speed1 * Time.deltaTime);
            btnAutoForgeToEndPanelPic.transform.localPosition = Vector3.Lerp(btnAutoForgeToEndPanelPic.transform.localPosition,
                new Vector3(0, 0, 0), info_panel_trans_speed1 * Time.deltaTime);
            btnAutoDissolvePanelPic.transform.localPosition = Vector3.Lerp(btnAutoDissolvePanelPic.transform.localPosition,
                new Vector3(-20, 0, 0), info_panel_trans_speed1 * Time.deltaTime);
            btnAutoDissolveToEndPanelPic.transform.localPosition = Vector3.Lerp(btnAutoDissolveToEndPanelPic.transform.localPosition,
                new Vector3(100, 0, 0), info_panel_trans_speed1 * Time.deltaTime);

            yield return 0;
        }

        if (GameSlot.dataBag.CurrentItem.lv > GameSlot.targetDissolveLv)
        {
            float t = 0;
            int result = TryDissolve();
            int p = 1;
            List<float> deltaTs = new List<float>();
            float deltaT = 0;
            deltaTs = MyStrFunc.getTempoList_4_4();
            while (result == 0 && GameStatus.CurrentSceneState == SceneState.playing_infopanel
                && GameSlot.itemInfoPanelState == ItemInfoPanelState.auto_dissolve)
            {
                if (!GameSlot.dissolveUntilTargetLv && GameSlot.dataBag.BagEnergyIsFull)
                {
                    break;
                }
                if (GameSlot.dataBag.CurrentItem.lv <= GameSlot.targetDissolveLv)
                {
                    break;
                }
                t += Time.deltaTime;
                if (t > deltaT)
                {
                    t -= deltaT;
                    if (p <= deltaTs.Count)
                    {
                        deltaT = deltaTs[p - 1];
                        p += 1;
                    }
                    else
                    {
                        deltaTs = MyStrFunc.getTempoList_3_4();
                        p = 1;
                        deltaT = deltaTs[p - 1];
                        p += 1;
                    }
                    result = TryDissolve();
                }
                yield return 0;
            }
            if (GameSlot.dissolveUntilTargetLv)
            {
                GameSlot.dissolveUntilTargetLv = false;
            }
            else
            {
                if (GameStatus.CurrentSceneState == SceneState.playing_infopanel)
                {
                    if (GameSlot.dataBag.CurrentChoosedOrderId == 0)
                    {

                    }
                    else if (GameSlot.dataBag.CurrentItem.lv <= GameSlot.targetDissolveLv)
                    {
                        GameStatus.superTextBulletList.Add(new SuperTextBullet(SentenceBank.pack.sentences["has_reached_target_lv"].ToString()
                            , 39, new Color(0.7f, 0.2f, 0.2f), forgeErrorPosition));
                    }
                    else if (GameSlot.itemInfoPanelState == ItemInfoPanelState.normal)
                    {

                    }
                    else
                    {
                        GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["bag_energy_has_full"].ToString(),
                           SentenceBank.pack.sentences["dissolve_until_target_lv"].ToString(), 3,
                           SentenceBank.pack.sentences["stop_dissolve"].ToString(), 0));
                    }
                }
            }
        }
    }
    int TryForge(bool isMute = false)
    {
        int pId = GameSlot.dataBag.currentChoosedPositionId;
        int oId = GameSlot.dataBag.GetItemOrderId(pId);
        int iId = GameSlot.dataBag.GetItemId(pId);
        int lv = GameSlot.dataBag.item[oId - 1].lv;
        if (GameStatus.CurrentSceneState != SceneState.playing_infopanel)
        {
            return 1;
        }
        if (lv >= GameSlot.dataBag.bagLevel * 10)
        {
            GameStatus.superTextBulletList.Add(new SuperTextBullet(SentenceBank.pack.sentences["has_maxlv"].ToString()
                , 39, new Color(0.7f, 0.2f, 0.2f), forgeErrorPosition));
            return 1;
        }
        if (!GameSlot.dataBag.CurrentItem.CanForge || lv >= GameSlot.targetForgeLv)
        {
            GameStatus.superTextBulletList.Add(new SuperTextBullet(SentenceBank.pack.sentences["has_reached_target_lv"].ToString()
                , 39, new Color(0.7f, 0.2f, 0.2f), forgeErrorPosition));
            return 1;
        }
        int forgeAtk = 1 + GameSlot.dataBag.GetTotalForgeAtkPlus();
        int finalResult = ItemAddProgress(pId, forgeAtk, false, isMute);
        return finalResult;
    }
    Vector3 GetRelativePosition(Vector3 inputPosition, List<Vector3> fatherPositionList)
    {
        Vector3 result = inputPosition - new Vector3(270, 480);
        for (int i = 1; i <= fatherPositionList.Count; i++)
        {
            result -= fatherPositionList[i - 1];
        }
        return result;
    }
    public void Forge()
    {
        int pId = GameSlot.dataBag.currentChoosedPositionId;
        int oId = GameSlot.dataBag.GetItemOrderId(pId);
        int iId = GameSlot.dataBag.GetItemId(pId);
        int lv = GameSlot.dataBag.item[oId - 1].lv;

        #region checking cost and levelup
        if (GameStatus.CurrentSceneState != SceneState.playing_infopanel)
        {
            return;
        }
        if (lv >= 300)
        {
            GameStatus.superTextBulletList.Add(new SuperTextBullet(SentenceBank.pack.sentences["has_maxlv"].ToString()
                , 39, new Color(0.7f, 0.2f, 0.2f), forgeErrorPosition));
            return;
        }
        if (lv >= GameSlot.dataBag.bagLevel * 10)
        {
            GameStatus.superTextBulletList.Add(new SuperTextBullet(SentenceBank.pack.sentences["error_notenouphbaglevel"].ToString()
                , 30, new Color(0.7f, 0.2f, 0.2f), forgeErrorPosition));
            return;
        }
        int forgeAtk = 1 + GameSlot.dataBag.GetTotalForgeAtkPlus();
        int finalResult = ItemAddProgress(pId, forgeAtk);
        #endregion
    }
    private int ItemAddProgress(int addPositionId, int forgeAtk, bool isAuto = false, bool isMute = false)
    {
        int pId = addPositionId;
        int oId = GameSlot.dataBag.GetItemOrderId(pId);
        int iId = GameSlot.dataBag.GetItemId(pId);
        int lv = GameSlot.dataBag.item[oId - 1].lv;
        int currentLvExp = GameSlot.dataBag.item[oId - 1].exp;

        int progress = GameSlot.dataBag.item[oId - 1].exp;
        #region 改成能量制后，立即结算能量消耗或获取
        if (GameSlot.dataBag.BagEnergy < forgeAtk)
        {
            if (isAuto)
            {
            }
            else
            {
                GameStatus.superTextBulletList.Add(new SuperTextBullet(SentenceBank.pack.sentences["error_notenouphenergy"].ToString()
                    , 39, new Color(0.7f, 0.2f, 0.2f), forgeErrorPosition));
            }
            return 1;
        }
        else
        {
            if (forgeAtk > 0)
            {
                BagAddEnergy(-forgeAtk, isMute);
            }
            else
            {
                int dissolvePer1000 = GameSlot.dataBag.GetTotalDissolveGetPlus();
                float finalDisAtk = -forgeAtk * (1 + dissolvePer1000 * 0.001f);

                int finalDisAtkInt = Mathf.FloorToInt(finalDisAtk);
                float rand = Random.Range(0, 1f);
                int finalDisAtkInt2 = 0;
                if (rand <= finalDisAtk - finalDisAtkInt)
                {
                    finalDisAtkInt2 = finalDisAtkInt + 1;
                }
                else
                {
                    finalDisAtkInt2 = finalDisAtkInt;
                }
                int itemMaxExp = 0;
                if (lv == 1)
                {
                    itemMaxExp = 5 + currentLvExp;
                }
                else
                {
                    itemMaxExp = 5 + MapDataLib.mdItemLib.expNeedSum[lv - 2] + currentLvExp;
                }
                int finalDisAtkInt3 = Mathf.Min(itemMaxExp, finalDisAtkInt2);
                //如果是CD类道具且降级会导致消失，则警告提示
                if (finalDisAtkInt2 > itemMaxExp - 5 &&
                    (GameSlot.dataBag.item[oId - 1].AttriTypeList.Contains(AttributeType.generatePotion) ||
                    GameSlot.dataBag.item[oId - 1].AttriTypeList.Contains(AttributeType.copyItem))
                    && GameStatus.CurrentPlayMode == PlayMode.abyss)
                {
                    GameSlot.newMsgBoxList.Add(new MsgBox(
                            SentenceBank.pack.sentences["dissolve_disappear_high_crystal_ban_title"].ToString(),
                            SentenceBank.pack.sentences["dissolve_disappear_high_crystal_ban_desc"].ToString(), 0));
                    return 1;
                }
                BagAddEnergy(finalDisAtkInt3, isMute);
            }
        }
        #endregion
        ItemNewData newValue = MapDataLib.mdItemLib.GetNewItemData(lv, progress, forgeAtk, GameSlot.dataBag.bagLevel * 10);

        GameSlot.dataBag.item[oId - 1].exp = newValue.progress;
        #region 播放锻造分解视觉特效
        Vector3 p1 = new Vector3(Random.Range(-150, 150), Random.Range(-270, 270), 0);
        if (isAuto)
        {
        }
        else
        {
            if (!isMute)
            {
                if (forgeAtk > 0)
                {
                    GameStatus.itemPanelEffectList.Add(new ItemPanelEffect(ParticleEffectsType.forge, 1, Vector3.zero));
                    GameSound.PlayForgeSoundByMode(1);
                    GameStatus.superTextBulletList.Add(new SuperTextBullet("+" + forgeAtk, 39, new Color(0.2f, 0.5f, 0.2f), forgeResultPosition));

                }
                else
                {
                    GameStatus.itemPanelEffectList.Add(new ItemPanelEffect(ParticleEffectsType.dissolve, 1, p1));
                    GameSound.PlayForgeSoundByMode(1, 2);
                    GameStatus.superTextBulletList.Add(new SuperTextBullet(SuperTextBulletType.drop, forgeAtk.ToString(), 39,
                        new Color(0.2f, 0.5f, 0.2f), forgeResultPosition));
                }
            }
        }
        #endregion
        if (newValue.level > lv)
        {
            #region 升级特效与飘字
            if (!isMute)
            {
                if (isAuto)
                {
                    GameStatus.superTextBulletList.Add(new SuperTextBullet(SentenceBank.pack.sentences["lv"] + "+" + (newValue.level - lv)
                        , 39, new Color(0.7f, 0.2f, 0.2f), bagCellBoardCanvas.cellCenterPosition[pId - 1]));
                }
                else
                {
                    GameStatus.superTextBulletList.Add(new SuperTextBullet(SentenceBank.pack.sentences["lv"] + "+" + (newValue.level - lv)
                        , 39, new Color(0.7f, 0.2f, 0.2f), itemLvUpReportPosition));
                    GameStatus.itemPanelEffectList.Add(new ItemPanelEffect(ParticleEffectsType.forge, 2, Vector3.zero));
                }
            }
            #endregion
            GameSlot.dataBag.item[oId - 1].lv = newValue.level;
            BagAddExp(pId, Mathf.RoundToInt(newValue.getExp * (100 + GameSlot.dataBag.GetTotalExpBonus()) / 100f), isAuto);
        }
        else if (newValue.level < lv)
        {
            if (!isMute)
                GameStatus.itemPanelEffectList.Add(new ItemPanelEffect(ParticleEffectsType.dissolve, 2, p1));
            if (newValue.level == 0)
            {
                RemoveItem(GameSlot.dataBag.currentChoosedPositionId);
                CloseInfoPanel();
                return 1;
            }
            else if (lv <= GameSlot.targetDissolveLv)
            {
                StopCoroutine("CloseInfoPanelCR");
                StartCoroutine(CloseInfoPanelCR());
                GameSlot.itemInfoPanelState = ItemInfoPanelState.normal;
                return 1;
            }
            else
            {
                GameSlot.dataBag.item[oId - 1].lv = newValue.level;
                if (!isMute)
                    GameStatus.superTextBulletList.Add(new SuperTextBullet(SuperTextBulletType.drop, SentenceBank.pack.sentences["lv"] + "-" + (lv - newValue.level)
                    , 39, new Color(0.7f, 0.2f, 0.2f), itemLvUpReportPosition));
            }
        }
        if (isAuto)
        {
            UpdateCurrentItemValue(addPositionId);
        }
        else
        {
            if (!isMute)
            {
                UpdateCurrentItemValue();
            }
        }
        if (!isMute)
        {
            UpdateCurrentBagValue();
        }
        return 0;
    }
    void BagAddExp(int pId, int expValue, bool isAuto)
    {
        int bLv = GameSlot.dataBag.bagLevel;
        if (bLv >= GameSlot.dataBag.MaxLevel)
        {

        }
        else
        {
            GameSlot.dataBag.BagExp += expValue;

            if (isAuto)
            {
                AddExpFlowEffect(pId);
            }
            else
            {
                AddExpFlowEffect(0);
            }
        }
    }
    void BagAddEnergy(int value, bool isMute = false)
    {
        GameSlot.dataBag.BagEnergy += value;
        if (!isMute)
        {
            if (value == 0)
            {
                return;
            }
            else if (value > 0)
            {
                GameStatus.superTextBulletList.Add(new SuperTextBullet("+" + value, 32, new Color(0.7f, 0.7f, 0.3f), energyGotResultPosition));
            }
            else
            {
                GameStatus.superTextBulletList.Add(new SuperTextBullet(SuperTextBulletType.drop,
                    value.ToString(), 26, new Color(0.7f, 0.2f, 0.2f), energyGotResultPosition));
            }
            UpdateCurrentBagValue();
        }
    }
    void AddExpFlowEffect(int pId)
    {
        Vector3[] targetPosition1s = new Vector3[4];
        Vector3 flowCenterPosition = expGotFlowStartPosition;
        if (pId > 0)
        {
            flowCenterPosition = bagCellBoardCanvas.cellCenterPosition[pId - 1] - bagCellBoard.transform.localPosition;
        }
        targetPosition1s[0] = flowCenterPosition + new Vector3(Random.Range(10, 90) * 1, Random.Range(10, 90) * 1, 0);
        targetPosition1s[1] = flowCenterPosition + new Vector3(Random.Range(10, 90) * 1, Random.Range(10, 90) * -1, 0);
        targetPosition1s[2] = flowCenterPosition + new Vector3(Random.Range(10, 90) * -1, Random.Range(10, 90) * -1, 0);
        targetPosition1s[3] = flowCenterPosition + new Vector3(Random.Range(10, 90) * -1, Random.Range(10, 90) * 1, 0);
        Vector3 targetPosition2 = new Vector3(0, -430, 0);
        for (int i = 1; i <= 4; i++)
        {
            GameStatus.economyFlowEffectList.Add(new EconomyFlowEffect(expGotFlowStartPosition, targetPosition1s[i - 1],
                expGotResultPosition, new Color(Random.Range(0.3f, 0.5f), Random.Range(0.3f, 0.5f), Random.Range(0.3f, 0.5f))));
        }
    }
    int TryDissolve(bool isMute = false)
    {
        int pId = GameSlot.dataBag.currentChoosedPositionId;
        int oId = GameSlot.dataBag.GetItemOrderId(pId);
        int iId = GameSlot.dataBag.GetItemId(pId);
        int lv = GameSlot.dataBag.item[oId - 1].lv;
        if (GameStatus.CurrentSceneState != SceneState.playing_infopanel)
        {
            return 1;
        }
        int forgeAtk = (1 + GameSlot.dataBag.GetTotalForgeAtkPlus()) * 5;
        int finalResult = ItemAddProgress(pId, -forgeAtk, false, isMute);
        return finalResult;
    }
    public void Dissolve()
    {
        int pId = GameSlot.dataBag.currentChoosedPositionId;
        int oId = GameSlot.dataBag.GetItemOrderId(pId);
        int iId = GameSlot.dataBag.GetItemId(pId);
        int lv = GameSlot.dataBag.item[oId - 1].lv;
        #region check Lv down and disapper
        if (GameStatus.CurrentSceneState != SceneState.playing_infopanel)
        {
            return;
        }
        int forgeAtk = (1 + GameSlot.dataBag.GetTotalForgeAtkPlus()) * 5;

        ItemAddProgress(pId, -forgeAtk);
        #endregion
    }
    private void UpdateCurrentItemValue(int autoPositionId = 0)
    {
        int pId = 0;
        int oId = 0;
        int iId = 0;
        int lv = 0;

        if (GameSlot.dataBag.CurrentChoosedOrderId == 0)
        {
            Debug.Log("item can't find");
            try
            {
                bagCellBoardCanvas.itemIconUnitList[pId - 1].UpdateItemId();
            }
            catch
            {

            }
            return;
        }

        if (autoPositionId == 0)
        {
            pId = GameSlot.dataBag.currentChoosedPositionId;
            bagCellBoardCanvas.itemIconUnitList[pId - 1].ChangeValue(pId);
        }
        else
        {
            bagCellBoardCanvas.itemIconUnitList[autoPositionId - 1].ChangeValue(autoPositionId);
            if (autoPositionId == GameSlot.dataBag.currentChoosedPositionId)
            {
                pId = GameSlot.dataBag.currentChoosedPositionId;
            }
        }

        if (pId == 0)
        {
            return;
        }
        oId = GameSlot.dataBag.GetItemOrderId(pId);
        iId = GameSlot.dataBag.GetItemId(pId);
        lv = GameSlot.dataBag.item[oId - 1].lv;

        itemNameText.text = GameSlot.dataBag.item[oId - 1].Name;
        itemLevelText.text = SentenceBank.pack.sentences["lv"].ToString() + "\n" + lv;
        itemDescText.text = GameSlot.dataBag.item[oId - 1].Desc;


        GameStatus.targetItemProgressList.Add(new Vector2Int(GameSlot.dataBag.item[oId - 1].exp, MapDataLib.mdItemLib.GetExpNeedByLv(lv)));
    }
    private void UpdateCurrentBagValue()
    {
        int lv = GameSlot.dataBag.bagLevel;
        int energy = GameSlot.dataBag.BagEnergy;
        int exp = GameSlot.dataBag.BagExp;

        GameStatus.targetBagEnergyList.Add(new Vector2Int(energy, MapDataLib.mdBag.maxEnergy[lv - 1]));
        if (lv == GameSlot.dataBag.MaxLevel)
        {
            bagExpBar.transform.localScale = new Vector3(0, 1, 1);

            bagExpText.text = SentenceBank.pack.sentences["has_maxlv"].ToString();

        }
        else
        {
            GameStatus.targetBagExpList.Add(new Vector2Int(exp, MapDataLib.mdBag.expNeed[lv - 1]));
        }
        bagLvText.text = lv.ToString();
    }


    #endregion

    #region UI movements
    [SerializeField] float transTime = 0.6f;
    /// <summary>
    /// 移除格子数据+动画
    /// </summary>
    /// <param name="removePositionId1"></param>
    void RemoveItem(int removePositionId1)
    {
        int oId = GameSlot.dataBag.GetItemOrderId(removePositionId1);
        GameSlot.dataBag.RemoveItemByOrder(oId);
    }
    void CreatePotion(int pId, int lv)
    {
        int orderId = GameSlot.dataBag.GetInsertOrderId(pId);
        GameSlot.dataBag.AddItemByOrder(orderId, new DataItem(10, lv, 0, pId));
    }
    void CreateItem(int itemId, int pId, int lv, int exp = 0)
    {
        int orderId = GameSlot.dataBag.GetInsertOrderId(pId);
        GameSlot.dataBag.AddItemByOrder(orderId, new DataItem(itemId, lv, exp, pId));
    }
    void CreateCrystal(int id = 1)
    {
        BagAddEnergy(-MapDataLib.mdItemLib.GetExpNeedByLv(1));
        int pId = GameSlot.dataBag.currentChoosedPositionId;
        int orderId = GameSlot.dataBag.GetInsertOrderId(pId);
        GameSlot.dataBag.AddItemByOrder(orderId, new DataItem(id, 1, 0, pId));
    }

    public void CloseInfoPanel()
    {
        if (GameStatus.CurrentSceneState != SceneState.playing_infopanel)
        {
            StopCoroutine("OpenInfoPanelCR");
            StopCoroutine("CloseInfoPanelCR");
            StartCoroutine("CloseInfoPanelCR");
        }
        else if (GameSlot.itemInfoPanelState == ItemInfoPanelState.normal)
        {
            StopCoroutine("OpenInfoPanelCR");
            StopCoroutine("CloseInfoPanelCR");
            StartCoroutine("CloseInfoPanelCR");
        }
        else if (GameSlot.itemInfoPanelState == ItemInfoPanelState.auto_forge || GameSlot.itemInfoPanelState == ItemInfoPanelState.auto_dissolve)
        {
            Debug.Log("???");
            if (GameSlot.dataBag.CurrentChoosedOrderId == 0)
            {
                StopCoroutine("OpenInfoPanelCR");
                StopCoroutine("CloseInfoPanelCR");
                StartCoroutine("CloseInfoPanelCR");
            }
            else
            {
                StopCoroutine("ExitAutoForgeDissovle");
                StartCoroutine(ExitAutoForgeDissovle());
                GameSlot.itemInfoPanelState = ItemInfoPanelState.normal;
            }
        }
    }
    IEnumerator CloseInfoPanelCR()
    {
        GameStatus.CurrentSceneState = SceneState.playing;

        Vector3 forgeTarget, dissolveTarget, autoForgeStart, autoForgeTarget, autoDissolveStart, autoDissolveTarget;
        forgeTarget = new Vector3(-400, 120, 0);
        dissolveTarget = new Vector3(400, 120, 0);
        if (GameSlot.IsOpenAutoDissolve)
        {
            autoForgeStart = new Vector3(-90, 270, 0);
            autoForgeTarget = new Vector3(-90, 990, 0);
        }
        else
        {
            autoForgeStart = new Vector3(-90, 270, 0);
            autoForgeTarget = new Vector3(-90, 990, 0);
        }
        autoDissolveStart = new Vector3(90, 270, 0);
        autoDissolveTarget = new Vector3(90, 990, 0);
        btnAutoForgePanel.transform.localPosition = autoForgeStart;
        btnAutoDissolvePanel.transform.localPosition = autoDissolveStart;

        itemInfoPanelExitBtn.transform.localScale = new Vector3(0, 1, 1);

        for (float t = 0; t <= transTime; t += Time.deltaTime)
        {
            if (GameSlot.dataBag.currentChoosedPositionId > 0)
            {
                infoPanel.transform.localPosition = Vector3.Lerp(infoPanel.transform.localPosition,
                    bagCellBoardCanvas.cellCenterPosition[GameSlot.dataBag.currentChoosedPositionId - 1], info_panel_trans_speed1 * Time.deltaTime);
            }
            infoPanel.transform.localScale = Vector3.Lerp(infoPanel.transform.localScale,
                new Vector3(0, 0, 0), info_panel_trans_speed1 * Time.deltaTime);

            btnForgePanel.transform.localPosition = Vector3.Lerp(btnForgePanel.transform.localPosition,
                forgeTarget, info_panel_trans_speed1 * Time.deltaTime);
            btnDissolvePanel.transform.localPosition = Vector3.Lerp(btnDissolvePanel.transform.localPosition,
                dissolveTarget, info_panel_trans_speed1 * Time.deltaTime);
            btnAutoForgePanel.transform.localPosition = Vector3.Lerp(btnAutoForgePanel.transform.localPosition,
                autoForgeTarget, info_panel_trans_speed1 * Time.deltaTime);
            btnAutoDissolvePanel.transform.localPosition = Vector3.Lerp(btnAutoDissolvePanel.transform.localPosition,
                autoDissolveTarget, info_panel_trans_speed1 * Time.deltaTime);

            btnAutoForgePanelPic.transform.localPosition = Vector3.Lerp(btnAutoForgePanelPic.transform.localPosition,
                new Vector3(0, 0, 0), info_panel_trans_speed1 * Time.deltaTime);
            btnAutoDissolvePanelPic.transform.localPosition = Vector3.Lerp(btnAutoDissolvePanelPic.transform.localPosition,
                new Vector3(0, 0, 0), info_panel_trans_speed1 * Time.deltaTime);
            btnAutoForgeToEndPanelPic.transform.localPosition = Vector3.Lerp(btnAutoForgeToEndPanelPic.transform.localPosition,
                new Vector3(0, 0, 0), info_panel_trans_speed1 * Time.deltaTime);
            btnAutoDissolveToEndPanelPic.transform.localPosition = Vector3.Lerp(btnAutoDissolveToEndPanelPic.transform.localPosition,
                new Vector3(0, 0, 0), info_panel_trans_speed1 * Time.deltaTime);

            yield return 0;
        }
        if (GameSlot.dataBag.currentChoosedPositionId >= 1)
        {
            infoPanel.transform.localPosition = bagCellBoardCanvas.cellCenterPosition[GameSlot.dataBag.currentChoosedPositionId - 1];
        }
        else
        {
            infoPanel.transform.localPosition = bagCellBoardCanvas.cellCenterPosition[0];
        }
        infoPanel.transform.localScale = new Vector3(0, 0, 0);
        btnForgePanel.transform.localPosition = forgeTarget;
        btnDissolvePanel.transform.localPosition = dissolveTarget;
        btnAutoForgePanel.transform.localPosition = autoForgeTarget;
        btnAutoDissolvePanel.transform.localPosition = autoDissolveTarget;
    }
    IEnumerator ExitAutoForgeDissovle()
    {
        for (float t1 = 0; t1 <= 0.5f; t1 += Time.deltaTime)
        {
            btnAutoForgePanelPic.transform.localPosition = Vector3.Lerp(btnAutoForgePanelPic.transform.localPosition,
                Vector3.zero, info_panel_trans_speed1 * Time.deltaTime);
            btnAutoForgeToEndPanelPic.transform.localPosition = Vector3.Lerp(btnAutoForgeToEndPanelPic.transform.localPosition,
                Vector3.zero, info_panel_trans_speed1 * Time.deltaTime);
            btnAutoDissolvePanelPic.transform.localPosition = Vector3.Lerp(btnAutoDissolvePanelPic.transform.localPosition,
                Vector3.zero, info_panel_trans_speed1 * Time.deltaTime);
            btnAutoDissolveToEndPanelPic.transform.localPosition = Vector3.Lerp(btnAutoDissolveToEndPanelPic.transform.localPosition,
                Vector3.zero, info_panel_trans_speed1 * Time.deltaTime);

            
            yield return 0;
        }
        btnAutoForgePanelPic.transform.localPosition = Vector3.zero;
        btnAutoForgeToEndPanelPic.transform.localPosition = Vector3.zero;
        btnAutoDissolvePanelPic.transform.localPosition = Vector3.zero;
        btnAutoDissolveToEndPanelPic.transform.localPosition = Vector3.zero;
        
    }
    void ResetTargetLvPanel()
    {
        GameSlot.targetForgeLv = GameSlot.dataBag.CurrentItem.CurrentMaxLevel;
        GameSlot.targetDissolveLv = 0;
        UpdateTargetLv();
    }
    void OpenInfoPanel()
    {
        StopCoroutine("CloseInfoPanelCR");
        StopCoroutine("OpenInfoPanelCR");
        StartCoroutine("OpenInfoPanelCR");
        btnAutoForgeToEndStrText.text = SentenceBank.pack.sentences["forge_btn_fast"].ToString();
        btnAutoDissolveToEndStrText.text = SentenceBank.pack.sentences["forge_btn_fast"].ToString();
        ResetTargetLvPanel();
    }
    IEnumerator OpenInfoPanelCR()
    {
        GameStatus.CurrentSceneState = SceneState.playing_infopanel;
        GameSlot.itemInfoPanelState = ItemInfoPanelState.normal;
        UpdateCurrentItemValue();
        UpdateCurrentBagValue();

        Vector3 forgeTarget, dissolveTarget, autoForgeStart, autoForgeTarget, autoDissolveStart, autoDissolveTarget;
        if (GameSlot.IsOpenDissolve)
        {
            forgeTarget = new Vector3(-90, 120, 0);
        }
        else
        {
            forgeTarget = new Vector3(0, 120, 0);
        }
        dissolveTarget = new Vector3(90, 120, 0);
        if (GameSlot.IsOpenAutoDissolve)
        {
            autoForgeStart = new Vector3(-90, 990, 0);
            autoForgeTarget = new Vector3(-90, 270, 0);
        }
        else
        {
            autoForgeStart = new Vector3(-90, 990, 0);
            autoForgeTarget = new Vector3(-90, 270, 0);
        }
        autoDissolveStart = new Vector3(90, 990, 0);
        autoDissolveTarget = new Vector3(90, 270, 0);
        btnAutoForgePanel.transform.localPosition = autoForgeStart;
        btnAutoDissolvePanel.transform.localPosition = autoDissolveStart;

        itemInfoPanelExitBtn.transform.localScale = new Vector3(1, 1, 1);
        infoPanel.transform.localPosition = bagCellBoardCanvas.cellCenterPosition[GameSlot.dataBag.currentChoosedPositionId - 1];
        infoPanel.transform.localScale = new Vector3(0, 0, 0);
        for (float t = 0; t <= transTime; t += Time.deltaTime)
        {
            infoPanel.transform.localPosition = Vector3.Lerp(infoPanel.transform.localPosition,
                new Vector3(0, -90, 0), info_panel_trans_speed1 * Time.deltaTime);
            infoPanel.transform.localScale = Vector3.Lerp(infoPanel.transform.localScale,
                new Vector3(1, 1, 1), info_panel_trans_speed1 * Time.deltaTime);

            btnForgePanel.transform.localPosition = Vector3.Lerp(btnForgePanel.transform.localPosition,
                forgeTarget, info_panel_trans_speed1 * Time.deltaTime);
            btnDissolvePanel.transform.localPosition = Vector3.Lerp(btnDissolvePanel.transform.localPosition,
                dissolveTarget, info_panel_trans_speed1 * Time.deltaTime);
            btnAutoForgePanel.transform.localPosition = Vector3.Lerp(btnAutoForgePanel.transform.localPosition,
                autoForgeTarget, info_panel_trans_speed1 * Time.deltaTime);
            btnAutoDissolvePanel.transform.localPosition = Vector3.Lerp(btnAutoDissolvePanel.transform.localPosition,
                autoDissolveTarget, info_panel_trans_speed1 * Time.deltaTime);
            yield return 0;
        }
        infoPanel.transform.localPosition = new Vector3(0, -90, 0);
        infoPanel.transform.localScale = new Vector3(1, 1, 1);
        btnForgePanel.transform.localPosition = forgeTarget;
        btnDissolvePanel.transform.localPosition = dissolveTarget;
        btnAutoForgePanel.transform.localPosition = autoForgeTarget;
        btnAutoDissolvePanel.transform.localPosition = autoDissolveTarget;
    }

    void CheckNumAndBarChange()
    {
        if (GameStatus.targetItemProgressList.Count > 0)
        {
            if (Mathf.Abs(itemProgressBar.transform.localScale.x - GameStatus.targetItemProgressList[0].x * 1f / GameStatus.targetItemProgressList[0].y) > 0.001f)
            {
                itemProgressBar.transform.localScale = Vector3.Lerp(itemProgressBar.transform.localScale,
                    new Vector3(GameStatus.targetItemProgressList[0].x * 1f / GameStatus.targetItemProgressList[0].y, 1, 1),
                    Mathf.Min(1, bar_trans_speed * Time.deltaTime * GameStatus.targetItemProgressList.Count));
                int numerator = Mathf.RoundToInt(itemProgressBar.transform.localScale.x * GameStatus.targetItemProgressList[0].y);
                int denominator = GameStatus.targetItemProgressList[0].y;

                itemProgressValueText.text = numerator + "/" + denominator;
            }
            else
            {
                itemProgressValueText.text = GameStatus.targetItemProgressList[0].x + "/" + GameStatus.targetItemProgressList[0].y;
                GameStatus.targetItemProgressList.RemoveAt(0);
            }
        }
        if (GameStatus.targetBagEnergyList.Count > 0)
        {
            if (Mathf.Abs(bagEnergyBar.transform.localScale.x - GameStatus.targetBagEnergyList[0].x * 1f / GameStatus.targetBagEnergyList[0].y) > 0.001f)
            {
                bagEnergyBar.transform.localScale = Vector3.Lerp(bagEnergyBar.transform.localScale,
                    new Vector3(GameStatus.targetBagEnergyList[0].x * 1f / GameStatus.targetBagEnergyList[0].y, 1, 1),
                    Mathf.Min(1, bar_trans_speed * Time.deltaTime * GameStatus.targetBagEnergyList.Count));
                int numerator = Mathf.RoundToInt(bagEnergyBar.transform.localScale.x * GameStatus.targetBagEnergyList[0].y);
                int denominator = GameStatus.targetBagEnergyList[0].y;

                bagEnergyText.text = numerator + "/" + denominator;
            }
            else
            {
                bagEnergyBar.transform.localScale = new Vector3(GameStatus.targetBagEnergyList[0].x * 1f / GameStatus.targetBagEnergyList[0].y, 1, 1);
                bagEnergyText.text = GameStatus.targetBagEnergyList[0].x + "/" + GameStatus.targetBagEnergyList[0].y;
                GameStatus.targetBagEnergyList.RemoveAt(0);
            }
        }
        if (GameStatus.targetBagExpList.Count > 0)
        {
            if (Mathf.Abs(bagExpBar.transform.localScale.x - GameStatus.targetBagExpList[0].x * 1f / GameStatus.targetBagExpList[0].y) > 0.001f)
            {
                bagExpBar.transform.localScale = Vector3.Lerp(bagExpBar.transform.localScale,
                    new Vector3(GameStatus.targetBagExpList[0].x * 1f / GameStatus.targetBagExpList[0].y, 1, 1),
                    Mathf.Min(1, bar_trans_speed * Time.deltaTime * GameStatus.targetBagExpList.Count));
                int numerator = Mathf.RoundToInt(bagExpBar.transform.localScale.x * GameStatus.targetBagExpList[0].y);
                int denominator = GameStatus.targetBagExpList[0].y;

                bagExpText.text = numerator + "/" + denominator;
            }
            else
            {
                bagExpBar.transform.localScale = new Vector3(GameStatus.targetBagExpList[0].x * 1f / GameStatus.targetBagExpList[0].y, 1, 1);
                bagExpText.text = GameStatus.targetBagExpList[0].x + "/" + GameStatus.targetBagExpList[0].y;
                GameStatus.targetBagExpList.RemoveAt(0);
            }
        }
    }
    #endregion

    #region game window state change
    #region big scene layer
    public void FromTitleToPlaying_newgame()
    {
        if (GameStatus.CurrentSceneState == SceneState.title)
        {
            GameSlot.InitData();
            StopCoroutine("FromTitleToPlayingIn");
            StartCoroutine("FromTitleToPlayingIn", true);
        }
    }

    List<GameObject> leavesInTitle = new List<GameObject>();
    IEnumerator CurtainInOut(float speedScale = 1)
    {
        imageCurtain.color = new Color(0, 0, 0, 0);
        curtain.transform.localScale = new Vector3(1, 1, 1);
        for (float t = 0; t <= 1; t += Time.deltaTime * speedScale)
        {
            imageCurtain.color = new Color(0, 0, 0, t);
            yield return 0;
        }
        imageCurtain.color = new Color(0, 0, 0, 1);
        for (float t = 0; t <= 0.25f; t += Time.deltaTime)
        {
            yield return 0;
        }
        for (float t = 1; t >= 0; t -= Time.deltaTime * speedScale)
        {
            imageCurtain.color = new Color(0, 0, 0, t);
            yield return 0;
        }
        imageCurtain.color = new Color(0, 0, 0, 0);
        curtain.transform.localScale = new Vector3(0, 1, 1);
    }
    IEnumerator CurtainLeafInOut()
    {
        imageCurtain.color = new Color(0, 0, 0, 0);
        curtain.transform.localScale = new Vector3(1, 1, 1);
        for (int x = -6; x <= 3; x++)
        {
            for (int y = -8; y <= 8; y++)
            {
                leavesInTitle.Add(Instantiate(leaf[Random.Range(0, 2)], curtain.transform));
                leavesInTitle[leavesInTitle.Count - 1].transform.localPosition = new Vector3(x * 80 + Random.Range(-20, 20) - 540, y * 55 + Random.Range(-20, 20), 0);
                leavesInTitle[leavesInTitle.Count - 1].transform.localRotation = Quaternion.Euler(0, 0, Random.Range(-30, 30));
                leavesInTitle[leavesInTitle.Count - 1].GetComponent<TurningLeafUnit>().startLeaf(Random.Range(0, 180),
                    new Vector3(660 + Random.Range(0, 300), 0, 0), 3);
            }
        }
        for (float t = 0; t <= 1; t += Time.deltaTime)
        {
            playing.transform.localPosition = new Vector3(-540 + 540 * t, 0, 0);
            title.transform.localPosition = new Vector3(540 * t, 0, 0);
            yield return 0;
        }
        title.transform.localScale = new Vector3(0, 1, 1);
        title.transform.localPosition = new Vector3(0, 0, 0);
        playing.transform.localPosition = new Vector3(0, 0, 0);
        for (float t = 0; t <= 2; t += Time.deltaTime)
        {
            yield return 0;
        }
        curtain.transform.localScale = new Vector3(0, 1, 1);
    }
    IEnumerator CurtainLeafInOutInPlaying()
    {
        imageCurtain.color = new Color(0, 0, 0, 0);
        curtain.transform.localScale = new Vector3(1, 1, 1);

        for (int x = -6; x <= 3; x++)
        {
            for (int y = -8; y <= 8; y++)
            {
                leavesInTitle.Add(Instantiate(leaf[Random.Range(0, 2)], curtain.transform));
                leavesInTitle[leavesInTitle.Count - 1].transform.localPosition = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0);
                leavesInTitle[leavesInTitle.Count - 1].transform.localRotation = Quaternion.Euler(0, 0, Random.Range(-30, 30));
                leavesInTitle[leavesInTitle.Count - 1].GetComponent<TurningLeafUnit>().startLeaf(Random.Range(0, 180),
                    new Vector3(330 + (y + 8) * 50, 0, 0), 2, LeafTurningType.swirlOutside);
            }
        }
        for (float t = 0; t <= 3; t += Time.deltaTime)
        {
            yield return 0;
        }
        curtain.transform.localScale = new Vector3(0, 1, 1);
    }
    IEnumerator newGameBtnStartCR(float speedScale = 1)
    {
        for (float t = 0; t <= 1; t += Time.deltaTime * speedScale)
        {
            title_total_layer.transform.localScale = new Vector3(1 + t * 0.8f, 1 + t * 0.8f, 1);
            title_total_layer.transform.localPosition = new Vector3(-t * 213, t * 372, 1);
            yield return 0;
        }
        title_total_layer.transform.localScale = new Vector3(1, 1, 1);
        title_total_layer.transform.localPosition = new Vector3(0, 0, 0);
        title.transform.localScale = new Vector3(0, 1, 1);

    }

    IEnumerator FromTitleToPlayingIn(bool isNew = true)
    {
        GameStatus.canControl = false;
        GameStatus.CurrentSceneState = SceneState.playing;
        GameStatus.CurrentPlayMode = PlayMode.story;
        ResetPlayingUIUnits();
        if (isStoryModeOn)
        {
            GameSlot.StartNewSentence();
        }

        bagCellBoardCanvas.UpdateItemCell();
        UpdateCurrentBagValue();
        float speedScale = 1;

        #region 这时进行判定，如果是开场剧情，则跳过主界面直接进入大段剧情界面

        if (GameStatus.CurrentSceneState == SceneState.playing)
        {
            GameStatus.canControl = true;
        }
        else
        {
        }
        speedScale = 1;
        if (isNew)
        {
            StopCoroutine("CurtainInOut");
            StartCoroutine("CurtainInOut", speedScale);
            StopCoroutine("newGameBtnStartCR");
            StartCoroutine("newGameBtnStartCR", speedScale);
            for (float t = 0; t <= 1; t += Time.deltaTime * speedScale)
            {
                yield return 0;
            }
            playing.transform.localPosition = new Vector3(0, 0, 0);
            playing.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            playing.transform.localPosition = new Vector3(-540, 0, 0);
            playing.transform.localScale = new Vector3(1, 1, 1);
            StopCoroutine("CurtainLeafInOut");
            StartCoroutine("CurtainLeafInOut");
        }

        #endregion
    }

    public void FromPlayingToTitle()
    {
        if (GameStatus.canControl && GameStatus.CurrentSceneState == SceneState.playing_pause)
        {
            ResetPauseBtnsPosition();
            StopCoroutine("StoryParagraphAnimationCRFull");
            StopCoroutine("StoryParagraphAnimationCR");
            StopCoroutine("FromPlayingToTitleIn");
            StartCoroutine(FromPlayingToTitleIn());
            StopCoroutine("PausePlayingCR");
            StopCoroutine("ExitPausePlayingCR");
            StartCoroutine("ExitPausePlayingCR");
        }
    }
    IEnumerator FromPlayingToTitleIn()
    {
        GameStatus.CurrentSceneState = SceneState.title;
        imageCurtain.color = new Color(0, 0, 0, 0);
        curtain.transform.localScale = new Vector3(1, 1, 1);
        for (float t = 0; t <= 1; t += Time.deltaTime)
        {
            imageCurtain.color = new Color(0, 0, 0, t);
            yield return 0;
        }
        imageCurtain.color = new Color(0, 0, 0, 1);
        storyParagraphBackLayer.transform.localScale = new Vector3(0, 1, 1);
        storyParagraphBackBack.transform.localScale = new Vector3(0, 1, 1);
        title.transform.localScale = new Vector3(1, 1, 1);
        playing.transform.localScale = new Vector3(0, 1, 1);
        endingList.transform.localScale = new Vector3(1, 1, 1);
        for (float t = 1; t >= 0; t -= Time.deltaTime)
        {
            imageCurtain.color = new Color(0, 0, 0, t);
            yield return 0;
        }
        imageCurtain.color = new Color(0, 0, 0, 0);
        curtain.transform.localScale = new Vector3(0, 1, 1);
    }
    #endregion
    #region save load slot
    public void TrySaveOrLoadInSlot(int id = 0)
    {
        if (GameStatus.CurrentSceneState == SceneState.playing_savelist)
        {
            TrySaveInSlot(id);
        }
        else if (GameStatus.CurrentSceneState == SceneState.playing_loadlist || GameStatus.CurrentSceneState == SceneState.title_loadlist)
        {
            TryLoadInSlot(id);
        }
    }
    private void TrySaveInSlot(int id = 0)
    {
        if (GameSlot.CanSave)
        {
            if (PlayerPrefs.HasKey("ProgressSlotStr_" + id))
            {
                GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["warning"].ToString(),
                    SentenceBank.pack.sentences["isOverWriteOrNot"].ToString(), 100 + id));
            }
            else
            {
                GameSlot.systemOrderFunctionList.Add(100 + id);
            }
        }
        else
        {
            GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["error"].ToString(),
                SentenceBank.pack.sentences["cannot_save_in_this_slot"].ToString(), 0));
        }
    }

    private void TryLoadInSlot(int id = 0)
    {
        if (PlayerPrefs.HasKey("ProgressSlotStr_" + id))
        {
            if (GameStatus.CurrentSceneState == SceneState.playing_loadlist)
            {
                GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["warning"].ToString(),
                    SentenceBank.pack.sentences["isLoadHereOrNot"].ToString(), 200 + id));
            }
            else if (GameStatus.CurrentSceneState == SceneState.title_loadlist)
            {
                StopCoroutine("CloseLoadListCR");
                StartCoroutine("CloseLoadListCR");
                GameSlot.InitData();

                GameSlot.LoadSingleSlot(id);
                StopCoroutine("FromTitleToPlayingIn");
                StartCoroutine("FromTitleToPlayingIn", false);
            }
        }
    }
    public void OpenSaveMenuInPlaying()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing_pause)
        {
            if (GameSlot.CanSave)
            {
                GameStatus.CurrentSceneState = SceneState.playing_savelist;
                StopCoroutine("OpenSaveListCR");
                StopCoroutine("CloseSaveListCR");
                StartCoroutine("OpenSaveListCR");
            }
            else
            {
                GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["error"].ToString(),
                    SentenceBank.pack.sentences["cannot_save_in_changing"].ToString(), 0));
            }
        }
    }
    public void OpenLoadMenuInPlaying()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing_pause)
        {
            GameStatus.CurrentSceneState = SceneState.playing_loadlist;
            StopCoroutine("OpenLoadListCR");
            StopCoroutine("CloseLoadListCR");
            StartCoroutine("OpenLoadListCR");
        }
    }
    public void OpenLoadMenuInTitle()
    {
        if (GameStatus.CurrentSceneState == SceneState.title)
        {
            GameStatus.CurrentSceneState = SceneState.title_loadlist;
            StopCoroutine("OpenLoadListCR");
            StopCoroutine("CloseLoadListCR");
            StartCoroutine("OpenLoadListCR");
        }
    }
    public void CloseSaveOrLoadList()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing_savelist)
        {
            CloseSaveList();
        }
        else if (GameStatus.CurrentSceneState == SceneState.playing_loadlist || GameStatus.CurrentSceneState == SceneState.title_loadlist)
        {
            CloseLoadList();
        }
    }
    private void UpdateSaveLoadSlotBriefText()
    {
        for (int i = 1; i <= 8; i++)
        {
            btnSaveLoadSlotBriefText[i - 1].text = GameSlot.GetSlotBriefStr(i - 1);
        }
    }
    IEnumerator OpenSaveListCR()
    {
        saveLoadExitBtn.transform.localScale = Vector3.zero;
        saveLoadTitle.transform.localPosition = saveLoadTitleStartPosition;
        saveLoadTitleStrText.text = SentenceBank.pack.sentences["save_slots"].ToString();
        UpdateSaveLoadSlotBriefText();
        for (int i = 2; i <= 8; i++)
        {
            btnSaveLoadSlot[i - 1].transform.localPosition = btnSaveSlotStartPosition[i - 1];
        }
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            saveLoadExitBtn.transform.localScale = Vector3.Lerp(saveLoadExitBtn.transform.localScale, Vector3.one, 15 * Time.deltaTime);
            saveLoadTitle.transform.localPosition = Vector3.Lerp(saveLoadTitle.transform.localPosition, saveLoadTitleEndPosition, 15 * Time.deltaTime);
            for (int i = 2; i <= 8; i++)
            {
                btnSaveLoadSlot[i - 1].transform.localPosition = Vector3.Lerp(btnSaveLoadSlot[i - 1].transform.localPosition,
                    btnSaveSlotEndPosition[i - 1], 15 * Time.deltaTime);
            }
            yield return 0;
        }
        saveLoadExitBtn.transform.localScale = Vector3.one;
        saveLoadTitle.transform.localPosition = saveLoadTitleEndPosition;
        for (int i = 2; i <= 8; i++)
        {
            btnSaveLoadSlot[i - 1].transform.localPosition = btnSaveSlotEndPosition[i - 1];
        }
    }
    void CloseSaveList()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing_savelist && !GameSlot.IsMsgBoxOn)
        {
            GameStatus.CurrentSceneState = SceneState.playing_pause;
            StopCoroutine("OpenSaveListCR");
            StopCoroutine("CloseSaveListCR");
            StartCoroutine("CloseSaveListCR");
        }
    }
    IEnumerator CloseSaveListCR()
    {
        saveLoadExitBtn.transform.localScale = Vector3.one;
        saveLoadTitle.transform.localPosition = saveLoadTitleEndPosition;
        for (int i = 2; i <= 8; i++)
        {
            btnSaveLoadSlot[i - 1].transform.localPosition = btnSaveSlotEndPosition[i - 1];
        }
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            saveLoadExitBtn.transform.localScale = Vector3.Lerp(saveLoadExitBtn.transform.localScale, Vector3.zero, 15 * Time.deltaTime);
            saveLoadTitle.transform.localPosition = Vector3.Lerp(saveLoadTitle.transform.localPosition, saveLoadTitleStartPosition, 15 * Time.deltaTime);
            for (int i = 2; i <= 8; i++)
            {
                btnSaveLoadSlot[i - 1].transform.localPosition = Vector3.Lerp(btnSaveLoadSlot[i - 1].transform.localPosition,
                    btnSaveSlotStartPosition[i - 1], 15 * Time.deltaTime);
            }
            yield return 0;
        }
        saveLoadExitBtn.transform.localScale = Vector3.zero;
        saveLoadTitle.transform.localPosition = saveLoadTitleStartPosition;
        for (int i = 2; i <= 8; i++)
        {
            btnSaveLoadSlot[i - 1].transform.localPosition = btnSaveSlotStartPosition[i - 1];
        }
    }
    IEnumerator OpenLoadListCR()
    {
        saveLoadExitBtn.transform.localScale = Vector3.zero;
        saveLoadTitle.transform.localPosition = saveLoadTitleStartPosition;
        saveLoadTitleStrText.text = SentenceBank.pack.sentences["load_slots"].ToString();
        UpdateSaveLoadSlotBriefText();
        for (int i = 1; i <= 8; i++)
        {
            btnSaveLoadSlot[i - 1].transform.localPosition = btnLoadSlotStartPosition[i - 1];
        }
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            saveLoadExitBtn.transform.localScale = Vector3.Lerp(saveLoadExitBtn.transform.localScale, Vector3.one, 15 * Time.deltaTime);
            saveLoadTitle.transform.localPosition = Vector3.Lerp(saveLoadTitle.transform.localPosition, saveLoadTitleEndPosition, 15 * Time.deltaTime);
            for (int i = 1; i <= 8; i++)
            {
                btnSaveLoadSlot[i - 1].transform.localPosition = Vector3.Lerp(btnSaveLoadSlot[i - 1].transform.localPosition,
                    btnLoadSlotEndPosition[i - 1], 15 * Time.deltaTime);
            }
            yield return 0;
        }
        saveLoadExitBtn.transform.localScale = Vector3.one;
        saveLoadTitle.transform.localPosition = saveLoadTitleEndPosition;
        for (int i = 1; i <= 8; i++)
        {
            btnSaveLoadSlot[i - 1].transform.localPosition = btnLoadSlotEndPosition[i - 1];
        }
    }
    void CloseLoadList()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing_loadlist && !GameSlot.IsMsgBoxOn)
        {
            GameStatus.CurrentSceneState = SceneState.playing_pause;
            StopCoroutine("OpenLoadListCR");
            StopCoroutine("CloseLoadListCR");
            StartCoroutine("CloseLoadListCR");
        }
        else if (GameStatus.CurrentSceneState == SceneState.title_loadlist && !GameSlot.IsMsgBoxOn)
        {
            GameStatus.CurrentSceneState = SceneState.title;
            StopCoroutine("OpenLoadListCR");
            StopCoroutine("CloseLoadListCR");
            StartCoroutine("CloseLoadListCR");
        }
    }
    IEnumerator CloseLoadListCR()
    {
        saveLoadExitBtn.transform.localScale = Vector3.one;
        saveLoadTitle.transform.localPosition = saveLoadTitleEndPosition;
        for (int i = 1; i <= 8; i++)
        {
            btnSaveLoadSlot[i - 1].transform.localPosition = btnLoadSlotEndPosition[i - 1];
        }
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            saveLoadExitBtn.transform.localScale = Vector3.Lerp(saveLoadExitBtn.transform.localScale, Vector3.zero, 15 * Time.deltaTime);
            saveLoadTitle.transform.localPosition = Vector3.Lerp(saveLoadTitle.transform.localPosition, saveLoadTitleStartPosition, 15 * Time.deltaTime);
            for (int i = 1; i <= 8; i++)
            {
                btnSaveLoadSlot[i - 1].transform.localPosition = Vector3.Lerp(btnSaveLoadSlot[i - 1].transform.localPosition,
                    btnLoadSlotStartPosition[i - 1], 15 * Time.deltaTime);
            }
            yield return 0;
        }
        saveLoadExitBtn.transform.localScale = Vector3.zero;
        saveLoadTitle.transform.localPosition = saveLoadTitleStartPosition;
        for (int i = 1; i <= 8; i++)
        {
            btnSaveLoadSlot[i - 1].transform.localPosition = btnLoadSlotStartPosition[i - 1];
        }
    }
    #endregion
    #region about pause menu
    public void ClickPauseBtn()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing && GameSlot.current_mss.CanPause)
        {
            PausePlaying();
            defaultReadSpeedStrText.text = GameSlot.DefaultReadSpeedStr;
        }
        else if (GameStatus.CurrentSceneState == SceneState.playing_pause)
        {
            ExitPausePlaying();
        }
    }
    private void PausePlaying()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing && !GameSlot.IsMsgBoxOn)
        {
            GameStatus.CurrentSceneState = SceneState.playing_pause;
            StopCoroutine("PausePlayingCR");
            StopCoroutine("ExitPausePlayingCR");
            StartCoroutine("PausePlayingCR");
        }
    }
    private void ResetPauseBtnsPosition(int type = 0)
    {
        if (type == 0)
        {
            for (int i = 2; i <= 7; i++)
            {
                btnsPause[i - 1].transform.localPosition = btnsPausePosition[0];//没错，就是移动到暂停按钮位置，伸缩动态需要
                btnsPause[i - 1].transform.localScale = Vector3.zero;
            }
            pauseBackImage.color = new Color(0, 0, 0, 0);
        }
        else
        {
            for (int i = 2; i <= 7; i++)
            {
                btnsPause[i - 1].transform.localPosition = btnsPausePosition[i - 1];
                btnsPause[i - 1].transform.localScale = Vector3.one;
            }
            pauseBackImage.color = new Color(0, 0, 0, 1);
        }
    }
    IEnumerator PausePlayingCR()
    {
        ResetPauseBtnsPosition();
        pauseBack.transform.localScale = Vector3.one;
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            pauseBackImage.color = new Color(0, 0, 0, t * 2);
            for (int i = 2; i <= 7; i++)
            {
                btnsPause[i - 1].transform.localPosition = Vector3.Lerp(btnsPause[i - 1].transform.localPosition, btnsPausePosition[i - 1], 0.4f);
                btnsPause[i - 1].transform.localScale = Vector3.Lerp(btnsPause[i - 1].transform.localScale, Vector3.one, 0.4f);
            }
            yield return 0;
        }
        ResetPauseBtnsPosition(1);
    }
    public void ExitPausePlaying()//退出必须是PUBLIC，因为点击按钮外区域调用的是这个
    {
        if (GameStatus.CurrentSceneState == SceneState.playing_pause && !GameSlot.IsMsgBoxOn)
        {
            GameStatus.CurrentSceneState = SceneState.playing;
            StopCoroutine("PausePlayingCR");
            StopCoroutine("ExitPausePlayingCR");
            StartCoroutine("ExitPausePlayingCR");
        }
    }
    IEnumerator ExitPausePlayingCR()
    {
        ResetPauseBtnsPosition(1);
        for (float t = 0.5f; t >= 0; t -= Time.deltaTime)
        {
            pauseBackImage.color = new Color(0, 0, 0, t * 2);
            for (int i = 2; i <= 7; i++)
            {
                btnsPause[i - 1].transform.localPosition = Vector3.Lerp(btnsPause[i - 1].transform.localPosition, btnsPausePosition[0], 0.4f);
                btnsPause[i - 1].transform.localScale = Vector3.Lerp(btnsPause[i - 1].transform.localScale, Vector3.zero, 0.4f);
            }
            yield return 0;
        }
        pauseBack.transform.localScale = Vector3.zero;
        ResetPauseBtnsPosition();
    }

    #endregion
    #region endinglist UI movement and function
    public void ClearStoryKnots()
    {
        GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["warning"].ToString(),
            SentenceBank.pack.sentences["isClearStoryKnotsOrNot"].ToString(), 1));
    }
    public void TryStartGameFromKnot(int largeKnotId)
    {
        if (GameStatus.CurrentSceneState == SceneState.endinglist)
        {
            if (MapDataLib.storyKnot.endingType[largeKnotId - 1] >= 1 && MapDataLib.storyKnot.endingType[largeKnotId - 1] <= 3)
            {
                GameSlot.newMsgBoxList.Add(new MsgBox(MapDataLib.storyKnot.knotTitle[largeKnotId - 1],
                    SentenceBank.pack.sentences["isReWatchEnding"].ToString(), 10000 + largeKnotId));
            }
            else if (MapDataLib.storyKnot.endingType[largeKnotId - 1] == 4)
            {
                GameSlot.newMsgBoxList.Add(new MsgBox(MapDataLib.storyKnot.knotTitle[largeKnotId - 1],
                    SentenceBank.pack.sentences["isReWatchTBC"].ToString(), 10000 + largeKnotId));
            }
            else
            {
                GameSlot.newMsgBoxList.Add(new MsgBox(MapDataLib.storyKnot.knotTitle[largeKnotId - 1],
                    SentenceBank.pack.sentences["startFromKnotBegin"].ToString(), 10000 + largeKnotId,
                    SentenceBank.pack.sentences["startFromKnotSwitch"].ToString(), 20000 + largeKnotId));
            }
        }
    }
    public void StartGameFromKnot(int largeKnotId)
    {
        GameSlot.InitData();
        GameSlot.dataBag.LoadStoryOfficialSlot(largeKnotId);//必须先载入数据，因为跳转过程中会改变数据
        GameSlot.StoryJumpTo(largeKnotId, 1, true);
        StopCoroutine("FromEndingListToPlayingIn");
        StartCoroutine(FromEndingListToPlayingIn());
    }
    public void StartGameFromKnotAtSwitchMission(int largeKnotId)
    {
        GameSlot.InitData();
        GameSlot.dataBag.LoadStoryOfficialSlot(largeKnotId);//必须先载入数据，因为跳转过程中会改变数据
        GameSlot.StoryJumpToAndSkipToSwitchMission(largeKnotId, 1);
        StopCoroutine("FromEndingListToPlayingIn");
        StartCoroutine(FromEndingListToPlayingIn());
    }
    IEnumerator FromEndingListToPlayingIn()
    {
        GameStatus.canControl = false;
        GameStatus.CurrentSceneState = SceneState.playing;
        GameStatus.CurrentPlayMode = PlayMode.story;
        ResetPlayingUIUnits();
        //Debug.Log("continue knot");
        if (isStoryModeOn)
        {
            Debug.Log("start from knot");
            GameSlot.StartNewSentence();
        }

        bagCellBoardCanvas.UpdateItemCell();
        UpdateCurrentBagValue();

        #region 这时进行判定，如果是开场剧情，则跳过主界面直接进入大段剧情界面

        if (GameStatus.CurrentSceneState == SceneState.playing)
        {
            GameStatus.canControl = true;
        }
        else
        {
        }

        imageCurtain.color = new Color(0, 0, 0, 0);
        curtain.transform.localScale = new Vector3(1, 1, 1);
        for (float t = 0; t <= 1; t += Time.deltaTime)
        {
            imageCurtain.color = new Color(0, 0, 0, t);
            yield return 0;
        }
        imageCurtain.color = new Color(0, 0, 0, 1);
        playing.transform.localPosition = new Vector3(0, 0, 0);
        playing.transform.localScale = new Vector3(1, 1, 1);
        endingList.transform.localPosition = new Vector3(0, -960, 0);
        endingList.transform.localScale = new Vector3(0, 1, 1);
        title.transform.localPosition = new Vector3(0, 0, 0);
        title.transform.localScale = new Vector3(0, 1, 1);
        for (float t = 1; t >= 0; t -= Time.deltaTime)
        {
            imageCurtain.color = new Color(0, 0, 0, t);
            yield return 0;
        }
        imageCurtain.color = new Color(0, 0, 0, 0);
        curtain.transform.localScale = new Vector3(0, 1, 1);

        GameSlot.isSystemOrderFunctionOn = false;


        #endregion
    }
    public void FromPlayingToEndingList()
    {
#if UNITY_ANDROID
        GameSlot.UploadLevelToTapDB();
#endif
        StopCoroutine("FromPlayingToEndingListCR");
        StartCoroutine("FromPlayingToEndingListCR");
    }
    IEnumerator FromPlayingToEndingListCR()
    {
        StopCoroutine("CurtainInOut");
        StartCoroutine("CurtainInOut", 1);
        for (float t = 0; t <= 1; t += Time.deltaTime)
        {
            storyParagraphBackBack.transform.localScale = new Vector3(1 - t, 1 - t, 1);
            yield return 0;
        }
        storyParagraphBackBack.transform.localScale = new Vector3(0, 0, 1);
        playing.transform.localPosition = new Vector3(0, 0, 0);
        playing.transform.localScale = new Vector3(0, 1, 1);
        endingList.transform.localPosition = new Vector3(0, 0, 0);
        endingList.transform.localScale = new Vector3(1, 1, 1);
        title.transform.localPosition = new Vector3(0, 960, 0);
        title.transform.localScale = new Vector3(1, 1, 1);
        endingListTitle.transform.localScale = new Vector3(1, 1, 1);
        endingListExitBtn.transform.localScale = new Vector3(1, 1, 1);
        GameStatus.CurrentSceneState = SceneState.endinglist;

    }
    public void OpenEndingList()
    {
        if (GameStatus.CurrentSceneState == SceneState.title)
        {
            StopCoroutine("OpenEndingListCR");
            StopCoroutine("CloseEndingListCR");
            StartCoroutine("OpenEndingListCR");
        }
    }
    IEnumerator OpenEndingListCR()
    {
        GameStatus.CurrentSceneState = SceneState.endinglist;
        endingList.GetComponent<COEndingList>().CreateALotOfBubble();
        endingListTitle.transform.localScale = new Vector3(0, 0, 1);
        endingListExitBtn.transform.localScale = new Vector3(0, 0, 1);
        for (float t = 0; t <= 1; t += Time.deltaTime)
        {
            title.transform.localPosition += new Vector3(0, Time.deltaTime * 2000 * t, 0);
            endingList.transform.localPosition += new Vector3(0, Time.deltaTime * 2000 * t, 0);
            yield return 0;
        }
        for (float t = 0; t <= 1; t += Time.deltaTime)
        {
            title.transform.localPosition = Vector3.Lerp(title.transform.localPosition, new Vector3(0, 960, 0),
                Mathf.Min(1, 5 * Time.deltaTime));
            endingList.transform.localPosition = Vector3.Lerp(endingList.transform.localPosition, new Vector3(0, 0, 0),
                Mathf.Min(1, 5 * Time.deltaTime));
            endingListTitle.transform.localScale = Vector3.Lerp(endingListTitle.transform.localScale, new Vector3(1, 1, 1),
                Mathf.Min(1, 10 * Time.deltaTime));
            endingListExitBtn.transform.localScale = Vector3.Lerp(endingListExitBtn.transform.localScale, new Vector3(1, 1, 1),
                Mathf.Min(1, 10 * Time.deltaTime));
            yield return 0;
        }
        title.transform.localPosition = new Vector3(0, 960, 0);
        endingList.transform.localPosition = new Vector3(0, 0, 0);
        endingListTitle.transform.localScale = new Vector3(1, 1, 1);
        endingListExitBtn.transform.localScale = new Vector3(1, 1, 1);

    }
    public void CloseEndingList()
    {
        if (GameStatus.CurrentSceneState == SceneState.endinglist)
        {
            StopCoroutine("OpenEndingListCR");
            StopCoroutine("CloseEndingListCR");
            StartCoroutine("CloseEndingListCR");
        }
    }
    IEnumerator CloseEndingListCR()
    {
        GameStatus.CurrentSceneState = SceneState.title;
        endingListTitle.transform.localScale = new Vector3(1, 1, 1);
        endingListExitBtn.transform.localScale = new Vector3(1, 1, 1);

        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            endingListTitle.transform.localScale = Vector3.Lerp(endingListTitle.transform.localScale, new Vector3(0, 0, 1),
                Mathf.Min(1, 10 * Time.deltaTime));
            endingListExitBtn.transform.localScale = Vector3.Lerp(endingListExitBtn.transform.localScale, new Vector3(0, 0, 1),
                Mathf.Min(1, 10 * Time.deltaTime));
            title.transform.localPosition = Vector3.Lerp(title.transform.localPosition, new Vector3(0, 0, 0),
                Mathf.Min(1, 8 * Time.deltaTime));
            endingList.transform.localPosition = Vector3.Lerp(endingList.transform.localPosition, new Vector3(0, -960, 0),
                Mathf.Min(1, 8 * Time.deltaTime));
            yield return 0;
        }

        for (float t = 0; t <= 1; t += Time.deltaTime)
        {
            title.transform.localPosition = Vector3.Lerp(title.transform.localPosition, new Vector3(0, 0, 0),
                Mathf.Min(1, 8 * Time.deltaTime));
            endingList.transform.localPosition = Vector3.Lerp(endingList.transform.localPosition, new Vector3(0, -960, 0),
                Mathf.Min(1, 8 * Time.deltaTime));
            yield return 0;
        }
        title.transform.localPosition = new Vector3(0, 0, 0);
        endingList.transform.localPosition = new Vector3(0, -960, 0);
        endingListTitle.transform.localScale = new Vector3(0, 0, 1);
        endingListExitBtn.transform.localScale = new Vector3(0, 0, 1);

    }
    public void OpenEndingListMoreInfoPanel()
    {
        if (GameStatus.CurrentSceneState == SceneState.endinglist)
        {
            StopCoroutine("OpenEndingListMoreInfoPanelCR");
            StopCoroutine("CloseEndingListMoreInfoPanelCR");
            StartCoroutine("OpenEndingListMoreInfoPanelCR");
        }
    }
    IEnumerator OpenEndingListMoreInfoPanelCR()
    {
        GameStatus.CurrentSceneState = SceneState.endinglist_moreinfo;
        COEndingList.statisticsChanged = true;
        endingListMoreInfo.transform.localScale = new Vector3(0, 0, 1);
        endingListMoreInfo.transform.localPosition = endingListMoreInfoStartPosition;
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            endingListMoreInfo.transform.localPosition = Vector3.Lerp(endingListMoreInfo.transform.localPosition, new Vector3(0, -100, 0), 0.4f);
            endingListMoreInfo.transform.localScale = Vector3.Lerp(endingListMoreInfo.transform.localScale, new Vector3(1, 1, 1), 0.4f);
            yield return 0;
        }
        endingListMoreInfo.transform.localPosition = new Vector3(0, -100, 0);
        endingListMoreInfo.transform.localScale = new Vector3(1, 1, 1);
    }
    public void CloseEndingListMoreInfoPanel()
    {
        if (GameStatus.CurrentSceneState == SceneState.endinglist_moreinfo)
        {
            StopCoroutine("OpenEndingListMoreInfoPanelCR");
            StopCoroutine("CloseEndingListMoreInfoPanelCR");
            StartCoroutine("CloseEndingListMoreInfoPanelCR");
        }
    }
    IEnumerator CloseEndingListMoreInfoPanelCR()
    {
        GameStatus.CurrentSceneState = SceneState.endinglist;
        endingListMoreInfo.transform.localPosition = new Vector3(0, -100, 0);
        endingListMoreInfo.transform.localScale = new Vector3(1, 1, 1);
        for (float t = 0.5f; t >= 0; t -= Time.deltaTime)
        {
            endingListMoreInfo.transform.localPosition = Vector3.Lerp(endingListMoreInfo.transform.localPosition, endingListMoreInfoStartPosition, 0.4f);
            endingListMoreInfo.transform.localScale = Vector3.Lerp(endingListMoreInfo.transform.localScale, new Vector3(0, 0, 1), 0.4f);
            yield return 0;
        }
        endingListMoreInfo.transform.localPosition = endingListMoreInfoStartPosition;
        endingListMoreInfo.transform.localScale = new Vector3(0, 0, 1);
    }
    public void OpenUnlockEventPanel()
    {
        GameSlot.newMsgBoxList.Add(new MsgBox("404", SentenceBank.pack.sentences["unopened_function"].ToString(), 0));
    }
    void ResetPlayingUIUnits()
    {
        ClearAllBubble();
        GameSlot.isHidingPanel = true;
        btnReadModeText.text = GameSlot.ReadModeStr;
        if (GameStatus.CurrentPlayMode == PlayMode.story)
        {
            playingPanelMission.transform.localScale = Vector3.one;
            playingPanelItemCell.transform.localScale = Vector3.one;
            playingPanelBagInfo.transform.localScale = Vector3.one;
            playingPanelPausePanel.transform.localScale = Vector3.one;
            playingPanelMission.transform.localPosition = playingPanelMissionHidePosition;
            playingPanelItemCell.transform.localPosition = playingPanelItemCellHidePosition;

            playingPanelAbyssFight.transform.localScale = Vector3.zero;
            pause_panel_abyss.transform.localScale = Vector3.zero;
        }
        else if (GameStatus.CurrentPlayMode == PlayMode.abyss)
        {
            playingPanelMission.transform.localScale = Vector3.zero;
            playingPanelItemCell.transform.localScale = Vector3.one;
            playingPanelBagInfo.transform.localScale = Vector3.one;
            playingPanelPausePanel.transform.localScale = Vector3.zero;
            playingPanelItemCell.transform.localPosition = playingPanelItemCellShowPosition;

            playingPanelAbyssFight.transform.localScale = Vector3.one;
            pause_panel_abyss.transform.localScale = Vector3.one;
        }
    }
    #endregion
    #region 其它模式界面相关
    #region 模式选择列表
    public void OpenOtherModeList()
    {
        if (GameStatus.CurrentSceneState == SceneState.title)
        {
            GameStatus.CurrentSceneState = SceneState.title_modeList;
            StopCoroutine("CloseOtherModeListCR");
            StopCoroutine("OpenOtherModeListCR");
            StartCoroutine("OpenOtherModeListCR");
        }
    }
    Vector3 catShowPosition = new Vector3(227, -99, 0);
    Vector3 catHidePosition = new Vector3(326, -239, 0);
    Vector3 otherModePanelShowPosition = new Vector3(0, 0, 0);
    Vector3 otherModePanelHidePosition = new Vector3(0, -960, 0);
    IEnumerator OpenOtherModeListCR()
    {
        btn_otherModeList.transform.localPosition = catShowPosition;
        panel_otherModeList.transform.localPosition = otherModePanelHidePosition;
        for (float t = 0; t <= 0.6f; t += Time.deltaTime)
        {
            btn_otherModeList.transform.localPosition = catShowPosition + (catHidePosition - catShowPosition) * (t / 0.6f);
            yield return 0;
        }
        btn_otherModeList.transform.localPosition = catHidePosition;
        for (float t = 0; t <= 0.6f; t += Time.deltaTime)
        {
            panel_otherModeList.transform.localPosition = otherModePanelHidePosition +
                (otherModePanelShowPosition - otherModePanelHidePosition) * (t / 0.6f);
            yield return 0;
        }
        panel_otherModeList.transform.localPosition = otherModePanelShowPosition;
    }
    public void CloseOtherModeList()
    {
        if (GameStatus.CurrentSceneState == SceneState.title_modeList)
        {
            StopCoroutine("OpenOtherModeListCR");
            StopCoroutine("CloseOtherModeListCR");
            StartCoroutine("CloseOtherModeListCR");
        }
    }
    IEnumerator CloseOtherModeListCR()
    {
        btn_otherModeList.transform.localPosition = catHidePosition;
        panel_otherModeList.transform.localPosition = otherModePanelShowPosition;
        for (float t = 0; t <= 0.6f; t += Time.deltaTime)
        {
            panel_otherModeList.transform.localPosition = otherModePanelShowPosition +
                (otherModePanelHidePosition - otherModePanelShowPosition) * (t / 0.6f);
            yield return 0;
        }
        panel_otherModeList.transform.localPosition = otherModePanelHidePosition;
        for (float t = 0; t <= 0.6f; t += Time.deltaTime)
        {
            btn_otherModeList.transform.localPosition = catHidePosition + (catShowPosition - catHidePosition) * (t / 0.6f);
            yield return 0;
        }
        btn_otherModeList.transform.localPosition = catShowPosition;
        GameStatus.CurrentSceneState = SceneState.title;
    }
    #endregion
    public void OpenPVEMode()
    {
        GameSlot.newMsgBoxList.Add(new MsgBox("404", SentenceBank.pack.sentences["unopened_function"].ToString(), 0));
    }
    public void OpenPVPMode()
    {
        GameSlot.newMsgBoxList.Add(new MsgBox("404", SentenceBank.pack.sentences["unopened_function"].ToString(), 0));
    }
    #endregion
    #region 作者信息界面相关
    public void OpenAuthorList()
    {
        if (GameStatus.CurrentSceneState == SceneState.title)
        {
            StopCoroutine("OpenAuthorListCR");
            StartCoroutine("OpenAuthorListCR");
        }
    }
    IEnumerator OpenAuthorListCR()
    {
        GameStatus.CurrentSceneState = SceneState.title_authorInfo;
        authorInfoTitle.transform.localPosition = authorInfoTitleStartPosition;
        otherAuthorInfo.transform.localPosition = otherAuthorInfoStartPosition;
        btn_closeAuthorInfo.transform.localScale = new Vector3(0, 0, 1);
        for (int i = 1; i <= 3; i++)
        {
            mainAuthor[i - 1].transform.localPosition = mainAuthorStartPosition[i - 1];
            mainAuthor[i - 1].transform.localRotation = Quaternion.Euler(mainAuthorStartRotation[i - 1]);
        }
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            authorInfoTitle.transform.localPosition = Vector3.Lerp(authorInfoTitle.transform.localPosition, authorInfoTitleTargetPosition,
                Mathf.Min(1, 15 * Time.deltaTime));
            otherAuthorInfo.transform.localPosition = Vector3.Lerp(otherAuthorInfo.transform.localPosition, otherAuthorInfoTargetPosition,
                Mathf.Min(1, 15 * Time.deltaTime));
            btn_closeAuthorInfo.transform.localScale = Vector3.Lerp(btn_closeAuthorInfo.transform.localScale, new Vector3(1, 1, 1),
                Mathf.Min(1, 15 * Time.deltaTime));
            for (int i = 1; i <= 3; i++)
            {
                mainAuthor[i - 1].transform.localPosition = Vector3.Lerp(mainAuthor[i - 1].transform.localPosition,
                    mainAuthorTargetPositionIn[i - 1], Mathf.Min(1, 15 * Time.deltaTime));
            }
            yield return 0;
        }
        authorInfoTitle.transform.localPosition = authorInfoTitleTargetPosition;
        otherAuthorInfo.transform.localPosition = otherAuthorInfoTargetPosition;
        btn_closeAuthorInfo.transform.localScale = new Vector3(1, 1, 1);
        for (int i = 1; i <= 3; i++)
        {
            mainAuthor[i - 1].transform.localPosition = mainAuthorTargetPositionIn[i - 1];
        }

    }
    public void CloseAuthorList()
    {
        if (GameStatus.CurrentSceneState == SceneState.title_authorInfo)
        {
            StopCoroutine("CloseAuthorListCR");
            StartCoroutine("CloseAuthorListCR");
        }
    }
    IEnumerator CloseAuthorListCR()
    {
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            authorInfoTitle.transform.localPosition = Vector3.Lerp(authorInfoTitle.transform.localPosition, authorInfoTitleStartPosition,
                Mathf.Min(1, 15 * Time.deltaTime));
            otherAuthorInfo.transform.localPosition = Vector3.Lerp(otherAuthorInfo.transform.localPosition, otherAuthorInfoStartPosition,
                Mathf.Min(1, 15 * Time.deltaTime));
            btn_closeAuthorInfo.transform.localScale = Vector3.Lerp(btn_closeAuthorInfo.transform.localScale, new Vector3(0, 0, 1),
                Mathf.Min(1, 15 * Time.deltaTime));
            for (int i = 1; i <= 3; i++)
            {
                mainAuthor[i - 1].transform.localPosition = Vector3.Lerp(mainAuthor[i - 1].transform.localPosition,
                    mainAuthorTargetPositionOut[i - 1], Mathf.Min(1, 15 * Time.deltaTime));
                mainAuthor[i - 1].transform.localRotation = Quaternion.Euler(Vector3.Lerp(mainAuthor[i - 1].transform.localRotation.eulerAngles,
                    mainAuthorTargetRotationOut[i - 1], Mathf.Min(1, 15 * Time.deltaTime)));
            }
            yield return 0;
        }
        authorInfoTitle.transform.localPosition = authorInfoTitleStartPosition;
        otherAuthorInfo.transform.localPosition = otherAuthorInfoStartPosition;
        btn_closeAuthorInfo.transform.localScale = new Vector3(0, 0, 1);
        for (int i = 1; i <= 3; i++)
        {
            mainAuthor[i - 1].transform.localPosition = mainAuthorTargetPositionOut[i - 1];
            mainAuthor[i - 1].transform.localRotation = Quaternion.Euler(mainAuthorTargetRotationOut[i - 1]);
        }
        GameStatus.CurrentSceneState = SceneState.title;
    }
    public void OpenAuthorThank()
    {
        if (GameStatus.CurrentSceneState == SceneState.title_authorInfo)
        {
            StopCoroutine("OpenAuthorThankCR");
            StartCoroutine("OpenAuthorThankCR");
        }
    }
    IEnumerator OpenAuthorThankCR()
    {
        GameStatus.CurrentSceneState = SceneState.title_thankAuthor;
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            thankAuthorPanel.transform.localScale = Vector3.Lerp(thankAuthorPanel.transform.localScale, new Vector3(1, 1, 1),
                Mathf.Min(1, 10 * Time.deltaTime));
            yield return 0;
        }
        thankAuthorPanel.transform.localScale = new Vector3(1, 1, 1);
    }
    public void CloseAuthorThank()
    {
        if (GameStatus.CurrentSceneState == SceneState.title_thankAuthor)
        {
            StopCoroutine("CloseAuthorThankCR");
            StartCoroutine("CloseAuthorThankCR");
        }
    }
    IEnumerator CloseAuthorThankCR()
    {
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            thankAuthorPanel.transform.localScale = Vector3.Lerp(thankAuthorPanel.transform.localScale, new Vector3(0, 0, 1),
                Mathf.Min(1, 10 * Time.deltaTime));
            yield return 0;
        }
        thankAuthorPanel.transform.localScale = new Vector3(0, 0, 1);
        GameStatus.CurrentSceneState = SceneState.title_authorInfo;
    }

    #region 外部链接
    public void OpenQQGroup(int id)
    {
        switch (id)
        {
            case 1:
                Application.OpenURL("https://jq.qq.com/?_wv=1027&k=5IIHHF7");
                break;
            case 2:
                Application.OpenURL("https://jq.qq.com/?_wv=1027&k=5xhTRzl");
                break;
            case 3:
                Application.OpenURL("https://jq.qq.com/?_wv=1027&k=5Q4o4R2");
                break;
            case 4:
                Application.OpenURL("https://jq.qq.com/?_wv=1027&k=5RcqG87");
                break;
            case 5:
                Application.OpenURL("https://jq.qq.com/?_wv=1027&k=51yjYB4");
                break;
            default:
                break;
        }
    }
    public void OpenWeChatThankPage()
    {
        Application.OpenURL("weixin://");
        Application.OpenURL("https://mp.weixin.qq.com/s/S7v-cFmaUfRGEKW_HJfoxQ");
    }
    public void OpenBilibiliPage(int id)
    {
        if (id == 1)
        {
            Application.OpenURL("https://space.bilibili.com/2437365");
        }
        else if (id == 2)
        {
            Application.OpenURL("https://space.bilibili.com/2050055");
        }
        else if (id == 3)
        {
            Application.OpenURL("https://space.bilibili.com/343066179");
        }
    }

    #endregion
    #endregion
    #region 历史消息和阅读相关
    public void ChangeReadMode()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing || GameStatus.CurrentSceneState == SceneState.playing_pause)
        {
            GameSlot.isManualRead = !GameSlot.isManualRead;
            btnReadModeText.text = GameSlot.ReadModeStr;
            GameSlot.playerReadRushPower = GameSlot.defaultReadSpeed;

        }
    }
    public void RushReadStory()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing || GameStatus.CurrentSceneState == SceneState.playing_story)
        {
            if (GameSlot.current_mss.sentenceType == 1)
            {
                if (GameSlot.isManualRead)
                {
                    if (GameSlot.current_mss.sentenceType == 1)
                    {
                        if (GameSlot.currentSentenceState == SentenceState.reading)
                        {
                            GameSlot.currentSentenceTime = 0f;
                        }
                        else if (GameSlot.currentSentenceState == SentenceState.wait)
                        {
                            GameSlot.currentSentenceTime = 0f;
                        }
                    }
                    else if (GameSlot.current_mss.sentenceType == 3)
                    {
                        GameSlot.playerReadRushPower = 0.05f;
                    }

                }
                else
                {
                    GameSlot.playerReadRushPower = 0.05f;
                }
            }
            else if (GameSlot.current_mss.sentenceType == 3)
            {
                GameSlot.playerReadRushPower = 0.05f;
            }
        }
    }

    public void ManualSkipInPlaying()
    {
        if (GameStatus.CurrentSceneState != SceneState.playing_pause && GameStatus.CurrentSceneState != SceneState.playing) return;
        if (GameSlot.hasCompleteStoryKnot[GameSlot.currentStoryPartLarge - 1] == 't')
        {
            if (GameSlot.MissionListCount > 0)
            {
                GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["not_now"].ToString(),
                    SentenceBank.pack.sentences["cannot_skip_in_mission"].ToString(), 0));
            }
            else
            {
                if (GameSlot.CanSave)
                {
                    if (GameSlot.current_mss.isEndSentence)
                    {
                        GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["not_now"].ToString(),
                            SentenceBank.pack.sentences["cannot_skip_in_switch"].ToString(), 0));
                    }
                    else
                    {
                        if (GameStatus.CurrentSceneState == SceneState.playing_pause)
                        {
                            GameStatus.CurrentSceneState = SceneState.playing;
                            StopCoroutine("ExitPausePlayingCR");
                            StartCoroutine("ExitPausePlayingCR");
                            TrySkipStoryMsgBox();
                        }
                        else
                        {
                            TrySkipStoryMsgBox();
                        }
                    }
                }
                else
                {
                    GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["not_now"].ToString(),
                        SentenceBank.pack.sentences["cannot_skip_in_action"].ToString(), 0));
                }
            }
        }
        else
        {
            if (GameStatus.CurrentSceneState == SceneState.playing_pause)
            {
                GameStatus.CurrentSceneState = SceneState.playing;
                StopCoroutine("ExitPausePlayingCR");
                StartCoroutine("ExitPausePlayingCR");
                TrySkipStoryMsgBox(false);
            }
            else
            {
                TrySkipStoryMsgBox(false);
            }
        }
    }
    void TrySkipStoryMsgBox(bool hasCompleteStory = true)
    {
        if (hasCompleteStory)
        {
            GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["confirm_speed_title"].ToString(),
                SentenceBank.pack.sentences["confirm_speed_sentence"].ToString(), 41));
        }
        else
        {
            GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["confirm_speed_title_uncomplete"].ToString(),
                SentenceBank.pack.sentences["confirm_speed_sentence_uncomplete"].ToString(), 41));
        }
    }
    public void ExitSpeedSkip()
    {
        Time.timeScale = 1f;
        GameSlot.isManualRead = GameSlot.preIsManualReadState;
        GameSlot.systemOrderFunctionList.Add(42);
    }

    public void ChangeSpeedInPlaying()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing_pause)
        {
            GameSlot.SwitchDefaultReadSpeed();
            defaultReadSpeedStrText.text = GameSlot.DefaultReadSpeedStr;
        }
    }

    public void OpenHistorySentenceWindow()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing || GameStatus.CurrentSceneState == SceneState.playing_pause)
        {
            StopCoroutine("OpenHistorySentenceWindowCR");
            StartCoroutine("OpenHistorySentenceWindowCR");
        }
    }
    IEnumerator OpenHistorySentenceWindowCR()
    {
        GameStatus.PreviousSceneState = GameStatus.CurrentSceneState;
        GameStatus.CurrentSceneState = SceneState.playing_historySentences;
        historySentenceParaText.text = GameSlot.HistorySentenceParagraph;
        appVersionInHistoryLayerText.text = Application.version;
        historySentencePara.GetComponent<RectTransform>().sizeDelta = new Vector2(466, historySentenceParaText.preferredHeight);
        historySentencePara.transform.localPosition = new Vector3(270 - 3 + 5, Mathf.Max(-386.4f, (historySentenceParaText.preferredHeight - 986) * 0.5f - 280), 0);

        historySentenceLayer.transform.localPosition = targetHistorySentenceWindowsPosition;
        historySentenceLayer.transform.localScale = Vector3.zero;
        for (float t = 0.5f; t >= 0; t -= Time.deltaTime)
        {
            historySentenceLayer.transform.localScale = Vector3.Lerp(historySentenceLayer.transform.localScale,
                new Vector3(1, 1, 1), Mathf.Min(1, Time.deltaTime * 10));
            historySentenceLayer.transform.localPosition = Vector3.Lerp(historySentenceLayer.transform.localPosition,
                new Vector3(0, 0, 0), Mathf.Min(1, Time.deltaTime * 10));
            yield return 0;
        }
        historySentenceLayer.transform.localPosition = Vector3.zero;
        historySentenceLayer.transform.localScale = Vector3.one;
    }
    public void CopyHistoryTextToClipBoard()
    {
        GUIUtility.systemCopyBuffer = GameSlot.HistorySentenceParagraph;
        GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["complete"].ToString(),
            SentenceBank.pack.sentences["history_copyto_clipboard"].ToString(), 0));
    }
    public void CloseHistorySentenceWindow()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing_historySentences)
        {
            StopCoroutine("CloseHistorySentenceWindowCR");
            StartCoroutine("CloseHistorySentenceWindowCR");
        }
    }
    IEnumerator CloseHistorySentenceWindowCR()
    {
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            historySentenceLayer.transform.localScale = Vector3.Lerp(historySentenceLayer.transform.localScale,
                new Vector3(0, 0, 1), Mathf.Min(1, Time.deltaTime * 10));
            historySentenceLayer.transform.localPosition = Vector3.Lerp(historySentenceLayer.transform.localPosition,
                targetHistorySentenceWindowsPosition, Mathf.Min(1, Time.deltaTime * 10));
            yield return 0;
        }
        historySentenceLayer.transform.localPosition = targetHistorySentenceWindowsPosition;
        historySentenceLayer.transform.localScale = new Vector3(0, 0, 1);

        GameStatus.CurrentSceneState = GameStatus.PreviousSceneState;
    }
    #endregion

    #endregion

    #region 深渊模式
    #region 深渊模式暂停
    public void ClickPauseBtnInAbyss()
    {
        if (GameStatus.CurrentPlayMode == PlayMode.abyss)
        {
            if (GameStatus.CurrentSceneState == SceneState.abyss_shop_buy || GameStatus.CurrentSceneState == SceneState.abyss_shop_sell)
            {
                return;
            }
            if (GameStatus.CurrentSceneState == SceneState.playing)
            {
                PausePlayingInAbyss();
            }
            else//不用else if是为了避免发生异常
            {
                ExitPausePlayingInAbyss();
            }
        }
    }
    public void PausePlayingInAbyss()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing && !GameSlot.IsMsgBoxOn)
        {
            GameStatus.CurrentSceneState = SceneState.playing_pause;
            StopCoroutine("PausePlayingInAbyssCR");
            StopCoroutine("ExitPausePlayingInAbyssCR");
            StartCoroutine("PausePlayingInAbyssCR");
        }
    }
    private void ResetAbyssPauseBtnsPosition(int type = 0)
    {
        if (type == 0)
        {
            for (int i = 2; i <= 3; i++)
            {
                btnsAbyssPause[i - 1].transform.localPosition = btnsAbyssPausePosition[0];//没错，就是移动到暂停按钮位置，伸缩动态需要
                btnsAbyssPause[i - 1].transform.localScale = Vector3.zero;
            }
            pause_abyss_back_image.color = new Color(0, 0, 0, 0);
        }
        else
        {
            for (int i = 2; i <= 3; i++)
            {
                btnsAbyssPause[i - 1].transform.localPosition = btnsAbyssPausePosition[i - 1];
                btnsAbyssPause[i - 1].transform.localScale = Vector3.one;
            }
            pause_abyss_back_image.color = new Color(1, 1, 1, 1);
        }
    }
    IEnumerator PausePlayingInAbyssCR()
    {
        ResetPauseBtnsPosition();
        pause_abyss_back_image.transform.localScale = Vector3.one;
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            pause_abyss_back_image.color = new Color(1, 1, 1, t * 2);
            for (int i = 2; i <= 3; i++)
            {
                btnsAbyssPause[i - 1].transform.localPosition = Vector3.Lerp(btnsAbyssPause[i - 1].transform.localPosition,
                    btnsAbyssPausePosition[i - 1], 0.4f);
                btnsAbyssPause[i - 1].transform.localScale = Vector3.Lerp(btnsAbyssPause[i - 1].transform.localScale, Vector3.one, 0.4f);
            }
            yield return 0;
        }
        ResetPauseBtnsPosition(1);
    }
    public void ExitPausePlayingInAbyss()
    {
        if (!GameSlot.IsMsgBoxOn)
        {
            GameStatus.CurrentSceneState = SceneState.playing;
            StopCoroutine("PausePlayingInAbyssCR");
            StopCoroutine("ExitPausePlayingInAbyssCR");
            StartCoroutine("ExitPausePlayingInAbyssCR");
        }
    }
    IEnumerator ExitPausePlayingInAbyssCR()
    {
        ResetPauseBtnsPosition(1);
        for (float t = 0.5f; t >= 0; t -= Time.deltaTime)
        {
            pause_abyss_back_image.color = new Color(1, 1, 1, t * 2);
            for (int i = 2; i <= 3; i++)
            {
                btnsAbyssPause[i - 1].transform.localPosition = Vector3.Lerp(btnsAbyssPause[i - 1].transform.localPosition,
                    btnsAbyssPausePosition[0], 0.4f);
                btnsAbyssPause[i - 1].transform.localScale = Vector3.Lerp(btnsAbyssPause[i - 1].transform.localScale, Vector3.zero, 0.4f);
            }
            yield return 0;
        }
        pause_abyss_back_image.transform.localScale = Vector3.zero;
        ResetPauseBtnsPosition();
    }
    #endregion
    #region 深渊模式选择与战斗
    public void TryEnterAbyssModeChooseList()
    {
        if (PlayerPrefs.HasKey("ProgressSlotStr_-1"))
        {
            GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["abyss_continue_title"].ToString(),
                SentenceBank.pack.sentences["abyss_continue_yes"].ToString(), 62,
                SentenceBank.pack.sentences["abyss_continue_no"].ToString(), 60));
        }
        else
        {
            EnterAbyssModeChooseList();
        }
    }
    public void EnterAbyssModeChooseList()
    {
        if (GameStatus.CurrentSceneState == SceneState.title_modeList)
        {
            GameStatus.CurrentSceneState = SceneState.abyss_transing;
            StopCoroutine("EnterAbyssModeChooseListCR");
            StartCoroutine("EnterAbyssModeChooseListCR");
        }
    }
    IEnumerator EnterAbyssModeChooseListCR()
    {
        float speedScale = 1;
        StopCoroutine("CurtainInOut");
        StartCoroutine("CurtainInOut", speedScale);
        for (float t = 0; t <= 1f; t += Time.deltaTime * speedScale)
        {
            yield return 0;
        }
        abyss_chooseList_panel.transform.localPosition = Vector3.zero;
        abyss_chooseList_panel.transform.localScale = Vector3.one;
        GameStatus.CurrentSceneState = SceneState.abyss_choose;
    }
    public void ExitAbyssModeChooseList()
    {
        if (GameStatus.CurrentSceneState == SceneState.abyss_choose)
        {
            GameStatus.CurrentSceneState = SceneState.abyss_transing;
            StopCoroutine("ExitAbyssModeChooseListCR");
            StartCoroutine("ExitAbyssModeChooseListCR");
        }
    }
    IEnumerator ExitAbyssModeChooseListCR()
    {
        btn_otherModeList.transform.localPosition = catShowPosition;
        panel_otherModeList.transform.localPosition = otherModePanelHidePosition;

        float speedScale = 1;
        StopCoroutine("CurtainInOut");
        StartCoroutine("CurtainInOut", speedScale);
        for (float t = 0; t <= 1f; t += Time.deltaTime * speedScale)
        {
            yield return 0;
        }
        abyss_chooseList_panel.transform.localScale = Vector3.zero;
        GameStatus.CurrentSceneState = SceneState.title;
    }
    void ContinueAbyssGame()
    {
        GameSlot.InitData();
        GameSlot.LoadSingleSlot(-1);
        if (GameSlot.dataBag.monsterWaitCD > 0)
        {
            LoadNextMonsterForPreview();
        }
        else
        {

        }
        try
        {
            heroBodyImage.color = Color.white;
            enemyBodyImage.color = new Color(1, 1, 1, 0);
            UpdateAbyssBGMAndScene(true);
            UpdateAbyssBasicValue();
        }
        catch
        {
            GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["error"].ToString(),
                SentenceBank.pack.sentences["abyss_continue_wrong"].ToString(), 60, true));
        }
        StopCoroutine("StartNewAbyssGameCR");
        StartCoroutine("StartNewAbyssGameCR");
    }
    void LoadNextMonsterForPreview()
    {
        int mId = GameSlot.dataBag.currentMonsterId;
        GameSlot.dataBag.nextMonster = new DataAbyssHero(GameSlot.dataBag.CurrentAbyssStage.monsterList[mId - 1],
            GameSlot.dataBag.CurrentAbyssStage.lvList[mId - 1], 1);
    }
    public void StartNewAbyssGame(int restrictLv = 0)
    {
        if (GameStatus.CurrentSceneState == SceneState.abyss_choose || GameStatus.CurrentSceneState == SceneState.abyss_hero_choosed)
        {
            GameSlot.InitData();
            if (restrictLv == 0)
            {
                if (COAbyss.IsRestrictLevel)
                {
                    GameSlot.dataBag.LoadAbyssHeroSlot(COAbyss.restrictLevel);
                }
                else
                {
                    GameSlot.dataBag.LoadAbyssHeroSlot(restrictLv);
                }
            }
            else
            {
                GameSlot.dataBag.LoadAbyssHeroSlot(restrictLv);
            }
            StopCoroutine("CloseHeroChoosedInAbyssCR");
            StartCoroutine("CloseHeroChoosedInAbyssCR");
            LoadNextMonsterForPreview();
            heroBodyImage.color = Color.white;
            enemyBodyImage.color = new Color(1, 1, 1, 0);
            UpdateAbyssBasicValue();
            UpdateAbyssBGMAndScene(true);
            GameSlot.dataBag.currentAbyssRoundTime = 0f;
            StopCoroutine("StartNewAbyssGameCR");
            StartCoroutine("StartNewAbyssGameCR");
        }
    }
    IEnumerator CloseHeroChoosedInAbyssCR()
    {
        heroChoosedPanelInAbyss.transform.localScale = Vector3.one;
        for (float t = 0; t <= 0.6f; t += Time.deltaTime)
        {
            heroChoosedPanelInAbyss.transform.localScale = Vector3.Lerp(heroChoosedPanelInAbyss.transform.localScale, Vector3.zero,
                Mathf.Min(1, 15 * Time.deltaTime));
            yield return 0;
        }
        heroChoosedPanelInAbyss.transform.localScale = Vector3.zero;
    }
    IEnumerator StartNewAbyssGameCR()
    {
        GameStatus.CurrentPlayMode = PlayMode.abyss;
        ResetPlayingUIUnits();
        for (float t = 0; t <= 1; t += Time.deltaTime)
        {
            yield return 0;
        }
        playing.transform.localPosition = new Vector3(0, 0, 0);
        playing.transform.localScale = new Vector3(1, 1, 1);


        bagCellBoardCanvas.UpdateItemCell();
        UpdateCurrentBagValue();
        GameSlot.systemOrderFunctionList.Add(65);
        GameSlot.isSystemOrderFunctionOn = false;
        GameStatus.canControl = true;
        GameStatus.CurrentSceneState = SceneState.playing;

    }
    IEnumerator AbyssChangeSceneCR()
    {
        for (float t = 0; t <= 1; t += Time.deltaTime)
        {
            yield return 0;
        }
        GameSound.NewMusicPage(GameSlot.dataBag.BGMId);
        abyss_stageName_text.text = SentenceBank.pack.sentences["abyss_stage_id"].ToString().Replace("n",
            GameSlot.dataBag.currentAbyssStageId.ToString())
            + "\n" + GameSlot.dataBag.CurrentAbyssStage.name;

        int scenePicId = GameSlot.dataBag.ScenePicId;
        abyssSceneBackPicImage.sprite = Sprite.Create(abyssScenePrefab[scenePicId - 1], new Rect(0, 0, 540, 960), new Vector2(0.5f, 0.5f));
        abyss_stageName.transform.localPosition = GameSlot.dataBag.CurrentAbyssStage.stageNamePosition;
        abyss_stageName_text.color = GameSlot.dataBag.CurrentAbyssStage.stageNameFontColor;
        abyss_roundTime_hint_text.color = GameSlot.dataBag.CurrentAbyssStage.timeHintFontColor;
        Debug.Log("scenePicId = " + scenePicId);
    }
    void UpdateAbyssBGMAndScene(bool picRefresh = false)
    {
        if (picRefresh)
        {
            StopCoroutine("CurtainInOut");
            StartCoroutine("CurtainInOut", 1);
            StopCoroutine("AbyssChangeSceneCR");
            StartCoroutine("AbyssChangeSceneCR");
            Debug.Log("change all");
        }
        else
        {
            GameSound.NewMusicPage(GameSlot.dataBag.BGMId);
            abyss_stageName_text.text = SentenceBank.pack.sentences["abyss_stage_id"].ToString().Replace("n",
                GameSlot.dataBag.currentAbyssStageId.ToString())
                + "\n" + GameSlot.dataBag.CurrentAbyssStage.name;
            Debug.Log("only change stage");
        }
    }
    void AbyssNextStage()
    {
        //这里判定传送符文和回归符文是否生效
        //优先级是先判断向上的，再判断向下的
        int preScenePicId = MapDataLib.abyss.stageList[GameSlot.dataBag.currentAbyssStageId - 1].scenePicId;
        int tryPortResult = GameSlot.dataBag.TryPort();
        GameSlot.dataBag.currentAbyssStageId += 1 + tryPortResult;
        if (GameSlot.dataBag.currentAbyssStageId < 1)
        {
            GameSlot.dataBag.currentAbyssStageId = 1;
        }
        GameSlot.currentAbyssRoundResultTime = GameSlot.dataBag.currentAbyssRoundTime;
        if (GameSlot.dataBag.currentAbyssStageId > MapDataLib.abyss.stageList.Count)
        {
            GameSlot.dataBag.currentAbyssStageId = MapDataLib.abyss.stageList.Count + 1;
            string winStr = SentenceBank.pack.sentences["abyss_current_time"].ToString().Replace("t",
                MyStrFunc.GetRecordTimeByFloat(GameSlot.currentAbyssRoundResultTime)).Replace("n",
                (GameSlot.dataBag.currentAbyssStageId - 1).ToString());
            GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["abyss_beat_all"].ToString(),
                winStr, 53, true));
        }
        else
        {
            int newScenePicId = MapDataLib.abyss.stageList[GameSlot.dataBag.currentAbyssStageId - 1].scenePicId;
            if (newScenePicId != preScenePicId)
            {
                UpdateAbyssBGMAndScene(true);
            }
            else
            {
                UpdateAbyssBGMAndScene();
            }
            GameSlot.dataBag.currentMonsterId = 1;
            GameSlot.dataBag.monsterWaitCD = GameSlot.dataBag.CurrentAbyssStage.waitSecondsList[0] + GameSlot.dataBag.TotalAddWaitTime;
            GameSlot.dataBag.FadeHideScroll();
            #region 自动存档
            GameSlot.SaveSlot(-1);
            #endregion
            LoadNextMonsterForPreview();
            UpdateAbyssBasicValue();
        }
    }
    void LoadNewMonsterInAbyss()
    {
        int mId = GameSlot.dataBag.currentMonsterId;
        GameSlot.dataBag.monster = new DataAbyssHero(GameSlot.dataBag.CurrentAbyssStage.monsterList[mId - 1],
            GameSlot.dataBag.CurrentAbyssStage.lvList[mId - 1], 1);
        heroBodyImage.color = Color.white;
        enemyBodyImage.color = Color.white;
        UpdateAbyssBasicValue();
    }
    void AbyssNextMonster()
    {
        LoadNewMonsterInAbyss();
    }
    void GetResultAndExitAbyss()
    {
        GameSlot.CheckNewRecord();
        int totalExp = GameSlot.dataBag.currentExpGot;
        GameSlot.AddAbyssHeroExp(GameSlot.dataBag.hero.id, totalExp);
        abyss_chooseList_panel.transform.localScale = Vector3.one;
        UpdateAbyssRankinglistTexts();
        PlayerPrefs.DeleteKey("ProgressSlotStr_-1");
        StartCoroutine("CloseInfoPanelCR");
        StartCoroutine("FromPlayingToAbyssRankinglist");
        StartCoroutine("OpenAbyssRankingListCR");
        btn_otherModeList.transform.localPosition = catShowPosition;
        panel_otherModeList.transform.localPosition = otherModePanelHidePosition;
        GameStatus.CurrentSceneState = SceneState.abyss_ranking_list;
    }
    public void TryGiveUpAndExitAbyss()
    {
        GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["abyss_give_up_title"].ToString(),
            SentenceBank.pack.sentences["abyss_give_up_pause"].ToString(), 54,
            SentenceBank.pack.sentences["abyss_give_up_give_up"].ToString() + "(" + GameSlot.dataBag.currentExpGot + ")", 59));
    }
    void GiveUpAndExitAbyss()
    {
        int totalExp = GameSlot.dataBag.currentExpGot;
        GameSlot.AddAbyssHeroExp(GameSlot.dataBag.hero.id, totalExp);
        abyss_chooseList_panel.transform.localScale = Vector3.one;
        UpdateAbyssRankinglistTexts();
        StopCoroutine("PausePlayingInAbyssCR");
        StopCoroutine("ExitPausePlayingInAbyssCR");
        StartCoroutine("ExitPausePlayingInAbyssCR");
        PlayerPrefs.DeleteKey("ProgressSlotStr_-1");
        StartCoroutine("CloseInfoPanelCR");
        StartCoroutine("FromPlayingToAbyssRankinglist");
        StartCoroutine("OpenAbyssRankingListCR");
        btn_otherModeList.transform.localPosition = catShowPosition;
        panel_otherModeList.transform.localPosition = otherModePanelHidePosition;
        GameStatus.CurrentSceneState = SceneState.abyss_ranking_list;
    }
    IEnumerator FromPlayingToAbyssRankinglist()
    {
        StopCoroutine("CurtainInOut");
        StartCoroutine("CurtainInOut", 2);
        for (float t = 0; t <= 1; t += Time.deltaTime * 2)
        {
            yield return 0;
        }
        playing.transform.localScale = Vector3.zero;
        GameSound.NewMusicPage(1);
        GameSlot.isSystemOrderFunctionOn = false;
    }
    void UpdateAbyssRankinglistTexts()
    {
        abyss_rankinglist_order_list_text.text = GameSlot.AbyssRankingOrderListStr;
        abyss_rankinglist_name_list_text.text = GameSlot.AbyssRankingNameListStr;
        abyss_rankinglist_stage_list_text.text = GameSlot.AbyssRankingStageListStr;
        abyss_rankinglist_time_list_text.text = GameSlot.AbyssRankingTimeListStr;
    }
    public void OpenAbyssRankingList()
    {
        if (GameStatus.CurrentSceneState == SceneState.abyss_choose)
        {
            UpdateAbyssRankinglistTexts();
            GameStatus.CurrentSceneState = SceneState.abyss_ranking_list;
            StopCoroutine("OpenAbyssRankingListCR");
            StartCoroutine("OpenAbyssRankingListCR");
        }
    }
    IEnumerator OpenAbyssRankingListCR()
    {
        abyss_rankinglist_panel.transform.localScale = Vector3.zero;
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            abyss_rankinglist_panel.transform.localScale = Vector3.Lerp(abyss_rankinglist_panel.transform.localScale, Vector3.one,
                Mathf.Min(1, 15 * Time.deltaTime));
            yield return 0;
        }
        abyss_rankinglist_panel.transform.localScale = Vector3.one;
    }
    public void CloseAbyssRankingList()
    {
        if (GameStatus.CurrentSceneState == SceneState.abyss_ranking_list)
        {
            GameStatus.CurrentSceneState = SceneState.abyss_choose;
            abyss_chooseList_panel.transform.localPosition = Vector3.zero;
            abyss_chooseList_panel.transform.localScale = Vector3.one;
            StopCoroutine("CloseAbyssRankingListCR");
            StartCoroutine("CloseAbyssRankingListCR");
        }
    }
    IEnumerator CloseAbyssRankingListCR()
    {
        abyss_rankinglist_panel.transform.localScale = Vector3.one;
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            abyss_rankinglist_panel.transform.localScale = Vector3.Lerp(abyss_rankinglist_panel.transform.localScale, Vector3.zero,
                Mathf.Min(1, 15 * Time.deltaTime));
            yield return 0;
        }
        abyss_rankinglist_panel.transform.localScale = Vector3.zero;
    }
    void PauseAbyssAndReturnTitle()
    {
        if (GameSlot.dataBag.monsterWaitCD > 0.1f)
        {
            GameSlot.SaveSlot(-1);
        }
        StopCoroutine("PausePlayingInAbyssCR");
        StopCoroutine("ExitPausePlayingInAbyssCR");
        StartCoroutine("ExitPausePlayingInAbyssCR");
        StartCoroutine("CloseInfoPanelCR");
        abyss_chooseList_panel.transform.localScale = Vector3.zero;
        abyss_rankinglist_panel.transform.localScale = Vector3.zero;
        btn_otherModeList.transform.localPosition = catShowPosition;
        panel_otherModeList.transform.localPosition = otherModePanelHidePosition;
        StopCoroutine("FromPlayingToTitleIn");
        StartCoroutine("FromPlayingToTitleIn");
    }
    public void AbyssSkipWaitMonster()
    {
        GameSlot.dataBag.monsterWaitCD = 0.1f;
    }
    #endregion
    #region 深渊模式drop and steal
    public void AbyssStealEnemy()
    {
        if (GameSlot.dataBag.monsterWaitCD <= 0)
        {
            Debug.Log(GameSlot.dataBag.monster.HasListStr);
            if (GameSlot.dataBag.monster.hasBeenStolen)
            {
                GameStatus.superTextBulletList.Add(new SuperTextBullet(
                    SentenceBank.pack.sentences["abyss_steal_has_steal"].ToString()
                    , 39, new Color(0.7f, 0.2f, 0.2f), new Vector3(0, -100, 0)));
            }
            else if (GameSlot.dataBag.item.Count == 16)
            {
                string str = SentenceBank.pack.sentences["bag_has_full"].ToString();
                GameStatus.superTextBulletList.Add(new SuperTextBullet(str, 39, new Color(0.7f, 0.2f, 0.2f), new Vector3(0, -100, 0)));
            }
            else
            {
                List<DataItem> dropList = GameSlot.dataBag.monster.GetDropList(DropItemType.steal);
                GameSlot.dataBag.FadeStealScroll();
                if (dropList.Count == 0)
                {
                    GameStatus.superTextBulletList.Add(new SuperTextBullet(
                        SentenceBank.pack.sentences["abyss_steal_fail"].ToString()
                        , 39, new Color(0.7f, 0.2f, 0.2f), new Vector3(0, -100, 0)));
                }
                else
                {
                    GameSlot.dataBag.AddNewItem(dropList[0].id, dropList[0].lv, dropList[0].exp);
                    GameStatus.superTextBulletList.Add(new SuperTextBullet(
                        SentenceBank.pack.sentences["abyss_steal_success"].ToString().Replace("n", dropList[0].Name)
                        , 39, new Color(0.7f, 0.2f, 0.2f), new Vector3(0, -100, 0)));
                }
            }
        }
    }
    void AbyssDropItem()
    {
        List<DataItem> dropList = GameSlot.dataBag.monster.GetDropList(DropItemType.drop);
        GameSlot.dataBag.FadeDropScroll();
        if (dropList.Count == 0)
        {
        }
        else
        {
            for (int i = 1; i <= dropList.Count; i++)
            {
                if (GameSlot.dataBag.item.Count == 16)
                {
                    string str = SentenceBank.pack.sentences["bag_has_full"].ToString();
                    GameStatus.superTextBulletList.Add(new SuperTextBullet(str, 39, new Color(0.7f, 0.2f, 0.2f), new Vector3(0, -100, 0)));
                }
                else
                {
                    GameSlot.dataBag.AddNewItem(dropList[i - 1].id, dropList[i - 1].lv, dropList[i - 1].exp);
                    GameStatus.superTextBulletList.Add(new SuperTextBullet(
                        SentenceBank.pack.sentences["abyss_drop_success"].ToString().Replace("n", dropList[i - 1].Name)
                        , 39, new Color(0.7f, 0.2f, 0.2f), new Vector3(0, 0 - 50 * i, 0)));
                }
            }
        }
    }
    #endregion
    #region 深渊模式装备和设置
    public void AbyssUnequipEquipment(int pId)
    {
        if (GameSlot.dataBag.hero.ExistEquip(pId))
        {
            if (GameSlot.dataBag.item.Count < 16)
            {
                int itemPId = GameSlot.dataBag.GetFirstEmptyPosition();
                int itemId = GameSlot.dataBag.hero.equip[pId - 1].id;
                string name = GameSlot.dataBag.hero.equip[pId - 1].Name;
                CreateItem(itemId, itemPId, GameSlot.dataBag.hero.equip[pId - 1].lv, GameSlot.dataBag.hero.equip[pId - 1].exp);
                GameSlot.dataBag.hero.DeleteEquip(pId);
                GameSlot.abyss_hero_equip_alert = -1;

                UpdateAbyssBasicValue();
                UpdateAbyssHeroInfoPanelText();
                GameStatus.superTextBulletList.Add(new SuperTextBullet(
                    SentenceBank.pack.sentences["abyss_equip_take_down"].ToString().Replace("n", name)
                                , 39, new Color(0.7f, 0.2f, 0.2f), new Vector3(0, -100, 0)));
                if (GameSlot.dataBag.hero.hp > GameSlot.dataBag.hero.HPMaxWithEquipment)
                { GameSlot.dataBag.hero.hp = GameSlot.dataBag.hero.HPMaxWithEquipment; }
            }
            else
            {
                GameStatus.superTextBulletList.Add(new SuperTextBullet(SentenceBank.pack.sentences["bag_has_full"].ToString()
                                , 39, new Color(0.7f, 0.2f, 0.2f), new Vector3(0, -100, 0)));
            }
        }
    }
    public void AbyssOpenHeroInfoPanel()
    {
        if (GameStatus.CurrentSceneState == SceneState.playing && GameStatus.CurrentPlayMode == PlayMode.abyss)
        {
            UpdateAbyssHeroInfoPanelText();
            StopCoroutine("AbyssOpenHeroInfoPanelCR");
            StartCoroutine("AbyssOpenHeroInfoPanelCR");
        }
    }
    void UpdateAbyssHeroInfoPanelText()
    {
        for (int i = 1; i <= 5; i++)
        {
            if (GameSlot.dataBag.hero.ExistEquip(i))
            {
                abyss_takeDownEquip_btns[i - 1].transform.localScale = Vector3.one;
                abyss_equip_exp_bar[i - 1].transform.localScale = new Vector3(GameSlot.dataBag.hero.equip[i - 1].ExpPct, 1, 1);
            }
            else
            {
                abyss_takeDownEquip_btns[i - 1].transform.localScale = Vector3.zero;
                abyss_equip_exp_bar[i - 1].transform.localScale = Vector3.zero;
            }
        }
        abyss_hero_name_text.text = GameSlot.dataBag.hero.NameWithLv;
        abyss_hero_weapon_info_text.text = GameSlot.dataBag.hero.EquipmentNameWithLv(1);
        abyss_hero_head_info_text.text = GameSlot.dataBag.hero.EquipmentNameWithLv(2);
        abyss_hero_body_info_text.text = GameSlot.dataBag.hero.EquipmentNameWithLv(3);
        abyss_hero_leg_info_text.text = GameSlot.dataBag.hero.EquipmentNameWithLv(4);
        abyss_hero_foot_info_text.text = GameSlot.dataBag.hero.EquipmentNameWithLv(5);
        UpdateAbyssSettingText();
    }
    void UpdateAbyssSettingText()
    {
        abyss_hero_set_eat_alert_text.text = GameSlot.Abyss_hero_eat_alert_str;
        abyss_hero_set_equip_alert_text.text = GameSlot.Abyss_hero_equip_alert_str;
        abyss_hero_set_vibration_text.text = GameSlot.IsVibrationOn_str;
    }
    IEnumerator AbyssOpenHeroInfoPanelCR()
    {
        GameStatus.CurrentSceneState = SceneState.abyss_hero_info_check;
        abyss_hero_info_panel.transform.localScale = Vector3.zero;
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            abyss_hero_info_panel.transform.localScale = Vector3.Lerp(abyss_hero_info_panel.transform.localScale,
                Vector3.one, Mathf.Min(1, 15 * Time.deltaTime));
            yield return 0;
        }
        abyss_hero_info_panel.transform.localScale = Vector3.one;
    }
    public void AbyssCloseHeroInfoPanel()
    {
        StopCoroutine("AbyssCloseHeroInfoPanelCR");
        StartCoroutine("AbyssCloseHeroInfoPanelCR");
    }
    IEnumerator AbyssCloseHeroInfoPanelCR()
    {
        abyss_hero_info_panel.transform.localScale = Vector3.one;
        for (float t = 0; t <= 0.5f; t += Time.deltaTime)
        {
            abyss_hero_info_panel.transform.localScale = Vector3.Lerp(abyss_hero_info_panel.transform.localScale,
                Vector3.zero, Mathf.Min(1, 15 * Time.deltaTime));
            yield return 0;
        }
        abyss_hero_info_panel.transform.localScale = Vector3.zero;
        GameStatus.CurrentSceneState = SceneState.playing;
    }
    public void AddHeroSettingEatAlert(int delta)
    {
        GameSlot.abyss_hero_eat_alert += delta;
        if (GameSlot.abyss_hero_eat_alert < 0)
        {
            GameSlot.abyss_hero_eat_alert = 0;
        }
        else if (GameSlot.abyss_hero_eat_alert > 100)
        {
            GameSlot.abyss_hero_eat_alert = 100;
        }
        GameSlot.SaveSetting();
        UpdateAbyssSettingText();
    }
    public void AddHeroSettingEquipAlert(int delta)
    {
        GameSlot.abyss_hero_equip_alert += delta;
        if (GameSlot.abyss_hero_equip_alert < -1)
        {
            GameSlot.abyss_hero_equip_alert = -1;
        }
        else if (GameSlot.abyss_hero_equip_alert > GameSlot.dataBag.MaxLevel * 10)
        {
            GameSlot.abyss_hero_equip_alert = GameSlot.dataBag.MaxLevel * 10;
        }
        GameSlot.SaveSetting();
        UpdateAbyssSettingText();
    }
    public void ChangeHeroSettingVibration()
    {
        GameSlot.isVibrationOn = !GameSlot.isVibrationOn;
        GameSlot.SaveSetting();
        UpdateAbyssSettingText();
    }
    #endregion
    #region 深渊商店
    public void TryPayToRefreshShopItems()
    {
        if (GameStatus.CurrentSceneState == SceneState.abyss_shop_buy)
        {
            if (GameSlot.dataBag.money >= GameSlot.dataBag.ShopRefreshPrice)
            {
                GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["abyss_pay_refresh_shop_title"].ToString(),
                    SentenceBank.pack.sentences["abyss_pay_refresh_shop_desc"].ToString().Replace("$n",
                    GameSlot.dataBag.ShopRefreshPrice.ToString()), 64));
            }
            else
            {
                GameSlot.newMsgBoxList.Add(new MsgBox("……", SentenceBank.pack.sentences["abyss_not_enough_money2"].ToString(), 0));
            }
        }
    }
    void PayToRefreshShopItems()
    {
        GameSlot.dataBag.money -= GameSlot.dataBag.ShopRefreshPrice;
        GameSlot.dataBag.shopRefreshTimes += 1;
        RefreshShopItems();
    }
    void RefreshShopItems()
    {
        GameSlot.GenerateShopItem();
        UpdateShopItemInfo();
        shopBoardPanelCanvas.UpdateItemCell();
    }
    void AbyssOpenShop()
    {
        GameSlot.newMsgBoxList.Add(new MsgBox("！！！", SentenceBank.pack.sentences["abyss_meet_shop"].ToString(), 0));
        GameSlot.dataBag.shopRefreshTimes = 0;
        SwitchShopMode(1);
        RefreshShopItems();
        GameStatus.CurrentSceneState = SceneState.abyss_shop_buy;
        shopBoardPanel.transform.localScale = Vector3.one;
        StopCoroutine("AbyssOpenShopCR");
        StartCoroutine("AbyssOpenShopCR");
    }
    IEnumerator AbyssOpenShopCR()
    {
        shopTotalPanel.transform.localScale = Vector3.zero;
        for (float t = 0; t <= 0.6f; t += Time.deltaTime)
        {
            shopTotalPanel.transform.localScale = Vector3.Lerp(shopTotalPanel.transform.localScale, Vector3.one, Mathf.Min(1, 15 * Time.deltaTime));
            yield return 0;
        }
        shopTotalPanel.transform.localScale = Vector3.one;
    }
    public void AbyssCloseShop()
    {
        StopCoroutine("AbyssCloseShopCR");
        StartCoroutine("AbyssCloseShopCR");
        GameStatus.CurrentSceneState = SceneState.playing;
        AbyssNextStage();
    }
    IEnumerator AbyssCloseShopCR()
    {
        shopTotalPanel.transform.localScale = Vector3.one;
        for (float t = 0; t <= 0.6f; t += Time.deltaTime)
        {
            shopTotalPanel.transform.localScale = Vector3.Lerp(shopTotalPanel.transform.localScale, Vector3.zero, Mathf.Min(1, 15 * Time.deltaTime));
            yield return 0;
        }
        shopTotalPanel.transform.localScale = Vector3.zero;
    }
    public void ClickYesInShop()
    {
        if (GameStatus.CurrentSceneState == SceneState.abyss_shop_buy)
        {
            if (GameSlot.shop.CurrentChoosedOrderId > 0)
            {
                int result = GameSlot.TryBuyItem(GameSlot.shop.currentChoosedPositionId);
                UpdateShopItemInfo();
                if (result > 0)
                {
                    shopBoardPanelCanvas.UpdateItemCell();
                    bagCellBoardCanvas.UpdateItemCell();
                }
            }
        }
        else
        {
            if (GameSlot.dataBag.CurrentChoosedOrderId > 0)
            {
                int result = GameSlot.TrySellItem(GameSlot.dataBag.currentChoosedPositionId);
                UpdateShopItemInfo();
                if (result > 0)
                {
                    shopBoardPanelCanvas.UpdateItemCell();
                    bagCellBoardCanvas.UpdateItemCell();
                }
            }
        }
    }
    void UpdateShopItemInfo()
    {
        if (GameStatus.CurrentSceneState == SceneState.abyss_shop_buy)
        {
            Debug.Log("GameSlot.shop.CurrentChoosedOrderId = " + GameSlot.shop.CurrentChoosedOrderId);
            if (GameSlot.shop.CurrentChoosedOrderId > 0)
            {
                shopItemNameStrText.text = GameSlot.shop.CurrentItem.NameWithLv;
                shopItemPriceStrText.text = GameSlot.shop.CurrentItem.Price.ToString();
                shopItemDescStrText.text = GameSlot.shop.CurrentItem.Desc;
                shopItemConfirmStrText.text = SentenceBank.pack.sentences["abyss_confirm_buy"].ToString();
            }
            else
            {
                ClearShopItemInfo();
            }
        }
        else
        {
            if (GameSlot.dataBag.CurrentChoosedOrderId > 0)
            {
                shopItemNameStrText.text = GameSlot.dataBag.CurrentItem.NameWithLv;
                shopItemPriceStrText.text = GameSlot.dataBag.CurrentItem.SellPrice.ToString();
                shopItemDescStrText.text = GameSlot.dataBag.CurrentItem.Desc;
                shopItemConfirmStrText.text = SentenceBank.pack.sentences["abyss_confirm_sell"].ToString();
            }
            else
            {
                ClearShopItemInfo();
            }
        }
        UpdateAbyssMoneyText();
    }
    void UpdateAbyssMoneyText()
    {
        shopMoneyStrText.text = GameSlot.dataBag.money.ToString();
    }
    void ClearShopItemInfo()
    {
        shopItemNameStrText.text = "";
        shopItemDescStrText.text = "";
        shopItemConfirmStrText.text = "";
    }
    #endregion
    #endregion

    #region 问卷调查
    void StartSurvey()
    {
        GameStatus.CurrentSceneState = SceneState.survey;
        GameSound.NewMusicPage(0);
        StopCoroutine("StartSurveyCR");
        StartCoroutine("StartSurveyCR");
        MapDataLib.survey.currentPage = 1;
        UpdateSurveyChoiceTexts();
    }
    IEnumerator StartSurveyCR()
    {
        surveyLayer.transform.localScale = Vector3.zero;
        for (float t = 0; t <= 0.6f; t += Time.deltaTime)
        {
            surveyLayer.transform.localScale = Vector3.Lerp(surveyLayer.transform.localScale, Vector3.one, Mathf.Min(1, 15 * Time.deltaTime));
            yield return 0;
        }
        surveyLayer.transform.localScale = Vector3.one;
    }
    public void MakeSurveyChoice(int position)
    {
        MapDataLib.survey.CurrentQuestion.Choose(position);
        UpdateSurveyChoiceTexts();
    }
    void UpdateSurveyChoiceTexts()
    {
        MapDataLib.survey.Output();
        Debug.Log(MapDataLib.survey.CurrentQuestion.OutputStr);
        surveyQuestionText.text = MapDataLib.survey.CurrentQuestion.title;
        for (int i = 1; i <= 9; i++)
        {
            if (i <= MapDataLib.survey.CurrentQuestion.chooseList.Count)
            {
                surveyChoiceBtn[i - 1].transform.localScale = Vector3.one;
                surveyChoiceStrText[i - 1].text = MapDataLib.survey.CurrentQuestion.chooseList[i - 1];
                try
                {
                    if (MapDataLib.survey.CurrentQuestion.chooseState[i - 1] == 1)
                    {
                        surveyChoiceMark[i - 1].transform.localScale = Vector3.one;
                    }
                    else
                    {
                        surveyChoiceMark[i - 1].transform.localScale = Vector3.zero;
                    }
                }
                catch
                {
                    Debug.Log("error i = " + i + ",error chooseState.count = " + MapDataLib.survey.CurrentQuestion.chooseState.Count);
                }
            }
            else
            {
                surveyChoiceBtn[i - 1].transform.localScale = Vector3.zero;
                surveyChoiceMark[i - 1].transform.localScale = Vector3.zero;
            }
        }
        surveyPageIdText.text = MapDataLib.survey.CurrentPageStr;
        if (MapDataLib.survey.IsFirstPage)
        {
            surveyBtnPre.transform.localScale = Vector3.zero;
            surveyBtnNext.transform.localScale = Vector3.one;
            surveyBtnComplete.transform.localScale = Vector3.zero;
        }
        else if (MapDataLib.survey.IsLastPage)
        {
            surveyBtnPre.transform.localScale = Vector3.one;
            surveyBtnNext.transform.localScale = Vector3.zero;
            surveyBtnComplete.transform.localScale = Vector3.one;
        }
        else
        {
            surveyBtnPre.transform.localScale = Vector3.one;
            surveyBtnNext.transform.localScale = Vector3.one;
            surveyBtnComplete.transform.localScale = Vector3.zero;
        }
    }
    public void ChangeSurveyPage(int delta)
    {
        MapDataLib.survey.SaveSurveyData();
        MapDataLib.survey.currentPage += delta;
        if (MapDataLib.survey.currentPage < 1)
        {
            MapDataLib.survey.currentPage = 1;
        }
        else if (MapDataLib.survey.currentPage > MapDataLib.survey.questions.Count)
        {
            MapDataLib.survey.currentPage = MapDataLib.survey.questions.Count;
        }
        UpdateSurveyChoiceTexts();
    }
    public void TryCompleteSurvey()
    {
        if (MapDataLib.survey.HasAllChoosed)
        {
            CompleteSurvey();
        }
        else
        {
            GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["error"].ToString(),
                SentenceBank.pack.sentences["abyss_survey_uncomplete_error"].ToString(), 0));
        }
    }
    void CompleteSurvey()
    {
        GameStatus.CurrentSceneState = SceneState.abyss_choose;
        MapDataLib.survey.SaveSurveyData();

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            GameSlot.newMsgBoxList.Add(new MsgBox(SentenceBank.pack.sentences["error"].ToString(),
                SentenceBank.pack.sentences["abyss_survey_upload_wrong"].ToString(), 0));
        }
        else
        {
            GameSlot.UploadSurvey();
        }
        StopCoroutine("EndSurveyCR");
        StartCoroutine("EndSurveyCR");
    }
    IEnumerator EndSurveyCR()
    {
        surveyLayer.transform.localScale = Vector3.one;
        for (float t = 0; t <= 0.6f; t += Time.deltaTime)
        {
            surveyLayer.transform.localScale = Vector3.Lerp(surveyLayer.transform.localScale, Vector3.zero, Mathf.Min(1, 15 * Time.deltaTime));
            yield return 0;
        }
        surveyLayer.transform.localScale = Vector3.zero;
    }
    #endregion
}