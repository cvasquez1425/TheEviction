using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class Eviction
    {
        public int EvictionId { get; set; }
        public int ClientId { get; set; }
        public int MatterId { get; set; }
        public int? CourtDtId { get; set; }
        public int? AttorneyId { get; set; }
        public int? StatusId { get; set; }
        public int? UserId { get; set; }
        public int? GenderId { get; set; }
        public int? NoticeTypeId { get; set; }
        public int? CourierId { get; set; }
        public int? CourierInstructionId { get; set; }
        public int PropertyTypeId { get; set; }
        public int? DefendantId { get; set; }
        public int? CourierDocId { get; set; }
        public int? LeaseTypeId { get; set; }
        public int? MailingAddressId { get; set; }
        public DateTime EnterDt { get; set; }
        public DateTime? ReceiveDt { get; set; }
        public DateTime? ExpireDt { get; set; }
        public string CaseNum { get; set; }
        public string CaseName { get; set; }
        public DateTime? FaResetDt { get; set; }
        public DateTime? NorDt { get; set; }
        public DateTime? WritDt { get; set; }
        public DateTime? DismissDt { get; set; }
        public string CourtroomNum { get; set; }
        public bool? Is24hrOutrageousFlg { get; set; }
        public bool? Is2448hrDrugAlcoholFlg { get; set; }
        public bool? Is72144hrRentFlg { get; set; }
        public bool? Is7dayWkToWkFlg { get; set; }
        public bool? Is10dayPetRepeatWkToWkFlg { get; set; }
        public bool? Is20dayRepeatViolationFlg { get; set; }
        public bool? Is3060180dayWoutCauseFlg { get; set; }
        public bool? Is30dWithCauseFlg { get; set; }
        public bool? IsOtherNoticeFlg { get; set; }
        public string OtherNoticeDesc { get; set; }
        public bool? IsNoNoticeFlg { get; set; }
        public string NoNoticeDesc { get; set; }
        public bool? Is24DomesticViolenceStalkingFlg { get; set; }
        public string IssueDesc { get; set; }
        public string Notes { get; set; }
        public string Agreement { get; set; }
        public string Noncompliant { get; set; }
        public bool? IsTrialFlg { get; set; }
        public bool? IsTrialFeePaidFlg { get; set; }
        public DateTime? LeaseDt { get; set; }
        public bool? IsReciprocalSvcFlg { get; set; }
        public decimal? MonthlyRentAmt { get; set; }
        public int? ProratedDays { get; set; }
        public DateTime? ServiceDt { get; set; }
        public decimal? AttyFeeAmt { get; set; }
        public decimal? OurCostAmt { get; set; }
        public DateTime? AdditionalRentBeginDt { get; set; }
        public DateTime? AdditionalRentEndDt { get; set; }
        public string MilitaryAffidavitNotes { get; set; }
        public bool? IsPaystayFlg { get; set; }
        public bool? IsMustVacateFlg { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public Attorney Attorney { get; set; }
        public Client Client { get; set; }
        public Courier Courier { get; set; }
        public CourierDoc CourierDoc { get; set; }
        public CourierInstructions CourierInstruction { get; set; }
        public CourtDate CourtDt { get; set; }
        public Defendant Defendant { get; set; }
        public Gender Gender { get; set; }
        public LeaseType LeaseType { get; set; }
        public Address MailingAddress { get; set; }
        public Matter Matter { get; set; }
        public PropertyType PropertyType { get; set; }
        public Status Status { get; set; }
        public Users User { get; set; }
    }
}
