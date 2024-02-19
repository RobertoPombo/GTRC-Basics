using System.ComponentModel.DataAnnotations;

namespace GTRC_Basics.Models.DTOs
{
    public class EntryEventFullDto : EntryEvent
    {
        public bool RegisterState
        {
            get { return GetRegisterState(this); }
            set { }
        }

        public bool SignInState
        {
            get { return GetSignInState(this); }
            set { }
        }

        public static bool GetRegisterState(EntryEvent obj)
        {
            return obj.Entry.RegisterDate < obj.Event.Date && obj.Entry.SignOutDate > obj.Event.Date;
        }

        public static bool GetSignInState(EntryEvent obj)
        {
            return obj.SignInDate < obj.Event.Date;
        }
    }


    public class EntryEventUniqPropsDto0 : Mapper<EntryEvent>
    {
        [Required] public int EntryId { get; set; }
        [Required] public int EventId { get; set; }
    }


    public class EntryEventAddDto : Mapper<EntryEvent>
    {
        public int? EntryId { get; set; }
        public int? EventId { get; set; }
        public DateTime? SignInDate { get; set; }
        public bool? IsOnEntrylist { get; set; }
        public bool? DidAttend { get; set; }
        public short? BallastKg { get; set; }
        public short? Restrictor { get; set; }
        public bool? IsPointScorer { get; set; }
        public ushort? Priority { get; set; }
    }


    public class EntryEventUpdateDto : EntryEventAddDto
    {
        [Required] public int Id { get; set; } = GlobalValues.NoId;
    }


    public class EntryEventFilterDto : EntryEventAddDto
    {
        public int? Id { get; set; }
        public string? Entry { get; set; }
        public string? Event { get; set; }
    }


    public class EntryEventFilterDtos
    {
        public EntryEventFilterDto Filter { get; set; } = new();
        public EntryEventFilterDto FilterMin { get; set; } = new();
        public EntryEventFilterDto FilterMax { get; set; } = new();
    }
}
