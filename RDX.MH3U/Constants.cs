namespace RDX.MH3U;

public class Constants
{
    public const long FileSaveSize = 35328;

    public const int GenderOffset = 0x0004;
    public const int GenderLength = 1;

    public const int NameOffset = 0x0007;
    public const int NameLength = 10;

    public const int MoneyOffset = 0x0024;
    public const int MoneyLength = 4;

    public const int PointsOffset = 0x5b2c;
    public const int PointsLength = 4;

    public const int ItemsItemStartPos = 0;
    public const int ItemsQuantityStartPos = 2;
    public const int ItemFullLength = 4;            // ogni oggetto occupa 4 Byte, 32 Bit, ossia 2^32 possibili oggetti
    public const int ItemIdentifierLength = 2;      // 2 byte per il codice (due byte vengono rappresentati come 4 bit + 4 bit (256 possibili combin.) | 4 bit + 4 bit)
    public const int ItemQuantityLength = 2;        // e 2 byte per la quantità

    public const int ItemsPouchOffset = 0x010c;
    public const int ItemsPouchLength = 128;
    public const int InventoryOffset = 0x00ac;
    public const int InventoryLength = 96;          // 96 Byte, ogni item ne occupa 4, quindi 24 slot totali
    public const int ItemsBoxOffset = 0x018c;
    public const int ItemsBoxLength = 4000;

    public const int EquipmentBoxOffset = 0x112c;
    public const int EquipmentBoxLength = 16000;
    public const int EquipmentLength = 16;

    public const int EquipmentCategoryPosition = 0;
    public const int EquipmentIdentifierStartPosition = 2;
    public const int EquipmentValuePosition_1 = 2;
    public const int EquipmentValuePosition_2 = 3;
    public const int UpgradeLevelPosition = 1;
    public const int UpgradeLevelLength = 1;
    public const int EquipmentIdentifierLength = 2;
    public const int DecoStartPosition_1 = 8;
    public const int DecoStartPosition_2 = 10;
    public const int DecoStartPosition_3 = 12;
    public const int DecoEndPosition_3 = 14;
    public const int CharmValuePosition = 2;
    public const int CharmValueLength = 1;
    public const int CharmSlotsCountPosition = 1;
    public const int CharmSkillPosition_1 = 4;
    public const int CharmSkillPointsPosition_1 = 5;
    public const int CharmSkillPosition_2 = 6;
    public const int CharmSkillPointsPosition_2 = 7;
    public const int CharmSkillLength = 1;
}
