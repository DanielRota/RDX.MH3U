using RDX.MH3U.Extensions;
using RDX.MH3U.Hex;

namespace RDX.MH3U.FileSave.Models;

public class CharmEquipmentItem : EquipmentItemBase
{
    private const int SkillPointsLimit = 128;

    public CharmEquipmentItem(HexValueCategory category, byte[] buffer)
        : base(category, buffer) => ParseBuffer(category, buffer);

    public HexValue Skill_1 { get; set; }
    public HexValue Skill_2 { get; set; }

    public int _skillPoints_1 { get; set; }
    public int SkillPoints_1
    {
        get => _skillPoints_1;
        set
        {
            if (value < -SkillPointsLimit || value > SkillPointsLimit)
            {
                throw new ArgumentOutOfRangeException(
                    $"Skill points can only range between -{SkillPointsLimit} and {SkillPointsLimit}.");
            }

            _skillPoints_1 = value;
        }
    }

    public int _skillPoints_2 { get; set; }
    public int SkillPoints_2
    {
        get => _skillPoints_2;
        set
        {
            if (value < -SkillPointsLimit || value > SkillPointsLimit)
            {
                throw new ArgumentOutOfRangeException(
                    $"Skill points can only range between -{SkillPointsLimit} and {SkillPointsLimit}.");
            }

            _skillPoints_2 = value;
        }
    }

    private int _slotsCount { get; set; }
    public int SlotsCount
    {
        get => _slotsCount;
        set
        {
            if (value < 0 || value > 3)
            {
                throw new ArgumentOutOfRangeException(
                    "Slots count must be between 0 and 3.");
            }

            _slotsCount = value;
        }
    }

    protected override void ParseBuffer(HexValueCategory category, byte[] buffer)
    {
        base.ParseBuffer(category, buffer);

        byte skill_1 = buffer[Constants.CharmSkillPosition_1];
        string skillHex_1 = ByteArrayExtensions.GetHexFromDecimal255(skill_1);
        Skill_1 = HexData.Collection[HexValueCategory.Skill, skillHex_1];

        byte skill_2 = buffer[Constants.CharmSkillPosition_2];
        string skillHex_2 = ByteArrayExtensions.GetHexFromDecimal255(skill_2);
        Skill_2 = HexData.Collection[HexValueCategory.Skill, skillHex_2];

        SkillPoints_1 = buffer[Constants.CharmSkillPointsPosition_1];
        SkillPoints_2 = buffer[Constants.CharmSkillPointsPosition_2];

        SlotsCount = buffer[Constants.CharmSlotsCountPosition];
    }

    protected override HexValue ParseValue(HexValueCategory category, byte[] buffer)
    {
        byte charm = buffer[Constants.CharmValuePosition];
        string charmHex = ByteArrayExtensions.GetHexFromDecimal16(charm, true);
        return HexData.Collection[HexValueCategory.Charm, charmHex];
    }

    public override async Task WriteEquipmentValue(FileStream stream, int offset)
    {
        byte[] value = Value.GetBytesOrDefault(Constants.ItemIdentifierLength);

        stream.Seek(offset + Constants.CharmValuePosition, SeekOrigin.Begin);
        stream.WriteByte(value[0]);
    }

    public override async Task WriteEquipmentCustom(FileStream stream, int offset)
    {
        byte[] skill_1 = Skill_1.GetBytesOrDefault(Constants.CharmSkillLength);
        byte[] skill_2 = Skill_2.GetBytesOrDefault(Constants.CharmSkillLength);

        stream.Seek(offset + Constants.CharmSkillPosition_1, SeekOrigin.Begin);
        stream.WriteByte(skill_1[0]);

        stream.Seek(offset + Constants.CharmSkillPosition_2, SeekOrigin.Begin);
        stream.WriteByte(skill_2[0]);

        stream.Seek(offset + Constants.CharmSkillPointsPosition_1, SeekOrigin.Begin);
        stream.WriteByte((byte)SkillPoints_1);

        stream.Seek(offset + Constants.CharmSkillPointsPosition_2, SeekOrigin.Begin);
        stream.WriteByte((byte)SkillPoints_2);

        stream.Seek(offset + Constants.CharmSlotsCountPosition, SeekOrigin.Begin);
        stream.WriteByte((byte)SlotsCount);
    }
}
